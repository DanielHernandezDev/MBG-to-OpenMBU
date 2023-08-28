//-----------------------------------------------------------------------------
// Torque Game Engine
//
// Copyright (c) 2001 GarageGames.Com
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
//Pads & Stuff
//-----------------------------------------------------------------------------
new Material(MBGStartPadMaterial) {
   
   baseTex[0] = "./shapes/pads/spawn";   
};

new Material(MBGEndPadMaterial) {
   
   baseTex[0] = "./shapes/pads/exit";   
};

new Material(MBGMarble)
{
   baseTex[0] = "./shapes/balls/base.marble";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
};

new Material(FinishSignMetal)
{
   baseTex[0] = "./shapes/signs/finishsign_metal";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
};

new Material(FinishSignPurple)
{
   baseTex[0] = "./shapes/signs/finishsign_purple";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
};

//-----------------------------------------------------------------------------
// Powerups & Items
//-----------------------------------------------------------------------------

new Material(BaseGem)
{
   baseTex[0] = "./shapes/items/base.gem";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
   emissive[0] = true;
};

new Material(Gem)
{
   baseTex[0] = "./shapes/items/gem";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
   emissive[0] = true;
};

new Material(GemShine)
{
   baseTex[0] = "./shapes/items/gemshine";
   translucent = true;
   emissive[0] = true;
};

new Material(BlackGem)
{
   baseTex[0] = "./shapes/items/black.gem";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
   emissive[0] = true;
};

new Material(BlueGem)
{
   baseTex[0] = "./shapes/items/blue.gem";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
   emissive[0] = true;
};

new Material(GreenGem)
{
   baseTex[0] = "./shapes/items/green.gem";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
   emissive[0] = true;
};

new Material(OrangeGem)
{
   baseTex[0] = "./shapes/items/orange.gem";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
   emissive[0] = true;
};

new Material(PurpleGem)
{
   baseTex[0] = "./shapes/items/purple.gem";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
   emissive[0] = true;
};

new Material(RedGem)
{
   baseTex[0] = "./shapes/items/red.gem";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
   emissive[0] = true;
};

new Material(TurqGem)
{
   baseTex[0] = "./shapes/items/turquoise.gem";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
   emissive[0] = true;
};

new Material(YellowGem)
{
   baseTex[0] = "./shapes/items/yellow.gem";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
   emissive[0] = true;
};

new Material(PowerupAntigravity)
{
   baseTex[0] = "~/data/shapes/items/antigravity";
};

new Material(Material_ItemArrow)
{
   baseTex[0] = "~/data/shapes/items/itemArrow";
};

new Material(PowerupShockAbsorber)
{
   baseTex[0] = "~/data/shapes/items/shockabsorber";
};

new Material(PowerupSupterJump)
{
   baseTex[0] = "~/data/shapes/items/sji_shinysteel";
};

new Material(PowerupBounce)
{
   baseTex[0] = "~/data/shapes/items/powerup-bounce";
};

new Material(PowerupHelicopter)
{
   baseTex[0] = "~/data/shapes/images/helicopter";
};

new Material(ForcefieldImage)
{
   baseTex[0] = "~/data/shapes/images/glow_bounce";
};

new Material(TimeTravelWood)
{
   baseTex[0] = "~/data/shapes/items/hourglasswood";
};

new Material(TimeTravelGlass)
{
   baseTex[0] = "~/data/shapes/items/timetravelitem_glass";
   translucent = true;
   emissive[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;  
};

new Material(TimeTravelSand)
{
   baseTex[0] = "~/data/shapes/items/timetravelitem_sand";
};

//-----------------------------------------------------------------------------
// some part textures
//-----------------------------------------------------------------------------
new Material(OilSlickMaterial) {
   baseTex[0] = "./shapes/hazards/base.slick";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;  
   friction = 0.05;
   restitution = 0.5;
};

new Material(BaseSlickMaterial) {
   
   mapTo = "base.slick";   
   
   translucent[0] = false; 

   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;  
   
   friction = 0.05;
   restitution = 0.5;
};

new Material(IceSlickMaterial) {
   
   mapTo = "ice.slick";   
   
   translucent[0] = false; 

   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;  
   
   friction = 0.05;
   restitution = 0.5;
};

new Material(BumperRubberMaterial) {
   mapTo = "bumper-rubber";   
   
   translucent[0] = false; 

   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;  
   
   friction = 0.5;
   restitution = 0;
   force = 15;
};

new Material(BumperTriangSideMaterial) {
   baseTex[0] = "./shapes/bumpers/triang-side";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;  
   
   friction = 0.5;
   restitution = 0;
   force = 15;
};

new Material(BumperTriangTopMaterial) {
   baseTex[0] = "./shapes/bumpers/triang-top";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;  
   
   friction = 0.5;
   restitution = 0;
   force = 15;
};

new Material(PBallRoundSideMaterial) {
   baseTex[0] = "./shapes/bumpers/pball-round-side";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;  
   
   friction = 0.5;
   restitution = 0;
   force = 15;
};

new Material(PBallRoundTopMaterial) {
   baseTex[0] = "./shapes/bumpers/pball-round-top";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;  
   
   friction = 0.5;
   restitution = 0;
   force = 15;
};

new Material(PBallRoundBottomMaterial) {
   baseTex[0] = "./shapes/bumpers/pball-round-bottom";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;  
   
   friction = 0.5;
   restitution = 0;
   force = 15;
};

new Material(ButtonMaterial) {
   mapTo = "button";
   
   translucent[0] = false; 

   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;  
   
   friction = 1;
   restitution = 1;
};
//-----------------------------------------------------------------------------


//cautionsign.dts
new Material(Material_BaseCautionSign)
{
   baseTex[0] = "~/data/shapes/signs/base.cautionsign";
};

new Material(Material_CautionCautionSign)
{
   baseTex[0] = "~/data/shapes/signs/caution.cautionsign";
};

new Material(Material_DangerCautionSign)
{
   baseTex[0] = "~/data/shapes/signs/danger.cautionsign";
};

new Material(Material_CautionSignWood)
{
   baseTex[0] = "~/data/shapes/signs/cautionsignwood";
};

new Material(Material_CautionSignPole)
{
   baseTex[0] = "~/data/shapes/signs/cautionsign_pole";
};

//plainsign.dts
new Material(Material_PlainSignWood)
{
   baseTex[0] = "~/data/shapes/signs/plainsignwood";
};

new Material(Material_BasePlainSign)
{
   baseTex[0] = "~/data/shapes/signs/base.plainSign";
};

new Material(Material_DownPlainSign)
{
   baseTex[0] = "~/data/shapes/signs/down.plainSign";
};

new Material(Material_LeftPlainSign)
{
   baseTex[0] = "~/data/shapes/signs/left.plainSign";
};

new Material(Material_RightPlainSign)
{
   baseTex[0] = "~/data/shapes/signs/right.plainSign";
};

new Material(Material_UpPlainSign)
{
   baseTex[0] = "~/data/shapes/signs/up.plainSign";
};

new Material(Material_PlainSignWood2)
{
   baseTex[0] = "~/data/shapes/signs/signwood2";
};

new Material(Material_SignWood)
{
   baseTex[0] = "~/data/shapes/signs/signwood";
};