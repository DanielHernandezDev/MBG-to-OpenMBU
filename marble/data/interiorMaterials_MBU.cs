new CubemapData( iceCubemap )
{
   cubeFace[0] = "~/data/interiors_mbu/acubexpos2";
   cubeFace[1] = "~/data/interiors_mbu/acubexneg2";
   cubeFace[2] = "~/data/interiors_mbu/acubezneg2";
   cubeFace[3] = "~/data/interiors_mbu/acubezpos2";
   cubeFace[4] = "~/data/interiors_mbu/acubeypos2";
   cubeFace[5] = "~/data/interiors_mbu/acubeyneg2";
};

new Material(DefaultMaterial) {

   translucent[0] = false;
   friction = 1;

   restitution = 1;
   force = 0;

   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;
};

new Material(CementMaterial) {
   translucent[0] = false;
   friction = 1;
   restitution = 1;
   force = 0;

   pixelSpecular[0] = true;
   specular[0] = "0.8 0.8 0.6 1.0";
   specularPower[0] = 12.0;
};

//-----------------------------------------------------------------------------
// Set Dressing Textures
//-----------------------------------------------------------------------------

new ShaderData( NoiseTile )
{
   DXVertexShaderFile   = "shaders/noiseTileV.hlsl";
   DXPixelShaderFile    = "shaders/noiseTileP.hlsl";
   pixVersion = 2.0;
};

new ShaderData( HalfTile )
{
   DXVertexShaderFile   = "shaders/halfTileV.hlsl";
   DXPixelShaderFile    = "shaders/halfTileP.hlsl";
   pixVersion = 2.0;
};


// Metal Plate random tile texture

%mat = new CustomMaterial( Material_Plate )
{
   mapTo = plate_1;
   texture[0] = "./interiors_mbu/plate.randomize";
   texture[1] = "./interiors_mbu/plate.normal";

   friction = 1;
   restitution = 1;
   force = 0;   

   specular[0] = "1.0 1.0 0.8 1.0";
   specularPower[0] = 8.0;

   shader = HalfTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Beginner )
{
   mapTo = tile_beginner;
   texture[0] = "./interiors_mbu/tile_beginner";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise";
   
   specular[0] = "1 1 1 1";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Beginner_Red  )
{
   mapTo = tile_beginner_red;
   texture[0] = "./interiors_mbu/tile_beginner";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_red";
   
   specular[0] = "1 1 1 1";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};


%mat = new CustomMaterial( Material_Tile_Beginner_Blue  )
{
   mapTo = tile_beginner_blue;
   texture[0] = "./interiors_mbu/tile_beginner";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_blue";
   
   specular[0] = "1 1 1 1";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};


%mat = new CustomMaterial( Material_Tile_Intermediate  )
{
   mapTo = tile_intermediate;
   texture[0] = "./interiors_mbu/tile_intermediate";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise";
   
   specular[0] = "1 1 1 1";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
      force = 0;

   shader = NoiseTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Intermediate_green  )
{
   mapTo = tile_intermediate_green;
   texture[0] = "./interiors_mbu/tile_intermediate";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_green";
   
   specular[0] = "1 1 1 1";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Intermediate_red  )
{
   mapTo = tile_intermediate_red;
   texture[0] = "./interiors_mbu/tile_intermediate";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_red";
   
   specular[0] = "1 1 1 1";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Advanced  )
{
   mapTo = tile_advanced;
   texture[0] = "./interiors_mbu/tile_advanced";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise";
   
   specular[0] = "1 1 1 1";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Advanced_Blue  )
{
   mapTo = tile_advanced_blue;
   texture[0] = "./interiors_mbu/tile_advanced";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_blue";
   
   specular[0] = "1 1 1 1";
   specularPower[0] = 40.0;
   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Advanced_Green  )
{
   mapTo = tile_advanced_green;
   texture[0] = "./interiors_mbu/tile_advanced";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_green";
   
   specular[0] = "1 1 1 1";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Beginner_shadow )
{
   mapTo = tile_beginner_shadow;
   texture[0] = "./interiors_mbu/tile_beginner";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_shadow";
   
   specular[0] = "0.2 0.2 0.2 0.2";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Beginner_Red_shadow  )
{
   mapTo = tile_beginner_red_shadow;
   texture[0] = "./interiors_mbu/tile_beginner";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_red_shadow";
   
   specular[0] = "0.2 0.2 0.2 0.2";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};


%mat = new CustomMaterial( Material_Tile_Beginner_Blue_shadow  )
{
   mapTo = tile_beginner_blue_shadow;
   texture[0] = "./interiors_mbu/tile_beginner";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_blue_shadow";
   
   specular[0] = "0.2 0.2 0.2 0.2";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};


