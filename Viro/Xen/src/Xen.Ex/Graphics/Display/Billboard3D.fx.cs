// XenFX
// Assembly = Xen.Graphics.ShaderSystem.CustomTool, Version=7.0.1.1, Culture=neutral, PublicKeyToken=e706afd07878dfca
// SourceFile = Billboard3D.fx
// Namespace = Xen.Ex.Graphics.Display

#if XBOX360
namespace Xen.Ex.Graphics.Display
{
	
	/// <summary><para>Technique 'DrawBillboardParticles_GpuTex3D' generated from file 'Billboard3D.fx'</para><para>Vertex Shader: approximately 56 instruction slots used (4 texture, 52 arithmetic), 10 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawBillboardParticles_GpuTex3D : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawBillboardParticles_GpuTex3D' shader</summary>
		public DrawBillboardParticles_GpuTex3D()
		{
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
			this.pts[0] = ((Xen.Graphics.TextureSamplerState)(197));
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawBillboardParticles_GpuTex3D.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawBillboardParticles_GpuTex3D.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawBillboardParticles_GpuTex3D.cid1 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawBillboardParticles_GpuTex3D.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawBillboardParticles_GpuTex3D.sid1 = state.GetNameUniqueID("PositionSampler");
			DrawBillboardParticles_GpuTex3D.sid2 = state.GetNameUniqueID("VelocitySampler");
			DrawBillboardParticles_GpuTex3D.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawBillboardParticles_GpuTex3D.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawBillboardParticles_GpuTex3D.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawBillboardParticles_GpuTex3D.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'viewPoint'
			this.vreg_change = (this.vreg_change | state.SetViewPointVector3(ref this.vreg[7], ref this.sc0));
			Microsoft.Xna.Framework.Vector4 unused = new Microsoft.Xna.Framework.Vector4();
			// Set the value for attribute 'worldMatrix'
			this.vreg_change = (this.vreg_change | state.SetWorldMatrix(ref this.vreg[4], ref this.vreg[5], ref this.vreg[6], ref unused, ref this.sc1));
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc2));
			// Assign pixel shader textures and samplers
			if ((ic | this.ptc))
			{
				state.SetPixelShaderSamplers(this.ptx, this.pts);
				this.ptc = false;
			}
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawBillboardParticles_GpuTex3D.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawBillboardParticles_GpuTex3D.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawBillboardParticles_GpuTex3D.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawBillboardParticles_GpuTex3D.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawBillboardParticles_GpuTex3D.fx, DrawBillboardParticles_GpuTex3D.fxb, 51, 8);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return ((this.vreg_change | this.vtc) 
						| this.ptc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawBillboardParticles_GpuTex3D.vin[i]));
			index = DrawBillboardParticles_GpuTex3D.vin[(i + 1)];
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
				return new byte[] {4,188,240,11,207,131,0,1,16,136,0,8,254,255,9,1,0,0,1,168,135,0,1,10,131,0,1,4,131,0,1,28,143,0,17,17,95,95,117,110,117,115,101,100,95,115,97,109,112,108,101,114,135,0,1,3,131,0,1,1,131,0,1,240,135,0,1,10,131,0,1,4,131,0,1,1,229,0,0,190,0,0,1,6,1,95,1,118,1,115,1,95,1,99,134,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,20,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,48,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,56,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,49,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,92,143,0,0,1,7,1,95,1,112,1,115,1,95,1,115,1,48,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,5,131,0,0,1,1,131,0,0,1,7,131,0,0,1,3,131,0,0,1,4,131,0,0,1,24,139,0,0,1,52,131,0,0,1,80,139,0,0,1,252,1,0,1,0,1,1,1,16,138,0,0,1,1,1,32,1,0,1,0,1,1,1,52,138,0,0,1,1,1,68,1,0,1,0,1,1,1,88,138,0,0,1,1,1,156,135,0,0,1,1,1,0,1,0,1,1,1,152,135,0,0,1,2,131,0,0,1,92,134,0,0,1,1,1,108,1,0,1,0,1,1,1,104,131,0,0,1,93,134,0,0,1,1,1,132,1,0,1,0,1,1,1,128,135,0,0,1,2,136,0,0,132,255,0,131,0,0,1,1,134,0,0,1,1,1,0,1,16,1,42,1,17,132,0,0,1,172,131,0,0,1,84,135,0,0,1,36,135,0,0,1,132,139,0,0,1,92,131,0,0,1,28,131,0,0,1,79,1,255,1,255,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,72,131,0,0,1,48,1,0,1,3,131,0,0,1,1,133,0,0,1,56,132,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,84,1,16,1,0,1,2,132,0,0,1,4,134,0,0,1,24,1,66,1,0,1,3,1,0,1,3,131,0,0,1,1,1,0,1,0,1,48,1,80,1,0,1,0,1,241,1,81,1,0,1,1,1,16,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,48,1,3,1,0,1,0,1,34,133,0,0,1,16,1,8,1,32,1,1,1,31,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,22,1,16,133,0,0,1,27,1,226,1,0,1,0,1,1,1,20,1,14,131,0,0,1,252,1,252,1,27,1,225,1,2,1,1,1,2,1,12,1,135,1,128,1,0,1,0,1,21,1,108,1,108,1,225,151,0,0,132,255,0,138,0,0,1,4,1,44,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,208,1,0,1,0,1,2,1,92,135,0,0,1,36,1,0,1,0,1,1,1,108,1,0,1,0,1,1,1,148,138,0,0,1,1,1,68,131,0,0,1,28,1,0,1,0,1,1,1,54,1,255,1,254,1,3,132,0,0,1,3,131,0,0,1,28,134,0,0,1,1,1,47,131,0,0,1,88,1,0,1,2,131,0,0,1,10,133,0,0,1,96,131,0,0,1,112,1,0,1,0,1,1,1,16,1,0,1,3,131,0,0,1,1,132,0,0,1,1,1,24,134,0,0,1,1,1,40,1,0,1,3,1,0,1,1,1,0,1,1,132,0,0,1,1,1,24,132,0,0,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,10,229,0,0,193,0,0,1,95,1,118,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,118,1,115,1,95,1,115,1,49,1,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,1,171,135,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,2,1,28,1,0,1,17,1,0,1,6,138,0,0,1,24,1,66,131,0,0,1,1,131,0,0,1,1,131,0,0,1,2,1,0,1,0,1,2,1,144,131,0,0,1,5,1,0,1,0,1,48,1,80,1,0,1,1,1,241,1,81,1,0,1,0,1,16,1,43,1,0,1,0,1,16,1,42,160,0,0,1,192,1,73,1,15,1,219,1,64,1,201,1,15,1,219,136,0,0,1,62,1,34,1,249,1,131,1,63,135,0,0,1,63,1,128,1,0,1,0,1,16,1,9,1,96,1,5,1,64,1,11,1,18,1,0,1,18,1,0,1,0,1,80,132,0,0,1,96,1,15,1,194,1,0,1,18,133,0,0,1,96,1,21,1,96,1,27,1,18,1,0,1,18,133,0,0,1,96,1,33,1,48,1,39,1,18,1,0,1,18,135,0,0,1,32,1,42,1,196,1,0,1,34,131,0,0,1,5,1,248,1,16,131,0,0,1,4,1,120,132,0,0,1,180,1,35,1,0,1,2,1,0,1,176,1,177,1,192,1,1,1,9,1,255,1,9,1,168,1,64,133,0,0,1,65,1,194,1,0,1,0,1,9,1,52,1,18,131,0,0,1,198,1,0,1,198,1,232,1,128,1,0,1,0,1,200,1,8,1,0,1,2,1,1,1,198,1,177,1,177,1,237,131,0,0,1,168,1,64,1,2,132,0,0,1,128,1,194,1,0,1,0,1,9,1,200,1,3,131,0,0,1,110,1,25,1,0,1,224,1,2,1,2,1,0,1,184,1,64,134,0,0,1,194,1,0,1,0,1,255,1,101,1,24,1,16,1,1,1,15,1,31,1,255,1,223,1,0,1,0,1,64,1,0,1,101,1,8,1,48,1,1,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,200,1,15,1,0,1,4,1,0,1,6,1,190,1,27,1,76,1,255,1,3,1,255,1,200,1,2,1,0,1,2,1,0,1,62,1,0,1,0,1,111,1,5,2,4,0,3,200,4,0,4,2,0,62,0,5,0,111,6,4,0,2,200,14,131,0,6,1,188,177,139,1,255,7,255,44,17,0,2,0,62,8,0,177,111,4,4,0,200,1,131,0,8,108,177,108,139,0,254,254,200,9,7,0,4,2,192,192,0,160,2,10,7,0,200,7,0,2,0,101,192,0,11,161,4,8,0,200,7,0,5,1,192,101,12,192,171,4,8,2,200,1,0,2,0,192,192,13,0,240,5,5,0,88,24,2,2,0,108,198,108,14,166,128,255,130,200,7,0,5,0,180,108,0,225,5,15,2,0,200,7,0,2,0,205,190,0,225,5,4,0,200,16,7,0,6,1,180,101,192,235,5,4,2,196,18,2,2,0,17,190,190,108,240,6,6,0,88,39,2,4,0,98,108,177,225,5,18,2,130,192,23,0,6,0,192,177,108,225,6,2,0,200,7,0,4,19,0,192,108,192,235,6,0,4,200,7,0,2,0,192,108,0,225,6,2,20,0,200,7,0,2,1,98,108,192,235,5,0,2,200,7,0,2,0,192,27,21,0,225,2,1,0,200,7,0,1,0,192,198,192,235,4,1,2,200,7,0,2,22,0,192,27,192,235,1,3,3,200,1,128,62,0,62,62,0,111,0,2,0,200,2,23,128,62,0,62,62,0,111,1,2,0,200,4,128,62,0,62,62,0,111,2,2,0,200,15,8,128,62,0,62,62,0,111,3,2,0,36,254,192,1,131,0,14,108,226,0,0,128,200,3,128,0,0,26,26,0,226,142,0,1,0};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 invTextureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 InvTextureSizeOffset
		{
			set
			{
				this.SetInvTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 worldSpaceYAxis'</summary>
		public Microsoft.Xna.Framework.Vector3 WorldSpaceYAxis
		{
			set
			{
				this.SetWorldSpaceYAxis(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'viewPoint'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute 'worldMatrix'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc2;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D DisplaySampler'</summary>
		public Xen.Graphics.TextureSamplerState DisplaySampler
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
		/// <summary>Get/Set the Bound texture for 'Texture2D DisplayTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D DisplayTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.ptx[0]));
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
		/// <summary>Name uid for sampler for 'Sampler2D DisplaySampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid1;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid2;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Name uid for texture for 'Texture2D DisplayTexture'</summary>
		static int tid4;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>Pixel samplers/textures changed</summary>
		bool ptc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[10];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[2];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[2];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[1];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[1];
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_GpuTex3D.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D.cid1))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_GpuTex3D.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D.sid1))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D.sid2))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_GpuTex3D.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawBillboardParticlesColour_GpuTex3D' generated from file 'Billboard3D.fx'</para><para>Vertex Shader: approximately 58 instruction slots used (6 texture, 52 arithmetic), 10 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawBillboardParticlesColour_GpuTex3D : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawBillboardParticlesColour_GpuTex3D' shader</summary>
		public DrawBillboardParticlesColour_GpuTex3D()
		{
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
			this.pts[0] = ((Xen.Graphics.TextureSamplerState)(197));
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[2] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawBillboardParticlesColour_GpuTex3D.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawBillboardParticlesColour_GpuTex3D.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawBillboardParticlesColour_GpuTex3D.cid1 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawBillboardParticlesColour_GpuTex3D.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawBillboardParticlesColour_GpuTex3D.sid1 = state.GetNameUniqueID("ColourSampler");
			DrawBillboardParticlesColour_GpuTex3D.sid2 = state.GetNameUniqueID("PositionSampler");
			DrawBillboardParticlesColour_GpuTex3D.sid3 = state.GetNameUniqueID("VelocitySampler");
			DrawBillboardParticlesColour_GpuTex3D.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawBillboardParticlesColour_GpuTex3D.tid1 = state.GetNameUniqueID("ColourTexture");
			DrawBillboardParticlesColour_GpuTex3D.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawBillboardParticlesColour_GpuTex3D.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawBillboardParticlesColour_GpuTex3D.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'viewPoint'
			this.vreg_change = (this.vreg_change | state.SetViewPointVector3(ref this.vreg[7], ref this.sc0));
			Microsoft.Xna.Framework.Vector4 unused = new Microsoft.Xna.Framework.Vector4();
			// Set the value for attribute 'worldMatrix'
			this.vreg_change = (this.vreg_change | state.SetWorldMatrix(ref this.vreg[4], ref this.vreg[5], ref this.vreg[6], ref unused, ref this.sc1));
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc2));
			// Assign pixel shader textures and samplers
			if ((ic | this.ptc))
			{
				state.SetPixelShaderSamplers(this.ptx, this.pts);
				this.ptc = false;
			}
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawBillboardParticlesColour_GpuTex3D.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawBillboardParticlesColour_GpuTex3D.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawBillboardParticlesColour_GpuTex3D.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawBillboardParticlesColour_GpuTex3D.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawBillboardParticlesColour_GpuTex3D.fx, DrawBillboardParticlesColour_GpuTex3D.fxb, 53, 8);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return ((this.vreg_change | this.vtc) 
						| this.ptc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawBillboardParticlesColour_GpuTex3D.vin[i]));
			index = DrawBillboardParticlesColour_GpuTex3D.vin[(i + 1)];
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
				return new byte[] {4,188,240,11,207,131,0,1,16,136,0,8,254,255,9,1,0,0,1,204,135,0,1,10,131,0,1,4,131,0,1,28,143,0,17,17,95,95,117,110,117,115,101,100,95,115,97,109,112,108,101,114,135,0,1,3,131,0,1,1,131,0,1,240,135,0,1,10,131,0,1,4,131,0,1,1,229,0,0,190,0,0,1,6,1,95,1,118,1,115,1,95,1,99,134,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,20,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,48,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,56,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,49,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,92,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,50,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,128,143,0,0,1,7,1,95,1,112,1,115,1,95,1,115,1,48,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,6,131,0,0,1,1,131,0,0,1,8,131,0,0,1,3,131,0,0,1,4,131,0,0,1,24,139,0,0,1,52,131,0,0,1,80,139,0,0,1,252,1,0,1,0,1,1,1,16,138,0,0,1,1,1,32,1,0,1,0,1,1,1,52,138,0,0,1,1,1,68,1,0,1,0,1,1,1,88,138,0,0,1,1,1,104,1,0,1,0,1,1,1,124,138,0,0,1,1,1,192,135,0,0,1,1,1,0,1,0,1,1,1,188,135,0,0,1,2,131,0,0,1,92,134,0,0,1,1,1,144,1,0,1,0,1,1,1,140,131,0,0,1,93,134,0,0,1,1,1,168,1,0,1,0,1,1,1,164,135,0,0,1,2,136,0,0,132,255,0,131,0,0,1,1,134,0,0,1,1,1,0,1,16,1,42,1,17,132,0,0,1,172,131,0,0,1,84,135,0,0,1,36,135,0,0,1,132,139,0,0,1,92,131,0,0,1,28,131,0,0,1,79,1,255,1,255,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,72,131,0,0,1,48,1,0,1,3,131,0,0,1,1,133,0,0,1,56,132,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,84,1,16,1,0,1,2,132,0,0,1,4,134,0,0,1,24,1,66,1,0,1,3,1,0,1,3,131,0,0,1,1,1,0,1,0,1,48,1,80,1,0,1,0,1,241,1,81,1,0,1,1,1,16,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,48,1,3,1,0,1,0,1,34,133,0,0,1,16,1,8,1,32,1,1,1,31,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,22,1,16,133,0,0,1,27,1,226,1,0,1,0,1,1,1,20,1,14,131,0,0,1,252,1,252,1,27,1,225,1,2,1,1,1,2,1,12,1,135,1,128,1,0,1,0,1,21,1,108,1,108,1,225,151,0,0,132,255,0,138,0,0,1,4,1,84,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,236,1,0,1,0,1,2,1,104,135,0,0,1,36,1,0,1,0,1,1,1,136,1,0,1,0,1,1,1,176,138,0,0,1,1,1,96,131,0,0,1,28,1,0,1,0,1,1,1,81,1,255,1,254,1,3,132,0,0,1,4,131,0,0,1,28,134,0,0,1,1,1,74,131,0,0,1,108,1,0,1,2,131,0,0,1,10,133,0,0,1,116,131,0,0,1,132,1,0,1,0,1,1,1,36,1,0,1,3,131,0,0,1,1,132,0,0,1,1,1,44,134,0,0,1,1,1,60,1,0,1,3,1,0,1,1,1,0,1,1,132,0,0,1,1,1,44,134,0,0,1,1,1,67,1,0,1,3,1,0,1,2,1,0,1,1,132,0,0,1,1,1,44,132,0,0,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,2,1,0,3,4,0,10,229,0,0,193,0,0,1,95,1,118,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,118,1,115,1,95,1,115,1,49,1,0,1,95,1,118,1,115,1,95,1,115,1,50,1,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,131,171,0,135,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,2,1,40,1,0,1,17,1,0,1,7,138,0,0,1,24,1,66,131,0,0,1,1,131,0,0,1,1,131,0,0,1,2,1,0,1,0,1,2,1,144,131,0,0,1,5,1,0,1,0,1,48,1,80,1,0,1,1,1,241,1,81,1,0,1,0,1,16,1,43,1,0,1,0,1,16,1,44,160,0,0,1,192,1,73,1,15,1,219,1,64,1,201,1,15,1,219,136,0,0,1,62,1,34,1,249,1,131,1,63,135,0,0,1,63,1,128,1,0,1,0,1,16,1,9,1,96,1,5,1,80,1,11,1,18,1,0,1,18,1,0,1,1,1,80,132,0,0,1,96,1,16,1,194,1,0,1,18,133,0,0,1,96,1,22,1,96,1,28,1,18,1,0,1,18,133,0,0,1,96,1,34,1,48,1,40,1,18,1,0,1,18,135,0,0,1,32,1,43,1,196,1,0,1,34,131,0,0,1,5,1,248,1,16,131,0,0,1,4,1,120,132,0,0,1,180,1,35,1,0,1,2,1,0,1,176,1,177,1,192,1,1,1,9,1,255,1,9,1,168,1,64,133,0,0,1,65,1,194,1,0,1,0,1,9,1,52,1,18,131,0,0,1,198,1,0,1,198,1,232,1,128,1,0,1,0,1,200,1,8,1,0,1,2,1,1,1,198,1,177,1,177,1,237,131,0,0,1,168,1,64,1,2,132,0,0,1,128,1,194,1,0,1,0,1,9,1,200,1,3,131,0,0,1,110,1,25,1,0,1,224,1,2,1,2,1,0,1,184,1,64,134,0,0,1,194,1,0,1,0,1,255,1,101,1,24,1,32,1,1,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,101,1,40,1,16,1,1,1,15,1,31,1,255,1,223,1,0,1,0,1,64,1,0,1,101,1,8,1,64,1,1,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,200,1,15,1,0,1,5,2,0,6,3,190,27,76,4,255,4,255,200,5,2,0,3,0,62,6,0,0,111,5,5,0,7,200,4,0,3,0,62,0,7,0,111,6,5,0,200,14,131,0,8,1,188,177,139,1,255,255,44,9,17,0,3,0,62,0,177,111,4,4,5,0,200,1,131,0,10,108,177,108,139,0,254,254,200,7,0,11,5,2,192,192,0,160,3,7,0,200,7,12,0,3,0,101,192,0,161,5,8,0,200,7,13,0,6,1,192,101,192,171,5,8,3,200,1,0,14,3,0,192,192,0,240,6,6,0,88,24,3,3,0,15,108,198,108,166,128,255,131,200,7,0,6,0,180,108,0,16,225,6,3,0,200,7,0,3,0,205,190,0,225,6,5,0,17,200,7,0,7,1,180,101,192,235,6,5,3,196,18,3,3,0,18,190,190,108,240,7,7,0,88,39,3,5,0,98,108,177,225,6,3,19,131,192,23,0,7,0,192,177,108,225,7,3,0,200,7,0,5,0,192,20,108,192,235,7,0,5,200,7,0,3,0,192,108,0,225,7,3,0,200,7,21,0,3,1,98,108,192,235,6,0,3,200,7,0,3,0,192,27,0,225,3,1,22,0,200,7,0,1,0,192,198,192,235,5,1,3,200,7,0,3,0,192,27,192,235,23,1,4,4,200,1,128,62,0,62,62,0,111,0,3,0,200,2,128,62,0,62,62,0,24,111,1,3,0,200,4,128,62,0,62,62,0,111,2,3,0,200,8,128,62,0,62,62,0,13,111,3,3,0,200,3,128,0,0,26,26,0,226,131,0,4,200,15,128,1,132,0,3,226,2,2,140,0,1,0};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 invTextureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 InvTextureSizeOffset
		{
			set
			{
				this.SetInvTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 worldSpaceYAxis'</summary>
		public Microsoft.Xna.Framework.Vector3 WorldSpaceYAxis
		{
			set
			{
				this.SetWorldSpaceYAxis(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'viewPoint'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute 'worldMatrix'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc2;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D DisplaySampler'</summary>
		public Xen.Graphics.TextureSamplerState DisplaySampler
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
		/// <summary>Get/Set the Bound texture for 'Texture2D DisplayTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D DisplayTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.ptx[0]));
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
		/// <summary>Name uid for sampler for 'Sampler2D DisplaySampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D ColourSampler'</summary>
		static int sid1;
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid2;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid3;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D ColourTexture'</summary>
		static int tid1;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Name uid for texture for 'Texture2D DisplayTexture'</summary>
		static int tid4;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>Pixel samplers/textures changed</summary>
		bool ptc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[10];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[3];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[3];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[1];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[1];
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.cid1))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.sid1))
			{
				this.ColourSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.sid2))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.sid3))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.tid1))
			{
				this.ColourTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawBillboardParticles_GpuTex3D_UserOffset' generated from file 'Billboard3D.fx'</para><para>Vertex Shader: approximately 59 instruction slots used (6 texture, 53 arithmetic), 10 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawBillboardParticles_GpuTex3D_UserOffset : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawBillboardParticles_GpuTex3D_UserOffset' shader</summary>
		public DrawBillboardParticles_GpuTex3D_UserOffset()
		{
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
			this.pts[0] = ((Xen.Graphics.TextureSamplerState)(197));
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[2] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawBillboardParticles_GpuTex3D_UserOffset.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawBillboardParticles_GpuTex3D_UserOffset.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawBillboardParticles_GpuTex3D_UserOffset.cid1 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawBillboardParticles_GpuTex3D_UserOffset.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawBillboardParticles_GpuTex3D_UserOffset.sid1 = state.GetNameUniqueID("PositionSampler");
			DrawBillboardParticles_GpuTex3D_UserOffset.sid2 = state.GetNameUniqueID("UserSampler");
			DrawBillboardParticles_GpuTex3D_UserOffset.sid3 = state.GetNameUniqueID("VelocitySampler");
			DrawBillboardParticles_GpuTex3D_UserOffset.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawBillboardParticles_GpuTex3D_UserOffset.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawBillboardParticles_GpuTex3D_UserOffset.tid3 = state.GetNameUniqueID("UserTexture");
			DrawBillboardParticles_GpuTex3D_UserOffset.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawBillboardParticles_GpuTex3D_UserOffset.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'viewPoint'
			this.vreg_change = (this.vreg_change | state.SetViewPointVector3(ref this.vreg[7], ref this.sc0));
			Microsoft.Xna.Framework.Vector4 unused = new Microsoft.Xna.Framework.Vector4();
			// Set the value for attribute 'worldMatrix'
			this.vreg_change = (this.vreg_change | state.SetWorldMatrix(ref this.vreg[4], ref this.vreg[5], ref this.vreg[6], ref unused, ref this.sc1));
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc2));
			// Assign pixel shader textures and samplers
			if ((ic | this.ptc))
			{
				state.SetPixelShaderSamplers(this.ptx, this.pts);
				this.ptc = false;
			}
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawBillboardParticles_GpuTex3D_UserOffset.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawBillboardParticles_GpuTex3D_UserOffset.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawBillboardParticles_GpuTex3D_UserOffset.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawBillboardParticles_GpuTex3D_UserOffset.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawBillboardParticles_GpuTex3D_UserOffset.fx, DrawBillboardParticles_GpuTex3D_UserOffset.fxb, 54, 8);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return ((this.vreg_change | this.vtc) 
						| this.ptc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawBillboardParticles_GpuTex3D_UserOffset.vin[i]));
			index = DrawBillboardParticles_GpuTex3D_UserOffset.vin[(i + 1)];
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
				return new byte[] {4,188,240,11,207,131,0,1,16,136,0,8,254,255,9,1,0,0,1,204,135,0,1,10,131,0,1,4,131,0,1,28,143,0,17,17,95,95,117,110,117,115,101,100,95,115,97,109,112,108,101,114,135,0,1,3,131,0,1,1,131,0,1,240,135,0,1,10,131,0,1,4,131,0,1,1,229,0,0,190,0,0,1,6,1,95,1,118,1,115,1,95,1,99,134,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,20,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,48,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,56,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,49,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,92,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,50,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,128,143,0,0,1,7,1,95,1,112,1,115,1,95,1,115,1,48,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,6,131,0,0,1,1,131,0,0,1,8,131,0,0,1,3,131,0,0,1,4,131,0,0,1,24,139,0,0,1,52,131,0,0,1,80,139,0,0,1,252,1,0,1,0,1,1,1,16,138,0,0,1,1,1,32,1,0,1,0,1,1,1,52,138,0,0,1,1,1,68,1,0,1,0,1,1,1,88,138,0,0,1,1,1,104,1,0,1,0,1,1,1,124,138,0,0,1,1,1,192,135,0,0,1,1,1,0,1,0,1,1,1,188,135,0,0,1,2,131,0,0,1,92,134,0,0,1,1,1,144,1,0,1,0,1,1,1,140,131,0,0,1,93,134,0,0,1,1,1,168,1,0,1,0,1,1,1,164,135,0,0,1,2,136,0,0,132,255,0,131,0,0,1,1,134,0,0,1,1,1,0,1,16,1,42,1,17,132,0,0,1,172,131,0,0,1,84,135,0,0,1,36,135,0,0,1,132,139,0,0,1,92,131,0,0,1,28,131,0,0,1,79,1,255,1,255,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,72,131,0,0,1,48,1,0,1,3,131,0,0,1,1,133,0,0,1,56,132,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,84,1,16,1,0,1,2,132,0,0,1,4,134,0,0,1,24,1,66,1,0,1,3,1,0,1,3,131,0,0,1,1,1,0,1,0,1,48,1,80,1,0,1,0,1,241,1,81,1,0,1,1,1,16,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,48,1,3,1,0,1,0,1,34,133,0,0,1,16,1,8,1,32,1,1,1,31,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,22,1,16,133,0,0,1,27,1,226,1,0,1,0,1,1,1,20,1,14,131,0,0,1,252,1,252,1,27,1,225,1,2,1,1,1,2,1,12,1,135,1,128,1,0,1,0,1,21,1,108,1,108,1,225,151,0,0,132,255,0,138,0,0,1,4,1,84,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,236,1,0,1,0,1,2,1,104,135,0,0,1,36,1,0,1,0,1,1,1,136,1,0,1,0,1,1,1,176,138,0,0,1,1,1,96,131,0,0,1,28,1,0,1,0,1,1,1,81,1,255,1,254,1,3,132,0,0,1,4,131,0,0,1,28,134,0,0,1,1,1,74,131,0,0,1,108,1,0,1,2,131,0,0,1,10,133,0,0,1,116,131,0,0,1,132,1,0,1,0,1,1,1,36,1,0,1,3,131,0,0,1,1,132,0,0,1,1,1,44,134,0,0,1,1,1,60,1,0,1,3,1,0,1,1,1,0,1,1,132,0,0,1,1,1,44,134,0,0,1,1,1,67,1,0,1,3,1,0,1,2,1,0,1,1,132,0,0,1,1,1,44,132,0,0,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,2,1,0,3,4,0,10,229,0,0,193,0,0,1,95,1,118,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,118,1,115,1,95,1,115,1,49,1,0,1,95,1,118,1,115,1,95,1,115,1,50,1,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,131,171,0,135,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,2,1,40,1,0,1,17,1,0,1,7,138,0,0,1,24,1,66,131,0,0,1,1,131,0,0,1,1,131,0,0,1,2,1,0,1,0,1,2,1,144,131,0,0,1,5,1,0,1,0,1,48,1,80,1,0,1,1,1,241,1,81,1,0,1,0,1,16,1,44,1,0,1,0,1,16,1,43,160,0,0,1,192,1,73,1,15,1,219,1,64,1,201,1,15,1,219,136,0,0,1,62,1,34,1,249,1,131,1,63,135,0,0,1,63,1,128,1,0,1,0,1,16,1,9,1,96,1,5,1,80,1,11,1,18,1,0,1,18,1,0,1,1,1,80,132,0,0,1,96,1,16,1,194,1,0,1,18,133,0,0,1,96,1,22,1,96,1,28,1,18,1,0,1,18,133,0,0,1,96,1,34,1,48,1,40,1,18,1,0,1,18,135,0,0,1,32,1,43,1,196,1,0,1,34,131,0,0,1,5,1,248,1,16,131,0,0,1,4,1,120,132,0,0,1,180,1,35,1,0,1,2,1,0,1,176,1,177,1,192,1,1,1,9,1,255,1,9,1,168,1,64,133,0,0,1,65,1,194,1,0,1,0,1,9,1,52,1,18,131,0,0,1,198,1,0,1,198,1,232,1,128,1,0,1,0,1,200,1,8,1,0,1,2,1,1,1,198,1,177,1,177,1,237,131,0,0,1,168,1,64,1,2,132,0,0,1,128,1,194,1,0,1,0,1,9,1,200,1,3,131,0,0,1,110,1,25,1,0,1,224,1,2,1,2,1,0,1,184,1,64,134,0,0,1,194,1,0,1,0,1,255,1,101,1,24,1,16,1,1,1,15,1,31,1,255,1,223,1,0,1,0,1,64,1,0,1,101,1,8,1,32,1,1,1,15,1,31,1,240,1,139,1,0,1,0,1,64,1,0,1,101,1,40,1,0,1,1,1,15,1,31,1,254,1,209,1,0,1,0,1,64,1,0,1,36,1,135,1,3,1,3,2,0,195,3,192,108,224,4,2,0,128,200,1,14,131,0,5,1,188,177,139,1,6,255,255,200,2,0,4,7,0,62,62,0,111,5,3,8,0,200,4,0,4,0,62,62,9,0,111,6,3,0,44,17,0,4,10,0,62,62,177,111,4,3,0,200,1,131,0,10,108,177,108,139,0,254,254,200,7,0,11,5,2,192,192,0,160,4,7,0,200,7,12,0,4,0,101,192,0,161,5,8,0,200,14,13,0,4,1,252,65,252,171,5,8,4,200,1,0,14,4,0,21,21,0,240,4,4,0,88,24,4,2,0,15,108,198,108,166,128,255,132,200,7,0,6,0,201,108,0,16,225,4,4,0,200,7,0,4,0,205,190,0,225,6,5,0,17,200,7,0,7,1,180,101,192,235,6,5,4,196,18,4,4,0,18,190,190,108,240,7,7,0,88,39,4,5,0,98,108,177,225,6,4,19,132,192,30,0,4,0,252,177,108,225,7,4,0,200,7,0,5,0,21,20,108,192,235,4,0,5,200,7,0,4,0,21,108,0,225,4,4,0,200,7,21,0,4,1,98,108,192,235,6,0,4,200,7,0,4,0,192,27,0,225,4,1,22,0,200,7,0,1,0,192,198,192,235,5,1,4,200,7,0,2,0,192,108,192,235,23,1,2,3,200,1,128,62,0,62,62,0,111,0,2,0,200,2,128,62,0,62,62,0,24,111,1,2,0,200,4,128,62,0,62,62,0,111,2,2,0,200,8,128,62,0,62,62,0,8,111,3,2,0,36,254,192,1,131,0,14,108,226,0,0,128,200,3,128,0,0,26,26,0,226,142,0,1,0};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 invTextureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 InvTextureSizeOffset
		{
			set
			{
				this.SetInvTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 worldSpaceYAxis'</summary>
		public Microsoft.Xna.Framework.Vector3 WorldSpaceYAxis
		{
			set
			{
				this.SetWorldSpaceYAxis(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'viewPoint'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute 'worldMatrix'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc2;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D DisplaySampler'</summary>
		public Xen.Graphics.TextureSamplerState DisplaySampler
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
		/// <summary>Get/Set the Bound texture for 'Texture2D DisplayTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D DisplayTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.ptx[0]));
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
		/// <summary>Name uid for sampler for 'Sampler2D DisplaySampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid1;
		/// <summary>Name uid for sampler for 'Sampler2D UserSampler'</summary>
		static int sid2;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid3;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Name uid for texture for 'Texture2D UserTexture'</summary>
		static int tid3;
		/// <summary>Name uid for texture for 'Texture2D DisplayTexture'</summary>
		static int tid4;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>Pixel samplers/textures changed</summary>
		bool ptc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[10];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[3];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[3];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[1];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[1];
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.cid1))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.sid1))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.sid2))
			{
				this.UserSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.sid3))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.tid3))
			{
				this.UserTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawBillboardParticlesColour_GpuTex3D_UserOffset' generated from file 'Billboard3D.fx'</para><para>Vertex Shader: approximately 61 instruction slots used (8 texture, 53 arithmetic), 10 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawBillboardParticlesColour_GpuTex3D_UserOffset : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawBillboardParticlesColour_GpuTex3D_UserOffset' shader</summary>
		public DrawBillboardParticlesColour_GpuTex3D_UserOffset()
		{
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
			this.pts[0] = ((Xen.Graphics.TextureSamplerState)(197));
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[3] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[2] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.cid1 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid1 = state.GetNameUniqueID("ColourSampler");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid2 = state.GetNameUniqueID("PositionSampler");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid3 = state.GetNameUniqueID("UserSampler");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid4 = state.GetNameUniqueID("VelocitySampler");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid1 = state.GetNameUniqueID("ColourTexture");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid3 = state.GetNameUniqueID("UserTexture");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawBillboardParticlesColour_GpuTex3D_UserOffset.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'viewPoint'
			this.vreg_change = (this.vreg_change | state.SetViewPointVector3(ref this.vreg[7], ref this.sc0));
			Microsoft.Xna.Framework.Vector4 unused = new Microsoft.Xna.Framework.Vector4();
			// Set the value for attribute 'worldMatrix'
			this.vreg_change = (this.vreg_change | state.SetWorldMatrix(ref this.vreg[4], ref this.vreg[5], ref this.vreg[6], ref unused, ref this.sc1));
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc2));
			// Assign pixel shader textures and samplers
			if ((ic | this.ptc))
			{
				state.SetPixelShaderSamplers(this.ptx, this.pts);
				this.ptc = false;
			}
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawBillboardParticlesColour_GpuTex3D_UserOffset.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawBillboardParticlesColour_GpuTex3D_UserOffset.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawBillboardParticlesColour_GpuTex3D_UserOffset.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawBillboardParticlesColour_GpuTex3D_UserOffset.fx, DrawBillboardParticlesColour_GpuTex3D_UserOffset.fxb, 56, 8);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return ((this.vreg_change | this.vtc) 
						| this.ptc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawBillboardParticlesColour_GpuTex3D_UserOffset.vin[i]));
			index = DrawBillboardParticlesColour_GpuTex3D_UserOffset.vin[(i + 1)];
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
				return new byte[] {4,188,240,11,207,131,0,1,16,136,0,8,254,255,9,1,0,0,1,192,135,0,1,3,131,0,1,1,131,0,1,192,135,0,1,10,131,0,1,4,131,0,1,1,229,0,0,190,0,0,1,6,1,95,1,118,1,115,1,95,1,99,134,0,0,1,12,131,0,0,1,4,131,0,0,1,228,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,48,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,8,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,49,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,44,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,50,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,80,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,51,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,116,143,0,0,1,7,1,95,1,112,1,115,1,95,1,115,1,48,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,6,131,0,0,1,1,131,0,0,1,8,131,0,0,1,3,131,0,0,1,4,131,0,0,1,32,139,0,0,1,204,131,0,0,1,224,139,0,0,1,240,1,0,1,0,1,1,1,4,138,0,0,1,1,1,20,1,0,1,0,1,1,1,40,138,0,0,1,1,1,56,1,0,1,0,1,1,1,76,138,0,0,1,1,1,92,1,0,1,0,1,1,1,112,138,0,0,1,1,1,180,135,0,0,1,1,1,0,1,0,1,1,1,176,135,0,0,1,2,131,0,0,1,92,134,0,0,1,1,1,132,1,0,1,0,1,1,1,128,131,0,0,1,93,134,0,0,1,1,1,156,1,0,1,0,1,1,1,152,135,0,0,1,2,136,0,0,132,255,0,131,0,0,1,1,134,0,0,1,1,1,0,1,16,1,42,1,17,132,0,0,1,172,131,0,0,1,84,135,0,0,1,36,135,0,0,1,132,139,0,0,1,92,131,0,0,1,28,131,0,0,1,79,1,255,1,255,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,72,131,0,0,1,48,1,0,1,3,131,0,0,1,1,133,0,0,1,56,132,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,84,1,16,1,0,1,2,132,0,0,1,4,134,0,0,1,24,1,66,1,0,1,3,1,0,1,3,131,0,0,1,1,1,0,1,0,1,48,1,80,1,0,1,0,1,241,1,81,1,0,1,1,1,16,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,48,1,3,1,0,1,0,1,34,133,0,0,1,16,1,8,1,32,1,1,1,31,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,22,1,16,133,0,0,1,27,1,226,1,0,1,0,1,1,1,20,1,14,131,0,0,1,252,1,252,1,27,1,225,1,2,1,1,1,2,1,12,1,135,1,128,1,0,1,0,1,21,1,108,1,108,1,225,151,0,0,132,255,0,138,0,0,1,4,1,120,1,16,1,42,1,17,1,1,1,0,1,0,1,2,1,4,1,0,1,0,1,2,1,116,135,0,0,1,36,1,0,1,0,1,1,1,160,1,0,1,0,1,1,1,200,138,0,0,1,1,1,120,131,0,0,1,28,1,0,1,0,1,1,1,108,1,255,1,254,1,3,132,0,0,1,5,131,0,0,1,28,134,0,0,1,1,1,101,131,0,0,1,128,1,0,1,2,131,0,0,1,10,133,0,0,1,136,131,0,0,1,152,1,0,1,0,1,1,1,56,1,0,1,3,131,0,0,1,1,132,0,0,1,1,1,64,134,0,0,1,1,1,80,1,0,1,3,1,0,1,1,1,0,1,1,132,0,0,1,1,1,64,134,0,0,1,1,1,87,1,0,1,3,1,0,1,2,1,0,1,1,132,0,0,1,1,1,64,134,0,0,1,1,1,94,1,0,2,3,0,3,3,0,1,132,0,2,1,64,132,0,1,95,2,118,115,3,95,99,0,4,171,171,0,1,5,0,3,0,1,0,3,4,0,10,229,0,0,193,0,0,1,95,1,118,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,118,1,115,1,95,1,115,1,49,1,0,1,95,1,118,1,115,1,95,1,115,1,50,1,0,1,95,1,118,1,115,1,95,1,115,1,51,1,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,136,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,2,1,52,1,0,1,17,1,0,1,8,138,0,0,1,24,1,66,131,0,0,1,1,131,0,0,1,1,131,0,0,1,2,1,0,1,0,1,2,1,144,131,0,0,1,5,1,0,1,0,1,48,1,80,1,0,1,1,1,241,1,81,1,0,1,0,1,16,1,44,1,0,1,0,1,16,1,45,160,0,0,1,192,1,73,1,15,1,219,1,64,1,201,1,15,1,219,136,0,0,1,62,1,34,1,249,1,131,1,63,135,0,0,1,63,1,128,1,0,1,0,1,16,1,9,1,96,1,5,1,96,1,11,1,18,1,0,1,18,1,0,1,5,1,80,132,0,0,1,96,1,17,1,194,1,0,1,18,133,0,0,1,96,1,23,1,96,1,29,1,18,1,0,1,18,133,0,0,1,96,1,35,1,48,1,41,1,18,1,0,1,18,135,0,0,1,32,1,44,1,196,1,0,1,34,131,0,0,1,5,1,248,1,16,131,0,0,1,4,1,120,132,0,0,1,180,1,35,1,0,1,2,1,0,1,176,1,177,1,192,1,1,1,9,1,255,1,9,1,168,1,64,133,0,0,1,65,1,194,1,0,1,0,1,9,1,52,1,18,131,0,0,1,198,1,0,1,198,1,232,1,128,1,0,1,0,1,200,1,8,1,0,1,2,1,1,1,198,1,177,1,177,1,237,131,0,0,1,168,1,64,1,2,132,0,0,1,128,1,194,1,0,1,0,1,9,1,200,1,3,131,0,0,1,110,1,25,1,0,1,224,1,2,1,2,1,0,1,184,1,64,134,0,0,1,194,1,0,1,0,1,255,1,101,1,24,1,32,1,1,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,101,1,40,1,16,1,1,1,15,1,31,1,255,1,223,1,0,1,0,1,64,1,0,1,101,1,8,1,48,1,1,1,15,1,31,1,240,1,139,2,0,0,3,64,0,101,4,56,0,1,15,5,31,254,209,0,0,6,64,0,36,135,4,4,7,0,195,192,108,224,3,0,3,128,200,14,131,0,8,1,188,177,139,1,255,255,200,9,2,0,5,0,62,62,0,111,5,10,4,0,200,4,0,5,0,62,62,0,11,111,6,4,0,44,17,0,5,0,62,62,7,177,111,4,4,0,200,1,131,0,12,108,177,108,139,0,254,254,200,7,0,6,2,13,192,192,0,160,5,7,0,200,7,0,5,0,101,14,192,0,161,6,8,0,200,14,0,5,1,252,65,252,15,171,6,8,5,200,1,0,5,0,21,21,0,240,5,5,16,0,88,24,5,3,0,108,198,108,166,128,255,133,200,7,0,17,7,0,201,108,0,225,5,5,0,200,7,0,5,0,205,190,0,18,225,7,6,0,200,7,0,8,1,180,101,192,235,7,6,5,196,18,19,5,5,0,190,190,108,240,8,8,0,88,39,5,6,0,98,108,177,225,20,7,5,133,192,30,0,5,0,252,177,108,225,8,5,0,200,7,0,6,0,21,21,108,192,235,5,0,6,200,7,0,5,0,21,108,0,225,5,5,0,200,7,22,0,5,1,98,108,192,235,7,0,5,200,7,0,5,0,192,27,0,225,5,1,0,23,200,7,0,1,0,192,198,192,235,6,1,5,200,7,0,3,0,192,108,192,235,1,3,24,4,200,1,128,62,0,62,62,0,111,0,3,0,200,2,128,62,0,62,62,0,111,1,3,25,0,200,4,128,62,0,62,62,0,111,2,3,0,200,8,128,62,0,62,62,0,111,3,3,0,9,200,3,128,0,0,26,26,0,226,131,0,4,200,15,128,1,132,0,3,226,2,2,140,0,1,0};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 invTextureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 InvTextureSizeOffset
		{
			set
			{
				this.SetInvTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 worldSpaceYAxis'</summary>
		public Microsoft.Xna.Framework.Vector3 WorldSpaceYAxis
		{
			set
			{
				this.SetWorldSpaceYAxis(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'viewPoint'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute 'worldMatrix'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc2;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D DisplaySampler'</summary>
		public Xen.Graphics.TextureSamplerState DisplaySampler
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
		/// <summary>Get/Set the Bound texture for 'Texture2D DisplayTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D DisplayTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.ptx[0]));
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
		/// <summary>Name uid for sampler for 'Sampler2D DisplaySampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D ColourSampler'</summary>
		static int sid1;
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid2;
		/// <summary>Name uid for sampler for 'Sampler2D UserSampler'</summary>
		static int sid3;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid4;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D ColourTexture'</summary>
		static int tid1;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Name uid for texture for 'Texture2D UserTexture'</summary>
		static int tid3;
		/// <summary>Name uid for texture for 'Texture2D DisplayTexture'</summary>
		static int tid4;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>Pixel samplers/textures changed</summary>
		bool ptc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[10];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[4];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[4];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[1];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[1];
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.cid1))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid1))
			{
				this.ColourSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid2))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid3))
			{
				this.UserSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid4))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid1))
			{
				this.ColourTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid3))
			{
				this.UserTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
}
#else
namespace Xen.Ex.Graphics.Display
{
	
