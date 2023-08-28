//-----------------------------------------------------------------------------
// Torque Game Engine
//
// Copyright (c) 2001 GarageGames.Com
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Penalty and bonus times.
$Game::TimeTravelBonus = 5000;

// Item respawn values, only powerups currently respawn
$Item::PopTime = 10 * 1000;
$Item::RespawnTime = 7 * 1000;

// Game duration in secs, no limit if the duration is set to 0
$Game::Duration = 0;

// Pause while looking over the end game screen (in secs)
$Game::EndGamePause = 5;

// Simulated net parameters
$Game::packetLoss = 0;
$Game::packetLag = 0;

//-----------------------------------------------------------------------------
// Variables extracted from the mission
$Game::GemCount = 0;
$Game::StartPad = 0;
$Game::EndPad = 0;

// Variables for tracking end game condition
$Game::GemsFound = 0;
$Game::ClientsFinished = 0;


//-----------------------------------------------------------------------------
//  Functions that implement game-play
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------

function onServerCreated()
{
   // Server::GameType is sent to the master server.
   // This variable should uniquely identify your game and/or mod.
   $Server::GameType = "Marble Game";

   // Server::MissionType sent to the master server.  Clients can
   // filter servers based on mission type.
   $Server::MissionType = "Deathmatch";

   // GameStartTime is the sim time the game started. Used to calculated
   // game elapsed time.
   $Game::StartTime = 0;

   // Load up all datablocks, objects etc.  This function is called when
   // a server is constructed.
   exec("./audioProfiles.cs");
   exec("./camera.cs");
   exec("./markers.cs");
   exec("./triggers.cs");
   exec("./inventory.cs");
   exec("./shapeBase.cs");
   exec("./staticShape.cs");
   exec("./item.cs");
   exec("./worldObjects.cs");

   // Basic items
   exec("./powerUps.cs");
   exec("./marble.cs");
   exec("./gems.cs");
   exec("./buttons.cs");
   exec("./hazards.cs");
   exec("./pads.cs");
   exec("./bumpers.cs");
   exec("./signs.cs");
   exec("./fireworks.cs");

   exec("./glowBuffer.cs");

	// stuff
	exec("./checkpoint.cs");
	exec("./teleporter.cs");
   
   // Platforms and interior doors
   exec("./pathedInteriors.cs");

   // Keep track of when the game started
   $Game::StartTime = $Sim::Time;
  
   exec("common/server/lightingSystem.cs");
}

function onServerDestroyed()
{
   // Perform any game cleanup without actually ending the game
   destroyGame();
}


//-----------------------------------------------------------------------------

function onMissionLoaded()
{
   // Called by loadMission() once the mission is finished loading.
   updateHostedMatchInfo();
   updateServerParams();

   // Start the game in a wait state
   setGameState("wait");
   
   $Game::GemCount = countGems(MissionGroup);

   //setGravityDir("1 0 0 0 -1 0 0 0 -1",true);

   // Start the game here if multiplayer...
   if ($Server::ServerType $= "MultiPlayer")
      startGame();
}

function onMissionEnded()
{
   // Called by endMission(), right before the mission is destroyed
   // This part of a normal mission cycling or end.
   endGame();
}

function onMissionReset()
{
   //setGravityDir("1 0 0 0 -1 0 0 0 -1",true);
   endFireWorks();
   if (isObject(ServerGroup))
      ServerGroup.onMissionReset();

   // Reset globals for next round
   $tied = false;
   $Game::GemsFound = 0;
   $Game::ClientsFinished = 0;
   $timeKeeper = 0;
   
   // Reset the players and inform them we're starting
   for( %clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++ ) {
      %cl = ClientGroup.getObject( %clientIndex );
      commandToClient(%cl, 'GameStart');
      %cl.resetStats();
   }

   // Start the game duration timer
   if ($Game::Duration)
      $Game::CycleSchedule = schedule($Game::Duration * 1000, 0, "onGameDurationEnd" );
   $Game::Running = true;

   ServerGroup.onMissionReset();

   // Set the initial state
   setGameState("Start");
}

