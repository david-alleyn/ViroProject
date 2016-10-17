using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using JigLibX.Physics;
using JigLibX.Collision;
using JigLibX.Geometry;

using Xen;
using Xen.Graphics;
using Xen.Camera;
using Xen.Ex.Graphics;
using Xen.Ex.Graphics.Content;

namespace Viro.Physics
{
    public class BoxObject : DynamicObject
    {
        public BoxObject(ContentRegister content, Vector3 position, Matrix orientation, string name)
            : base(content, position, orientation, name)
        {

        }

        public override void LoadContent(ContentState state)
        {
            base.LoadContent(state);

            body = new Body();
            collision = new CollisionSkin(body);

            //Vector3 sideLengths = new Vector3(100.0f, 100.0f, 100.0f);

            //Vector3 sideLengths2 = new Vector3();

            Vector3 sideLengths = model.ModelData.StaticBounds.Maximum;
            sideLengths += new Vector3(Math.Abs(model.ModelData.StaticBounds.Minimum.X), Math.Abs(model.ModelData.StaticBounds.Minimum.Y), Math.Abs(model.ModelData.StaticBounds.Minimum.Z));

            //Vector3 boxCornerPosition = new Vector3(50.0f, 0.0f, 50.0f);

            collision.AddPrimitive(new Box(/*-0.5f * */ model.ModelData.StaticBounds.Minimum, Matrix.Identity, sideLengths), (int)MaterialTable.MaterialID.NotBouncySmooth);
            body.CollisionSkin = this.collision;

            Vector3 com = SetMass(100.0f);
            //com = new Vector3( -50, 0, -50);
            //com.Y -= 50.0f;


            body.MoveTo(position + (-com), Matrix.Identity);
            //collision.ApplyLocalTransform(new JigLibX.Math.Transform(-com, Matrix.Identity));
            body.EnableBody();
            
        }
    }
}
