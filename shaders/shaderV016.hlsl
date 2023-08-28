//*****************************************************************************
// TSE -- HLSL procedural shader                                               
//*****************************************************************************
//-----------------------------------------------------------------------------
// Structures                                                                  
//-----------------------------------------------------------------------------
struct VertData
{
   float2 texCoord        : TEXCOORD0;
   float2 lmCoord         : TEXCOORD1;
   float3 T               : TEXCOORD2;
   float3 B               : TEXCOORD3;
   float3 N               : TEXCOORD4;
   float3 normal          : NORMAL;
   float4 position        : POSITION;
};


struct ConnectData
{
   float4 hpos            : POSITION;
   float2 outTexCoord     : TEXCOORD0;
   float4 dlightCoord     : TEXCOORD1;
   float4 outLightVec     : TEXCOORD2;
   float3 pos             : TEXCOORD3;
   float3 outEyePos       : TEXCOORD4;
   float2 fogCoord        : TEXCOORD5;
};


//-----------------------------------------------------------------------------
// Main                                                                        
//-----------------------------------------------------------------------------
ConnectData main( VertData IN,
                  uniform float4x4 modelview       : register(C0),
                  uniform float4   lightPos        : register(C23),
                  uniform float4x4 objTrans        : register(C12),
                  uniform float4x4 lightingMatrix  : register(C8),
                  uniform float3   eyePos          : register(C20),
                  uniform float3   inLightVec      : register(C24),
                  uniform float3   fogData         : register(C22)
)
{
   ConnectData OUT;

   OUT.hpos = mul(modelview, IN.position);
   OUT.outTexCoord = IN.texCoord;
   OUT.dlightCoord = ((mul(objTrans, IN.position.xyz) - mul(objTrans, lightPos.xyz)) * lightPos.w);
   OUT.dlightCoord = mul(lightingMatrix, OUT.dlightCoord) + 0.5;

   float3x3 objToTangentSpace;
   objToTangentSpace[0] = IN.T;
   objToTangentSpace[1] = IN.B;
   objToTangentSpace[2] = IN.N;

   OUT.outLightVec.xyz = normalize(lightPos.xyz - IN.position.xyz);
   OUT.dlightCoord.w = saturate(dot(OUT.outLightVec, IN.N) * 4.0);
   OUT.outLightVec.xyz = mul(objToTangentSpace, OUT.outLightVec);
   OUT.pos = mul(objToTangentSpace, IN.position.xyz / 100.0);;
   OUT.outEyePos.xyz = mul(objToTangentSpace, eyePos.xyz / 100.0);;
   OUT.outLightVec.w = step( 0.0, dot( -inLightVec, IN.normal ) );
   // fog setup
   float3 transPos = mul( objTrans, IN.position );
   OUT.fogCoord.x = 1.0 - ( distance( IN.position, eyePos ) / fogData.z );
   OUT.fogCoord.y = (transPos.z - fogData.x) * fogData.y;
   return OUT;
}