function SimGroup::onMissionReset(%this, %checkpointConfirmNum )
{
   for(%i = 0; %i < %this.getCount(); %i++)
      %this.getObject(%i).onMissionReset( %checkpointConfirmNum );
}

function SimObject::onMissionReset(%this, %checkpointConfirmNum)
{
}

function GameBase::onMissionReset(%this, %checkpointConfirmNum)
{
   %this.getDataBlock().onMissionReset(%this, %checkpointConfirmNum);
}

//-----------------------------------------------------------------------------

function startGame()
{
   if ($Game::Running) {
      error("startGame: End the game first!");
      return;
   }
   $Game::Running = true;
   $Game::Qualified = false;
   onMissionReset();

   resetAvgPlayerCount();
}

function endGame()
{
   if (!$Game::Running) {
      error("endGame: No game running!");
      return;
   }
   destroyGame();

   // Inform the clients the game is over
   for (%index = 0; %index < ClientGroup.getCount(); %index++)  {
      %client = ClientGroup.getObject(%index);
      commandToClient(%client, 'GameEnd');
   }

   // Single player... grab the playgui as the elapsed time and
   // roll in clients penalty and bonus
   PlayGUI.stopTimer();

   $Game::ScoreTime = PlayGui.elapsedTime;
   $Game::ElapsedTime = PlayGui.elapsedTime - %client.penaltyTime + PlayGui.totalBonus;
   $Game::PenaltyTime = %client.penaltyTime;
   $Game::BonusTime = PlayGui.totalBonus;

   // Not all missions have time qualifiers
   $Game::Qualified = MissionInfo.time? $Game::ScoreTime < MissionInfo.time: true;

   // Bump up the max level
   if (!$playingDemo && $Game::Qualified && (MissionInfo.level + 1) > $Pref::QualifiedLevel[MissionInfo.type])
         $Pref::QualifiedLevel[MissionInfo.type] = MissionInfo.level + 1;
}

$pauseTimescale = 0.00001;

function pauseGame()
{
   // we always store a variable indicating when they have requested a game pause (the UI keys off this)
   $gamePauseWanted = true;
   stopDemoTimer(); 
   //sfxPauseAll();
   //sfxPause($SimAudioType);
   //if(xbHasPlaybackControl())
   //   pauseMusic();
   if ($Server::ServerType $= "SinglePlayer")
      $gamePaused = true;
}

function resumeGame()
{
   $gamePaused = false;
   $gamePauseWanted = false;
   //sfxUnpauseAll();
   sfxResume();
   //if(xbHasPlaybackControl())
   //   unpauseMusic();
   // restart demo timer if necessary
}

function destroyGame()
{
   // Cancel any client timers
   for (%index = 0; %index < ClientGroup.getCount(); %index++)
      cancel(ClientGroup.getObject(%index).respawnSchedule);

   // Perform cleanup to reset the game.
   cancel($Game::CycleSchedule);
   cancel($Game::StateSchedule);

   $Game::Running = false;
}


//-----------------------------------------------------------------------------

function setGameState(%state)
{
   cancel($Game::StateSchedule);
   $Game::State = %state;
   eval("State::"@%state@"();");
   echo("State "@%state@"");
}

function State::start()
{
   PlayGui.resetTimer();
   PlayGui.setTimer(0);
   PlayGui.setMessage("");
   PlayGui.setGemCount(0);
   PlayGui.setMaxGems($Game::GemCount);
   $Game::StateSchedule = schedule( 500, 0, "setGameState", "Ready");
   if(MissionInfo.startHelpText !$= "")
   {
      addHelpLine(MissionInfo.startHelpText, false);
   }
}

function State::ready()
{
   serverPlay2d(ReadyVoiceSfx);
   PlayGui.setMessage("ready");
   $Game::StateSchedule = schedule( 1500, 0, "setGameState", "set");
}

