//*****************************************************************************
// TSE -- HLSL procedural shader                                               
//*****************************************************************************
//-----------------------------------------------------------------------------
// Structures                                                                  
//-----------------------------------------------------------------------------
struct ConnectData
{
   float4 shading         : COLOR;
   float2 texCoord        : TEXCOORD0;
   float3 lightVec        : TEXCOORD1;
};


struct Fragout
{
   float4 col : COLOR0;
};


//-----------------------------------------------------------------------------
// Main                                                                        
//-----------------------------------------------------------------------------
Fragout main( ConnectData IN,
              uniform float4    ambient         : register(C3),
              uniform sampler2D diffuseMap      : register(S0),
              uniform sampler2D bumpMap         : register(S1),
              uniform float     visibility      : register(C9)
)
{
   Fragout OUT;

   OUT.col = tex2D(diffuseMap, IN.texCoord);
   float4 bumpNormal = tex2D(bumpMap, IN.texCoord);

   float4 bumpDot = ( dot(bumpNormal.xyz * 2.0 - 1.0, IN.lightVec.xyz) + 1.0 ) * 0.5;
   OUT.col *= (IN.shading * bumpDot) + ambient;
   OUT.col.a *= visibility;

   return OUT;
}
