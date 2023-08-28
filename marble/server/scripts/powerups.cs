//-----------------------------------------------------------------------------
// Torque Game Engine
// 
// Copyright (c) 2001 GarageGames.Com
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// PowerUp base class
//-----------------------------------------------------------------------------

// function PowerUp::onPickup(%this,%obj,%user,%amount)
// {
//    // Dont' pickup the power up if it's the same
//    // one we already have.
//    if (%user.powerUpData == %this)
//       return false;

//    // Grab it...
//    %user.client.play2d(%this.pickupAudio);
//    if (%this.powerUpId)
//    {
//       if(%obj.showHelpOnPickup)
//          addHelpLine("Press <func:bind mouseFire> to use the " @ %this.useName @ "!", false);
   
//       %user.setPowerUp(%this);
//    }
//    Parent::onPickup(%this, %obj, %user, %amount);
//    return true;
// }

function PowerUp::onPickup(%this,%obj,%user,%amount)
{
   // Dont' pickup the power up if it's the same
   // one we already have.
   if (%user.powerUpData == %this)
      return false;

   // Grab it...
   %user.client.play2d(%this.pickupAudio);
   if (%this.powerUpId)
   {
      if(%obj.showHelpOnPickup)
      {
         %text = avar($Text::PullToUse, %this.useName);
         addHelpLine("Press <func:bind mouseFire> to use the " @ %this.useName @ "!", false);
      }
   
      %user.setPowerUp(%this);
   }
   Parent::onPickup(%this, %obj, %user, %amount);
   return true;
}


//-----------------------------------------------------------------------------

