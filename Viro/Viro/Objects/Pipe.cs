using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xen;
using Microsoft.Xna.Framework;

namespace Viro.Physics
{
    class Pipe : StaticObject
    {
        Viro.Shaders.GlowShader glow;
        public Pipe(ContentRegister content, Vector3 position, Matrix orientation, string name)
            : base(content, position, orientation, name)
        {
            glow = new Shaders.GlowShader();
        }

        public Pipe() : base() { }

        public override void LoadContent(ContentState state)
        {
            base.LoadContent(state);
            glow = new Shaders.GlowShader();
            model.ShaderProvider = glow;
            if (model.ModelData.Meshes[0].Geometry[0].MaterialData.TextureFileName == "Blue_neon_pipes_0")
                glow.COLOR = Color.MidnightBlue;
            else if (model.ModelData.Meshes[0].Geometry[0].MaterialData.TextureFileName == "red_neon_pipes_0")
                glow.COLOR = Color.DarkRed;
            else if (model.ModelData.Meshes[0].Geometry[0].MaterialData.TextureFileName == "green_neon_pipes_0")
                glow.COLOR = Color.DarkGreen;
        }

        public override void Draw(DrawState state)
        {
            using (state.RenderState.Push())
            {
                state.RenderState.CurrentBlendState = Xen.Graphics.AlphaBlendState.Alpha;
                base.Draw(state);
            }
        }
    }
}
