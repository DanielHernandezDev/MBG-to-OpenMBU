//-----------------------------------------------------------------------------
// Torque Game Engine
// 
// Copyright (c) 2001 GarageGames.Com
//-----------------------------------------------------------------------------

// The master server is declared with the server defaults, which is
// loaded on both clients & dedicated servers.  If the server mod
// is not loaded on a client, then the master must be defined. 
//$pref::Master[0] = "2:v12master.dyndns.org:28002";

$pref::Player::Name = "Test Guy";
$pref::Player::defaultFov = 90;
$pref::Player::zoomSpeed = 0;

$pref::QualifiedLevel["Beginner"] = 1;
$pref::QualifiedLevel["Intermediate"] = 1;
$pref::QualifiedLevel["Advanced"] = 1;
$pref::QualifiedLevel["Custom"] = 1000;

$pref::checkMOTDAndVersion = "1"; // check the version by default

$pref::Net::LagThreshold = 400;

$pref::shadows = "2";
$pref::HudMessageLogSize = 40;
$pref::ChatHudLength = 1;
$pref::useStencilShadows = false;

$pref::Input::LinkMouseSensitivity = 1;
// DInput keyboard, mouse, and joystick prefs
$pref::Input::KeyboardEnabled = 1;
$pref::Input::MouseEnabled = 1;
$pref::Input::JoystickEnabled = 0;
$pref::Input::KeyboardTurnSpeed = 0.025;

$pref::Input::MouseSensitivity = 0.75;
$pref::Input::InvertYAxis = false;
$pref::Input::AlwaysFreeLook = true;

$pref::sceneLighting::cacheSize = 20000;
$pref::sceneLighting::purgeMethod = "lastCreated";
$pref::sceneLighting::cacheLighting = 1;
$pref::sceneLighting::terrainGenerateLevel = 1;

$pref::Terrain::DynamicLights = 1;
$pref::Interior::TexturedFog = 0;
$pref::Video::displayDevice = "D3D";
$pref::Video::fullScreen = 0;
$pref::Video::allowOpenGL = 1;
$pref::Video::allowD3D = 1;
$pref::Video::preferOpenGL = 1;
$pref::Video::appliedPref = 0;
$pref::Video::disableVerticalSync = 1;
$pref::Video::monitorNum = 0;
$pref::Video::resolution = "1280 720 32";
$pref::Video::windowedRes = "1280 720";

$pref::OpenGL::force16BitTexture = "0";
$pref::OpenGL::forcePalettedTexture = "0";
$pref::OpenGL::maxHardwareLights = 3;
$pref::VisibleDistanceMod = 1.0;

/// The sound provider to select at startup.  Typically
/// this is DirectSound, OpenAL, or XACT.  There is also 
/// a special Null provider which acts normally, but 
/// plays no sound.
$pref::SFX::provider = "";

/// The sound device to select from the provider.  Each
/// provider may have several different devices.
$pref::SFX::device = "";

/// If true the device will try to use hardware buffers
/// and sound mixing.  If not it will use software.
$pref::SFX::useHardware = false;

/// If you have a software device you have a 
/// choice of how many software buffers to
/// allow at any one time.  More buffers cost
/// more CPU time to process and mix.
$pref::SFX::maxSoftwareBuffers = 16;

/// This is the playback frequency for the primary 
/// sound buffer used for mixing.  Although most
/// providers will reformat on the fly, for best 
/// quality and performance match your sound files
/// to this setting.
$pref::SFX::frequency = 44100;

/// This is the playback bitrate for the primary 
/// sound buffer used for mixing.  Although most
/// providers will reformat on the fly, for best 
/// quality and performance match your sound files
/// to this setting.
$pref::SFX::bitrate = 32;

/// The overall system volume at startup.  Note that 
/// you can only scale volume down, volume does not
/// get louder than 1.
$pref::SFX::masterVolume   = 1.0;

/// The startup sound channel volumes.  These are 
/// used to control the overall volume of different 
/// classes of sounds.
$pref::SFX::channelVolume1 = 1.0;
$pref::SFX::channelVolume2 = 0.7;
$pref::SFX::channelVolume3 = 0.8;
$pref::SFX::channelVolume4 = 0.8;
$pref::SFX::channelVolume5 = 0.8;
$pref::SFX::channelVolume6 = 0.8;
$pref::SFX::channelVolume7 = 0.8;
$pref::SFX::channelVolume8 = 0.8;

$Option::DefaultMusicVolume = 35;
$Option::DefaultFXVolume = 100;
$pref::Option::MusicVolume = $Option::DefaultMusicVolume;
$pref::Option::FXVolume = $Option::DefaultFXVolume;

$Option::DefaultMusicVolume = 35;
$Option::DefaultFXVolume = 100;

$pref::LastReadMOTD = "Welcome to MarbleBlast!";
$pref::CurrentMOTD = "Welcome to MarbleBlast!";

$Pref::Unix::OpenALFrequency = 44100;
