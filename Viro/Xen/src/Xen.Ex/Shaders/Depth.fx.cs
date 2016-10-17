// XenFX
// Assembly = Xen.Graphics.ShaderSystem.CustomTool, Version=7.0.1.1, Culture=neutral, PublicKeyToken=e706afd07878dfca
// SourceFile = Depth.fx
// Namespace = Xen.Ex.Shaders

namespace Xen.Ex.Shaders
{
	
	/// <summary><para>Technique 'DepthOutRg' generated from file 'Depth.fx'</para><para>Vertex Shader: approximately 13 instruction slots used, 10 registers</para><para>Pixel Shader: approximately 5 instruction slots used, 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	public sealed class DepthOutRg : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DepthOutRg' shader</summary>
		public DepthOutRg()
		{
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
			this.sc3 = -1;
			this.sc4 = -1;
			this.sc5 = -1;
			this.sc6 = -1;
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DepthOutRg.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DepthOutRg.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			this.vbreg_change = (this.vbreg_change | ic);
			this.vireg_change = (this.vireg_change | ic);
			// Set the value for attribute 'cameraNearFar'
			this.vreg_change = (this.vreg_change | state.SetCameraNearFarVector2(ref this.vreg[9], ref this.sc0));
			// Set the value for attribute 'viewDirection'
			this.vreg_change = (this.vreg_change | state.SetViewDirectionVector3(ref this.vreg[7], ref this.sc1));
			// Set the value for attribute 'viewPoint'
			this.vreg_change = (this.vreg_change | state.SetViewPointVector3(ref this.vreg[8], ref this.sc2));
			Microsoft.Xna.Framework.Vector4 unused = new Microsoft.Xna.Framework.Vector4();
			// Set the value for attribute 'worldMatrix'
			this.vreg_change = (this.vreg_change | state.SetWorldMatrix(ref this.vreg[4], ref this.vreg[5], ref this.vreg[6], ref unused, ref this.sc3));
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc4));
			if ((this.vreg_change == true))
			{
				DepthOutRg.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			if ((ext == Xen.Graphics.ShaderSystem.ShaderExtension.Blending))
			{
				ic = (ic | state.SetBlendMatricesDirect(DepthOutRg.fx.vsb_c, ref this.sc5));
			}
			if ((ext == Xen.Graphics.ShaderSystem.ShaderExtension.Instancing))
			{
				this.vireg_change = (this.vireg_change | state.SetViewProjectionMatrix(ref this.vireg[0], ref this.vireg[1], ref this.vireg[2], ref this.vireg[3], ref this.sc6));
				if ((this.vireg_change == true))
				{
					DepthOutRg.fx.vsi_c.SetValue(this.vireg);
					this.vireg_change = false;
					ic = true;
				}
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DepthOutRg.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DepthOutRg.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DepthOutRg.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DepthOutRg.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DepthOutRg.fx, DepthOutRg.fxb, 14, 7);
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
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DepthOutRg.vin[i]));
			index = DepthOutRg.vin[(i + 1)];
		}
		/// <summary>Static graphics ID</summary>
		private static int gd;
		/// <summary>Static effect container instance</summary>
		private static Xen.Graphics.ShaderSystem.ShaderEffect fx;
		/// <summary/>
		private bool vreg_change;
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
		/// <summary>Change ID for Semantic bound attribute 'cameraNearFar'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute 'viewDirection'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute 'viewPoint'</summary>
		private int sc2;
		/// <summary>Change ID for Semantic bound attribute 'worldMatrix'</summary>
		private int sc3;
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc4;
		/// <summary>Change ID for Semantic bound attribute '__BLENDMATRICES__GENMATRIX'</summary>
		private int sc5;
		/// <summary>Change ID for Semantic bound attribute 'viewProj'</summary>
		private int sc6;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[10];
		/// <summary>Instancing shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vireg = new Microsoft.Xna.Framework.Vector4[4];
#if XBOX360
		/// <summary>Static RLE compressed shader byte code (Xbox360)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {4,188,240,11,207,131,0,1,32,152,0,8,254,255,9,1,0,0,15,156,135,0,1,3,131,0,1,1,131,0,1,192,135,0,1,10,131,0,1,4,131,0,1,1,229,0,0,190,0,0,1,6,1,95,1,118,1,115,1,95,1,99,134,0,0,1,3,131,0,0,1,1,1,0,1,0,1,14,1,104,135,0,0,1,216,131,0,0,1,4,131,0,0,1,1,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,153,0,0,1,7,1,95,1,118,1,115,1,98,1,95,1,99,133,0,0,1,3,131,0,0,1,1,1,0,1,0,1,14,1,208,135,0,0,1,4,131,0,0,1,4,131,0,0,1,1,195,0,0,1,7,1,95,1,118,1,115,1,105,1,95,1,99,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,3,131,0,0,1,16,131,0,0,1,4,143,0,0,1,4,131,0,0,1,15,131,0,0,1,4,143,0,0,1,9,1,66,1,108,1,101,1,110,1,100,1,105,1,110,1,103,135,0,0,1,5,131,0,0,1,16,131,0,0,1,4,143,0,0,1,6,131,0,0,1,15,131,0,0,1,4,143,0,0,1,11,1,73,1,110,1,115,1,116,1,97,1,110,1,99,1,105,1,110,1,103,133,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,3,131,0,0,1,1,131,0,0,1,9,131,0,0,1,7,131,0,0,1,4,131,0,0,1,32,139,0,0,1,204,131,0,0,1,232,138,0,0,1,14,1,116,1,0,1,0,1,14,1,144,138,0,0,1,15,1,144,135,0,0,1,3,1,0,1,0,1,15,1,12,135,0,0,1,2,131,0,0,1,92,134,0,0,1,14,1,224,1,0,1,0,1,14,1,220,131,0,0,1,93,134,0,0,1,14,1,248,1,0,1,0,1,14,1,244,1,0,1,0,1,15,1,64,135,0,0,1,2,131,0,0,1,92,134,0,0,1,15,1,20,1,0,1,0,1,15,1,16,131,0,0,1,93,134,0,0,1,15,1,44,1,0,1,0,1,15,1,40,1,0,1,0,1,15,1,128,135,0,0,1,2,131,0,0,1,92,134,0,0,1,15,1,84,1,0,1,0,1,15,1,80,131,0,0,1,93,134,0,0,1,15,1,108,1,0,1,0,1,15,1,104,135,0,0,1,6,135,0,0,1,2,132,255,0,131,0,0,1,1,135,0,0,1,172,1,16,1,42,1,17,132,0,0,1,124,131,0,0,1,48,135,0,0,1,36,135,0,0,1,88,139,0,0,1,48,131,0,0,1,28,131,0,0,1,35,1,255,1,255,1,3,144,0,0,1,28,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,48,1,16,134,0,0,1,4,134,0,0,1,4,1,33,1,0,1,1,1,0,1,1,131,0,0,1,1,1,0,1,0,1,16,1,80,132,0,0,1,32,1,1,1,196,1,0,1,34,131,0,0,1,8,1,32,133,0,0,1,108,1,226,131,0,0,1,200,1,139,1,192,1,0,1,0,1,176,1,176,1,0,1,226,150,0,0,1,2,132,255,0,138,0,0,1,2,1,208,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,212,131,0,0,1,252,135,0,0,1,36,134,0,0,1,1,1,144,138,0,0,1,1,1,104,131,0,0,1,28,1,0,1,0,1,1,1,91,1,255,1,254,1,3,132,0,0,1,2,131,0,0,1,28,134,0,0,1,1,1,84,131,0,0,1,68,1,0,1,2,131,0,0,1,10,133,0,0,1,76,131,0,0,1,92,131,0,0,1,252,1,0,1,2,1,0,1,10,1,0,1,4,132,0,0,1,1,1,4,1,0,1,0,1,1,1,20,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,10,229,0,0,193,0,0,1,95,1,118,1,115,1,105,1,95,1,99,1,0,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,4,198,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,252,1,0,1,1,1,0,1,4,138,0,0,1,8,1,33,131,0,0,1,1,131,0,0,1,5,131,0,0,1,1,1,0,1,0,1,2,1,144,1,0,1,16,1,0,1,3,1,0,1,12,1,0,1,4,1,0,1,13,1,0,1,5,1,0,1,14,1,0,1,6,1,0,1,63,1,0,1,7,1,0,1,0,1,48,1,80,1,0,1,0,1,16,1,19,1,241,1,85,1,80,1,3,1,0,1,0,1,18,1,1,1,194,133,0,0,1,96,1,8,1,32,1,14,1,18,1,0,1,18,135,0,0,1,64,1,16,1,196,1,0,1,34,131,0,0,1,5,1,248,1,32,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,16,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,48,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,64,131,0,0,1,6,1,136,132,0,0,1,5,1,248,132,0,0,1,6,1,136,132,0,0,1,200,1,15,131,0,0,1,27,1,0,1,0,1,225,1,2,1,0,1,0,1,200,1,15,131,0,0,1,198,1,0,1,0,1,235,1,2,1,4,1,0,1,200,1,15,131,0,0,1,177,1,148,1,148,1,235,1,2,1,3,1,0,1,200,1,15,131,0,0,1,108,1,248,1,148,1,235,1,2,1,1,1,0,1,200,1,1,1,128,1,62,1,0,1,233,1,167,1,0,1,175,1,0,1,10,1,0,1,200,1,2,1,128,1,62,1,0,1,233,1,167,1,0,1,175,1,0,1,11,1,0,1,200,1,4,1,128,1,62,1,0,1,233,1,167,1,0,1,175,1,0,1,12,1,0,1,200,1,8,1,128,1,62,1,0,1,233,1,167,1,0,1,175,1,0,1,13,1,0,1,200,1,7,1,0,1,0,1,2,1,20,1,192,1,0,1,160,1,0,1,8,1,0,1,100,1,18,131,0,0,1,190,1,190,1,188,1,144,1,0,1,7,1,9,1,76,1,18,1,0,1,0,1,2,1,177,1,108,1,108,1,160,1,0,1,9,1,0,1,200,1,3,1,128,1,0,1,0,1,177,1,108,1,0,1,225,150,0,0,1,1,132,255,0,131,0,0,1,1,135,0,0,1,172,1,16,1,42,1,17,132,0,0,1,124,131,0,0,1,48,135,0,0,1,36,135,0,0,1,88,139,0,0,1,48,131,0,0,1,28,131,0,0,1,35,1,255,1,255,1,3,144,0,0,1,28,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,48,1,16,134,0,0,1,4,134,0,0,1,4,1,33,1,0,1,1,1,0,1,1,131,0,0,1,1,1,0,1,0,1,16,1,80,132,0,0,1,32,1,1,1,196,1,0,1,34,131,0,0,1,8,1,32,133,0,0,1,108,1,226,131,0,0,1,200,1,139,1,192,1,0,1,0,1,176,1,176,1,0,1,226,150,0,0,1,1,132,255,0,138,0,0,1,17,1,120,1,16,1,42,1,17,1,1,1,0,1,0,1,15,1,52,1,0,1,0,1,2,1,68,135,0,0,1,36,1,0,1,0,1,14,1,208,1,0,1,0,1,14,1,248,138,0,0,1,14,1,168,131,0,0,1,28,1,0,1,0,1,14,1,155,1,255,1,254,1,3,132,0,0,1,2,131,0,0,1,28,134,0,0,1,14,1,148,131,0,0,1,68,1,0,1,2,131,0,0,1,10,133,0,0,1,76,131,0,0,1,92,131,0,0,1,252,1,0,1,2,1,0,1,10,1,0,1,216,132,0,0,1,1,1,4,1,0,1,0,1,1,1,20,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,10,229,0,0,193,0,0,1,95,1,118,1,115,1,98,1,95,1,99,1,0,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,216,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,156,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,2,1,4,1,0,1,1,1,0,1,6,138,0,0,1,8,1,33,131,0,0,1,1,131,0,0,1,3,131,0,0,1,1,1,0,1,0,1,2,1,144,1,0,1,16,1,0,1,5,1,0,1,0,1,16,1,6,1,0,1,48,1,32,1,7,1,0,1,0,1,48,1,80,1,0,1,0,1,16,1,41,180,0,0,1,63,1,128,1,0,1,0,1,64,1,64,134,0,0,1,112,1,21,1,48,1,5,1,0,1,0,1,18,1,0,1,194,133,0,0,1,96,1,8,1,96,1,14,1,18,1,0,1,18,133,0,0,1,96,1,20,1,96,1,26,1,18,1,0,1,18,133,0,0,1,16,1,32,1,0,1,0,1,18,1,0,1,196,133,0,0,1,96,1,33,1,48,1,39,1,18,1,0,1,34,131,0,0,1,5,1,248,1,16,131,0,0,1,4,1,200,132,0,0,1,5,1,248,1,64,131,0,0,1,2,1,208,132,0,0,1,5,1,248,132,0,0,1,6,1,136,132,0,0,1,200,1,15,1,0,1,6,1,0,1,0,1,198,1,0,1,161,1,0,1,255,1,0,1,92,1,8,1,0,1,3,1,0,1,198,1,27,1,27,1,161,1,1,1,3,1,6,1,200,1,15,1,0,1,2,1,160,1,198,1,136,1,0,1,161,1,4,1,10,1,0,1,200,1,15,1,0,1,5,1,160,1,198,1,136,1,0,1,161,1,4,1,11,1,0,1,92,1,15,1,0,1,0,1,160,1,198,1,136,1,198,1,161,1,4,1,12,1,6,1,200,1,15,1,0,1,0,1,160,1,177,1,136,1,0,1,171,1,4,1,12,1,0,1,200,1,15,1,0,1,5,1,160,1,177,1,136,1,0,1,171,1,4,1,11,1,5,1,200,1,15,1,0,1,2,1,160,1,177,1,136,1,0,1,171,1,4,1,10,1,2,1,92,1,2,1,0,1,4,1,0,1,198,1,27,1,177,1,161,1,1,1,1,1,6,1,200,1,15,1,0,1,2,1,160,1,27,1,52,1,148,1,171,1,4,1,10,1,2,1,200,1,15,1,0,1,5,1,160,1,27,1,52,1,148,1,171,1,4,1,11,1,5,1,200,1,15,1,0,1,0,1,160,1,27,1,52,1,148,1,171,1,4,1,12,1,0,1,92,1,8,1,0,1,4,1,0,1,198,1,27,1,108,1,161,1,1,1,0,1,6,1,200,1,15,1,0,1,0,1,160,1,108,1,208,1,148,1,171,1,4,1,12,1,0,1,200,1,15,1,0,1,5,1,160,1,108,1,208,1,148,1,171,1,4,1,11,1,5,1,200,1,15,1,0,1,2,1,160,1,108,1,208,1,148,1,171,1,4,1,10,1,2,1,200,1,1,1,0,1,2,1,0,1,170,1,170,1,0,1,239,1,2,1,1,1,0,1,200,1,4,1,0,1,2,1,0,1,170,1,170,1,0,1,239,1,0,1,1,1,0,1,172,1,34,1,0,1,2,1,0,1,170,1,170,1,2,1,207,1,5,1,1,1,4,1,200,1,1,1,0,1,3,1,0,1,190,1,190,1,0,1,176,1,2,1,2,1,0,1,200,1,4,1,0,1,3,1,0,1,190,1,190,1,0,1,176,1,2,1,3,1,0,1,20,1,17,1,0,1,4,1,0,1,190,1,190,1,198,1,176,1,2,1,1,1,1,1,168,1,36,1,3,1,4,1,0,1,190,1,190,1,0,1,144,1,2,1,0,1,2,1,200,1,3,1,128,1,62,1,0,1,110,1,179,1,0,1,224,1,4,1,4,1,0,1,200,1,12,1,128,1,62,1,0,1,236,1,49,1,0,1,224,1,3,1,3,1,0,1,200,1,1,1,0,1,1,1,0,1,190,1,190,1,0,1,176,1,2,1,4,1,0,1,20,1,18,1,0,1,1,1,0,1,190,1,190,1,198,1,176,1,2,1,6,1,1,1,200,1,15,1,0,1,2,1,0,1,176,1,198,1,166,1,108,1,255,1,1,1,2,1,168,1,132,131,0,0,1,85,1,62,1,0,1,143,1,2,1,5,1,6,1,200,1,10,131,0,0,1,188,1,17,1,0,1,224,1,1,1,0,1,0,1,200,1,7,1,0,1,0,1,2,1,21,1,192,1,0,1,160,1,0,1,8,1,0,1,100,1,18,131,0,0,1,190,1,190,1,188,1,144,1,0,1,7,1,9,1,76,1,18,1,0,1,0,1,2,1,177,1,108,1,108,1,160,1,0,1,9,1,0,1,200,1,3,1,128,1,0,1,0,1,177,1,108,1,0,1,225,151,0,0,132,255,0,131,0,0,1,1,135,0,0,1,172,1,16,1,42,1,17,132,0,0,1,124,131,0,0,1,48,135,0,0,1,36,135,0,0,1,88,139,0,0,1,48,131,0,0,1,28,131,0,0,1,35,1,255,1,255,1,3,144,0,0,1,28,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,48,1,16,134,0,0,1,4,134,0,0,1,4,1,33,1,0,1,1,1,0,1,1,131,0,0,1,1,1,0,1,0,1,16,1,80,132,0,0,1,32,1,1,1,196,1,0,1,34,131,0,0,1,8,1,32,133,0,0,1,108,1,226,131,0,0,1,200,1,139,1,192,1,0,1,0,1,176,1,176,1,0,1,226,151,0,0,132,255,0,138,0,0,1,2,1,24,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,88,131,0,0,1,192,135,0,0,1,36,134,0,0,1,1,1,36,139,0,0,1,252,131,0,0,1,28,131,0,0,1,239,1,255,1,254,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,232,131,0,0,1,48,1,0,1,2,131,0,0,1,10,133,0,0,1,56,131,0,0,1,72,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,10,229,0,0,193,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,192,1,0,1,1,1,0,1,1,138,0,0,1,8,1,33,131,0,0,1,1,131,0,0,1,1,131,0,0,1,1,1,0,1,0,1,2,1,144,131,0,0,1,3,1,0,1,0,1,48,1,80,1,0,1,0,1,16,1,14,1,16,1,1,1,16,1,3,1,0,1,0,1,18,1,0,1,194,133,0,0,1,64,1,4,1,0,1,0,1,18,1,0,1,196,133,0,0,1,96,1,8,1,16,1,14,1,18,1,0,1,34,131,0,0,1,5,1,248,1,16,131,0,0,1,6,1,136,132,0,0,1,200,1,1,1,128,1,62,1,0,1,167,1,167,1,0,1,175,1,1,1,0,1,0,1,200,1,2,1,128,1,62,1,0,1,167,1,167,1,0,1,175,1,1,1,1,1,0,1,200,1,4,1,128,1,62,1,0,1,167,1,167,1,0,1,175,1,1,1,2,1,0,1,200,1,8,1,128,1,62,1,0,1,167,1,167,1,0,1,175,1,1,1,3,1,0,1,200,1,1,131,0,0,1,167,1,167,1,0,1,175,1,1,1,4,1,0,1,200,1,2,131,0,0,1,167,1,167,1,0,1,175,1,1,1,5,1,0,1,200,1,4,131,0,0,1,167,1,167,1,0,1,175,1,1,1,6,1,0,1,200,1,7,1,0,1,0,1,2,1,192,1,192,1,0,1,160,1,0,1,8,1,0,1,100,1,18,131,0,0,1,190,1,190,1,188,1,144,1,0,1,7,1,9,1,76,1,18,1,0,1,0,1,2,1,177,1,108,1,108,1,160,1,0,1,9,1,0,1,200,1,3,1,128,1,0,1,0,1,177,1,108,1,0,1,225,142,0,0,1,0};
			}
		}
