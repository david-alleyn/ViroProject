// XenFX
// Assembly = Xen.Graphics.ShaderSystem.CustomTool, Version=7.0.1.1, Culture=neutral, PublicKeyToken=e706afd07878dfca
// SourceFile = VelocityLines.fx
// Namespace = Xen.Ex.Graphics.Display

#if XBOX360
namespace Xen.Ex.Graphics.Display
{
	
	/// <summary><para>Technique 'DrawVelocityParticles_LinesGpuTex' generated from file 'VelocityLines.fx'</para><para>Vertex Shader: approximately 26 instruction slots used (4 texture, 22 arithmetic), 6 registers</para><para>Pixel Shader: approximately 3 instruction slots used, 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityParticles_LinesGpuTex : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityParticles_LinesGpuTex' shader</summary>
		public DrawVelocityParticles_LinesGpuTex()
		{
			this.sc0 = -1;
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawVelocityParticles_LinesGpuTex.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityParticles_LinesGpuTex.cid0 = state.GetNameUniqueID("textureSizeOffset");
			DrawVelocityParticles_LinesGpuTex.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityParticles_LinesGpuTex.sid0 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityParticles_LinesGpuTex.sid1 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityParticles_LinesGpuTex.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityParticles_LinesGpuTex.tid2 = state.GetNameUniqueID("VelocityTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityParticles_LinesGpuTex.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc0));
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawVelocityParticles_LinesGpuTex.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityParticles_LinesGpuTex.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityParticles_LinesGpuTex.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityParticles_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityParticles_LinesGpuTex.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityParticles_LinesGpuTex.fx, DrawVelocityParticles_LinesGpuTex.fxb, 30, 4);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return (this.vreg_change | this.vtc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityParticles_LinesGpuTex.vin[i]));
			index = DrawVelocityParticles_LinesGpuTex.vin[(i + 1)];
		}
		/// <summary>Static graphics ID</summary>
		private static int gd;
		/// <summary>Static effect container instance</summary>
		private static Xen.Graphics.ShaderSystem.ShaderEffect fx;
		/// <summary>Static RLE compressed shader byte code (Xbox360)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {4,188,240,11,207,131,0,1,16,136,0,8,254,255,9,1,0,0,1,68,135,0,1,10,131,0,1,4,131,0,1,28,143,0,17,17,95,95,117,110,117,115,101,100,95,115,97,109,112,108,101,114,135,0,1,3,131,0,1,1,131,0,1,176,135,0,1,6,131,0,1,4,131,0,1,1,227,0,0,1,6,1,95,1,118,1,115,1,95,1,99,134,0,0,1,12,131,0,0,1,4,131,0,0,1,212,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,48,133,0,0,1,12,131,0,0,1,4,131,0,0,1,248,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,49,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,4,131,0,0,1,1,131,0,0,1,6,131,0,0,1,3,131,0,0,1,4,131,0,0,1,24,139,0,0,1,52,131,0,0,1,80,139,0,0,1,188,131,0,0,1,208,139,0,0,1,224,131,0,0,1,244,138,0,0,1,1,1,56,135,0,0,1,1,1,0,1,0,1,1,1,52,135,0,0,1,2,131,0,0,1,92,134,0,0,1,1,1,8,1,0,1,0,1,1,1,4,131,0,0,1,93,134,0,0,1,1,1,32,1,0,1,0,1,1,1,28,135,0,0,1,2,136,0,0,132,255,0,131,0,0,1,1,135,0,0,1,184,1,16,1,42,1,17,132,0,0,1,124,131,0,0,1,60,135,0,0,1,36,135,0,0,1,88,139,0,0,1,48,131,0,0,1,28,131,0,0,1,35,1,255,1,255,1,3,144,0,0,1,28,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,60,1,16,1,0,1,1,132,0,0,1,4,134,0,0,1,16,1,33,1,0,1,1,1,0,1,1,131,0,0,1,1,1,0,1,0,1,240,1,81,132,0,0,1,48,1,1,1,196,1,0,1,34,131,0,0,1,22,1,128,1,1,132,0,0,1,27,1,226,131,0,0,1,200,1,7,1,0,1,1,1,0,1,192,1,27,1,0,1,225,1,0,1,1,1,0,1,200,1,15,1,128,133,0,0,1,226,1,1,1,1,149,0,0,132,255,0,138,0,0,1,2,1,232,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,136,1,0,1,0,1,1,1,96,135,0,0,1,36,1,0,1,0,1,1,1,44,1,0,1,0,1,1,1,84,138,0,0,1,1,1,4,131,0,0,1,28,131,0,0,1,246,1,255,1,254,1,3,132,0,0,1,3,131,0,0,1,28,135,0,0,1,239,131,0,0,1,88,1,0,1,2,131,0,0,1,6,133,0,0,1,96,131,0,0,1,112,131,0,0,1,208,1,0,1,3,131,0,0,1,1,133,0,0,1,216,135,0,0,1,232,1,0,1,3,1,0,1,1,1,0,1,1,133,0,0,1,216,132,0,0,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,6,229,0,0,1,0,1,95,1,118,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,118,1,115,1,95,1,115,1,49,1,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,1,171,135,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,1,1,32,1,0,1,1,1,0,1,2,138,0,0,1,16,1,33,131,0,0,1,1,131,0,0,1,1,131,0,0,1,1,1,0,1,0,1,2,1,144,131,0,0,1,4,1,0,1,0,1,240,1,81,1,0,1,0,1,16,1,22,176,0,0,1,63,1,128,1,0,1,0,1,63,139,0,0,1,16,1,9,1,96,1,4,1,64,1,10,1,18,1,0,1,18,1,0,1,0,1,80,132,0,0,1,96,1,14,1,194,1,0,1,18,133,0,0,1,32,1,20,1,0,1,0,1,18,1,0,1,196,133,0,0,1,16,1,22,1,0,1,0,1,34,133,0,0,1,5,1,248,132,0,0,1,14,1,120,132,0,0,1,176,1,35,1,0,1,1,1,0,1,176,1,177,1,192,1,1,1,4,1,255,1,4,1,168,1,128,133,0,0,1,65,1,194,1,0,1,0,1,4,1,52,1,18,131,0,0,1,27,1,0,1,27,1,232,1,128,1,0,1,0,1,200,1,8,1,0,1,1,1,1,1,27,1,177,1,177,1,237,131,0,0,1,168,1,64,1,1,132,0,0,1,128,1,194,1,0,1,0,1,4,1,200,1,3,131,0,0,1,196,1,179,1,0,1,224,1,1,1,1,1,0,1,184,1,128,133,0,0,1,65,1,194,1,0,1,0,1,255,1,49,1,8,1,16,1,1,1,15,1,31,1,254,1,200,1,0,1,0,1,64,1,0,1,49,1,24,1,32,1,1,1,15,1,31,1,254,1,200,1,0,1,0,1,64,1,0,1,200,1,6,131,0,0,1,198,1,188,1,0,1,225,1,0,1,2,1,0,1,200,1,1,131,0,0,1,198,1,177,1,108,1,139,1,2,2,5,5,2,200,3,131,0,3,197,108,0,1,225,131,0,2,200,3,131,0,4,176,198,176,235,5,0,1,1,200,1,6,128,62,0,109,109,27,1,145,131,0,7,200,2,128,62,0,109,109,8,27,145,0,1,1,200,4,128,9,62,0,109,109,27,145,0,2,2,10,200,8,128,62,0,109,109,27,145,0,5,3,3,36,254,192,132,0,5,108,226,0,0,128,139,0,1,0};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'textureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 textureSizeOffset'</summary><param name="value"/>
		public void SetTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[4] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 textureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 TextureSizeOffset
		{
			set
			{
				this.SetTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[5] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float2 velocityScale'</summary>
		public Microsoft.Xna.Framework.Vector2 VelocityScale
		{
			set
			{
				this.SetVelocityScale(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc0;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D PositionSampler'</summary>
		public Xen.Graphics.TextureSamplerState PositionSampler
		{
			get
			{
				return this.vts[0];
			}
			set
			{
				if ((value != this.vts[0]))
				{
					this.vts[0] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D VelocitySampler'</summary>
		public Xen.Graphics.TextureSamplerState VelocitySampler
		{
			get
			{
				return this.vts[1];
			}
			set
			{
				if ((value != this.vts[1]))
				{
					this.vts[1] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D PositionTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D PositionTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[0]));
			}
			set
			{
				if ((value != this.vtx[0]))
				{
					this.vtc = true;
					this.vtx[0] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D VelocityTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D VelocityTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[1]));
			}
			set
			{
				if ((value != this.vtx[1]))
				{
					this.vtc = true;
					this.vtx[1] = value;
				}
			}
		}
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid1;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[6];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[2];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[2];
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityParticles_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityParticles_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex.cid0))
			{
				this.SetTextureSizeOffset(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityParticles_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex.sid0))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticles_LinesGpuTex.sid1))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityParticles_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticles_LinesGpuTex.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityParticlesColour_LinesGpuTex' generated from file 'VelocityLines.fx'</para><para>Vertex Shader: approximately 28 instruction slots used (6 texture, 22 arithmetic), 6 registers</para><para>Pixel Shader: approximately 3 instruction slots used, 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityParticlesColour_LinesGpuTex : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityParticlesColour_LinesGpuTex' shader</summary>
		public DrawVelocityParticlesColour_LinesGpuTex()
		{
			this.sc0 = -1;
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[2] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawVelocityParticlesColour_LinesGpuTex.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityParticlesColour_LinesGpuTex.cid0 = state.GetNameUniqueID("textureSizeOffset");
			DrawVelocityParticlesColour_LinesGpuTex.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityParticlesColour_LinesGpuTex.sid0 = state.GetNameUniqueID("ColourSampler");
			DrawVelocityParticlesColour_LinesGpuTex.sid1 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityParticlesColour_LinesGpuTex.sid2 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityParticlesColour_LinesGpuTex.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityParticlesColour_LinesGpuTex.tid1 = state.GetNameUniqueID("ColourTexture");
			DrawVelocityParticlesColour_LinesGpuTex.tid2 = state.GetNameUniqueID("VelocityTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityParticlesColour_LinesGpuTex.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc0));
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawVelocityParticlesColour_LinesGpuTex.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityParticlesColour_LinesGpuTex.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityParticlesColour_LinesGpuTex.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityParticlesColour_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityParticlesColour_LinesGpuTex.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityParticlesColour_LinesGpuTex.fx, DrawVelocityParticlesColour_LinesGpuTex.fxb, 32, 4);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return (this.vreg_change | this.vtc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityParticlesColour_LinesGpuTex.vin[i]));
			index = DrawVelocityParticlesColour_LinesGpuTex.vin[(i + 1)];
		}
		/// <summary>Static graphics ID</summary>
		private static int gd;
		/// <summary>Static effect container instance</summary>
		private static Xen.Graphics.ShaderSystem.ShaderEffect fx;
		/// <summary>Static RLE compressed shader byte code (Xbox360)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {4,188,240,11,207,131,0,1,16,136,0,8,254,255,9,1,0,0,1,104,135,0,1,10,131,0,1,4,131,0,1,28,143,0,17,17,95,95,117,110,117,115,101,100,95,115,97,109,112,108,101,114,135,0,1,3,131,0,1,1,131,0,1,176,135,0,1,6,131,0,1,4,131,0,1,1,227,0,0,1,6,1,95,1,118,1,115,1,95,1,99,134,0,0,1,12,131,0,0,1,4,131,0,0,1,212,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,48,133,0,0,1,12,131,0,0,1,4,131,0,0,1,248,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,49,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,28,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,50,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,5,131,0,0,1,1,131,0,0,1,7,131,0,0,1,3,131,0,0,1,4,131,0,0,1,24,139,0,0,1,52,131,0,0,1,80,139,0,0,1,188,131,0,0,1,208,139,0,0,1,224,131,0,0,1,244,138,0,0,1,1,1,4,1,0,1,0,1,1,1,24,138,0,0,1,1,1,92,135,0,0,1,1,1,0,1,0,1,1,1,88,135,0,0,1,2,131,0,0,1,92,134,0,0,1,1,1,44,1,0,1,0,1,1,1,40,131,0,0,1,93,134,0,0,1,1,1,68,1,0,1,0,1,1,1,64,135,0,0,1,2,136,0,0,132,255,0,131,0,0,1,1,135,0,0,1,184,1,16,1,42,1,17,132,0,0,1,124,131,0,0,1,60,135,0,0,1,36,135,0,0,1,88,139,0,0,1,48,131,0,0,1,28,131,0,0,1,35,1,255,1,255,1,3,144,0,0,1,28,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,60,1,16,1,0,1,1,132,0,0,1,4,134,0,0,1,16,1,33,1,0,1,1,1,0,1,1,131,0,0,1,1,1,0,1,0,1,240,1,81,132,0,0,1,48,1,1,1,196,1,0,1,34,131,0,0,1,22,1,128,1,1,132,0,0,1,27,1,226,131,0,0,1,200,1,7,1,0,1,1,1,0,1,192,1,27,1,0,1,225,1,0,1,1,1,0,1,200,1,15,1,128,133,0,0,1,226,1,1,1,1,149,0,0,132,255,0,138,0,0,1,3,1,16,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,164,1,0,1,0,1,1,1,108,135,0,0,1,36,1,0,1,0,1,1,1,72,1,0,1,0,1,1,1,112,138,0,0,1,1,1,32,131,0,0,1,28,1,0,1,0,1,1,1,17,1,255,1,254,1,3,132,0,0,1,4,131,0,0,1,28,134,0,0,1,1,1,10,131,0,0,1,108,1,0,1,2,131,0,0,1,6,133,0,0,1,116,131,0,0,1,132,131,0,0,1,228,1,0,1,3,131,0,0,1,1,133,0,0,1,236,135,0,0,1,252,1,0,1,3,1,0,1,1,1,0,1,1,133,0,0,1,236,134,0,0,1,1,1,3,1,0,1,3,1,0,1,2,1,0,1,1,133,0,0,1,236,132,0,0,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,6,229,0,0,1,0,1,95,1,118,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,118,1,115,1,95,1,115,1,49,1,0,1,95,1,118,1,115,1,95,1,115,1,50,1,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,131,171,0,135,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,1,1,44,1,0,1,1,1,0,1,3,138,0,0,1,16,1,33,131,0,0,1,1,131,0,0,1,1,131,0,0,1,1,1,0,1,0,1,2,1,144,131,0,0,1,4,1,0,1,0,1,240,1,81,1,0,1,0,1,16,1,23,176,0,0,1,63,1,128,1,0,1,0,1,63,139,0,0,1,16,1,9,1,96,1,4,1,80,1,10,1,18,1,0,1,18,1,0,1,1,1,80,132,0,0,1,96,1,15,1,194,1,0,1,18,133,0,0,1,32,1,21,1,0,1,0,1,18,1,0,1,196,133,0,0,1,16,1,23,1,0,1,0,1,34,133,0,0,1,5,1,248,132,0,0,1,14,1,120,132,0,0,1,176,1,35,1,0,1,1,1,0,1,176,1,177,1,192,1,1,1,4,1,255,1,4,1,168,1,128,133,0,0,1,65,1,194,1,0,1,0,1,4,1,52,1,18,131,0,0,1,27,1,0,1,27,1,232,1,128,1,0,1,0,1,200,1,8,1,0,1,1,1,1,1,27,1,177,1,177,1,237,131,0,0,1,168,1,64,1,1,132,0,0,1,128,1,194,1,0,1,0,1,4,1,200,1,3,131,0,0,1,196,1,179,1,0,1,224,1,1,1,1,1,0,1,184,1,128,133,0,0,1,65,1,194,1,0,1,0,1,255,1,49,1,24,1,16,1,1,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,49,1,8,1,32,1,1,1,15,1,31,1,254,1,200,1,0,1,0,1,64,1,0,1,49,1,40,1,48,1,1,2,15,31,3,254,200,0,4,0,64,0,200,1,6,131,0,5,198,188,0,225,0,4,3,0,200,1,131,0,6,198,177,108,139,3,5,3,5,200,3,131,0,4,197,108,0,225,131,0,2,200,3,131,0,7,176,198,176,235,0,2,2,8,200,1,128,62,0,109,109,27,1,145,131,0,9,200,2,128,62,0,109,109,27,145,10,0,1,1,200,4,128,62,0,109,109,11,27,145,0,2,2,200,8,128,62,0,109,9,109,27,145,0,3,3,200,15,128,133,0,3,226,1,1,140,0,1,0};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'textureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 textureSizeOffset'</summary><param name="value"/>
		public void SetTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[4] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 textureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 TextureSizeOffset
		{
			set
			{
				this.SetTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[5] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float2 velocityScale'</summary>
		public Microsoft.Xna.Framework.Vector2 VelocityScale
		{
			set
			{
				this.SetVelocityScale(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc0;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D ColourSampler'</summary>
		public Xen.Graphics.TextureSamplerState ColourSampler
		{
			get
			{
				return this.vts[1];
			}
			set
			{
				if ((value != this.vts[1]))
				{
					this.vts[1] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D PositionSampler'</summary>
		public Xen.Graphics.TextureSamplerState PositionSampler
		{
			get
			{
				return this.vts[0];
			}
			set
			{
				if ((value != this.vts[0]))
				{
					this.vts[0] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D VelocitySampler'</summary>
		public Xen.Graphics.TextureSamplerState VelocitySampler
		{
			get
			{
				return this.vts[2];
			}
			set
			{
				if ((value != this.vts[2]))
				{
					this.vts[2] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D PositionTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D PositionTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[0]));
			}
			set
			{
				if ((value != this.vtx[0]))
				{
					this.vtc = true;
					this.vtx[0] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D ColourTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D ColourTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[1]));
			}
			set
			{
				if ((value != this.vtx[1]))
				{
					this.vtc = true;
					this.vtx[1] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D VelocityTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D VelocityTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[2]));
			}
			set
			{
				if ((value != this.vtx[2]))
				{
					this.vtc = true;
					this.vtx[2] = value;
				}
			}
		}
		/// <summary>Name uid for sampler for 'Sampler2D ColourSampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid1;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid2;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D ColourTexture'</summary>
		static int tid1;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[6];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[3];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[3];
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.cid0))
			{
				this.SetTextureSizeOffset(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.sid0))
			{
				this.ColourSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.sid1))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.sid2))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.tid1))
			{
				this.ColourTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityParticles_LinesGpuTex_UserOffset' generated from file 'VelocityLines.fx'</para><para>Vertex Shader: approximately 29 instruction slots used (6 texture, 23 arithmetic), 6 registers</para><para>Pixel Shader: approximately 3 instruction slots used, 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityParticles_LinesGpuTex_UserOffset : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityParticles_LinesGpuTex_UserOffset' shader</summary>
		public DrawVelocityParticles_LinesGpuTex_UserOffset()
		{
			this.sc0 = -1;
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[2] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawVelocityParticles_LinesGpuTex_UserOffset.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityParticles_LinesGpuTex_UserOffset.cid0 = state.GetNameUniqueID("textureSizeOffset");
			DrawVelocityParticles_LinesGpuTex_UserOffset.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityParticles_LinesGpuTex_UserOffset.sid0 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityParticles_LinesGpuTex_UserOffset.sid1 = state.GetNameUniqueID("UserSampler");
			DrawVelocityParticles_LinesGpuTex_UserOffset.sid2 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityParticles_LinesGpuTex_UserOffset.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityParticles_LinesGpuTex_UserOffset.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawVelocityParticles_LinesGpuTex_UserOffset.tid3 = state.GetNameUniqueID("UserTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityParticles_LinesGpuTex_UserOffset.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc0));
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawVelocityParticles_LinesGpuTex_UserOffset.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityParticles_LinesGpuTex_UserOffset.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityParticles_LinesGpuTex_UserOffset.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityParticles_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityParticles_LinesGpuTex_UserOffset.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityParticles_LinesGpuTex_UserOffset.fx, DrawVelocityParticles_LinesGpuTex_UserOffset.fxb, 33, 4);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return (this.vreg_change | this.vtc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityParticles_LinesGpuTex_UserOffset.vin[i]));
			index = DrawVelocityParticles_LinesGpuTex_UserOffset.vin[(i + 1)];
		}
		/// <summary>Static graphics ID</summary>
		private static int gd;
		/// <summary>Static effect container instance</summary>
		private static Xen.Graphics.ShaderSystem.ShaderEffect fx;
		/// <summary>Static RLE compressed shader byte code (Xbox360)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {4,188,240,11,207,131,0,1,16,136,0,8,254,255,9,1,0,0,1,104,135,0,1,10,131,0,1,4,131,0,1,28,143,0,17,17,95,95,117,110,117,115,101,100,95,115,97,109,112,108,101,114,135,0,1,3,131,0,1,1,131,0,1,176,135,0,1,6,131,0,1,4,131,0,1,1,227,0,0,1,6,1,95,1,118,1,115,1,95,1,99,134,0,0,1,12,131,0,0,1,4,131,0,0,1,212,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,48,133,0,0,1,12,131,0,0,1,4,131,0,0,1,248,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,49,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,28,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,50,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,5,131,0,0,1,1,131,0,0,1,7,131,0,0,1,3,131,0,0,1,4,131,0,0,1,24,139,0,0,1,52,131,0,0,1,80,139,0,0,1,188,131,0,0,1,208,139,0,0,1,224,131,0,0,1,244,138,0,0,1,1,1,4,1,0,1,0,1,1,1,24,138,0,0,1,1,1,92,135,0,0,1,1,1,0,1,0,1,1,1,88,135,0,0,1,2,131,0,0,1,92,134,0,0,1,1,1,44,1,0,1,0,1,1,1,40,131,0,0,1,93,134,0,0,1,1,1,68,1,0,1,0,1,1,1,64,135,0,0,1,2,136,0,0,132,255,0,131,0,0,1,1,135,0,0,1,184,1,16,1,42,1,17,132,0,0,1,124,131,0,0,1,60,135,0,0,1,36,135,0,0,1,88,139,0,0,1,48,131,0,0,1,28,131,0,0,1,35,1,255,1,255,1,3,144,0,0,1,28,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,60,1,16,1,0,1,1,132,0,0,1,4,134,0,0,1,16,1,33,1,0,1,1,1,0,1,1,131,0,0,1,1,1,0,1,0,1,240,1,81,132,0,0,1,48,1,1,1,196,1,0,1,34,131,0,0,1,22,1,128,1,1,132,0,0,1,27,1,226,131,0,0,1,200,1,7,1,0,1,1,1,0,1,192,1,27,1,0,1,225,1,0,1,1,1,0,1,200,1,15,1,128,133,0,0,1,226,1,1,1,1,149,0,0,132,255,0,138,0,0,1,3,1,28,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,164,1,0,1,0,1,1,1,120,135,0,0,1,36,1,0,1,0,1,1,1,72,1,0,1,0,1,1,1,112,138,0,0,1,1,1,32,131,0,0,1,28,1,0,1,0,1,1,1,17,1,255,1,254,1,3,132,0,0,1,4,131,0,0,1,28,134,0,0,1,1,1,10,131,0,0,1,108,1,0,1,2,131,0,0,1,6,133,0,0,1,116,131,0,0,1,132,131,0,0,1,228,1,0,1,3,131,0,0,1,1,133,0,0,1,236,135,0,0,1,252,1,0,1,3,1,0,1,1,1,0,1,1,133,0,0,1,236,134,0,0,1,1,1,3,1,0,1,3,1,0,1,2,1,0,1,1,133,0,0,1,236,132,0,0,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,6,229,0,0,1,0,1,95,1,118,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,118,1,115,1,95,1,115,1,49,1,0,1,95,1,118,1,115,1,95,1,115,1,50,1,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,131,171,0,135,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,1,1,56,1,0,1,1,1,0,1,2,138,0,0,1,16,1,33,131,0,0,1,1,131,0,0,1,1,131,0,0,1,1,1,0,1,0,1,2,1,144,131,0,0,1,4,1,0,1,0,1,240,1,81,1,0,1,0,1,16,1,24,176,0,0,1,63,1,128,1,0,1,0,1,63,139,0,0,1,16,1,9,1,96,1,4,1,80,1,10,1,18,1,0,1,18,1,0,1,1,1,80,132,0,0,1,96,1,15,1,194,1,0,1,18,133,0,0,1,48,1,21,1,0,1,0,1,18,1,0,1,196,133,0,0,1,16,1,24,1,0,1,0,1,34,133,0,0,1,5,1,248,132,0,0,1,14,1,120,132,0,0,1,176,1,35,1,0,1,1,1,0,1,176,1,177,1,192,1,1,1,4,1,255,1,4,1,168,1,128,133,0,0,1,65,1,194,1,0,1,0,1,4,1,52,1,18,131,0,0,1,27,1,0,1,27,1,232,1,128,1,0,1,0,1,200,1,8,1,0,1,1,1,1,1,27,1,177,1,177,1,237,131,0,0,1,168,1,64,1,1,132,0,0,1,128,1,194,1,0,1,0,1,4,1,200,1,3,131,0,0,1,196,1,179,1,0,1,224,1,1,1,1,1,0,1,184,1,128,133,0,0,1,65,1,194,1,0,1,0,1,255,1,49,1,24,1,32,1,1,1,15,1,31,1,254,1,200,1,0,1,0,1,64,1,0,1,49,1,8,1,16,1,1,1,15,1,31,1,254,1,200,1,0,1,0,1,64,1,0,1,49,1,40,1,0,1,1,2,15,31,3,245,207,0,4,0,64,0,200,1,10,131,0,5,188,17,0,224,1,6,0,0,200,3,0,2,7,0,198,176,0,225,0,2,3,0,200,1,131,0,8,198,177,108,139,2,5,5,200,1,5,131,0,9,176,108,0,225,2,0,0,200,3,131,0,9,196,198,25,235,0,1,0,200,1,7,128,62,0,109,109,27,145,131,0,10,200,2,128,62,0,109,109,27,145,0,11,1,1,200,4,128,62,0,109,109,27,145,12,0,2,2,200,8,128,62,0,109,109,27,145,6,0,3,3,36,254,192,132,0,5,108,226,0,0,128,139,0,1,0};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'textureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 textureSizeOffset'</summary><param name="value"/>
		public void SetTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[4] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 textureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 TextureSizeOffset
		{
			set
			{
				this.SetTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[5] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float2 velocityScale'</summary>
		public Microsoft.Xna.Framework.Vector2 VelocityScale
		{
			set
			{
				this.SetVelocityScale(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc0;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D PositionSampler'</summary>
		public Xen.Graphics.TextureSamplerState PositionSampler
		{
			get
			{
				return this.vts[0];
			}
			set
			{
				if ((value != this.vts[0]))
				{
					this.vts[0] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D UserSampler'</summary>
		public Xen.Graphics.TextureSamplerState UserSampler
		{
			get
			{
				return this.vts[2];
			}
			set
			{
				if ((value != this.vts[2]))
				{
					this.vts[2] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D VelocitySampler'</summary>
		public Xen.Graphics.TextureSamplerState VelocitySampler
		{
			get
			{
				return this.vts[1];
			}
			set
			{
				if ((value != this.vts[1]))
				{
					this.vts[1] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D PositionTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D PositionTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[0]));
			}
			set
			{
				if ((value != this.vtx[0]))
				{
					this.vtc = true;
					this.vtx[0] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D VelocityTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D VelocityTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[1]));
			}
			set
			{
				if ((value != this.vtx[1]))
				{
					this.vtc = true;
					this.vtx[1] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D UserTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D UserTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[2]));
			}
			set
			{
				if ((value != this.vtx[2]))
				{
					this.vtc = true;
					this.vtx[2] = value;
				}
			}
		}
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D UserSampler'</summary>
		static int sid1;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid2;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Name uid for texture for 'Texture2D UserTexture'</summary>
		static int tid3;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[6];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[3];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[3];
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityParticles_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityParticles_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.cid0))
			{
				this.SetTextureSizeOffset(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityParticles_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.sid0))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.sid1))
			{
				this.UserSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.sid2))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityParticles_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.tid3))
			{
				this.UserTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityParticlesColour_LinesGpuTex_UserOffset' generated from file 'VelocityLines.fx'</para><para>Vertex Shader: approximately 31 instruction slots used (8 texture, 23 arithmetic), 6 registers</para><para>Pixel Shader: approximately 3 instruction slots used, 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityParticlesColour_LinesGpuTex_UserOffset : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityParticlesColour_LinesGpuTex_UserOffset' shader</summary>
		public DrawVelocityParticlesColour_LinesGpuTex_UserOffset()
		{
			this.sc0 = -1;
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[3] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[2] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.cid0 = state.GetNameUniqueID("textureSizeOffset");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid0 = state.GetNameUniqueID("ColourSampler");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid1 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid2 = state.GetNameUniqueID("UserSampler");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid3 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid1 = state.GetNameUniqueID("ColourTexture");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid3 = state.GetNameUniqueID("UserTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc0));
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawVelocityParticlesColour_LinesGpuTex_UserOffset.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityParticlesColour_LinesGpuTex_UserOffset.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityParticlesColour_LinesGpuTex_UserOffset.fx, DrawVelocityParticlesColour_LinesGpuTex_UserOffset.fxb, 35, 4);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return (this.vreg_change | this.vtc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityParticlesColour_LinesGpuTex_UserOffset.vin[i]));
			index = DrawVelocityParticlesColour_LinesGpuTex_UserOffset.vin[(i + 1)];
		}
		/// <summary>Static graphics ID</summary>
		private static int gd;
		/// <summary>Static effect container instance</summary>
		private static Xen.Graphics.ShaderSystem.ShaderEffect fx;
		/// <summary>Static RLE compressed shader byte code (Xbox360)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {4,188,240,11,207,131,0,1,16,136,0,8,254,255,9,1,0,0,1,92,135,0,1,3,131,0,1,1,131,0,1,128,135,0,1,6,131,0,1,4,131,0,1,1,227,0,0,1,6,1,95,1,118,1,115,1,95,1,99,134,0,0,1,12,131,0,0,1,4,131,0,0,1,164,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,48,133,0,0,1,12,131,0,0,1,4,131,0,0,1,200,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,49,133,0,0,1,12,131,0,0,1,4,131,0,0,1,236,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,50,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,16,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,51,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,5,131,0,0,1,1,131,0,0,1,7,131,0,0,1,3,131,0,0,1,4,131,0,0,1,32,139,0,0,1,140,131,0,0,1,160,139,0,0,1,176,131,0,0,1,196,139,0,0,1,212,131,0,0,1,232,139,0,0,1,248,1,0,1,0,1,1,1,12,138,0,0,1,1,1,80,135,0,0,1,1,1,0,1,0,1,1,1,76,135,0,0,1,2,131,0,0,1,92,134,0,0,1,1,1,32,1,0,1,0,1,1,1,28,131,0,0,1,93,134,0,0,1,1,1,56,1,0,1,0,1,1,1,52,135,0,0,1,2,136,0,0,132,255,0,131,0,0,1,1,135,0,0,1,184,1,16,1,42,1,17,132,0,0,1,124,131,0,0,1,60,135,0,0,1,36,135,0,0,1,88,139,0,0,1,48,131,0,0,1,28,131,0,0,1,35,1,255,1,255,1,3,144,0,0,1,28,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,60,1,16,1,0,1,1,132,0,0,1,4,134,0,0,1,16,1,33,1,0,1,1,1,0,1,1,131,0,0,1,1,1,0,1,0,1,240,1,81,132,0,0,1,48,1,1,1,196,1,0,1,34,131,0,0,1,22,1,128,1,1,132,0,0,1,27,1,226,131,0,0,1,200,1,7,1,0,1,1,1,0,1,192,1,27,1,0,1,225,1,0,1,1,1,0,1,200,1,15,1,128,133,0,0,1,226,1,1,1,1,149,0,0,132,255,0,138,0,0,1,3,1,64,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,188,1,0,1,0,1,1,1,132,135,0,0,1,36,1,0,1,0,1,1,1,96,1,0,1,0,1,1,1,136,138,0,0,1,1,1,56,131,0,0,1,28,1,0,1,0,1,1,1,44,1,255,1,254,1,3,132,0,0,1,5,131,0,0,1,28,134,0,0,1,1,1,37,131,0,0,1,128,1,0,1,2,131,0,0,1,6,133,0,0,1,136,131,0,0,1,152,131,0,0,1,248,1,0,1,3,131,0,0,1,1,132,0,0,1,1,135,0,0,1,1,1,16,1,0,1,3,1,0,1,1,1,0,1,1,132,0,0,1,1,135,0,0,1,1,1,23,1,0,1,3,1,0,1,2,1,0,1,1,132,0,0,1,1,135,0,0,1,1,1,30,1,0,1,3,1,0,1,3,1,0,1,1,132,0,0,1,1,133,0,0,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,2,3,0,3,1,0,4,2,0,6,229,0,0,1,0,1,95,1,118,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,118,1,115,1,95,1,115,1,49,1,0,1,95,1,118,1,115,1,95,1,115,1,50,1,0,1,95,1,118,1,115,1,95,1,115,1,51,1,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,136,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,1,1,68,1,0,1,1,1,0,1,3,138,0,0,1,16,1,33,131,0,0,1,1,131,0,0,1,1,131,0,0,1,1,1,0,1,0,1,2,1,144,131,0,0,1,4,1,0,1,0,1,240,1,81,1,0,1,0,1,16,1,25,176,0,0,1,63,1,128,1,0,1,0,1,63,139,0,0,1,16,1,9,1,96,1,4,1,96,1,10,1,18,1,0,1,18,1,0,1,5,1,80,132,0,0,1,96,1,16,1,194,1,0,1,18,133,0,0,1,48,1,22,1,0,1,0,1,18,1,0,1,196,133,0,0,1,16,1,25,1,0,1,0,1,34,133,0,0,1,5,1,248,132,0,0,1,14,1,120,132,0,0,1,176,1,35,1,0,1,1,1,0,1,176,1,177,1,192,1,1,1,4,1,255,1,4,1,168,1,128,133,0,0,1,65,1,194,1,0,1,0,1,4,1,52,1,18,131,0,0,1,27,1,0,1,27,1,232,1,128,1,0,1,0,1,200,1,8,1,0,1,1,1,1,1,27,1,177,1,177,1,237,131,0,0,1,168,1,64,1,1,132,0,0,1,128,1,194,1,0,1,0,1,4,1,200,1,3,131,0,0,1,196,1,179,1,0,1,224,1,1,1,1,1,0,1,184,1,128,133,0,0,1,65,1,194,1,0,1,0,1,255,1,49,1,24,1,16,1,1,1,15,1,31,1,246,1,136,1,0,1,0,1,64,2,0,49,3,40,48,1,4,15,31,254,200,5,0,0,64,0,49,6,8,32,1,15,31,254,7,200,0,0,64,0,49,56,8,0,1,15,31,245,207,0,0,4,64,0,200,10,131,0,9,188,17,0,224,2,0,0,200,3,10,0,3,0,198,176,0,225,0,3,0,2,200,1,131,0,9,198,177,108,139,3,5,5,200,5,131,0,9,176,108,0,225,3,0,0,200,3,131,0,11,196,198,25,235,0,2,0,200,1,128,62,5,0,109,109,27,145,131,0,12,200,2,128,62,0,109,109,27,145,0,1,1,13,200,4,128,62,0,109,109,27,145,0,2,2,200,14,8,128,62,0,109,109,27,145,0,3,3,200,15,128,133,0,3,226,1,1,140,0,1,0};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'textureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 textureSizeOffset'</summary><param name="value"/>
		public void SetTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[4] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 textureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 TextureSizeOffset
		{
			set
			{
				this.SetTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[5] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float2 velocityScale'</summary>
		public Microsoft.Xna.Framework.Vector2 VelocityScale
		{
			set
			{
				this.SetVelocityScale(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc0;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D ColourSampler'</summary>
		public Xen.Graphics.TextureSamplerState ColourSampler
		{
			get
			{
				return this.vts[1];
			}
			set
			{
				if ((value != this.vts[1]))
				{
					this.vts[1] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D PositionSampler'</summary>
		public Xen.Graphics.TextureSamplerState PositionSampler
		{
			get
			{
				return this.vts[0];
			}
			set
			{
				if ((value != this.vts[0]))
				{
					this.vts[0] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D UserSampler'</summary>
		public Xen.Graphics.TextureSamplerState UserSampler
		{
			get
			{
				return this.vts[3];
			}
			set
			{
				if ((value != this.vts[3]))
				{
					this.vts[3] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D VelocitySampler'</summary>
		public Xen.Graphics.TextureSamplerState VelocitySampler
		{
			get
			{
				return this.vts[2];
			}
			set
			{
				if ((value != this.vts[2]))
				{
					this.vts[2] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D PositionTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D PositionTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[0]));
			}
			set
			{
				if ((value != this.vtx[0]))
				{
					this.vtc = true;
					this.vtx[0] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D ColourTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D ColourTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[1]));
			}
			set
			{
				if ((value != this.vtx[1]))
				{
					this.vtc = true;
					this.vtx[1] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D VelocityTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D VelocityTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[2]));
			}
			set
			{
				if ((value != this.vtx[2]))
				{
					this.vtc = true;
					this.vtx[2] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D UserTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D UserTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[3]));
			}
			set
			{
				if ((value != this.vtx[3]))
				{
					this.vtc = true;
					this.vtx[3] = value;
				}
			}
		}
		/// <summary>Name uid for sampler for 'Sampler2D ColourSampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid1;
		/// <summary>Name uid for sampler for 'Sampler2D UserSampler'</summary>
		static int sid2;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid3;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D ColourTexture'</summary>
		static int tid1;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Name uid for texture for 'Texture2D UserTexture'</summary>
		static int tid3;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[6];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[4];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[4];
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.cid0))
			{
				this.SetTextureSizeOffset(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid0))
			{
				this.ColourSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid1))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid2))
			{
				this.UserSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid3))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid1))
			{
				this.ColourTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid3))
			{
				this.UserTexture = value;
				return true;
			}
			return false;
		}
	}
}
#else
namespace Xen.Ex.Graphics.Display
{
	
	/// <summary><para>Technique 'DrawVelocityParticles_LinesGpuTex' generated from file 'VelocityLines.fx'</para><para>Vertex Shader: approximately 26 instruction slots used (4 texture, 22 arithmetic), 6 registers</para><para>Pixel Shader: approximately 3 instruction slots used, 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityParticles_LinesGpuTex : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityParticles_LinesGpuTex' shader</summary>
		public DrawVelocityParticles_LinesGpuTex()
		{
			this.sc0 = -1;
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawVelocityParticles_LinesGpuTex.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityParticles_LinesGpuTex.cid0 = state.GetNameUniqueID("textureSizeOffset");
			DrawVelocityParticles_LinesGpuTex.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityParticles_LinesGpuTex.sid0 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityParticles_LinesGpuTex.sid1 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityParticles_LinesGpuTex.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityParticles_LinesGpuTex.tid2 = state.GetNameUniqueID("VelocityTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityParticles_LinesGpuTex.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc0));
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawVelocityParticles_LinesGpuTex.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityParticles_LinesGpuTex.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityParticles_LinesGpuTex.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityParticles_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityParticles_LinesGpuTex.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityParticles_LinesGpuTex.fx, DrawVelocityParticles_LinesGpuTex.fxb, 30, 4);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return (this.vreg_change | this.vtc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityParticles_LinesGpuTex.vin[i]));
			index = DrawVelocityParticles_LinesGpuTex.vin[(i + 1)];
		}
		/// <summary>Static graphics ID</summary>
		private static int gd;
		/// <summary>Static effect container instance</summary>
		private static Xen.Graphics.ShaderSystem.ShaderEffect fx;
		/// <summary>Static Length+DeflateStream compressed shader byte code (Windows)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {196,5,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,183,127,77,249,61,161,255,255,58,244,255,223,201,251,30,207,111,78,255,255,253,127,255,245,114,221,228,179,223,191,201,22,171,50,175,241,249,175,141,247,233,255,127,147,182,251,245,244,125,5,247,179,250,160,175,223,255,178,249,253,167,244,243,55,250,53,164,223,127,173,211,230,215,215,54,205,206,175,241,215,154,54,255,219,80,155,221,95,227,15,2,222,191,153,182,243,159,95,139,254,255,155,70,62,151,113,254,99,191,14,96,188,158,103,51,80,197,140,31,248,129,62,248,251,183,243,222,217,167,255,191,244,254,254,251,232,255,255,146,247,247,127,68,255,255,229,222,223,143,149,152,248,177,175,191,3,159,63,69,191,255,13,232,179,95,135,254,255,167,234,223,41,253,254,59,121,237,204,243,127,211,99,230,229,207,194,63,191,246,255,253,127,255,95,255,247,111,243,107,156,188,57,126,130,249,254,113,253,204,123,37,197,231,171,230,247,191,247,251,239,252,26,95,20,211,186,106,170,243,54,221,122,117,39,253,246,243,215,207,83,25,113,122,82,45,86,5,49,68,250,112,188,247,233,248,225,253,189,241,222,193,254,254,175,241,187,80,247,191,238,175,241,107,254,65,68,185,63,233,215,100,84,126,115,250,253,255,254,147,126,93,144,229,55,248,245,233,247,95,131,254,255,159,201,119,191,193,111,192,127,251,189,3,95,243,251,111,4,66,254,218,255,23,225,251,165,197,247,215,255,53,229,51,124,165,252,154,130,72,191,247,175,33,227,254,245,232,223,63,128,126,174,126,13,161,175,240,234,175,245,107,252,91,10,243,191,226,207,126,77,250,239,215,251,53,254,39,253,76,248,233,175,253,107,127,77,254,230,215,225,57,252,97,60,134,71,127,29,226,228,95,147,255,243,62,223,237,127,126,249,53,231,228,39,126,141,95,227,215,253,245,126,141,223,244,47,34,16,191,7,145,251,31,20,104,127,208,239,241,187,8,201,254,32,204,149,254,254,39,253,26,191,193,111,250,23,153,223,127,77,247,59,218,252,71,102,110,127,77,250,253,215,98,210,254,154,127,208,175,243,107,252,53,128,43,243,203,243,254,107,208,103,191,198,95,244,91,242,123,191,22,254,254,99,127,99,254,238,215,225,239,232,255,127,240,111,193,172,139,182,127,13,253,255,43,252,255,15,246,218,255,65,6,182,180,255,234,15,6,236,95,83,191,251,117,126,141,175,254,34,225,171,95,243,15,162,121,250,139,126,29,22,181,95,155,62,255,207,128,7,225,246,159,253,65,242,217,111,196,176,127,189,95,227,79,251,139,126,189,95,227,111,251,139,126,127,134,241,155,210,103,255,219,31,244,107,254,6,255,25,255,253,107,232,223,191,6,253,45,239,252,58,244,254,255,253,7,253,186,212,7,245,249,23,73,191,191,54,195,36,88,127,146,249,27,120,187,126,204,247,255,55,253,255,63,251,131,4,183,95,135,250,253,191,255,162,223,64,198,241,31,253,26,252,253,47,215,191,127,173,255,72,218,153,191,127,29,254,251,215,178,127,255,6,252,247,175,77,127,3,22,104,13,88,144,208,255,39,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'textureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 textureSizeOffset'</summary><param name="value"/>
		public void SetTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[4] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 textureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 TextureSizeOffset
		{
			set
			{
				this.SetTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[5] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float2 velocityScale'</summary>
		public Microsoft.Xna.Framework.Vector2 VelocityScale
		{
			set
			{
				this.SetVelocityScale(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc0;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D PositionSampler'</summary>
		public Xen.Graphics.TextureSamplerState PositionSampler
		{
			get
			{
				return this.vts[0];
			}
			set
			{
				if ((value != this.vts[0]))
				{
					this.vts[0] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D VelocitySampler'</summary>
		public Xen.Graphics.TextureSamplerState VelocitySampler
		{
			get
			{
				return this.vts[1];
			}
			set
			{
				if ((value != this.vts[1]))
				{
					this.vts[1] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D PositionTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D PositionTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[0]));
			}
			set
			{
				if ((value != this.vtx[0]))
				{
					this.vtc = true;
					this.vtx[0] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D VelocityTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D VelocityTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[1]));
			}
			set
			{
				if ((value != this.vtx[1]))
				{
					this.vtc = true;
					this.vtx[1] = value;
				}
			}
		}
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid1;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[6];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[2];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[2];
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityParticles_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityParticles_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex.cid0))
			{
				this.SetTextureSizeOffset(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityParticles_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex.sid0))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticles_LinesGpuTex.sid1))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityParticles_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticles_LinesGpuTex.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityParticlesColour_LinesGpuTex' generated from file 'VelocityLines.fx'</para><para>Vertex Shader: approximately 28 instruction slots used (6 texture, 22 arithmetic), 6 registers</para><para>Pixel Shader: approximately 3 instruction slots used, 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityParticlesColour_LinesGpuTex : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityParticlesColour_LinesGpuTex' shader</summary>
		public DrawVelocityParticlesColour_LinesGpuTex()
		{
			this.sc0 = -1;
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[2] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawVelocityParticlesColour_LinesGpuTex.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityParticlesColour_LinesGpuTex.cid0 = state.GetNameUniqueID("textureSizeOffset");
			DrawVelocityParticlesColour_LinesGpuTex.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityParticlesColour_LinesGpuTex.sid0 = state.GetNameUniqueID("ColourSampler");
			DrawVelocityParticlesColour_LinesGpuTex.sid1 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityParticlesColour_LinesGpuTex.sid2 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityParticlesColour_LinesGpuTex.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityParticlesColour_LinesGpuTex.tid1 = state.GetNameUniqueID("ColourTexture");
			DrawVelocityParticlesColour_LinesGpuTex.tid2 = state.GetNameUniqueID("VelocityTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityParticlesColour_LinesGpuTex.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc0));
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawVelocityParticlesColour_LinesGpuTex.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityParticlesColour_LinesGpuTex.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityParticlesColour_LinesGpuTex.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityParticlesColour_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityParticlesColour_LinesGpuTex.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityParticlesColour_LinesGpuTex.fx, DrawVelocityParticlesColour_LinesGpuTex.fxb, 32, 4);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return (this.vreg_change | this.vtc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityParticlesColour_LinesGpuTex.vin[i]));
			index = DrawVelocityParticlesColour_LinesGpuTex.vin[(i + 1)];
		}
		/// <summary>Static graphics ID</summary>
		private static int gd;
		/// <summary>Static effect container instance</summary>
		private static Xen.Graphics.ShaderSystem.ShaderEffect fx;
		/// <summary>Static Length+DeflateStream compressed shader byte code (Windows)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {52,6,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,87,249,107,202,239,9,253,255,215,161,255,255,78,222,247,120,126,115,250,255,239,255,251,175,151,235,38,159,253,254,77,182,88,149,121,141,207,127,109,188,79,255,255,155,180,221,175,167,239,43,184,159,213,7,125,253,254,151,205,239,63,253,53,126,141,95,235,55,250,53,164,223,127,173,211,230,215,215,54,205,206,175,241,107,152,54,255,219,80,155,93,215,230,119,234,12,192,182,217,251,53,254,36,124,245,155,105,59,255,249,181,232,255,191,105,228,115,1,245,143,255,58,128,241,122,158,205,64,185,95,87,63,199,103,160,33,222,249,237,188,119,246,233,255,47,189,191,255,62,250,255,191,228,253,253,31,209,255,127,185,247,247,175,67,192,126,59,15,231,63,64,127,199,143,223,91,127,7,126,127,138,126,63,162,207,182,232,255,127,170,254,253,148,126,255,61,189,118,230,249,191,233,49,96,255,44,252,243,107,255,223,255,247,255,245,127,255,54,191,198,201,155,227,39,224,145,31,215,207,188,87,82,124,190,106,126,255,123,191,255,206,175,241,69,49,173,171,166,58,111,211,173,87,119,210,111,63,127,253,60,21,10,164,39,213,98,85,16,19,165,15,199,123,159,142,31,222,223,27,239,29,236,239,255,26,191,11,117,255,235,254,26,191,230,31,68,148,4,157,9,149,223,156,126,255,191,255,164,95,23,100,250,13,126,125,250,253,215,160,255,255,103,242,221,111,240,27,240,223,126,239,192,215,252,254,109,16,246,215,254,191,8,223,159,178,248,222,251,53,229,51,143,199,83,208,162,252,53,100,220,191,30,253,219,210,207,63,140,254,255,159,253,26,134,191,127,173,95,227,191,83,152,255,7,127,246,107,210,127,191,30,211,28,207,111,245,107,226,179,95,139,62,75,44,223,8,95,254,181,127,237,175,201,173,127,29,230,213,31,198,163,188,254,215,254,58,196,201,191,38,255,231,125,190,59,240,249,94,255,243,203,175,57,127,63,65,172,253,235,253,26,191,233,95,68,32,126,15,154,154,127,80,160,253,65,191,199,239,34,228,253,131,48,175,250,251,159,244,107,252,6,191,233,95,100,126,255,53,189,223,127,45,247,59,218,255,71,134,39,126,77,250,253,215,226,41,249,53,255,160,95,231,215,248,107,208,135,240,5,243,203,175,65,159,253,26,127,209,111,201,239,253,90,248,251,143,253,141,249,187,95,135,191,163,255,255,193,191,5,139,9,218,254,53,244,255,175,240,255,63,216,107,255,7,25,216,210,254,171,63,24,176,127,77,253,238,215,249,53,190,250,139,132,31,127,205,63,136,230,242,47,250,117,88,100,127,109,250,252,63,3,30,132,219,127,246,7,201,103,191,17,195,254,245,126,141,63,237,47,250,245,126,141,191,237,47,250,253,25,198,111,250,31,145,214,249,131,126,205,223,224,63,51,127,255,65,248,251,215,210,191,127,13,253,251,215,160,191,5,198,175,67,240,254,239,63,232,215,165,62,9,135,191,72,240,248,181,185,15,130,253,39,153,191,49,14,215,175,249,254,255,166,255,255,103,127,144,224,250,235,16,30,255,247,95,244,27,200,184,254,35,124,78,90,67,255,254,181,254,35,105,103,254,254,117,248,239,95,203,254,253,27,240,223,191,54,253,13,233,254,127,2,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'textureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 textureSizeOffset'</summary><param name="value"/>
		public void SetTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[4] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 textureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 TextureSizeOffset
		{
			set
			{
				this.SetTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[5] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float2 velocityScale'</summary>
		public Microsoft.Xna.Framework.Vector2 VelocityScale
		{
			set
			{
				this.SetVelocityScale(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc0;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D ColourSampler'</summary>
		public Xen.Graphics.TextureSamplerState ColourSampler
		{
			get
			{
				return this.vts[1];
			}
			set
			{
				if ((value != this.vts[1]))
				{
					this.vts[1] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D PositionSampler'</summary>
		public Xen.Graphics.TextureSamplerState PositionSampler
		{
			get
			{
				return this.vts[0];
			}
			set
			{
				if ((value != this.vts[0]))
				{
					this.vts[0] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D VelocitySampler'</summary>
		public Xen.Graphics.TextureSamplerState VelocitySampler
		{
			get
			{
				return this.vts[2];
			}
			set
			{
				if ((value != this.vts[2]))
				{
					this.vts[2] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D PositionTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D PositionTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[0]));
			}
			set
			{
				if ((value != this.vtx[0]))
				{
					this.vtc = true;
					this.vtx[0] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D ColourTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D ColourTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[1]));
			}
			set
			{
				if ((value != this.vtx[1]))
				{
					this.vtc = true;
					this.vtx[1] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D VelocityTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D VelocityTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[2]));
			}
			set
			{
				if ((value != this.vtx[2]))
				{
					this.vtc = true;
					this.vtx[2] = value;
				}
			}
		}
		/// <summary>Name uid for sampler for 'Sampler2D ColourSampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid1;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid2;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D ColourTexture'</summary>
		static int tid1;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[6];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[3];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[3];
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.cid0))
			{
				this.SetTextureSizeOffset(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.sid0))
			{
				this.ColourSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.sid1))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.sid2))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.tid1))
			{
				this.ColourTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityParticles_LinesGpuTex_UserOffset' generated from file 'VelocityLines.fx'</para><para>Vertex Shader: approximately 29 instruction slots used (6 texture, 23 arithmetic), 6 registers</para><para>Pixel Shader: approximately 3 instruction slots used, 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityParticles_LinesGpuTex_UserOffset : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityParticles_LinesGpuTex_UserOffset' shader</summary>
		public DrawVelocityParticles_LinesGpuTex_UserOffset()
		{
			this.sc0 = -1;
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[2] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawVelocityParticles_LinesGpuTex_UserOffset.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityParticles_LinesGpuTex_UserOffset.cid0 = state.GetNameUniqueID("textureSizeOffset");
			DrawVelocityParticles_LinesGpuTex_UserOffset.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityParticles_LinesGpuTex_UserOffset.sid0 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityParticles_LinesGpuTex_UserOffset.sid1 = state.GetNameUniqueID("UserSampler");
			DrawVelocityParticles_LinesGpuTex_UserOffset.sid2 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityParticles_LinesGpuTex_UserOffset.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityParticles_LinesGpuTex_UserOffset.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawVelocityParticles_LinesGpuTex_UserOffset.tid3 = state.GetNameUniqueID("UserTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityParticles_LinesGpuTex_UserOffset.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc0));
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawVelocityParticles_LinesGpuTex_UserOffset.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityParticles_LinesGpuTex_UserOffset.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityParticles_LinesGpuTex_UserOffset.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityParticles_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityParticles_LinesGpuTex_UserOffset.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityParticles_LinesGpuTex_UserOffset.fx, DrawVelocityParticles_LinesGpuTex_UserOffset.fxb, 33, 4);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return (this.vreg_change | this.vtc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityParticles_LinesGpuTex_UserOffset.vin[i]));
			index = DrawVelocityParticles_LinesGpuTex_UserOffset.vin[(i + 1)];
		}
		/// <summary>Static graphics ID</summary>
		private static int gd;
		/// <summary>Static effect container instance</summary>
		private static Xen.Graphics.ShaderSystem.ShaderEffect fx;
		/// <summary>Static Length+DeflateStream compressed shader byte code (Windows)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {80,6,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,87,249,107,202,239,9,253,255,215,161,255,255,78,222,247,120,126,115,250,255,239,255,251,175,151,235,38,159,253,254,77,182,88,149,121,141,207,127,109,188,79,255,255,155,180,221,175,167,239,43,184,159,213,7,125,253,254,151,205,239,63,165,159,191,209,175,33,253,254,107,157,54,191,190,182,105,118,126,141,95,203,180,249,223,134,218,236,254,26,127,144,105,243,59,117,6,96,219,236,201,216,126,51,109,231,63,191,22,253,255,55,141,124,46,160,126,99,134,241,122,158,205,64,185,95,87,63,199,103,160,33,222,249,237,188,119,246,233,255,47,189,191,255,62,250,255,191,228,253,253,31,209,255,127,185,247,247,175,67,192,126,59,15,231,63,64,127,199,143,223,91,127,7,126,127,138,126,63,162,207,182,232,255,127,170,254,253,148,126,255,61,189,118,230,249,191,233,49,96,255,44,252,243,107,255,223,255,247,255,245,127,255,54,191,198,201,155,227,39,224,145,31,215,207,188,87,82,124,190,106,126,255,123,191,255,206,175,241,69,49,173,171,166,58,111,211,173,87,119,210,111,63,127,253,60,21,10,164,39,213,98,85,16,19,165,15,199,123,159,142,31,222,223,27,239,29,236,239,255,26,191,11,117,255,235,254,26,191,230,31,68,148,252,147,126,77,70,229,55,167,223,255,239,63,233,215,5,153,126,131,95,159,126,255,53,232,255,255,153,124,247,27,252,6,252,183,223,59,240,53,191,207,64,216,95,251,255,34,124,127,202,226,123,239,215,148,207,60,30,79,65,139,242,215,144,113,255,122,244,111,75,63,255,48,250,255,127,246,107,24,254,254,181,126,141,255,78,97,254,31,252,217,175,73,255,253,122,76,115,60,191,213,175,137,207,126,45,250,44,177,124,35,124,249,215,254,181,191,38,183,254,117,152,87,127,24,143,242,250,95,251,235,144,68,252,154,252,159,247,249,238,192,231,123,253,207,47,191,230,252,253,4,177,246,175,247,107,252,166,127,17,129,248,61,104,106,254,65,129,246,7,253,30,191,139,144,247,15,194,188,234,239,127,210,175,241,27,252,166,127,145,249,253,215,244,126,255,181,220,239,104,255,31,25,158,248,53,233,247,95,139,167,228,215,252,131,126,157,95,227,175,65,31,194,23,204,47,191,6,125,246,107,252,69,191,37,191,247,107,225,239,63,246,55,230,239,126,29,254,142,254,255,7,255,22,44,38,104,251,215,208,255,191,194,255,255,96,175,253,31,100,96,75,251,175,254,96,192,254,53,245,187,95,231,215,248,234,47,18,126,252,53,255,32,154,203,191,232,215,97,145,253,181,233,243,255,12,120,16,110,255,217,31,36,159,253,70,12,251,215,251,53,254,180,191,232,215,251,53,254,182,191,232,247,103,24,191,41,125,246,191,253,65,191,214,111,240,159,241,223,191,150,254,253,107,232,223,191,134,254,253,107,210,223,191,22,183,255,181,9,222,127,77,248,24,152,24,195,255,253,7,253,186,132,3,225,244,23,201,152,127,109,250,236,63,67,95,74,3,252,253,215,240,103,6,55,252,254,107,209,123,192,77,112,255,117,8,175,255,251,47,250,13,100,156,255,145,188,255,203,245,239,95,139,255,254,53,237,223,191,206,127,36,239,155,191,127,3,254,251,215,166,191,1,11,115,1,88,144,252,255,39,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'textureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 textureSizeOffset'</summary><param name="value"/>
		public void SetTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[4] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 textureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 TextureSizeOffset
		{
			set
			{
				this.SetTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[5] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float2 velocityScale'</summary>
		public Microsoft.Xna.Framework.Vector2 VelocityScale
		{
			set
			{
				this.SetVelocityScale(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc0;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D PositionSampler'</summary>
		public Xen.Graphics.TextureSamplerState PositionSampler
		{
			get
			{
				return this.vts[0];
			}
			set
			{
				if ((value != this.vts[0]))
				{
					this.vts[0] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D UserSampler'</summary>
		public Xen.Graphics.TextureSamplerState UserSampler
		{
			get
			{
				return this.vts[2];
			}
			set
			{
				if ((value != this.vts[2]))
				{
					this.vts[2] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D VelocitySampler'</summary>
		public Xen.Graphics.TextureSamplerState VelocitySampler
		{
			get
			{
				return this.vts[1];
			}
			set
			{
				if ((value != this.vts[1]))
				{
					this.vts[1] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D PositionTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D PositionTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[0]));
			}
			set
			{
				if ((value != this.vtx[0]))
				{
					this.vtc = true;
					this.vtx[0] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D VelocityTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D VelocityTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[1]));
			}
			set
			{
				if ((value != this.vtx[1]))
				{
					this.vtc = true;
					this.vtx[1] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D UserTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D UserTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[2]));
			}
			set
			{
				if ((value != this.vtx[2]))
				{
					this.vtc = true;
					this.vtx[2] = value;
				}
			}
		}
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D UserSampler'</summary>
		static int sid1;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid2;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Name uid for texture for 'Texture2D UserTexture'</summary>
		static int tid3;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[6];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[3];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[3];
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityParticles_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityParticles_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.cid0))
			{
				this.SetTextureSizeOffset(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityParticles_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.sid0))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.sid1))
			{
				this.UserSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.sid2))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityParticles_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticles_LinesGpuTex_UserOffset.tid3))
			{
				this.UserTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityParticlesColour_LinesGpuTex_UserOffset' generated from file 'VelocityLines.fx'</para><para>Vertex Shader: approximately 31 instruction slots used (8 texture, 23 arithmetic), 6 registers</para><para>Pixel Shader: approximately 3 instruction slots used, 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityParticlesColour_LinesGpuTex_UserOffset : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityParticlesColour_LinesGpuTex_UserOffset' shader</summary>
		public DrawVelocityParticlesColour_LinesGpuTex_UserOffset()
		{
			this.sc0 = -1;
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[3] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[2] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.cid0 = state.GetNameUniqueID("textureSizeOffset");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid0 = state.GetNameUniqueID("ColourSampler");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid1 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid2 = state.GetNameUniqueID("UserSampler");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid3 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid1 = state.GetNameUniqueID("ColourTexture");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid3 = state.GetNameUniqueID("UserTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc0));
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawVelocityParticlesColour_LinesGpuTex_UserOffset.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityParticlesColour_LinesGpuTex_UserOffset.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityParticlesColour_LinesGpuTex_UserOffset.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityParticlesColour_LinesGpuTex_UserOffset.fx, DrawVelocityParticlesColour_LinesGpuTex_UserOffset.fxb, 35, 4);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return (this.vreg_change | this.vtc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityParticlesColour_LinesGpuTex_UserOffset.vin[i]));
			index = DrawVelocityParticlesColour_LinesGpuTex_UserOffset.vin[(i + 1)];
		}
		/// <summary>Static graphics ID</summary>
		private static int gd;
		/// <summary>Static effect container instance</summary>
		private static Xen.Graphics.ShaderSystem.ShaderEffect fx;
		/// <summary>Static Length+DeflateStream compressed shader byte code (Windows)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {128,6,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,31,240,107,202,239,191,54,254,166,255,255,65,250,221,175,71,255,255,117,244,179,159,237,7,125,253,254,151,205,239,63,165,30,127,163,95,67,250,253,203,58,109,126,125,109,211,236,252,26,127,145,105,243,79,13,181,217,253,53,42,211,230,191,27,106,179,231,224,252,102,157,65,218,54,247,126,141,95,11,95,253,102,218,206,127,126,45,250,255,111,26,249,92,64,253,81,191,55,96,188,158,103,179,188,254,53,254,160,95,87,63,199,103,160,51,222,73,189,119,254,56,250,255,95,228,253,253,55,209,255,255,49,239,239,127,141,254,255,95,121,127,255,111,244,255,223,200,195,249,141,254,142,31,207,245,119,224,247,167,232,247,41,125,246,59,209,255,255,84,253,251,128,126,223,247,218,153,231,255,166,199,128,253,179,240,207,175,253,127,255,223,255,215,255,253,219,252,26,39,111,142,159,252,78,244,231,143,235,103,222,43,41,62,95,53,191,255,189,223,127,231,215,248,162,152,214,85,83,157,183,233,214,171,59,233,183,159,191,126,158,10,5,210,147,106,177,42,74,250,229,225,120,239,211,241,195,251,123,227,189,131,253,253,95,227,119,161,238,127,221,95,227,215,252,131,136,146,127,210,175,201,168,252,230,244,251,255,253,39,253,186,32,211,111,240,235,211,239,191,6,253,255,63,147,239,126,131,223,128,255,246,123,7,190,230,247,191,8,132,253,181,255,47,194,55,183,248,254,254,191,166,124,6,250,255,78,210,44,253,189,127,77,225,113,140,251,215,163,127,255,168,95,67,198,250,191,253,26,70,6,126,45,203,244,224,139,95,155,254,248,53,169,229,111,167,159,109,241,103,191,22,125,150,252,26,59,250,217,239,201,159,161,229,111,242,107,124,91,63,19,126,254,107,255,218,95,147,63,255,117,152,199,127,24,143,202,200,95,11,73,250,53,249,63,239,243,221,129,207,247,6,62,191,215,255,252,242,107,206,245,79,252,26,191,198,175,251,235,253,26,191,233,95,68,32,126,15,154,129,127,80,160,253,65,191,199,239,34,83,241,7,129,7,244,247,63,233,215,248,13,126,211,191,200,252,254,107,122,191,255,90,222,239,191,182,251,29,239,254,71,134,151,126,77,250,253,215,226,169,252,53,255,160,95,231,215,248,107,208,159,240,19,243,217,175,65,159,253,26,127,209,111,201,239,253,90,248,251,143,253,141,249,187,95,135,191,163,255,255,193,191,5,253,241,107,114,219,191,134,254,255,21,254,255,7,123,237,255,32,3,91,218,127,245,7,3,246,175,169,223,253,58,191,198,87,127,145,240,241,175,249,7,209,124,255,69,191,14,139,250,175,77,159,255,103,192,131,112,251,207,254,32,249,236,55,98,216,191,222,175,241,167,253,69,191,222,175,241,183,253,69,191,63,195,248,77,255,35,226,194,63,232,215,252,13,254,51,243,247,31,132,191,127,109,253,251,215,210,191,127,13,253,251,215,208,191,127,45,250,251,215,226,246,191,54,193,255,175,9,63,211,7,198,244,127,147,238,249,234,47,34,28,255,34,161,193,175,77,159,253,103,232,91,105,130,191,255,26,254,204,224,138,223,127,45,122,15,184,202,88,126,29,194,243,255,254,139,126,3,25,247,127,36,239,255,114,253,251,215,226,191,127,77,251,247,175,243,31,201,251,230,239,223,128,255,254,181,233,111,104,141,255,39,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'textureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 textureSizeOffset'</summary><param name="value"/>
		public void SetTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[4] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 textureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 TextureSizeOffset
		{
			set
			{
				this.SetTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[5] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float2 velocityScale'</summary>
		public Microsoft.Xna.Framework.Vector2 VelocityScale
		{
			set
			{
				this.SetVelocityScale(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc0;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D ColourSampler'</summary>
		public Xen.Graphics.TextureSamplerState ColourSampler
		{
			get
			{
				return this.vts[1];
			}
			set
			{
				if ((value != this.vts[1]))
				{
					this.vts[1] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D PositionSampler'</summary>
		public Xen.Graphics.TextureSamplerState PositionSampler
		{
			get
			{
				return this.vts[0];
			}
			set
			{
				if ((value != this.vts[0]))
				{
					this.vts[0] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D UserSampler'</summary>
		public Xen.Graphics.TextureSamplerState UserSampler
		{
			get
			{
				return this.vts[3];
			}
			set
			{
				if ((value != this.vts[3]))
				{
					this.vts[3] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D VelocitySampler'</summary>
		public Xen.Graphics.TextureSamplerState VelocitySampler
		{
			get
			{
				return this.vts[2];
			}
			set
			{
				if ((value != this.vts[2]))
				{
					this.vts[2] = value;
					this.vtc = true;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D PositionTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D PositionTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[0]));
			}
			set
			{
				if ((value != this.vtx[0]))
				{
					this.vtc = true;
					this.vtx[0] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D ColourTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D ColourTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[1]));
			}
			set
			{
				if ((value != this.vtx[1]))
				{
					this.vtc = true;
					this.vtx[1] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D VelocityTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D VelocityTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[2]));
			}
			set
			{
				if ((value != this.vtx[2]))
				{
					this.vtc = true;
					this.vtx[2] = value;
				}
			}
		}
		/// <summary>Get/Set the Bound texture for 'Texture2D UserTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D UserTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.vtx[3]));
			}
			set
			{
				if ((value != this.vtx[3]))
				{
					this.vtc = true;
					this.vtx[3] = value;
				}
			}
		}
		/// <summary>Name uid for sampler for 'Sampler2D ColourSampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid1;
		/// <summary>Name uid for sampler for 'Sampler2D UserSampler'</summary>
		static int sid2;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid3;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D ColourTexture'</summary>
		static int tid1;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Name uid for texture for 'Texture2D UserTexture'</summary>
		static int tid3;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[6];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[4];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[4];
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.cid0))
			{
				this.SetTextureSizeOffset(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid0))
			{
				this.ColourSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid1))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid2))
			{
				this.UserSampler = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.sid3))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityParticlesColour_LinesGpuTex_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid1))
			{
				this.ColourTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesGpuTex_UserOffset.tid3))
			{
				this.UserTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityParticles_LinesCpu' generated from file 'VelocityLines.fx'</para><para>Vertex Shader: approximately 14 instruction slots used, 165 registers</para><para>Pixel Shader: approximately 3 instruction slots used, 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityParticles_LinesCpu : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityParticles_LinesCpu' shader</summary>
		public DrawVelocityParticles_LinesCpu()
		{
			this.sc0 = -1;
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawVelocityParticles_LinesCpu.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityParticles_LinesCpu.cid0 = state.GetNameUniqueID("positionData");
			DrawVelocityParticles_LinesCpu.cid1 = state.GetNameUniqueID("velocityData");
			DrawVelocityParticles_LinesCpu.cid2 = state.GetNameUniqueID("velocityScale");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityParticles_LinesCpu.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[160], ref this.vreg[161], ref this.vreg[162], ref this.vreg[163], ref this.sc0));
			if ((this.vreg_change == true))
			{
				DrawVelocityParticles_LinesCpu.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityParticles_LinesCpu.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityParticles_LinesCpu.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityParticles_LinesCpu.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityParticles_LinesCpu.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityParticles_LinesCpu.fx, DrawVelocityParticles_LinesCpu.fxb, 16, 4);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return this.vreg_change;
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityParticles_LinesCpu.vin[i]));
			index = DrawVelocityParticles_LinesCpu.vin[(i + 1)];
		}
		/// <summary>Static graphics ID</summary>
		private static int gd;
		/// <summary>Static effect container instance</summary>
		private static Xen.Graphics.ShaderSystem.ShaderEffect fx;
		/// <summary>Static Length+DeflateStream compressed shader byte code (Windows)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {232,23,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,63,148,200,239,191,54,254,166,255,175,244,239,191,156,254,255,235,232,103,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,63,122,126,244,124,200,243,235,209,255,127,255,203,230,247,159,254,26,255,217,95,4,255,242,55,251,53,196,215,244,159,95,139,254,255,155,70,62,55,254,232,175,79,255,127,61,207,102,121,253,107,172,126,77,253,252,215,214,255,227,157,212,123,231,111,83,159,22,109,254,58,253,29,240,255,20,253,254,15,162,207,126,134,254,255,167,234,223,127,22,253,254,167,121,237,204,243,127,211,99,250,255,179,248,203,255,251,255,254,191,254,239,223,230,215,56,121,115,252,228,119,162,63,127,92,63,243,94,73,241,249,170,249,253,247,126,255,157,95,227,139,98,90,87,77,117,222,166,91,175,238,164,223,126,254,250,121,42,35,72,79,170,197,170,40,233,151,135,227,189,79,199,15,239,239,141,247,14,246,247,127,141,223,69,186,255,131,126,205,95,227,55,253,155,126,77,254,253,183,163,223,255,239,191,233,215,229,97,254,250,127,16,97,68,127,255,103,242,221,111,240,155,210,223,255,217,31,228,247,14,124,205,239,255,213,111,8,220,254,47,194,247,111,255,181,12,190,127,97,34,159,97,76,191,147,52,75,49,246,157,95,67,58,254,203,233,223,3,250,249,237,95,195,204,215,95,251,215,254,154,212,245,175,73,20,70,124,240,163,231,71,207,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,135,62,151,95,211,87,254,137,95,227,215,248,117,255,242,95,227,55,253,139,200,93,254,61,124,120,198,135,166,104,226,79,250,45,249,247,95,147,126,255,53,254,164,95,139,125,104,254,253,15,198,223,99,249,238,111,250,53,216,223,198,119,191,193,31,244,50,253,191,9,222,175,241,55,253,58,28,82,160,237,255,253,7,253,101,191,198,87,127,209,95,246,107,252,26,127,209,175,203,159,253,122,244,217,87,127,210,203,244,95,226,118,226,151,255,218,128,73,255,255,175,255,160,95,135,67,29,252,253,159,253,65,191,134,194,250,53,210,255,140,127,138,63,255,235,252,65,228,71,255,69,191,129,224,242,15,161,221,95,244,107,252,114,253,251,215,226,191,255,98,251,247,175,195,127,255,37,246,239,223,128,255,254,75,233,111,192,162,24,225,63,2,44,68,31,255,79,0,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'positionData'</summary>
		private static int cid0;
		/// <summary>Set the shader array value 'float4 positionData[80]'</summary><param name="value"/><param name="readIndex"/><param name="writeIndex"/><param name="count"/>
		public void SetPositionData(Microsoft.Xna.Framework.Vector4[] value, uint readIndex, uint writeIndex, uint count)
		{
			Microsoft.Xna.Framework.Vector4 val;
			int i;
			uint ri;
			uint wi;
			ri = readIndex;
			wi = writeIndex;
			if ((value == null))
			{
				throw new System.ArgumentNullException("value");
			}
			if ((((ri + count) 
						> value.Length) 
						|| ((wi + count) 
						> 80)))
			{
				throw new System.ArgumentException("Invalid range");
			}
			for (i = 0; ((i < count) 
						&& (wi < 80)); i = (i + 1))
			{
				val = value[ri];
				this.vreg[((wi * 1) 
							+ 0)] = val;
				ri = (ri + 1);
				wi = (wi + 1);
			}
			this.vreg_change = true;
		}
		/// <summary>Set and copy the array data for the shader value 'float4 positionData[80]'</summary>
		public Microsoft.Xna.Framework.Vector4[] PositionData
		{
			set
			{
				this.SetPositionData(value, 0, 0, ((uint)(value.Length)));
			}
		}
		/// <summary>Name ID for 'velocityData'</summary>
		private static int cid1;
		/// <summary>Set the shader array value 'float4 velocityData[80]'</summary><param name="value"/><param name="readIndex"/><param name="writeIndex"/><param name="count"/>
		public void SetVelocityData(Microsoft.Xna.Framework.Vector4[] value, uint readIndex, uint writeIndex, uint count)
		{
			Microsoft.Xna.Framework.Vector4 val;
			int i;
			uint ri;
			uint wi;
			ri = readIndex;
			wi = writeIndex;
			if ((value == null))
			{
				throw new System.ArgumentNullException("value");
			}
			if ((((ri + count) 
						> value.Length) 
						|| ((wi + count) 
						> 80)))
			{
				throw new System.ArgumentException("Invalid range");
			}
			for (i = 0; ((i < count) 
						&& (wi < 80)); i = (i + 1))
			{
				val = value[ri];
				this.vreg[((wi * 1) 
							+ 80)] = val;
				ri = (ri + 1);
				wi = (wi + 1);
			}
			this.vreg_change = true;
		}
		/// <summary>Set and copy the array data for the shader value 'float4 velocityData[80]'</summary>
		public Microsoft.Xna.Framework.Vector4[] VelocityData
		{
			set
			{
				this.SetVelocityData(value, 0, 0, ((uint)(value.Length)));
			}
		}
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid2;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[164] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float2 velocityScale'</summary>
		public Microsoft.Xna.Framework.Vector2 VelocityScale
		{
			set
			{
				this.SetVelocityScale(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc0;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[165];
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityParticles_LinesCpu.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesCpu.cid2))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector4[]' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Vector4[] value)
		{
			if ((DrawVelocityParticles_LinesCpu.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticles_LinesCpu.cid0))
			{
				this.SetPositionData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			if ((id == DrawVelocityParticles_LinesCpu.cid1))
			{
				this.SetVelocityData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityParticlesColour_LinesCpu' generated from file 'VelocityLines.fx'</para><para>Vertex Shader: approximately 14 instruction slots used, 245 registers</para><para>Pixel Shader: approximately 3 instruction slots used, 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityParticlesColour_LinesCpu : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityParticlesColour_LinesCpu' shader</summary>
		public DrawVelocityParticlesColour_LinesCpu()
		{
			this.sc0 = -1;
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawVelocityParticlesColour_LinesCpu.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityParticlesColour_LinesCpu.cid0 = state.GetNameUniqueID("colourData");
			DrawVelocityParticlesColour_LinesCpu.cid1 = state.GetNameUniqueID("positionData");
			DrawVelocityParticlesColour_LinesCpu.cid2 = state.GetNameUniqueID("velocityData");
			DrawVelocityParticlesColour_LinesCpu.cid3 = state.GetNameUniqueID("velocityScale");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityParticlesColour_LinesCpu.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[240], ref this.vreg[241], ref this.vreg[242], ref this.vreg[243], ref this.sc0));
			if ((this.vreg_change == true))
			{
				DrawVelocityParticlesColour_LinesCpu.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityParticlesColour_LinesCpu.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityParticlesColour_LinesCpu.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityParticlesColour_LinesCpu.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityParticlesColour_LinesCpu.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityParticlesColour_LinesCpu.fx, DrawVelocityParticlesColour_LinesCpu.fxb, 16, 4);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return this.vreg_change;
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityParticlesColour_LinesCpu.vin[i]));
			index = DrawVelocityParticlesColour_LinesCpu.vin[(i + 1)];
		}
		/// <summary>Static graphics ID</summary>
		private static int gd;
		/// <summary>Static effect container instance</summary>
		private static Xen.Graphics.ShaderSystem.ShaderEffect fx;
		/// <summary>Static Length+DeflateStream compressed shader byte code (Windows)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {236,33,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,63,244,155,202,239,191,54,254,166,255,175,244,239,95,65,255,255,117,244,179,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,251,63,191,30,253,255,247,191,108,126,255,233,175,145,62,68,124,253,155,253,26,18,107,251,207,175,69,255,71,40,222,253,220,196,227,191,62,253,255,245,60,155,229,245,175,241,7,253,154,250,249,175,173,255,199,59,169,247,206,223,166,49,61,218,252,117,250,59,224,255,41,250,253,31,68,159,253,12,253,255,79,213,191,255,44,250,253,79,243,218,153,231,255,166,199,244,255,103,241,151,255,247,255,253,127,253,223,191,205,175,113,242,230,248,201,239,68,127,254,184,126,230,189,146,226,243,85,243,251,239,253,254,59,191,198,23,197,180,174,154,234,188,77,183,94,221,73,191,253,252,245,243,84,70,144,158,84,139,85,81,210,47,15,199,123,159,142,31,222,223,27,239,29,236,239,255,26,191,139,116,79,227,251,77,255,166,95,147,127,255,237,232,247,255,251,111,250,117,121,152,191,254,31,68,24,209,223,255,153,124,247,27,252,166,244,247,127,246,7,249,189,3,95,243,251,127,247,155,1,183,255,139,240,253,21,191,182,193,247,47,252,77,229,51,140,233,119,226,86,191,70,138,177,239,252,26,210,241,175,160,127,15,232,231,183,127,13,51,95,127,237,95,251,107,82,215,191,38,81,24,249,145,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,255,141,207,255,23,112,186,252,154,185,130,159,248,53,126,141,95,247,87,252,26,191,233,95,68,233,130,223,195,135,103,114,8,148,77,249,147,126,75,254,253,215,164,223,127,141,63,233,215,226,28,2,255,254,7,227,239,177,124,247,55,253,26,156,111,192,119,191,193,31,244,50,253,191,9,222,175,241,55,253,58,156,82,65,219,255,251,15,250,229,191,198,87,127,209,47,255,53,126,141,191,232,215,229,207,126,61,250,236,171,63,233,101,250,47,113,59,201,75,252,218,128,73,255,255,175,255,160,95,135,83,61,248,251,63,251,131,126,13,133,245,107,164,255,25,255,68,31,148,215,248,143,254,34,247,55,245,255,235,252,65,148,87,248,139,126,3,193,237,31,194,123,255,211,175,241,203,245,239,95,139,255,254,159,237,223,191,14,255,253,191,216,191,127,3,254,251,151,209,223,200,192,252,63,1,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'colourData'</summary>
		private static int cid0;
		/// <summary>Set the shader array value 'float4 colourData[80]'</summary><param name="value"/><param name="readIndex"/><param name="writeIndex"/><param name="count"/>
		public void SetColourData(Microsoft.Xna.Framework.Vector4[] value, uint readIndex, uint writeIndex, uint count)
		{
			Microsoft.Xna.Framework.Vector4 val;
			int i;
			uint ri;
			uint wi;
			ri = readIndex;
			wi = writeIndex;
			if ((value == null))
			{
				throw new System.ArgumentNullException("value");
			}
			if ((((ri + count) 
						> value.Length) 
						|| ((wi + count) 
						> 80)))
			{
				throw new System.ArgumentException("Invalid range");
			}
			for (i = 0; ((i < count) 
						&& (wi < 80)); i = (i + 1))
			{
				val = value[ri];
				this.vreg[((wi * 1) 
							+ 160)] = val;
				ri = (ri + 1);
				wi = (wi + 1);
			}
			this.vreg_change = true;
		}
		/// <summary>Set and copy the array data for the shader value 'float4 colourData[80]'</summary>
		public Microsoft.Xna.Framework.Vector4[] ColourData
		{
			set
			{
				this.SetColourData(value, 0, 0, ((uint)(value.Length)));
			}
		}
		/// <summary>Name ID for 'positionData'</summary>
		private static int cid1;
		/// <summary>Set the shader array value 'float4 positionData[80]'</summary><param name="value"/><param name="readIndex"/><param name="writeIndex"/><param name="count"/>
		public void SetPositionData(Microsoft.Xna.Framework.Vector4[] value, uint readIndex, uint writeIndex, uint count)
		{
			Microsoft.Xna.Framework.Vector4 val;
			int i;
			uint ri;
			uint wi;
			ri = readIndex;
			wi = writeIndex;
			if ((value == null))
			{
				throw new System.ArgumentNullException("value");
			}
			if ((((ri + count) 
						> value.Length) 
						|| ((wi + count) 
						> 80)))
			{
				throw new System.ArgumentException("Invalid range");
			}
			for (i = 0; ((i < count) 
						&& (wi < 80)); i = (i + 1))
			{
				val = value[ri];
				this.vreg[((wi * 1) 
							+ 0)] = val;
				ri = (ri + 1);
				wi = (wi + 1);
			}
			this.vreg_change = true;
		}
		/// <summary>Set and copy the array data for the shader value 'float4 positionData[80]'</summary>
		public Microsoft.Xna.Framework.Vector4[] PositionData
		{
			set
			{
				this.SetPositionData(value, 0, 0, ((uint)(value.Length)));
			}
		}
		/// <summary>Name ID for 'velocityData'</summary>
		private static int cid2;
		/// <summary>Set the shader array value 'float4 velocityData[80]'</summary><param name="value"/><param name="readIndex"/><param name="writeIndex"/><param name="count"/>
		public void SetVelocityData(Microsoft.Xna.Framework.Vector4[] value, uint readIndex, uint writeIndex, uint count)
		{
			Microsoft.Xna.Framework.Vector4 val;
			int i;
			uint ri;
			uint wi;
			ri = readIndex;
			wi = writeIndex;
			if ((value == null))
			{
				throw new System.ArgumentNullException("value");
			}
			if ((((ri + count) 
						> value.Length) 
						|| ((wi + count) 
						> 80)))
			{
				throw new System.ArgumentException("Invalid range");
			}
			for (i = 0; ((i < count) 
						&& (wi < 80)); i = (i + 1))
			{
				val = value[ri];
				this.vreg[((wi * 1) 
							+ 80)] = val;
				ri = (ri + 1);
				wi = (wi + 1);
			}
			this.vreg_change = true;
		}
		/// <summary>Set and copy the array data for the shader value 'float4 velocityData[80]'</summary>
		public Microsoft.Xna.Framework.Vector4[] VelocityData
		{
			set
			{
				this.SetVelocityData(value, 0, 0, ((uint)(value.Length)));
			}
		}
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid3;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[244] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float2 velocityScale'</summary>
		public Microsoft.Xna.Framework.Vector2 VelocityScale
		{
			set
			{
				this.SetVelocityScale(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc0;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[245];
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityParticlesColour_LinesCpu.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesCpu.cid3))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector4[]' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Vector4[] value)
		{
			if ((DrawVelocityParticlesColour_LinesCpu.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityParticlesColour_LinesCpu.cid0))
			{
				this.SetColourData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesCpu.cid1))
			{
				this.SetPositionData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			if ((id == DrawVelocityParticlesColour_LinesCpu.cid2))
			{
				this.SetVelocityData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			return false;
		}
	}
}
#endif
