float Distance;
float Range;
float Near;
float Far;

float4x4 worldViewProjection    : WORLDVIEWPROJECTION;

texture BaseScene;
sampler SceneSampler = sampler_state
{
   Texture = <BaseScene>;
   MinFilter = Linear;
   MagFilter = Linear;
   MipFilter = Linear;  
   AddressU  = Clamp;
   AddressV  = Clamp;
};

texture BlurScene;
sampler BlurSceneSampler = sampler_state
{
   Texture = <BlurScene>;
   MinFilter = Linear;
   MagFilter = Linear;
   MipFilter = Linear;  
   AddressU  = Clamp;
   AddressV  = Clamp;
};
           
texture DepthMap;
sampler DepthMapSampler = sampler_state
{
   Texture = <DepthMap>;
   MinFilter = Linear;
   MagFilter = Linear;
   MipFilter = Linear;  
   AddressU  = Clamp;
   AddressV  = Clamp;
};


float4 DOF_PixelShader(float2 Tex: TEXCOORD0) : COLOR
{
    // Get the scene texel
    float4 NormalScene = tex2D(SceneSampler, Tex);
   
    // Get the blurred scene texel
    float4 BlurScene = tex2D(BlurSceneSampler, Tex);
   
    // Get the depth texel
    float  fDepth = tex2D(DepthMapSampler, Tex).r;
   
    float distRatio = Distance/Far;
   
    float blurFactor = clamp(abs((fDepth - distRatio)/(1 - distRatio)), 0, 1);
   
    // Based on how far the texel is from "distance" in Distance, stored in blurFactor, mix the scene
    return lerp(NormalScene,BlurScene,blurFactor);
}

void DOF_VertexShader(
    float4 pos : POSITION, float2 tex : TEXCOORD0,
    out float4 o_pos : POSITION, out float2 o_tex : TEXCOORD0)
{
    o_pos = mul(pos, worldViewProjection);
    o_tex = tex;
}

technique PostProcessDOF
{
    pass
    {
        PixelShader = compile ps_2_0 DOF_PixelShader();
        VertexShader = compile vs_2_0 DOF_VertexShader();
    }
}