#else
		/// <summary>Static Length+DeflateStream compressed shader byte code (Windows)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {148,41,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,210,95,99,248,249,53,127,236,255,254,191,254,162,223,84,126,255,181,241,55,253,255,31,210,239,18,250,255,175,163,159,253,191,253,249,245,232,255,191,255,101,243,251,79,9,101,51,142,249,111,34,223,253,91,191,198,255,119,198,241,163,231,71,207,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,255,127,121,126,253,95,131,227,180,9,2,53,19,167,253,75,26,167,253,58,250,255,111,34,78,211,126,10,244,3,120,191,217,175,33,176,253,231,215,162,255,35,244,237,126,110,250,7,126,191,89,228,123,252,29,123,239,199,232,255,79,202,124,57,43,150,23,0,254,235,14,188,143,88,53,246,254,111,72,255,63,91,54,109,182,156,2,2,143,225,245,60,155,229,181,163,21,250,192,231,120,55,245,222,253,231,232,255,255,149,247,119,75,52,253,147,148,174,120,254,52,47,198,255,141,244,119,140,255,79,209,239,255,35,106,251,239,209,255,255,84,253,251,127,163,223,127,57,253,255,105,164,237,111,71,159,253,86,191,169,107,187,67,191,143,232,255,127,88,164,237,239,77,159,189,241,218,174,232,247,82,219,253,122,242,131,219,255,223,244,24,186,255,77,248,231,215,254,191,255,239,255,235,255,254,109,126,141,147,55,199,79,126,39,250,243,199,245,51,109,130,39,197,231,171,230,247,191,247,251,239,252,26,95,20,211,186,106,170,243,54,221,122,117,39,253,246,243,215,207,83,161,92,122,82,45,86,69,73,191,60,28,239,125,58,126,120,127,111,188,119,176,191,255,107,252,4,79,207,111,250,23,9,168,63,232,247,48,64,127,23,66,135,190,248,131,136,218,127,210,175,11,114,253,6,191,22,253,254,107,252,73,248,255,175,9,84,127,131,95,243,15,114,191,255,70,244,251,211,191,200,96,101,198,97,96,253,103,248,224,215,254,191,104,28,51,59,142,239,253,154,242,25,190,250,157,164,89,250,134,62,123,170,239,39,191,198,47,248,53,158,211,207,223,151,254,255,127,240,103,137,200,5,181,249,173,126,77,147,227,248,107,255,218,95,147,80,251,53,233,27,228,104,254,191,240,168,44,90,188,187,188,255,117,159,203,175,57,255,191,11,147,27,243,247,155,254,73,242,251,111,252,7,253,154,246,247,223,228,15,250,181,236,239,191,233,31,244,107,219,223,127,141,63,232,215,241,126,167,239,254,35,195,47,52,174,255,232,215,212,246,191,206,175,241,159,49,239,16,60,106,243,21,125,247,159,253,73,191,14,79,33,254,198,123,255,25,241,207,127,246,7,185,207,254,26,234,207,125,246,107,240,103,255,55,245,43,159,253,24,139,237,175,249,31,209,123,127,80,242,107,252,103,127,145,252,253,107,241,223,191,161,253,251,215,225,191,127,35,251,247,111,192,127,255,198,244,247,175,197,127,255,250,232,247,15,250,13,126,141,255,236,47,254,13,4,222,31,244,235,211,119,248,236,215,210,191,129,27,189,251,23,203,223,191,22,255,254,99,191,198,87,127,209,175,199,227,130,28,124,245,7,201,184,126,237,255,72,198,241,213,31,100,184,29,108,237,203,240,223,135,127,126,173,136,12,255,90,81,25,222,251,58,115,24,202,176,121,254,160,223,195,205,207,175,249,55,253,186,58,150,95,67,212,202,223,36,115,196,99,213,223,193,3,255,217,95,36,242,12,186,255,103,189,49,25,200,47,127,115,250,231,215,130,60,255,109,191,182,25,211,159,251,155,200,103,190,60,255,105,191,137,47,207,191,86,79,158,255,173,95,227,255,23,242,60,241,229,249,223,186,241,141,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,63,140,231,71,125,252,232,249,209,243,243,231,185,252,128,88,250,63,225,88,250,247,252,61,125,120,94,174,131,243,30,191,38,231,58,228,119,250,130,243,36,18,99,255,166,156,195,248,79,126,141,95,227,47,26,75,30,228,111,66,44,253,235,106,62,227,215,252,53,190,250,147,146,20,249,134,175,254,166,95,71,226,246,63,72,254,230,56,252,79,66,219,240,243,191,134,62,255,107,34,159,255,223,244,249,255,205,159,107,94,228,15,66,62,197,244,245,107,106,95,191,161,215,23,62,251,13,189,190,52,207,226,125,46,125,245,63,151,190,92,14,230,215,226,190,126,205,78,95,191,81,167,175,223,104,160,175,223,104,160,175,223,40,218,215,175,99,251,146,60,197,111,64,127,255,223,127,146,142,249,31,194,120,145,183,80,188,248,239,95,211,229,130,248,239,95,203,229,130,248,239,95,91,255,254,53,133,102,200,83,233,223,60,46,26,147,249,155,251,254,131,126,61,47,119,4,60,190,137,220,209,175,17,201,29,225,249,255,91,238,8,143,159,59,250,13,0,149,115,71,103,118,76,255,227,175,33,159,97,220,38,119,244,95,209,63,59,191,134,32,129,220,209,1,253,252,246,175,241,255,221,60,209,215,213,71,190,222,241,120,254,79,234,240,252,159,212,225,249,63,169,195,243,127,146,225,121,163,39,12,207,27,89,54,60,111,228,205,231,249,95,227,103,137,231,255,159,0,0,0,255,255};
			}
		}