datablock SFXProfile(doSuperJumpSfx)
{
   filename    = "~/data/sound/doSuperJump.wav";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(PuSuperJumpVoiceSfx)
{
   filename    = "~/data/sound/puSuperJumpVoice.wav";
   description = Audio2D;
   preload = true;
};

datablock ItemData(SuperJumpItem)
{
   // Mission editor category
   category = "Powerups";
   className = "PowerUp";
   powerUpId = 1;

   activeAudio = DoSuperJumpSfx;
   pickupAudio = PuSuperJumpVoiceSfx;

   // Basic Item properties
   shapeFile = "~/data/shapes/items/superjump.dts";
   mass = 1;
   friction = 1;
   elasticity = 0.3;
   emap = false;

   // Dynamic properties defined by the scripts
   pickupName = "a Super Jump PowerUp!";
   useName = "Super Jump PowerUp";
   maxInventory = 1;
};


//-----------------------------------------------------------------------------

datablock SFXProfile(doSuperBounceSfx)
{
   filename    = "~/data/sound/doSuperBounce.wav";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(PuSuperBounceVoiceSfx)
{
   filename    = "~/data/sound/puSuperBounceVoice.wav";
   description = Audio2D;
   preload = true;
};

datablock ItemData(SuperBounceItem)
{
   // Mission editor category
   category = "Powerups";
   className = "PowerUp";
   powerUpId = 3;

   pickupAudio = PuSuperBounceVoiceSfx;

   // Basic Item properties
   shapeFile = "~/data/shapes/items/superbounce.dts";
   mass = 1;
   friction = 1;
   elasticity = 0.3;

   // Dynamic properties defined by the scripts
   pickupName = "a Super Bounce PowerUp!";
   useName = "Super Bounce PowerUp";
   maxInventory = 1;
};

datablock SFXProfile(SuperBounceLoopSfx)
{
   filename    = "~/data/sound/forcefield.wav";
   description = AudioClosestLooping3d;
   preload = true;
};

datablock ShapeBaseImageData(SuperBounceImage)
{
   // Basic Item properties
   shapeFile = "~/data/shapes/images/glow_bounce.dts";
   emap = true;

   // Specify mount point & offset for 3rd person, and eye offset
   // for first person rendering.
   mountPoint = 0;
   offset = "0 0 0";
   stateName[0] = "Blah";
   stateSound[0] = SuperBounceLoopSfx;
};


//-----------------------------------------------------------------------------

datablock SFXProfile(doSuperSpeedSfx)
{
   filename    = "~/data/sound/doSuperSpeed.wav";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(PuSuperSpeedVoiceSfx)
{
   filename    = "~/data/sound/puSuperSpeedVoice.wav";
   description = Audio2D;
   preload = true;
};

datablock ItemData(SuperSpeedItem)
{
   // Mission editor category
   category = "Powerups";
   className = "PowerUp";
   powerUpId = 2;

   activeAudio = DoSuperSpeedSfx;
   pickupAudio = PuSuperSpeedVoiceSfx;

   // Basic Item properties
   shapeFile = "~/data/shapes/items/superspeed.dts";
   mass = 1;
   friction = 1;
   elasticity = 0.3;
   emap = false;

   // Dynamic properties defined by the scripts
   pickupName = "a Super Speed PowerUp!";
   useName = "Super Speed PowerUp";
   maxInventory = 1;
};


//-----------------------------------------------------------------------------

datablock SFXProfile(doShockAbsorberSfx)
{
   filename    = "~/data/sound/doShockAbsorber.wav";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(PuShockAbsorberVoiceSfx)
{
   filename    = "~/data/sound/puShockAbsorberVoice.wav";
   description = Audio2D;
   preload = true;
};

datablock ItemData(ShockAbsorberItem)
{
   // Mission editor category
   category = "Powerups";
   className = "PowerUp";
   powerUpId = 4;

   activeAudio = DoShockAbsorberSfx;
   pickupAudio = PuShockAbsorberVoiceSfx;

   // Basic Item properties
   shapeFile = "~/data/shapes/items/shockabsorber.dts";
   mass = 1;
   friction = 1;
   elasticity = 0.3;

   // Dynamic properties defined by the scripts
   pickupName = "a Shock Absorber PowerUp!";
   useName = "Shock Absorber PowerUp";
   maxInventory = 1;
   emap = false;
};

datablock SFXProfile(ShockLoopSfx)
{
   filename    = "~/data/sound/superbounceactive.wav";
   description = AudioClosestLooping3d;
   preload = true;
};

datablock ShapeBaseImageData(ShockAbsorberImage)
{
   // Basic Item properties
   shapeFile = "~/data/shapes/images/glow_bounce.dts";
   emap = true;

   // Specify mount point & offset for 3rd person, and eye offset
   // for first person rendering.
   mountPoint = 0;
   offset = "0 0 0";
   stateName[0] = "Blah";
   stateSound[0] = ShockLoopSfx;
};


//-----------------------------------------------------------------------------

datablock SFXProfile(PuGyrocopterVoiceSfx)
{
   filename    = "~/data/sound/puGyrocopterVoice.wav";
   description = Audio2D;
   preload = true;
};

datablock ItemData(HelicopterItem)
{
   // Mission editor category
   category = "Powerups";
   className = "PowerUp";
   powerUpId = 5;

   pickupAudio = PuGyrocopterVoiceSfx;

   // Basic Item properties
   shapeFile = "~/data/shapes/images/helicopter.dts";
   mass = 1;
   friction = 1;
   elasticity = 0.3;

   // Dynamic properties defined by the scripts
   pickupName = "a Gyrocopter PowerUp!";
   useName = "Gyrocopter PowerUp";
   maxInventory = 1;
};

datablock SFXProfile(HelicopterLoopSfx)
{
   filename    = "~/data/sound/Use_Gyrocopter.wav";
   description = AudioClosestLooping3d;
   preload = true;
};

datablock ShapeBaseImageData(HelicopterImage)
{
   // Basic Item properties
   shapeFile = "~/data/shapes/images/helicopter.dts";
   emap = true;
   mountPoint = 0;
   offset = "0 0 0";
   stateName[0]                     = "Rotate";
   stateSequence[0]                 = "rotate";
   stateSound[0] = HelicopterLoopSfx;
   ignoreMountRotation = true;
};


//-----------------------------------------------------------------------------
// Special non-inventory power ups
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------

datablock SFXProfile(PuTimeTravelVoiceSfx)
{
   filename    = "~/data/sound/puTimeTravelVoice.wav";
   description = Audio2D;
   preload = true;
};

datablock ItemData(TimeTravelItem)
{
   // Mission editor category
   category = "Powerups";
   className = "PowerUp";

   // Basic Item properties
   pickupAudio = PuTimeTravelVoiceSfx;
   shapeFile = "~/data/shapes/items/timetravel.dts";
   mass = 1;
   friction = 1;
   elasticity = 0.3;
   emap = false;

   // Dynamic properties defined by the scripts
   noRespawn = true;
   maxInventory = 1;
};

function TimeTravelItem::getPickupName(%this, %obj)
{
   if(%obj.timeBonus !$= "")
      %time = %obj.timeBonus / 1000;
   else
      %time = $Game::TimeTravelBonus / 1000;

   return "a " @ %time @ " second Time Travel Bonus!";
}

function TimeTravelItem::onPickup(%this,%obj,%user,%amount)
{
   Parent::onPickup(%this, %obj, %user, %amount);
   if(%obj.timeBonus !$= "")
      %user.client.incBonusTime(%obj.timeBonus);
   else
      %user.client.incBonusTime($Game::TimeTravelBonus);
}


//-----------------------------------------------------------------------------

datablock SFXProfile(PuAntiGravityVoiceSfx)
{
   filename    = "~/data/sound/gravitychange.wav";
   description = Audio2D;
   preload = true;
};

datablock ItemData(AntiGravityItem)
{
   // Mission editor category
   category = "Powerups";
   className = "PowerUp";

   pickupAudio = PuAntiGravityVoiceSfx;
   pickupName = "a Gravity Modifier!";

   // Basic Item properties
   shapeFile = "~/data/shapes/items/antiGravity.dts";
   mass = 1;
   friction = 1;
   elasticity = 0.3;
   emap = false;

   // Dynamic properties defined by the scripts
   maxInventory = 1;
};

function AntiGravityItem::onAdd(%this, %obj)
{
   %obj.playThread(0,"Ambient");
}   

function AntiGravityItem::onPickup(%this,%obj,%user,%amount)
{
   %rotation = getWords(%obj.getTransform(),3);
   %ortho = vectorOrthoBasis(%rotation);
   %up = getWords(%ortho,6);
   if (getGravityDir() !$= %up) {
      Parent::onPickup(%this, %obj, %user, %amount);
      %user.setGravityDir(%ortho);
   }
}

//-----------------------------------------------------------------------------
// Blast marble powerUp
//-----------------------------------------------------------------------------

datablock SFXProfile(doBlastSfx)
{
   filename    = "~/data/sound/use_blast.wav";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(PuBlastVoiceSfx)
{
   filename    = "~/data/sound/ultrablast.wav";
   description = Audio2D;
   preload = true;
};

datablock ShapeBaseImageData(BlastImage)
{
   // Basic Item properties
   shapeFile = "~/data/shapes/images/distort.dts";
   emap = false;
   mountPoint = 0;
   offset = "0 0 0";
   stateName[0]                     = "Grow";
   stateSequence[0]                 = "grow";
//   stateSound[0] = doBlastSfx;
   ignoreMountRotation = true;
};


datablock ItemData(BlastItem)
{
   // Mission editor category
   category = "Powerups";
   className = "PowerUp";
   powerUpId = 6;

   activeAudio = DoBlastSfx;
   pickupAudio = PuBlastVoiceSfx;

   // Basic Item properties
   shapeFile = "~/data/shapes/images/blast.dts";
	emap = false;
   mass = 1;
   friction = 1;
   elasticity = 0.3;
   
   // Dynamic properties defined by the scripts
	pickupName = "a Blast PowerUp!";
};


function BlastItem::onAdd(%this, %obj)
{
   %obj.playThread(0,"Ambient");
   %obj.rotate = 0;
}   

//-----------------------------------------------------------------------------
// Mega marble powerUp
//-----------------------------------------------------------------------------

datablock SFXProfile(DoMegaMarbleSfx)
{
   filename    = "~/data/sound/use_mega.wav";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(PuMegaMarbleVoiceSfx)
{
   filename    = "~/data/sound/mega_marble.wav";
   description = Audio2D;
   preload = true;
};

datablock SFXProfile(ShrinkMegaMarbleSfx)
{
   filename    = "~/data/sound/MegaShrink.wav";
   description = AudioClose3d;
   preload = true;
};

datablock ItemData(MegaMarbleItem)
{
   // Mission editor category
   category = "Powerups";
   className = "PowerUp";
   powerUpId = 7;

   activeAudio = DoMegaMarbleSfx;
   pickupAudio = PuMegaMarbleVoiceSfx;

   // Basic Item properties
   shapeFile = "~/data/shapes/images/grow.dts";
   mass = 1;
   friction = 1;
   elasticity = 0.3;

   // Dynamic properties defined by the scripts
	pickupName = "a Mega Marble PowerUp!";
	useName = "Mega Marble PowerUp";
   maxInventory = 1;
};

function MegaMarbleItem::onAdd(%this, %obj)
{
   %obj.playThread(0,"ambient");
}   

//-----------------------------------------------------------------------------
// power-up parameters
//-----------------------------------------------------------------------------

datablock PowerUpData(PowerUpDefs)
{
   // This datablock holds the properties
   // of all the powerups.
   
   // Possible properties of powerups.
   // Note: leave value alone to accept default behavior.
   //    boostDir -- direction that boost applies
   //    boostAmount -- impulse of boost
   //    boostMassless -- whether boost is massless or not
   //    airAccel -- modify air acceleration by this factor
   //    gravityMod -- modify gravity by this factor
   //    bounce -- change bounce restitution to this value
   //    repulseMax -- apply up to this much force to other marbles
   //    repulseDist -- max distance at which repulse force is applied
   //    massScale -- scale mass by this amount
   //    sizeScale -- scale size by this amount
   //    activateTime -- time, in ms, for powerup to be activated and have an effect

   // Blast Ability -- triggered by energy level not powerup
   image[0] = BlastImage;
   emitter[0] = BlastEmitter;
   boostDir[0] = "0 0 1";
   boostAmount[0] = 8; // small hop to get off surface
   duration[0] = 384;
   repulseMax[0] = 60;
   repulseDist[0] = 10;
   activateTime[0] = 150;

   // Super Jump
   emitter[1] = MarbleSuperJumpEmitter; 		
   duration[1] = 1000;
   boostDir[1] = "0 0 1";
   boostAmount[1] = 20;
   boostMassless[1] = 0.7;
   activateTime[1] = 0;
   
   // Super Speed
   emitter[2] = MarbleSuperSpeedEmitter;
   duration[2] = 1000;
   boostDir[2] = "0 1 0";
   boostAmount[2] = 25;
   boostMassless[2] = 0.7;
   activateTime[2] = 100;

   // Super Bounce
   image[3] = SuperBounceImage;
   duration[3] = 5000;
   bounce[3] = 0.9;
   activateTime[3] = 0;

   // Shock Absorber
   image[4] = ShockAbsorberImage;
   duration[4] = 5000;
   boost[4] = 0.01;
   activateTime[4] = 0;

   // Helicopter
   image[5] = HelicopterImage;
   duration[5] = 5000;
   gravityMod[5] = 0.25;
   airAccel[5] = 2;
   activateTime[5] = 70;

   // Blast
//   image[6] = BlastImage;
   duration[6] = 400;
   blastRecharge[6] = true;
   
   // Mega marble
   image[7] = MegaMarbleImage;
   duration[7] = 10000;
   boostAmount[7] = 5; // small hop to get off surface
   massScale[7] = 5;
   sizeScale[7] = 2.25;
   boostDir[7] = "0 0 1";
   activateTime[7] = 100;
   
   // Time freeze marble
   image[8] = TimeFreezeImage;
   duration[8] = 5000;
   timeFreeze[8] = 5000;
   activateTime[8] = 0;

   // currently unused...
   //emitter[3] = MarbleSuperBounceEmitter;
   //emitter[4] = MarbleShockAbsorberEmitter;
   //emitter[5] = MarbleHelicopterEmitter;
};
