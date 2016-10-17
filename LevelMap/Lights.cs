using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Xen;
using Xen.Graphics;
using Xen.Ex.Graphics;
using Xen.Ex.Material;

using System.Xml.Serialization;

namespace LevelMap
{
    public class Lights
    {
        public enum LightType { POINT, DIRECTIONAL }

        public LightType type;
        public Vector3 position;
        public Vector4 lightSpecularColour;
        public int intensity;
        public Vector4 lightColor;
        public Vector3 direction;
        public int radius;
        LightSourceDrawer lightDrawer;

        public Lights()
        {
            lightDrawer = new LightSourceDrawer(position, new Xen.Ex.Geometry.Sphere(new Vector3(15), 2, true, false, false), Color.White);
        }

        public void Init()
        {
            lightDrawer = new LightSourceDrawer(position, new Xen.Ex.Geometry.Sphere(new Vector3(15), 2, true, false, false), Color.White);
        }

        public Lights(LightType o, Vector4 lightSpecularColour, int intensity, Vector4 lightColor)
        {
            type = o;
            this.lightSpecularColour = lightSpecularColour;
            this.intensity = intensity;
            this.lightColor = lightColor;

            lightDrawer = new LightSourceDrawer(position, new Xen.Ex.Geometry.Sphere(new Vector3(15), 2, true, false, false), Color.White);
        }

        public Lights(LightType o, Vector4 lightSpecularColour, Vector3 direction, Vector4 lightColor)
        {
            type = o;
            this.lightSpecularColour = lightSpecularColour;
            this.direction = direction;
            this.lightColor = lightColor;

            lightDrawer = new LightSourceDrawer(position, new Xen.Ex.Geometry.Sphere(new Vector3(15), 2, true, false, false), Color.White);
        }

        public Lights(Lights l)
        {
            type = l.type;
            position = l.position;
            lightSpecularColour = l.lightSpecularColour;
            intensity = l.intensity;
            lightColor = l.lightColor;
            direction = l.direction;
            radius = l.radius;
            lightDrawer = new LightSourceDrawer(l.GetPosition, l.lightDrawer.GEOMETRY, Color.White);
        }

        public void ChangePosition(Vector3 pos)
        {
            position += pos;
            lightDrawer.POSITION = position;
        }

        public Vector3 GetPosition
        {
            get { return position; }
        }

        public void Draw(DrawState state)
        {
            lightDrawer.Draw(state);
        }
    }

    class LightSourceDrawer
    {
        private IDraw geometry;
        private Vector3 position;
        private Color lightColour;

        public Vector3 POSITION
        {
            get { return position; }
            set { position = value; }
        }

        public IDraw GEOMETRY
        {
            get { return geometry; }
        }

        public LightSourceDrawer(Vector3 position, IDraw geometry, Color lightColour)
        {
            this.position = position;
            this.geometry = geometry;
            this.lightColour = lightColour;
        }

        public void Draw(DrawState state)
        {
            using (state.WorldMatrix.PushTranslateMultiply(ref position))
            {
                DrawSphere(state);
            }
        }

        private void DrawSphere(DrawState state)
        {
            //draw the geometry with a solid colour shader
            if (geometry.CullTest(state))
            {
                Xen.Ex.Shaders.FillSolidColour shader = state.GetShader<Xen.Ex.Shaders.FillSolidColour>();

                shader.FillColour = lightColour.ToVector4();

                using (state.Shader.Push(shader))
                {
                    geometry.Draw(state);
                }
            }
        }

        public bool CullTest(ICuller culler)
        {
            return true;
        }
    }
}
