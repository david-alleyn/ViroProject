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
using Xen.Ex.Graphics2D;
using Xen.Ex.Graphics.Content;

using Microsoft.Xna.Framework.Graphics;

namespace Viro.Physics
{
    public class CharacterObject : PhysicObject
    {
        public CharacterObject(ContentRegister content, Vector3 position, String modelContentName)
            : base(content, position, modelContentName)
        {

        }

        public CharacterObject() : base()
        {
            
        }

        public override void LoadContent(ContentState state)
        {
            base.LoadContent(state);

            body = new ActorBody();
            collision = new CollisionSkin(body);

            //Vector3 capsuleTop = new Vector3((model.ModelData.StaticBounds.Minimum.X + model.ModelData.StaticBounds.Maximum.X) / 2, model.ModelData.StaticBounds.Maximum.Y, 0);

            //if (modelName == "Models/WalkerAnimation")
            //{
            //    float capsuleHeight = Math.Abs(model.ModelData.StaticBounds.Maximum.Y / 100);
            //    float capsuleRadius = (Math.Abs(model.ModelData.StaticBounds.Minimum.X / 100) + Math.Abs(model.ModelData.StaticBounds.Maximum.X / 100)) / 2;
            //    Vector3 capsuleTop = new Vector3(((model.ModelData.StaticBounds.Minimum.X + model.ModelData.StaticBounds.Maximum.X) / 100) / 2, (model.ModelData.StaticBounds.Maximum.Y  / 100) - capsuleRadius, 0);

            //    Vector3 boxMiddleLengths = new Vector3(Math.Abs(model.ModelData.StaticBounds.Minimum.X / 100) + Math.Abs(model.ModelData.StaticBounds.Maximum.X / 100), (Math.Abs(model.ModelData.StaticBounds.Minimum.Y / 100) + Math.Abs(model.ModelData.StaticBounds.Maximum.Y / 100)) - (capsuleRadius * 2), Math.Abs(model.ModelData.StaticBounds.Minimum.Z / 100) + Math.Abs(model.ModelData.StaticBounds.Maximum.Z / 100));

            //    //float yValueOfModelBounds = model.ModelData.StaticBounds.Minimum.Y;
            //    Sphere sphereTop = new Sphere(capsuleTop, capsuleRadius);
            //    Sphere sphereBottom = new Sphere(capsuleTop - new Vector3(0, capsuleTop.Y - capsuleRadius, 0), capsuleRadius);
            //    Box boxMiddle = new Box(model.ModelData.StaticBounds.Minimum / new Vector3(100,100,100), Matrix.Identity, boxMiddleLengths);
            //    //Capsule capsule = new Capsule(capsuleTop /* + (new Vector3(0, -capsuleRadius, 0) * 2) */, Matrix.CreateRotationX(MathHelper.PiOver2), capsuleRadius, 0);
            //    //collision.AddPrimitive(capsule, (int)MaterialTable.MaterialID.NotBouncyNormal);

            //    collision.AddPrimitive(sphereTop, (int)MaterialTable.MaterialID.NotBouncyNormal);
            //    collision.AddPrimitive(sphereBottom, (int)MaterialTable.MaterialID.NotBouncyNormal);
            //    collision.AddPrimitive(boxMiddle, (int)MaterialTable.MaterialID.NotBouncyNormal);
            //}
            //else
            //{
                float capsuleHeight = Math.Abs(model.ModelData.StaticBounds.Maximum.Y);
                float capsuleRadius = (Math.Abs(model.ModelData.StaticBounds.Minimum.X) + Math.Abs(model.ModelData.StaticBounds.Maximum.X)) / 2;
                Vector3 capsuleTop = new Vector3((model.ModelData.StaticBounds.Minimum.X + model.ModelData.StaticBounds.Maximum.X) / 2, model.ModelData.StaticBounds.Maximum.Y - capsuleRadius, 0);

                Vector3 boxMiddleLengths = new Vector3(Math.Abs(model.ModelData.StaticBounds.Minimum.X) + Math.Abs(model.ModelData.StaticBounds.Maximum.X), (Math.Abs(model.ModelData.StaticBounds.Minimum.Y) + Math.Abs(model.ModelData.StaticBounds.Maximum.Y)) - (capsuleRadius * 2), Math.Abs(model.ModelData.StaticBounds.Minimum.Z) + Math.Abs(model.ModelData.StaticBounds.Maximum.Z));

                //float yValueOfModelBounds = model.ModelData.StaticBounds.Minimum.Y;
                Sphere sphereTop = new Sphere(capsuleTop, capsuleRadius);
                Sphere sphereBottom = new Sphere(capsuleTop - new Vector3(0, capsuleTop.Y - capsuleRadius, 0), capsuleRadius);
                Box boxMiddle = new Box(model.ModelData.StaticBounds.Minimum, Matrix.Identity, boxMiddleLengths);
                //Capsule capsule = new Capsule(capsuleTop /* + (new Vector3(0, -capsuleRadius, 0) * 2) */, Matrix.CreateRotationX(MathHelper.PiOver2), capsuleRadius, 0);
                //collision.AddPrimitive(capsule, (int)MaterialTable.MaterialID.NotBouncyNormal);
                collision.AddPrimitive(sphereTop, (int)MaterialTable.MaterialID.NotBouncyNormal);
                collision.AddPrimitive(sphereBottom, (int)MaterialTable.MaterialID.NotBouncyNormal);
                collision.AddPrimitive(boxMiddle, (int)MaterialTable.MaterialID.NotBouncyNormal);
            //}


            body.CollisionSkin = this.collision;
            Vector3 com = SetMass(10.0f);


            body.MoveTo(position + com, Matrix.Identity);

            //collision.ApplyLocalTransform(new JigLibX.Math.Transform(-com, Matrix.Identity));

            body.SetBodyInvInertia(0.0f, 0.0f, 0.0f);

            //CharacterBody = body as ActorBody;

            body.AllowFreezing = false;
            body.Immovable = false;
            body.EnableBody();
        }
    }

    class ASkinPredicate : CollisionSkinPredicate1
    {
        public override bool ConsiderSkin(CollisionSkin skin0)
        {
            if (!(skin0.Owner is ActorBody))
                return true;
            else
                return false;
        }
    }

    
}