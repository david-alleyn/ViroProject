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
    public class StaticObject : TriangleMeshObject, IDraw
    {
        public int hpValue = 2;
        public bool isInfected = false;
        public StaticObject(ContentRegister content, Vector3 position, Matrix orientation, string name)
            : base(content, position, orientation, name)
        {

        }

        public StaticObject() : base() { }
    }
}
