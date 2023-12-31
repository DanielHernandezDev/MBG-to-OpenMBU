//-----------------------------------------------------------------------------
// Torque Game Engine
// 
// Copyright (c) 2001 GarageGames.Com
// Portions Copyright (c) 2001 by Sierra Online, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Message Hud
//-----------------------------------------------------------------------------

// chat hud sizes
$outerChatLenY[1] = 72;
$outerChatLenY[2] = 140;
$outerChatLenY[3] = 200;

// Only play sound files that are <= 5000ms in length.
$MaxMessageWavLength = 5000;

// Helper function to play a sound file if the message indicates.
// Returns starting position of wave file indicator.
function playMessageSound(%message, %voice, %pitch)
{
   // Search for wav tag marker.
   %wavStart = strstr(%message, "~w");
   if (%wavStart == -1) {
      return -1;
   }

   %wav = getSubStr(%message, %wavStart + 2, 1000);
   if (%voice !$= "") {
      %wavFile = "~/data/sound/voice/" @ %voice @ "/" @ %wav;
   }
   else {
      %wavFile = "~/data/sound/" @ %wav;
   }
   if (strstr(%wavFile, ".wav") != (strlen(%wavFile) - 4)) {
      %wavFile = %wavFile @ ".wav";
   }
   // XXX This only expands to a single filepath, of course; it
   // would be nice to support checking in each mod path if we
   // have multiple mods active.
   %wavFile = ExpandFilename(%wavFile);

   if ((%pitch < 0.5) || (%pitch > 2.0)) {
      %pitch = 1.0;
   }

   %wavLengthMS = alxGetWaveLen(%wavFile) * %pitch;
   if (%wavLengthMS == 0) {
      error("** WAV file \"" @ %wavFile @ "\" is nonexistent or sound is zero-length **");
   }
   else if (%wavLengthMS <= $MaxMessageWavLength) {
      if ($ClientChatHandle[%sender] != 0) {
         sfxStop($ClientChatHandle[%sender]);
      }
      $ClientChatHandle[%sender] = sfxCreateSource(AudioMessage, %wavFile);
      if (%pitch != 1.0) {
         alxSourcef($ClientChatHandle[%sender], "AL_PITCH", %pitch);
      }
      sfxPlay($ClientChatHandle[%sender]);
   }
   else {
      error("** WAV file \"" @ %wavFile @ "\" is too long **");
   }

   return %wavStart;
}


// All messages are stored in this HudMessageVector, the actual
// MainChatHud only displays the contents of this vector.

new MessageVector(HudMessageVector);
$LastHudTarget = 0;


//-----------------------------------------------------------------------------
function onChatMessage(%message, %voice, %pitch)
{
   // XXX Client objects on the server must have voiceTag and voicePitch
   // fields for values to be passed in for %voice and %pitch... in
   // this example mod, they don't have those fields.

   // Clients are not allowed to trigger general game sounds with their
   // chat messages... a voice directory MUST be specified.
   if (%voice $= "") {
      %voice = "default";
   }

   // See if there's a sound at the end of the message, and play it.
   if ((%wavStart = playMessageSound(%message, %voice, %pitch)) != -1) {
      // Remove the sound marker from the end of the message.
      %message = getSubStr(%message, 0, %wavStart);
   }

   // Chat goes to the chat HUD.
   addChatLine(%message);
}

function chatFade(%fade)
{
   ChatTextForeground.setAlpha(0.8 * %fade);
   ChatTextBackground.setAlpha(%fade);
   if(%fade > 0)
   {
      %nextFade = %fade - 0.03;
      if(%nextFade < 0)
         %nextFade = 0;
      $ChatFadeTimer = schedule(32, 0, chatFade, %nextFade);
   }
}

function addChatLine(%message)
{
   if (getWordCount(%message)) {
      %text = "<just:center><font:DomCasualD:32>" @ %message;
      ChatTextBackground.setText("<color:000000>" @ %text);
      ChatTextForeground.setText(%text);

      cancel($ChatFadeTimer);
      ChatTextForeground.setAlpha(0.8);
      ChatTextBackground.setAlpha(1.0);
      $ChatFadeTimer = schedule(3000, 0, chatFade, 1.0);
   }
}

