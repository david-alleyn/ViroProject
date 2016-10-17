// XenFX
// Assembly = Xen.Graphics.ShaderSystem.CustomTool, Version=7.0.1.1, Culture=neutral, PublicKeyToken=e706afd07878dfca
// SourceFile = CombineBloom.fx
// Namespace = Viro.Shaders

namespace Viro.Shaders.CombineBloom
{
	
	/// <summary><para>Technique 'BloomCombine' generated from file 'CombineBloom.fx'</para><para>Vertex Shader: approximately 5 instruction slots used, 4 registers</para><para>Pixel Shader: approximately 12 instruction slots used (2 texture, 10 arithmetic), 4 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	public sealed class BloomCombine : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'BloomCombine' shader</summary>
		public BloomCombine()
		{
			this.preg[0] = new Microsoft.Xna.Framework.Vector4(1.3F, 0F, 0F, 0F);
			this.preg[1] = new Microsoft.Xna.Framework.Vector4(1F, 0F, 0F, 0F);
			this.preg[2] = new Microsoft.Xna.Framework.Vector4(1F, 0F, 0F, 0F);
			this.preg[3] = new Microsoft.Xna.Framework.Vector4(1F, 0F, 0F, 0F);
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
			this.pts[0] = ((Xen.Graphics.TextureSamplerState)(5));
			this.pts[1] = ((Xen.Graphics.TextureSamplerState)(5));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			BloomCombine.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			BloomCombine.cid0 = state.GetNameUniqueID("BloomIntensity");
			BloomCombine.cid1 = state.GetNameUniqueID("BloomSaturation");
			BloomCombine.cid2 = state.GetNameUniqueID("OriginalIntensity");
			BloomCombine.cid3 = state.GetNameUniqueID("OriginalSaturation");
			BloomCombine.sid0 = state.GetNameUniqueID("BloomSampler");
			BloomCombine.sid1 = state.GetNameUniqueID("ColorMapSampler");
			BloomCombine.tid0 = state.GetNameUniqueID("Bloom");
			BloomCombine.tid1 = state.GetNameUniqueID("ColorMap");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != BloomCombine.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			this.preg_change = (this.preg_change | ic);
			this.vbreg_change = (this.vbreg_change | ic);
			this.vireg_change = (this.vireg_change | ic);
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc0));
			// Assign pixel shader textures and samplers
			if ((ic | this.ptc))
			{
				state.SetPixelShaderSamplers(this.ptx, this.pts);
				this.ptc = false;
			}
			if ((this.vreg_change == true))
			{
				BloomCombine.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			if ((this.preg_change == true))
			{
				BloomCombine.fx.ps_c.SetValue(this.preg);
				this.preg_change = false;
				ic = true;
			}
			if ((ext == Xen.Graphics.ShaderSystem.ShaderExtension.Blending))
			{
				ic = (ic | state.SetBlendMatricesDirect(BloomCombine.fx.vsb_c, ref this.sc1));
			}
			if ((ext == Xen.Graphics.ShaderSystem.ShaderExtension.Instancing))
			{
				this.vireg_change = (this.vireg_change | state.SetViewProjectionMatrix(ref this.vireg[0], ref this.vireg[1], ref this.vireg[2], ref this.vireg[3], ref this.sc2));
				if ((this.vireg_change == true))
				{
					BloomCombine.fx.vsi_c.SetValue(this.vireg);
					this.vireg_change = false;
					ic = true;
				}
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref BloomCombine.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((BloomCombine.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((BloomCombine.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			BloomCombine.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out BloomCombine.fx, BloomCombine.fxb, 7, 16);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return ((this.vreg_change | this.preg_change) 
						| this.ptc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 2;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(BloomCombine.vin[i]));
			index = BloomCombine.vin[(i + 2)];
		}
		/// <summary>Static graphics ID</summary>
		private static int gd;
		/// <summary>Static effect container instance</summary>
		private static Xen.Graphics.ShaderSystem.ShaderEffect fx;
		/// <summary/>
		private bool vreg_change;
		/// <summary/>
		private bool preg_change;
		/// <summary/>
		private bool vbreg_change;
		/// <summary/>
		private bool vireg_change;
		/// <summary>Return the supported modes for this shader</summary><param name="blendingSupport"/><param name="instancingSupport"/>
		protected override void GetExtensionSupportImpl(out bool blendingSupport, out bool instancingSupport)
		{
			blendingSupport = true;
			instancingSupport = true;
		}
		/// <summary>Name ID for 'BloomIntensity'</summary>
		private static int cid0;
		/// <summary>Assign the shader value 'float BloomIntensity'</summary>
		public float BloomIntensity
		{
			set
			{
				this.preg[0] = new Microsoft.Xna.Framework.Vector4(value, 0F, 0F, 0F);
				this.preg_change = true;
			}
		}
		/// <summary>Name ID for 'BloomSaturation'</summary>
		private static int cid1;
		/// <summary>Assign the shader value 'float BloomSaturation'</summary>
		public float BloomSaturation
		{
			set
			{
				this.preg[2] = new Microsoft.Xna.Framework.Vector4(value, 0F, 0F, 0F);
				this.preg_change = true;
			}
		}
		/// <summary>Name ID for 'OriginalIntensity'</summary>
		private static int cid2;
		/// <summary>Assign the shader value 'float OriginalIntensity'</summary>
		public float OriginalIntensity
		{
			set
			{
				this.preg[1] = new Microsoft.Xna.Framework.Vector4(value, 0F, 0F, 0F);
				this.preg_change = true;
			}
		}
		/// <summary>Name ID for 'OriginalSaturation'</summary>
		private static int cid3;
		/// <summary>Assign the shader value 'float OriginalSaturation'</summary>
		public float OriginalSaturation
		{
			set
			{
				this.preg[3] = new Microsoft.Xna.Framework.Vector4(value, 0F, 0F, 0F);
				this.preg_change = true;
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute '__BLENDMATRICES__GENMATRIX'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute '__VIEWPROJECTION__GENMATRIX'</summary>
		private int sc2;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D BloomSampler'</summary>
		public Xen.Graphics.TextureSamplerState BloomSampler
		{
			get
			{
				return this.pts[0];
			}
			set
			{
				if ((value != this.pts[0]))
				{
					this.pts[0] = value;
					this.ptc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D ColorMapSampler'</summary>
		public Xen.Graphics.TextureSamplerState ColorMapSampler
		{
			get
			{
				return this.pts[1];
			}
			set
			{
				if ((value != this.pts[1]))
				{
					this.pts[1] = value;
					this.ptc = true;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture Bloom'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture Bloom
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture)(this.ptx[0]));
			}
			set
			{
				if ((value != this.ptx[0]))
				{
					this.ptc = true;
					this.ptx[0] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture ColorMap'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture ColorMap
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture)(this.ptx[1]));
			}
			set
			{
				if ((value != this.ptx[1]))
				{
					this.ptc = true;
					this.ptx[1] = value;
				}
			}
		}
		/// <summary>Name uid for sampler for 'Sampler2D BloomSampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D ColorMapSampler'</summary>
		static int sid1;
		/// <summary>Name uid for texture for 'Texture Bloom'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture ColorMap'</summary>
		static int tid1;
		/// <summary>Pixel samplers/textures changed</summary>
		bool ptc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,2,0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[4];
		/// <summary>Pixel shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] preg = new Microsoft.Xna.Framework.Vector4[4];
		/// <summary>Instancing shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vireg = new Microsoft.Xna.Framework.Vector4[4];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[2];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[2];
#if XBOX360
		/// <summary>Static RLE compressed shader byte code (Xbox360)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {4,188,240,11,207,131,0,1,32,152,0,8,254,255,9,1,0,0,15,236,135,0,1,3,131,0,1,1,131,0,1,96,135,0,1,4,131,0,1,4,131,0,1,1,195,0,6,6,95,118,115,95,99,134,0,1,3,131,0,1,1,131,0,1,200,135,0,1,4,131,0,1,4,131,0,1,1,195,0,0,1,6,1,95,1,112,1,115,1,95,1,99,134,0,0,1,3,131,0,0,1,1,1,0,1,0,1,14,1,112,135,0,0,1,216,131,0,0,1,4,131,0,0,1,1,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,153,0,0,1,7,1,95,1,118,1,115,1,98,1,95,1,99,133,0,0,1,3,131,0,0,1,1,1,0,1,0,1,14,1,216,135,0,0,1,4,131,0,0,1,4,131,0,0,1,1,195,0,0,1,7,1,95,1,118,1,115,1,105,1,95,1,99,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,14,1,252,143,0,0,1,7,1,95,1,112,1,115,1,95,1,115,1,48,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,15,1,32,143,0,0,1,7,1,95,1,112,1,115,1,95,1,115,1,49,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,3,131,0,0,1,16,131,0,0,1,4,143,0,0,1,4,131,0,0,1,15,131,0,0,1,4,143,0,0,1,9,1,66,1,108,1,101,1,110,1,100,1,105,1,110,1,103,135,0,0,1,5,131,0,0,1,16,131,0,0,1,4,143,0,0,1,6,131,0,0,1,15,131,0,0,1,4,143,0,0,1,11,1,73,1,110,1,115,1,116,1,97,1,110,1,99,1,105,1,110,1,103,133,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,6,131,0,0,1,1,131,0,0,1,11,131,0,0,1,7,131,0,0,1,4,131,0,0,1,32,139,0,0,1,108,131,0,0,1,136,139,0,0,1,212,131,0,0,1,240,138,0,0,1,14,1,124,1,0,1,0,1,14,1,152,138,0,0,1,14,1,228,1,0,1,0,1,14,1,248,138,0,0,1,15,1,8,1,0,1,0,1,15,1,28,138,0,0,1,15,1,224,135,0,0,1,3,1,0,1,0,1,15,1,92,135,0,0,1,2,131,0,0,1,92,134,0,0,1,15,1,48,1,0,1,0,1,15,1,44,131,0,0,1,93,134,0,0,1,15,1,72,1,0,1,0,1,15,1,68,1,0,1,0,1,15,1,144,135,0,0,1,2,131,0,0,1,92,134,0,0,1,15,1,100,1,0,1,0,1,15,1,96,131,0,0,1,93,134,0,0,1,15,1,124,1,0,1,0,1,15,1,120,1,0,1,0,1,15,1,208,135,0,0,1,2,131,0,0,1,92,134,0,0,1,15,1,164,1,0,1,0,1,15,1,160,131,0,0,1,93,134,0,0,1,15,1,188,1,0,1,0,1,15,1,184,135,0,0,1,6,135,0,0,1,2,132,255,0,131,0,0,1,1,134,0,0,1,2,1,88,1,16,1,42,1,17,131,0,0,1,1,1,88,1,0,1,0,1,1,136,0,0,1,36,1,0,1,0,1,1,1,12,1,0,1,0,1,1,1,52,139,0,0,1,228,131,0,0,1,28,131,0,0,1,214,1,255,1,255,1,3,132,0,0,1,3,131,0,0,1,28,135,0,0,1,207,131,0,0,1,88,1,0,1,2,131,0,0,1,4,133,0,0,1,96,131,0,0,1,112,131,0,0,1,176,1,0,1,3,131,0,0,1,1,133,0,0,1,184,135,0,0,1,200,1,0,1,3,1,0,1,1,1,0,1,1,133,0,0,1,184,132,0,0,1,95,1,112,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,4,198,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,112,1,115,1,95,1,115,1,49,1,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,1,171,135,0,0,1,1,139,0,0,1,20,1,1,1,252,1,0,1,16,147,0,0,1,64,131,0,0,1,192,1,16,1,0,1,2,132,0,0,1,4,134,0,0,1,8,1,33,1,0,1,1,1,0,1,1,131,0,0,1,1,1,0,1,0,1,48,1,80,176,0,0,1,61,1,225,1,71,1,174,1,62,1,153,1,153,1,154,1,63,1,23,1,10,1,61,1,63,1,128,131,0,0,1,5,1,32,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,96,1,4,1,80,1,10,1,18,1,0,1,34,131,0,0,1,16,1,24,1,32,1,1,1,31,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,16,1,8,1,16,1,1,1,31,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,200,1,2,131,0,0,1,190,1,192,1,0,1,176,1,1,1,255,1,0,1,200,1,1,131,0,0,1,190,1,192,1,0,1,176,1,2,1,255,1,0,1,200,1,15,1,0,1,2,1,4,1,108,1,0,1,0,1,224,1,0,1,2,1,0,1,200,1,15,1,0,1,1,1,4,1,177,1,0,1,0,1,224,1,0,1,1,1,0,1,200,1,15,1,0,1,1,1,0,1,148,1,108,1,177,1,171,1,1,1,2,1,0,1,200,1,15,131,0,0,1,148,1,108,1,108,1,171,1,2,1,3,1,0,1,200,1,15,1,0,1,2,1,0,1,248,1,108,1,0,1,161,1,0,1,1,1,0,1,201,1,15,131,0,0,1,248,1,108,1,0,1,161,1,1,1,0,1,0,1,200,1,15,1,0,1,0,1,4,1,0,1,27,1,0,1,160,1,0,1,255,1,0,1,200,1,15,134,0,0,1,225,1,2,1,0,1,0,1,200,1,15,1,128,1,0,1,0,1,248,1,108,1,0,1,171,1,1,149,0,0,1,2,132,255,0,138,0,0,1,1,1,240,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,12,131,0,0,1,228,135,0,0,1,36,135,0,0,1,196,139,0,0,1,156,131,0,0,1,28,131,0,0,1,143,1,255,1,254,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,136,131,0,0,1,48,1,0,1,2,1,0,1,4,1,0,1,4,133,0,0,1,56,131,0,0,1,72,1,95,1,118,1,115,1,105,1,95,1,99,1,0,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,4,198,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,228,1,0,1,1,1,0,1,5,138,0,0,1,8,1,33,131,0,0,1,1,131,0,0,1,6,131,0,0,1,1,1,0,1,0,1,2,1,144,1,0,1,16,1,0,1,3,1,0,1,0,1,80,1,4,1,0,1,12,1,0,1,5,1,0,1,13,1,0,1,6,1,0,1,14,1,0,1,7,1,0,1,47,1,0,1,8,1,0,1,0,1,48,1,80,1,0,1,0,1,16,1,17,1,245,1,85,1,96,1,3,1,0,1,0,1,18,1,3,1,194,133,0,0,1,96,1,9,1,32,1,15,1,18,1,0,1,18,135,0,0,1,16,1,17,1,196,1,0,1,34,131,0,0,1,5,1,248,1,48,131,0,0,1,6,1,136,132,0,0,1,5,1,248,132,0,0,1,14,1,71,132,0,0,1,5,1,248,1,32,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,64,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,80,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,16,131,0,0,1,6,1,136,132,0,0,1,200,1,15,1,0,1,1,1,0,1,27,1,0,1,0,1,225,1,3,1,1,1,0,1,200,1,15,1,0,1,1,1,0,1,198,1,0,1,0,1,235,1,3,1,5,1,1,1,200,1,15,1,0,1,1,1,0,1,177,1,148,1,148,1,235,1,3,1,4,1,1,1,200,1,15,1,0,1,1,1,0,1,108,1,248,1,148,1,235,1,3,1,2,1,1,1,200,1,1,1,128,1,62,1,0,1,233,1,167,1,0,1,175,1,1,1,4,1,0,1,200,1,2,1,128,1,62,1,0,1,233,1,167,1,0,1,175,1,1,1,5,1,0,1,200,1,4,1,128,1,62,1,0,1,233,1,167,1,0,1,175,1,1,1,6,1,0,1,200,1,8,1,128,1,62,1,0,1,233,1,167,1,0,1,175,1,1,1,7,1,0,1,200,1,3,1,128,1,0,1,0,1,197,1,197,1,0,1,226,150,0,0,1,1,132,255,0,131,0,0,1,1,134,0,0,1,2,1,88,1,16,1,42,1,17,131,0,0,1,1,1,88,1,0,1,0,1,1,136,0,0,1,36,1,0,1,0,1,1,1,12,1,0,1,0,1,1,1,52,139,0,0,1,228,131,0,0,1,28,131,0,0,1,214,1,255,1,255,1,3,132,0,0,1,3,131,0,0,1,28,135,0,0,1,207,131,0,0,1,88,1,0,1,2,131,0,0,1,4,133,0,0,1,96,131,0,0,1,112,131,0,0,1,176,1,0,1,3,131,0,0,1,1,133,0,0,1,184,135,0,0,1,200,1,0,1,3,1,0,1,1,1,0,1,1,133,0,0,1,184,132,0,0,1,95,1,112,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,4,198,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,112,1,115,1,95,1,115,1,49,1,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,1,171,135,0,0,1,1,139,0,0,1,20,1,1,1,252,1,0,1,16,147,0,0,1,64,131,0,0,1,192,1,16,1,0,1,2,132,0,0,1,4,134,0,0,1,8,1,33,1,0,1,1,1,0,1,1,131,0,0,1,1,1,0,1,0,1,48,1,80,176,0,0,1,61,1,225,1,71,1,174,1,62,1,153,1,153,1,154,1,63,1,23,1,10,1,61,1,63,1,128,131,0,0,1,5,1,32,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,96,1,4,1,80,1,10,1,18,1,0,1,34,131,0,0,1,16,1,24,1,32,1,1,1,31,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,16,1,8,1,16,1,1,1,31,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,200,1,2,131,0,0,1,190,1,192,1,0,1,176,1,1,1,255,1,0,1,200,1,1,131,0,0,1,190,1,192,1,0,1,176,1,2,1,255,1,0,1,200,1,15,1,0,1,2,1,4,1,108,1,0,1,0,1,224,1,0,1,2,1,0,1,200,1,15,1,0,1,1,1,4,1,177,1,0,1,0,1,224,1,0,1,1,1,0,1,200,1,15,1,0,1,1,1,0,1,148,1,108,1,177,1,171,1,1,1,2,1,0,1,200,1,15,131,0,0,1,148,1,108,1,108,1,171,1,2,1,3,1,0,1,200,1,15,1,0,1,2,1,0,1,248,1,108,1,0,1,161,1,0,1,1,1,0,1,201,1,15,131,0,0,1,248,1,108,1,0,1,161,1,1,1,0,1,0,1,200,1,15,1,0,1,0,1,4,1,0,1,27,1,0,1,160,1,0,1,255,1,0,1,200,1,15,134,0,0,1,225,1,2,1,0,1,0,1,200,1,15,1,128,1,0,1,0,1,248,1,108,1,0,1,171,1,1,149,0,0,1,1,132,255,0,138,0,0,1,16,1,200,1,16,1,42,1,17,1,1,1,0,1,0,1,14,1,216,1,0,1,0,1,1,1,240,135,0,0,1,36,1,0,1,0,1,14,1,112,1,0,1,0,1,14,1,152,138,0,0,1,14,1,72,131,0,0,1,28,1,0,1,0,1,14,1,59,1,255,1,254,1,3,132,0,0,1,2,131,0,0,1,28,134,0,0,1,14,1,52,131,0,0,1,68,1,0,1,2,131,0,0,1,4,133,0,0,1,76,131,0,0,1,92,131,0,0,1,156,1,0,1,2,1,0,1,4,1,0,1,216,133,0,0,1,164,131,0,0,1,180,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,4,198,0,0,1,95,1,118,1,115,1,98,1,95,1,99,1,0,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,216,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,156,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,1,1,176,1,0,1,1,1,0,1,7,138,0,0,1,8,1,33,131,0,0,1,1,131,0,0,1,4,131,0,0,1,1,1,0,1,0,1,2,1,144,1,0,1,16,1,0,1,5,1,0,1,0,1,80,1,6,1,0,1,0,1,16,1,7,1,0,1,32,1,32,1,8,1,0,1,0,1,48,1,80,1,0,1,0,1,16,1,34,176,0,0,1,64,1,64,142,0,0,1,240,1,85,1,64,1,5,1,0,1,0,1,18,1,0,1,194,133,0,0,1,96,1,9,1,96,1,15,1,18,1,0,1,18,133,0,0,1,96,1,21,1,96,1,27,1,18,1,0,1,18,133,0,0,1,16,1,33,1,0,1,0,1,18,1,0,1,196,133,0,0,1,16,1,34,1,0,1,0,1,34,133,0,0,1,5,1,248,1,64,131,0,0,1,6,1,136,132,0,0,1,5,1,248,132,0,0,1,14,1,71,132,0,0,1,5,1,248,1,32,131,0,0,1,2,1,208,132,0,0,1,5,1,248,1,16,131,0,0,1,6,1,136,132,0,0,1,200,1,15,1,0,1,7,1,0,1,0,1,108,1,0,1,161,1,1,1,255,1,0,1,92,1,8,1,0,1,1,1,0,131,27,0,1,161,1,4,1,2,1,7,1,200,1,15,1,0,1,3,1,160,1,198,1,136,1,0,1,161,1,2,1,4,1,0,1,200,1,15,1,0,1,6,1,160,1,198,1,136,1,0,1,161,1,2,1,5,1,0,1,92,1,15,1,0,1,5,1,160,1,198,1,136,1,198,1,161,1,2,1,6,1,7,1,200,1,15,1,0,1,5,1,160,1,177,1,136,1,0,1,171,1,2,1,6,1,5,1,200,1,15,1,0,1,6,1,160,1,177,1,136,1,0,1,171,1,2,1,5,1,6,1,200,1,15,1,0,1,3,1,160,1,177,1,136,1,0,1,171,1,2,1,4,1,3,1,92,1,2,1,0,1,2,1,0,1,27,1,27,1,177,1,161,1,4,1,0,1,7,1,200,1,15,1,0,1,3,1,160,1,27,1,52,1,148,1,171,1,2,1,4,1,3,1,200,1,15,1,0,1,6,1,160,1,27,1,52,1,148,1,171,1,2,1,5,1,6,1,200,1,15,1,0,1,5,1,160,1,27,1,52,1,148,1,171,1,2,1,6,1,5,1,92,1,8,1,0,1,2,1,0,1,27,1,27,1,108,1,161,1,4,1,1,1,7,1,200,1,15,1,0,1,5,1,160,1,108,1,208,1,148,1,171,1,2,1,6,1,5,1,200,1,15,1,0,1,6,1,160,1,108,1,208,1,148,1,171,1,2,1,5,1,6,1,200,1,15,1,0,1,3,1,160,1,108,1,208,1,148,1,171,1,2,1,4,1,3,1,200,1,1,1,0,1,3,1,0,1,170,1,167,1,0,1,239,1,3,1,4,1,0,1,200,1,2,1,0,1,3,1,0,1,170,1,167,1,0,1,239,1,6,1,4,1,0,1,200,1,4,1,0,1,3,1,0,1,170,1,167,1,0,1,239,1,5,1,4,1,0,1,200,1,1,1,0,1,1,1,0,1,190,1,190,1,0,1,176,1,3,1,3,1,0,1,200,1,4,1,0,1,1,1,0,1,190,1,190,1,0,1,176,1,3,1,2,1,0,1,20,1,17,1,0,1,2,1,0,1,190,1,190,1,27,1,176,1,3,1,0,1,4,1,168,1,36,1,1,1,2,1,0,1,190,1,190,1,0,1,144,1,3,1,1,1,3,1,200,1,3,1,128,1,62,1,0,1,196,1,25,1,0,1,224,1,2,1,2,1,0,1,200,1,12,1,128,1,62,1,0,1,70,1,155,1,0,1,224,1,1,1,1,1,0,1,200,1,3,1,128,1,0,1,0,1,197,1,197,1,0,1,226,151,0,0,132,255,0,131,0,0,1,1,134,0,0,1,2,1,88,1,16,1,42,1,17,131,0,0,1,1,1,88,1,0,1,0,1,1,136,0,0,1,36,1,0,1,0,1,1,1,12,1,0,1,0,1,1,1,52,139,0,0,1,228,131,0,0,1,28,131,0,0,1,214,1,255,1,255,1,3,132,0,0,1,3,131,0,0,1,28,135,0,0,1,207,131,0,0,1,88,1,0,1,2,131,0,0,1,4,133,0,0,1,96,131,0,0,1,112,131,0,0,1,176,1,0,1,3,131,0,0,1,1,133,0,0,1,184,135,0,0,1,200,1,0,1,3,1,0,1,1,1,0,1,1,133,0,0,1,184,132,0,0,1,95,1,112,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,4,198,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,112,1,115,1,95,1,115,1,49,1,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,1,171,135,0,0,1,1,139,0,0,1,20,1,1,1,252,1,0,1,16,147,0,0,1,64,131,0,0,1,192,1,16,1,0,1,2,132,0,0,1,4,134,0,0,1,8,1,33,1,0,1,1,1,0,1,1,131,0,0,1,1,1,0,1,0,1,48,1,80,176,0,0,1,61,1,225,1,71,1,174,1,62,1,153,1,153,1,154,1,63,1,23,1,10,1,61,1,63,1,128,131,0,0,1,5,1,32,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,96,1,4,1,80,1,10,1,18,1,0,1,34,131,0,0,1,16,1,24,1,32,1,1,1,31,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,16,1,8,1,16,1,1,1,31,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,200,1,2,131,0,0,1,190,1,192,1,0,1,176,1,1,1,255,1,0,1,200,1,1,131,0,0,1,190,1,192,1,0,1,176,1,2,1,255,1,0,1,200,1,15,1,0,1,2,1,4,1,108,1,0,1,0,1,224,1,0,1,2,1,0,1,200,1,15,1,0,1,1,1,4,1,177,1,0,1,0,1,224,1,0,1,1,1,0,1,200,1,15,1,0,1,1,1,0,1,148,1,108,1,177,1,171,1,1,1,2,1,0,1,200,1,15,131,0,0,1,148,1,108,1,108,1,171,1,2,1,3,1,0,1,200,1,15,1,0,1,2,1,0,1,248,1,108,1,0,1,161,1,0,1,1,1,0,1,201,1,15,131,0,0,1,248,1,108,1,0,1,161,1,1,1,0,1,0,1,200,1,15,1,0,1,0,1,4,1,0,1,27,1,0,1,160,1,0,1,255,1,0,1,200,1,15,134,0,0,1,225,1,2,1,0,1,0,1,200,1,15,1,128,1,0,1,0,1,248,1,108,1,0,1,171,1,1,150,0,0,132,255,0,138,0,0,1,1,1,128,1,16,1,42,1,17,1,1,131,0,0,1,252,131,0,0,1,132,135,0,0,1,36,135,0,0,1,196,139,0,0,1,156,131,0,0,1,28,131,0,0,1,143,1,255,1,254,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,136,131,0,0,1,48,1,0,1,2,131,0,0,1,4,133,0,0,1,56,131,0,0,1,72,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,4,198,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,132,1,0,1,1,1,0,1,1,138,0,0,1,8,1,33,131,0,0,1,1,131,0,0,1,2,131,0,0,1,1,1,0,1,0,1,2,1,144,1,0,1,16,1,0,1,3,1,0,1,48,1,80,1,4,1,0,1,0,1,48,1,80,1,0,1,0,1,16,1,9,1,48,1,5,1,32,1,3,1,0,1,0,1,18,1,0,1,194,133,0,0,1,64,1,5,1,0,1,0,1,18,1,0,1,196,133,0,0,1,16,1,9,1,0,1,0,1,34,133,0,0,1,5,1,248,1,16,131,0,0,1,6,1,136,132,0,0,1,5,1,248,132,0,0,1,15,1,200,132,0,0,1,200,1,1,1,128,1,62,1,0,1,167,1,167,1,0,1,175,1,1,1,0,1,0,1,200,1,2,1,128,1,62,1,0,1,167,1,167,1,0,1,175,1,1,1,1,1,0,1,200,1,4,1,128,1,62,1,0,1,167,1,167,1,0,1,175,1,1,1,2,1,0,1,200,1,8,1,128,1,62,1,0,1,167,1,167,1,0,1,175,1,1,1,3,1,0,1,200,1,3,1,128,1,0,1,0,1,176,1,176,1,0,1,226,142,0,0,1,0};
			}
		}
#else
		/// <summary>Static Length+DeflateStream compressed shader byte code (Windows)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {160,43,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,210,95,99,248,249,53,127,236,255,254,191,254,167,223,84,126,255,181,241,55,253,255,15,208,239,126,29,253,255,175,169,127,127,200,243,235,209,255,127,255,203,230,247,159,254,26,174,159,127,74,191,251,198,251,89,133,253,172,126,19,249,238,223,250,53,190,185,126,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,237,158,95,255,215,224,120,112,66,129,218,31,100,226,180,127,75,227,180,111,50,30,212,126,10,4,132,191,209,175,33,112,255,15,237,39,104,67,49,99,179,227,218,164,26,19,247,218,236,10,94,191,153,182,243,159,95,139,254,143,215,186,159,155,113,96,156,191,89,228,123,252,29,123,239,199,232,255,79,202,124,57,43,150,23,0,242,235,14,188,143,152,55,246,254,111,72,255,63,91,54,109,182,156,2,2,143,225,245,60,155,229,181,188,243,107,106,27,124,206,99,246,222,45,233,255,127,148,247,247,191,70,255,255,159,188,191,127,134,104,248,103,121,116,252,207,232,247,255,205,251,251,55,32,132,126,39,143,134,255,153,151,99,248,125,245,119,208,235,79,209,239,119,232,179,17,253,255,79,213,191,191,77,191,63,165,255,255,105,145,182,115,250,108,230,181,253,131,232,247,159,161,255,255,107,145,182,127,21,125,246,151,121,109,255,33,250,253,239,211,118,191,158,252,224,246,255,55,61,102,158,126,39,124,240,107,255,223,255,247,255,245,127,127,254,107,156,188,57,126,242,59,209,159,255,229,175,33,159,1,255,223,137,91,253,26,233,127,68,255,252,222,250,254,175,67,255,254,1,244,115,69,255,255,155,126,13,147,123,248,181,126,141,191,75,97,254,83,252,217,175,73,255,253,122,191,198,191,164,159,73,158,226,175,253,107,127,77,254,230,215,233,205,223,215,125,148,151,255,218,95,135,184,249,215,228,255,188,207,119,251,159,211,199,247,126,255,157,95,227,139,98,90,87,77,117,222,166,91,175,238,164,223,126,254,250,121,42,220,146,158,84,139,85,81,210,47,15,199,123,159,142,31,222,223,27,239,29,236,239,255,26,63,65,44,249,235,252,26,191,233,95,244,231,252,217,127,246,209,103,201,111,251,123,252,13,159,255,199,159,209,108,252,30,191,11,145,132,120,245,15,162,17,255,73,191,139,144,231,79,34,134,248,139,204,239,191,38,253,254,132,73,244,155,82,155,255,140,254,254,207,254,162,223,128,254,38,140,240,247,31,244,235,252,26,255,217,95,244,91,16,73,127,45,250,158,26,253,69,248,140,112,253,131,126,93,125,231,215,146,191,25,198,175,169,48,126,13,133,241,107,17,140,95,211,131,241,107,115,251,95,227,47,194,103,191,150,194,248,53,25,238,127,70,239,225,243,95,227,215,250,181,126,141,223,229,15,210,239,127,109,244,73,240,255,224,95,231,215,248,191,255,162,95,7,211,250,27,48,124,237,243,63,251,131,254,239,255,91,104,102,120,70,73,248,107,252,107,32,230,175,253,127,17,207,236,90,158,249,19,127,13,249,12,95,25,158,249,163,232,159,29,126,95,230,251,128,254,255,237,95,195,234,168,111,156,23,46,191,230,220,202,92,253,70,127,16,209,91,231,240,55,166,241,155,223,127,19,162,135,249,29,180,52,191,255,26,68,119,249,253,215,101,90,187,207,169,221,127,100,62,167,49,254,71,191,166,190,75,243,244,39,153,57,249,53,126,141,175,64,227,63,9,116,151,191,241,30,241,7,207,167,249,236,175,193,92,216,207,132,135,254,111,204,39,127,246,99,204,35,191,230,127,100,248,72,254,254,181,248,239,95,215,254,253,235,240,223,191,158,253,251,55,224,191,127,125,250,27,120,1,63,106,251,39,153,217,197,252,249,250,97,11,35,250,181,34,250,225,215,250,255,173,126,216,251,58,60,180,73,63,252,26,162,31,254,166,91,232,135,191,9,250,193,147,245,191,201,201,250,111,240,7,153,121,54,178,110,244,197,175,69,60,97,244,5,100,29,250,66,222,249,134,245,131,224,100,245,3,243,181,234,140,46,255,40,57,127,141,159,249,205,232,159,95,11,186,226,207,251,181,13,255,28,254,38,242,25,8,96,248,103,159,62,123,250,107,56,254,121,78,63,127,95,250,255,159,199,159,253,58,156,207,254,203,232,255,127,219,175,97,114,235,63,11,188,34,62,154,133,251,111,221,248,198,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,231,250,249,81,255,63,122,126,244,252,232,249,209,243,255,175,231,242,3,98,242,127,143,98,242,95,227,215,248,61,127,79,31,158,151,167,177,249,27,147,239,65,238,205,228,123,16,35,35,223,227,197,214,127,210,191,71,113,242,88,242,57,127,147,228,89,36,46,254,181,126,141,175,254,164,95,39,253,207,168,175,175,254,166,95,135,211,215,148,239,225,191,127,141,191,233,215,66,204,47,57,28,239,243,191,134,62,255,107,34,159,255,223,244,249,255,205,159,107,126,231,15,226,156,159,246,245,107,106,95,191,174,215,23,62,251,117,189,190,52,95,228,125,46,125,245,63,151,190,92,46,233,215,226,190,126,205,78,95,191,94,167,175,95,111,160,175,95,111,160,175,95,47,218,215,175,99,251,146,252,216,111,64,127,255,223,127,146,142,249,31,194,120,127,13,151,211,226,191,127,77,151,211,226,191,127,45,151,211,226,191,127,109,205,105,253,26,156,115,115,57,45,60,63,202,105,125,61,249,249,81,78,75,30,63,167,181,15,194,254,90,145,252,247,175,53,148,255,22,254,57,248,53,108,254,251,103,133,47,190,174,158,28,210,135,158,44,254,73,29,89,252,147,58,178,248,39,117,100,241,79,138,201,226,255,19,0,0,255,255};
			}
		}
#endif
		/// <summary>Set a shader attribute of type 'Single' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, float value)
		{
			if ((BloomCombine.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == BloomCombine.cid0))
			{
				this.BloomIntensity = value;
				return true;
			}
			if ((id == BloomCombine.cid1))
			{
				this.BloomSaturation = value;
				return true;
			}
			if ((id == BloomCombine.cid2))
			{
				this.OriginalIntensity = value;
				return true;
			}
			if ((id == BloomCombine.cid3))
			{
				this.OriginalSaturation = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((BloomCombine.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == BloomCombine.sid0))
			{
				this.BloomSampler = value;
				return true;
			}
			if ((id == BloomCombine.sid1))
			{
				this.ColorMapSampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture value)
		{
			if ((BloomCombine.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == BloomCombine.tid0))
			{
				this.Bloom = value;
				return true;
			}
			if ((id == BloomCombine.tid1))
			{
				this.ColorMap = value;
				return true;
			}
			return false;
		}
	}
}
