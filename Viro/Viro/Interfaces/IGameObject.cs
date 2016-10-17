using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Viro.Interfaces
{
    public interface IGameObject
    {
        Vector3 GetPosition();
        double GetDistanceFromObject(Vector3 position);
        bool isEnabled
        {
            get;
            set;
        }
        int ObjectID
        {
            get;
        }

        void SetPosition(Vector3 pos);

    }
}