function State::set()
{
   serverPlay2d(SetVoiceSfx);
   PlayGui.setMessage("set");
   $Game::StateSchedule = schedule( 1500, 0, "setGameState", "Go");
}

function State::go()
{
   serverPlay2d(GetRollingVoiceSfx);
   PlayGui.setMessage("go");
   PlayGui.startTimer();
   $Game::StateSchedule = schedule( 2000, 0, "setGameState", "Play");

   // Target the players to the end pad and let them lose
   for( %index = 0; %index < ClientGroup.getCount(); %index++ ) {
      %player = ClientGroup.getObject(%index).player;
      %player.setPad($Game::EndPad);
      %player.setMode(Normal);
   }
}

function State::play()
{
   // Normaly play mode
   PlayGui.setMessage("");
}

function State::end()
{
   // Do score calculations, messages to winner, losers, etc.
   PlayGUI.stopTimer();
   serverplay2d(WonRaceSfx);
   startFireWorks(EndPoint);
   $Game::StateSchedule = schedule( 2000, 0, "endGame");
}


//-----------------------------------------------------------------------------

function onGameDurationEnd()
{
   // This "redirect" is here so that we can abort the game cycle if
   // the $Game::Duration variable has been cleared, without having
   // to have a function to cancel the schedule.
   if ($Game::Duration && !isObject(EditorGui))
      cycleGame();
}

function cycleGame()
{
   // This is setup as a schedule so that this function can be called
   // directly from object callbacks.  Object callbacks have to be
   // carefull about invoking server functions that could cause
   // their object to be deleted.
   if (!$Game::Cycling) {
      $Game::Cycling = true;
      $Game::CycleSchedule = schedule(0, 0, "onCycleExec");
   }
}

function onCycleExec()
{
   // End the current game and start another one, we'll pause for a little
   // so the end game victory screen can be examined by the clients.
   endGame();
   $Game::CycleSchedule = schedule($Game::EndGamePause * 1000, 0, "onCyclePauseEnd");
}

function onCyclePauseEnd()
{
   $Game::Cycling = false;
   loadNextMission();
}

function loadNextMission()
{
   %nextMission = "";

   // Cycle to the next level, or back to the start if there aren't
   // any more levels.
   for (%file = findFirstFile($Server::MissionFileSpec);
         %file !$= ""; %file = findNextFile($Server::MissionFileSpec))
      if (strStr(%file, "CVS/") == -1 && strStr(%file, "common/") == -1)
      {
         %mission = getMissionObject(%file);
         if (%mission.type $= MissionInfo.type) {
            if (%mission.level == 1)
               %nextMission = %file;
            if ((%mission.level + 0) == MissionInfo.level + 1) {
               echo("Found one!");
               %nextMission = %file;
               break;
            }
         }
      }
   loadMission(%nextMission);
}



//-----------------------------------------------------------------------------
// GameConnection Methods
// These methods are extensions to the GameConnection class. Extending
// GameConnection make is easier to deal with some of this functionality,
// but these could also be implemented as stand-alone functions.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------

function GameConnection::incPenaltyTime(%this,%dt)
{
   %this.penaltyTime += %dt;
}

function GameConnection::incBonusTime(%this,%dt)
{
   %this.player.setMarbleBonusTime(%this.player.getMarbleBonusTime() + %dt);
}


//-----------------------------------------------------------------------------

function GameConnection::onClientEnterGame(%this)
{
   // Create a new camera object.
   %this.camera = new Camera() {
      dataBlock = Observer;
   };
   MissionCleanup.add( %this.camera );
   %this.camera.scopeToClient(%this);

   // Setup game parameters and create the player
   %this.resetStats();
   %this.spawnPlayer();

   // Anchor the player to the start pad
   %this.player.setMode(Start);

   // Start the game here for single player
   if ($Server::ServerType $= "SinglePlayer")
      startGame();
}

function GameConnection::onClientLeaveGame(%this)
{
   if (isObject(%this.camera))
      %this.camera.delete();
   if (isObject(%this.player))
      %this.player.delete();
}

