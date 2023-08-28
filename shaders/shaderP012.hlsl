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
   float2 fogCoord        : TEXCOORD1;
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
              uniform float     visibility      : register(C9),
              uniform sampler2D fogMap          : register(S1)
)
{
   Fragout OUT;

   OUT.col = IN.shading + ambient;
   OUT.col *= tex2D(diffuseMap, IN.texCoord);
   OUT.col.a *= visibility;
   float4 fogColor = tex2D(fogMap, IN.fogCoord);
   OUT.col.rgb = lerp(OUT.col.rgb, fogColor.rgb, fogColor.a);

   return OUT;
}
