using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Xen;
using Xen.Graphics;
using Xen.Ex.Graphics;

using System.Xml.Serialization;

namespace LevelMap
{
    public class LevelObjects : IContentOwner
    {
        public enum OBJECTTYPE { PLAYER, MINION, SWITCH, TRIGGER, PORT, STATIC, DOOR, WAYPOINT, MOVABLEPLATFORM, PIPE}
        public Matrix worldMatrix;
        public string modelName;
        public OBJECTTYPE obj;
        public List<int> linkedObjects;
        public Lights light;
        public int objectID;
        public bool enabled;
        public static int lastGivenID;

        ModelInstance model;
        Vector3 position;
        Vector3 rotation;

        public LevelObjects(string name, OBJECTTYPE o)
        {
            rotation = Vector3.Zero;
            worldMatrix = Matrix.Identity;
            modelName = name;
            obj = o;
            linkedObjects = new List<int>();
            model = new ModelInstance();
            lastGivenID++;
            objectID = lastGivenID;
            enabled = true;
        }

        public LevelObjects(OBJECTTYPE o,Vector4 lightSpecularColour, int intensity, Vector4 lightColor)
        {
            rotation = Vector3.Zero;
            worldMatrix = Matrix.Identity;
            modelName = "";
            obj = o;
            linkedObjects = new List<int>();
            model = new ModelInstance();
            lastGivenID++;
            objectID = lastGivenID;
            enabled = true;
        }

        public LevelObjects(LevelObjects m)
        {
            worldMatrix = m.worldMatrix;
            modelName = m.modelName;
            obj = m.obj;
            linkedObjects = m.linkedObjects;
            model = m.model;
            position = m.position;
            light = m.light;
            lastGivenID++;
            objectID = lastGivenID;
            enabled = true;
        }

        public LevelObjects()
        {
            worldMatrix = Matrix.Identity;
            modelName = "";
            linkedObjects = new List<int>();
            model = new ModelInstance();
            lastGivenID++;
            objectID = lastGivenID;
            enabled = true;
        }

        public void ChangePosition(Vector3 pos)
        {
            position += pos;
            Matrix temp = new Matrix();
            Matrix.CreateTranslation(ref pos, out temp);
            worldMatrix *= temp;
        }

        public Vector3 GetPosition
        {
            get { return position; }
        }

        public ModelInstance GetModel()
        {
            return model;
        }

        public void SetScale(float scale)
        {
            worldMatrix *= Matrix.CreateScale(scale);
        }

        public void SetPosition(Vector3 pos)
        {
            position = pos;
            Matrix.CreateTranslation(ref pos, out worldMatrix);
        }

        public void SetRotation(Quaternion q)
        {
            //rotation = q;
            //Vector3 empty = Vector3.Zero;
            //Matrix.CreateTranslation(ref empty, out worldMatrix);
            //worldMatrix *= Matrix.CreateFromQuaternion(rotation);
            //worldMatrix *= Matrix.CreateTranslation(position);
        }

        public void ChangeRotation(Vector3 q)
        {
            rotation += q;
            Vector3 empty = Vector3.Zero;
            Matrix.CreateTranslation(ref empty, out worldMatrix);
            worldMatrix *= Matrix.CreateFromYawPitchRoll(rotation.X, rotation.Y, rotation.Z);
            worldMatrix *= Matrix.CreateTranslation(position);
        }

        public void LoadContent(ContentState state)
        {
            model.ModelData = state.Load<Xen.Ex.Graphics.Content.ModelData>(modelName);
        }

        public void Draw(DrawState state)
        {
            using (state.WorldMatrix.PushMultiply(ref worldMatrix))
            {
                model.Draw(state);
            }
        }
    }
}