function GameConnection::resetStats(%this)
{
   // Reset game stats
   %this.bonusTime = 0;
   %this.penaltyTime = 0;
   %this.gemCount = 0;

   // Reset the checkpoint
   if (isObject(%this.checkPoint))
      %this.checkPoint.delete();
   %this.checkPoint = new ScriptObject() {
      pad = $Game::StartPad;
      time = 0;
      gemCount = 0;
      penaltyTime = 0;
      bonusTime = 0;
      powerUp = 0;
   };
}


//-----------------------------------------------------------------------------

function GameConnection::onEnterPad(%this)
{
   if (%this.player.getPad() == $Game::EndPad) {

      if ($Game::GemCount && %this.gemCount < $Game::GemCount) {
         %this.play2d(MissingGemsSfx);
         messageClient(%this, 'MsgMissingGems', '\c0You can\'t finish without all the gems!!');
      }
      else {
         %this.player.setMode(Victory);
         messageClient(%this, 'MsgRaceOver', '\c0Congratulations! You\'ve finished!');
         setGameState("End");
      }
   }
}

function GameConnection::onLeavePad(%this)
{
   // Don't care if the leave
}


//-----------------------------------------------------------------------------

function GameConnection::onOutOfBounds(%this)
{
   if ($Game::State $= "End")
      return;

   // Reset the player back to the last checkpoint
   PlayGui.setMessage("outOfBounds",2000);
   %this.play2d(OutOfBoundsVoiceSfx);
   %this.player.setOOB(true);
   if(!isEventPending(%this.respawnSchedule))
      %this.respawnSchedule = %this.schedule(2500, respawnPlayer);
}

function Marble::onOOBClick(%this)
{
   if($Game::State $= "Play")
      ClientGroup.getObject(0).respawnPlayer();
}

function GameConnection::onDestroyed(%this)
{
   if ($Game::State $= "End")
      return;

   // Reset the player back to the last checkpoint
   PlayGui.setMessage("destroyed",2000);
   %client.play2d(DestroyedVoiceSfx);
   %this.player.setOOB(true);
   if(!isEventPending(%this.respawnSchedule))
      %this.respawnSchedule = %this.schedule(2500, respawnPlayer);
}

function GameConnection::onFoundGem(%this,%amount)
{
   %this.gemCount += %amount;
   %remaining = $Game::gemCount - %this.gemCount;
   if (%remaining <= 0) {
      messageClient(%this, 'MsgHaveAllGems', '\c0You have all the gems, head for the finish!');
      %this.play2d(GotAllGemsSfx);
      %this.gemCount = $Game::GemCount;
   }
   else
   {
      if(%remaining == 1)
         %msg = '\c0You picked up a gem.  Only one gem to go!';
      else
         %msg = '\c0You picked up a gem.  %1 gems to go!';

      messageClient(%this, 'MsgItemPickup', %msg, %remaining);
      %this.play2d(GotGemSfx);
   }

   PlayGui.setGemCount(%this.gemCount);
}


//-----------------------------------------------------------------------------

function GameConnection::spawnPlayer(%this)
{
   // Combination create player and drop him somewhere
   %spawnPoint = %this.getCheckpointPos();
   %this.createPlayer(%spawnPoint);
   serverPlay3d(spawnSfx, %this.player.getTransform());
}

function restartLevel()
{
   LocalClientConnection.respawnPlayer();
}

