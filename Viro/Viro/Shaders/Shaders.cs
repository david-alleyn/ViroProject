using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xen;
using Xen.Graphics;
using Microsoft.Xna.Framework.Graphics;
using Xen.Ex.Graphics.Content;
using Xen.Ex.Material;
using Microsoft.Xna.Framework;

namespace Viro.Shaders
{
    public class DisolveShader : Xen.Ex.Graphics.IModelShaderProvider
    {
        static Texture2D noise;
        float alpha;

        //no change to the shader:
        public IShader BeginModel(DrawState state, Xen.Ex.Material.MaterialLightCollection lights)
        {
            return null;
        }
        public void EndModel(DrawState state)
        {
        }

        //return the shader to use:
        public IShader BeginGeometry(DrawState state, GeometryData geometry)
        {
            Viro.Shaders.Disolve.disolve disolve = new Viro.Shaders.Disolve.disolve();
            disolve.DisplayTexture = geometry.MaterialData.Texture;
            disolve.RandomNumber = noise;
            disolve.AlphaChange = alpha;

            return disolve;
        }

        public float ALPHACHANGE
        {
            set { alpha = value; }
        }

        public Texture2D NOISETEXTURE
        {
            set { noise = value; }
        }
    }

    public class DepthShader : Xen.Ex.Graphics.IModelShaderProvider
    {
        Xen.Ex.Shaders.DepthOutRg depth = new Xen.Ex.Shaders.DepthOutRg();
        //Shaders.Depth.DepthMapShader depth = new Depth.DepthMapShader();

        public DepthShader()
            : base()
        {
        }
    
        public IShader BeginModel(DrawState state, MaterialLightCollection lights)
        {
            return null;
        }
        public void EndModel(DrawState state)
        {
        }
    
        //return the shader to use:
        public IShader BeginGeometry(DrawState state, GeometryData geometry)
        {
            return depth;
        }
    }

    public class GlowShader : Xen.Ex.Graphics.IModelShaderProvider
    {
        Viro.Shaders.Laser_shader.laserbolt_technique laser = new Viro.Shaders.Laser_shader.laserbolt_technique();
        float pulse;
        float pulseChange;
        bool increase;
        public GlowShader()
            : base()
        {
            pulse = 0.2f;
            Microsoft.Xna.Framework.Vector4 color = Microsoft.Xna.Framework.Color.Black.ToVector4();
            laser.SetLaser_bolt_color(ref color);
            Microsoft.Xna.Framework.Vector3 temp = new Microsoft.Xna.Framework.Vector3(1.0f, 1.0f, 1.0f);
            laser.SetCenter_to_viewer(ref temp);
            Random rand = new Random();
            pulseChange = (float)rand.Next(0, 75) / 1000.0f;
        }

        public Color COLOR
        {
            set 
            {
                Microsoft.Xna.Framework.Vector4 color = value.ToVector4();
                laser.SetLaser_bolt_color(ref color);
            }
        }

        public IShader BeginModel(DrawState state, MaterialLightCollection lights)
        {
            return null;
        }
        public void EndModel(DrawState state)
        {
        }

        //return the shader to use:
        public IShader BeginGeometry(DrawState state, GeometryData geometry)
        {
            if (increase)
            {
                pulse += pulseChange;
                if (pulse >= 1.0f + pulseChange)
                    increase = false;
            }
            else
            {
                pulse -= pulseChange;
                if (pulse <= 0.0f + pulseChange)
                    increase = true;
            }
            laser.Pulse = pulse;
            return laser;
        }
    }

    public class InfectedShader : Xen.Ex.Graphics.IModelShaderProvider
    {
        Texture2D infectedTexture;
        //no change to the shader:
        public IShader BeginModel(DrawState state, MaterialLightCollection lights)
        {
            return null;
        }
        public void EndModel(DrawState state)
        {
        }

        //return the shader to use:
        public IShader BeginGeometry(DrawState state, GeometryData geometry)
        {
            Viro.Shaders.Infection.infect infection = new Viro.Shaders.Infection.infect();
            infection.DisplayTexture = geometry.MaterialData.Texture;
            infection.InfectedTexture = infectedTexture;

            return infection;
        }

        public Texture2D INFECTEDTEXTURE
        {
            set { infectedTexture = value; }
        }
    }
}
