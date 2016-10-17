using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xen;
using Xen.Ex.Graphics;
using Microsoft.Xna.Framework;

using System.Xml.Serialization;

using JigLibX.Physics;
using JigLibX.Collision;
using JigLibX.Geometry;

namespace Viro.Physics
{
    public class LevelObject : PhysicObject, IContentOwner
    {
        // VARIABLES ALREADY NOW INHERIT FROM PhysicObject (variables names not changed)
        //public string modelName;
        //public Matrix worldMatrix;
        //ModelInstance model;

        public LevelObject()
        {

        }

        public LevelObject(string name)
        {
            modelName = name;
            Matrix.CreateTranslation(ref position, out worldMatrix);
        }

        public LevelObject(ContentRegister content, Vector3 position, string name)
            : base(content, position, name)
        {

        }

        public LevelObject(LevelObject obj)
        {
            modelName = obj.modelName;
            worldMatrix = obj.worldMatrix;
            model = obj.model;
            //collisionModel = obj.collisionModel;
            position = obj.position;
        }

        public void ChangePosition(Vector3 pos)
        {
            position += pos;
            Matrix temp = new Matrix();
            Matrix.CreateTranslation(ref pos, out temp);
            worldMatrix *= temp;
        }

        public string MODELNAME
        {
            get { return modelName; }
        }

        public override void LoadContent(ContentState state)
        {
            base.LoadContent(state);

            body = new ActorBody();
            collision = new CollisionSkin(body);

            Vector3 sidelengths = new Vector3();
            sidelengths.X = Math.Abs(model.ModelData.StaticBounds.Minimum.X);
            sidelengths.Y = Math.Abs(model.ModelData.StaticBounds.Minimum.Y);
            sidelengths.Z = Math.Abs(model.ModelData.StaticBounds.Minimum.Z);
            sidelengths.X += Math.Abs(model.ModelData.StaticBounds.Maximum.X);
            sidelengths.Y += Math.Abs(model.ModelData.StaticBounds.Maximum.Y);
            sidelengths.Z += Math.Abs(model.ModelData.StaticBounds.Maximum.Z);



            Box box = new Box( -0.5f * sidelengths, Matrix.Identity, sidelengths);
            //Box box = new Box(new Vector3(0.0f, 0.0f, 0.0f), Matrix.Identity, sidelengths);
            collision.AddPrimitive(box, (int)MaterialTable.MaterialID.NormalNormal);
            body.CollisionSkin = this.collision;
            Vector3 com = SetMass(1.0f);

            body.MoveTo(position + com, Matrix.Identity);
            collision.ApplyLocalTransform(new JigLibX.Math.Transform(-com, Matrix.Identity));

            //body.SetBodyInvInertia(0.0f, 0.0f, 0.0f);

            //CharacterBody = body as ActorBody;

            body.AllowFreezing = false;
            body.Immovable = true;
            body.DisableBody();
        }
        
        public override void Draw(DrawState state)
        {
            //Inherited drawing
            base.Draw(state);
        }
    }
}