function GameConnection::respawnPlayer(%this)
{
   // Reset the player back to the last checkpoint
   cancel(%this.respawnSchedule);
   onMissionReset();
   
   %this.player.setMarbleBonusTime(0);

   // If we restarted the level, reset the blast energy
   //%this.player.setBlastEnergy( 0.0 );

   %this.player.setOOB(false);
   %this.player.setVelocity("0 0 0");
   %this.player.setVelocityRot("0 0 0");

   setGameState("start");
   %this.player.setMode(Start);
   %this.player.setMarbleTime(0);
   %this.gemCount = 0;
   commandToClient(%this, 'setGemCount', %this.gemCount, $Game::GemCount);
   %this.player.setPosition(%this.getCheckpointPos(), 0.45);
   %this.player.setGravityDir("1 0 0 0 -1 0 0 0 -1",true);
   faceGems( %this.player );
   %this.player.setPowerUp(%this.checkPoint.powerUp,true);

   %this.gemCount = %this.checkPoint.gemCount;
   %this.penaltyTime = %this.checkPoint.penaltyTime;
   %this.bonusTime = %this.checkPoint.bonusTime;

   PlayGUI.setTimer(%this.checkPoint.time);
   PlayGui.setGemCount(%this.gemCount);
   serverPlay3d(spawnSfx, %this.player.getTransform());
}

//-----------------------------------------------------------------------------

function GameConnection::createPlayer(%this, %spawnPoint)
{
   if (%this.player > 0)  {
      // The client should not have a player currently
      // assigned.  Assigning a new one could result in
      // a player ghost.
      error( "Attempting to create an angus ghost!" );
   }

   %player = new Marble() {
      dataBlock = DefaultMarble;
      client = %this;
   };
   MissionCleanup.add(%player);

   // Player setup...
   %spawnPos = getSpawnPosition(%spawnPoint);
   %player.setPosition(%spawnPoint, 0.45);
   %player.setEnergyLevel(60);
   %player.setShapeName(%this.name);
   %player.client.status = 1;
   if ($Server::ServerType $= "MultiPlayer")
      %player.setUseFullMarbleTime(true);
   
   %player.setGravityDir("1 0 0 0 -1 0 0 0 -1",true);

   // Update the camera to start with the player
   %this.camera.setTransform(%player.getEyeTransform());

   // Give the client control of the player
   %this.player = %player;
   %this.setControlObject(%player);
}


//-----------------------------------------------------------------------------

function GameConnection::setCheckpoint(%this,%object)
{
   // Store the last checkpoint which will be used to restore
   // the player when he goes out of bounds.
   if (%object != %this.checkPoint.pad) {
      %this.checkPoint.delete();
      %this.checkPoint = new ScriptObject() {
         pad = %object;
         time = PlayGUI.elapsedTime;
         gemCount = %this.gemCount;
         penaltyTime = %this.penaltyTime;
         bonusTime = %this.bonusTime;
         powerUp = %this.player.getPowerUp();
      };

      messageClient(%this, 'MsgCheckPoint', "\c0Check Point " @ %object.number @ " reached!");
   }
}

function GameConnection::getCheckpointPos(%this,%num)
{
   // Return the point a little above the object's center
   if (!isObject(%this.checkPoint.pad))
      return "0 0 300 1 0 0 0";
   return vectorAdd(%this.checkPoint.pad.getTransform(),"0 0 3") SPC
                    getWords(%this.checkPoint.pad.getTransform(), 3);
}

//-----------------------------------------------------------------------------
// Support functions
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------

function countGems(%group)
{
   // Count up all gems out there are in the world
   %gems = 0;
   for (%i = 0; %i < %group.getCount(); %i++)
   {
      %object = %group.getObject(%i);
      %type = %object.getClassName();
      if (%type $= "SimGroup")
         %gems += countGems(%object);
      else
         if (%type $= "Item" &&
               %object.getDatablock().classname $= "Gem")
            %gems++;
   }
   return %gems;
}

//----------------------------------------------------------------------------
// Game events sent from the server
//----------------------------------------------------------------------------
function formatTime(%time)
{
   %isNeg = "";
   if (%time < 0)
   {
      %time = -%time;
      %isNeg = "-";
   }
   
   // Hack for italian
   if( getLanguage() $= "italian" )
      %secondSeperator = ":";
   else
      %secondSeperator = ".";
   
   %hundredth = mFloor((%time % 1000) / 10);
   %totalSeconds = mFloor(%time / 1000);
   %seconds = %totalSeconds % 60;
   %minutes = (%totalSeconds - %seconds) / 60;
   %secondsOne   = %seconds % 10;
   %secondsTen   = (%seconds - %secondsOne) / 10;
   %minutesOne   = %minutes % 10;
   %minutesTen   = (%minutes - %minutesOne) / 10;
   %hundredthOne = %hundredth % 10; 
   %hundredthTen = (%hundredth - %hundredthOne) / 10;
   
   return %isNeg @ %minutesTen @ %minutesOne @ ":" @
       %secondsTen @ %secondsOne @ %secondSeperator @
       %hundredthTen @ %hundredthOne;
}