#endif
	}
	/// <summary><para>Technique 'DepthOutRgTextureAlphaClip' generated from file 'Depth.fx'</para><para>Vertex Shader: approximately 14 instruction slots used, 10 registers</para><para>Pixel Shader: approximately 8 instruction slots used (1 texture, 7 arithmetic), 1 register</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	public sealed class DepthOutRgTextureAlphaClip : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'DepthOutRgTextureAlphaClip' shader</summary>
		public DepthOutRgTextureAlphaClip()
		{
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
			this.sc3 = -1;
			this.sc4 = -1;
			this.sc5 = -1;
			this.sc6 = -1;
			this.pts[0] = ((Xen.Graphics.TextureSamplerState)(192));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			DepthOutRgTextureAlphaClip.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			DepthOutRgTextureAlphaClip.cid0 = state.GetNameUniqueID("clipThreshold");
			DepthOutRgTextureAlphaClip.sid0 = state.GetNameUniqueID("AlphaTextureSampler");
			DepthOutRgTextureAlphaClip.tid0 = state.GetNameUniqueID("AlphaTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != DepthOutRgTextureAlphaClip.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			this.preg_change = (this.preg_change | ic);
			this.vbreg_change = (this.vbreg_change | ic);
			this.vireg_change = (this.vireg_change | ic);
			// Set the value for attribute 'cameraNearFar'
			this.vreg_change = (this.vreg_change | state.SetCameraNearFarVector2(ref this.vreg[9], ref this.sc0));
			// Set the value for attribute 'viewDirection'
			this.vreg_change = (this.vreg_change | state.SetViewDirectionVector3(ref this.vreg[7], ref this.sc1));
			// Set the value for attribute 'viewPoint'
			this.vreg_change = (this.vreg_change | state.SetViewPointVector3(ref this.vreg[8], ref this.sc2));
			Microsoft.Xna.Framework.Vector4 unused = new Microsoft.Xna.Framework.Vector4();
			// Set the value for attribute 'worldMatrix'
			this.vreg_change = (this.vreg_change | state.SetWorldMatrix(ref this.vreg[4], ref this.vreg[5], ref this.vreg[6], ref unused, ref this.sc3));
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc4));
			// Assign pixel shader textures and samplers
			if ((ic | this.ptc))
			{
				state.SetPixelShaderSamplers(this.ptx, this.pts);
				this.ptc = false;
			}
			if ((this.vreg_change == true))
			{
				DepthOutRgTextureAlphaClip.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			if ((this.preg_change == true))
			{
				DepthOutRgTextureAlphaClip.fx.ps_c.SetValue(this.preg);
				this.preg_change = false;
				ic = true;
			}
			if ((ext == Xen.Graphics.ShaderSystem.ShaderExtension.Blending))
			{
				ic = (ic | state.SetBlendMatricesDirect(DepthOutRgTextureAlphaClip.fx.vsb_c, ref this.sc5));
			}
			if ((ext == Xen.Graphics.ShaderSystem.ShaderExtension.Instancing))
			{
				this.vireg_change = (this.vireg_change | state.SetViewProjectionMatrix(ref this.vireg[0], ref this.vireg[1], ref this.vireg[2], ref this.vireg[3], ref this.sc6));
				if ((this.vireg_change == true))
				{
					DepthOutRgTextureAlphaClip.fx.vsi_c.SetValue(this.vireg);
					this.vireg_change = false;
					ic = true;
				}
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref DepthOutRgTextureAlphaClip.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((DepthOutRgTextureAlphaClip.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((DepthOutRgTextureAlphaClip.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			DepthOutRgTextureAlphaClip.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out DepthOutRgTextureAlphaClip.fx, DepthOutRgTextureAlphaClip.fxb, 16, 12);
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
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(DepthOutRgTextureAlphaClip.vin[i]));
			index = DepthOutRgTextureAlphaClip.vin[(i + 2)];
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
		/// <summary>Name ID for 'clipThreshold'</summary>
		private static int cid0;
		/// <summary>Assign the shader value 'float clipThreshold'</summary>
		public float ClipThreshold
		{
			set
			{
				this.preg[0] = new Microsoft.Xna.Framework.Vector4(value, 0F, 0F, 0F);
				this.preg_change = true;
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'cameraNearFar'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute 'viewDirection'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute 'viewPoint'</summary>
		private int sc2;
		/// <summary>Change ID for Semantic bound attribute 'worldMatrix'</summary>
		private int sc3;
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc4;
		/// <summary>Change ID for Semantic bound attribute '__BLENDMATRICES__GENMATRIX'</summary>
		private int sc5;
		/// <summary>Change ID for Semantic bound attribute 'viewProj'</summary>
		private int sc6;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D AlphaTextureSampler'</summary>
		public Xen.Graphics.TextureSamplerState AlphaTextureSampler
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
		/// <summary>Get/Set the Bound texture for 'Texture2D AlphaTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D AlphaTexture
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
		/// <summary>Name uid for sampler for 'Sampler2D AlphaTextureSampler'</summary>
		static int sid0;
		/// <summary>Name uid for texture for 'Texture2D AlphaTexture'</summary>
		static int tid0;
		/// <summary>Pixel samplers/textures changed</summary>
		bool ptc;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,2,0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[10];
		/// <summary>Pixel shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] preg = new Microsoft.Xna.Framework.Vector4[1];
		/// <summary>Instancing shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vireg = new Microsoft.Xna.Framework.Vector4[4];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[1];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[1];
#if XBOX360
		/// <summary>Static RLE compressed shader byte code (Xbox360)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {4,188,240,11,207,131,0,1,32,152,0,8,254,255,9,1,0,0,15,248,135,0,1,3,131,0,1,1,131,0,1,192,135,0,1,10,131,0,1,4,131,0,1,1,229,0,0,190,0,0,1,6,1,95,1,118,1,115,1,95,1,99,134,0,0,1,3,131,0,0,1,1,131,0,0,1,248,135,0,0,1,1,131,0,0,1,4,131,0,0,1,1,147,0,0,1,6,1,95,1,112,1,115,1,95,1,99,134,0,0,1,3,131,0,0,1,1,1,0,1,0,1,14,1,160,135,0,0,1,216,131,0,0,1,4,131,0,0,1,1,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,153,0,0,1,7,1,95,1,118,1,115,1,98,1,95,1,99,133,0,0,1,3,131,0,0,1,1,1,0,1,0,1,15,1,8,135,0,0,1,4,131,0,0,1,4,131,0,0,1,1,195,0,0,1,7,1,95,1,118,1,115,1,105,1,95,1,99,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,15,1,44,143,0,0,1,7,1,95,1,112,1,115,1,95,1,115,1,48,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,3,131,0,0,1,16,131,0,0,1,4,143,0,0,1,4,131,0,0,1,15,131,0,0,1,4,143,0,0,1,9,1,66,1,108,1,101,1,110,1,100,1,105,1,110,1,103,135,0,0,1,5,131,0,0,1,16,131,0,0,1,4,143,0,0,1,6,131,0,0,1,15,131,0,0,1,4,143,0,0,1,11,1,73,1,110,1,115,1,116,1,97,1,110,1,99,1,105,1,110,1,103,133,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,5,131,0,0,1,1,131,0,0,1,10,131,0,0,1,7,131,0,0,1,4,131,0,0,1,32,139,0,0,1,204,131,0,0,1,232,138,0,0,1,1,1,4,1,0,1,0,1,1,1,32,138,0,0,1,14,1,172,1,0,1,0,1,14,1,200,138,0,0,1,15,1,20,1,0,1,0,1,15,1,40,138,0,0,1,15,1,236,135,0,0,1,3,1,0,1,0,1,15,1,104,135,0,0,1,2,131,0,0,1,92,134,0,0,1,15,1,60,1,0,1,0,1,15,1,56,131,0,0,1,93,134,0,0,1,15,1,84,1,0,1,0,1,15,1,80,1,0,1,0,1,15,1,156,135,0,0,1,2,131,0,0,1,92,134,0,0,1,15,1,112,1,0,1,0,1,15,1,108,131,0,0,1,93,134,0,0,1,15,1,136,1,0,1,0,1,15,1,132,1,0,1,0,1,15,1,220,135,0,0,1,2,131,0,0,1,92,134,0,0,1,15,1,176,1,0,1,0,1,15,1,172,131,0,0,1,93,134,0,0,1,15,1,200,1,0,1,0,1,15,1,196,135,0,0,1,6,135,0,0,1,2,132,255,0,131,0,0,1,1,134,0,0,1,1,1,164,1,16,1,42,1,17,131,0,0,1,1,1,16,131,0,0,1,148,135,0,0,1,36,131,0,0,1,192,131,0,0,1,232,139,0,0,1,152,131,0,0,1,28,131,0,0,1,139,1,255,1,255,1,3,132,0,0,1,2,131,0,0,1,28,135,0,0,1,132,131,0,0,1,68,1,0,1,2,131,0,0,1,1,133,0,0,1,76,131,0,0,1,92,131,0,0,1,108,1,0,1,3,131,0,0,1,1,133,0,0,1,116,132,0,0,1,95,1,112,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,1,150,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,1,139,0,0,1,20,1,1,1,252,1,0,1,16,147,0,0,1,64,131,0,0,1,84,1,16,1,0,1,1,132,0,0,1,4,134,0,0,1,12,1,66,1,0,1,3,1,0,1,3,131,0,0,1,33,1,0,1,0,1,16,1,80,1,0,1,0,1,49,1,81,193,0,0,1,1,1,16,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,48,1,3,1,0,1,0,1,34,133,0,0,1,16,1,8,1,0,1,33,1,31,1,31,1,255,1,223,1,0,1,0,1,64,1,0,1,184,1,32,1,0,1,0,1,1,1,0,1,0,1,65,1,194,131,0,0,1,8,1,32,131,0,0,1,108,1,177,1,108,1,121,1,255,1,0,1,0,1,200,1,139,1,192,1,0,1,0,1,176,1,176,1,0,1,226,150,0,0,1,2,132,255,0,138,0,0,1,2,1,244,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,224,1,0,1,0,1,1,1,20,135,0,0,1,36,134,0,0,1,1,1,144,138,0,0,1,1,1,104,131,0,0,1,28,1,0,1,0,1,1,1,91,1,255,1,254,1,3,132,0,0,1,2,131,0,0,1,28,134,0,0,1,1,1,84,131,0,0,1,68,1,0,1,2,131,0,0,1,10,133,0,0,1,76,131,0,0,1,92,131,0,0,1,252,1,0,1,2,1,0,1,10,1,0,1,4,132,0,0,1,1,1,4,1,0,1,0,1,1,1,20,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,10,229,0,0,193,0,0,1,95,1,118,1,115,1,105,1,95,1,99,1,0,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,4,198,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,134,0,0,1,1,1,20,1,0,1,17,1,0,1,5,138,0,0,1,16,1,66,131,0,0,1,1,131,0,0,1,6,131,0,0,1,2,1,0,1,0,1,2,1,144,1,0,1,16,1,0,1,3,1,0,1,0,1,80,1,4,1,0,1,12,1,0,1,5,1,0,1,13,1,0,1,6,1,0,1,14,1,0,1,7,1,0,1,63,1,0,1,8,1,0,1,0,1,48,1,80,1,0,1,1,1,49,1,81,1,0,1,0,1,16,1,21,1,0,1,0,1,16,1,18,1,245,1,85,1,96,1,3,1,0,1,0,1,18,1,3,1,194,133,0,0,1,96,1,9,1,32,1,15,1,18,1,0,1,18,135,0,0,1,80,1,17,1,196,1,0,1,34,131,0,0,1,5,1,248,1,48,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,16,131,0,0,1,15,1,200,132,0,0,1,5,1,248,1,32,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,64,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,80,131,0,0,1,6,1,136,132,0,0,1,5,1,248,132,0,0,1,6,1,136,132,0,0,1,200,1,15,131,0,0,1,27,1,0,1,0,1,225,1,3,1,0,1,0,1,200,1,15,131,0,0,1,198,1,0,1,0,1,235,1,3,1,5,1,0,1,200,1,15,131,0,0,1,177,1,148,1,148,1,235,1,3,1,4,1,0,1,200,1,15,131,0,0,1,108,1,248,1,148,1,235,1,3,1,2,1,0,1,200,1,1,1,128,1,62,1,0,1,233,1,167,1,0,1,175,1,0,1,10,1,0,1,200,1,2,1,128,1,62,1,0,1,233,1,167,1,0,1,175,1,0,1,11,1,0,1,200,1,4,1,128,1,62,1,0,1,233,1,167,1,0,1,175,1,0,1,12,1,0,1,200,1,8,1,128,1,62,1,0,1,233,1,167,1,0,1,175,1,0,1,13,1,0,1,200,1,7,1,0,1,0,1,2,1,20,1,192,1,0,1,160,1,0,1,8,1,0,1,200,1,3,1,128,1,1,1,0,1,176,1,176,1,0,1,226,1,1,1,1,1,0,1,100,1,18,131,0,0,1,190,1,190,1,188,1,144,1,0,1,7,1,9,1,76,1,18,1,0,1,0,1,2,1,177,1,108,1,108,1,160,1,0,1,9,1,0,1,200,1,3,1,128,1,0,1,0,1,177,1,108,1,0,1,225,150,0,0,1,1,132,255,0,131,0,0,1,1,134,0,0,1,1,1,164,1,16,1,42,1,17,131,0,0,1,1,1,16,131,0,0,1,148,135,0,0,1,36,131,0,0,1,192,131,0,0,1,232,139,0,0,1,152,131,0,0,1,28,131,0,0,1,139,1,255,1,255,1,3,132,0,0,1,2,131,0,0,1,28,135,0,0,1,132,131,0,0,1,68,1,0,1,2,131,0,0,1,1,133,0,0,1,76,131,0,0,1,92,131,0,0,1,108,1,0,1,3,131,0,0,1,1,133,0,0,1,116,132,0,0,1,95,1,112,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,1,150,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,1,139,0,0,1,20,1,1,1,252,1,0,1,16,147,0,0,1,64,131,0,0,1,84,1,16,1,0,1,1,132,0,0,1,4,134,0,0,1,12,1,66,1,0,1,3,1,0,1,3,131,0,0,1,33,1,0,1,0,1,16,1,80,1,0,1,0,1,49,1,81,193,0,0,1,1,1,16,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,48,1,3,1,0,1,0,1,34,133,0,0,1,16,1,8,1,0,1,33,1,31,1,31,1,255,1,223,1,0,1,0,1,64,1,0,1,184,1,32,1,0,1,0,1,1,1,0,1,0,1,65,1,194,131,0,0,1,8,1,32,131,0,0,1,108,1,177,1,108,1,121,1,255,1,0,1,0,1,200,1,139,1,192,1,0,1,0,1,176,1,176,1,0,1,226,150,0,0,1,1,132,255,0,138,0,0,1,17,1,168,1,16,1,42,1,17,1,1,1,0,1,0,1,15,1,64,1,0,1,0,1,2,1,104,135,0,0,1,36,1,0,1,0,1,14,1,208,1,0,1,0,1,14,1,248,138,0,0,1,14,1,168,131,0,0,1,28,1,0,1,0,1,14,1,155,1,255,1,254,1,3,132,0,0,1,2,131,0,0,1,28,134,0,0,1,14,1,148,131,0,0,1,68,1,0,1,2,131,0,0,1,10,133,0,0,1,76,131,0,0,1,92,131,0,0,1,252,1,0,1,2,1,0,1,10,1,0,1,216,132,0,0,1,1,1,4,1,0,1,0,1,1,1,20,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,10,229,0,0,193,0,0,1,95,1,118,1,115,1,98,1,95,1,99,1,0,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,216,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,156,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,2,1,40,1,0,1,17,1,0,1,7,138,0,0,1,16,1,66,131,0,0,1,1,131,0,0,1,4,131,0,0,1,2,1,0,1,0,1,2,1,144,1,0,1,16,1,0,1,5,1,0,1,0,1,80,1,6,1,0,1,0,1,16,1,7,1,0,1,48,1,32,1,8,1,0,1,0,1,48,1,80,1,0,1,1,1,49,1,81,1,0,1,0,1,16,1,44,1,0,1,0,1,16,1,40,180,0,0,1,63,1,128,1,0,1,0,1,64,1,64,134,0,0,1,240,1,85,1,64,1,5,1,0,1,0,1,18,1,0,1,194,133,0,0,1,96,1,9,1,96,1,15,1,18,1,0,1,18,133,0,0,1,96,1,21,1,96,1,27,1,18,1,0,1,18,133,0,0,1,16,1,33,1,0,1,0,1,18,1,0,1,196,133,0,0,1,96,1,34,1,80,1,40,1,18,1,0,1,34,131,0,0,1,5,1,248,1,32,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,16,131,0,0,1,15,1,200,132,0,0,1,5,1,248,1,80,131,0,0,1,2,1,208,132,0,0,1,5,1,248,132,0,0,1,6,1,136,132,0,0,1,200,1,15,1,0,1,7,1,0,1,0,1,198,1,0,1,161,1,0,1,255,1,0,1,92,1,8,1,0,1,4,1,0,131,27,0,1,161,1,2,1,3,1,7,1,200,1,15,1,0,1,3,1,160,1,198,1,136,1,0,1,161,1,5,1,10,1,0,1,200,1,15,1,0,1,6,1,160,1,198,1,136,1,0,1,161,1,5,1,11,1,0,1,92,1,15,1,0,1,0,1,160,1,198,1,136,1,198,1,161,1,5,1,12,1,7,1,200,1,15,1,0,1,0,1,160,1,177,1,136,1,0,1,171,1,5,1,12,1,0,1,200,1,15,1,0,1,6,1,160,1,177,1,136,1,0,1,171,1,5,1,11,1,6,1,200,1,15,1,0,1,3,1,160,1,177,1,136,1,0,1,171,1,5,1,10,1,3,1,92,1,2,1,0,1,5,1,0,1,27,1,27,1,177,1,161,1,2,1,1,1,7,1,200,1,15,1,0,1,3,1,160,1,27,1,52,1,148,1,171,1,5,1,10,1,3,1,200,1,15,1,0,1,6,1,160,1,27,1,52,1,148,1,171,1,5,1,11,1,6,1,200,1,15,1,0,1,0,1,160,1,27,1,52,1,148,1,171,1,5,1,12,1,0,1,92,1,8,1,0,1,5,1,0,1,27,1,27,1,108,1,161,1,2,1,0,1,7,1,200,1,15,1,0,1,0,1,160,1,108,1,208,1,148,1,171,1,5,1,12,1,0,1,200,1,15,1,0,1,6,1,160,1,108,1,208,1,148,1,171,1,5,1,11,1,6,1,200,1,15,1,0,1,3,1,160,1,108,1,208,1,148,1,171,1,5,1,10,1,3,1,200,1,1,1,0,1,3,1,0,1,170,1,167,1,0,1,239,1,3,1,2,1,0,1,200,1,2,1,0,1,3,1,0,1,170,1,167,1,0,1,239,1,6,1,2,1,0,1,200,1,4,1,0,1,3,1,0,1,170,1,167,1,0,1,239,1,0,1,2,1,0,1,200,1,1,1,0,1,4,1,0,1,190,1,190,1,0,1,176,1,3,1,2,1,0,1,200,1,4,1,0,1,4,1,0,1,190,1,190,1,0,1,176,1,3,1,3,1,0,1,20,1,17,1,0,1,5,1,0,1,190,1,190,1,27,1,176,1,3,1,1,1,2,1,168,1,36,1,4,1,5,1,0,1,190,1,190,1,0,1,144,1,3,1,0,1,2,1,200,1,3,1,128,1,62,1,0,1,110,1,179,1,0,1,224,1,5,1,5,1,0,1,200,1,12,1,128,1,62,1,0,1,236,1,49,1,0,1,224,1,4,1,4,1,0,1,200,1,2,131,0,0,1,27,1,27,1,0,1,161,1,2,1,4,1,0,1,200,1,4,1,0,1,1,1,0,1,190,1,190,1,0,1,176,1,3,1,4,1,0,1,20,1,24,1,0,1,1,1,0,1,190,1,190,1,27,1,176,1,3,1,6,1,2,1,200,1,15,1,0,1,2,1,0,1,176,1,27,1,166,1,108,1,255,1,2,1,3,1,168,1,132,131,0,0,1,85,1,62,1,0,1,143,1,2,1,5,1,6,1,200,1,10,131,0,0,1,22,1,17,1,0,1,224,1,1,1,0,1,0,1,200,1,3,1,128,1,1,1,0,1,176,1,176,1,0,1,226,1,1,1,1,1,0,1,200,1,7,1,0,1,0,1,2,1,21,1,192,1,0,1,160,1,0,1,8,1,0,1,100,1,18,131,0,0,1,190,1,190,1,188,1,144,1,0,1,7,1,9,1,76,1,18,1,0,1,0,1,2,1,177,1,108,1,108,1,160,1,0,1,9,1,0,1,200,1,3,1,128,1,0,1,0,1,177,1,108,1,0,1,225,151,0,0,132,255,0,131,0,0,1,1,134,0,0,1,1,1,164,1,16,1,42,1,17,131,0,0,1,1,1,16,131,0,0,1,148,135,0,0,1,36,131,0,0,1,192,131,0,0,1,232,139,0,0,1,152,131,0,0,1,28,131,0,0,1,139,1,255,1,255,1,3,132,0,0,1,2,131,0,0,1,28,135,0,0,1,132,131,0,0,1,68,1,0,1,2,131,0,0,1,1,133,0,0,1,76,131,0,0,1,92,131,0,0,1,108,1,0,1,3,131,0,0,1,1,133,0,0,1,116,132,0,0,1,95,1,112,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,1,150,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,1,139,0,0,1,20,1,1,1,252,1,0,1,16,147,0,0,1,64,131,0,0,1,84,1,16,1,0,1,1,132,0,0,1,4,134,0,0,1,12,1,66,1,0,1,3,1,0,1,3,131,0,0,1,33,1,0,1,0,1,16,1,80,1,0,1,0,1,49,1,81,193,0,0,1,1,1,16,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,48,1,3,1,0,1,0,1,34,133,0,0,1,16,1,8,1,0,1,33,1,31,1,31,1,255,1,223,1,0,1,0,1,64,1,0,1,184,1,32,1,0,1,0,1,1,1,0,1,0,1,65,1,194,131,0,0,1,8,1,32,131,0,0,1,108,1,177,1,108,1,121,1,255,1,0,1,0,1,200,1,139,1,192,1,0,1,0,1,176,1,176,1,0,1,226,151,0,0,132,255,0,138,0,0,1,2,1,60,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,100,131,0,0,1,216,135,0,0,1,36,134,0,0,1,1,1,36,139,0,0,1,252,131,0,0,1,28,131,0,0,1,239,1,255,1,254,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,232,131,0,0,1,48,1,0,1,2,131,0,0,1,10,133,0,0,1,56,131,0,0,1,72,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,10,229,0,0,193,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,216,1,0,1,17,1,0,1,2,138,0,0,1,16,1,66,131,0,0,1,1,131,0,0,1,2,131,0,0,1,2,1,0,1,0,1,2,1,144,1,0,1,16,1,0,1,3,1,0,1,32,1,80,1,4,1,0,1,0,1,48,1,80,1,0,1,1,1,49,1,81,1,0,1,0,1,16,1,16,1,0,1,0,1,16,1,12,1,48,1,5,1,32,1,3,1,0,1,0,1,18,1,0,1,194,133,0,0,1,64,1,5,1,0,1,0,1,18,1,0,1,196,133,0,0,1,96,1,9,1,32,1,15,1,18,1,0,1,34,131,0,0,1,5,1,248,1,32,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,16,131,0,0,1,15,1,200,132,0,0,1,200,1,1,1,128,1,62,1,0,1,167,1,167,1,0,1,175,1,2,1,0,1,0,1,200,1,2,1,128,1,62,1,0,1,167,1,167,1,0,1,175,1,2,1,1,1,0,1,200,1,4,1,128,1,62,1,0,1,167,1,167,1,0,1,175,1,2,1,2,1,0,1,200,1,8,1,128,1,62,1,0,1,167,1,167,1,0,1,175,1,2,1,3,1,0,1,200,1,1,131,0,0,1,167,1,167,1,0,1,175,1,2,1,4,1,0,1,200,1,2,131,0,0,1,167,1,167,1,0,1,175,1,2,1,5,1,0,1,200,1,4,131,0,0,1,167,1,167,1,0,1,175,1,2,1,6,1,0,1,200,1,3,1,128,1,1,1,0,1,176,1,176,1,0,1,226,1,1,1,1,1,0,1,200,1,7,1,0,1,0,1,2,1,192,1,192,1,0,1,160,1,0,1,8,1,0,1,100,1,18,131,0,0,1,190,1,190,1,188,1,144,1,0,1,7,1,9,1,76,1,18,1,0,1,0,1,2,1,177,1,108,1,108,1,160,1,0,1,9,1,0,1,200,1,3,1,128,1,0,1,0,1,177,1,108,1,0,1,225,142,0,0,1,0};
			}
		}
#else
		/// <summary>Static Length+DeflateStream compressed shader byte code (Windows)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {92,44,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,210,95,99,248,249,53,127,236,255,254,191,254,143,223,84,126,255,181,241,55,253,255,31,210,239,18,250,255,175,163,159,253,191,253,249,245,232,255,191,255,101,243,251,79,9,101,51,142,255,77,191,195,239,67,227,224,247,86,252,158,29,255,95,244,155,200,119,255,214,134,247,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,207,206,243,235,255,26,28,223,77,16,168,153,56,237,55,208,184,245,215,209,255,127,19,113,154,246,83,160,159,223,232,215,16,184,35,237,39,104,67,49,99,179,35,125,254,102,218,206,127,126,45,250,63,94,235,126,46,56,254,223,255,55,198,240,155,69,190,199,223,177,247,126,140,254,255,164,204,151,179,98,121,129,191,127,221,95,35,254,62,226,217,216,251,191,33,253,255,108,217,180,217,114,202,16,48,134,215,243,108,150,215,2,11,120,33,222,199,231,120,55,245,222,253,231,232,255,255,149,247,247,175,67,141,83,143,216,127,29,197,203,255,148,198,204,120,126,43,66,96,203,163,217,255,228,229,23,230,250,59,232,243,167,232,247,143,233,179,3,250,255,159,170,127,191,161,223,95,210,255,255,162,72,219,150,62,91,121,109,255,56,250,253,143,162,255,255,71,145,182,127,27,125,246,55,121,109,255,57,250,253,159,210,118,191,158,252,224,246,255,55,61,102,56,191,55,126,249,181,255,239,255,251,255,250,191,119,126,141,147,55,199,79,126,39,250,243,143,253,53,228,51,180,253,157,184,213,175,145,254,97,244,207,83,125,255,215,164,127,159,211,207,223,151,254,95,254,26,134,63,127,173,95,163,85,152,146,95,248,107,255,218,95,147,190,249,53,137,186,67,124,170,60,245,215,254,58,196,121,191,38,255,39,15,125,124,239,247,223,249,53,190,40,166,117,213,84,231,109,186,245,234,78,250,237,231,175,159,167,50,131,233,73,181,88,21,37,253,242,112,188,247,233,248,225,253,189,241,222,193,254,254,175,241,19,52,181,191,230,175,241,155,254,69,2,229,15,250,61,76,63,191,11,161,77,115,254,7,17,150,127,146,252,254,107,254,65,132,27,255,78,95,255,73,36,88,127,209,19,30,198,111,74,159,255,103,244,247,127,246,23,253,90,250,55,81,139,254,255,107,252,197,199,204,50,191,233,31,244,235,226,243,223,224,215,250,131,248,61,250,255,175,9,24,191,193,175,249,7,185,223,127,35,130,241,244,47,250,191,255,111,233,219,208,219,224,242,27,128,88,191,246,255,69,244,158,89,122,127,239,215,148,207,124,122,191,249,53,29,189,147,95,227,23,88,122,255,31,252,89,34,58,128,218,252,86,191,166,201,3,57,122,131,175,255,191,240,168,222,177,120,119,101,248,235,62,151,95,147,127,132,31,126,163,63,136,230,89,121,227,55,166,185,52,191,255,38,127,208,175,101,127,255,77,255,160,95,219,254,254,107,252,65,191,142,254,14,30,251,117,189,207,169,221,127,228,241,155,254,254,107,16,156,95,251,63,250,53,21,206,175,67,252,6,158,250,53,153,215,190,98,254,251,117,120,106,241,55,96,252,103,196,87,255,217,31,228,62,251,107,232,125,247,153,225,209,95,91,63,251,49,230,219,95,243,63,162,247,254,160,228,215,248,207,254,34,249,251,215,226,191,127,67,251,247,175,195,127,255,70,246,239,223,128,255,254,141,127,13,195,247,191,62,250,253,131,126,131,95,227,63,251,139,127,3,129,247,7,253,250,244,29,62,251,181,244,111,224,70,239,254,197,242,247,175,197,191,255,216,175,241,213,95,244,235,241,184,32,31,95,177,172,96,172,50,14,140,237,215,248,181,64,135,95,151,112,53,18,1,214,247,245,209,12,191,252,90,17,125,244,107,253,156,234,163,189,175,195,79,161,62,50,207,31,244,123,56,254,248,53,255,38,243,59,225,102,126,239,234,163,191,233,70,125,196,244,254,53,254,38,252,95,248,138,231,71,127,135,62,250,207,254,34,209,77,120,255,63,251,131,186,180,55,152,205,127,115,250,231,215,130,110,250,219,126,109,67,251,63,247,55,145,207,124,218,255,105,191,137,175,155,28,237,141,110,250,183,126,141,255,95,232,166,137,175,155,254,173,27,223,248,209,243,163,231,71,207,143,158,31,61,63,122,126,244,252,92,61,63,234,247,71,207,143,158,31,61,63,122,254,255,249,92,126,64,44,254,159,112,44,254,123,254,158,62,60,47,87,99,115,56,38,231,243,107,114,174,70,126,167,70,156,243,249,117,53,14,71,190,229,63,161,148,237,88,242,56,127,19,226,234,95,87,243,49,191,214,175,241,213,159,148,164,200,151,124,245,55,253,58,156,110,254,77,255,32,249,251,215,248,155,126,45,206,27,114,238,198,251,252,175,161,207,255,154,200,231,255,55,125,254,127,243,231,154,215,249,131,144,15,50,125,253,154,218,215,111,232,245,133,207,126,67,175,47,205,19,121,159,75,95,253,207,165,47,151,67,250,181,184,175,95,179,211,215,111,212,233,235,55,26,232,235,55,26,232,235,55,138,246,245,235,216,190,36,103,241,27,208,223,255,247,159,164,99,254,135,48,222,95,195,229,178,248,239,95,211,254,253,235,240,223,191,150,203,101,241,223,191,182,254,253,107,10,205,144,103,211,191,121,92,52,38,243,55,247,253,7,253,122,94,238,11,120,124,19,185,175,95,35,146,251,250,53,189,220,23,158,31,229,190,126,110,114,95,120,252,220,87,138,222,57,247,117,102,105,255,63,254,26,242,25,104,97,104,255,95,209,63,59,191,134,32,139,220,215,1,253,252,246,175,241,255,221,60,215,215,213,167,67,122,211,147,217,63,169,35,179,127,82,71,102,255,164,142,204,254,73,70,102,141,158,51,50,107,116,145,145,89,163,47,124,153,253,53,126,8,50,251,255,4,0,0,255,255};
			}
		}
#endif
		/// <summary>Set a shader attribute of type 'Single' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, float value)
		{
			if ((DepthOutRgTextureAlphaClip.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DepthOutRgTextureAlphaClip.cid0))
			{
				this.ClipThreshold = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((DepthOutRgTextureAlphaClip.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DepthOutRgTextureAlphaClip.sid0))
			{
				this.AlphaTextureSampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((DepthOutRgTextureAlphaClip.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == DepthOutRgTextureAlphaClip.tid0))
			{
				this.AlphaTexture = value;
				return true;
			}
			return false;
		}
	}
	/// <summary><para>Technique 'NonLinearDepthOut' generated from file 'Depth.fx'</para><para>Vertex Shader: approximately 6 instruction slots used, 4 registers</para><para>Pixel Shader: approximately 4 instruction slots used, 0 registers</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	public sealed class NonLinearDepthOut : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'NonLinearDepthOut' shader</summary>
		public NonLinearDepthOut()
		{
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			NonLinearDepthOut.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != NonLinearDepthOut.gd))
			{
				this.WarmShader(state);
				ic = true;
			}
			// Force updating if the instance has changed
			this.vreg_change = (this.vreg_change | ic);
			this.vbreg_change = (this.vbreg_change | ic);
			this.vireg_change = (this.vireg_change | ic);
			// Set the value for attribute 'worldViewProj'
			this.vreg_change = (this.vreg_change | state.SetWorldViewProjectionMatrix(ref this.vreg[0], ref this.vreg[1], ref this.vreg[2], ref this.vreg[3], ref this.sc0));
			if ((this.vreg_change == true))
			{
				NonLinearDepthOut.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			if ((ext == Xen.Graphics.ShaderSystem.ShaderExtension.Blending))
			{
				ic = (ic | state.SetBlendMatricesDirect(NonLinearDepthOut.fx.vsb_c, ref this.sc1));
			}
			if ((ext == Xen.Graphics.ShaderSystem.ShaderExtension.Instancing))
			{
				this.vireg_change = (this.vireg_change | state.SetViewProjectionMatrix(ref this.vireg[0], ref this.vireg[1], ref this.vireg[2], ref this.vireg[3], ref this.sc2));
				if ((this.vireg_change == true))
				{
					NonLinearDepthOut.fx.vsi_c.SetValue(this.vireg);
					this.vireg_change = false;
					ic = true;
				}
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref NonLinearDepthOut.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((NonLinearDepthOut.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((NonLinearDepthOut.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			NonLinearDepthOut.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out NonLinearDepthOut.fx, NonLinearDepthOut.fxb, 7, 6);
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
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(NonLinearDepthOut.vin[i]));
			index = NonLinearDepthOut.vin[(i + 1)];
		}
		/// <summary>Static graphics ID</summary>
		private static int gd;
		/// <summary>Static effect container instance</summary>
		private static Xen.Graphics.ShaderSystem.ShaderEffect fx;
		/// <summary/>
		private bool vreg_change;
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
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute '__BLENDMATRICES__GENMATRIX'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute 'viewProj'</summary>
		private int sc2;
		/// <summary>array storing vertex usages, and element indices</summary>
readonly 
		private static int[] vin = new int[] {0,0};
		/// <summary>Vertex shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vreg = new Microsoft.Xna.Framework.Vector4[4];
		/// <summary>Instancing shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vireg = new Microsoft.Xna.Framework.Vector4[4];
#if XBOX360
		/// <summary>Static RLE compressed shader byte code (Xbox360)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {4,188,240,11,207,131,0,1,32,152,0,8,254,255,9,1,0,0,15,60,135,0,1,3,131,0,1,1,131,0,1,96,135,0,1,4,131,0,1,4,131,0,1,1,195,0,6,6,95,118,115,95,99,134,0,1,3,131,0,5,1,0,0,14,8,135,0,1,216,131,0,1,4,131,0,1,1,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,153,0,0,1,7,1,95,1,118,1,115,1,98,1,95,1,99,133,0,0,1,3,131,0,0,1,1,1,0,1,0,1,14,1,112,135,0,0,1,4,131,0,0,1,4,131,0,0,1,1,195,0,0,1,7,1,95,1,118,1,115,1,105,1,95,1,99,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,3,131,0,0,1,16,131,0,0,1,4,143,0,0,1,4,131,0,0,1,15,131,0,0,1,4,143,0,0,1,9,1,66,1,108,1,101,1,110,1,100,1,105,1,110,1,103,135,0,0,1,5,131,0,0,1,16,131,0,0,1,4,143,0,0,1,6,131,0,0,1,15,131,0,0,1,4,143,0,0,1,11,1,73,1,110,1,115,1,116,1,97,1,110,1,99,1,105,1,110,1,103,133,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,3,131,0,0,1,1,131,0,0,1,9,131,0,0,1,7,131,0,0,1,4,131,0,0,1,32,139,0,0,1,108,131,0,0,1,136,138,0,0,1,14,1,20,1,0,1,0,1,14,1,48,138,0,0,1,15,1,48,135,0,0,1,3,1,0,1,0,1,14,1,172,135,0,0,1,2,131,0,0,1,92,134,0,0,1,14,1,128,1,0,1,0,1,14,1,124,131,0,0,1,93,134,0,0,1,14,1,152,1,0,1,0,1,14,1,148,1,0,1,0,1,14,1,224,135,0,0,1,2,131,0,0,1,92,134,0,0,1,14,1,180,1,0,1,0,1,14,1,176,131,0,0,1,93,134,0,0,1,14,1,204,1,0,1,0,1,14,1,200,1,0,1,0,1,15,1,32,135,0,0,1,2,131,0,0,1,92,134,0,0,1,14,1,244,1,0,1,0,1,14,1,240,131,0,0,1,93,134,0,0,1,15,1,12,1,0,1,0,1,15,1,8,135,0,0,1,6,135,0,0,1,2,132,255,0,131,0,0,1,1,135,0,0,1,172,1,16,1,42,1,17,132,0,0,1,124,131,0,0,1,48,135,0,0,1,36,135,0,0,1,88,139,0,0,1,48,131,0,0,1,28,131,0,0,1,35,1,255,1,255,1,3,144,0,0,1,28,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,48,1,16,134,0,0,1,4,134,0,0,1,8,1,33,1,0,1,1,1,0,1,1,131,0,0,1,1,1,0,1,0,1,48,1,80,132,0,0,1,32,1,1,1,196,1,0,1,34,131,0,0,1,76,1,64,133,0,0,1,177,1,226,131,0,0,1,200,1,143,1,192,1,0,1,0,1,198,1,108,1,0,1,225,150,0,0,1,2,132,255,0,138,0,0,1,1,1,236,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,8,131,0,0,1,228,135,0,0,1,36,135,0,0,1,196,139,0,0,1,156,131,0,0,1,28,131,0,0,1,143,1,255,1,254,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,136,131,0,0,1,48,1,0,1,2,1,0,1,4,1,0,1,4,133,0,0,1,56,131,0,0,1,72,1,95,1,118,1,115,1,105,1,95,1,99,1,0,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,4,198,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,228,1,0,1,1,1,0,1,4,138,0,0,1,8,1,33,131,0,0,1,1,131,0,0,1,5,131,0,0,1,1,1,0,1,0,1,2,1,144,1,0,1,16,1,0,1,3,1,0,1,12,1,0,1,4,1,0,1,13,1,0,1,5,1,0,1,14,1,0,1,6,1,0,1,63,1,0,1,7,1,0,1,0,1,48,1,80,1,0,1,0,1,16,1,17,1,241,1,85,1,80,1,3,1,0,1,0,1,18,1,1,1,194,133,0,0,1,96,1,8,1,48,1,14,1,18,1,0,1,18,135,0,0,1,16,1,17,1,196,1,0,1,34,131,0,0,1,5,1,248,1,32,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,16,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,48,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,64,131,0,0,1,6,1,136,132,0,0,1,5,1,248,132,0,0,1,6,1,136,132,0,0,1,200,1,15,131,0,0,1,27,1,0,1,0,1,225,1,2,1,0,1,0,1,200,1,15,131,0,0,1,198,1,0,1,0,1,235,1,2,1,4,1,0,1,200,1,15,131,0,0,1,177,1,148,1,148,1,235,1,2,1,3,1,0,1,200,1,15,1,0,1,1,1,0,1,108,1,248,1,148,1,235,1,2,1,1,1,0,1,200,1,8,131,0,0,1,233,1,167,1,0,1,175,1,1,1,7,1,0,1,200,1,4,131,0,0,1,233,1,167,1,0,1,175,1,1,1,6,1,0,1,200,1,2,131,0,0,1,233,1,167,1,0,1,175,1,1,1,5,1,0,1,200,1,1,131,0,0,1,233,1,167,1,0,1,175,1,1,1,4,1,0,1,200,1,15,1,128,1,62,132,0,0,1,226,131,0,0,1,200,1,3,1,128,1,0,1,0,1,26,1,26,1,0,1,226,150,0,0,1,1,132,255,0,131,0,0,1,1,135,0,0,1,172,1,16,1,42,1,17,132,0,0,1,124,131,0,0,1,48,135,0,0,1,36,135,0,0,1,88,139,0,0,1,48,131,0,0,1,28,131,0,0,1,35,1,255,1,255,1,3,144,0,0,1,28,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,48,1,16,134,0,0,1,4,134,0,0,1,8,1,33,1,0,1,1,1,0,1,1,131,0,0,1,1,1,0,1,0,1,48,1,80,132,0,0,1,32,1,1,1,196,1,0,1,34,131,0,0,1,76,1,64,133,0,0,1,177,1,226,131,0,0,1,200,1,143,1,192,1,0,1,0,1,198,1,108,1,0,1,225,150,0,0,1,1,132,255,0,138,0,0,1,16,1,196,1,16,1,42,1,17,1,1,1,0,1,0,1,14,1,212,1,0,1,0,1,1,1,240,135,0,0,1,36,1,0,1,0,1,14,1,112,1,0,1,0,1,14,1,152,138,0,0,1,14,1,72,131,0,0,1,28,1,0,1,0,1,14,1,59,1,255,1,254,1,3,132,0,0,1,2,131,0,0,1,28,134,0,0,1,14,1,52,131,0,0,1,68,1,0,1,2,131,0,0,1,4,133,0,0,1,76,131,0,0,1,92,131,0,0,1,156,1,0,1,2,1,0,1,4,1,0,1,216,133,0,0,1,164,131,0,0,1,180,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,4,198,0,0,1,95,1,118,1,115,1,98,1,95,1,99,1,0,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,216,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,156,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,1,1,176,1,0,1,1,1,0,1,5,138,0,0,1,8,1,33,131,0,0,1,1,131,0,0,1,3,131,0,0,1,1,1,0,1,0,1,2,1,144,1,0,1,16,1,0,1,5,1,0,1,0,1,16,1,6,1,0,1,48,1,32,1,7,1,0,1,0,1,48,1,80,1,0,1,0,1,16,1,34,180,0,0,1,63,1,128,1,0,1,0,1,64,1,64,134,0,0,1,112,1,21,1,48,1,5,1,0,1,0,1,18,1,0,1,194,133,0,0,1,96,1,8,1,96,1,14,1,18,1,0,1,18,133,0,0,1,96,1,20,1,96,1,26,1,18,1,0,1,18,133,0,0,1,32,1,32,1,0,1,0,1,18,1,0,1,196,133,0,0,1,16,1,34,1,0,1,0,1,34,133,0,0,1,5,1,248,1,32,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,16,131,0,0,1,2,1,208,132,0,0,1,5,1,248,132,0,0,1,6,1,136,132,0,0,1,200,1,15,1,0,1,5,1,0,1,0,1,198,1,0,1,161,1,0,1,255,1,0,1,92,134,0,0,1,27,1,226,1,0,1,0,1,5,1,200,1,15,1,0,1,0,1,160,1,198,1,136,1,0,1,161,1,1,1,4,1,0,1,200,1,15,1,0,1,4,1,160,1,198,1,136,1,0,1,161,1,1,1,5,1,0,1,92,1,15,1,0,1,3,1,160,1,198,1,136,1,198,1,161,1,1,1,6,1,5,1,200,1,15,1,0,1,3,1,160,1,177,1,136,1,0,1,171,1,1,1,6,1,3,1,200,1,15,1,0,1,4,1,160,1,177,1,136,1,0,1,171,1,1,1,5,1,4,1,200,1,15,1,0,1,0,1,160,1,177,1,136,1,0,1,171,1,1,1,4,1,0,1,92,1,2,1,0,1,1,1,0,1,27,1,27,1,177,1,161,1,2,1,0,1,5,1,200,1,15,1,0,1,0,1,160,1,27,1,52,1,148,1,171,1,1,1,4,1,0,1,200,1,15,1,0,1,4,1,160,1,27,1,52,1,148,1,171,1,1,1,5,1,4,1,200,1,15,1,0,1,3,1,160,1,27,1,52,1,148,1,171,1,1,1,6,1,3,1,92,1,8,1,0,1,1,1,0,1,27,1,27,1,108,1,161,1,2,1,1,1,5,1,200,1,15,1,0,1,3,1,160,1,108,1,208,1,148,1,171,1,1,1,6,1,3,1,200,1,15,1,0,1,4,1,160,1,108,1,208,1,148,1,171,1,1,1,5,1,4,1,200,1,15,1,0,1,0,1,160,1,108,1,208,1,148,1,171,1,1,1,4,1,0,1,200,1,1,131,0,0,1,170,1,167,1,0,1,239,1,0,1,2,1,0,1,200,1,2,131,0,0,1,170,1,167,1,0,1,239,1,4,1,2,1,0,1,200,1,4,131,0,0,1,170,1,167,1,0,1,239,1,3,1,2,1,0,1,200,1,1,1,0,1,1,1,0,1,190,1,190,1,0,1,176,131,0,0,1,200,1,4,1,0,1,1,1,0,1,190,1,190,1,0,1,176,1,0,1,1,1,0,1,200,1,15,1,0,1,2,1,0,1,176,1,27,1,166,1,108,1,255,1,2,1,0,1,200,1,8,131,0,0,1,85,1,62,1,0,1,175,1,2,1,3,1,0,1,200,1,4,131,0,0,1,85,1,62,1,0,1,175,1,2,1,2,1,0,1,200,1,3,131,0,0,1,196,1,25,1,0,1,224,1,1,1,1,1,0,1,200,1,15,1,128,1,62,132,0,0,1,226,131,0,0,1,200,1,3,1,128,1,0,1,0,1,26,1,26,1,0,1,226,151,0,0,132,255,0,131,0,0,1,1,135,0,0,1,172,1,16,1,42,1,17,132,0,0,1,124,131,0,0,1,48,135,0,0,1,36,135,0,0,1,88,139,0,0,1,48,131,0,0,1,28,131,0,0,1,35,1,255,1,255,1,3,144,0,0,1,28,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,48,1,16,134,0,0,1,4,134,0,0,1,8,1,33,1,0,1,1,1,0,1,1,131,0,0,1,1,1,0,1,0,1,48,1,80,132,0,0,1,32,1,1,1,196,1,0,1,34,131,0,0,1,76,1,64,133,0,0,1,177,1,226,131,0,0,1,200,1,143,1,192,1,0,1,0,1,198,1,108,1,0,1,225,151,0,0,132,255,0,138,0,0,1,1,1,124,1,16,1,42,1,17,1,1,131,0,0,1,248,131,0,0,1,132,135,0,0,1,36,135,0,0,1,196,139,0,0,1,156,131,0,0,1,28,131,0,0,1,143,1,255,1,254,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,136,131,0,0,1,48,1,0,1,2,131,0,0,1,4,133,0,0,1,56,131,0,0,1,72,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,4,198,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,132,1,0,1,1,1,0,1,1,138,0,0,1,8,1,33,131,0,0,1,1,131,0,0,1,1,131,0,0,1,1,1,0,1,0,1,2,1,144,131,0,0,1,3,1,0,1,0,1,48,1,80,1,0,1,0,1,16,1,9,1,16,1,1,1,16,1,3,1,0,1,0,1,18,1,0,1,194,133,0,0,1,80,1,4,1,0,1,0,1,18,1,0,1,196,133,0,0,1,16,1,9,1,0,1,0,1,34,133,0,0,1,5,1,248,1,16,131,0,0,1,6,1,136,132,0,0,1,200,1,8,131,0,0,1,167,1,167,1,0,1,175,1,1,1,3,1,0,1,200,1,4,131,0,0,1,167,1,167,1,0,1,175,1,1,1,2,1,0,1,200,1,2,131,0,0,1,167,1,167,1,0,1,175,1,1,1,1,1,0,1,200,1,1,131,0,0,1,167,1,167,1,0,1,175,1,1,1,0,1,0,1,200,1,15,1,128,1,62,132,0,0,1,226,131,0,0,1,200,1,3,1,128,1,0,1,0,1,26,1,26,1,0,1,226,142,0,0,1,0};
			}
		}
#else
		/// <summary>Static Length+DeflateStream compressed shader byte code (Windows)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {124,38,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,210,95,99,248,249,53,127,236,255,254,191,126,207,223,84,126,255,181,241,55,253,255,15,208,239,126,29,253,255,175,169,127,127,200,243,235,209,255,127,255,203,230,247,159,254,26,174,159,223,224,55,145,239,254,173,95,227,155,235,231,71,207,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,63,122,126,244,220,238,249,245,127,13,142,211,38,8,212,76,156,182,210,56,237,155,140,7,181,159,2,253,0,222,111,246,107,8,108,255,249,181,232,255,8,77,187,159,75,255,255,247,255,13,252,126,179,200,247,248,59,246,222,143,209,255,159,148,249,114,86,44,47,240,247,175,251,107,196,223,71,172,26,123,255,55,164,255,159,45,155,54,91,78,25,2,198,240,122,158,205,242,218,209,10,125,224,115,188,155,122,239,150,244,255,63,202,251,251,183,34,154,238,40,93,241,236,123,49,248,95,167,159,99,252,127,138,126,255,7,209,103,63,67,255,255,83,245,239,63,139,126,255,211,232,255,255,89,164,237,223,69,159,253,109,94,219,127,137,126,255,231,232,255,191,155,246,225,183,253,223,232,243,95,238,181,253,205,168,205,111,164,237,126,61,249,193,237,255,111,122,204,188,255,77,248,231,215,254,191,255,239,255,235,255,254,109,126,141,147,55,199,79,126,39,250,243,199,245,51,109,130,39,197,231,171,230,247,191,247,251,239,252,26,95,20,211,186,106,170,243,54,221,122,117,39,253,246,243,215,207,83,161,92,122,82,45,86,69,73,191,60,28,239,125,58,126,120,127,111,188,119,176,191,255,107,252,4,79,207,111,250,23,209,200,127,15,15,230,175,241,187,16,58,244,197,31,68,157,253,73,191,30,163,246,107,210,239,95,253,73,191,46,72,247,27,252,250,244,59,190,251,53,254,164,95,19,223,253,6,191,1,126,255,139,12,86,102,28,6,214,191,134,1,253,218,255,23,141,99,215,142,227,79,252,53,228,51,124,245,59,113,171,95,35,253,163,232,159,29,126,255,215,225,121,61,160,255,127,251,215,176,252,251,215,254,154,212,245,175,169,223,125,19,207,229,215,164,217,239,194,67,252,141,254,32,162,219,159,36,191,255,198,127,208,175,105,127,255,77,254,160,95,203,254,254,155,254,65,191,182,253,253,215,248,131,126,29,239,119,250,238,63,50,52,166,113,253,71,191,166,182,255,117,126,141,255,140,105,76,240,168,205,87,244,221,127,246,39,209,120,127,29,249,27,239,253,103,68,243,255,236,15,114,159,253,53,212,159,251,236,215,224,207,254,111,234,87,62,251,49,102,245,95,243,63,250,53,248,251,255,236,47,146,191,127,45,254,251,215,213,191,137,166,128,251,7,253,122,246,239,223,128,255,254,245,233,111,193,235,55,250,143,0,11,191,11,174,255,195,31,100,102,23,243,231,243,236,223,135,127,126,173,8,207,254,90,81,158,221,251,58,244,223,196,179,191,134,240,236,223,36,60,251,27,208,239,95,253,77,204,179,191,6,120,246,255,166,255,255,26,127,211,175,105,191,251,53,100,124,191,1,104,246,159,245,198,100,224,254,204,111,70,255,252,90,224,223,63,239,215,54,99,58,252,77,228,51,116,104,248,119,159,62,123,250,107,8,18,191,14,253,251,156,126,254,190,244,255,63,143,63,251,117,56,255,246,151,209,255,255,182,95,195,228,232,254,218,111,156,167,213,166,88,184,255,214,141,111,252,232,249,209,243,163,231,71,207,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,125,159,31,181,255,209,179,233,185,252,128,88,247,223,227,88,247,247,252,61,125,120,94,30,129,115,10,191,38,231,17,228,119,250,130,115,16,18,247,254,166,156,31,248,247,40,214,29,75,142,225,111,146,216,95,114,5,191,38,229,116,126,157,244,63,251,139,16,39,255,58,18,87,255,65,242,55,199,201,127,146,228,13,252,207,255,26,250,252,175,137,124,254,127,211,231,255,55,127,174,57,135,63,8,185,10,211,215,175,169,125,253,186,94,95,248,236,215,245,250,210,28,134,247,185,244,213,255,92,250,114,249,141,95,139,251,250,53,59,125,253,122,157,190,126,189,129,190,126,189,129,190,126,189,104,95,191,142,237,203,229,17,254,239,63,73,199,252,15,97,188,191,134,203,179,240,223,191,102,39,207,242,107,117,242,44,191,182,203,179,252,67,14,110,152,103,193,243,255,183,60,11,30,63,207,178,143,193,253,90,145,60,225,175,53,148,39,148,60,203,193,175,97,243,132,63,43,57,149,175,43,187,190,140,122,252,241,39,117,248,227,79,50,252,97,120,203,240,135,208,238,63,251,147,124,254,248,53,60,254,248,53,148,63,254,159,0,0,0,255,255};
			}
		}
#endif
	}
	/// <summary><para>Technique 'NonLinearDepthOutTextureAlphaClip' generated from file 'Depth.fx'</para><para>Vertex Shader: approximately 7 instruction slots used, 4 registers</para><para>Pixel Shader: approximately 7 instruction slots used (1 texture, 6 arithmetic), 1 register</para></summary>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Xen.Graphics.ShaderSystem.CustomTool.dll", "c31205e5-3188-40cc-ae97-d91ef3da07ce")]
	public sealed class NonLinearDepthOutTextureAlphaClip : Xen.Graphics.ShaderSystem.BaseShader
	{
		/// <summary>Construct an instance of the 'NonLinearDepthOutTextureAlphaClip' shader</summary>
		public NonLinearDepthOutTextureAlphaClip()
		{
			this.sc0 = -1;
			this.sc1 = -1;
			this.sc2 = -1;
			this.pts[0] = ((Xen.Graphics.TextureSamplerState)(192));
		}
		/// <summary>Setup shader static values</summary><param name="state"/>
		private void gdInit(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// set the graphics ID
			NonLinearDepthOutTextureAlphaClip.gd = state.DeviceUniqueIndex;
			this.GraphicsID = state.DeviceUniqueIndex;
			NonLinearDepthOutTextureAlphaClip.cid0 = state.GetNameUniqueID("clipThreshold");
			NonLinearDepthOutTextureAlphaClip.sid0 = state.GetNameUniqueID("AlphaTextureSampler");
			NonLinearDepthOutTextureAlphaClip.tid0 = state.GetNameUniqueID("AlphaTexture");
		}
		/// <summary>Bind the shader, 'ic' indicates the shader instance has changed and 'ec' indicates the extension has changed.</summary><param name="state"/><param name="ic"/><param name="ec"/><param name="ext"/>
		protected override void BeginImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, bool ic, bool ec, Xen.Graphics.ShaderSystem.ShaderExtension ext)
		{
			// if the device changed, call Warm()
			if ((state.DeviceUniqueIndex != NonLinearDepthOutTextureAlphaClip.gd))
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
				NonLinearDepthOutTextureAlphaClip.fx.vs_c.SetValue(this.vreg);
				this.vreg_change = false;
				ic = true;
			}
			if ((this.preg_change == true))
			{
				NonLinearDepthOutTextureAlphaClip.fx.ps_c.SetValue(this.preg);
				this.preg_change = false;
				ic = true;
			}
			if ((ext == Xen.Graphics.ShaderSystem.ShaderExtension.Blending))
			{
				ic = (ic | state.SetBlendMatricesDirect(NonLinearDepthOutTextureAlphaClip.fx.vsb_c, ref this.sc1));
			}
			if ((ext == Xen.Graphics.ShaderSystem.ShaderExtension.Instancing))
			{
				this.vireg_change = (this.vireg_change | state.SetViewProjectionMatrix(ref this.vireg[0], ref this.vireg[1], ref this.vireg[2], ref this.vireg[3], ref this.sc2));
				if ((this.vireg_change == true))
				{
					NonLinearDepthOutTextureAlphaClip.fx.vsi_c.SetValue(this.vireg);
					this.vireg_change = false;
					ic = true;
				}
			}
			// Finally, bind the effect
			if ((ic | ec))
			{
				state.SetEffect(this, ref NonLinearDepthOutTextureAlphaClip.fx, ext);
			}
		}
		/// <summary>Warm (Preload) the shader</summary><param name="state"/>
		protected override void WarmShader(Xen.Graphics.ShaderSystem.ShaderSystemBase state)
		{
			// Shader is already warmed
			if ((NonLinearDepthOutTextureAlphaClip.gd == state.DeviceUniqueIndex))
			{
				return;
			}
			// Setup the shader
			if ((NonLinearDepthOutTextureAlphaClip.gd != state.DeviceUniqueIndex))
			{
				this.gdInit(state);
			}
			NonLinearDepthOutTextureAlphaClip.fx.Dispose();
			// Create the effect instance
			state.CreateEffect(out NonLinearDepthOutTextureAlphaClip.fx, NonLinearDepthOutTextureAlphaClip.fxb, 9, 11);
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
			usage = ((Microsoft.Xna.Framework.Graphics.VertexElementUsage)(NonLinearDepthOutTextureAlphaClip.vin[i]));
			index = NonLinearDepthOutTextureAlphaClip.vin[(i + 2)];
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
		/// <summary>Name ID for 'clipThreshold'</summary>
		private static int cid0;
		/// <summary>Assign the shader value 'float clipThreshold'</summary>
		public float ClipThreshold
		{
			set
			{
				this.preg[0] = new Microsoft.Xna.Framework.Vector4(value, 0F, 0F, 0F);
				this.preg_change = true;
			}
		}
		/// <summary>Change ID for Semantic bound attribute 'worldViewProj'</summary>
		private int sc0;
		/// <summary>Change ID for Semantic bound attribute '__BLENDMATRICES__GENMATRIX'</summary>
		private int sc1;
		/// <summary>Change ID for Semantic bound attribute 'viewProj'</summary>
		private int sc2;
		/// <summary>Get/Set the Texture Sampler State for 'Sampler2D AlphaTextureSampler'</summary>
		public Xen.Graphics.TextureSamplerState AlphaTextureSampler
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
		/// <summary>Get/Set the Bound texture for 'Texture2D AlphaTexture'</summary>
		public Microsoft.Xna.Framework.Graphics.Texture2D AlphaTexture
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
		/// <summary>Name uid for sampler for 'Sampler2D AlphaTextureSampler'</summary>
		static int sid0;
		/// <summary>Name uid for texture for 'Texture2D AlphaTexture'</summary>
		static int tid0;
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
		private Microsoft.Xna.Framework.Vector4[] preg = new Microsoft.Xna.Framework.Vector4[1];
		/// <summary>Instancing shader register storage</summary>
readonly 
		private Microsoft.Xna.Framework.Vector4[] vireg = new Microsoft.Xna.Framework.Vector4[4];
		/// <summary>Bound pixel textures</summary>
readonly 
		Microsoft.Xna.Framework.Graphics.Texture[] ptx = new Microsoft.Xna.Framework.Graphics.Texture[1];
		/// <summary>Bound pixel samplers</summary>
readonly 
		Xen.Graphics.TextureSamplerState[] pts = new Xen.Graphics.TextureSamplerState[1];
#if XBOX360
		/// <summary>Static RLE compressed shader byte code (Xbox360)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {4,188,240,11,207,131,0,1,32,152,0,8,254,255,9,1,0,0,15,152,135,0,1,3,131,0,1,1,131,0,1,96,135,0,1,4,131,0,1,4,131,0,1,1,195,0,6,6,95,118,115,95,99,134,0,1,3,131,0,1,1,131,0,1,152,135,0,1,1,131,0,1,4,131,0,1,1,147,0,0,1,6,1,95,1,112,1,115,1,95,1,99,134,0,0,1,3,131,0,0,1,1,1,0,1,0,1,14,1,64,135,0,0,1,216,131,0,0,1,4,131,0,0,1,1,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,153,0,0,1,7,1,95,1,118,1,115,1,98,1,95,1,99,133,0,0,1,3,131,0,0,1,1,1,0,1,0,1,14,1,168,135,0,0,1,4,131,0,0,1,4,131,0,0,1,1,195,0,0,1,7,1,95,1,118,1,115,1,105,1,95,1,99,133,0,0,1,12,131,0,0,1,4,1,0,1,0,1,14,1,204,143,0,0,1,7,1,95,1,112,1,115,1,95,1,115,1,48,133,0,0,1,1,131,0,0,1,16,131,0,0,1,4,143,0,0,1,2,131,0,0,1,15,131,0,0,1,4,147,0,0,1,3,131,0,0,1,16,131,0,0,1,4,143,0,0,1,4,131,0,0,1,15,131,0,0,1,4,143,0,0,1,9,1,66,1,108,1,101,1,110,1,100,1,105,1,110,1,103,135,0,0,1,5,131,0,0,1,16,131,0,0,1,4,143,0,0,1,6,131,0,0,1,15,131,0,0,1,4,143,0,0,1,11,1,73,1,110,1,115,1,116,1,97,1,110,1,99,1,105,1,110,1,103,133,0,0,1,7,1,83,1,104,1,97,1,100,1,101,1,114,133,0,0,1,5,131,0,0,1,1,131,0,0,1,10,131,0,0,1,7,131,0,0,1,4,131,0,0,1,32,139,0,0,1,108,131,0,0,1,136,139,0,0,1,164,131,0,0,1,192,138,0,0,1,14,1,76,1,0,1,0,1,14,1,104,138,0,0,1,14,1,180,1,0,1,0,1,14,1,200,138,0,0,1,15,1,140,135,0,0,1,3,1,0,1,0,1,15,1,8,135,0,0,1,2,131,0,0,1,92,134,0,0,1,14,1,220,1,0,1,0,1,14,1,216,131,0,0,1,93,134,0,0,1,14,1,244,1,0,1,0,1,14,1,240,1,0,1,0,1,15,1,60,135,0,0,1,2,131,0,0,1,92,134,0,0,1,15,1,16,1,0,1,0,1,15,1,12,131,0,0,1,93,134,0,0,1,15,1,40,1,0,1,0,1,15,1,36,1,0,1,0,1,15,1,124,135,0,0,1,2,131,0,0,1,92,134,0,0,1,15,1,80,1,0,1,0,1,15,1,76,131,0,0,1,93,134,0,0,1,15,1,104,1,0,1,0,1,15,1,100,135,0,0,1,6,135,0,0,1,2,132,255,0,131,0,0,1,1,134,0,0,1,1,1,164,1,16,1,42,1,17,131,0,0,1,1,1,16,131,0,0,1,148,135,0,0,1,36,131,0,0,1,192,131,0,0,1,232,139,0,0,1,152,131,0,0,1,28,131,0,0,1,139,1,255,1,255,1,3,132,0,0,1,2,131,0,0,1,28,135,0,0,1,132,131,0,0,1,68,1,0,1,2,131,0,0,1,1,133,0,0,1,76,131,0,0,1,92,131,0,0,1,108,1,0,1,3,131,0,0,1,1,133,0,0,1,116,132,0,0,1,95,1,112,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,1,150,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,1,139,0,0,1,20,1,1,1,252,1,0,1,16,147,0,0,1,64,131,0,0,1,84,1,16,1,0,1,1,132,0,0,1,4,134,0,0,1,16,1,66,1,0,1,3,1,0,1,3,131,0,0,1,33,1,0,1,0,1,48,1,80,1,0,1,0,1,49,1,81,193,0,0,1,1,1,16,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,48,1,3,1,0,1,0,1,34,133,0,0,1,16,1,8,1,0,1,33,1,31,1,31,1,254,1,255,1,0,1,0,1,64,1,0,1,184,1,64,1,0,1,0,1,1,1,0,1,0,1,66,1,194,131,0,0,1,76,1,64,131,0,0,1,108,1,198,1,177,1,121,1,255,1,0,1,0,1,200,1,143,1,192,1,0,1,0,1,198,1,108,1,0,1,225,150,0,0,1,2,132,255,0,138,0,0,1,2,1,16,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,20,131,0,0,1,252,135,0,0,1,36,135,0,0,1,196,139,0,0,1,156,131,0,0,1,28,131,0,0,1,143,1,255,1,254,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,136,131,0,0,1,48,1,0,1,2,1,0,1,4,1,0,1,4,133,0,0,1,56,131,0,0,1,72,1,95,1,118,1,115,1,105,1,95,1,99,1,0,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,4,198,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,252,1,0,1,17,1,0,1,5,138,0,0,1,16,1,66,131,0,0,1,1,131,0,0,1,6,131,0,0,1,2,1,0,1,0,1,2,1,144,1,0,1,16,1,0,1,3,1,0,1,0,1,80,1,4,1,0,1,12,1,0,1,5,1,0,1,13,1,0,1,6,1,0,1,14,1,0,1,7,1,0,1,63,1,0,1,8,1,0,1,0,1,48,1,80,1,0,1,1,1,49,1,81,1,0,1,0,1,16,1,19,1,0,1,0,1,16,1,18,1,245,1,85,1,96,1,3,1,0,1,0,1,18,1,3,1,194,133,0,0,1,96,1,9,1,48,1,15,1,18,1,0,1,18,135,0,0,1,32,1,18,1,196,1,0,1,34,131,0,0,1,5,1,248,1,48,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,16,131,0,0,1,15,1,200,132,0,0,1,5,1,248,1,32,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,64,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,80,131,0,0,1,6,1,136,132,0,0,1,5,1,248,132,0,0,1,6,1,136,132,0,0,1,200,1,15,131,0,0,1,27,1,0,1,0,1,225,1,3,1,0,1,0,1,200,1,15,131,0,0,1,198,1,0,1,0,1,235,1,3,1,5,1,0,1,200,1,15,131,0,0,1,177,1,148,1,148,1,235,1,3,1,4,1,0,1,200,1,15,1,0,1,2,1,0,1,108,1,248,1,148,1,235,1,3,1,2,1,0,1,200,1,8,131,0,0,1,233,1,167,1,0,1,175,1,2,1,7,1,0,1,200,1,4,131,0,0,1,233,1,167,1,0,1,175,1,2,1,6,1,0,1,200,1,2,131,0,0,1,233,1,167,1,0,1,175,1,2,1,5,1,0,1,200,1,1,131,0,0,1,233,1,167,1,0,1,175,1,2,1,4,1,0,1,200,1,15,1,128,1,62,132,0,0,1,226,131,0,0,1,200,1,3,1,128,1,1,1,0,1,176,1,176,1,0,1,226,1,1,1,1,1,0,1,200,1,3,1,128,1,0,1,0,1,26,1,26,1,0,1,226,150,0,0,1,1,132,255,0,131,0,0,1,1,134,0,0,1,1,1,164,1,16,1,42,1,17,131,0,0,1,1,1,16,131,0,0,1,148,135,0,0,1,36,131,0,0,1,192,131,0,0,1,232,139,0,0,1,152,131,0,0,1,28,131,0,0,1,139,1,255,1,255,1,3,132,0,0,1,2,131,0,0,1,28,135,0,0,1,132,131,0,0,1,68,1,0,1,2,131,0,0,1,1,133,0,0,1,76,131,0,0,1,92,131,0,0,1,108,1,0,1,3,131,0,0,1,1,133,0,0,1,116,132,0,0,1,95,1,112,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,1,150,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,1,139,0,0,1,20,1,1,1,252,1,0,1,16,147,0,0,1,64,131,0,0,1,84,1,16,1,0,1,1,132,0,0,1,4,134,0,0,1,16,1,66,1,0,1,3,1,0,1,3,131,0,0,1,33,1,0,1,0,1,48,1,80,1,0,1,0,1,49,1,81,193,0,0,1,1,1,16,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,48,1,3,1,0,1,0,1,34,133,0,0,1,16,1,8,1,0,1,33,1,31,1,31,1,254,1,255,1,0,1,0,1,64,1,0,1,184,1,64,1,0,1,0,1,1,1,0,1,0,1,66,1,194,131,0,0,1,76,1,64,131,0,0,1,108,1,198,1,177,1,121,1,255,1,0,1,0,1,200,1,143,1,192,1,0,1,0,1,198,1,108,1,0,1,225,150,0,0,1,1,132,255,0,138,0,0,1,16,1,232,1,16,1,42,1,17,1,1,1,0,1,0,1,14,1,224,1,0,1,0,1,2,1,8,135,0,0,1,36,1,0,1,0,1,14,1,112,1,0,1,0,1,14,1,152,138,0,0,1,14,1,72,131,0,0,1,28,1,0,1,0,1,14,1,59,1,255,1,254,1,3,132,0,0,1,2,131,0,0,1,28,134,0,0,1,14,1,52,131,0,0,1,68,1,0,1,2,131,0,0,1,4,133,0,0,1,76,131,0,0,1,92,131,0,0,1,156,1,0,1,2,1,0,1,4,1,0,1,216,133,0,0,1,164,131,0,0,1,180,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,4,198,0,0,1,95,1,118,1,115,1,98,1,95,1,99,1,0,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,216,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,229,0,0,156,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,1,139,0,0,1,20,1,0,1,252,1,0,1,16,147,0,0,1,64,1,0,1,0,1,1,1,200,1,0,1,17,1,0,1,6,138,0,0,1,16,1,66,131,0,0,1,1,131,0,0,1,4,131,0,0,1,2,1,0,1,0,1,2,1,144,1,0,1,16,1,0,1,5,1,0,1,0,1,80,1,6,1,0,1,0,1,16,1,7,1,0,1,48,1,32,1,8,1,0,1,0,1,48,1,80,1,0,1,1,1,49,1,81,1,0,1,0,1,16,1,36,1,0,1,0,1,16,1,35,180,0,0,1,63,1,128,1,0,1,0,1,64,1,64,134,0,0,1,240,1,85,1,64,1,5,1,0,1,0,1,18,1,0,1,194,133,0,0,1,96,1,9,1,96,1,15,1,18,1,0,1,18,133,0,0,1,96,1,21,1,96,1,27,1,18,1,0,1,18,133,0,0,1,32,1,33,1,0,1,0,1,18,1,0,1,196,133,0,0,1,32,1,35,1,0,1,0,1,34,133,0,0,1,5,1,248,1,48,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,16,131,0,0,1,15,1,200,132,0,0,1,5,1,248,1,32,131,0,0,1,2,1,208,132,0,0,1,5,1,248,132,0,0,1,6,1,136,132,0,0,1,200,1,15,1,0,1,6,1,0,1,0,1,198,1,0,1,161,1,0,1,255,1,0,1,92,134,0,0,1,27,1,226,1,0,1,0,1,6,1,200,1,15,1,0,1,0,1,160,1,198,1,136,1,0,1,161,1,2,1,4,1,0,1,200,1,15,1,0,1,5,1,160,1,198,1,136,1,0,1,161,1,2,1,5,1,0,1,92,1,15,1,0,1,4,1,160,1,198,1,136,1,198,1,161,1,2,1,6,1,6,1,200,1,15,1,0,1,4,1,160,1,177,1,136,1,0,1,171,1,2,1,6,1,4,1,200,1,15,1,0,1,5,1,160,1,177,1,136,1,0,1,171,1,2,1,5,1,5,1,200,1,15,1,0,1,0,1,160,1,177,1,136,1,0,1,171,1,2,1,4,1,0,1,92,1,2,1,0,1,2,1,0,1,27,1,27,1,177,1,161,1,3,1,0,1,6,1,200,1,15,1,0,1,0,1,160,1,27,1,52,1,148,1,171,1,2,1,4,1,0,1,200,1,15,1,0,1,5,1,160,1,27,1,52,1,148,1,171,1,2,1,5,1,5,1,200,1,15,1,0,1,4,1,160,1,27,1,52,1,148,1,171,1,2,1,6,1,4,1,92,1,8,1,0,1,2,1,0,1,27,1,27,1,108,1,161,1,3,1,1,1,6,1,200,1,15,1,0,1,4,1,160,1,108,1,208,1,148,1,171,1,2,1,6,1,4,1,200,1,15,1,0,1,5,1,160,1,108,1,208,1,148,1,171,1,2,1,5,1,5,1,200,1,15,1,0,1,0,1,160,1,108,1,208,1,148,1,171,1,2,1,4,1,0,1,200,1,1,131,0,0,1,170,1,167,1,0,1,239,1,0,1,3,1,0,1,200,1,2,131,0,0,1,170,1,167,1,0,1,239,1,5,1,3,1,0,1,200,1,4,131,0,0,1,170,1,167,1,0,1,239,1,4,1,3,1,0,1,200,1,1,1,0,1,2,1,0,1,190,1,190,1,0,1,176,131,0,0,1,200,1,4,1,0,1,2,1,0,1,190,1,190,1,0,1,176,1,0,1,1,1,0,1,200,1,15,1,0,1,3,1,0,1,176,1,27,1,166,1,108,1,255,1,3,1,0,1,200,1,8,131,0,0,1,85,1,62,1,0,1,175,1,3,1,3,1,0,1,200,1,4,131,0,0,1,85,1,62,1,0,1,175,1,3,1,2,1,0,1,200,1,3,131,0,0,1,196,1,25,1,0,1,224,1,2,1,2,1,0,1,200,1,15,1,128,1,62,132,0,0,1,226,131,0,0,1,200,1,3,1,128,1,1,1,0,1,176,1,176,1,0,1,226,1,1,1,1,1,0,1,200,1,3,1,128,1,0,1,0,1,26,1,26,1,0,1,226,151,0,0,132,255,0,131,0,0,1,1,134,0,0,1,1,1,164,1,16,1,42,1,17,131,0,0,1,1,1,16,131,0,0,1,148,135,0,0,1,36,131,0,0,1,192,131,0,0,1,232,139,0,0,1,152,131,0,0,1,28,131,0,0,1,139,1,255,1,255,1,3,132,0,0,1,2,131,0,0,1,28,135,0,0,1,132,131,0,0,1,68,1,0,1,2,131,0,0,1,1,133,0,0,1,76,131,0,0,1,92,131,0,0,1,108,1,0,1,3,131,0,0,1,1,133,0,0,1,116,132,0,0,1,95,1,112,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,1,150,0,0,1,95,1,112,1,115,1,95,1,115,1,48,1,0,1,171,1,0,1,4,1,0,1,12,1,0,1,1,1,0,1,1,1,0,1,1,134,0,0,1,112,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,1,139,0,0,1,20,1,1,1,252,1,0,1,16,147,0,0,1,64,131,0,0,1,84,1,16,1,0,1,1,132,0,0,1,4,134,0,0,1,16,1,66,1,0,1,3,1,0,1,3,131,0,0,1,33,1,0,1,0,1,48,1,80,1,0,1,0,1,49,1,81,193,0,0,1,1,1,16,1,2,1,0,1,0,1,18,1,0,1,196,133,0,0,1,48,1,3,1,0,1,0,1,34,133,0,0,1,16,1,8,1,0,1,33,1,31,1,31,1,254,1,255,1,0,1,0,1,64,1,0,1,184,1,64,1,0,1,0,1,1,1,0,1,0,1,66,1,194,131,0,0,1,76,1,64,131,0,0,1,108,1,198,1,177,1,121,1,255,1,0,1,0,1,200,1,143,1,192,1,0,1,0,1,198,1,108,1,0,1,225,151,0,0,132,255,0,138,0,0,1,1,1,160,1,16,1,42,1,17,1,1,1,0,1,0,1,1,1,4,131,0,0,1,156,135,0,0,1,36,135,0,0,1,196,139,0,0,1,156,131,0,0,1,28,131,0,0,1,143,1,255,1,254,1,3,132,0,0,1,1,131,0,0,1,28,135,0,0,1,136,131,0,0,1,48,1,0,1,2,131,0,0,1,4,133,0,0,1,56,131,0,0,1,72,1,95,1,118,1,115,1,95,1,99,1,0,1,171,1,171,1,0,1,1,1,0,1,3,1,0,1,1,1,0,1,4,1,0,1,4,198,0,0,1,118,1,115,1,95,1,51,1,95,1,48,1,0,1,50,1,46,1,48,1,46,1,49,1,49,1,54,1,50,1,54,1,46,1,48,1,0,1,171,135,0,0,1,156,1,0,1,17,1,0,1,2,138,0,0,1,16,1,66,131,0,0,1,1,131,0,0,1,2,131,0,0,1,2,1,0,1,0,1,2,1,144,1,0,1,16,1,0,1,3,1,0,1,32,1,80,1,4,1,0,1,0,1,48,1,80,1,0,1,1,1,49,1,81,1,0,1,0,1,16,1,11,1,0,1,0,1,16,1,10,1,48,1,5,1,32,1,3,1,0,1,0,1,18,1,0,1,194,133,0,0,1,80,1,5,1,0,1,0,1,18,1,0,1,196,133,0,0,1,32,1,10,1,0,1,0,1,34,133,0,0,1,5,1,248,1,32,131,0,0,1,6,1,136,132,0,0,1,5,1,248,1,16,131,0,0,1,15,1,200,132,0,0,1,200,1,8,131,0,0,1,167,1,167,1,0,1,175,1,2,1,3,1,0,1,200,1,4,131,0,0,1,167,1,167,1,0,1,175,1,2,1,2,1,0,1,200,1,2,131,0,0,1,167,1,167,1,0,1,175,1,2,1,1,1,0,1,200,1,1,131,0,0,1,167,1,167,1,0,1,175,1,2,1,0,1,0,1,200,1,15,1,128,1,62,132,0,0,1,226,131,0,0,1,200,1,3,1,128,1,1,1,0,1,176,1,176,1,0,1,226,1,1,1,1,1,0,1,200,1,3,1,128,1,0,1,0,1,26,1,26,1,0,1,226,142,0,0,1,0};
			}
		}
