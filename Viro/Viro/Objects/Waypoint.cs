using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Viro.Interfaces;
using Microsoft.Xna.Framework;

namespace Viro.Objects
{
    public class Waypoint : IGameObject
    {
        public Vector3 position;
        public bool Enabled;
        public int objectID;

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

        public int ObjectID
        {
            get { return objectID; }
        }

        public void SetPosition(Vector3 pos)
        {
            position = pos;
        }
    }
}
