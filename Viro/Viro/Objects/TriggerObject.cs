using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Viro.Interfaces;

namespace Viro.Objects
{
    public class Trigger : IGameObject
    {
        Vector3 position = Vector3.Zero;
        protected bool Enabled;
        public List<int> objectsToTrigger;
        public int objectID;

        public Trigger()
        {
            if (objectsToTrigger == null)
            {
                objectsToTrigger = new List<int>();
            }
        }

        public Trigger(List<int> triggerableDynamicObjects)
        {

        }

        public Vector3 GetPosition()
        {
            return position;
        }

        public void SetPosition(Vector3 pos)
        {
            if (pos != null)
            {
                position = pos;
            }
        }

        public double GetDistanceFromObject(Vector3 position)
        {
            double distance = new double();
            distance = Math.Sqrt((this.position.X - position.X) * (this.position.X - position.X) + (this.position.Y - position.Y) * (this.position.Y - position.Y));
            return distance;
        }


        public bool isEnabled
        {
            get
            {
                return Enabled;
            }
            set
            {
                Enabled = value;
            }
        }

        public virtual List<int> GetTriggeredObjectsList()
        {
            //Implement a list of actions
            return objectsToTrigger;
        }


        public int ObjectID
        {
            get { return objectID; }
        }
    }
}