package GuiMLTextHelper
{

// strip out any <func:> tags and call the display func on them
function GuiMLTextCtrl::setText(%this, %text)
{
   %start = 0;
   while((%pos = strpos(%text, "<func:", %start)) != -1)
   {
      %end = strpos(%text, ">", %pos + 5);
      if(%end == -1)
         break;

      %pre = getSubStr(%text, 0, %pos);
      %post = getSubStr(%text, %end+1, 100000);
      %func = getSubStr(%text, %pos + 6, %end - (%pos + 6));
      %val = %this.evalTextFunc(%func);
      %start = strlen(%val) + %pos;
      %text = %pre @ %val @ %post;
   }
   Parent::setText(%this, %text);
}

};

activatePackage(GuiMLTextHelper);

function GuiMLTextCtrl::evalTextFunc(%this, %text)
{
   %func = getWord(%text, 0);
   switch$(%func)
   {
      case "bind":
         %binding = moveMap.getBinding(getWord(%text, 1));
         return getMapDisplayName(getField(%binding, 0), getField(%binding, 1), true);
   }
}

function helpFade(%fade)
{
   HelpTextForeground.setAlpha(1.0 * %fade);
   HelpTextBackground.setAlpha(%fade);
   if(%fade > 0)
   {
      %nextFade = %fade - 0.03;
      if(%nextFade < 0)
         %nextFade = 0;
      $HelpFadeTimer = schedule(32, 0, helpFade, %nextFade);
   }
}

function addHelpLine(%message, %playBeep)
{
   if (getWordCount(%message)) {
      %text = "<just:center><font:DomCasualD:32>" @ %message;
      HelpTextBackground.setText("<color:000000>" @ %text);
      HelpTextForeground.setText("<color:FFFFFF>" @ %text);

      cancel($HelpFadeTimer);
      HelpTextForeground.setAlpha(1.0);
      HelpTextBackground.setAlpha(1.0);
      $HelpFadeTimer = schedule(3000, 0, helpFade, 1.0);
   }
   if(%playBeep)
   {
      serverplay2d(HelpDingSfx);
   }
}

function onServerMessage(%message)
{
   // See if there's a sound at the end of the message, and play it.
   if ((%wavStart = playMessageSound(%message)) != -1) {
      // Remove the sound marker from the end of the message.
      %message = getSubStr(%message, 0, %wavStart);
   }

   addChatLine(%message);
}


//-----------------------------------------------------------------------------
// MainChatHud methods
//-----------------------------------------------------------------------------

function MainChatHud::onWake( %this )
{
   // set the chat hud to the users pref
   %this.setChatHudLength( $Pref::ChatHudLength );
}


//------------------------------------------------------------------------------

function MainChatHud::setChatHudLength( %this, %length )
{
   %outerChatLenX = firstWord(outerChatHud.extent);
   %chatScrollLenX = firstWord(chatScrollHud.extent);

   outerChatHud.extent = %outerChatLenX SPC $outerChatLenY[%length];
   chatScrollHud.extent = %chatScrollLenX SPC $outerChatLenY[%length];

   //find out how many lines per page are visible
   %chatScrollHeight = getWord(chatHud.getGroup().getGroup().extent, 1);
   if (%chatScrollHeight <= 0)
      return;

   %textHeight = chatHud.profile.fontSize;
   if (%textHeight <= 0)
      %textHeight = 12;

   %pageLines = mFloor(%chatScrollHeight / %textHeight);
   if (%pageLines <= 0)
      %pageLines = 1;

   // Put the last line at the bottom.
   %pos = HudMessageVector.getNumLines() - %pageLines;
   if (%pos < 0)
      %pos = 0;
   ChatHud.position = "0" SPC (-1 * %pos * %textHeight);

   ChatHud.resize(firstWord(ChatHud.position), getWord(ChatHud.position, 1), firstWord(ChatHud.extent), getWord(ChatHud.extent, 1));
   ChatPageDown.position = (firstWord(outerChatHud.extent) - firstWord(ChatPageDown.extent))
       SPC ($outerChatLenY[%length] - getWord(ChatPageDown.extent, 1));
   ChatPageDown.setVisible(false);
}


//------------------------------------------------------------------------------

function MainChatHud::nextChatHudLen( %this )
{
   %len = $pref::ChatHudLength++;
   if ($pref::ChatHudLength == 4)
      $pref::ChatHudLength = 1;
   %this.setChatHudLength($pref::ChatHudLength);
}


