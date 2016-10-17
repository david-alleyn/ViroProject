// XenFX
// Assembly = Xen.Graphics.ShaderSystem.CustomTool, Version=7.0.1.1, Culture=neutral, PublicKeyToken=e706afd07878dfca
// SourceFile = VelocityBillboard3D.fx
// Namespace = Xen.Ex.Graphics.Display

#if XBOX360
namespace Xen.Ex.Graphics.Display
{
	
	/// <summary><para>Technique 'DrawVelocityBillboardParticles_GpuTex3D' generated from file 'VelocityBillboard3D.fx'</para><para>Vertex Shader: approximately 52 instruction slots used (4 texture, 48 arithmetic), 11 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityBillboardParticles_GpuTex3D : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityBillboardParticles_GpuTex3D' shader</summary>
		public DrawVelocityBillboardParticles_GpuTex3D()
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
			DrawVelocityBillboardParticles_GpuTex3D.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityBillboardParticles_GpuTex3D.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawVelocityBillboardParticles_GpuTex3D.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityBillboardParticles_GpuTex3D.cid2 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawVelocityBillboardParticles_GpuTex3D.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawVelocityBillboardParticles_GpuTex3D.sid1 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityBillboardParticles_GpuTex3D.sid2 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityBillboardParticles_GpuTex3D.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityBillboardParticles_GpuTex3D.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawVelocityBillboardParticles_GpuTex3D.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityBillboardParticles_GpuTex3D.gd))
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
				DrawVelocityBillboardParticles_GpuTex3D.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityBillboardParticles_GpuTex3D.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityBillboardParticles_GpuTex3D.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityBillboardParticles_GpuTex3D.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityBillboardParticles_GpuTex3D.fx, DrawVelocityBillboardParticles_GpuTex3D.fxb, 55, 8);
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
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityBillboardParticles_GpuTex3D.vin[i]));
			index = DrawVelocityBillboardParticles_GpuTex3D.vin[(i + 1)];
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
				return new byte[] {4,188,240,11,207,131,0,1,16,136,0,8,254,255,9,1,0,0,1,184,135,0,1,10,131,0,1,4,131,0,1,28,143,0,17,17,95,95,117,110,117,115,101,100,95,115,97,109,112,108,101,114,135,0,1,3,131,0,4,1,0,0,1,136,0,1,11,131,0,1,4,131,0,1,1,229,0,0,206,0,0,1,6,1,95,1,118,1,115,1,95,1,99,134,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,36,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,48,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,72,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,49,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,108,143,0,0,1,7,1,95,1,112,1,115,1,95,1,115,1,48,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,5,131,0,0,1,1,131,0,0,1,7,131,0,0,1,3,131,0,0,1,4,131,0,0,1,24,139,0,0,1,52,131,0,0,1,80,138,0,0,1,1,1,12,1,0,1,0,1,1,1,32,138,0,0,1,1,1,48,1,0,1,0,1,1,1,68,138,0,0,1,1,1,84,1,0,1,0,1,1,1,104,138,0,0,1,1,1,172,135,0,0,1,1,1,0,1,0,1,1,1,168,135,0,0,1,2,131,0,0,1,92,134,0,0,1,1,1,124,1,0,1,0,1,1,1,120,131,0,0,1,93,134,0,0,1,1,1,148,1,0,1,0,1,1,1,144,135,0,0,1,2,136,0,0,132,255,0,131,0,0,1,1,134,0,0,1,1,1,0,1,16,1,42,1,17,132,0,0,1,172,131,0,0,1,84,135,0,0,1,36,135,0,0,1,132,139,0,0,1,92,131,0,0,1,28,131,0,0,1,79,1,255,1,255,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,72,131,0,0,1,48,1,0,1,3,131,0,0,1,1,133,0,0,1,56,132,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,84,1,16,1,0,1,2,132,0,0,1,4,134,0,0,1,24,1,66,1,0,1,3,1,0,1,3,131,0,0,1,1,1,0,1,0,1,48,1,80,1,0,1,0,1,241,1,81,1,0,1,1,1,16,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,48,1,3,1,0,1,0,1,34,133,0,0,1,16,1,8,1,32,1,1,1,31,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,22,1,16,133,0,0,1,27,1,226,1,0,1,0,1,1,1,20,1,14,131,0,0,1,252,1,252,1,27,1,225,1,2,1,1,1,2,1,12,1,135,1,128,1,0,1,0,1,21,1,108,1,108,1,225,151,0,0,132,255,0,138,0,0,1,4,1,72,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,224,1,0,1,0,1,2,1,104,135,0,0,1,36,1,0,1,0,1,1,1,124,1,0,1,0,1,1,1,164,138,0,0,1,1,1,84,131,0,0,1,28,1,0,1,0,1,1,1,70,1,255,1,254,1,3,132,0,0,1,3,131,0,0,1,28,134,0,0,1,1,1,63,131,0,0,1,88,1,0,1,2,131,0,0,1,11,133,0,0,1,96,131,0,0,1,112,1,0,1,0,1,1,1,32,1,0,1,3,131,0,0,1,1,132,0,0,1,1,1,40,134,0,0,1,1,1,56,1,0,1,3,1,0,1,1,1,0,1,1,132,0,0,1,1,1,40,132,0,0,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,11,229,0,0,209,0,0,1,95,1,118,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,118,1,115,1,95,1,115,1,49,1,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,1,171,135,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,2,1,40,1,0,1,17,1,0,1,7,138,0,0,1,24,1,66,131,0,0,1,1,131,0,0,1,1,131,0,0,1,2,1,0,1,0,1,2,1,144,131,0,0,1,5,1,0,1,0,1,48,1,80,1,0,1,1,1,241,1,81,1,0,1,0,1,16,1,44,1,0,1,0,1,16,1,43,176,0,0,1,63,1,128,1,0,1,0,1,63,139,0,0,1,16,1,9,1,96,1,5,1,64,1,11,1,18,1,0,1,18,1,0,1,0,1,80,132,0,0,1,96,1,15,1,194,1,0,1,18,133,0,0,1,96,1,21,1,96,1,27,1,18,1,0,1,18,133,0,0,1,96,1,33,1,64,1,39,1,18,1,0,1,18,135,0,0,1,32,1,43,1,196,1,0,1,34,131,0,0,1,5,1,248,132,0,0,1,4,1,120,132,0,0,1,176,1,35,1,0,1,1,1,0,1,176,1,177,1,192,1,1,1,10,1,255,1,10,1,168,1,64,1,1,132,0,0,1,65,1,194,1,0,1,0,1,10,1,52,1,18,131,0,0,1,198,1,0,1,198,1,232,1,129,1,0,1,1,1,200,1,8,1,0,1,1,1,1,1,198,1,177,1,177,1,237,1,1,1,0,1,0,1,168,1,64,1,1,132,0,0,1,128,1,194,1,0,1,0,1,10,1,200,1,3,1,0,1,1,1,0,1,196,1,179,1,0,1,224,1,1,1,1,1,0,1,188,1,64,1,1,132,0,0,1,65,1,194,1,0,1,0,1,255,1,33,1,8,1,48,1,33,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,33,1,24,1,32,1,33,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,200,1,2,1,0,1,1,1,0,1,27,1,177,1,108,1,139,1,2,1,8,1,8,1,200,1,7,1,0,1,5,1,0,1,192,1,198,1,0,1,167,1,2,1,255,1,0,1,200,1,15,1,0,1,4,1,0,1,70,1,190,1,108,1,76,1,255,1,3,1,255,1,200,1,1,1,0,1,1,1,0,1,62,1,0,1,0,1,111,1,5,1,4,1,0,1,200,1,4,1,0,1,1,1,0,1,62,1,0,1,0,1,111,1,4,1,4,1,0,1,200,1,2,131,0,0,1,64,1,0,1,0,1,243,1,5,1,0,1,0,1,48,2,40,0,3,1,0,62,4,0,177,111,6,5,4,0,184,39,0,6,5,2,20,205,65,128,7,1,7,255,200,7,0,4,8,0,177,205,205,171,0,9,2,9,168,18,1,0,0,98,98,130,208,10,5,5,255,88,40,0,1,0,190,190,11,177,240,2,2,128,168,71,1,7,0,192,12,177,131,193,5,0,255,160,130,1,0,0,98,13,190,27,240,7,2,129,20,7,0,2,1,180,205,14,177,225,7,4,128,200,7,0,2,1,205,180,192,235,15,7,4,2,4,130,1,0,0,192,192,27,240,2,2,1,16,88,34,0,1,0,27,177,177,225,1,1,128,180,23,2,6,17,0,180,177,65,193,2,0,255,180,39,2,4,0,98,27,128,193,18,6,0,255,180,71,2,5,0,98,205,130,193,7,6,255,200,7,0,19,1,1,180,180,192,235,7,6,5,36,135,1,1,0,192,108,108,225,1,4,2,128,200,7,131,0,20,192,198,192,235,1,0,4,200,7,0,1,0,192,27,192,235,0,3,3,200,21,1,128,62,0,62,62,0,111,0,1,0,200,2,128,62,0,62,62,0,111,1,22,1,0,200,4,128,62,0,62,62,0,111,2,1,0,200,8,128,62,0,62,62,0,8,111,3,1,0,36,254,192,1,131,0,16,108,226,0,0,128,200,3,128,0,0,197,197,0,226,2,2,140,0,1,0};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[10] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
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
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid2;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[11];
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
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.cid2))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.sid1))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.sid2))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityBillboardParticlesColour_GpuTex3D' generated from file 'VelocityBillboard3D.fx'</para><para>Vertex Shader: approximately 54 instruction slots used (6 texture, 48 arithmetic), 11 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityBillboardParticlesColour_GpuTex3D : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityBillboardParticlesColour_GpuTex3D' shader</summary>
		public DrawVelocityBillboardParticlesColour_GpuTex3D()
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
			DrawVelocityBillboardParticlesColour_GpuTex3D.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityBillboardParticlesColour_GpuTex3D.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawVelocityBillboardParticlesColour_GpuTex3D.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityBillboardParticlesColour_GpuTex3D.cid2 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawVelocityBillboardParticlesColour_GpuTex3D.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D.sid1 = state.GetNameUniqueID("ColourSampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D.sid2 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D.sid3 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityBillboardParticlesColour_GpuTex3D.tid1 = state.GetNameUniqueID("ColourTexture");
			DrawVelocityBillboardParticlesColour_GpuTex3D.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawVelocityBillboardParticlesColour_GpuTex3D.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityBillboardParticlesColour_GpuTex3D.gd))
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
				DrawVelocityBillboardParticlesColour_GpuTex3D.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityBillboardParticlesColour_GpuTex3D.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityBillboardParticlesColour_GpuTex3D.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityBillboardParticlesColour_GpuTex3D.fx, DrawVelocityBillboardParticlesColour_GpuTex3D.fxb, 57, 8);
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
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityBillboardParticlesColour_GpuTex3D.vin[i]));
			index = DrawVelocityBillboardParticlesColour_GpuTex3D.vin[(i + 1)];
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
				return new byte[] {4,188,240,11,207,131,0,1,16,136,0,8,254,255,9,1,0,0,1,220,135,0,1,10,131,0,1,4,131,0,1,28,143,0,17,17,95,95,117,110,117,115,101,100,95,115,97,109,112,108,101,114,135,0,1,3,131,0,4,1,0,0,1,136,0,1,11,131,0,1,4,131,0,1,1,229,0,0,206,0,0,1,6,1,95,1,118,1,115,1,95,1,99,134,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,36,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,48,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,72,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,49,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,108,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,50,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,144,143,0,0,1,7,1,95,1,112,1,115,1,95,1,115,1,48,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,6,131,0,0,1,1,131,0,0,1,8,131,0,0,1,3,131,0,0,1,4,131,0,0,1,24,139,0,0,1,52,131,0,0,1,80,138,0,0,1,1,1,12,1,0,1,0,1,1,1,32,138,0,0,1,1,1,48,1,0,1,0,1,1,1,68,138,0,0,1,1,1,84,1,0,1,0,1,1,1,104,138,0,0,1,1,1,120,1,0,1,0,1,1,1,140,138,0,0,1,1,1,208,135,0,0,1,1,1,0,1,0,1,1,1,204,135,0,0,1,2,131,0,0,1,92,134,0,0,1,1,1,160,1,0,1,0,1,1,1,156,131,0,0,1,93,134,0,0,1,1,1,184,1,0,1,0,1,1,1,180,135,0,0,1,2,136,0,0,132,255,0,131,0,0,1,1,134,0,0,1,1,1,0,1,16,1,42,1,17,132,0,0,1,172,131,0,0,1,84,135,0,0,1,36,135,0,0,1,132,139,0,0,1,92,131,0,0,1,28,131,0,0,1,79,1,255,1,255,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,72,131,0,0,1,48,1,0,1,3,131,0,0,1,1,133,0,0,1,56,132,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,84,1,16,1,0,1,2,132,0,0,1,4,134,0,0,1,24,1,66,1,0,1,3,1,0,1,3,131,0,0,1,1,1,0,1,0,1,48,1,80,1,0,1,0,1,241,1,81,1,0,1,1,1,16,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,48,1,3,1,0,1,0,1,34,133,0,0,1,16,1,8,1,32,1,1,1,31,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,22,1,16,133,0,0,1,27,1,226,1,0,1,0,1,1,1,20,1,14,131,0,0,1,252,1,252,1,27,1,225,1,2,1,1,1,2,1,12,1,135,1,128,1,0,1,0,1,21,1,108,1,108,1,225,151,0,0,132,255,0,138,0,0,1,4,1,112,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,252,1,0,1,0,1,2,1,116,135,0,0,1,36,1,0,1,0,1,1,1,152,1,0,1,0,1,1,1,192,138,0,0,1,1,1,112,131,0,0,1,28,1,0,1,0,1,1,1,97,1,255,1,254,1,3,132,0,0,1,4,131,0,0,1,28,134,0,0,1,1,1,90,131,0,0,1,108,1,0,1,2,131,0,0,1,11,133,0,0,1,116,131,0,0,1,132,1,0,1,0,1,1,1,52,1,0,1,3,131,0,0,1,1,132,0,0,1,1,1,60,134,0,0,1,1,1,76,1,0,1,3,1,0,1,1,1,0,1,1,132,0,0,1,1,1,60,134,0,0,1,1,1,83,1,0,1,3,1,0,1,2,1,0,1,1,132,0,0,1,1,1,60,132,0,0,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,11,229,0,0,209,0,0,1,95,1,118,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,118,1,115,1,95,1,115,1,49,1,0,1,95,1,118,1,115,1,95,1,115,1,50,1,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,131,171,0,135,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,2,1,52,1,0,1,17,1,0,1,8,138,0,0,1,24,1,66,131,0,0,1,1,131,0,0,1,1,131,0,0,1,2,1,0,1,0,1,2,1,144,131,0,0,1,5,1,0,1,0,1,48,1,80,1,0,1,1,1,241,1,81,1,0,1,0,1,16,1,44,1,0,1,0,1,16,1,45,176,0,0,1,63,1,128,1,0,1,0,1,63,139,0,0,1,16,1,9,1,96,1,5,1,80,1,11,1,18,1,0,1,18,1,0,1,1,1,80,132,0,0,1,96,1,16,1,194,1,0,1,18,133,0,0,1,96,1,22,1,96,1,28,1,18,1,0,1,18,133,0,0,1,96,1,34,1,64,1,40,1,18,1,0,1,18,135,0,0,1,32,1,44,1,196,1,0,1,34,131,0,0,1,5,1,248,132,0,0,1,4,1,120,132,0,0,1,176,1,35,1,0,1,1,1,0,1,176,1,177,1,192,1,1,1,10,1,255,1,10,1,168,1,64,1,1,132,0,0,1,65,1,194,1,0,1,0,1,10,1,52,1,18,131,0,0,1,198,1,0,1,198,1,232,1,129,1,0,1,1,1,200,1,8,1,0,1,1,1,1,1,198,1,177,1,177,1,237,1,1,1,0,1,0,1,168,1,64,1,1,132,0,0,1,128,1,194,1,0,1,0,1,10,1,200,1,3,1,0,1,1,1,0,1,196,1,179,1,0,1,224,1,1,1,1,1,0,1,188,1,64,1,1,132,0,0,1,65,1,194,1,0,1,0,1,255,1,33,1,24,1,32,1,33,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,33,1,8,1,64,1,33,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,33,1,40,1,48,1,33,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,200,1,2,1,0,1,1,1,0,1,27,1,177,1,108,1,139,1,3,1,8,1,8,1,200,1,7,1,0,1,6,1,0,1,192,1,198,1,0,1,167,1,3,1,255,1,0,1,200,1,15,1,0,1,5,1,0,1,70,1,190,1,108,1,76,1,255,1,4,1,255,1,200,1,1,1,0,1,1,1,0,1,62,1,0,1,0,1,111,1,5,1,5,1,0,1,200,2,4,0,3,1,0,62,4,0,0,111,4,4,5,0,200,2,131,0,5,64,0,0,243,6,6,0,0,48,40,0,1,7,0,62,0,177,111,6,5,8,0,184,39,0,6,2,20,205,9,65,128,1,7,255,200,7,0,5,10,0,177,205,205,171,0,9,3,168,18,11,1,0,0,98,98,130,208,6,6,255,88,12,40,0,1,0,190,190,177,240,3,3,128,168,13,71,1,8,0,192,177,131,193,6,0,255,160,130,14,1,0,0,98,190,27,240,8,3,129,20,7,0,3,15,1,180,205,177,225,8,5,128,200,7,0,3,1,205,180,16,192,235,8,5,3,4,130,1,0,0,192,192,27,240,3,3,17,1,88,34,0,1,0,27,177,177,225,1,1,128,180,23,3,7,18,0,180,177,65,193,3,0,255,180,39,3,5,0,98,27,128,193,7,19,0,255,180,71,3,6,0,98,205,130,193,8,7,255,200,7,0,1,1,20,180,180,192,235,8,7,6,36,135,1,1,0,192,108,108,225,1,3,128,200,1,7,131,0,21,192,198,192,235,1,0,5,200,7,0,1,0,192,27,192,235,0,4,4,200,1,22,128,62,0,62,62,0,111,0,1,0,200,2,128,62,0,62,62,0,111,1,1,0,23,200,4,128,62,0,62,62,0,111,2,1,0,200,8,128,62,0,62,62,0,111,3,1,17,0,200,3,128,0,0,197,197,0,226,3,3,0,200,15,128,1,132,0,3,226,2,2,140,0,1,0};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[10] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
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
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid2;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[11];
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
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.cid2))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.sid1))
			{
				this.ColourSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.sid2))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.sid3))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.tid1))
			{
				this.ColourTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityBillboardParticles_GpuTex3D_UserOffset' generated from file 'VelocityBillboard3D.fx'</para><para>Vertex Shader: approximately 55 instruction slots used (6 texture, 49 arithmetic), 11 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityBillboardParticles_GpuTex3D_UserOffset : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityBillboardParticles_GpuTex3D_UserOffset' shader</summary>
		public DrawVelocityBillboardParticles_GpuTex3D_UserOffset()
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
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.cid2 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid1 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid2 = state.GetNameUniqueID("UserSampler");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid3 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid3 = state.GetNameUniqueID("UserTexture");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd))
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
				DrawVelocityBillboardParticles_GpuTex3D_UserOffset.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityBillboardParticles_GpuTex3D_UserOffset.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityBillboardParticles_GpuTex3D_UserOffset.fx, DrawVelocityBillboardParticles_GpuTex3D_UserOffset.fxb, 58, 8);
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
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityBillboardParticles_GpuTex3D_UserOffset.vin[i]));
			index = DrawVelocityBillboardParticles_GpuTex3D_UserOffset.vin[(i + 1)];
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
				return new byte[] {4,188,240,11,207,131,0,1,16,136,0,8,254,255,9,1,0,0,1,220,135,0,1,10,131,0,1,4,131,0,1,28,143,0,17,17,95,95,117,110,117,115,101,100,95,115,97,109,112,108,101,114,135,0,1,3,131,0,4,1,0,0,1,136,0,1,11,131,0,1,4,131,0,1,1,229,0,0,206,0,0,1,6,1,95,1,118,1,115,1,95,1,99,134,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,36,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,48,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,72,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,49,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,108,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,50,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,144,143,0,0,1,7,1,95,1,112,1,115,1,95,1,115,1,48,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,6,131,0,0,1,1,131,0,0,1,8,131,0,0,1,3,131,0,0,1,4,131,0,0,1,24,139,0,0,1,52,131,0,0,1,80,138,0,0,1,1,1,12,1,0,1,0,1,1,1,32,138,0,0,1,1,1,48,1,0,1,0,1,1,1,68,138,0,0,1,1,1,84,1,0,1,0,1,1,1,104,138,0,0,1,1,1,120,1,0,1,0,1,1,1,140,138,0,0,1,1,1,208,135,0,0,1,1,1,0,1,0,1,1,1,204,135,0,0,1,2,131,0,0,1,92,134,0,0,1,1,1,160,1,0,1,0,1,1,1,156,131,0,0,1,93,134,0,0,1,1,1,184,1,0,1,0,1,1,1,180,135,0,0,1,2,136,0,0,132,255,0,131,0,0,1,1,134,0,0,1,1,1,0,1,16,1,42,1,17,132,0,0,1,172,131,0,0,1,84,135,0,0,1,36,135,0,0,1,132,139,0,0,1,92,131,0,0,1,28,131,0,0,1,79,1,255,1,255,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,72,131,0,0,1,48,1,0,1,3,131,0,0,1,1,133,0,0,1,56,132,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,84,1,16,1,0,1,2,132,0,0,1,4,134,0,0,1,24,1,66,1,0,1,3,1,0,1,3,131,0,0,1,1,1,0,1,0,1,48,1,80,1,0,1,0,1,241,1,81,1,0,1,1,1,16,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,48,1,3,1,0,1,0,1,34,133,0,0,1,16,1,8,1,32,1,1,1,31,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,22,1,16,133,0,0,1,27,1,226,1,0,1,0,1,1,1,20,1,14,131,0,0,1,252,1,252,1,27,1,225,1,2,1,1,1,2,1,12,1,135,1,128,1,0,1,0,1,21,1,108,1,108,1,225,151,0,0,132,255,0,138,0,0,1,4,1,112,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,252,1,0,1,0,1,2,1,116,135,0,0,1,36,1,0,1,0,1,1,1,152,1,0,1,0,1,1,1,192,138,0,0,1,1,1,112,131,0,0,1,28,1,0,1,0,1,1,1,97,1,255,1,254,1,3,132,0,0,1,4,131,0,0,1,28,134,0,0,1,1,1,90,131,0,0,1,108,1,0,1,2,131,0,0,1,11,133,0,0,1,116,131,0,0,1,132,1,0,1,0,1,1,1,52,1,0,1,3,131,0,0,1,1,132,0,0,1,1,1,60,134,0,0,1,1,1,76,1,0,1,3,1,0,1,1,1,0,1,1,132,0,0,1,1,1,60,134,0,0,1,1,1,83,1,0,1,3,1,0,1,2,1,0,1,1,132,0,0,1,1,1,60,132,0,0,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,11,229,0,0,209,0,0,1,95,1,118,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,118,1,115,1,95,1,115,1,49,1,0,1,95,1,118,1,115,1,95,1,115,1,50,1,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,131,171,0,135,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,2,1,52,1,0,1,17,1,0,1,8,138,0,0,1,24,1,66,131,0,0,1,1,131,0,0,1,1,131,0,0,1,2,1,0,1,0,1,2,1,144,131,0,0,1,5,1,0,1,0,1,48,1,80,1,0,1,1,1,241,1,81,1,0,1,0,1,16,1,45,1,0,1,0,1,16,1,44,176,0,0,1,63,1,128,1,0,1,0,1,63,139,0,0,1,16,1,9,1,96,1,5,1,80,1,11,1,18,1,0,1,18,1,0,1,1,1,80,132,0,0,1,96,1,16,1,194,1,0,1,18,133,0,0,1,96,1,22,1,96,1,28,1,18,1,0,1,18,133,0,0,1,96,1,34,1,64,1,40,1,18,1,0,1,18,135,0,0,1,32,1,44,1,196,1,0,1,34,131,0,0,1,5,1,248,132,0,0,1,4,1,120,132,0,0,1,176,1,35,1,0,1,1,1,0,1,176,1,177,1,192,1,1,1,10,1,255,1,10,1,168,1,64,1,1,132,0,0,1,65,1,194,1,0,1,0,1,10,1,52,1,18,131,0,0,1,198,1,0,1,198,1,232,1,129,1,0,1,1,1,200,1,8,1,0,1,1,1,1,1,198,1,177,1,177,1,237,1,1,1,0,1,0,1,168,1,64,1,1,132,0,0,1,128,1,194,1,0,1,0,1,10,1,200,1,3,1,0,1,1,1,0,1,196,1,179,1,0,1,224,1,1,1,1,1,0,1,188,1,64,1,1,132,0,0,1,65,1,194,1,0,1,0,1,255,1,33,1,8,1,64,1,33,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,33,1,40,1,48,1,33,1,15,1,31,1,254,1,209,1,0,1,0,1,64,1,0,1,33,1,24,1,32,1,33,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,200,1,2,1,0,1,1,1,0,1,27,1,177,1,108,1,139,1,2,1,8,1,8,1,200,1,13,1,0,1,1,1,0,1,240,1,198,1,0,1,167,1,2,1,255,1,0,1,36,1,130,1,3,1,0,1,0,1,84,1,0,1,108,1,243,1,1,1,0,1,128,1,48,1,39,1,0,1,3,1,0,1,192,1,192,1,177,1,224,1,4,1,3,1,0,1,200,2,4,0,3,1,0,62,4,62,0,111,4,5,3,0,200,8,0,6,1,0,62,62,0,111,7,6,3,0,184,33,0,1,8,0,62,62,65,79,5,3,255,9,200,7,0,5,0,177,205,205,171,10,0,9,2,200,7,0,6,2,20,205,11,0,160,1,7,0,168,18,1,0,0,98,12,98,130,208,6,6,255,88,40,0,1,0,190,13,190,177,240,2,2,128,168,71,1,8,0,192,177,14,131,193,6,0,255,160,130,1,0,0,98,190,27,240,15,8,2,129,20,7,0,2,1,180,205,177,225,8,5,128,16,200,7,0,2,1,205,180,192,235,8,5,2,4,130,1,0,17,0,192,192,27,240,2,2,1,88,34,0,1,0,27,177,177,225,18,1,1,128,180,23,2,7,0,180,177,65,193,2,0,255,180,39,2,19,5,0,98,27,128,193,7,0,255,180,71,2,6,0,98,205,130,193,8,20,7,255,200,7,0,1,1,180,180,192,235,8,7,6,36,135,1,1,0,192,8,108,108,225,1,2,128,200,7,131,0,21,192,198,192,235,1,0,5,200,7,0,1,0,192,27,192,235,0,4,3,200,1,22,128,62,0,62,62,0,111,0,1,0,200,2,128,62,0,62,62,0,111,1,1,0,23,200,4,128,62,0,62,62,0,111,2,1,0,200,8,128,62,0,62,62,0,111,3,1,5,0,36,254,192,1,131,0,16,108,226,0,0,128,200,3,128,0,0,197,197,0,226,2,2,140,0,1,0};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[10] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
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
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid2;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[11];
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
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.cid2))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid1))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid2))
			{
				this.UserSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid3))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid3))
			{
				this.UserTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset' generated from file 'VelocityBillboard3D.fx'</para><para>Vertex Shader: approximately 57 instruction slots used (8 texture, 49 arithmetic), 11 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset' shader</summary>
		public DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset()
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
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.cid2 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid1 = state.GetNameUniqueID("ColourSampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid2 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid3 = state.GetNameUniqueID("UserSampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid4 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid1 = state.GetNameUniqueID("ColourTexture");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid3 = state.GetNameUniqueID("UserTexture");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd))
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
				DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.fx, DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.fxb, 60, 8);
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
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.vin[i]));
			index = DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.vin[(i + 1)];
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
				return new byte[] {4,188,240,11,207,131,0,1,16,136,0,8,254,255,9,1,0,0,1,208,135,0,1,3,131,0,1,1,131,0,1,208,135,0,1,11,131,0,1,4,131,0,1,1,229,0,0,206,0,0,1,6,1,95,1,118,1,115,1,95,1,99,134,0,0,1,12,131,0,0,1,4,131,0,0,1,244,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,48,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,24,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,49,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,60,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,50,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,96,143,0,0,1,7,1,95,1,118,1,115,1,95,1,115,1,51,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,1,1,132,143,0,0,1,7,1,95,1,112,1,115,1,95,1,115,1,48,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,6,131,0,0,1,1,131,0,0,1,8,131,0,0,1,3,131,0,0,1,4,131,0,0,1,32,139,0,0,1,220,131,0,0,1,240,138,0,0,1,1,131,0,0,1,1,1,20,138,0,0,1,1,1,36,1,0,1,0,1,1,1,56,138,0,0,1,1,1,72,1,0,1,0,1,1,1,92,138,0,0,1,1,1,108,1,0,1,0,1,1,1,128,138,0,0,1,1,1,196,135,0,0,1,1,1,0,1,0,1,1,1,192,135,0,0,1,2,131,0,0,1,92,134,0,0,1,1,1,148,1,0,1,0,1,1,1,144,131,0,0,1,93,134,0,0,1,1,1,172,1,0,1,0,1,1,1,168,135,0,0,1,2,136,0,0,132,255,0,131,0,0,1,1,134,0,0,1,1,1,0,1,16,1,42,1,17,132,0,0,1,172,131,0,0,1,84,135,0,0,1,36,135,0,0,1,132,139,0,0,1,92,131,0,0,1,28,131,0,0,1,79,1,255,1,255,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,72,131,0,0,1,48,1,0,1,3,131,0,0,1,1,133,0,0,1,56,132,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,84,1,16,1,0,1,2,132,0,0,1,4,134,0,0,1,24,1,66,1,0,1,3,1,0,1,3,131,0,0,1,1,1,0,1,0,1,48,1,80,1,0,1,0,1,241,1,81,1,0,1,1,1,16,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,48,1,3,1,0,1,0,1,34,133,0,0,1,16,1,8,1,32,1,1,1,31,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,22,1,16,133,0,0,1,27,1,226,1,0,1,0,1,1,1,20,1,14,131,0,0,1,252,1,252,1,27,1,225,1,2,1,1,1,2,1,12,1,135,1,128,1,0,1,0,1,21,1,108,1,108,1,225,151,0,0,132,255,0,138,0,0,1,4,1,148,1,16,1,42,1,17,1,1,1,0,1,0,1,2,1,20,1,0,1,0,1,2,1,128,135,0,0,1,36,1,0,1,0,1,1,1,176,1,0,1,0,1,1,1,216,138,0,0,1,1,1,136,131,0,0,1,28,1,0,1,0,1,1,1,124,1,255,1,254,1,3,132,0,0,1,5,131,0,0,1,28,134,0,0,1,1,1,117,131,0,0,1,128,1,0,1,2,131,0,0,1,11,133,0,0,1,136,131,0,0,1,152,1,0,1,0,1,1,1,72,1,0,1,3,131,0,0,1,1,132,0,0,1,1,1,80,134,0,0,1,1,1,96,1,0,1,3,1,0,1,1,1,0,1,1,132,0,0,1,1,1,80,134,0,0,1,1,1,103,1,0,1,3,1,0,1,2,1,0,1,1,132,0,0,1,1,1,80,134,0,0,1,1,1,110,1,0,1,3,1,0,1,3,1,0,1,1,132,0,0,1,1,1,80,132,0,0,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,2,0,1,3,0,4,0,1,11,229,0,0,209,0,0,1,95,1,118,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,95,1,118,1,115,1,95,1,115,1,49,1,0,1,95,1,118,1,115,1,95,1,115,1,50,1,0,1,95,1,118,1,115,1,95,1,115,1,51,1,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,136,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,2,1,64,1,0,1,17,1,0,1,9,138,0,0,1,24,1,66,131,0,0,1,1,131,0,0,1,1,131,0,0,1,2,1,0,1,0,1,2,1,144,131,0,0,1,5,1,0,1,0,1,48,1,80,1,0,1,1,1,241,1,81,1,0,1,0,1,16,1,45,1,0,1,0,1,16,1,46,176,0,0,1,63,1,128,1,0,1,0,1,63,139,0,0,1,16,1,9,1,96,1,5,1,96,1,11,1,18,1,0,1,18,1,0,1,5,1,80,132,0,0,1,96,1,17,1,194,1,0,1,18,133,0,0,1,96,1,23,1,96,1,29,1,18,1,0,1,18,133,0,0,1,96,1,35,1,64,1,41,1,18,1,0,1,18,135,0,0,1,32,1,45,1,196,1,0,1,34,131,0,0,1,5,1,248,132,0,0,1,4,1,120,132,0,0,1,176,1,35,1,0,1,1,1,0,1,176,1,177,1,192,1,1,1,10,1,255,1,10,1,168,1,64,1,1,132,0,0,1,65,1,194,1,0,1,0,1,10,1,52,1,18,131,0,0,1,198,1,0,1,198,1,232,1,129,1,0,1,1,1,200,1,8,1,0,1,1,1,1,1,198,1,177,1,177,1,237,1,1,1,0,1,0,1,168,1,64,1,1,132,0,0,1,128,1,194,1,0,1,0,1,10,1,200,1,3,1,0,1,1,1,0,1,196,1,179,1,0,1,224,1,1,1,1,1,0,1,188,1,64,1,1,132,0,0,1,65,1,194,1,0,1,0,1,255,1,33,1,24,1,32,1,33,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,33,1,8,1,80,1,33,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,33,1,56,1,64,1,33,1,15,1,31,1,254,1,209,1,0,1,0,1,64,1,0,1,33,1,40,1,48,1,33,1,15,1,31,1,246,1,136,1,0,1,0,1,64,1,0,1,200,1,2,1,0,1,1,1,0,1,27,1,177,1,108,1,139,1,3,1,8,1,8,1,200,1,13,1,0,1,1,1,0,1,240,1,198,2,0,167,3,3,255,0,4,36,130,4,0,5,0,84,0,108,243,6,1,0,128,48,39,0,7,4,0,192,192,177,224,5,8,4,0,200,4,0,1,0,62,9,62,0,111,4,4,0,200,8,0,10,1,0,62,62,0,111,6,4,0,184,11,33,0,1,0,62,62,65,79,5,4,255,12,200,7,0,6,0,177,205,205,171,0,9,3,13,200,7,0,7,2,20,205,0,160,1,7,0,168,14,18,1,0,0,98,98,130,208,7,7,255,88,40,0,15,1,0,190,190,177,240,3,3,128,168,71,1,9,0,192,16,177,131,193,7,0,255,160,130,1,0,0,98,190,27,240,9,17,3,129,20,7,0,3,1,180,205,177,225,9,6,128,200,7,0,18,3,1,205,180,192,235,9,6,3,4,130,1,0,0,192,192,27,240,19,3,3,1,88,34,0,1,0,27,177,177,225,1,1,128,180,23,3,8,20,0,180,177,65,193,3,0,255,180,39,3,6,0,98,27,128,193,8,0,255,21,180,71,3,7,0,98,205,130,193,9,8,255,200,7,0,1,1,180,180,192,235,17,9,8,7,36,135,1,1,0,192,108,108,225,1,3,128,200,7,131,0,22,192,198,192,235,1,0,6,200,7,0,1,0,192,27,192,235,0,5,4,200,1,128,23,62,0,62,62,0,111,0,1,0,200,2,128,62,0,62,62,0,111,1,1,0,200,4,24,128,62,0,62,62,0,111,2,1,0,200,8,128,62,0,62,62,0,111,3,1,0,200,3,14,128,0,0,197,197,0,226,3,3,0,200,15,128,1,132,0,3,226,2,2,140,0,1,0};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[10] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
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
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid2;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[11];
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
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.cid2))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid1))
			{
				this.ColourSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid2))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid3))
			{
				this.UserSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid4))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid1))
			{
				this.ColourTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid3))
			{
				this.UserTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid4))
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
	
	/// <summary><para>Technique 'DrawVelocityBillboardParticles_GpuTex3D' generated from file 'VelocityBillboard3D.fx'</para><para>Vertex Shader: approximately 52 instruction slots used (4 texture, 48 arithmetic), 11 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityBillboardParticles_GpuTex3D : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityBillboardParticles_GpuTex3D' shader</summary>
		public DrawVelocityBillboardParticles_GpuTex3D()
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
			DrawVelocityBillboardParticles_GpuTex3D.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityBillboardParticles_GpuTex3D.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawVelocityBillboardParticles_GpuTex3D.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityBillboardParticles_GpuTex3D.cid2 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawVelocityBillboardParticles_GpuTex3D.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawVelocityBillboardParticles_GpuTex3D.sid1 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityBillboardParticles_GpuTex3D.sid2 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityBillboardParticles_GpuTex3D.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityBillboardParticles_GpuTex3D.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawVelocityBillboardParticles_GpuTex3D.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityBillboardParticles_GpuTex3D.gd))
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
				DrawVelocityBillboardParticles_GpuTex3D.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityBillboardParticles_GpuTex3D.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityBillboardParticles_GpuTex3D.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityBillboardParticles_GpuTex3D.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityBillboardParticles_GpuTex3D.fx, DrawVelocityBillboardParticles_GpuTex3D.fxb, 55, 8);
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
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityBillboardParticles_GpuTex3D.vin[i]));
			index = DrawVelocityBillboardParticles_GpuTex3D.vin[(i + 1)];
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
				return new byte[] {152,8,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,223,247,107,202,239,9,253,255,215,161,255,255,78,222,247,120,126,115,250,255,239,255,251,175,151,235,38,159,253,254,77,182,88,149,121,253,107,252,254,191,239,175,243,107,227,253,95,195,252,243,107,252,26,191,161,190,175,127,254,127,234,249,245,232,255,191,255,101,243,251,79,233,231,111,244,107,200,56,126,183,206,64,126,125,109,211,236,184,54,223,30,106,179,235,218,148,177,54,43,129,131,175,126,51,109,231,63,191,22,253,255,55,141,124,110,64,1,198,235,121,54,163,153,248,53,126,93,253,28,159,97,78,240,206,111,231,189,179,79,255,127,233,253,253,27,81,227,212,195,105,135,126,127,234,253,253,134,126,159,123,127,255,77,250,59,126,252,85,250,59,240,251,83,244,251,159,161,207,222,209,255,255,84,253,251,79,163,223,255,36,175,157,121,254,111,122,44,88,252,242,107,255,223,255,247,255,245,127,255,174,191,198,201,155,227,39,224,185,47,127,13,249,12,95,41,15,166,223,166,127,118,126,13,25,215,175,73,208,14,244,117,165,223,95,251,235,16,149,127,77,254,79,30,250,248,222,239,191,243,107,124,81,76,235,170,169,206,219,116,235,213,157,244,219,207,95,63,79,133,90,233,73,181,88,21,196,192,233,195,241,222,167,227,135,247,247,198,123,7,251,251,191,198,239,66,168,18,29,255,32,234,233,79,146,223,127,205,63,232,215,252,53,126,83,254,157,192,254,73,191,198,111,240,155,254,69,79,24,141,223,148,218,252,103,244,247,127,246,23,253,186,252,247,175,143,191,169,237,127,134,33,255,90,191,230,175,241,155,211,239,255,247,159,196,223,253,6,230,187,95,227,15,146,191,127,3,250,251,255,230,191,255,239,255,91,17,254,53,132,46,230,247,95,142,201,251,181,255,47,162,203,212,210,229,187,191,166,124,6,26,24,186,188,164,207,126,239,95,67,144,251,13,233,223,63,128,126,174,240,197,175,233,104,181,165,68,57,224,207,64,163,95,239,215,248,61,245,51,225,245,191,246,175,253,53,249,155,95,135,101,247,255,139,143,202,99,143,15,84,6,123,159,95,126,77,254,248,9,18,179,223,240,215,248,77,255,34,2,241,123,208,244,253,131,2,237,15,250,61,148,63,254,160,95,163,195,43,230,247,95,211,253,142,54,255,145,225,51,162,187,254,254,107,254,65,191,22,125,78,211,254,235,224,179,95,227,215,248,175,255,36,154,139,191,8,255,255,181,120,42,127,205,63,40,249,53,254,26,244,43,60,69,127,3,22,233,234,191,232,183,100,184,191,22,254,254,99,127,99,254,238,215,225,239,232,255,127,240,111,193,240,208,246,175,161,255,127,133,255,255,193,94,251,63,200,192,150,246,95,253,193,128,253,107,234,119,201,175,241,213,95,244,107,114,219,95,243,15,2,30,191,14,171,148,95,155,62,255,207,128,7,120,253,15,146,207,126,35,134,253,27,254,26,127,26,225,251,183,253,69,191,63,195,128,124,252,111,127,16,228,227,247,231,62,228,239,95,147,254,198,59,52,86,122,255,119,163,119,254,65,122,231,191,249,139,126,140,218,252,218,212,239,175,197,48,255,51,253,251,215,225,191,127,93,251,247,175,201,127,255,122,244,55,240,254,181,72,230,126,109,250,251,215,255,53,254,149,191,248,55,224,191,127,3,254,254,215,226,207,126,141,95,75,254,254,191,89,230,208,86,190,251,191,255,32,211,22,50,137,255,255,70,22,246,255,253,7,227,123,255,221,95,207,251,253,215,210,118,52,152,63,248,55,252,53,254,111,30,199,175,205,56,252,26,127,208,143,253,26,255,52,209,228,159,230,190,126,29,237,11,184,153,54,191,214,175,241,175,208,223,255,52,198,246,7,255,110,4,243,215,81,220,127,93,134,41,237,127,29,254,222,181,255,117,248,157,255,236,15,54,48,127,29,198,247,175,249,147,128,255,175,193,248,254,211,140,191,204,1,230,12,99,251,234,47,250,13,60,158,1,222,52,87,127,156,180,177,243,252,7,1,127,163,183,126,109,134,251,107,40,28,209,85,212,230,79,250,117,44,108,163,191,254,111,158,115,225,137,223,128,97,252,152,244,243,31,41,45,245,239,95,235,63,146,246,230,239,95,135,255,254,181,236,223,191,1,255,77,253,50,127,129,239,1,11,186,240,255,9,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[10] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
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
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid2;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[11];
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
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.cid2))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.sid1))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.sid2))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityBillboardParticlesColour_GpuTex3D' generated from file 'VelocityBillboard3D.fx'</para><para>Vertex Shader: approximately 54 instruction slots used (6 texture, 48 arithmetic), 11 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityBillboardParticlesColour_GpuTex3D : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityBillboardParticlesColour_GpuTex3D' shader</summary>
		public DrawVelocityBillboardParticlesColour_GpuTex3D()
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
			DrawVelocityBillboardParticlesColour_GpuTex3D.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityBillboardParticlesColour_GpuTex3D.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawVelocityBillboardParticlesColour_GpuTex3D.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityBillboardParticlesColour_GpuTex3D.cid2 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawVelocityBillboardParticlesColour_GpuTex3D.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D.sid1 = state.GetNameUniqueID("ColourSampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D.sid2 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D.sid3 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityBillboardParticlesColour_GpuTex3D.tid1 = state.GetNameUniqueID("ColourTexture");
			DrawVelocityBillboardParticlesColour_GpuTex3D.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawVelocityBillboardParticlesColour_GpuTex3D.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityBillboardParticlesColour_GpuTex3D.gd))
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
				DrawVelocityBillboardParticlesColour_GpuTex3D.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityBillboardParticlesColour_GpuTex3D.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityBillboardParticlesColour_GpuTex3D.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityBillboardParticlesColour_GpuTex3D.fx, DrawVelocityBillboardParticlesColour_GpuTex3D.fxb, 57, 8);
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
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityBillboardParticlesColour_GpuTex3D.vin[i]));
			index = DrawVelocityBillboardParticlesColour_GpuTex3D.vin[(i + 1)];
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
				return new byte[] {8,9,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,127,244,107,202,239,9,253,255,215,161,255,255,78,222,247,120,126,115,250,255,239,255,251,175,151,235,38,159,253,254,77,182,88,149,121,253,107,252,254,191,239,175,243,107,227,253,95,195,252,243,107,252,26,191,161,190,175,127,254,127,234,249,245,232,255,191,255,101,243,251,79,233,231,111,244,107,200,56,126,183,206,64,126,125,109,211,236,184,54,223,30,106,179,235,218,148,67,109,246,92,155,63,41,214,102,197,125,253,223,248,234,55,211,118,254,243,107,209,255,127,211,200,231,6,20,96,188,158,103,51,154,45,30,31,62,255,13,232,255,152,55,188,243,219,121,239,236,211,255,95,122,127,255,70,212,56,245,112,218,161,223,159,122,127,191,161,223,231,222,223,239,232,247,63,206,251,251,95,211,223,241,227,159,211,223,129,239,159,162,223,255,69,244,217,159,71,255,255,83,245,239,191,139,126,255,219,188,118,230,249,191,233,177,96,241,203,175,253,127,255,223,255,215,255,253,187,254,26,39,111,142,159,128,79,191,252,53,228,51,124,165,124,155,126,155,254,217,249,53,100,156,191,38,65,59,208,215,149,158,127,237,175,67,84,255,53,249,63,121,232,227,123,191,255,206,175,241,69,49,173,171,166,58,111,211,173,87,119,210,111,63,127,253,60,21,234,165,39,213,98,85,16,211,167,15,199,123,159,142,31,222,223,27,239,29,236,239,255,26,191,11,161,250,235,254,26,191,198,31,68,61,253,73,242,251,175,249,7,253,154,191,198,111,202,191,19,216,63,233,215,248,13,126,211,191,232,9,163,241,155,82,155,255,140,254,254,207,254,162,95,151,255,254,245,241,55,181,253,207,48,237,191,214,175,249,107,252,230,244,251,255,253,39,241,119,191,129,249,238,215,248,131,228,239,223,128,254,254,191,249,239,255,251,255,86,132,127,13,161,139,249,125,135,26,254,26,191,246,255,69,116,89,90,186,252,161,191,166,124,230,201,115,250,51,244,89,249,107,8,114,191,33,253,219,210,207,63,140,254,191,255,107,58,90,61,86,162,60,231,207,64,163,95,143,231,26,207,140,63,251,181,232,179,196,242,180,200,204,95,251,215,254,154,220,250,215,97,29,240,255,197,71,229,186,199,27,42,203,241,207,247,250,159,95,126,77,94,250,137,95,227,215,248,117,127,195,95,227,55,253,139,8,196,239,65,83,253,15,10,180,63,232,247,80,94,250,131,126,141,14,95,153,223,127,77,239,247,95,203,253,142,246,255,145,225,79,154,27,253,253,215,252,131,126,45,250,252,215,226,233,254,53,255,160,228,215,248,107,208,159,240,29,253,141,247,200,6,252,69,191,37,195,248,181,240,247,31,251,27,243,119,191,14,127,71,255,255,131,127,11,250,227,215,228,182,127,13,253,255,43,252,255,15,246,218,255,65,6,182,180,255,234,15,6,236,95,83,191,75,126,141,175,32,246,191,22,190,39,62,249,139,126,29,86,67,191,54,125,254,159,1,15,200,195,31,36,159,253,70,12,251,55,252,53,254,180,191,232,55,252,53,254,182,191,232,247,167,70,192,251,215,248,53,254,183,63,232,215,36,25,250,117,24,135,95,155,254,254,175,255,36,192,193,255,127,127,238,7,114,246,191,253,65,144,179,223,159,241,144,191,127,45,125,135,96,80,31,191,27,193,253,7,233,157,255,230,47,250,49,106,67,252,76,56,163,223,255,76,255,254,117,248,239,95,215,254,253,107,242,223,191,30,253,253,107,49,30,191,254,31,244,107,211,223,191,254,175,241,175,252,197,191,1,255,253,27,240,247,191,22,127,246,107,252,90,242,247,255,205,178,139,182,242,221,255,253,7,153,182,144,109,252,255,55,178,176,255,239,63,24,223,251,239,254,122,222,239,191,150,182,163,193,252,193,191,225,175,241,127,243,56,126,109,198,225,215,248,131,126,236,215,248,167,137,110,255,52,247,245,235,104,95,192,205,180,249,181,126,141,127,133,254,254,167,49,182,63,248,119,35,152,191,142,226,254,235,50,76,105,255,235,240,247,174,253,175,195,239,252,103,127,176,129,249,235,48,190,127,205,159,4,252,127,13,198,247,159,102,252,101,158,48,175,24,219,87,127,17,125,255,23,153,185,7,222,52,159,127,156,180,177,188,240,7,1,127,163,255,126,109,134,251,107,40,28,209,121,212,230,79,250,117,44,108,163,7,255,111,230,11,225,155,223,128,97,252,152,244,243,31,41,45,245,239,95,235,63,146,246,230,239,95,135,255,254,181,236,223,191,1,255,77,253,254,69,208,163,255,79,0,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[10] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
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
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid2;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[11];
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
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.cid2))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.sid1))
			{
				this.ColourSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.sid2))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.sid3))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.tid1))
			{
				this.ColourTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityBillboardParticles_GpuTex3D_UserOffset' generated from file 'VelocityBillboard3D.fx'</para><para>Vertex Shader: approximately 55 instruction slots used (6 texture, 49 arithmetic), 11 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityBillboardParticles_GpuTex3D_UserOffset : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityBillboardParticles_GpuTex3D_UserOffset' shader</summary>
		public DrawVelocityBillboardParticles_GpuTex3D_UserOffset()
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
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.cid2 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid1 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid2 = state.GetNameUniqueID("UserSampler");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid3 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid3 = state.GetNameUniqueID("UserTexture");
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd))
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
				DrawVelocityBillboardParticles_GpuTex3D_UserOffset.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityBillboardParticles_GpuTex3D_UserOffset.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityBillboardParticles_GpuTex3D_UserOffset.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityBillboardParticles_GpuTex3D_UserOffset.fx, DrawVelocityBillboardParticles_GpuTex3D_UserOffset.fxb, 58, 8);
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
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityBillboardParticles_GpuTex3D_UserOffset.vin[i]));
			index = DrawVelocityBillboardParticles_GpuTex3D_UserOffset.vin[(i + 1)];
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
				return new byte[] {28,9,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,127,244,107,202,239,9,253,255,215,161,255,255,78,222,247,120,126,115,250,255,239,255,251,175,151,235,38,159,253,254,77,182,88,149,121,253,107,252,254,191,239,175,243,107,227,253,95,195,252,243,107,252,26,191,161,190,175,127,254,127,234,249,245,232,255,191,255,101,243,251,79,233,231,111,244,107,200,56,126,183,206,64,126,125,109,211,236,184,54,223,30,106,179,235,218,148,67,109,246,92,155,63,41,214,102,197,125,253,223,248,234,55,211,118,254,243,107,209,255,127,211,200,231,6,20,96,188,158,103,51,154,45,30,31,62,255,13,232,255,152,55,188,243,219,121,239,236,211,255,95,122,127,255,70,212,56,245,112,218,161,223,159,122,127,191,161,223,231,222,223,239,232,247,63,206,251,251,95,211,223,241,227,159,211,223,129,239,159,162,223,255,69,244,217,159,71,255,255,83,245,239,191,139,126,255,219,188,118,230,249,191,233,177,96,241,203,175,253,127,255,223,255,215,255,253,187,254,26,39,111,142,159,128,79,191,252,53,228,51,124,165,124,155,126,155,254,217,249,53,100,156,191,38,65,59,208,215,149,158,127,237,175,67,84,255,53,249,63,121,232,227,123,191,255,206,175,241,69,49,173,171,166,58,111,211,173,87,119,210,111,63,127,253,60,21,234,165,39,213,98,85,16,211,167,15,199,123,159,142,31,222,223,27,239,29,236,239,255,26,191,11,161,250,235,254,26,191,198,31,68,61,253,73,242,251,175,249,7,253,154,191,198,111,202,191,19,216,63,233,215,248,13,126,211,191,232,9,163,241,155,82,155,255,140,254,254,207,254,162,95,151,255,254,245,241,55,181,253,207,48,237,191,214,175,249,107,252,230,244,251,255,253,39,241,119,191,129,249,238,215,248,131,228,239,223,128,254,254,191,249,239,255,251,255,86,132,127,13,161,139,249,253,41,53,252,53,126,237,255,139,232,178,180,116,249,67,127,77,249,204,147,231,244,103,232,179,242,215,16,228,126,67,250,183,165,159,127,24,253,127,255,215,116,180,122,172,68,121,206,159,129,70,191,30,207,53,158,25,127,246,107,209,103,137,229,105,145,153,191,246,175,253,53,185,245,175,195,58,224,255,139,143,202,117,143,55,84,150,227,159,239,245,63,191,252,154,188,244,19,191,198,175,241,235,254,134,191,198,111,250,23,17,136,223,131,166,250,31,20,104,127,208,239,161,188,244,7,253,26,29,190,50,191,255,154,222,239,191,150,251,29,237,255,35,195,159,52,55,250,251,175,249,7,253,90,244,57,241,196,175,131,207,126,141,95,227,191,254,147,104,190,254,34,252,255,215,98,22,248,53,255,160,228,215,248,107,128,131,240,34,253,13,88,100,23,254,162,223,146,225,254,90,248,251,143,253,141,249,187,95,135,191,163,255,255,193,191,5,195,67,219,191,134,254,255,21,254,255,7,123,237,255,32,3,91,218,127,245,7,3,246,175,169,223,37,191,198,87,80,5,191,22,190,7,30,191,14,171,166,95,155,62,255,207,128,7,100,228,15,146,207,126,35,134,253,27,254,26,127,26,225,251,183,253,69,191,63,195,128,92,253,111,127,208,175,69,114,133,191,127,45,253,251,215,208,191,127,13,253,251,215,164,191,127,45,110,255,235,19,188,95,69,248,176,124,145,220,253,6,4,239,255,254,139,126,140,223,253,181,180,175,255,76,255,254,117,248,239,95,215,254,253,107,242,223,191,222,175,33,176,126,45,130,5,56,191,254,175,241,175,252,197,191,1,195,254,13,248,111,249,76,96,147,76,179,12,155,182,248,219,180,133,140,227,255,164,255,127,237,95,155,97,255,223,127,48,190,247,223,253,245,188,223,127,45,109,71,131,250,131,129,51,104,242,107,19,92,250,251,15,250,177,95,227,159,38,90,253,211,220,215,175,163,125,253,218,74,183,95,155,255,254,87,232,239,127,26,99,251,131,127,55,130,249,235,240,123,255,25,183,255,181,181,253,175,195,223,187,246,191,14,191,243,159,253,193,6,230,175,195,248,254,53,127,18,240,199,92,253,90,212,254,215,208,62,100,158,49,182,175,254,162,223,192,227,37,224,77,115,248,199,73,27,59,255,76,115,163,7,127,109,134,251,107,40,28,209,125,212,230,79,250,117,44,108,249,236,215,98,29,40,243,246,107,120,243,70,112,255,35,165,165,254,253,107,253,71,162,63,205,223,191,206,127,36,239,155,191,127,3,254,155,250,101,190,131,60,0,22,116,235,255,19,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[10] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
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
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid2;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[11];
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
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.cid2))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid1))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid2))
			{
				this.UserSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.sid3))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityBillboardParticles_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid3))
			{
				this.UserTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_GpuTex3D_UserOffset.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset' generated from file 'VelocityBillboard3D.fx'</para><para>Vertex Shader: approximately 57 instruction slots used (8 texture, 49 arithmetic), 11 registers</para><para>Pixel Shader: approximately 5 instruction slots used (1 texture, 4 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset' shader</summary>
		public DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset()
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
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.cid0 = state.GetNameUniqueID("invTextureSizeOffset");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.cid1 = state.GetNameUniqueID("velocityScale");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.cid2 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid1 = state.GetNameUniqueID("ColourSampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid2 = state.GetNameUniqueID("PositionSampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid3 = state.GetNameUniqueID("UserSampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid4 = state.GetNameUniqueID("VelocitySampler");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid0 = state.GetNameUniqueID("PositionTexture");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid1 = state.GetNameUniqueID("ColourTexture");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid2 = state.GetNameUniqueID("VelocityTexture");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid3 = state.GetNameUniqueID("UserTexture");
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd))
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
				DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.fx, DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.fxb, 60, 8);
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
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.vin[i]));
			index = DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.vin[(i + 1)];
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
				return new byte[] {76,9,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,191,246,107,202,239,191,54,254,166,255,255,75,250,221,111,72,255,255,117,244,179,255,175,61,191,30,253,255,247,191,108,126,255,41,253,252,141,126,13,25,199,47,239,180,249,245,181,77,179,227,218,252,118,157,193,218,54,187,174,205,227,161,54,123,174,205,31,48,212,230,158,107,243,135,197,218,172,24,159,95,7,95,253,102,218,206,127,126,45,250,255,111,26,249,92,64,253,223,255,55,96,188,158,103,179,188,22,26,224,243,223,224,215,144,185,197,59,169,247,206,191,71,255,255,159,58,64,126,43,15,167,223,141,126,63,240,254,254,54,253,254,251,122,127,151,244,251,31,228,253,253,79,233,239,248,241,15,233,239,192,247,79,209,239,255,52,250,236,79,162,255,255,169,250,247,95,71,191,255,85,94,59,243,252,223,244,88,176,248,229,215,254,191,255,239,255,235,255,254,93,127,141,147,55,199,79,126,39,250,243,203,95,67,62,195,87,191,19,55,250,53,210,111,211,63,59,191,134,225,225,95,235,215,56,208,215,149,158,127,237,175,67,84,255,53,249,63,121,232,227,123,191,255,206,175,241,69,49,173,171,166,58,111,211,173,87,119,210,111,63,127,253,60,21,234,165,39,213,98,85,148,244,203,195,241,222,167,227,135,247,247,198,123,7,251,251,191,198,239,66,168,254,186,52,108,234,233,79,146,223,127,77,34,193,111,202,191,19,216,63,233,215,248,13,126,211,191,232,9,163,241,155,82,155,255,140,254,254,207,254,162,95,151,255,254,245,241,55,181,253,207,64,130,95,235,215,252,53,126,115,250,253,255,254,147,248,187,223,192,124,247,107,252,65,242,247,111,64,127,255,223,252,247,255,253,127,43,194,191,134,208,197,252,142,134,191,198,175,253,127,17,93,174,45,93,254,198,95,83,62,195,87,134,46,160,47,1,99,228,126,67,250,247,143,162,159,127,214,175,33,115,105,104,245,82,137,242,7,240,103,160,209,175,247,107,204,245,179,119,252,217,175,69,159,37,118,174,255,36,254,12,45,127,147,95,227,207,210,207,68,214,254,218,191,246,215,228,207,127,29,214,29,255,95,124,84,31,244,248,69,117,64,252,243,189,129,207,239,245,63,191,252,154,124,247,19,191,198,175,241,235,254,134,191,198,111,250,23,17,136,223,131,102,244,31,20,104,127,208,239,161,124,247,7,253,26,29,30,52,191,255,154,222,239,191,150,247,251,175,237,126,199,187,255,145,225,107,154,63,253,253,215,252,131,126,45,250,252,215,98,54,249,53,255,160,228,215,248,107,208,183,240,43,253,141,247,146,95,227,215,248,139,126,75,134,241,107,225,239,63,246,55,230,239,126,29,254,142,254,255,7,255,22,191,6,244,24,218,254,53,244,255,175,240,255,63,216,107,255,7,25,216,210,254,171,63,24,176,127,77,253,46,249,53,190,250,139,126,77,110,251,107,254,65,196,75,127,209,175,195,234,235,215,166,207,255,51,224,65,120,254,103,127,144,124,246,27,49,236,223,240,215,248,211,254,162,223,240,215,248,219,254,162,223,159,26,1,239,95,227,215,248,223,254,160,95,147,100,239,215,97,28,126,109,250,251,191,254,147,0,7,255,255,253,185,31,200,231,255,246,7,253,218,212,70,223,225,191,127,13,253,251,215,208,191,127,45,250,251,215,226,246,191,62,245,249,171,8,103,150,83,146,223,223,128,250,252,191,255,162,31,227,119,127,45,197,231,63,211,191,127,29,254,251,215,181,127,255,154,252,247,175,247,107,8,172,95,139,96,1,206,175,255,107,252,43,127,241,111,192,176,127,3,254,91,62,19,216,164,27,88,23,152,182,248,219,180,133,174,192,255,201,142,252,218,191,54,195,254,191,255,96,124,239,191,251,235,121,191,255,90,218,142,6,245,7,3,103,208,228,215,38,184,244,247,31,244,99,191,198,63,77,244,252,167,185,175,95,71,251,250,181,149,182,191,54,255,253,175,208,223,255,52,198,246,7,255,110,4,243,215,225,247,254,51,110,255,107,107,251,95,135,191,119,237,127,29,126,231,63,251,131,13,204,95,135,241,253,107,254,36,224,143,249,252,181,168,253,175,161,125,8,47,96,108,95,253,69,244,253,95,100,120,2,120,211,60,255,113,210,198,242,8,211,220,232,211,95,155,225,254,26,10,71,116,40,181,249,147,126,29,11,91,62,251,181,88,151,202,188,253,26,222,188,17,220,255,72,105,169,127,255,90,255,145,232,97,243,247,175,243,31,201,251,230,239,223,128,255,166,126,255,34,232,229,255,39,0,0,255,255};
			}
		}
		/// <summary/>
		private bool vreg_change;
		/// <summary>Name ID for 'invTextureSizeOffset'</summary>
		private static int cid0;
		/// <summary>Set the shader value 'float3 invTextureSizeOffset'</summary><param name="value"/>
		public void SetInvTextureSizeOffset(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[10] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid1;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[8] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
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
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid2;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[9] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[11];
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
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.cid1))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.cid0))
			{
				this.SetInvTextureSizeOffset(ref value);
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.cid2))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid1))
			{
				this.ColourSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid2))
			{
				this.PositionSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid3))
			{
				this.UserSampler = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.sid4))
			{
				this.VelocitySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid0))
			{
				this.PositionTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid1))
			{
				this.ColourTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid2))
			{
				this.VelocityTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid3))
			{
				this.UserTexture = value;
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_GpuTex3D_UserOffset.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityBillboardParticles_BillboardCpu3D' generated from file 'VelocityBillboard3D.fx'</para><para>Vertex Shader: approximately 42 instruction slots used, 160 registers</para><para>Pixel Shader: approximately 6 instruction slots used (1 texture, 5 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityBillboardParticles_BillboardCpu3D : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityBillboardParticles_BillboardCpu3D' shader</summary>
		public DrawVelocityBillboardParticles_BillboardCpu3D()
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
			DrawVelocityBillboardParticles_BillboardCpu3D.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityBillboardParticles_BillboardCpu3D.cid0 = state.GetNameUniqueID("positionData");
			DrawVelocityBillboardParticles_BillboardCpu3D.cid1 = state.GetNameUniqueID("velocityData");
			DrawVelocityBillboardParticles_BillboardCpu3D.cid2 = state.GetNameUniqueID("velocityScale");
			DrawVelocityBillboardParticles_BillboardCpu3D.cid3 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawVelocityBillboardParticles_BillboardCpu3D.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawVelocityBillboardParticles_BillboardCpu3D.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityBillboardParticles_BillboardCpu3D.gd))
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
				DrawVelocityBillboardParticles_BillboardCpu3D.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityBillboardParticles_BillboardCpu3D.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityBillboardParticles_BillboardCpu3D.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityBillboardParticles_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityBillboardParticles_BillboardCpu3D.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityBillboardParticles_BillboardCpu3D.fx, DrawVelocityBillboardParticles_BillboardCpu3D.fxb, 40, 9);
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
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityBillboardParticles_BillboardCpu3D.vin[i]));
			index = DrawVelocityBillboardParticles_BillboardCpu3D.vin[(i + 1)];
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
				return new byte[] {160,25,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,159,150,200,239,191,54,254,166,255,167,250,247,95,68,255,255,117,244,179,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,63,191,158,95,143,254,255,251,95,54,191,255,148,126,254,70,191,134,248,133,79,213,79,52,207,175,143,54,171,230,247,111,118,196,103,252,205,180,157,255,252,90,244,255,223,52,242,185,248,152,255,247,255,13,24,175,231,217,44,175,165,45,62,71,219,95,91,127,166,222,59,35,234,255,247,244,112,248,163,244,119,188,243,7,233,239,128,241,167,232,247,111,232,179,151,244,255,63,85,255,46,233,247,185,215,206,60,255,55,61,198,231,253,141,240,203,175,245,127,255,223,255,215,255,253,187,254,26,39,111,142,159,252,78,244,231,151,191,134,124,134,175,126,39,110,245,107,164,223,166,127,118,126,13,227,67,255,90,191,198,129,190,175,244,248,107,127,29,162,218,175,201,255,201,67,31,239,253,254,59,191,198,23,197,180,174,154,234,188,77,183,94,221,73,191,253,252,245,243,84,70,159,158,84,139,85,81,210,47,15,199,123,159,142,31,222,223,27,239,29,236,239,255,26,191,139,160,250,7,81,79,127,147,249,253,215,252,53,126,83,243,251,159,244,107,252,6,191,233,95,244,132,209,248,77,169,205,127,246,55,253,26,191,193,127,246,23,253,186,252,247,175,143,191,169,237,127,246,55,17,14,191,214,175,249,107,252,118,244,251,255,253,55,225,187,95,203,126,247,127,255,65,242,247,111,64,127,255,223,252,55,218,18,204,63,232,215,162,239,255,239,255,91,145,255,53,132,70,230,247,111,255,198,244,207,175,245,127,17,141,254,226,95,203,210,40,145,207,2,26,37,66,35,32,250,23,41,141,190,253,107,24,190,250,107,255,218,95,147,208,252,53,105,150,255,34,215,205,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,159,71,207,229,215,244,145,127,226,215,248,53,126,221,191,232,215,248,77,255,34,2,241,123,144,123,252,123,24,120,206,119,254,77,255,164,95,135,195,137,95,251,63,250,53,126,141,255,250,79,162,134,127,17,254,255,91,242,247,191,38,125,255,107,252,73,191,22,251,204,252,251,31,140,191,199,242,221,223,244,107,176,191,141,223,127,189,63,232,47,250,53,254,179,191,136,128,252,186,236,107,167,191,27,250,163,239,255,116,122,231,167,255,160,31,163,247,41,14,248,131,224,87,255,57,212,78,254,254,117,248,239,63,215,254,253,107,242,223,127,30,253,253,107,169,143,78,254,249,31,244,231,255,26,255,202,95,252,27,240,223,191,1,127,143,255,255,250,220,39,254,22,31,221,248,243,248,251,55,96,28,126,131,63,232,247,74,255,51,198,193,252,252,141,108,31,255,247,31,140,118,62,140,95,207,251,253,215,210,118,52,174,63,248,47,250,53,190,250,139,126,77,142,1,126,83,11,15,180,250,53,25,183,95,227,15,250,11,127,141,127,154,112,253,167,53,78,176,49,197,31,100,218,252,26,191,198,191,66,127,255,211,136,23,254,224,223,141,250,248,181,116,76,191,46,247,33,237,241,190,223,254,215,226,119,254,179,63,216,192,252,181,120,92,127,205,159,244,27,240,28,1,255,127,218,226,242,227,110,142,254,32,161,25,143,15,127,255,193,50,167,191,22,125,254,127,255,65,127,1,141,227,47,160,57,253,117,44,140,95,131,254,255,213,31,132,241,25,250,253,154,220,207,175,241,7,73,27,67,207,175,254,36,244,255,235,112,200,171,159,165,255,55,247,253,107,40,14,191,166,210,14,176,126,76,112,248,135,208,238,207,208,121,165,175,249,239,63,211,254,253,235,240,223,127,150,253,251,55,224,191,255,108,250,91,98,177,223,244,63,2,44,196,87,255,79,0,0,0,255,255};
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
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid2;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[158] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
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
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid3;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[159] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[160];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[1];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[1];
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityBillboardParticles_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_BillboardCpu3D.cid2))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityBillboardParticles_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_BillboardCpu3D.cid3))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector4[]' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Vector4[] value)
		{
			if ((DrawVelocityBillboardParticles_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_BillboardCpu3D.cid0))
			{
				this.SetPositionData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			if ((id == DrawVelocityBillboardParticles_BillboardCpu3D.cid1))
			{
				this.SetVelocityData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityBillboardParticles_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_BillboardCpu3D.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityBillboardParticles_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticles_BillboardCpu3D.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'DrawVelocityBillboardParticlesColour_BillboardCpu3D' generated from file 'VelocityBillboard3D.fx'</para><para>Vertex Shader: approximately 42 instruction slots used, 235 registers</para><para>Pixel Shader: approximately 6 instruction slots used (1 texture, 5 arithmetic), 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	internal sealed class DrawVelocityBillboardParticlesColour_BillboardCpu3D : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DrawVelocityBillboardParticlesColour_BillboardCpu3D' shader</summary>
		public DrawVelocityBillboardParticlesColour_BillboardCpu3D()
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
			DrawVelocityBillboardParticlesColour_BillboardCpu3D.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DrawVelocityBillboardParticlesColour_BillboardCpu3D.cid0 = state.GetNameUniqueID("colourData");
			DrawVelocityBillboardParticlesColour_BillboardCpu3D.cid1 = state.GetNameUniqueID("positionData");
			DrawVelocityBillboardParticlesColour_BillboardCpu3D.cid2 = state.GetNameUniqueID("velocityData");
			DrawVelocityBillboardParticlesColour_BillboardCpu3D.cid3 = state.GetNameUniqueID("velocityScale");
			DrawVelocityBillboardParticlesColour_BillboardCpu3D.cid4 = state.GetNameUniqueID("worldSpaceYAxis");
			DrawVelocityBillboardParticlesColour_BillboardCpu3D.sid0 = state.GetNameUniqueID("DisplaySampler");
			DrawVelocityBillboardParticlesColour_BillboardCpu3D.tid4 = state.GetNameUniqueID("DisplayTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DrawVelocityBillboardParticlesColour_BillboardCpu3D.gd))
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
				DrawVelocityBillboardParticlesColour_BillboardCpu3D.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DrawVelocityBillboardParticlesColour_BillboardCpu3D.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DrawVelocityBillboardParticlesColour_BillboardCpu3D.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DrawVelocityBillboardParticlesColour_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DrawVelocityBillboardParticlesColour_BillboardCpu3D.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DrawVelocityBillboardParticlesColour_BillboardCpu3D.fx, DrawVelocityBillboardParticlesColour_BillboardCpu3D.fxb, 40, 9);
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
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DrawVelocityBillboardParticlesColour_BillboardCpu3D.vin[i]));
			index = DrawVelocityBillboardParticlesColour_BillboardCpu3D.vin[(i + 1)];
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
				return new byte[] {4,35,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,126,179,95,195,61,191,230,143,253,223,255,215,211,223,84,126,255,181,241,55,253,255,95,250,77,228,239,255,150,254,255,235,232,103,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,255,27,159,95,143,254,255,251,95,54,191,255,148,126,254,70,191,134,196,177,191,92,227,90,243,252,250,104,179,106,126,255,102,71,98,220,223,76,219,249,207,175,69,255,71,120,220,253,92,98,226,255,251,255,6,140,215,243,108,150,215,210,22,159,163,237,175,173,63,83,239,157,127,143,250,255,159,60,28,14,52,238,198,59,59,250,59,96,252,41,250,253,175,131,207,232,255,127,170,254,253,59,209,239,191,157,215,206,60,255,55,61,38,70,255,141,240,203,175,245,127,255,223,255,215,255,253,187,254,26,39,111,142,159,252,78,244,231,151,191,134,124,134,175,126,39,110,245,107,164,223,166,127,118,126,13,19,243,255,90,191,198,129,190,175,244,248,107,127,29,162,218,175,201,255,201,67,31,239,253,254,59,191,198,23,197,180,174,154,234,188,77,183,94,221,73,191,253,252,245,243,84,70,159,158,84,139,85,81,210,47,15,199,123,159,142,31,222,223,27,239,29,236,239,255,26,191,139,160,250,7,81,79,127,147,249,253,215,252,53,126,83,243,251,159,244,107,252,6,191,233,95,244,132,209,248,77,169,205,127,246,55,253,26,191,193,127,246,23,253,186,252,247,175,143,191,169,237,127,246,55,17,14,191,214,175,249,107,252,118,244,251,255,253,55,225,187,95,203,126,247,127,255,65,242,247,111,64,127,255,223,252,55,218,18,204,63,232,215,162,239,255,239,255,91,145,255,53,132,70,230,247,255,227,55,167,127,126,173,255,139,104,244,207,255,218,134,70,255,247,111,34,159,249,52,250,223,126,19,161,17,16,253,111,149,70,223,254,53,12,95,253,181,127,237,175,73,104,254,154,52,203,200,147,252,232,249,209,243,163,231,71,207,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,255,111,122,124,92,46,191,102,76,255,19,191,198,175,241,235,254,183,191,198,111,250,23,17,136,223,131,194,249,223,195,192,115,177,254,111,250,39,253,58,156,254,248,181,255,163,95,227,215,248,175,255,36,138,143,255,34,252,255,183,228,239,127,77,250,254,215,248,147,126,45,142,241,249,247,63,24,127,143,229,187,191,233,215,224,252,0,126,255,245,254,160,255,246,215,248,207,254,34,2,242,235,114,110,32,253,221,208,31,125,255,167,211,59,63,253,7,253,24,189,79,121,139,63,8,121,128,255,156,218,201,223,191,14,255,253,95,216,191,127,77,254,251,191,164,191,127,45,205,41,80,62,225,15,250,175,126,141,127,229,47,254,13,248,239,223,128,191,199,255,127,125,238,19,127,75,78,193,228,31,240,247,111,192,56,252,6,127,208,239,149,254,103,140,131,249,249,27,217,62,254,239,63,24,237,124,24,191,158,247,251,175,165,237,104,92,127,240,127,251,107,124,245,23,253,154,156,179,248,77,45,60,208,234,215,100,220,126,141,63,232,191,249,53,254,105,194,245,159,214,188,134,205,129,252,65,166,205,175,241,107,252,43,244,247,63,141,252,198,31,252,187,81,31,191,150,142,233,215,229,62,164,61,222,247,219,255,90,252,206,127,246,7,27,152,191,22,143,235,175,249,147,126,3,158,35,224,255,79,91,92,126,220,205,209,31,36,52,227,241,225,239,63,88,230,244,215,162,207,255,239,63,232,191,166,113,252,215,52,167,191,142,133,241,107,208,255,191,250,131,48,62,67,191,95,147,251,249,53,254,32,105,99,232,249,213,159,132,254,127,29,78,209,233,103,233,255,205,125,255,26,138,195,175,201,99,249,77,255,163,63,195,253,205,180,4,236,31,19,156,254,33,188,247,31,235,60,211,215,252,247,127,98,255,254,117,248,239,255,212,254,253,27,240,223,255,25,253,141,156,208,255,19,0,0,255,255};
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
		/// <summary>Name ID for 'velocityScale'</summary>
		private static int cid3;
		/// <summary>Set the shader value 'float2 velocityScale'</summary><param name="value"/>
		public void SetVelocityScale(ref Microsoft.Xna.Framework.Vector2 value)
		{
			this.vreg[233] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, 0F, 0F);
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
		/// <summary>Name ID for 'worldSpaceYAxis'</summary>
		private static int cid4;
		/// <summary>Set the shader value 'float3 worldSpaceYAxis'</summary><param name="value"/>
		public void SetWorldSpaceYAxis(ref Microsoft.Xna.Framework.Vector3 value)
		{
			this.vreg[234] = new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, 0F);
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
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[235];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[1];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[1];
		/// <summary>Set a shader attribute of type 'Vector2' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector2 value)
		{
			if ((DrawVelocityBillboardParticlesColour_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_BillboardCpu3D.cid3))
			{
				this.SetVelocityScale(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector3' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, ref Microsoft.Xna.Framework.Vector3 value)
		{
			if ((DrawVelocityBillboardParticlesColour_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_BillboardCpu3D.cid4))
			{
				this.SetWorldSpaceYAxis(ref value);
				return true;
			}
			return false;
		}
		/// <summary>Set a shader attribute of type 'Vector4[]' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Vector4[] value)
		{
			if ((DrawVelocityBillboardParticlesColour_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_BillboardCpu3D.cid0))
			{
				this.SetColourData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_BillboardCpu3D.cid1))
			{
				this.SetPositionData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			if ((id == DrawVelocityBillboardParticlesColour_BillboardCpu3D.cid2))
			{
				this.SetVelocityData(value, 0, 0, ((uint)(value.Length)));
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DrawVelocityBillboardParticlesColour_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_BillboardCpu3D.sid0))
			{
				this.DisplaySampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DrawVelocityBillboardParticlesColour_BillboardCpu3D.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DrawVelocityBillboardParticlesColour_BillboardCpu3D.tid4))
			{
				this.DisplayTexture = value;
				return true;
			}
			return false;
		}
	}
}
#endif
