//-----------------------------------------------------------------------------
// Torque Game Engine
// 
// Copyright (c) 2001 GarageGames.Com
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Function to construct and initialize the default canvas window
// used by the games

function initCanvas(%windowName)
{
   videoSetGammaCorrection($pref::OpenGL::gammaCorrection);
   
   if( %effectCanvas )
      %canvasCreate = createEffectCanvas( %windowName );
   else
      %canvasCreate = createCanvas( %windowName );
   
   if( !%canvasCreate ) 
   {
      quitWithErrorMessage("Copy of Torque is already running; exiting.");
      return;
   }

   // Declare default GUI Profiles.
   exec("~/ui/defaultProfiles.cs");

   // Common GUI's
   exec("~/ui/GuiEditorGui.gui");
   exec("~/ui/ConsoleDlg.gui");
   exec("~/ui/InspectDlg.gui");
   exec("~/ui/LoadFileDlg.gui");
   exec("~/ui/SaveFileDlg.gui");
   exec("~/ui/MessageBoxOkDlg.gui");
   exec("~/ui/MessageBoxYesNoDlg.gui");
   exec("~/ui/MessageBoxOKCancelDlg.gui");
   exec("~/ui/MessagePopupDlg.gui");
   exec("~/ui/HelpDlg.gui");
   exec("~/ui/RecordingsDlg.gui");

   // Commonly used helper scripts
   exec("./metrics.cs");
   exec("./messageBox.cs");
   exec("./screenshot.cs");
   exec("./cursor.cs");
   exec("./help.cs");
   //exec("./recordings.cs");
   
   // Misc
   exec( "./shaders.cs" );
   exec("./materials.cs");

   // Init the audio system
   sfxStartup();
}

function resetCanvas()
{
   if (isObject(Canvas))
   {
      Canvas.repaint(); 
   }
}
