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
using Xen.Ex.Material;
using Viro.Shaders;

namespace Viro.Physics
{
    public class TriangleMeshObject : PhysicObject, IContentOwner
    {
        TriangleMesh triangleMesh;
        Texture2D infectedTexture;
        protected static Texture2D noise;

        //Position and orientation must be used during the LoadContent phase for this object type. These are only used once - Dave

        public TriangleMeshObject(ContentRegister content, Vector3 position, Matrix orientation, String modelContentName)
            : base(content, position, modelContentName)
        {
            this.orientation = orientation;
        }

        public TriangleMeshObject()
            : base()
        {

        }

        public override void LoadContent(ContentState state)
        {
            base.LoadContent(state);

            //This must be done in order to ANY possible extraction of model data.
            //Xen is not comfortable in its current state with vertex and index data extration.

            ModelInstance collisionMesh;

            //if (collisionModel == null)
            //{
                collisionMesh = model;
            //}
            //else
            //{
            //    collisionMesh = collisionModel;
            //}

            if (Math.Abs(position.Z) < 5.0f && collisionMesh != null)
            {
                foreach (MeshData modelData in collisionMesh.ModelData.Meshes)
                {
                    foreach (GeometryData geometryData in modelData.Geometry)
                    {
                        geometryData.Vertices.Warm(state);
                        geometryData.Indices.Warm(state);
                    }
                }
                body = new Body();
                collision = new CollisionSkin(null);
                triangleMesh = new TriangleMesh();

                List<Vector3> vertexList = new List<Vector3>();
                List<TriangleVertexIndices> indexList = new List<TriangleVertexIndices>();

                ExtractData(vertexList, indexList, collisionMesh);

                if (triangleMesh == null)
                {
                    triangleMesh = new TriangleMesh();
                }
                if (body == null)
                {
                    body = new Body();
                }
                if (collision == null)
                {
                    collision = new CollisionSkin(null);
                }

                triangleMesh.CreateMesh(vertexList, indexList, 4, 1.0f);
                collision.AddPrimitive(triangleMesh, (int)MaterialTable.MaterialID.NotBouncyNormal);
                PhysicsSystem.CurrentPhysicsSystem.CollisionSystem.AddCollisionSkin(collision);

                //Vector3 com = SetMass(1.0f);

                // Transform
                collision.ApplyLocalTransform(new JigLibX.Math.Transform(position, orientation));
                // we also need to move this dummy, so the object is *rendered* at the correct position

                body.MoveTo(position, orientation);
            }


            infectedTexture = state.Load<Texture2D>("Levels/LevelObjects/1x1_t_infected");
            noise = state.Load<Texture2D>("Noise");
        }

        public override void Update(UpdateState state)
        {
            //base.Update(state);

            if (!isEnabled)
            {
                //PhysicsSystem.CurrentPhysicsSystem.RemoveBody(body);
            }
        }

      

        public void InfectObject()
        {
            InfectedShader infectedShader = new InfectedShader();
            infectedShader.INFECTEDTEXTURE = infectedTexture;
            model.ShaderProvider = infectedShader;
        }

        /// <summary>
        /// Helper Method to get the vertex and index List from the model.
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="indices"></param>
        /// <param name="model"></param>
        public void ExtractData(List<Vector3> vertices, List<TriangleVertexIndices> indices, ModelInstance model)
        {
            Transform[] boneTranforms = null;

            if (model.ModelData.Skeleton != null)
            {
                boneTranforms = new Transform[model.ModelData.Skeleton.BoneCount];
                model.ModelData.Skeleton.BoneWorldTransforms.CopyTo(boneTranforms, 0);
            }

            foreach (MeshData md in model.ModelData.Meshes)
            {
                int offset = vertices.Count;
                foreach (GeometryData gd in md.Geometry)
                {
                    Vector3[] a = new Vector3[gd.Vertices.Count];
                    int stride = gd.Vertices.Stride;

                    //Microsoft.Xna.Framework.Graphics.ModelMeshPart modeltest = new Microsoft.Xna.Framework.Graphics.ModelMeshPart();


                    gd.Vertices.TryExtractVertexData((Microsoft.Xna.Framework.Graphics.VertexElementUsage)0, 0, a);  //VertexBuffer.GetData(gd.VertexOffset * stride, a, 0, gd.NumVertices, stride);

                    Matrix xform = new Matrix();
                    xform = Matrix.Identity;

                    if (model.ModelData.Skeleton != null)
                    {
                        boneTranforms[gd.BoneIndices[0]].GetMatrix(out xform);
                    }


                    for (int i = 0; i != a.Length; ++i)
                        Vector3.Transform(ref a[i], ref xform, out a[i]);
                    vertices.AddRange(a);

                    //if (mm.IndexBuffer.IndexElementSize != IndexElementSize.SixteenBits)      //XNA 4.0 change
                   // if (!gd.Indices.Is16bit)
                   //     throw new Exception(String.Format("Model uses 32-bit indices, which are not supported."));

                    int[] s = new int[gd.Indices.Count];
                    //mm.IndexBuffer.GetData<short>(mmp.StartIndex * 2, s, 0, mmp.PrimitiveCount * 3);      //XNA 4.0 change
                    //gd.IndexBuffer.GetData(gd.StartIndex * 2, s, 0, gd.PrimitiveCount * 3);

                    gd.Indices.ExtractIndexData(s);
                    // WHAT THE FFFFFFF (took forever to find this)

                    JigLibX.Geometry.TriangleVertexIndices[] tvi = new JigLibX.Geometry.TriangleVertexIndices[gd.Indices.Count / 3];
                    for (int i = 0; i != tvi.Length; ++i)
                    {
                        tvi[i].I0 = s[i * 3 + 2] + offset;
                        tvi[i].I1 = s[i * 3 + 1] + offset;
                        tvi[i].I2 = s[i * 3 + 0] + offset;
                    }
                    indices.AddRange(tvi);
                }
            }
        }
    }
}