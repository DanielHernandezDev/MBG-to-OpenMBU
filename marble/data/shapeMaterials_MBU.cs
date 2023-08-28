new CubemapData( sky_environment )
{
   cubeFace[0] = "marble/data/skies_mbu/env_SO";
   cubeFace[1] = "marble/data/skies_mbu/env_NO";
   cubeFace[2] = "marble/data/skies_mbu/env_EA";
   cubeFace[3] = "marble/data/skies_mbu/env_WE";
   cubeFace[4] = "marble/data/skies_mbu/env_UP";
   cubeFace[5] = "marble/data/skies_mbu/env_DN";
};

new CubemapData( marbleCubemap3 )
{
   cubeFace[0] = "marble/data/skies_mbu/marbleCubemap3_SO";
   cubeFace[1] = "marble/data/skies_mbu/marbleCubemap3_NO";
   cubeFace[2] = "marble/data/skies_mbu/marbleCubemap3_EA";
   cubeFace[3] = "marble/data/skies_mbu/marbleCubemap3_WE";
   cubeFace[4] = "marble/data/skies_mbu/marbleCubemap3_UP";
   cubeFace[5] = "marble/data/skies_mbu/marbleCubemap3_DN";
};

new CubemapData( gemCubemap )
{
   cubeFace[0] = "marble/data/skies_mbu/gemCubemapUp";
   cubeFace[1] = "marble/data/skies_mbu/gemCubemapUp";
   cubeFace[2] = "marble/data/skies_mbu/gemCubemapUp";
   cubeFace[3] = "marble/data/skies_mbu/gemCubemapUp";
   cubeFace[4] = "marble/data/skies_mbu/gemCubemapUp";
   cubeFace[5] = "marble/data/skies_mbu/gemCubemapUp";
};

new CubemapData( gemCubemap2 )
{
   cubeFace[0] = "marble/data/skies_mbu/gemCubemapUp2";
   cubeFace[1] = "marble/data/skies_mbu/gemCubemapUp2";
   cubeFace[2] = "marble/data/skies_mbu/gemCubemapUp2";
   cubeFace[3] = "marble/data/skies_mbu/gemCubemapUp2";
   cubeFace[4] = "marble/data/skies_mbu/gemCubemapUp2";
   cubeFace[5] = "marble/data/skies_mbu/gemCubemapUp2";
};

new CubemapData( gemCubemap3 )
{
   cubeFace[0] = "marble/data/skies_mbu/gemCubemapUp3";
   cubeFace[1] = "marble/data/skies_mbu/gemCubemapUp3";
   cubeFace[2] = "marble/data/skies_mbu/gemCubemapUp3";
   cubeFace[3] = "marble/data/skies_mbu/gemCubemapUp3";
   cubeFace[4] = "marble/data/skies_mbu/gemCubemapUp3";
   cubeFace[5] = "marble/data/skies_mbu/gemCubemapUp3";
};


//-----------------------------------------------------------------------------
// ShaderData
//-----------------------------------------------------------------------------
new ShaderData( RefractPix )
{
   DXVertexShaderFile 	= "shaders/refractV.hlsl";
   DXPixelShaderFile 	= "shaders/refractP.hlsl";
   pixVersion = 2.0;
};

new ShaderData( StdTex )
{
   DXVertexShaderFile 	= "shaders/standardTexV.hlsl";
   DXPixelShaderFile 	= "shaders/standardTexP.hlsl";
   pixVersion = 2.0;
};

new CustomMaterial(Material_Marble_BB)
{
   mapTo = "marble.BB.skin";

   texture[0] = "~/data/shapes_mbu/balls/marble.BB.bump";
   texture[1] = "$backbuff";
   texture[2] = "~/data/shapes_mbu/balls/marble.BB.skin";

   specular[0] = "1 1 1 1.0";
   specularPower[0] = 12.0;

   version = 2.0;
   refract = true;
   shader = RefractPix;

   pass[0] = Mat_Glass_NoRefract;
   
};


%mat = new Material(Material_cap)
{
   baseTex[0] = "marble/data/shapes/balls/cap";
   bumpTex[0] = "marble/data/shapes/balls/cap_normal";
   cubemap = Lobby;
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
};