#else
		/// <summary>Static Length+DeflateStream compressed shader byte code (Windows)</summary>
		private static byte[] fxb
		{
			get
			{
				return new byte[] {68,41,0,0,236,189,7,96,28,73,150,37,38,47,109,202,123,127,74,245,74,215,224,116,161,8,128,96,19,36,216,144,64,16,236,193,136,205,230,146,236,29,105,71,35,41,171,42,129,202,101,86,101,93,102,22,64,204,237,157,188,247,222,123,239,189,247,222,123,239,189,247,186,59,157,78,39,247,223,255,63,92,102,100,1,108,246,206,74,218,201,158,33,128,170,200,31,63,126,124,31,63,34,254,197,223,240,127,250,251,210,95,99,248,249,53,127,236,255,254,191,254,188,223,84,126,255,181,241,55,253,255,15,208,239,126,29,253,255,175,169,127,127,200,243,235,209,255,127,255,203,230,247,159,254,26,174,159,63,75,191,195,239,67,253,240,123,171,240,189,223,243,55,145,239,254,173,13,239,253,232,249,209,243,163,231,71,207,143,158,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,159,157,231,215,255,53,56,190,155,32,80,51,113,218,95,165,113,218,55,25,71,106,63,5,250,249,141,126,13,129,251,207,105,63,65,27,138,25,155,29,233,243,55,211,118,254,243,107,209,255,17,246,118,63,23,28,255,239,255,27,99,248,205,34,223,227,239,216,123,63,70,255,127,82,230,203,89,177,188,192,223,191,238,175,17,127,31,241,108,236,253,223,144,254,127,182,108,218,108,57,101,8,24,195,235,121,54,203,235,95,227,63,2,44,224,149,252,26,242,57,222,77,189,119,75,250,255,31,229,253,253,151,209,255,255,33,239,239,231,68,159,185,71,163,191,141,126,255,167,188,191,255,36,47,254,255,13,244,119,208,231,79,209,239,255,61,106,251,111,209,255,255,84,253,251,151,211,239,255,19,253,255,247,140,180,253,173,232,179,223,236,55,117,109,71,244,251,22,253,255,15,138,180,125,67,159,189,244,218,150,244,251,92,219,253,122,242,131,219,255,223,244,24,222,249,189,241,203,175,253,127,255,223,255,215,255,189,243,107,156,188,57,126,242,59,209,159,127,236,175,33,159,161,237,239,196,173,126,141,244,15,163,127,158,234,251,191,38,253,251,156,126,254,190,191,134,208,234,215,214,207,90,133,41,249,133,191,246,175,253,53,233,155,95,147,168,59,196,167,202,83,127,237,175,67,156,247,107,242,127,242,208,199,247,126,255,157,95,227,139,98,90,87,77,117,222,166,91,175,238,164,223,126,254,250,121,42,51,152,158,84,139,85,81,210,47,15,199,123,159,142,31,222,223,27,239,29,236,239,255,26,63,65,108,242,107,254,26,191,233,95,68,212,249,61,252,126,126,23,66,155,230,252,15,34,76,255,36,249,253,215,252,131,126,77,253,157,190,254,147,104,146,254,162,39,60,140,223,148,62,255,207,232,239,255,236,47,250,181,244,111,162,22,253,255,215,248,139,143,153,101,126,211,63,232,215,227,119,126,77,250,236,171,63,233,215,69,155,223,224,215,199,247,248,255,159,244,107,226,187,223,224,55,32,24,191,198,95,244,127,255,223,210,183,161,183,193,229,127,99,122,255,95,68,239,93,75,239,63,241,215,144,207,240,149,161,247,31,69,255,236,240,251,191,14,243,231,1,253,255,219,191,134,149,85,75,219,46,223,127,221,231,242,107,210,92,104,248,27,253,65,68,27,165,231,111,76,227,55,191,255,38,127,208,175,101,127,255,77,255,160,95,219,254,254,107,252,65,191,142,254,142,121,249,117,189,207,169,221,127,228,205,145,254,254,107,16,156,95,251,63,250,53,21,206,175,67,115,4,218,255,154,60,63,95,241,156,17,29,126,29,249,27,48,254,51,154,139,255,236,15,114,159,253,53,244,190,251,204,204,235,175,173,159,253,24,207,245,175,249,31,253,26,252,253,127,246,23,201,223,191,22,255,253,235,234,223,68,107,192,165,249,55,127,255,6,252,247,175,79,127,11,94,191,209,127,4,88,248,93,112,253,31,248,119,140,129,96,252,73,134,3,48,199,190,252,205,240,203,175,21,145,191,95,235,231,84,254,246,190,14,47,108,146,191,95,67,228,239,111,50,191,255,154,238,247,174,252,253,77,183,148,191,191,137,229,239,215,176,242,247,55,201,60,136,252,137,44,226,253,255,236,15,234,210,222,224,245,167,253,102,244,207,175,5,89,252,243,126,109,67,251,195,223,68,62,243,105,191,255,155,56,218,255,58,30,237,255,60,254,236,215,225,188,233,95,70,255,255,219,126,13,147,147,117,180,255,166,228,83,125,1,11,247,223,186,241,141,31,61,63,122,126,244,252,232,249,209,243,163,231,71,207,143,158,31,61,223,196,243,35,24,63,122,126,244,252,232,49,207,229,7,196,202,255,30,199,202,191,231,239,233,195,243,242,32,54,63,98,242,41,191,38,231,65,228,119,106,196,249,148,95,87,227,100,228,50,254,61,138,123,199,146,35,249,155,36,119,33,185,142,95,139,114,85,191,78,250,159,253,69,136,153,127,29,78,165,82,14,133,255,254,53,254,166,95,11,241,183,228,69,188,207,255,26,250,252,175,137,124,254,127,211,231,255,55,127,174,57,147,63,8,185,22,211,215,175,169,125,253,186,94,95,248,236,215,245,250,210,28,140,247,185,244,213,255,92,250,114,249,153,95,139,251,250,53,59,125,253,122,157,190,126,189,129,190,126,189,129,190,126,189,104,95,191,142,237,203,228,20,168,205,159,164,99,254,135,48,222,95,195,229,137,248,239,95,179,147,39,250,181,58,121,162,95,219,229,137,254,33,7,55,204,19,253,154,94,158,8,207,143,242,68,63,55,121,34,60,126,158,232,57,211,62,146,179,253,181,134,114,182,146,39,58,248,53,108,206,246,103,37,39,244,117,117,207,144,142,241,248,251,79,234,240,247,159,100,248,219,200,134,225,111,145,141,255,236,79,242,249,251,215,240,248,251,215,136,240,247,255,19,0,0,255,255};
			}
		}