%mat = new CustomMaterial( Material_Tile_Intermediate_shadow  )
{
   mapTo = tile_intermediate_shadow;
   texture[0] = "./interiors_mbu/tile_intermediate";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_shadow";
   
   specular[0] = "0.2 0.2 0.2 0.2";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
      force = 0;

   shader = NoiseTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Intermediate_green_shadow  )
{
   mapTo = tile_intermediate_green_shadow;
   texture[0] = "./interiors_mbu/tile_intermediate";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_green_shadow";
   
   specular[0] = "0.2 0.2 0.2 0.2";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Intermediate_red_shadow  )
{
   mapTo = tile_intermediate_red_shadow;
   texture[0] = "./interiors_mbu/tile_intermediate";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_red_shadow";
   
   specular[0] = "0.2 0.2 0.2 0.2";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Advanced_shadow  )
{
   mapTo = tile_advanced_shadow;
   texture[0] = "./interiors_mbu/tile_advanced";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_shadow";
   
   specular[0] = "0.2 0.2 0.2 0.2";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Advanced_Blue_shadow  )
{
   mapTo = tile_advanced_blue_shadow;
   texture[0] = "./interiors_mbu/tile_advanced";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_blue_shadow";
   
   specular[0] = "0.2 0.2 0.2 0.2";
   specularPower[0] = 40.0;
   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Advanced_Green_shadow  )
{
   mapTo = tile_advanced_green_shadow;
   texture[0] = "./interiors_mbu/tile_advanced";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise_green_shadow";
   
   specular[0] = "0.2 0.2 0.2 0.2";
   specularPower[0] = 40.0;

   friction = 1;
   restitution = 1;
   force = 0;

   shader = NoiseTile;
   version = 2.0;
};

%mat = new CustomMaterial( Material_Tile_Underside  )
{
   mapTo = tile_underside;
   texture[0] = "./interiors_mbu/tile_underside";
   texture[1] = "./interiors_mbu/tile_intermediate.normal";
   texture[2] = "./interiors_mbu/noise";
   
   specular[0] = "1 1 1 1";
   specularPower[0] = 40.0;

   shader = NoiseTile;
   version = 2.0;
};


%mat = new Material(Material_Wall_Beginner : DefaultMaterial) {
   mapTo="wall_beginner";

   baseTex[0] = "./interiors_mbu/wall_beginner";
   //bumpTex[0] = "./interiors_mbu/plate.normal";
};

%mat = new Material(Material_Edge_White : DefaultMaterial)
{
   mapTo = "mbu_edge_white";
   baseTex[0] = "./interiors_mbu/edge_white";
   bumpTex[0] = "./interiors_mbu/edge.normal";

   specular[0] = "0.8 0.8 0.8 1.0";
   specularPower[0] = 50.0;
   
};

%mat = new Material(Material_Edge_White_shadow : DefaultMaterial)
{
   mapTo = "edge_white_shadow";
   baseTex[0] = "./interiors_mbu/edge_white_shadow";
   bumpTex[0] = "./interiors_mbu/edge.normal";

   specular[0] = "0.2 0.2 0.2 0.2";
   specularPower[0] = 50.0;
   
};

%mat = new Material(Material_beam : DefaultMaterial) {
   baseTex[0] = "./interiors_mbu/beam";
   bumpTex[0] = "./interiors_mbu/beam.normal";
};

%mat = new Material(Material_BeamSide : DefaultMaterial) {
   baseTex[0] = "./interiors_mbu/beam_side";
   bumpTex[0] = "./interiors_mbu/beam_side.normal";
};

// ---------------------------------------------------------------------------
// Friction Materials
// ---------------------------------------------------------------------------

%mat = new Material(Material_LowFriction) {
   baseTex[0] = "./interiors_mbu/friction_low";
   bumpTex[0] = "./interiors_mbu/friction_low.normal";
   friction = 0.20;
   restitution = 1.0;
   force = 0;
   
   mapTo = friction_low_mbu;
   
   cubemap[0] = iceCubemap;
   
   //FUCK ICE
   //baseTex[1] = "./interiors_mbu/friction_low";
   //bumpTex[1] = "./interiors_mbu/friction_low.normal";
   //translucent[1] = true;
   pixelSpecular[0] = true;
   specular[0] = "1.0 1.0 1.0 0.8";
   specularPower[0] = 128.0;
};

//updated
%mat = new Material(Material_HighFriction : DefaultMaterial) {
   friction = 4.5;
   restitution = 0.5;
   force = 0;
  
   specular[0] = "0.3 0.3 0.35 1.0";
   specularPower[0] = 10.0;
   
   MAPTO = "friction_high_mbu";
   baseTex[0] = "./interiors_mbu/friction_high";
   bumpTex[0] = "./interiors_mbu/friction_high.normal";
};

%mat = new Material(Material_HighFriction_Shadow : DefaultMaterial) {
   friction = 4.5;
   restitution = 0.5;
   force = 0;
  
   specular[0] = "0.15 0.15 0.16 1.0";
   specularPower[0] = 10.0;
   
   MAPTO = "friction_high_mbu_shadow";
   baseTex[0] = "./interiors_mbu/friction_high_shadow";
   bumpTex[0] = "./interiors_mbu/friction_high.normal";
};

%mat = new Material(Material_LowFriction_Shadow) {
   baseTex[0] = "./interiors_mbu/friction_low_shadow";
   bumpTex[0] = "./interiors_mbu/friction_low.normal";
   friction = 0.20;
   restitution = 1.0;
   force = 0;
   
   mapTo = friction_low_shadow;
   
   cubemap[0] = iceCubemap;
   
   pixelSpecular[0] = true;
   specular[0] = "0.3 0.3 0.35 1.0";
   specularPower[0] = 128.0;
};

// Adding this back in
%mat = new Material(Material_stripe_caution : DefaultMaterial)
{
   mapTo = mbu_stripe_caution;
   baseTex[0] = "./interiors_mbu/stripe_caution";
};