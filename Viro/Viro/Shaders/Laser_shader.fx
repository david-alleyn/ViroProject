//= vertex and pixel structures

struct LaserVertexToPixel
{
    float4 Position     : POSITION;
    float3 Normal       : TEXCOORD0;
    float4 Orig_pos     : TEXCOORD2;
};

struct PixelToFrame
{  
    float4 Color        : COLOR;
};
//-

//= standard world matrices and light array
float4x4 worldViewProj : WORLDVIEWPROJECTION;
float4x4 worldMatrix : WORLD;
//-

//= Laser bolt variables
uniform extern float4 laser_bolt_color;
uniform extern float3 center_to_viewer;
uniform extern float pulse;
//-


//-

//++=============================================================================================================================================
// Vertex Shaders 
//++=============================================================================================================================================

LaserVertexToPixel Laser_VertexShader(float4 position    : POSITION, 
                                        float2    texCoord    : TEXCOORD0,
                                        float3 normal : NORMAL0)
{
    LaserVertexToPixel Output = (LaserVertexToPixel)0;
   
    Output.Position = mul(position, worldViewProj);
    // we'll normalize the normal in the pixel shader.  No guarantee it will be normal coming out of the raterizer so
    // no point in normalizing it twice by doing it here and in the pixel shader.
    Output.Normal = (mul(normal, (float3x3) worldViewProj));
    
    Output.Orig_pos = position;

    return Output;
};

//++=============================================================================================================================================
// Pixel Shaders 
//++=============================================================================================================================================

PixelToFrame Laserbolt_PixelShader (LaserVertexToPixel PSIn)
{
      PixelToFrame Output = (PixelToFrame)0;

      float cosang;
      float white_heat;
      float4 the_color;
    
       PSIn.Normal = normalize(PSIn.Normal);
     
       // determines whether we're processing at the center (1) or the edges (near 0)
       cosang = 1-abs((dot(center_to_viewer,PSIn.Normal))); 
      
       // width of the white stripe down the middle controlled by the exponent
       white_heat =  pow(cosang,2.751);  
       
       // bit of alpha blending on the ends
       float endfade = clamp(1-(abs(PSIn.Orig_pos.z)+.05),0,1);
    
       // falloff controlled by the exponent
       endfade =  pow(endfade,.0000000075);
     
       // add in the white heat
       the_color =  laser_bolt_color;
 
      //alpha on the edges.. again, fadeoff controlled by the exponent
      the_color.a = pow(cosang,pulse);
     
      the_color.a = min(the_color.a,endfade);
        
      Output.Color = the_color;
   return Output;
};

//++=============================================================================================================================================
// Techniques 
//++=============================================================================================================================================

technique laserbolt_technique
{
    pass laser_pass
    {
         VertexShader = compile vs_3_0 Laser_VertexShader();
         PixelShader = compile ps_3_0 Laserbolt_PixelShader();
    }
}