//pball_round.dts
%mat = new Material(Material_Bumper)
{
   mapTo = bumper;
   
   friction = 0.5;
   restitution = 0;
   force = 15;

   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
   
   baseTex[0] = "~/data/shapes_mbu/bumpers/bumper";
};

//ductfan.dts
%mat = new Material(Material_HazardFan)
{
   mapTo = fan;
   
   baseTex[0] = "~/data/shapes_mbu/hazards/fan";
   //bumpTex[0] = "~/data/shapes_mbu/signs/arrowsign_post_bump";

   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;
};

//trapdoor.dts
%mat = new Material(Material_Trapdoor)
{
   mapTo = "trapdoor";

   baseTex[0] = "~/data/shapes_mbu/hazards/trapdoor";
};



//copter

%mat = new Material(Material_Helicopter)
{
   mapTo = copter_skin;

   // stage 0
   baseTex[0] = "~/data/shapes_mbu/images/copter_skin";
   //bumpTex[0] = "~/data/shapes_mbu/images/copter_bump";
   pixelSpecular[0] = true;
   specular[0] = "1.0 1.0 1.0 1.0";
   specularPower[0] = 32.0;
};



//blast.dts

%mat = new Material(Material_blastOrbit)
{
   mapTo = blast_orbit_skin;
   
   baseTex[0] = "~/data/shapes_mbu/images/blast_orbit_skin";
   bumpTex[0] = "~/data/shapes_mbu/images/blast_orbit_bump";

   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 32.0;
};


%mat = new Material(Material_item_glow)
{
   mapTo = item_glow;

   // stage 0
   baseTex[0] = "~/data/shapes_mbu/items/item_glow";
   
   glow[0] = true;
   emissive[0] = true;
};


%mat = new Material(Material_blast_glow)
{
   mapTo = blast_glow;

   // stage 0
   baseTex[0] = "~/data/shapes_mbu/images/blast_glow";
   

   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 32.0;
   glow[0]=true;
   
};


//grow.dts
%mat = new Material(Material_grow)
{
   mapTo = grow;
   
   baseTex[0] = "~/data/shapes_mbu/images/grow";
   bumpTex[0] = "~/data/shapes_mbu/images/grow_bump";

   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 32.0;
};

%mat = new Material(Material_Grow_Glow)
{
   mapTo = grow_glow;

   // stage 0
   baseTex[0] = "~/data/shapes_mbu/images/grow_glow";
   emissive[0] = true;
   glow[0]=true;
   
   pixelSpecular[0] = true;
   specular[0] = "1.0 1.0 1.0 1.0";
   specularPower[0] = 32.0;
};


//antiGravity.dts

%mat = new Material(Material_AntiGravSkin)
{
   mapTo = antigrav_skin;
   
   baseTex[0] = "~/data/shapes_mbu/items/antigrav_skin";
   bumpTex[0] = "~/data/shapes_mbu/items/antigrav_bump";

   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 32.0;
};

%mat = new Material(Material_AntiGravGlow)
{
   mapTo = antigrav_glow;

   // stage 0
   baseTex[0] = "~/data/shapes_mbu/items/antigrav_glow";
   glow[0]=true;
   emissive[0] = true;
};


//egg.dts
%mat = new Material(Material_EasterEgg)
{
   mapTo = "egg_skin";

   baseTex[0] = "~/data/shapes_mbu/items/egg_skin";
   pixelSpecular[0] = true;
   specular[0] = "1.0 1.0 1.0 1.0";
   specularPower[0] = 32.0;

   cubemap = gemCubemap;
};

//gem.dts
%mat = new Material(Material_BaseGem)
{
   mapTo = "mbu_base.gem";
   baseTex[0] = "~/data/shapes_mbu/items/red.gem";
   cubemap = gemCubemap;
};

%mat = new Material(Material_RedGem)
{
   baseTex[0] = "~/data/shapes_mbu/items/red.gem";
   cubemap = gemCubemap;
};

%mat = new Material(Material_BlueGem)
{
   baseTex[0] = "~/data/shapes_mbu/items/blue.gem";
   cubemap = gemCubemap3;
};

