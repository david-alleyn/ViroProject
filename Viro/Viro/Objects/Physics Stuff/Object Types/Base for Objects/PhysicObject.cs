//#define ENABLEDEBUGDRAWER

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using JigLibX.Physics;
using JigLibX.Collision;
using JigLibX.Geometry;

using Xen;
using Xen.Graphics;
using Xen.Camera;
using Xen.Ex.Graphics;
using Xen.Ex.Graphics.Content;

using Viro.Interfaces;

namespace Viro.Physics
{
    /// <summary>
    /// Helps to combine the physics with the graphics.
    /// </summary>
    public abstract class PhysicObject : IContentOwner, IGameObject
    {

        protected Body body;
        protected CollisionSkin collision;

        protected bool Enabled = true;

        public ModelInstance model;
        //protected ModelInstance collisionModel;
        public string modelName;

        protected Vector3 scale = Vector3.One;

        public int objectID;

#if DEBUGDRAWERENABLED
        VertexPositionColor[] wf;
#endif

        public Body PhysicsBody { get { return body; } }
        public CollisionSkin PhysicsSkin { get { return collision; } }
        public bool isEnabled { get { return Enabled; } set { Enabled = value; } }
        public GeometryBounds BoundingBox
        {
            get
            {
                return model.ModelData.StaticBounds;
            }
        }

        protected static Random random = new Random();

        public Matrix worldMatrix;
        public Matrix orientation;
        public Vector3 position;

        public PhysicObject(ContentRegister content, Vector3 position, String modelContentName)
        {
            
            if (modelContentName != String.Empty)
            {
                this.model = new ModelInstance();
                //this.collisionModel = new ModelInstance();
                this.modelName = modelContentName;
                Enabled = true;
                // content.Add(this); //DO NOT ADD CONTENT HERE. POSITIONS/WORLDMATRIX/ORIENTATION GET COMPLETELY IGNORED
            }
            worldMatrix = Matrix.Identity;
            this.position = position;
            worldMatrix.Translation += position;
            orientation = Matrix.Identity;

            if (modelContentName != String.Empty)
            { content.Add(this); }
        }

        public PhysicObject()
        {
            if (model == null)
            {
                model = new ModelInstance();
            }
            //if (collisionModel == null)
            //{
            //    collisionModel = new ModelInstance();
            //}
            if (modelName == null)
            {
                modelName = "";
            }
            if (worldMatrix != Matrix.Identity)
            {
                worldMatrix = new Matrix();
            }
            if (position == null)
            {
                position = Vector3.Zero;
            }
            if (orientation != Matrix.Identity)
            {
                orientation = Matrix.Identity;
            }
        }

        public virtual void LoadContent(ContentState state)
        {
            if (modelName != String.Empty)
            {
                if (model.ModelData == null)
                {
                    try
                    {
                        model.ModelData = state.Load<Xen.Ex.Graphics.Content.ModelData>(modelName);
                    }
                    catch
                    {
                        model = null;
                    }

                    //try
                    //{
                    //    collisionModel.ModelData = state.Load<ModelData>(modelName + "_col");
                    //}
                    //catch
                    //{
                    //    collisionModel = null;
                    //}
                }
            }

            Quaternion rot = Quaternion.Identity;
            Vector3 junk2 = Vector3.Zero;
            worldMatrix.Decompose(out scale, out rot , out position);
            orientation = Matrix.CreateFromQuaternion(rot);
        }

        public Vector3 SetMass(float mass)
        {
            PrimitiveProperties primitiveProperties =
                new PrimitiveProperties(PrimitiveProperties.MassDistributionEnum.Solid, PrimitiveProperties.MassTypeEnum.Density, mass);

            float junk; Vector3 com; Matrix it, itCoM;

            collision.GetMassProperties(primitiveProperties, out junk, out com, out it, out itCoM);
            body.BodyInertia = itCoM;
            body.Mass = junk;

            return com;
        }

        public Xen.Ex.Material.MaterialLightCollection SetLightCollection
        {
            set { model.LightCollection = value; }
        }

        //public abstract void ApplyEffects(BasicEffect effect);
        public virtual void Draw(DrawState state)
        {
            using (state.WorldMatrix.PushMultiply(ref worldMatrix))
            {
                if (Enabled)
                {
                    if(CullTest(state.Culler))
                        model.Draw(state);
                }
            }

#if DEBUGDRAWERENABLED
            if (Main.debugDrawerToggle)
            {

                wf = collision.GetLocalSkinWireframe();

                // if the collision skin was also added to the body
                // we have to transform the skin wireframe to the body space
                if (body.CollisionSkin != null)
                {
                    body.TransformWireframe(wf);
                }

                Main.debugDrawer.DrawShape(wf);
            }
#endif
        }

        public bool CullTest(ICuller culler)
        {
            return model.CullTest(culler);
        }


        public Vector3 GetPosition()
        {
            return position;
        }

        public double GetDistanceFromObject(Vector3 position)
        {
            double distance = new double();
            distance = Math.Sqrt((this.position.X - position.X) * (this.position.X - position.X) + (this.position.Y - position.Y) * (this.position.Y - position.Y));
            return distance;
        }

        public double GetDistanceFromObjectsHead(Vector3 position)
        {
            double distance = new double();
            if (model != null)
            {
                float tempY = model.ModelData.StaticBounds.Maximum.Y;
                distance = Math.Sqrt((this.position.X - position.X) * (this.position.X - position.X) + ((this.position.Y + tempY) - position.Y) * ((this.position.Y + tempY) - position.Y));
                return distance;
            }
            return distance;
        }

        public GeometryBounds GetBoundingBox()
        {
            GeometryBounds tempBox = model.ModelData.StaticBounds;
            return tempBox;
        }

        public virtual void Update(UpdateState state)
        {
            Vector3 junk = new Vector3();
            Quaternion junkQuat = new Quaternion();

            if (!isEnabled && body.IsBodyEnabled)
            {
                body.DisableBody();
            }

            //Update the objects position variable
            worldMatrix.Decompose(out junk, out junkQuat, out position);

            if (body != null)
            {
                Vector3 temp = body.Position;
                temp.Z = 0;

                if (body.CollisionSkin != null)
                {
                    worldMatrix = Matrix.CreateScale(scale) * orientation * Matrix.CreateTranslation(temp);
                }
                else
                    worldMatrix = Matrix.CreateScale(scale) * orientation * Matrix.CreateTranslation(temp);

                //Quaternion c = new Quaternion();
                //Vector3 t = new Vector3();
                //worldMatrix.Decompose(out t, out c, out t);
                //Console.WriteLine(c.Y);
            }
        }


        public int ObjectID
        {
            get { return objectID; }
        }


        public void SetPosition(Vector3 pos)
        {
            position = pos;
            Matrix.CreateTranslation(ref pos, out worldMatrix);
        }
    }
}
