using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Xen;
using Xen.Graphics;
using Xen.Camera;
using Xen.Ex.Graphics;
using Xen.Ex.Graphics.Content;
using Xen.Ex.Material;

namespace Viro
{
    public class DebugDrawer
    {
        
        BasicEffect basicEffect;
        MaterialShader colorShader;
        List<VertexPositionColor> vertexData;

        public DebugDrawer()
        {
            this.vertexData = new List<VertexPositionColor>();
        }

        public void Initialize()
        {
            
            //basicEffect = new BasicEffect(Main.graphicsDevice.GraphicsDevice);
        }

        public void Draw(DrawState state, Matrix viewMatrix, Matrix projectionMatrix)
        {
            if (vertexData.Count == 0) return;
            if (colorShader == null)
            {
                Effect temp = state.Shader.CurrentEffect;
                basicEffect = new BasicEffect(temp.GraphicsDevice);
                if (basicEffect == null)
                {
                    return;
                }
            }

            this.basicEffect.AmbientLightColor = Vector3.One;
            this.basicEffect.View = viewMatrix;
            this.basicEffect.Projection = projectionMatrix;
            this.basicEffect.VertexColorEnabled = true;

            state.Shader.Set(basicEffect);

            foreach (EffectPass pass in this.basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                state.DrawDynamicVertices(vertexData.ToArray(), PrimitiveType.LineStrip);
            }
            
            //Effect
            vertexData.Clear();

            

            //base.Draw(gameTime);
        }


        #region Alex's addition for Body Renderer

        public void DrawShape(List<Vector3> shape, Color color)
        {
            if (vertexData.Count > 0)
            {
                Vector3 v = vertexData[vertexData.Count - 1].Position;
                vertexData.Add(new VertexPositionColor(v, new Color(0, 0, 0, 0)));
                vertexData.Add(new VertexPositionColor(shape[0], new Color(0, 0, 0, 0)));
            }

            foreach (Vector3 p in shape)
            {
                vertexData.Add(new VertexPositionColor(p, color));
            }
        }

        public void DrawShape(List<Vector3> shape, Color color, bool closed)
        {
            DrawShape(shape, color);

            Vector3 v = shape[0];
            vertexData.Add(new VertexPositionColor(v, color));
        }

        public void DrawShape(List<VertexPositionColor> shape)
        {
            if (vertexData.Count > 0)
            {
                Vector3 v = vertexData[vertexData.Count - 1].Position;
                vertexData.Add(new VertexPositionColor(v, new Color(0, 0, 0, 0)));
                vertexData.Add(new VertexPositionColor(shape[0].Position, new Color(0, 0, 0, 0)));
            }

            foreach (VertexPositionColor vps in shape)
            {
                vertexData.Add(vps);
            }
        }

        public void DrawShape(VertexPositionColor[] shape)
        {
            if (vertexData.Count > 0)
            {
                Vector3 v = vertexData[vertexData.Count - 1].Position;
                vertexData.Add(new VertexPositionColor(v, new Color(0, 0, 0, 0)));
                vertexData.Add(new VertexPositionColor(shape[0].Position, new Color(0, 0, 0, 0)));
            }

            foreach (VertexPositionColor vps in shape)
            {
                vertexData.Add(vps);
            }
        }

        public void DrawShape(List<VertexPositionColor> shape, bool closed)
        {
            DrawShape(shape);

            VertexPositionColor v = shape[0];
            vertexData.Add(v);
        }

        #endregion



    }
}

