using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Viro.Interfaces;
using Viro.Physics;
using Xen;

namespace Viro.Objects
{
    public class Switch : DynamicObject, IGameObject, IDraw
    {
        
        public List<int> objectsToTrigger;

        public Switch(ContentRegister content, Vector3 position, Matrix orientation, string name)
            : base(content, position, orientation, name)
        {
            if (objectsToTrigger == null)
            {
                objectsToTrigger = new List<int>();
            }
        }

        public Switch(List<int> triggerableDynamicObjects, ContentRegister content, Vector3 position, Matrix orientation, string name)
            : base(content, position, orientation, name)
        {

        }

        public Switch() : base() { }

        public virtual List<int> GetTriggeredObjectsList()
        {
            //Implement a list of actions
            return objectsToTrigger;
        }
    }
}
