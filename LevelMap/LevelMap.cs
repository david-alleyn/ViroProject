using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Xen.Ex.Graphics;
using Xen;
using Xen.Ex.Material;

using System.Xml;
using System.Xml.Serialization;

namespace LevelMap
{
    public class LevelMap
    {
        public List<LevelObjects> listOfObjects;
        public List<Lights> listOfLights;

        public LevelMap()
        {
            listOfLights = new List<Lights>();
            listOfObjects = new List<LevelObjects>();
        }

        public void Draw(DrawState state)
        {
            foreach (LevelObjects m in listOfObjects)
                m.Draw(state);
        }
    }
}
