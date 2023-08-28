// maps a texture name to the specified material object.  You should not need to call this function,
// unless you want to override a mapping for a texture (normally the mapping is set up by the baseTex
// property of the Material or the mapTo field of the material).
function mapMaterial(%name,%material)
{
   addMaterialMapping(%name, "material: " @ %material);
}

function loadMaterials()
{
   // load base materials
   exec("./baseMaterials.cs");
   
   for( %file = findFirstFile( "*/materials.cs" ); %file !$= ""; %file = findNextFile( "*/materials.cs" ))
   {
      exec( %file );
   }

   // load custom material files
   exec("./shapeMaterials.cs");
   exec("./interiorMaterials.cs");
   exec("./shapeMaterials_MBU.cs");
   exec("./interiorMaterials_MBU.cs");
}

function reloadMaterials()
{
   reloadTextures();
   loadMaterials();
   reInitMaterials();
}  
