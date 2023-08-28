//-----------------------------------------------------------------------------
// Torque Game Engine
//
// Copyright (c) 2001 GarageGames.Com
//-----------------------------------------------------------------------------

if (!$AudioChannelTypesDefined)
{
    error("Audio channel types are not defined, all sounds will use same channel");
}

new SFXDescription(AudioGui)
{
   volume   = 1.0;
   isLooping= false;
   is3D     = false;
   channel     = $GuiAudioType;
};
new SFXDescription(AudioMessage)
{
   volume   = 1.0;
   isLooping= false;
   is3D     = false;
   channel     = $MessageAudioType;
};
new SFXDescription(ClientAudioLooping2D)
{
   volume = 1.0;
   isLooping = true;
   is3D = false;
   channel = $EffectAudioType;
};

new SFXProfile(TimeTravelLoopSfx)
{
   filename    = "~/data/sound/TimeTravelActive.wav";
   description = ClientAudioLooping2d;
   preload = true;
};

new SFXProfile(AudioButtonOver)
{
   filename = "~/data/sound/buttonOver.wav";
   description = "AudioGui";
	preload = true;
};

new SFXProfile(AudioButtonDown)
{
   filename = "~/data/sound/ButtonPress.wav";
   description = "AudioGui";
	preload = true;
};

new SFXDescription(AudioMusic)
{
   volume   = 1.0;
   isLooping = true;
   isStreaming = true;
   is3D     = false;
   channel     = $MusicAudioType;
};

function playMusic(%musicFileBase)
{
   sfxStop($currentMusicHandle);
   if(isObject(MusicProfile))
      MusicProfile.delete();

   %file = "~/data/sound/" @ %musicFileBase;
   new SFXProfile(MusicProfile) {
      fileName = %file;
      description = "AudioMusic";
      preload = false;
   };
   $currentMusicBase = %musicFileBase;
   $currentMusicHandle = sfxPlay(MusicProfile);  //add this line
}

function playShellMusic()
{
   playMusic("Shell.ogg");
}

function playGameMusic()
{
   if(!$musicFound)
   {
      $NumMusicFiles = 0;
      for(%file = findFirstFile("*.ogg"); %file !$= ""; %file = findNextFile("*.ogg"))
      {
         if(fileBase(%file) !$= "Shell")
         {
            $Music[$NumMusicFiles] = fileBase(%file) @ ".ogg";
            $NumMusicFiles++;
         }
      }
      $musicFound = true;
   }   
   if($NumMusicFiles)
      playMusic($Music[MissionInfo.level % $NumMusicFiles]);
   else
      playMusic("Shell.ogg");
}

function pauseMusic()
{
   sfxStop($currentMusicHandle);
}

function resumeMusic()
{
   playMusic($currentMusicBase);
}