//-----------------------------------------------------------------------------
// ChatHud methods
// This is the actual message vector/text control which is part of
// the MainChatHud dialog
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------

function ChatHud::addLine(%this,%text)
{
   //first, see if we're "scrolled up"...
   %textHeight = %this.profile.fontSize;
   if (%textHeight <= 0)
      %textHeight = 12;
   %chatScrollHeight = getWord(%this.getGroup().getGroup().extent, 1);
   %chatPosition = getWord(%this.extent, 1) - %chatScrollHeight + getWord(%this.position, 1);
   %linesToScroll = mFloor((%chatPosition / %textHeight) + 0.5);
   if (%linesToScroll > 0)
      %origPosition = %this.position;
      
   //add the message...
   while( !chatPageDown.isVisible() && HudMessageVector.getNumLines() && (HudMessageVector.getNumLines() >= $pref::HudMessageLogSize))
   {
      %tag = HudMessageVector.getLineTag(0);
      if(%tag != 0)
         %tag.delete();
      HudMessageVector.popFrontLine();
   }
   HudMessageVector.pushBackLine(%text, $LastHudTarget);
   $LastHudTarget = 0;

   //now that we've added the message, see if we need to reset the position
   if (%linesToScroll > 0)
   {
      chatPageDown.setVisible(true);
      %this.position = %origPosition;
   }
   else
      chatPageDown.setVisible(false);
}


//-----------------------------------------------------------------------------

function ChatHud::pageUp(%this)
{
   // Find out the text line height
   %textHeight = %this.profile.fontSize;
   if (%textHeight <= 0)
      %textHeight = 12;

   // Find out how many lines per page are visible
   %chatScrollHeight = getWord(%this.getGroup().getGroup().extent, 1);
   if (%chatScrollHeight <= 0)
      return;

   %pageLines = mFloor(%chatScrollHeight / %textHeight) - 1;
   if (%pageLines <= 0)
      %pageLines = 1;

   // See how many lines we actually can scroll up:
   %chatPosition = -1 * getWord(%this.position, 1);
   %linesToScroll = mFloor((%chatPosition / %textHeight) + 0.5);
   if (%linesToScroll <= 0)
      return;

   if (%linesToScroll > %pageLines)
      %scrollLines = %pageLines;
   else
      %scrollLines = %linesToScroll;

   // Now set the position
   %this.position = firstWord(%this.position) SPC (getWord(%this.position, 1) + (%scrollLines * %textHeight));

   // Display the pageup icon
   chatPageDown.setVisible(true);
}


//-----------------------------------------------------------------------------

function ChatHud::pageDown(%this)
{
   // Find out the text line height
   %textHeight = %this.profile.fontSize;
   if (%textHeight <= 0)
      %textHeight = 12;

   // Find out how many lines per page are visible
   %chatScrollHeight = getWord(%this.getGroup().getGroup().extent, 1);
   if (%chatScrollHeight <= 0)
      return;

   %pageLines = mFloor(%chatScrollHeight / %textHeight) - 1;
   if (%pageLines <= 0)
      %pageLines = 1;

   // See how many lines we actually can scroll down:
   %chatPosition = getWord(%this.extent, 1) - %chatScrollHeight + getWord(%this.position, 1);
   %linesToScroll = mFloor((%chatPosition / %textHeight) + 0.5);
   if (%linesToScroll <= 0)
      return;

   if (%linesToScroll > %pageLines)
      %scrollLines = %pageLines;
   else
      %scrollLines = %linesToScroll;

   // Now set the position
   %this.position = firstWord(%this.position) SPC (getWord(%this.position, 1) - (%scrollLines * %textHeight));

   // See if we have should (still) display the pagedown icon
   if (%scrollLines < %linesToScroll)
      chatPageDown.setVisible(true);
   else
      chatPageDown.setVisible(false);
}


//-----------------------------------------------------------------------------
// Support functions
//-----------------------------------------------------------------------------

function pageUpMessageHud()
{
   ChatHud.pageUp();
}

function pageDownMessageHud()
{
   ChatHud.pageDown();
}

function cycleMessageHudSize()
{
   MainChatHud.nextChatHudLen();
}
