float4x4 worldViewProj : WORLDVIEWPROJECTION;

texture2D infectedTexture;
texture2D displayTexture;

sampler2D InfectedTextureSampler = sampler_state
{
	Texture = (infectedTexture);
	AddressU = Clamp;
	AddressV = Clamp;
};

sampler2D TextureSampler = sampler_state
{
	Texture = (displayTexture);
	AddressU = Clamp;
	AddressV = Clamp;
};

void VS(float4 position	: POSITION, 
		out float4 positionOut : POSITION,
		float2	texCoord	: TEXCOORD0,
	out	float2	texCoordOut	: TEXCOORD0)
{
	positionOut = mul(position,worldViewProj);

	texCoordOut	= texCoord;
}


float4 PS(float2 texCoord : TEXCOORD0) : COLOR 
{
	float4 reg = tex2D(TextureSampler, texCoord);
	float4 inf = tex2D(InfectedTextureSampler, texCoord);
	return (reg*inf);
}

technique infect
{
   pass
   {
		VertexShader = compile vs_2_0 VS();
		PixelShader = compile ps_2_0 PS();
   }
}