%mat = new Material(Material_YellowGem)
{
   baseTex[0] = "~/data/shapes_mbu/items/yellow.gem";
   cubemap = gemCubemap2;
};


%mat = new Material(Material_GemShine)
{
   baseTex[0] = "~/data/shapes_mbu/items/gemshine";
   translucentBlendOp = add;
   translucent = true;
};

//superJump.dts

%mat = new Material(Material_SuperJump)
{
   mapTo = superJump_skin;

   // stage 0
   baseTex[0] = "~/data/shapes_mbu/items/superJump_skin";
   bumpTex[0] = "~/data/shapes_mbu/items/superJump_bump";
   
   pixelSpecular[0] = true;
   specular[0] = "1.0 1.0 1.0 1.0";
   specularPower[0] = 32.0;
};


//itemArrow used in several powerups
%mat = new Material(Material_ItemArrow)
{
   baseTex[0] = "~/data/shapes_mbu/items/itemArrow";
};

//superSpeed.dts

%mat = new Material(Material_SuperSpeed)
{
   mapTo = superSpeed_skin;

   // stage 0
   baseTex[0] = "~/data/shapes_mbu/items/superSpeed_skin";
   //bumpTex[0] = "~/data/shapes_mbu/items/superSpeed_bump";
   pixelSpecular[0] = true;
   specular[0] = "1.0 1.0 1.0 1.0";
   specularPower[0] = 32.0;
};


%mat = new Material(Material_SuperSpeedStar)
{
   mapTo = superSpeed_star;

   baseTex[0] = "~/data/shapes_mbu/items/superSpeed_star";
   emissive[0] = true;
   glow[0] = true;
   

};


//timetravel.dts
%mat = new Material(Material_TimeTravelSkin)
{
   mapto = timeTravel_skin;	
   
   baseTex[0] = "~/data/shapes_mbu/items/timeTravel_skin";
   pixelSpecular[0] = true;
   specular[0] = "1.0 1.0 1.0 1.0";
   specularPower[0] = 32.0;
};


//endarea.dts

%mat = new Material(Material_endpad_glow)
{
   mapTo = endpad_glow;
   
   baseTex[0] = "~/data/shapes_mbu/pads/endpad_glow";
   glow[0] = true;
   emissive[0] = true;
   translucent[0] = true;
   //cubemap = sky_environment;
};

%mat = new Material(Material_checkpad)
{
   mapTo = checkpad;
   baseTex[0] = "~/data/shapes_mbu/pads/checkpad";
   pixelSpecular[0] = true;
   specular[0] = "1.0 1.0 1.0 1.0";
   specularPower[0] = 32.0;
};

//startarea.dts

%mat = new Material(Material_ringglass)
{
   mapTo = ringglass;

   baseTex[0] = "~/data/shapes_mbu/pads/ringglass";
   bumpTex[0] = "~/data/shapes_mbu/pads/ringnormal";
   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 12.0;
   emissive[0] = true;
   translucent[0] = true;
   cubemap = sky_environment;
};


%mat = new Material(Material_ringtex)
{
   mapTo = ringtex;

   //bumpTex[0] = "~/data/shapes_mbu/pads/pad_base2.normal";
   baseTex[0] = "~/data/shapes_mbu/pads/ringtex";
   pixelSpecular[0] = true;
   specular[0] = "0.3 0.3 0.3 0.7";
   specularPower[0] = 14.0;
   
 };
 
//Unused atm - Tim
// %mat = new Material(Material_center)
//{
//   mapTo = center;
 //bumpTex[0] = "~/data/shapes_mbu/pads/pad_base2.normal";
//   baseTex[0] = "~/data/shapes_mbu/pads/center";
//   pixelSpecular[0] = true;
//   specular[0] = "0.3 0.3 0.3 1.0";
//   specularPower[0] = 12.0;
//   emissive[0] = true;
// };