	/// <summary><para>Technique 'DrawBillboardParticles_GpuTex3D' generated from file 'Billboard3D.fx'</para><para>Vertex Shader: approximately 56 instruction slots used (4 texture, 52 arithmetic), 10 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawBillboardParticles_GpuTex3D : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawBillboardParticles_GpuTex3D' shader</summary>
		public DrawBillboardParticles_GpuTex3D()
		{
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
			this.pts[0] = ((Xen.Graphics.TextureSamplerState)(197));
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawBillboardParticles_GpuTex3D.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawBillboardParticles_GpuTex3D.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawBillboardParticles_GpuTex3D.cid1 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawBillboardParticles_GpuTex3D.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawBillboardParticles_GpuTex3D.sid1 = state.GetNameUniqueID("PositionSampler");
			DrawBillboardParticles_GpuTex3D.sid2 = state.GetNameUniqueID("VelocitySampler");
			DrawBillboardParticles_GpuTex3D.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawBillboardParticles_GpuTex3D.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawBillboardParticles_GpuTex3D.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawBillboardParticles_GpuTex3D.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'viewPoint'
			this.vreg_change = (this.vreg_change | state.SetViewPointVector3(ref this.vreg[7], ref this.sc0));
			Microsoft.Xna.Framework.Vector4 unused = new Microsoft.Xna.Framework.Vector4();
			// Set the value for attribute 'worldMatrix'
			this.vreg_change = (this.vreg_change | state.SetWorldMatrix(ref this.vreg[4], ref this.vreg[5], ref this.vreg[6], ref unused, ref this.sc1));
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc2));
			// Assign pixel shader textures and samplers
			if ((ic | this.ptc))
			{
				state.SetPixelShaderSamplers(this.ptx, this.pts);
				this.ptc = false;
			}
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawBillboardParticles_GpuTex3D.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawBillboardParticles_GpuTex3D.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawBillboardParticles_GpuTex3D.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawBillboardParticles_GpuTex3D.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawBillboardParticles_GpuTex3D.fx, DrawBillboardParticles_GpuTex3D.fxb, 51, 8);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return ((this.vreg_change | this.vtc) 
						| this.ptc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawBillboardParticles_GpuTex3D.vin[i]));
			index = DrawBillboardParticles_GpuTex3D.vin[(i + 1)];
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
				return new byte[] {68,8,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,95,247,107,202,239,9,253,255,215,161,255,255,78,222,247,120,126,115,250,255,239,255,251,175,151,235,38,159,253,254,77,182,88,149,121,253,107,252,126,127,253,175,251,107,227,125,250,255,255,164,237,204,251,10,238,255,213,207,175,71,255,255,253,47,155,223,127,74,63,127,163,95,67,240,254,173,58,136,255,250,218,166,217,113,109,14,134,218,236,186,54,191,111,172,205,74,224,224,171,223,76,219,249,207,175,69,255,255,77,35,159,255,154,250,47,96,188,158,103,51,162,252,175,241,235,234,231,248,12,115,128,119,126,59,239,157,125,250,255,75,239,239,255,131,254,255,155,121,56,165,244,251,190,247,247,83,250,253,247,246,254,254,139,244,119,252,248,179,244,119,224,247,167,232,247,37,125,54,167,255,255,169,250,247,31,70,191,255,65,94,59,243,252,223,244,88,176,248,229,215,254,191,255,239,255,235,255,254,93,127,141,147,55,199,79,192,99,95,254,26,242,25,190,82,158,75,191,77,255,236,252,26,50,174,95,147,160,29,232,235,74,191,191,246,215,33,42,255,154,252,159,60,244,241,189,223,127,231,215,248,162,152,214,85,83,157,183,233,214,171,59,233,183,159,191,126,158,10,181,210,147,106,177,42,136,97,211,135,227,189,79,199,15,239,239,141,247,14,246,247,127,141,223,133,80,37,58,254,65,212,211,159,36,191,255,154,52,132,223,148,127,39,176,127,210,175,241,27,252,166,127,209,19,70,227,55,165,54,255,25,253,253,159,253,69,191,46,255,253,235,227,111,106,251,159,253,73,132,195,175,245,107,254,26,191,57,253,254,127,255,73,252,221,111,96,190,251,53,254,32,249,251,55,160,191,255,111,254,251,255,254,191,21,225,95,67,232,98,126,255,155,48,121,191,246,255,69,116,249,253,45,93,62,255,53,229,51,208,192,208,229,247,196,28,253,26,130,92,66,255,254,1,244,115,245,107,200,188,26,90,253,118,74,148,45,254,12,52,250,245,126,141,29,253,76,120,253,175,253,107,127,77,254,230,215,97,89,253,255,194,163,242,215,155,119,149,185,222,231,151,95,147,31,126,130,196,42,249,53,126,211,191,232,15,253,85,31,29,17,152,223,227,223,253,77,255,233,223,243,223,253,77,207,254,33,124,254,27,210,231,248,140,166,241,31,148,94,254,160,223,67,249,228,15,250,53,58,60,99,126,255,53,221,239,104,243,31,25,126,35,250,235,239,191,230,31,244,107,209,231,52,253,191,14,62,251,53,126,141,255,250,79,250,13,73,244,240,255,95,139,167,244,215,252,131,126,236,215,248,107,208,175,240,22,253,13,88,63,70,223,255,150,12,247,215,194,223,127,236,111,204,223,253,58,252,29,253,255,15,254,45,24,30,218,254,53,244,255,175,240,255,63,216,107,255,7,25,216,210,254,171,63,24,176,127,77,253,238,199,126,141,175,254,162,95,147,219,254,154,127,16,240,248,117,88,181,252,218,244,249,127,6,60,192,243,127,144,124,246,27,49,236,223,240,215,248,211,8,223,191,237,47,250,253,25,6,228,228,127,251,131,32,39,191,63,247,33,127,255,154,244,183,188,131,62,255,239,63,136,248,238,47,74,168,159,223,82,251,1,92,247,253,175,65,223,255,53,244,253,255,253,23,253,238,244,253,175,69,125,187,239,127,83,234,255,119,163,62,255,65,234,243,191,249,139,136,14,191,246,175,205,120,3,167,255,76,255,254,117,248,239,95,215,254,253,107,242,223,191,30,253,45,227,254,245,255,160,95,155,254,254,245,127,141,127,229,47,254,117,249,123,145,215,223,224,215,248,167,25,71,249,251,95,161,191,255,149,191,136,218,253,193,191,27,225,240,235,232,59,126,251,95,231,215,248,167,21,39,105,255,235,208,255,77,123,211,198,232,10,234,151,223,55,237,9,87,250,12,243,242,159,49,237,127,173,95,227,55,230,54,191,206,175,241,167,113,155,95,75,251,67,155,95,139,232,231,235,28,154,211,63,201,192,249,181,248,239,175,254,164,95,195,131,45,186,231,255,230,121,146,121,252,13,136,94,255,55,211,130,232,251,31,9,140,255,76,255,254,181,254,35,105,111,254,254,117,248,239,95,203,254,253,27,240,223,132,11,243,4,120,21,176,160,199,254,159,0,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 invTextureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 InvTextureSizeOffset
		{
			set
			{
				this.SetInvTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 worldSpaceYAxis'</summary>
		public Microsoft.Xna.Framework.Vector3 WorldSpaceYAxis
		{
			set
			{
				this.SetWorldSpaceYAxis(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'viewPoint'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute 'worldMatrix'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc2;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D DisplaySampler'</summary>
		public Xen.Graphics.TextureSamplerState DisplaySampler
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
		/// <summary>Get/Set the Bound texture for 'Texture2D DisplayTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D DisplayTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.ptx[0]));
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
		/// <summary>Name uid for sampler for 'Sampler2D DisplaySampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid1;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid2;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Name uid for texture for 'Texture2D DisplayTexture'</summary>
		static int tid4;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>Pixel samplers/textures changed</summary>
		bool ptc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[10];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[2];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[2];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[1];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[1];
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_GpuTex3D.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D.cid1))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_GpuTex3D.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D.sid1))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D.sid2))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_GpuTex3D.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawBillboardParticlesColour_GpuTex3D' generated from file 'Billboard3D.fx'</para><para>Vertex Shader: approximately 58 instruction slots used (6 texture, 52 arithmetic), 10 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawBillboardParticlesColour_GpuTex3D : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawBillboardParticlesColour_GpuTex3D' shader</summary>
		public DrawBillboardParticlesColour_GpuTex3D()
		{
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
			this.pts[0] = ((Xen.Graphics.TextureSamplerState)(197));
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[2] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawBillboardParticlesColour_GpuTex3D.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawBillboardParticlesColour_GpuTex3D.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawBillboardParticlesColour_GpuTex3D.cid1 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawBillboardParticlesColour_GpuTex3D.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawBillboardParticlesColour_GpuTex3D.sid1 = state.GetNameUniqueID("ColourSampler");
			DrawBillboardParticlesColour_GpuTex3D.sid2 = state.GetNameUniqueID("PositionSampler");
			DrawBillboardParticlesColour_GpuTex3D.sid3 = state.GetNameUniqueID("VelocitySampler");
			DrawBillboardParticlesColour_GpuTex3D.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawBillboardParticlesColour_GpuTex3D.tid1 = state.GetNameUniqueID("ColourTexture");
			DrawBillboardParticlesColour_GpuTex3D.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawBillboardParticlesColour_GpuTex3D.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawBillboardParticlesColour_GpuTex3D.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'viewPoint'
			this.vreg_change = (this.vreg_change | state.SetViewPointVector3(ref this.vreg[7], ref this.sc0));
			Microsoft.Xna.Framework.Vector4 unused = new Microsoft.Xna.Framework.Vector4();
			// Set the value for attribute 'worldMatrix'
			this.vreg_change = (this.vreg_change | state.SetWorldMatrix(ref this.vreg[4], ref this.vreg[5], ref this.vreg[6], ref unused, ref this.sc1));
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc2));
			// Assign pixel shader textures and samplers
			if ((ic | this.ptc))
			{
				state.SetPixelShaderSamplers(this.ptx, this.pts);
				this.ptc = false;
			}
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawBillboardParticlesColour_GpuTex3D.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawBillboardParticlesColour_GpuTex3D.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawBillboardParticlesColour_GpuTex3D.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawBillboardParticlesColour_GpuTex3D.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawBillboardParticlesColour_GpuTex3D.fx, DrawBillboardParticlesColour_GpuTex3D.fxb, 53, 8);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return ((this.vreg_change | this.vtc) 
						| this.ptc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawBillboardParticlesColour_GpuTex3D.vin[i]));
			index = DrawBillboardParticlesColour_GpuTex3D.vin[(i + 1)];
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
				return new byte[] {180,8,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,191,244,107,202,239,9,253,255,215,161,255,255,78,222,247,120,126,115,250,255,239,255,251,175,151,235,38,159,253,254,77,182,88,149,121,253,107,252,126,127,253,175,251,107,227,125,250,255,255,164,237,204,251,10,238,255,213,207,175,71,255,255,253,47,155,223,127,74,63,127,163,95,67,240,254,173,58,136,255,250,218,166,217,113,109,14,134,218,236,186,54,191,239,80,155,61,215,230,15,138,181,89,73,95,248,234,55,211,118,254,243,107,209,255,127,211,200,231,6,20,96,188,158,103,51,154,29,30,31,62,255,13,232,255,152,39,188,243,219,121,239,236,211,255,95,122,127,255,31,244,255,223,204,195,41,165,223,247,189,191,159,210,239,191,183,247,247,156,126,255,25,239,239,127,76,127,199,143,191,79,127,7,190,127,138,126,255,39,209,103,127,28,253,255,79,213,191,255,42,250,253,47,243,218,153,231,255,166,199,130,197,47,191,246,255,253,127,255,95,255,247,239,250,107,156,188,57,126,2,190,252,242,215,144,207,240,149,242,105,250,109,250,103,231,215,144,113,254,154,4,237,64,95,87,122,254,181,191,14,81,253,215,228,255,228,161,143,239,253,254,59,191,198,23,197,180,174,154,234,188,77,183,94,221,73,191,253,252,245,243,84,168,151,158,84,139,85,65,76,158,62,28,239,125,58,126,120,127,111,188,119,176,191,255,107,252,46,132,234,175,75,83,71,61,253,73,242,251,175,73,211,248,155,242,239,4,246,79,250,53,126,131,223,244,47,122,194,104,252,166,212,230,63,163,191,255,179,191,232,215,229,191,127,125,252,77,109,255,51,144,225,215,250,53,127,141,223,156,126,255,191,255,36,254,238,55,48,223,253,26,127,144,252,253,27,208,223,255,55,255,253,127,255,223,138,240,175,33,116,49,191,255,119,152,204,95,251,255,34,186,252,180,165,75,243,107,202,103,158,252,166,37,125,86,254,26,130,92,66,255,182,244,243,15,163,255,255,110,191,166,163,213,72,137,242,152,63,3,141,126,61,158,107,60,111,248,179,95,139,62,75,44,79,139,204,252,181,127,237,175,201,173,127,29,150,249,255,47,60,42,199,61,94,80,217,141,127,190,215,255,252,242,107,242,206,79,252,26,191,198,175,155,252,26,191,233,95,244,135,254,170,143,142,8,204,239,241,239,254,166,255,244,239,249,239,254,166,103,255,16,62,255,13,233,115,124,70,83,254,15,74,47,127,208,239,161,60,245,7,253,26,29,254,50,191,255,154,222,239,191,150,251,29,237,255,35,195,167,52,71,250,251,175,249,7,253,90,244,249,175,197,211,254,107,254,65,63,246,107,252,53,232,79,248,143,254,198,123,63,246,107,252,26,127,209,111,201,48,126,45,252,253,199,254,198,252,221,175,195,223,209,255,255,224,223,130,254,248,53,185,237,95,67,255,255,10,255,255,131,189,246,127,144,129,45,237,191,250,131,1,251,215,212,239,126,236,215,248,234,47,250,53,185,237,175,249,7,253,134,212,207,175,195,234,232,215,166,207,255,51,224,1,185,248,131,228,179,223,136,97,255,134,191,198,159,246,23,253,134,191,198,223,246,23,253,254,212,8,120,255,26,191,198,255,246,7,253,154,36,75,191,14,227,240,107,211,223,255,245,159,4,56,248,255,239,207,253,64,222,254,183,63,8,242,246,251,51,30,242,247,175,165,239,8,94,255,247,31,68,188,250,23,37,132,203,111,169,184,160,111,247,253,175,65,223,255,53,244,253,255,253,23,253,238,244,253,175,69,248,185,239,127,83,194,241,119,35,188,254,65,234,243,191,249,139,136,86,191,246,175,205,99,3,222,255,153,254,253,235,240,223,191,174,253,251,215,228,191,127,61,250,91,104,243,235,255,65,191,54,253,253,235,255,26,255,202,95,252,235,242,247,34,247,191,193,175,241,79,51,142,242,247,191,66,127,255,43,127,17,181,251,131,127,55,194,225,215,209,119,252,246,191,206,175,241,79,43,78,210,254,215,161,255,155,246,166,141,209,57,212,47,191,111,218,19,174,244,25,230,238,63,227,249,249,181,126,141,223,152,219,252,58,191,198,159,198,109,126,45,237,15,109,126,45,162,159,175,187,104,222,255,36,3,231,215,226,191,191,250,147,126,13,15,182,232,176,255,155,231,82,230,250,55,32,122,253,223,76,11,162,239,127,36,48,254,51,253,251,215,250,143,164,189,249,251,215,225,191,127,45,251,247,111,192,127,19,46,127,17,116,224,255,19,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 invTextureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 InvTextureSizeOffset
		{
			set
			{
				this.SetInvTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 worldSpaceYAxis'</summary>
		public Microsoft.Xna.Framework.Vector3 WorldSpaceYAxis
		{
			set
			{
				this.SetWorldSpaceYAxis(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'viewPoint'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute 'worldMatrix'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc2;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D DisplaySampler'</summary>
		public Xen.Graphics.TextureSamplerState DisplaySampler
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
		/// <summary>Get/Set the Bound texture for 'Texture2D DisplayTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D DisplayTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.ptx[0]));
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
		/// <summary>Name uid for sampler for 'Sampler2D DisplaySampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D ColourSampler'</summary>
		static int sid1;
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid2;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid3;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D ColourTexture'</summary>
		static int tid1;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Name uid for texture for 'Texture2D DisplayTexture'</summary>
		static int tid4;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>Pixel samplers/textures changed</summary>
		bool ptc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[10];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[3];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[3];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[1];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[1];
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.cid1))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.sid1))
			{
				this.ColourSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.sid2))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.sid3))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.tid1))
			{
				this.ColourTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawBillboardParticles_GpuTex3D_UserOffset' generated from file 'Billboard3D.fx'</para><para>Vertex Shader: approximately 59 instruction slots used (6 texture, 53 arithmetic), 10 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawBillboardParticles_GpuTex3D_UserOffset : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawBillboardParticles_GpuTex3D_UserOffset' shader</summary>
		public DrawBillboardParticles_GpuTex3D_UserOffset()
		{
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
			this.pts[0] = ((Xen.Graphics.TextureSamplerState)(197));
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[2] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawBillboardParticles_GpuTex3D_UserOffset.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawBillboardParticles_GpuTex3D_UserOffset.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawBillboardParticles_GpuTex3D_UserOffset.cid1 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawBillboardParticles_GpuTex3D_UserOffset.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawBillboardParticles_GpuTex3D_UserOffset.sid1 = state.GetNameUniqueID("PositionSampler");
			DrawBillboardParticles_GpuTex3D_UserOffset.sid2 = state.GetNameUniqueID("UserSampler");
			DrawBillboardParticles_GpuTex3D_UserOffset.sid3 = state.GetNameUniqueID("VelocitySampler");
			DrawBillboardParticles_GpuTex3D_UserOffset.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawBillboardParticles_GpuTex3D_UserOffset.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawBillboardParticles_GpuTex3D_UserOffset.tid3 = state.GetNameUniqueID("UserTexture");
			DrawBillboardParticles_GpuTex3D_UserOffset.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawBillboardParticles_GpuTex3D_UserOffset.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'viewPoint'
			this.vreg_change = (this.vreg_change | state.SetViewPointVector3(ref this.vreg[7], ref this.sc0));
			Microsoft.Xna.Framework.Vector4 unused = new Microsoft.Xna.Framework.Vector4();
			// Set the value for attribute 'worldMatrix'
			this.vreg_change = (this.vreg_change | state.SetWorldMatrix(ref this.vreg[4], ref this.vreg[5], ref this.vreg[6], ref unused, ref this.sc1));
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc2));
			// Assign pixel shader textures and samplers
			if ((ic | this.ptc))
			{
				state.SetPixelShaderSamplers(this.ptx, this.pts);
				this.ptc = false;
			}
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawBillboardParticles_GpuTex3D_UserOffset.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawBillboardParticles_GpuTex3D_UserOffset.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawBillboardParticles_GpuTex3D_UserOffset.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawBillboardParticles_GpuTex3D_UserOffset.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawBillboardParticles_GpuTex3D_UserOffset.fx, DrawBillboardParticles_GpuTex3D_UserOffset.fxb, 54, 8);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return ((this.vreg_change | this.vtc) 
						| this.ptc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawBillboardParticles_GpuTex3D_UserOffset.vin[i]));
			index = DrawBillboardParticles_GpuTex3D_UserOffset.vin[(i + 1)];
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
				return new byte[] {200,8,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,191,244,107,202,239,9,253,255,215,161,255,255,78,222,247,120,126,115,250,255,239,255,251,175,151,235,38,159,253,254,77,182,88,149,121,253,107,252,126,127,253,175,251,107,227,125,250,255,255,164,237,204,251,10,238,255,213,207,175,71,255,255,253,47,155,223,127,74,63,127,163,95,67,240,254,173,58,136,255,250,218,166,217,113,109,14,134,218,236,186,54,191,239,80,155,61,215,230,15,138,181,89,113,95,191,46,190,250,205,180,157,255,252,90,244,255,223,52,242,185,1,5,24,175,231,217,140,102,231,215,253,245,244,243,223,128,254,143,121,194,59,191,157,247,206,62,253,255,165,247,247,255,65,255,255,205,60,156,82,250,125,223,251,251,41,253,254,123,123,127,207,233,247,159,241,254,254,199,244,119,252,248,251,244,119,224,251,167,232,247,127,18,125,246,199,209,255,255,84,253,251,175,162,223,255,50,175,157,121,254,111,122,44,88,252,242,107,255,223,255,247,255,245,127,255,174,191,198,201,155,227,39,224,203,47,127,13,249,12,95,41,159,166,223,166,127,118,126,13,25,231,175,73,208,14,244,117,165,231,95,251,235,16,213,127,77,254,79,30,250,248,222,239,191,243,107,124,81,76,235,170,169,206,219,116,235,213,157,244,219,207,95,63,79,133,122,233,73,181,88,21,196,228,233,195,241,222,167,227,135,247,247,198,123,7,251,251,191,198,239,66,168,254,186,52,117,212,211,159,36,191,255,154,52,141,191,41,255,78,96,255,164,95,227,55,248,77,255,162,39,140,198,111,74,109,254,51,250,251,63,251,139,126,93,254,251,215,199,223,212,246,63,3,25,126,173,95,243,215,248,205,233,247,255,251,79,226,239,126,3,243,221,175,241,7,201,223,191,1,253,253,127,243,223,255,247,255,173,8,255,26,66,23,251,7,53,252,53,126,237,255,139,232,242,211,150,46,205,175,41,159,121,242,155,150,244,89,249,107,8,114,9,253,219,210,207,63,140,254,255,187,253,154,142,86,35,37,202,99,254,12,52,250,245,120,174,241,188,225,207,126,45,250,44,177,60,45,50,243,215,254,181,191,38,183,254,117,88,230,255,191,240,168,28,247,120,65,101,55,254,249,94,255,243,203,175,201,59,63,65,179,150,252,26,191,233,95,244,135,254,170,143,142,8,204,239,241,239,254,166,255,244,239,249,239,254,166,103,255,16,62,255,13,233,115,124,70,83,254,15,74,47,127,208,239,161,60,245,7,253,26,29,254,50,191,255,154,222,239,191,150,251,29,237,255,35,195,167,52,71,250,251,175,249,7,253,90,244,57,241,198,175,131,207,126,141,95,227,191,254,147,126,195,95,227,215,248,139,240,255,95,139,89,225,215,252,131,126,236,215,248,107,128,131,240,36,253,13,88,63,70,223,255,150,12,247,215,194,223,127,236,111,204,223,253,58,252,29,253,255,15,254,45,24,30,218,254,53,244,255,175,240,255,63,216,107,255,7,25,216,210,254,171,63,24,176,127,77,253,238,199,126,141,175,254,162,95,147,219,254,154,127,16,240,248,117,88,69,253,218,244,249,127,6,60,32,43,127,144,124,246,27,49,236,223,240,215,248,211,8,223,191,237,47,250,253,25,6,228,235,127,251,131,126,45,146,47,252,253,107,233,223,191,134,254,253,107,232,223,191,38,253,45,48,128,195,255,253,7,17,175,254,69,9,245,251,91,106,191,232,199,125,255,107,208,247,127,13,125,255,127,255,69,191,59,125,255,107,19,46,110,12,191,62,225,243,171,232,119,150,83,250,232,55,32,124,254,239,191,232,199,236,120,128,235,127,166,127,255,58,252,247,175,107,255,254,53,249,239,95,143,254,254,181,248,239,95,159,199,246,235,255,26,255,202,95,252,235,50,238,242,247,111,240,107,252,211,140,171,252,253,175,208,223,255,10,181,255,207,254,224,223,141,250,251,117,232,179,95,139,97,186,246,191,206,175,241,79,51,238,191,166,182,255,117,232,255,166,189,105,243,235,106,127,191,54,143,227,63,179,237,9,87,250,236,43,180,225,57,249,181,127,141,223,152,219,252,58,191,198,159,246,7,25,28,126,45,109,243,107,19,29,13,28,192,164,185,254,147,12,156,95,139,255,254,234,79,114,115,37,109,126,45,162,181,234,180,128,86,68,231,255,232,215,224,119,254,51,253,251,215,250,143,84,47,234,223,191,14,255,253,107,217,191,127,3,254,251,215,166,191,127,77,30,215,111,250,31,1,22,244,226,255,19,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 invTextureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 InvTextureSizeOffset
		{
			set
			{
				this.SetInvTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 worldSpaceYAxis'</summary>
		public Microsoft.Xna.Framework.Vector3 WorldSpaceYAxis
		{
			set
			{
				this.SetWorldSpaceYAxis(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'viewPoint'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute 'worldMatrix'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc2;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D DisplaySampler'</summary>
		public Xen.Graphics.TextureSamplerState DisplaySampler
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
		/// <summary>Get/Set the Bound texture for 'Texture2D DisplayTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D DisplayTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.ptx[0]));
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
		/// <summary>Name uid for sampler for 'Sampler2D DisplaySampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid1;
		/// <summary>Name uid for sampler for 'Sampler2D UserSampler'</summary>
		static int sid2;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid3;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Name uid for texture for 'Texture2D UserTexture'</summary>
		static int tid3;
		/// <summary>Name uid for texture for 'Texture2D DisplayTexture'</summary>
		static int tid4;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>Pixel samplers/textures changed</summary>
		bool ptc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[10];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[3];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[3];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[1];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[1];
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.cid1))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.sid1))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.sid2))
			{
				this.UserSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.sid3))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.tid3))
			{
				this.UserTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticles_GpuTex3D_UserOffset.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawBillboardParticlesColour_GpuTex3D_UserOffset' generated from file 'Billboard3D.fx'</para><para>Vertex Shader: approximately 61 instruction slots used (8 texture, 53 arithmetic), 10 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawBillboardParticlesColour_GpuTex3D_UserOffset : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawBillboardParticlesColour_GpuTex3D_UserOffset' shader</summary>
		public DrawBillboardParticlesColour_GpuTex3D_UserOffset()
		{
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
			this.pts[0] = ((Xen.Graphics.TextureSamplerState)(197));
			this.vts[1] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[0] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[3] = ((Xen.Graphics.TextureSamplerState)(64));
			this.vts[2] = ((Xen.Graphics.TextureSamplerState)(64));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.cid1 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid1 = state.GetNameUniqueID("ColourSampler");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid2 = state.GetNameUniqueID("PositionSampler");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid3 = state.GetNameUniqueID("UserSampler");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid4 = state.GetNameUniqueID("VelocitySampler");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid1 = state.GetNameUniqueID("ColourTexture");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid3 = state.GetNameUniqueID("UserTexture");
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawBillboardParticlesColour_GpuTex3D_UserOffset.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'viewPoint'
			this.vreg_change = (this.vreg_change | state.SetViewPointVector3(ref this.vreg[7], ref this.sc0));
			Microsoft.Xna.Framework.Vector4 unused = new Microsoft.Xna.Framework.Vector4();
			// Set the value for attribute 'worldMatrix'
			this.vreg_change = (this.vreg_change | state.SetWorldMatrix(ref this.vreg[4], ref this.vreg[5], ref this.vreg[6], ref unused, ref this.sc1));
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc2));
			// Assign pixel shader textures and samplers
			if ((ic | this.ptc))
			{
				state.SetPixelShaderSamplers(this.ptx, this.pts);
				this.ptc = false;
			}
			// Assign pixel shader textures and samplers
			if ((ic | this.vtc))
			{
				state.SetVertexShaderSamplers(this.vtx, this.vts);
				this.vtc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawBillboardParticlesColour_GpuTex3D_UserOffset.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawBillboardParticlesColour_GpuTex3D_UserOffset.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawBillboardParticlesColour_GpuTex3D_UserOffset.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawBillboardParticlesColour_GpuTex3D_UserOffset.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawBillboardParticlesColour_GpuTex3D_UserOffset.fx, DrawBillboardParticlesColour_GpuTex3D_UserOffset.fxb, 56, 8);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return ((this.vreg_change | this.vtc) 
						| this.ptc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawBillboardParticlesColour_GpuTex3D_UserOffset.vin[i]));
			index = DrawBillboardParticlesColour_GpuTex3D_UserOffset.vin[(i + 1)];
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
				return new byte[] {248,8,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,63,246,107,202,239,191,54,254,166,255,255,67,250,93,66,255,255,117,244,179,255,183,63,191,30,253,255,247,191,108,126,255,41,253,252,141,126,13,193,251,63,235,180,249,245,181,77,179,227,218,252,6,157,193,217,54,187,174,205,104,168,205,158,107,243,114,168,205,61,215,166,141,181,89,9,62,248,234,55,211,118,254,243,107,209,255,127,211,200,231,6,20,96,188,158,103,179,188,22,26,224,243,223,224,215,144,185,196,59,169,247,206,63,71,255,255,143,188,191,255,39,180,241,112,250,173,232,247,45,239,239,3,250,253,185,247,247,239,75,191,175,188,191,255,46,253,29,63,254,38,253,29,248,254,41,250,253,31,70,159,253,65,244,255,63,85,255,254,243,232,247,63,203,107,103,158,255,155,30,11,22,191,252,218,255,247,255,253,127,253,223,191,235,175,113,242,230,248,201,239,68,127,126,249,107,200,103,248,234,119,226,70,191,70,250,109,250,103,231,215,48,60,251,107,253,26,7,250,186,210,243,175,253,117,136,234,191,38,255,39,15,125,124,239,247,223,249,53,190,40,166,117,213,84,231,109,186,245,234,78,250,237,231,175,159,167,66,189,244,164,90,172,138,146,126,121,56,222,251,116,252,240,254,222,120,239,96,127,255,215,248,93,8,213,95,151,134,65,61,253,73,242,251,175,73,67,250,77,249,119,2,251,39,253,26,191,193,111,250,23,61,97,52,126,83,106,243,159,209,223,255,217,95,244,235,242,223,191,62,254,166,182,255,217,159,68,56,252,90,191,230,175,241,155,211,239,255,247,159,196,223,253,6,230,187,95,227,15,146,191,127,3,250,251,255,230,191,255,239,255,91,17,254,53,132,46,230,247,199,212,240,215,248,181,255,47,162,203,218,210,229,47,252,53,229,51,124,101,232,2,250,18,48,70,46,161,127,255,40,250,249,103,253,26,50,151,134,86,191,167,18,229,37,127,6,26,253,122,191,198,239,173,159,205,249,179,95,139,62,75,236,92,255,65,252,25,90,254,38,191,198,31,165,159,137,172,253,181,127,237,175,201,159,255,58,172,43,254,191,240,168,252,247,248,67,101,62,254,249,222,192,231,247,250,159,95,126,77,62,251,137,95,227,215,248,117,147,95,227,55,253,139,8,196,239,65,20,255,7,5,218,31,244,123,224,243,223,144,62,255,67,127,213,71,71,248,238,223,253,77,255,233,223,243,223,253,77,207,254,33,229,191,63,232,215,232,240,162,249,253,215,244,126,255,181,188,223,127,109,247,59,222,253,143,12,127,211,60,234,239,191,230,31,244,107,209,231,191,22,179,203,175,249,7,253,216,175,241,215,0,39,225,91,250,27,239,253,216,175,241,107,252,69,191,37,195,248,181,240,247,31,251,27,243,119,191,14,127,71,255,255,131,127,11,86,43,104,251,215,208,255,191,194,255,255,96,175,253,31,100,96,75,251,175,254,96,192,254,53,245,187,31,251,53,190,250,139,126,77,110,251,107,254,65,196,83,127,209,175,195,106,236,215,166,207,255,51,224,65,120,254,103,127,144,124,246,27,49,236,228,215,248,211,254,162,228,215,248,219,254,162,223,159,26,1,239,95,227,215,248,223,254,160,95,147,100,240,215,97,28,126,109,250,251,191,254,147,0,7,255,255,253,185,31,200,233,255,246,7,253,218,212,70,223,225,191,127,13,253,251,215,208,191,127,45,133,33,120,254,223,127,208,111,72,239,255,134,132,219,111,169,184,1,23,247,253,175,65,223,255,53,244,253,255,253,23,253,238,244,61,201,138,55,206,95,159,112,254,85,244,59,203,59,125,244,27,16,206,255,247,95,244,99,118,204,24,207,127,166,127,255,58,252,247,175,107,255,254,53,249,239,95,143,254,254,181,248,239,95,159,199,255,235,255,26,255,202,95,252,235,50,238,242,247,111,240,107,252,211,140,171,252,253,175,208,223,255,10,181,255,207,254,224,223,141,250,251,117,232,179,95,139,97,186,246,191,206,175,241,79,255,65,66,31,105,255,235,208,255,77,123,211,230,215,213,254,126,109,30,199,127,102,219,19,174,244,217,87,104,195,243,246,107,255,26,191,49,183,249,117,126,141,63,237,15,50,56,252,90,218,230,215,38,58,26,56,128,73,252,240,39,25,56,191,22,255,253,213,159,228,230,83,218,252,90,68,107,213,141,1,173,136,206,255,17,62,255,53,148,54,244,245,127,164,250,85,255,254,117,248,239,95,203,254,253,27,240,223,191,54,253,13,157,250,255,4,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 invTextureSizeOffset'</summary>
		public Microsoft.Xna.Framework.Vector3 InvTextureSizeOffset
		{
			set
			{
				this.SetInvTextureSizeOffset(ref value);
			}
		}
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 worldSpaceYAxis'</summary>
		public Microsoft.Xna.Framework.Vector3 WorldSpaceYAxis
		{
			set
			{
				this.SetWorldSpaceYAxis(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'viewPoint'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute 'worldMatrix'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc2;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D DisplaySampler'</summary>
		public Xen.Graphics.TextureSamplerState DisplaySampler
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
		/// <summary>Get/Set the Bound texture for 'Texture2D DisplayTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D DisplayTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.ptx[0]));
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
		/// <summary>Name uid for sampler for 'Sampler2D DisplaySampler'</summary>
		static int sid0;
		/// <summary>Name uid for sampler for 'Sampler2D ColourSampler'</summary>
		static int sid1;
		/// <summary>Name uid for sampler for 'Sampler2D PositionSampler'</summary>
		static int sid2;
		/// <summary>Name uid for sampler for 'Sampler2D UserSampler'</summary>
		static int sid3;
		/// <summary>Name uid for sampler for 'Sampler2D VelocitySampler'</summary>
		static int sid4;
		/// <summary>Name uid for texture for 'Texture2D PositionTexture'</summary>
		static int tid0;
		/// <summary>Name uid for texture for 'Texture2D ColourTexture'</summary>
		static int tid1;
		/// <summary>Name uid for texture for 'Texture2D VelocityTexture'</summary>
		static int tid2;
		/// <summary>Name uid for texture for 'Texture2D UserTexture'</summary>
		static int tid3;
		/// <summary>Name uid for texture for 'Texture2D DisplayTexture'</summary>
		static int tid4;
		/// <summary>Vertex samplers/textures changed</summary>
		bool vtc;
		/// <summary>Pixel samplers/textures changed</summary>
		bool ptc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[10];
		/// <summary>Bound vertex textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] vtx = new Microsoft.Xna.Framework.Graphics.Texture[4];
		/// <summary>Bound vertex samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] vts = new Xen.Graphics.TextureSamplerState[4];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[1];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[1];
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.cid1))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid1))
			{
				this.ColourSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid2))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid3))
			{
				this.UserSampler = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.sid4))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid1))
			{
				this.ColourTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid3))
			{
				this.UserTexture = value;
				return true;
			}
			if ((id == DrawBillboardParticlesColour_GpuTex3D_UserOffset.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawBillboardParticles_BillboardCpu3D' generated from file 'Billboard3D.fx'</para><para>Vertex Shader: approximately 44 instruction slots used, 159 registers</para><para>Pixel Shader: approximately 6 instruction slots used (1 texture, 5 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawBillboardParticles_BillboardCpu3D : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawBillboardParticles_BillboardCpu3D' shader</summary>
		public DrawBillboardParticles_BillboardCpu3D()
		{
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
			this.pts[0] = ((Xen.Graphics.TextureSamplerState)(197));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawBillboardParticles_BillboardCpu3D.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawBillboardParticles_BillboardCpu3D.cid0 = state.GetNameUniqueID("positionData");
			DrawBillboardParticles_BillboardCpu3D.cid1 = state.GetNameUniqueID("velocityData");
			DrawBillboardParticles_BillboardCpu3D.cid2 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawBillboardParticles_BillboardCpu3D.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawBillboardParticles_BillboardCpu3D.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawBillboardParticles_BillboardCpu3D.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'viewPoint'
			this.vreg_change = (this.vreg_change | state.SetViewPointVector3(ref this.vreg[157], ref this.sc0));
			Microsoft.Xna.Framework.Vector4 unused = new Microsoft.Xna.Framework.Vector4();
			// Set the value for attribute 'worldMatrix'
			this.vreg_change = (this.vreg_change | state.SetWorldMatrix(ref this.vreg[154], ref this.vreg[155], ref this.vreg[156], ref unused, ref this.sc1));
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[150], ref this.vreg[151], ref this.vreg[152], ref this.vreg[153], ref this.sc2));
			// Assign pixel shader textures and samplers
			if ((ic | this.ptc))
			{
				state.SetPixelShaderSamplers(this.ptx, this.pts);
				this.ptc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawBillboardParticles_BillboardCpu3D.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawBillboardParticles_BillboardCpu3D.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawBillboardParticles_BillboardCpu3D.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawBillboardParticles_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawBillboardParticles_BillboardCpu3D.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawBillboardParticles_BillboardCpu3D.fx, DrawBillboardParticles_BillboardCpu3D.fxb, 38, 9);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return (this.vreg_change | this.ptc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawBillboardParticles_BillboardCpu3D.vin[i]));
			index = DrawBillboardParticles_BillboardCpu3D.vin[(i + 1)];
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
				return new byte[] {96,25,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,31,150,200,239,191,54,254,166,255,255,102,250,247,95,72,255,255,117,244,179,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,255,255,126,126,61,250,255,239,127,217,252,254,83,250,249,27,253,26,226,7,238,171,95,104,158,95,31,109,86,205,239,223,236,168,223,168,237,252,231,215,162,255,255,166,145,207,197,167,252,191,255,111,192,120,61,207,102,121,45,109,241,57,218,254,218,250,51,245,222,249,157,168,255,29,15,135,119,250,59,222,89,233,239,128,241,167,232,247,79,233,179,223,147,254,255,167,234,223,191,47,253,254,123,123,237,204,243,127,211,99,124,220,223,8,191,252,90,255,247,255,253,127,253,223,191,235,175,113,242,230,248,201,239,68,127,126,249,107,200,103,248,234,119,226,86,191,70,250,109,250,103,231,215,48,62,243,175,245,107,28,232,251,74,143,191,246,215,33,170,253,154,252,159,60,244,241,222,239,191,243,107,124,81,76,235,170,169,206,219,116,235,213,157,244,219,207,95,63,79,101,244,233,73,181,88,21,37,253,242,112,188,247,233,248,225,253,189,241,222,193,254,254,175,241,187,8,170,127,16,245,244,55,153,223,127,205,95,227,55,53,191,255,73,191,198,111,240,155,254,69,79,24,141,223,148,218,252,103,127,211,175,241,27,252,103,127,209,175,203,127,255,250,248,155,218,254,103,127,19,225,240,107,253,154,191,198,111,71,191,255,223,127,19,190,251,181,236,119,255,247,31,36,127,255,6,244,247,255,205,127,163,45,193,252,131,126,45,250,254,255,254,191,21,249,95,67,104,100,126,255,237,126,99,250,231,215,250,191,136,70,127,254,175,101,104,244,123,36,242,153,79,163,131,68,104,4,68,255,66,165,209,183,127,13,195,87,127,237,95,251,107,18,154,191,38,205,50,226,140,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,255,255,127,46,191,166,79,252,19,191,198,175,241,235,254,133,191,198,111,250,23,17,136,223,131,220,225,223,3,176,254,208,95,245,209,17,62,255,139,232,243,127,247,55,253,167,127,207,127,247,55,61,251,135,76,63,248,252,47,166,207,127,205,223,248,95,250,219,179,223,240,239,248,59,255,218,191,230,91,135,127,244,31,245,71,61,196,231,127,9,125,254,215,254,53,127,205,223,71,205,254,1,133,245,123,56,159,251,55,253,147,126,29,14,67,126,237,255,232,215,248,53,254,235,63,137,252,212,191,8,255,255,45,249,251,95,147,190,255,53,254,164,95,139,125,109,254,253,15,198,223,99,249,238,111,250,53,216,79,199,239,191,233,31,244,23,254,26,255,217,95,68,64,126,221,95,19,62,122,250,187,1,111,250,254,79,167,119,126,250,15,250,49,246,191,127,45,248,233,127,208,159,67,237,228,239,95,135,255,254,115,237,223,191,38,255,253,231,209,223,232,239,215,36,255,29,254,249,159,255,107,252,43,127,177,241,231,241,253,95,240,107,252,211,232,231,215,145,191,255,21,250,251,95,161,246,255,217,31,252,187,17,30,191,182,190,227,183,255,181,127,141,127,250,15,66,251,95,83,219,255,218,244,127,211,222,180,1,222,24,223,239,149,254,223,138,247,255,141,177,254,65,30,13,254,32,161,145,252,78,141,254,162,191,232,215,248,234,47,250,221,25,238,175,205,159,253,197,132,247,95,242,107,184,184,4,120,252,154,246,189,95,159,250,197,223,95,81,219,255,236,15,254,117,121,124,191,49,125,246,167,217,54,102,188,104,243,107,254,26,255,219,31,100,224,32,134,249,53,126,141,191,70,231,72,240,253,53,126,141,175,254,164,95,67,240,254,245,108,27,131,123,250,159,241,79,153,151,223,128,230,229,43,166,47,225,254,15,161,221,159,161,244,166,175,249,239,63,211,254,253,235,240,223,127,150,253,251,55,224,191,255,108,250,91,98,171,223,244,63,2,44,196,75,255,79,0,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'positionData'</summary>
		private static int cid0;
		/// <summary>Set the shader array value 'float4 positionData[75]'</summary><param name="value"/><param name="readIndex"/><param name="writeIndex"/><param name="count"/>
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
						> 75)))
			{
				throw new System.ArgumentException("Invalid range");
			}
			for (i = 0; ((i < count) 
						&& (wi < 75)); i = (i + 1))
			{
				val = value[ri];
				this.vreg[((wi * 1) 
							+ 0)] = val;
				ri = (ri + 1);
				wi = (wi + 1);
			}
			this.vreg_change = true;
		}
		/// <summary>Set and copy the array data for the shader value 'float4 positionData[75]'</summary>
		public Microsoft.Xna.Framework.Vector4[] PositionData
		{
			set
			{
				this.SetPositionData(value, 0, 0, ((uint)(value.Length)));
			}
		}
		/// <summary>Name ID for 'velocityData'</summary>
		private static int cid1;
		/// <summary>Set the shader array value 'float4 velocityData[75]'</summary><param name="value"/><param name="readIndex"/><param name="writeIndex"/><param name="count"/>
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
						> 75)))
			{
				throw new System.ArgumentException("Invalid range");
			}
			for (i = 0; ((i < count) 
						&& (wi < 75)); i = (i + 1))
			{
				val = value[ri];
				this.vreg[((wi * 1) 
							+ 75)] = val;
				ri = (ri + 1);
				wi = (wi + 1);
			}
			this.vreg_change = true;
		}
		/// <summary>Set and copy the array data for the shader value 'float4 velocityData[75]'</summary>
		public Microsoft.Xna.Framework.Vector4[] VelocityData
		{
			set
			{
				this.SetVelocityData(value, 0, 0, ((uint)(value.Length)));
			}
		}
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid2;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[158] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 worldSpaceYAxis'</summary>
		public Microsoft.Xna.Framework.Vector3 WorldSpaceYAxis
		{
			set
			{
				this.SetWorldSpaceYAxis(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'viewPoint'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute 'worldMatrix'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc2;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D DisplaySampler'</summary>
		public Xen.Graphics.TextureSamplerState DisplaySampler
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
		/// <summary>Get/Set the Bound texture for 'Texture2D DisplayTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D DisplayTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.ptx[0]));
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
		/// <summary>Name uid for sampler for 'Sampler2D DisplaySampler'</summary>
		static int sid0;
		/// <summary>Name uid for texture for 'Texture2D DisplayTexture'</summary>
		static int tid4;
		/// <summary>Pixel samplers/textures changed</summary>
		bool ptc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[159];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[1];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[1];
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawBillboardParticles_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_BillboardCpu3D.cid2))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector4[]' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Vector4[] value)
		{
			if ((DrawBillboardParticles_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_BillboardCpu3D.cid0))
			{
				this.SetPositionData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			if ((id == DrawBillboardParticles_BillboardCpu3D.cid1))
			{
				this.SetVelocityData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawBillboardParticles_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_BillboardCpu3D.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawBillboardParticles_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticles_BillboardCpu3D.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawBillboardParticlesColour_BillboardCpu3D' generated from file 'Billboard3D.fx'</para><para>Vertex Shader: approximately 44 instruction slots used, 234 registers</para><para>Pixel Shader: approximately 6 instruction slots used (1 texture, 5 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawBillboardParticlesColour_BillboardCpu3D : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawBillboardParticlesColour_BillboardCpu3D' shader</summary>
		public DrawBillboardParticlesColour_BillboardCpu3D()
		{
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
			this.pts[0] = ((Xen.Graphics.TextureSamplerState)(197));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DrawBillboardParticlesColour_BillboardCpu3D.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawBillboardParticlesColour_BillboardCpu3D.cid0 = state.GetNameUniqueID("colourData");
			DrawBillboardParticlesColour_BillboardCpu3D.cid1 = state.GetNameUniqueID("positionData");
			DrawBillboardParticlesColour_BillboardCpu3D.cid2 = state.GetNameUniqueID("velocityData");
			DrawBillboardParticlesColour_BillboardCpu3D.cid3 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawBillboardParticlesColour_BillboardCpu3D.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawBillboardParticlesColour_BillboardCpu3D.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawBillboardParticlesColour_BillboardCpu3D.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			// Set the value for attribute 'viewPoint'
			this.vreg_change = (this.vreg_change | state.SetViewPointVector3(ref this.vreg[232], ref this.sc0));
			Microsoft.Xna.Framework.Vector4 unused = new Microsoft.Xna.Framework.Vector4();
			// Set the value for attribute 'worldMatrix'
			this.vreg_change = (this.vreg_change | state.SetWorldMatrix(ref this.vreg[229], ref this.vreg[230], ref this.vreg[231], ref unused, ref this.sc1));
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[225], ref this.vreg[226], ref this.vreg[227], ref this.vreg[228], ref this.sc2));
			// Assign pixel shader textures and samplers
			if ((ic | this.ptc))
			{
				state.SetPixelShaderSamplers(this.ptx, this.pts);
				this.ptc = false;
			}
			if ((this.vreg_change == true))
			{
				DrawBillboardParticlesColour_BillboardCpu3D.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawBillboardParticlesColour_BillboardCpu3D.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawBillboardParticlesColour_BillboardCpu3D.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawBillboardParticlesColour_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawBillboardParticlesColour_BillboardCpu3D.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawBillboardParticlesColour_BillboardCpu3D.fx, DrawBillboardParticlesColour_BillboardCpu3D.fxb, 38, 9);
		}
		/// <summary>True if a shader constant has changed since the last Bind()</summary>
		protected override bool Changed()
		{
			return (this.vreg_change | this.ptc);
		}
		/// <summary>Returns the number of vertex inputs used by this shader</summary>
		protected override int GetVertexInputCountImpl()
		{
			return 1;
		}
		/// <summary>Returns a vertex input used by this shader</summary><param name="i"/><param name="usage"/><param name="index"/>
		protected override void GetVertexInputImpl(int i, out Microsoft.Xna.Framework.Graphics.VertexElementUsage usage, out int index)
		{
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawBillboardParticlesColour_BillboardCpu3D.vin[i]));
			index = DrawBillboardParticlesColour_BillboardCpu3D.vin[(i + 1)];
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
				return new byte[] {196,34,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,254,111,42,191,255,218,248,155,254,255,15,253,38,242,247,127,67,255,255,117,244,179,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,255,13,207,175,71,255,255,253,47,155,223,127,74,63,127,163,95,67,226,214,255,76,227,88,243,252,250,104,179,106,126,255,102,71,98,218,223,76,219,249,207,175,69,255,71,56,220,253,92,98,224,255,251,255,6,140,215,243,108,150,215,210,22,159,163,237,175,173,63,83,239,157,127,142,250,255,143,60,28,182,52,206,198,59,169,254,14,24,127,138,126,255,203,169,237,255,68,255,255,83,245,239,223,136,218,252,6,94,59,243,252,223,244,152,152,252,55,194,47,191,214,255,253,127,255,95,255,247,239,250,107,156,188,57,126,242,59,209,159,95,254,26,242,25,190,250,157,184,213,175,145,126,155,254,217,249,53,76,140,255,107,253,26,7,250,190,210,227,175,253,117,136,106,191,38,255,39,15,125,188,247,251,239,252,26,95,20,211,186,106,170,243,54,221,122,117,39,253,246,243,215,207,83,25,125,122,82,45,86,69,73,191,60,28,239,125,58,126,120,127,111,188,119,176,191,255,107,252,46,130,234,31,68,61,253,77,230,247,95,243,215,248,77,205,239,127,18,13,232,47,122,194,104,252,166,212,230,63,251,155,126,141,223,224,63,251,139,126,93,254,251,215,199,223,212,246,63,251,155,8,135,95,235,215,252,53,126,59,250,253,255,254,155,240,221,175,101,191,251,191,255,32,249,251,55,160,191,255,111,254,27,109,9,230,31,244,107,209,247,255,247,255,173,200,255,26,66,35,243,251,63,247,155,211,63,191,214,255,69,52,250,167,127,109,67,163,255,241,55,145,207,124,26,253,87,191,137,208,8,136,254,55,74,163,111,255,26,134,175,254,218,191,246,215,36,52,127,77,154,101,228,69,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,255,183,60,151,145,24,254,54,49,252,79,252,26,191,198,175,251,223,252,26,191,233,95,68,32,126,15,10,223,127,15,192,250,67,127,213,71,71,248,252,191,165,207,255,221,223,244,159,254,61,255,221,223,244,236,31,50,253,224,243,255,142,62,255,53,127,227,127,233,111,207,126,195,191,227,239,252,107,255,154,111,29,254,209,127,212,31,245,16,159,255,247,244,249,95,251,215,252,53,127,31,53,251,7,20,214,239,225,114,4,191,233,159,244,235,112,218,228,215,254,143,126,141,95,227,191,254,147,40,174,254,139,240,255,223,146,191,255,53,233,251,95,227,79,250,181,56,55,192,191,255,193,248,123,44,223,253,77,191,6,231,21,240,251,111,250,7,253,55,191,198,127,246,23,17,144,95,247,215,68,78,33,253,221,128,55,125,255,167,211,59,63,253,7,253,24,231,11,126,45,228,21,254,160,255,156,218,201,223,191,14,255,253,95,216,191,127,77,254,251,191,164,191,209,223,175,73,249,6,228,19,254,171,95,227,95,249,139,77,254,1,223,255,215,191,198,63,141,126,126,29,249,251,95,161,191,255,21,106,255,159,253,193,191,27,225,241,107,235,59,126,251,95,251,215,248,167,255,32,180,255,53,181,253,175,77,255,55,237,77,27,224,141,241,253,94,233,255,173,120,255,223,24,235,31,228,209,224,15,18,26,201,239,255,45,209,231,191,253,53,190,250,139,126,119,134,251,107,243,103,255,29,225,253,223,255,26,46,143,2,60,126,77,251,222,175,79,253,226,239,175,168,237,127,246,7,255,186,60,190,223,152,62,251,211,108,27,51,94,180,249,53,127,141,255,237,15,50,112,144,115,249,53,126,141,191,70,231,72,240,253,53,126,141,175,254,164,95,67,240,254,245,108,27,131,123,250,159,241,207,95,147,251,248,77,255,163,63,195,253,77,99,249,13,104,158,190,98,122,211,88,254,33,188,247,31,43,253,233,107,254,251,63,177,127,255,58,252,247,127,106,255,254,13,248,239,255,140,254,70,142,231,255,9,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'colourData'</summary>
		private static int cid0;
		/// <summary>Set the shader array value 'float4 colourData[75]'</summary><param name="value"/><param name="readIndex"/><param name="writeIndex"/><param name="count"/>
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
						> 75)))
			{
				throw new System.ArgumentException("Invalid range");
			}
			for (i = 0; ((i < count) 
						&& (wi < 75)); i = (i + 1))
			{
				val = value[ri];
				this.vreg[((wi * 1) 
							+ 150)] = val;
				ri = (ri + 1);
				wi = (wi + 1);
			}
			this.vreg_change = true;
		}
		/// <summary>Set and copy the array data for the shader value 'float4 colourData[75]'</summary>
		public Microsoft.Xna.Framework.Vector4[] ColourData
		{
			set
			{
				this.SetColourData(value, 0, 0, ((uint)(value.Length)));
			}
		}
		/// <summary>Name ID for 'positionData'</summary>
		private static int cid1;
		/// <summary>Set the shader array value 'float4 positionData[75]'</summary><param name="value"/><param name="readIndex"/><param name="writeIndex"/><param name="count"/>
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
						> 75)))
			{
				throw new System.ArgumentException("Invalid range");
			}
			for (i = 0; ((i < count) 
						&& (wi < 75)); i = (i + 1))
			{
				val = value[ri];
				this.vreg[((wi * 1) 
							+ 0)] = val;
				ri = (ri + 1);
				wi = (wi + 1);
			}
			this.vreg_change = true;
		}
		/// <summary>Set and copy the array data for the shader value 'float4 positionData[75]'</summary>
		public Microsoft.Xna.Framework.Vector4[] PositionData
		{
			set
			{
				this.SetPositionData(value, 0, 0, ((uint)(value.Length)));
			}
		}
		/// <summary>Name ID for 'velocityData'</summary>
		private static int cid2;
		/// <summary>Set the shader array value 'float4 velocityData[75]'</summary><param name="value"/><param name="readIndex"/><param name="writeIndex"/><param name="count"/>
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
						> 75)))
			{
				throw new System.ArgumentException("Invalid range");
			}
			for (i = 0; ((i < count) 
						&& (wi < 75)); i = (i + 1))
			{
				val = value[ri];
				this.vreg[((wi * 1) 
							+ 75)] = val;
				ri = (ri + 1);
				wi = (wi + 1);
			}
			this.vreg_change = true;
		}
		/// <summary>Set and copy the array data for the shader value 'float4 velocityData[75]'</summary>
		public Microsoft.Xna.Framework.Vector4[] VelocityData
		{
			set
			{
				this.SetVelocityData(value, 0, 0, ((uint)(value.Length)));
			}
		}
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid3;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[233] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
			this.vreg_change = true;
		}
		/// <summary>Assign the shader value 'float3 worldSpaceYAxis'</summary>
		public Microsoft.Xna.Framework.Vector3 WorldSpaceYAxis
		{
			set
			{
				this.SetWorldSpaceYAxis(ref value);
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'viewPoint'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute 'worldMatrix'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc2;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D DisplaySampler'</summary>
		public Xen.Graphics.TextureSamplerState DisplaySampler
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
		/// <summary>Get/Set the Bound texture for 'Texture2D DisplayTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D DisplayTexture
		{
			get
			{
				return ((Microsoft.Xna.Framework.Graphics.Texture2D)(this.ptx[0]));
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
		/// <summary>Name uid for sampler for 'Sampler2D DisplaySampler'</summary>
		static int sid0;
		/// <summary>Name uid for texture for 'Texture2D DisplayTexture'</summary>
		static int tid4;
		/// <summary>Pixel samplers/textures changed</summary>
		bool ptc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[234];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[1];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[1];
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawBillboardParticlesColour_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_BillboardCpu3D.cid3))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector4[]' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Vector4[] value)
		{
			if ((DrawBillboardParticlesColour_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_BillboardCpu3D.cid0))
			{
				this.SetColourData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			if ((id == DrawBillboardParticlesColour_BillboardCpu3D.cid1))
			{
				this.SetPositionData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			if ((id == DrawBillboardParticlesColour_BillboardCpu3D.cid2))
			{
				this.SetVelocityData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawBillboardParticlesColour_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_BillboardCpu3D.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawBillboardParticlesColour_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawBillboardParticlesColour_BillboardCpu3D.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
}
#endif