$Game::clientHiddenTime = 800;

function MarbleData::onClientCollision(%this,%obj,%col)
{
   // JMQ: workaround: skip hidden objects  
   if (%col.isHidden())
      return;
      
   // Try and pickup all items
   if (%col.getClassName() !$= "Item")
      return;

   %data = %col.getDatablock();

   if (%data.getName() $= "GemItem")
   {
      // it's a gem, simply hide the gem and leave, let the server
      // play sounds and update our gem count
      %col.setClientHidden($Game::clientHiddenTime);
      return;
   }

   if (strstr(%data.shapeFile,"ravity.dts") != -1)
   {
      // Must be the anti-gravity powerup (searched for
      // "ravity" in order to avoid potential caps issues).
      %rotation = getWords(%col.getTransform(),3);
      %ortho = vectorOrthoBasis(%rotation);
      %down = getWords(%ortho,6);
      if (VectorDot(%obj.getGravityDir(),%down)>0.9)
         // Don't pick up if same as current gravity:
         return;
      %obj.setGravityDir(%ortho);
   }

   if (%data.powerupId && (%data.powerUpId == %obj.getPowerUpId()))
   {
      // already have this powerup...don't pick up
      return;
   }

   // hide the powerup
   if (!%col.permanent)
      %col.setClientHidden($Game::clientHiddenTime);

   // The rest of this code handles client side pickup of powerups
   // Only do this if we are the control object.
   if (ServerConnection.getControlObject().getId() != %obj.getId())
   {
      //error("not control object" SPC ServerConnection.getControlObject().getId() SPC %obj.getId());
      return;
   }
      
   if (strstr(%data.shapeFile,"ravel.dts") != -1)
   {
      // Must be the time travel powerup (searched for
      // "ravel" in order to avoid potential caps issues).
      // Add some bonus time -- guess at the value, doesn't have
      // to be right because we'll be updated soon if it's wrong.
      %obj.setMarbleBonusTime(%obj.getMarbleBonusTime() + 5000);
   }

   // pick up the powerup
   if (%data.powerUpId)
      %obj.setPowerUpId(%data.powerUpId);
}

function TrapDoor::onClientCollision(%this,%obj,%col)
{
   // Hard-code open time to 200 ms since that is the only
   // value we actually use in the game.
   %obj.playThread(0,"fall",1,200);
}

//------------------------------------------------------------------------------

function clientCmdSetTimer(%cmd,%time)
{
   switch$ (%cmd)
   {
      case "reset":
         PlayGui.resetTimer();
      case "start":
         PlayGui.startTimer();
      case "stop":
         PlayGui.stopTimer();
      case "set":
         PlayGui.setTimer(%time);
   }
}

function clientCmdSetGemCount(%gems,%maxGems)
{
   PlayGui.setGemCount(%gems);
   PlayGui.setMaxGems(%maxGems);
}

function clientCmdSetPoints(%clientid, %points)
{
   PlayGui.setPoints(%clientid, %points);
}

function clientCmdSetGameDuration(%duration, %playStart)
{
   PlayGui.gameDuration = %duration;
   PlayGui.setTimer(0);
         
   if (%playStart > 0)
      $Client::LastGamePlayStart = %playStart;
}

function clientCmdSetEndTime(%playEnd)
{
   $Client::LastGamePlayEnd = %playEnd;
}

function clientCmdSetPowerup(%shapeFile)
{
   PlayGui.setPowerUp(%shapeFile);
}