float4x4 worldViewProj : WORLDVIEWPROJECTION;

texture2D randomNumber;
texture2D displayTexture;
float alphaChange;

sampler2D RandomNumberTextureSampler = sampler_state
{
	Texture = (randomNumber);
	AddressU = Wrap;
	AddressV = Wrap;
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
	float4 rand = tex2D(RandomNumberTextureSampler, texCoord);
	float change = reg.a - (alphaChange / (rand.r));
	clip(change);
	if(rand.r > 0.5f)
	{
		reg.r -= rand.r/15 + change;
		reg.g += rand.r/15 - change;
		reg.b -= rand.r/15 + change;
	}
	reg.a = 0;
	return (reg);
}

technique disolve
{
   pass
   {
		AlphaBlendEnable	= true;
		SrcBlend			= SrcAlpha;
		DestBlend			= DestColor;
		VertexShader = compile vs_2_0 VS();
		PixelShader = compile ps_2_0 PS();
   }
}