%mat = new Material(Material_abyss)
{
   mapTo = abyss;

   //bumpTex[0] = "~/data/shapes_mbu/pads/pad_base2.normal";
   baseTex[0] = "~/data/shapes_mbu/pads/abyss";
   emissive[0] = true;
   //glow[0] = true;
   animFlags[0] = $rotate;
   rotPivotOffset[0] = "-0.5 -0.5";
   rotSpeed[0] = 1.0;
   

 };
 
 %mat = new Material(Material_abyss2)
{
   mapTo = abyss2;

   baseTex[0] = "~/data/shapes_mbu/pads/abyss2";
  // emissive[0] = true;
   glow[0] = true;
   animFlags[0] = $rotate;
   rotPivotOffset[0] = "-0.5 -0.5";
   rotSpeed[0] = 1.0;
   
 };
 
 

%mat = new Material(Material_misty)
{
   mapTo = misty;

   //bumpTex[0] = "~/data/shapes_mbu/pads/pad_base2.normal";
   baseTex[0] = "~/data/shapes_mbu/pads/misty";

   translucent[0] = true;
   translucentBlendOp = LerpAlpha;
   
   animFlags[0] = $scroll;
   scrollDir[0] = "0.0 1.0";
   scrollSpeed[0] = 0.5;
   emissive[0] = true;
   glow[0] = true;


 };
 
 %mat = new Material(Material_mistyglow)
{
   mapTo = mistyglow;

   baseTex[0] = "~/data/shapes_mbu/pads/mistyglow";
   glow[0] = true;
   emissive[0] = true;
   translucent[0] = true;
   //cubemap = sky_environment;
};

%mat = new Material(Material_corona)
{
   mapTo = corona;

   //bumpTex[0] = "~/data/shapes_mbu/pads/pad_base2.normal";
   baseTex[0] = "~/data/shapes_mbu/images/corona";
   glow[0] = true;
   emissive[0] = true;
   translucent[0] = true;
   translucentBlendOp = Add;

   animFlags[0] = $rotate;
   rotPivotOffset[0] = "-0.5 -0.5";
   rotSpeed[0] = 3.0;
 };

//cautionsign.dts
%mat = new Material(Material_BaseCautionSign)
{
   baseTex[0] = "~/data/shapes_mbu/signs/base.cautionsign";
};

%mat = new Material(Material_CautionCautionSign)
{
   baseTex[0] = "~/data/shapes_mbu/signs/caution.cautionsign";
};

%mat = new Material(Material_DangerCautionSign)
{
   baseTex[0] = "~/data/shapes_mbu/signs/danger.cautionsign";
};

%mat = new Material(Material_CautionSignWood)
{
   baseTex[0] = "~/data/shapes_mbu/signs/cautionsignwood";
};

%mat = new Material(Material_CautionSignPole)
{
   baseTex[0] = "~/data/shapes_mbu/signs/cautionsign_pole";
};

//plainsign.dts
%mat = new Material(Material_PlainSignWood)
{
   baseTex[0] = "~/data/shapes_mbu/signs/plainsignwood";
};

%mat = new Material(Material_BasePlainSign)
{
   baseTex[0] = "~/data/shapes_mbu/signs/base.plainSign";
};

%mat = new Material(Material_DownPlainSign)
{
   baseTex[0] = "~/data/shapes_mbu/signs/down.plainSign";
};

%mat = new Material(Material_LeftPlainSign)
{
   baseTex[0] = "~/data/shapes_mbu/signs/left.plainSign";
};

%mat = new Material(Material_RightPlainSign)
{
   baseTex[0] = "~/data/shapes_mbu/signs/right.plainSign";
};

%mat = new Material(Material_UpPlainSign)
{
   baseTex[0] = "~/data/shapes_mbu/signs/up.plainSign";
};

%mat = new Material(Material_PlainSignWood2)
{
   baseTex[0] = "~/data/shapes_mbu/signs/signwood2";
};

%mat = new Material(Material_SignWood)
{
   baseTex[0] = "~/data/shapes_mbu/signs/signwood";
};

%mat = new Material(Material_astrolabe)
{
   mapTo = "astrolabe_glow";

   baseTex[0] = "~/data/shapes_mbu/astrolabe/astrolabe_glow";

   translucent[0] = true;

   emissive[0] = true;
   renderBin = "SkyShape";
};

%mat = new Material(Material_astrolabe_solid)
{
   mapTo = "astrolabe_solid_glow";

   baseTex[0] = "~/data/shapes_mbu/astrolabe/astrolabe_solid_glow";

   translucent[0] = true;

   emissive[0] = true;
   renderBin = "SkyShape";
};