#endif
		/// <summary>Set a shader attribute of type 'Single' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetAttributeImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, float value)
		{
			if ((NonLinearDepthOutTextureAlphaClip.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == NonLinearDepthOutTextureAlphaClip.cid0))
			{
				this.ClipThreshold = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader sampler of type 'TextureSamplerState' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetSamplerStateImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Xen.Graphics.TextureSamplerState value)
		{
			if ((NonLinearDepthOutTextureAlphaClip.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == NonLinearDepthOutTextureAlphaClip.sid0))
			{
				this.AlphaTextureSampler = value;
				return true;
			}
			return false;
		}
		/// <summary>Set a shader texture of type 'Texture2D' by global unique ID, see <see cref="Xen.Graphics.ShaderSystem.ShaderSystemBase.GetNameUniqueID"/> for details.</summary><param name="state"/><param name="id"/><param name="value"/>
		protected override bool SetTextureImpl(Xen.Graphics.ShaderSystem.ShaderSystemBase state, int id, Microsoft.Xna.Framework.Graphics.Texture2D value)
		{
			if ((NonLinearDepthOutTextureAlphaClip.gd != state.DeviceUniqueIndex))
			{
				this.WarmShader(state);
			}
			if ((id == NonLinearDepthOutTextureAlphaClip.tid0))
			{
				this.AlphaTexture = value;
				return true;
			}
			return false;
		}
	}
}
