using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Viro.Physics;
using Viro.Interfaces;
using Microsoft.Xna.Framework;
using Xen;
using Xen.Ex.Graphics;

namespace Viro.Objects
{
    class DoorObject : DynamicObject,  ITriggerable
    {
        ParticleSystem particles;
        static Xen.Ex.Graphics.Display.ParticleDrawer3D barrier;
        static UpdateManager manager;

        public DoorObject(ContentRegister content, Vector3 position, Matrix orientation, string name)
            : base(content, position, orientation, name)
        {
            
        }

        public DoorObject() : base() { }

        public override void Activate()
        {
            collision.RemoveAllPrimitives();
            isEnabled = false;
        }

        public void init(UpdateManager updateManager)
        {
            particles = new ParticleSystem(updateManager);
            barrier = new Xen.Ex.Graphics.Display.VelocityBillboardParticles3D(this.particles, false, 0.05f);
            manager = updateManager;
        }

        public override void LoadContent(ContentState state)
        {
            this.particles.ParticleSystemData = state.Load<Xen.Ex.Graphics.Content.ParticleSystemData>(@"Particles/Snow");
            Xen.Ex.Graphics.Content.ParticleSystemHotLoader.Monitor(manager, this.particles, @"..\..\..\..\..\Viro\Xen\bin\Xen.Graphics.ShaderSystem\");
            base.LoadContent(state);
        }

        public override void Draw(DrawState state)
        {
            if (isEnabled)
            {
                using(state.WorldMatrix.PushMultiply(ref worldMatrix))
                {
                    if(state.Culler.TestSphere(100.0f))
                        barrier.Draw(state);
                }
            }
            //base.Draw(state);
        } 
    }
}
