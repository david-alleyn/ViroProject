using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Xen;

namespace Viro.Physics
{
    public class DynamicObject : TriangleMeshObject
    {
        public DynamicObject(ContentRegister content, Vector3 position, Matrix orientation, string name)
            : base(content, position, orientation, name)
        {

        }

        public DynamicObject() : base() { }

        public virtual void Activate()
        {
            
        }

        public override void Update(UpdateState state)
        {
            base.Update(state);
        }
    }
}
