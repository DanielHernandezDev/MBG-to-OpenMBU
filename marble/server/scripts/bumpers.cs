//-----------------------------------------------------------------------------
// Torque Game Engine
//
// Copyright (c) 2001 GarageGames.Com
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------

datablock SFXProfile(BumperDing)
{
   filename    = "~/data/sound/bumperDing1.wav";
   description = AudioDefault3d;
   preload = true;
};

datablock SFXProfile(BumperFlat)
{
   filename    = "~/data/sound/bumper1.wav";
   description = AudioDefault3d;
   preload = true;
};

function Bumper::onAdd( %this, %obj )
{
   %obj.playThread( 0, "idle" );
}

function Bumper::onEndSequence( %this, %obj, %slot )
{
   // This means the activate sequence is done, so put back to idle
   %obj.stopThread( 0 );
   %obj.playThread( 0, "idle" );
}

function Bumper::onCollision(%this,%obj,%col,%vec, %vecLen, %material)
{
      %obj.stopThread( 0 );
      %obj.playThread( 0, "push" );
      %obj.playAudio( 0, %this.sound );
}

//-----------------------------------------------------------------------------

datablock StaticShapeData(AngleBumper)
{
   category = "Bumpers";
   className = "Bumper";
   shapeFile = "~/data/shapes/bumpers/angleBumper.dts";
   scopeAlways = true;
   sound = BumperFlat;
};

datablock StaticShapeData(TriangleBumper)
{
   category = "Bumpers";
   className = "Bumper";
   shapeFile = "~/data/shapes/bumpers/pball_tri.dts";
   scopeAlways = true;
   sound = BumperFlat;
};

datablock StaticShapeData(RoundBumper)
{
   category = "Bumpers";
   className = "Bumper";
   shapeFile = "~/data/shapes/bumpers/pball_round.dts";
   scopeAlways = true;
   sound = BumperDing;
};


