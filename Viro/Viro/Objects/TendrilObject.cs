using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Viro.Physics;
using Viro.Shaders;

using Xen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Viro.Objects
{
    class TendrilObject : DynamicObject
    {
        static float alpha;

        public TendrilObject(ContentRegister content, Vector3 position, Matrix orientation, string name)
            : base(content, position, orientation, name)
        {
            
        }

        public void KillTendrils()
        {
            DisolveShader disolve = new DisolveShader();
            disolve.ALPHACHANGE = 0.0f;
            disolve.NOISETEXTURE = noise;
            model.ShaderProvider = disolve;
        }

        public void DisolveTendrils()
        {
            alpha += 0.0003f;
            ((DisolveShader)(model.ShaderProvider)).ALPHACHANGE = alpha;
        }

        public override void Draw(DrawState state)
        {
            worldMatrix = Matrix.CreateTranslation(new Vector3(0,-100,0)) * orientation * Matrix.CreateTranslation(position);
            
            //using (state.WorldMatrix.PushMultiply(ref worldMatrix))
            using (state.WorldMatrix.Push(ref worldMatrix))
            {
                model.Draw(state);
            }
        }

        public void MoveTo(Vector3 Position)
        {
            SetPosition(Position);
        }
    }
}
