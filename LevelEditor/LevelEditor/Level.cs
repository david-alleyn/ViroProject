using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Xen;
using Xen.Graphics;
using Xen.Ex.Graphics;
using Xen.Ex.Material;

using System.Xml.Serialization;

using LevelMap;

namespace LevelEditor
{
    public class Level
    {
        public LevelMap.LevelMap map;
        MaterialLightCollection lights;
        List<IMaterialDirectionalLight> direct;
        List<IMaterialPointLight> point;

        List<bool> isObject;

        public Level()
        {
            map = new LevelMap.LevelMap();
            lights = new MaterialLightCollection();
            point = new List<IMaterialPointLight>();
            direct = new List<IMaterialDirectionalLight>();

            lights.AmbientLightColour = new Color(40,40,80).ToVector3();

            isObject = new List<bool>();
        }

        public void Init()
        {
            foreach (LevelMap.Lights l in map.listOfLights)
            {
                switch (l.type)
                {
                    case Lights.LightType.DIRECTIONAL:
                        direct.Add(lights.CreateDirectionalLight(l.direction, new Color(l.lightColor), new Color(l.lightSpecularColour)));
                        break;
                    case Lights.LightType.POINT:
                        {
                            point.Add(lights.CreatePointLight(l.position, l.intensity, new Color(l.lightColor), new Color(l.lightSpecularColour)));
                            point[point.Count - 1].SourceRadius = l.radius;
                        }
                        break;
                }
                l.Init();
            }

            //foreach (LevelMap.LevelObjects l in map.listOfObjects)
            //{
            //    Vector3 temp1, pos;
            //    Quaternion rot;
            //    l.worldMatrix.Decompose(out temp1, out rot, out pos);
            //    l.SetPosition(pos);
            //    l.SetRotation(rot);
            //}
        }

        public void AddObject(LevelMap.LevelObjects obj)
        {
            map.listOfObjects.Add(new LevelMap.LevelObjects(obj));
            isObject.Add(true);
        }

        public void RemoveObject()
        {
            switch (isObject[isObject.Count - 1])
            {
                case true:
                    if (map.listOfObjects.Count != 0)
                    {
                        map.listOfObjects.RemoveAt(map.listOfObjects.Count - 1);
                    }
                    break;
                case false:
                    if (map.listOfLights.Count != 0)
                    {
                        if (map.listOfLights[map.listOfLights.Count - 1].type == Lights.LightType.DIRECTIONAL)
                        {
                            lights.RemoveLight(direct[direct.Count - 1]);
                            direct.RemoveAt(direct.Count - 1);
                        }
                        else
                        {
                            lights.RemoveLight(point[point.Count - 1]);
                            point.RemoveAt(point.Count - 1);
                        }
                         map.listOfLights.RemoveAt(map.listOfLights.Count - 1);
                    }
                    break;
            }
        }

        public void AddLight(LevelMap.Lights obj)
        {
            obj.radius = 20;
            map.listOfLights.Add(new LevelMap.Lights(obj));
            if (obj.type == Lights.LightType.DIRECTIONAL)
            {
                direct.Add(lights.CreateDirectionalLight(obj.direction, new Color(obj.lightColor), new Color(obj.lightSpecularColour)));
            }
            else if (obj.type == Lights.LightType.POINT)
            {
                point.Add(lights.CreatePointLight(obj.position, obj.intensity, new Color(obj.lightColor), new Color(obj.lightSpecularColour)));
                point[point.Count - 1].SourceRadius = obj.radius;
            }
            isObject.Add(false);
        }

        public void Draw(DrawState state)
        {
            foreach (LevelMap.Lights l in map.listOfLights)
                l.Draw(state);
            foreach (LevelMap.LevelObjects m in map.listOfObjects)
                using (state.DrawFlags.Push(new MaterialLightCollectionFlag(lights)))
                {
                     m.Draw(state);
                }
        }

        public bool CullTest(ICuller culler)
        {
            return true;
        }
    }
}
