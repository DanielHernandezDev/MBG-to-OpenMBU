//-----------------------------------------------------------------------------
// Torque Game Engine
// 
// Copyright (c) 2001 GarageGames.Com
// Portions Copyright (c) 2001 by Sierra Online, Inc.
//-----------------------------------------------------------------------------

// Load up common script base
loadDir("common");

//-----------------------------------------------------------------------------
// Load up defaults console values.

// Defaults console values
exec("./client/defaults.cs");
exec("./server/defaults.cs");

// Preferences (overide defaults)
execPrefs("prefs.cs");
execPrefs("server_prefs.cs");
exec("./referrer.cs");


//-----------------------------------------------------------------------------
// Package overrides to initialize the mod.
package marble {

function displayHelp() {
   Parent::displayHelp();
   error(
      "Marble Mod options:\n"@
      "  -dedicated             Start as dedicated server\n"@
      "  -connect <address>     For non-dedicated: Connect to a game at <address>\n" @
      "  -mission <filename>    For dedicated or non-dedicated: Load the mission\n" @
      "  -test <.dif filename>  Test an interior map file\n"
   );
}

function parseArgs()
{
   // Call the parent
   Parent::parseArgs();

   // Arguments, which override everything else.
   for (%i = 1; %i < $Game::argc ; %i++)
   {
      %arg = $Game::argv[%i];
      %nextArg = $Game::argv[%i+1];
      %hasNextArg = $Game::argc - %i > 1;
   
      switch$ (%arg)
      {
         //--------------------
         case "-referrer":
            $argUsed[%i]++;
            if (%hasNextArg) {
               $referrerId = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -referrer <referrerid>");
         case "-mission":
            $argUsed[%i]++;
            if (%hasNextArg) {
               $missionArg = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -mission <filename>");

         case "-test":
            $argUsed[%i]++;
            if(%hasNextArg) {
               $testCheats = true;
               $interiorArg = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -test <interior filename>");
         //--------------------
         case "-cheats":
            $testCheats = true;
            $argUsed[%i]++;
      }
   }
}

function onStart()
{
   Parent::onStart();
   echo("\n--------- Initializing MOD: FPS ---------");

   // Load the scripts that start it all...
   exec("./client/init.cs");
   exec("./server/init.cs");
   exec("./data/init.cs");

   // Server gets loaded for all sessions, since clients
   // can host in-game servers.
   initServer();

   // Start up in either client, or dedicated server mode
   if ($Server::Dedicated)
      initDedicated();
   else
      initClient();
      preloadClientDataBlocks();
}

function onExit()
{
   echo("Exporting client prefs");
   export("$pref::*", "prefs.cs", False);

   echo("Exporting server prefs");
   export("$Pref::Server::*", "server_prefs.cs", False);

   Parent::onExit();
}

}; // Client package
activatePackage(marble);

function listResolutions()
{
   %deviceList = getDisplayDeviceList();
   for(%deviceIndex = 0; (%device = getField(%deviceList, %deviceIndex)) !$= ""; %deviceIndex++)
   {
      %resList = getResolutionList(%device);
      for(%resIndex = 0; (%res = getField(%resList, %resIndex)) !$= ""; %resIndex++)
         echo(%device @ " - " @ getWord(%res, 0) @ " x " @ getWord(%res, 1) @ " (" @ getWord(%res, 2) @ " bpp)");
   }
}

//-------------------------------------------------------------
// Below is some code for testing for memory leaks.  It creates
// an interior and deletes it and then logs the leaked memory.
// It does the same for pathed interiors, items, marbles.  After
// that, it runs a mission -- twice -- for  10 seconds and records 
// leaks from the second running of the mission (so that one time
// instance data isn't included).  Before dumping the log, we delete
// all sorts of things that hold onto instance memory (but aren't
// leaks) and then we log it and quit.
//-------------------------------------------------------------
function testmem()
{
   profilerEnable(1);
   
   // schedule this out so the profiler 
   // enable has time to work (don't ask)
   schedule(100,0,"testMem2");
}

function testMem2()
{
   destroyServer();
   ServerGroup.delete();
   ServerConnection.delete();

   // ---------------------------   
   // Begin test interior leaks
   // ---------------------------   
   
   flagCurrentAllocs();
   
   $testItr = new InteriorInstance() {
      position = "0 0 0";
      rotation = "1 0 0 0";
      scale = "1 1 1";
      interiorFile = "marble/data/missions/Multiplayer/Walled Sprawl/sprawl_walled.dif";
      showTerrainInside = "0";
   };
   error("interior id:" SPC $testItr.getId());
   $testItr.delete();
   
   purgeResources();
   dumpUnflaggedAllocs("itrdmp.txt");
   
   // ---------------------------   
   // Begin test pathed interior leaks
   // ---------------------------   
   
   flagCurrentAllocs();
   
   $testPItr = new PathedInterior(MustChange) {
      position = "0 0 12";
      rotation = "1 0 0 0";
      scale = "1 1 1";
      hidden = "0";
      dataBlock = "PathedDefault";
      interiorResource = "marble/data/missions/advanced/Cube Root/cube.dif";
      interiorIndex = "0";
      basePosition = "0 0 0";
      baseRotation = "1 0 0 0";
      baseScale = "1 1 1";
      initialTargetPosition = "-1";
   };
   error("pathed interior id:" SPC $testPItr.getId());
   $testPItr.delete();
   
   purgeResources();
   dumpUnflaggedAllocs("pitrdmp.txt");
   
   // ---------------------------   
   // Begin test item leaks
   // ---------------------------   
   
   flagCurrentAllocs();

   $testItem = new Item() {
      position = "-7.69364 7.04311 89";
      rotation = "1 0 0 90";
      scale = "1 1 1";
      dataBlock = "AntiGravityItem";
      collideable = "0";
      static = "1";
      rotate = "1";
      permanent = "1";
   };
   error("item id:" SPC $testItem.getId());
   $testItem.delete();

   purgeResources();
   dumpUnflaggedAllocs("itemdmp.txt");
   
   // ---------------------------   
   // Begin test marble leaks
   // ---------------------------   

   flagCurrentAllocs();

   $testMarble = new Marble() {
      datablock = defaultMarble;
   };
   error("marble id:" SPC $testMarble.getId());
   $testMarble.delete();
   
   purgeResources();
   dumpUnflaggedAllocs("marbledmp.txt");

   // ---------------------------   
   // Begin test mission leaks
   // ---------------------------   

   flagCurrentAllocs();

   createServer("Multiplayer", "marble/data/missions/advanced/Battlements/battlements.mis");
   connectToPreviewServer();
   commandToServer('JoinGame');
   RootGui.setContent(PlayGui);
   schedule(10000,0,"againTestMem");   
}

function againTestMem()
{
   destroyServer();
   ServerConnection.delete();

   // ---------------------------   
   // Begin test mission leaks (2)
   // ---------------------------   

   flagCurrentAllocs();

   createServer("Multiplayer", "marble/data/missions/advanced/Battlements/battlements.mis");
   connectToPreviewServer();
   commandToServer('JoinGame');
   RootGui.setContent(PlayGui);
   schedule(10000,0,"finishTestMem");   
}

function finishTestMem()
{
   destroyServer();
   ServerConnection.delete();

   datablockgroup.delete(); // datablocks often hold onto memory that was allocated
                            // for instance purposes -- e.g., tsshapes are held onto
                            // by datablocks and tsshapes hold onto instance render
                            // data (should probably be done a little differently, but
                            // that's what we have got).  Deleting datablocks gets this
                            // memory off our radar -- at the risk of missing a leak --
                            // but requires us to exit when this function is done.

   sfxStopAll($SimAudioType); // stopping sounds should be handled by server destruction
                 // that it isn't properly (tons of sfx leaks if this line not
                 // included) indicates we may have a problem here.
                 
   cleanDetailManager(); // this gets rid of a bunch of accumulated working memory
                         // it isn't strictly a leak (much like console dictionaries,
                         // datachunkers, and frameallocator) but gets in the way
                         // of seeing the real leaks.
                         
   clearServerPaths();  // Server path manager is normally cleared out pre mission-load.
   clearClientPaths();  // Client path manager is cleared out indirectly in the process.
                        // We clear them both out here so that they don't appear as
                        // leaks.

   RootGui.delete();    // Get rid of all gui's since they hold some memory that may have
   GuiGroup.delete();   // been created by playing mission (but not leaks).
   GuiDataGroup.delete();
   
   cleanPrimBuild();    // clean out anything prim builder holding onto
   
   purgeResources();
   dumpUnflaggedAllocs("missiondmp.txt");
   
   schedule(1000,0,"quit");
}