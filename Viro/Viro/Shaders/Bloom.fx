float4x4 worldViewProj : WORLDVIEWPROJECTION;

// This shader gets the areas that are bright. This will later be blured making bright spots "glow"
 
// Get the threshold of what brightness level we want to glow
float Threshold = 0.6;
 
texture BaseScene;
sampler TextureSampler = sampler_state
{
   Texture = <BaseScene>;
   MinFilter = Linear;
   MagFilter = Linear;
   MipFilter = Linear;  
   AddressU  = Clamp;
   AddressV  = Clamp;
};
 
float4 PixelShader(float2 texCoord : TEXCOORD0) : COLOR0
{
    float4 Color = tex2D(TextureSampler, texCoord);
   
    // Get the bright areas that is brighter than Threshold and return it.
    return saturate((Color - Threshold) / (1 - Threshold));
}
 
void DOF_VertexShader(
    float4 pos : POSITION, float2 tex : TEXCOORD0,
    out float4 o_pos : POSITION, out float2 o_tex : TEXCOORD0)
{
    o_pos = mul(pos, worldViewProj);
    o_tex = tex;
}
 
technique Bloom
{
    pass
    {
        PixelShader = compile ps_2_0 PixelShader();
		VertexShader = compile vs_2_0 DOF_VertexShader();
    }
}