%mat = new Material(Material_clouds_beginner)
{
   mapTo = "clouds_beginner";

   baseTex[0] = "~/data/shapes_mbu/astrolabe/clouds_beginner";

   translucent[0] = true;

   emissive[0] = true;
   renderBin = "SkyShape";
};

%mat = new Material(Material_clouds_intermediate)
{
   mapTo = "clouds_intermediate";

   baseTex[0] = "~/data/shapes_mbu/astrolabe/clouds_intermediate";

   translucent[0] = true;

   emissive[0] = true;
   renderBin = "SkyShape";
};

%mat = new Material(Material_clouds_advanced)
{
   mapTo = "clouds_advanced";

   baseTex[0] = "~/data/shapes_mbu/astrolabe/clouds_advanced";

   translucent[0] = true;

   emissive[0] = true;
   renderBin = "SkyShape";
};

new CustomMaterial(Mat_Glass_NoRefract)
{
   
   texture[0] = "~/data/shapes_mbu/structures/glass2";
    baseTex[0] = "~/data/shapes_mbu/structures/glass";
   
   friction = 1;
   restitution = 1;
   force = 0;

   version = 2.0;
   translucent = true;
   translucentZWrite = false;
   blendOp = LerpAlpha;
   shader = StdTex;
};

new CustomMaterial(Material_glass)
{
   mapTo = "glass";

   texture[0] = "~/data/shapes_mbu/structures/glass.normal";
   texture[1] = "$backbuff";
   texture[2] = "~/data/shapes_mbu/structures/glass";
   
   friction = 1;
   restitution = 1;
   force = 0;

   specular[0] = "1.0 1.0 1.0 1.0";
   specularPower[0] = 12.0;

   version = 2.0;
   refract = true;
   shader = RefractPix;

   pass[0] = Mat_Glass_NoRefract;
   renderBin = "TranslucentPreGlow";
};



//%mat = new Material(Material_glass)
//{
//eventually we want to use refraction here
//   mapTo = "glass.png";
   
//   baseTex[0] = "~/data/shapes_mbu/structures/glass";
//   translucent[0] = true;
   //translucentZwrite = true;
   //bumpTex[0] = "~/data/shapes_mbu/structures/glass.normal";

//   pixelSpecular[0] = true;
//   specular[0] = "1 1 1 1.0";
//   specularPower[0] = 10.0;
//};

%mat = new Material(Material_GemBeam)
{
   baseTex[0] = "marble/data/shapes/items/gembeam";
   translucent[0] = true;
   //translucentZwrite = true;
   emissive[0] = true;

   pixelSpecular[0] = true;
   specular[0] = "0.5 0.6 0.5 0.6";
   specularPower[0] = 12.0;
};

%mat = new Material(Material_ArrowSignArrow)
{
   mapTo = arrowsign_arrow;
	
   baseTex[0] = "marble/data/shapes/signs/arrowsign_arrow";
   bumpTex[0] = "marble/data/shapes/items/arrow_bump";
   //emissive[0] = true;
   //glow[0]=true;

   pixelSpecular[0] = true;
   specular[0] = "1 1 1 1";
   specularPower[0] = 32.0;
};

%mat = new Material(Material_ArrowSignArrowGlow)
{
   mapTo = arrowsign_arrow_glow;
	
   baseTex[0] = "marble/data/shapes/signs/arrowsign_arrow";

      pixelSpecular[0] = true;
   specular[0] = ".3 .3 .3 .3";
   specularPower[0] = 32.0;

   glow[0]=true;

};

%mat = new Material(Material_ArrowSignPost)
{
   mapTo = arrowpostUVW;
   
   baseTex[0] = "~/data/shapes_mbu/signs/arrowpostUVW";
   //bumpTex[0] = "~/data/shapes_mbu/signs/arrowsign_post_bump";

   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 32.0;
};

%mat = new Material(Material_ArrowSignChain)
{
   mapTo = arrowsign_chain;
   
   baseTex[0] = "~/data/shapes_mbu/signs/arrowsign_chain";
   
   emissive[0] = true;
   glow[0] = true;
   translucent[0] = true;
   //translucentblendop[0] = add;
   
};

