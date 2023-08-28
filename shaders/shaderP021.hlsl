//*****************************************************************************
// TSE -- HLSL procedural shader                                               
//*****************************************************************************
//-----------------------------------------------------------------------------
// Structures                                                                  
//-----------------------------------------------------------------------------
struct ConnectData
{
   float2 texCoord        : TEXCOORD0;
   float4 dlightCoord     : TEXCOORD1;
   float3 reflectVec      : TEXCOORD2;
   float3 normal          : TEXCOORD3;
   float3 pixPos          : TEXCOORD4;
   float3 eyePos          : TEXCOORD5;
   float4 lightVec        : TEXCOORD6;
   float2 fogCoord        : TEXCOORD7;
};


struct Fragout
{
   float4 col : COLOR0;
};


//-----------------------------------------------------------------------------
// Main                                                                        
//-----------------------------------------------------------------------------
Fragout main( ConnectData IN,
              uniform sampler2D diffuseMap      : register(S0),
              uniform sampler3D dlightMap       : register(S1),
              uniform float4    lightColor      : register(C2),
              uniform samplerCUBE cubeMap         : register(S2),
              uniform float4    specularColor   : register(C0),
              uniform float     specularPower   : register(C1),
              uniform float     visibility      : register(C9),
              uniform sampler2D fogMap          : register(S3)
)
{
   Fragout OUT;

   float4 diffuseColor = tex2D(diffuseMap, IN.texCoord);
   OUT.col = diffuseColor;
   float4 attn = tex3D(dlightMap, IN.dlightCoord) * lightColor;
   OUT.col *= attn;
   OUT.col += attn.x * diffuseColor.a * texCUBE(cubeMap, IN.reflectVec);

   float3 eyeVec = normalize(IN.eyePos - IN.pixPos);
   float3 halfAng = normalize(eyeVec + IN.lightVec.xyz);
   float specular = saturate( dot(IN.normal.xyz, halfAng) ) * IN.lightVec.w;
   specular = pow(specular, specularPower);
   OUT.col += specularColor * specular * attn * diffuseColor.a;
   OUT.col.a = 1.0;
   OUT.col.a *= visibility;
   float4 fogColor = tex2D(fogMap, IN.fogCoord);
   OUT.col.a = 1.0 - fogColor.a;

   return OUT;
}