%mat = new Material(Material_ArrowSignPost)
{
   mapTo = arrowsign_post;
   
   baseTex[0] = "~/data/shapes_mbu/signs/arrowsign_post";
   bumpTex[0] = "~/data/shapes_mbu/signs/arrowsign_post_bump";

   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;
};

new CustomMaterial(Material_TimeTravelGlass)
{
   mapto = timeTravel_glass;

   texture[0] = "~/data/shapes_mbu/structures/time.normal";
   texture[1] = "$backbuff";
   texture[2] = "~/data/shapes_mbu/structures/glass";

   friction = 1;
   restitution = 1;
   force = 0;

   specular[0] = "1 1 1 1.0";
   specularPower[0] = 10.0;

   version = 2.0;
   refract = true;
   shader = RefractPix;
};

new CustomMaterial(Material_distort_d)
{
   mapto = distort_d;

   texture[0] = "~/data/shapes_mbu/Particles/distort_n";
   texture[1] = "$backbuff";
   texture[2] = "~/data/shapes_mbu/Particles/distort_d";
   //specular[0] = "1 1 1 1.0";
   //specularPower[0] = 10.0;

   version = 2.0;
   refract = true;
   shader = RefractPix;
};



new CustomMaterial(Material_cube_glass)
{
   mapTo = "cube_glass";

   texture[0] = "~/data/shapes_mbu/structures/cube_glass.normal";
   texture[1] = "$backbuff";
   texture[2] = "~/data/shapes_mbu/structures/cube_glass";

   friction = 0.8;
   restitution = 0.1;
   force = 0;

   specular[0] = "1 1 1 1.0";
   specularPower[0] = 10.0;

   version = 2.0;
   refract = true;
   shader = RefractPix;

   pass[0] = Mat_Glass_NoRefract;
};

new CustomMaterial(Material_refract)
{
   mapto = refract;

   texture[0] = "~/data/shapes_mbu/structures/time.normal";
   texture[1] = "$backbuff";
   texture[2] = "~/data/shapes_mbu/pads/refract";

   friction = 1;
   restitution = 1;
   force = 0;

   specular[0] = "1 1 1 1.0";
   specularPower[0] = 10.0;

   version = 2.0;
   refract = true;
   shader = RefractPix;
};

%mat = new Material(Material_blastwave)
{
   mapTo = blastwave;
   //bumpTex[0] = "~/data/shapes_mbu/pads/pad_base2.normal";
   baseTex[0] = "~/data/shapes_mbu/images/blastwave";
   glow[0] = true;
   emissive[0] = true;
   translucent[0] = true;
   translucentBlendOp = Add;

 };
 
 %mat = new Material(Material_sigil)
{
   mapTo = sigil;

   // stage 0
   baseTex[0] = "~/data/shapes_mbu/pads/sigil";
   //emissive[0] = true;
   glow[0]=true;
   emissive[0] = true;
   translucent[0] = true;
   translucentBlendOp = Add;
};

 %mat = new Material(Material_sigil_glow)
{
   mapTo = sigil_glow;

   // stage 0
   baseTex[0] = "~/data/shapes_mbu/pads/sigil_glow";
   //emissive[0] = true;
   glow[0]=true;
   emissive[0] = true;
   translucent[0] = true;
   translucentBlendOp = Add;
   animFlags[0] = $scroll;
   scrollDir[0] = "1.0 0.0";
   scrollSpeed[0] = 0.3;
};

 %mat = new Material(Material_sigiloff)
{
   mapTo = sigiloff;

   // stage 0
   baseTex[0] = "~/data/shapes_mbu/pads/sigiloff";
   //emissive[0] = true;
//   glow[0]=true;
//   emissive[0] = true;
   translucent[0] = true;
//   translucentBlendOp = Add;
};

 %mat = new Material(lightning1frame1)
{
   mapTo = lightning1frame1;
   baseTex[0] = "~/data/shapes_mbu/bumpers/lightning1frame1";

	emmisive[0] = true;
	glow[0] = true;
	animFlags[0] = $sequence;
	sequenceFramePerSec[0] = 4.0;
	sequenceSegmentSize[0] = 0.25;
    translucent[0] = true;
};
