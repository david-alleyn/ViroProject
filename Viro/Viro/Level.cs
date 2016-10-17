using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#if WINDOWS
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
#endif

using Xen;
using Xen.Graphics;
using Xen.Ex.Graphics2D;
using Xen.Camera;
using Xen.Ex.Material;
using Xen.Ex.Graphics;


using Viro.Actors;
using Viro.Physics;
using Viro.Objects;
using Viro.Interfaces;
using Viro.Objects.Physics_Stuff;

using JigLibX.Physics;
using JigLibX.Collision;
using JigLibX.Geometry;
using JigLibX.Math;
using JigLibX.Utils;
using JigLibX.Vehicles;

using LevelMap;
using System.IO;
using Xen.Input.State;

namespace Viro
{
    public class Level : IContentOwner, IUpdate, IDraw
    {
        public DrawTargetTexture2D drawTexture;
        public DrawTargetTexture2D intermediateTexture;
        public DrawTargetTexture2D depthTexture;
        public DrawTargetTexture2D bloomTexture;
        public DrawTargetTexture2D combinedBloomTexture;

        public bool renderDepth = false;
        float cameraRotation = 0.0f;
        Camera3D camera;
        GameMenu inGameMenu;
        string levelName;
        public int reCycle = 0;
        public int portRecycle = 0;
        float timeStep = 0.0166f; // avg time for a 60hz frame

        public Player player;
        public List<Vector3> SpawnPoints;
        public List<Vector3> SpawnTriggers;

        TextElement avgFps;
        HUD hud;

        List<NPC> npcList;
        List<StaticObject> staticObjects;
        List<DynamicObject> dynamicObjects;
        List<DoorObject> doorObjects;
        List<Trigger> triggerObjects;
        List<Switch> switchObjects;
        List<Port> portObjects;
        List<Pipe> pipeObjects;
        List<Waypoint> waypointsObjects;
        List<MovablePlatform> platformObjects;
        Background backGround;
        PhysicsSystem physicSystem;
        ConstraintWorldPoint objectController = new ConstraintWorldPoint();
        ConstraintVelocity damperController = new ConstraintVelocity();

        MaterialLightCollection lights;
        IMaterialPointLight playerFollowLight;

        ContentRegister contentRegister;

        Storyboard storyboard;
        public int windowHeight;
        public int windowWidth;

#if DEBUG
        private Xen.Ex.Graphics2D.Statistics.DrawStatisticsDisplay stats;

#endif
        public int currentSpawnPointNum = 0;
        public float distanceOffset = 0;
        public Level(ref DrawTargetScreen screen, ref ContentRegister content, UpdateManager updateManager, string levelName, int width, int height)
        {
            contentRegister = content;
            this.levelName = levelName;
            physicSystem = new PhysicsSystem();
            physicSystem.CollisionSystem = new CollisionSystemSAP();

            physicSystem.EnableFreezing = true;
            physicSystem.SolverType = PhysicsSystem.Solver.Normal;
            physicSystem.CollisionSystem.UseSweepTests = true;

            physicSystem.NumCollisionIterations = 6;
            physicSystem.NumContactIterations = 6;
            physicSystem.NumPenetrationRelaxtionTimesteps = 6;
            physicSystem.Gravity = physicSystem.Gravity * 150;

#if !XBOX360
            DisplayMode mode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
            camera = new Camera3D();
            camera.LookAt(new Vector3(0, 40, 0), new Vector3(0, 45, 1000), new Vector3(0, 1, 0));
            camera.Projection.FieldOfView = (float)0.7853982;
            camera.Projection.FarClip = 5000;
            screen = new DrawTargetScreen(camera);
            screen.ClearBuffer.ClearColour = Color.Chocolate;
#else
            camera = new Camera3D();
            camera.LookAt(new Vector3(0, 40, 0), new Vector3(0, 45, 1000), new Vector3(0, 1, 0));
            camera.Projection.FieldOfView = (float)0.7853982;
            camera.Projection.FarClip = 10000;
            screen = new DrawTargetScreen(camera);
            screen.ClearBuffer.ClearColour = Color.Chocolate;
#endif      
            intermediateTexture = new DrawTargetTexture2D(camera, width, height, SurfaceFormat.Color, DepthFormat.Depth24Stencil8, true, PreferredMultiSampleLevel.FourSamples);
            depthTexture = new DrawTargetTexture2D(camera, width, height, SurfaceFormat.Color, DepthFormat.Depth24Stencil8, true, PreferredMultiSampleLevel.FourSamples);
            drawTexture = new DrawTargetTexture2D(camera, width, height, SurfaceFormat.Color, DepthFormat.Depth24Stencil8, true, PreferredMultiSampleLevel.FourSamples);
            bloomTexture = new DrawTargetTexture2D(camera, width, height, SurfaceFormat.Color, DepthFormat.Depth24Stencil8, true, PreferredMultiSampleLevel.FourSamples);
            combinedBloomTexture = new DrawTargetTexture2D(camera, width, height, SurfaceFormat.Color, DepthFormat.Depth24Stencil8, true, PreferredMultiSampleLevel.FourSamples);
            drawTexture.ClearBuffer.ClearColour = Color.AliceBlue;
            drawTexture.Add(this);
            depthTexture.Add(this);

            inGameMenu = new GameMenu();

            pipeObjects = new List<Pipe>();
            backGround = new Background();
            staticObjects = new List<StaticObject>();
            dynamicObjects = new List<DynamicObject>();
            doorObjects = new List<DoorObject>();
            triggerObjects = new List<Trigger>();
            switchObjects = new List<Switch>();
            portObjects = new List<Port>();
            waypointsObjects = new List<Waypoint>();
            npcList = new List<NPC>();
            platformObjects = new List<MovablePlatform>();
            player = new Player();
            player.InitTendrils(content);
            hud = new HUD(new Vector2(0.03f, 0.08f), "HealthBar1", "HealthBar2", "HealthBar3", "HealthBar4", "HealthBar5", "HealthBar6", "HealthBar7", "HealthBar8", "HealthBar9", "HealthBar10", "Lives");
            SpawnPoints = new List<Vector3>();
            SpawnTriggers = new List<Vector3>();

            lights = new MaterialLightCollection();
            lights.AmbientLightColour = new Vector3(1.0f, 1.0f, 1.0f);

            
#if DEBUG
            stats = new Xen.Ex.Graphics2D.Statistics.DrawStatisticsDisplay(updateManager);
            screen.Add(stats);
#endif
            content.Add(this);

            InitSpawns(SpawnPoints, SpawnTriggers);

            foreach (StaticObject s in staticObjects)
            {
                content.Add(s);
                if (!s.isEnabled && s.PhysicsBody != null)
                {
                    PhysicsSystem.CurrentPhysicsSystem.RemoveBody(s.PhysicsBody);
                }
            }
            foreach (Pipe s in pipeObjects)
            {
                content.Add(s);
            }
            foreach (DynamicObject s in dynamicObjects)
            {
                content.Add(s);
            }
            foreach (DoorObject s in doorObjects)
            {
                s.init(updateManager);
                content.Add(s);
            }
            foreach (Switch s in switchObjects)
            {
                content.Add(s);
            }
            foreach (Port s in portObjects)
            {
                content.Add(s);
            }
            foreach (NPC s in npcList)
            {
                s.Lives = 0;
                content.Add(s);
                s.init();
            }
            foreach (MovablePlatform s in platformObjects)
            {
                content.Add(s);
            }


            content.Add(player);
            content.Add(backGround);

            //backGround.GetTexture(0).AlphaBlendState = AlphaBlendState.Alpha;
            backGround.GetTexture(1).AlphaBlendState = AlphaBlendState.Alpha;
            backGround.GetTexture(2).AlphaBlendState = AlphaBlendState.Alpha;

            //set sizes
            backGround.GetTexture(1).Size = new Vector2(3.0f);
            backGround.GetTexture(2).Size = new Vector2(3.0f);

            content.Add(hud);
            screen.Add(hud);
        }

        public Level()
        {
            staticObjects = new List<StaticObject>();
            dynamicObjects = new List<DynamicObject>();
            triggerObjects = new List<Trigger>();
            switchObjects = new List<Switch>();
            portObjects = new List<Port>();
            waypointsObjects = new List<Waypoint>();
            platformObjects = new List<MovablePlatform>();
        }

        public virtual void LoadContent(ContentState state)
        {
#if DEBUG
            this.stats.Font = state.Load<SpriteFont>("Font/Arial");
#endif
            LevelMap.LevelMap streamTemp = state.Load<LevelMap.LevelMap>("Levels/" + levelName);

            backGround.AddTexture("Levels/background");
            backGround.AddTexture("Levels/middleground");
            backGround.AddTexture("Levels/foreground");

            avgFps = new TextElement();
            avgFps.Position = new Vector2(110.0f, -110.0f);
            avgFps.Font = state.Load<SpriteFont>(@"Font/Arial");

            foreach (LevelMap.LevelObjects l in streamTemp.listOfObjects)
            {
                Vector3 garbage = Vector3.Zero;
                Quaternion garbagequat = Quaternion.Identity;
                switch (l.obj)
                {
                    case LevelMap.LevelObjects.OBJECTTYPE.STATIC:
                        StaticObject newStatic = new StaticObject();
                        newStatic.worldMatrix = l.worldMatrix;
                        newStatic.modelName = l.modelName;
                        newStatic.objectID = l.objectID;
                        newStatic.isEnabled = l.enabled;
                        this.staticObjects.Add(newStatic);
                        break;
                    case LevelMap.LevelObjects.OBJECTTYPE.MINION:
                        NPC newNPC = new NPC();
                        newNPC.worldMatrix = l.worldMatrix;
                        newNPC.modelName = l.modelName;
                        newNPC.objectID = l.objectID;
                        this.npcList.Add(newNPC);
                        break;
                    case LevelMap.LevelObjects.OBJECTTYPE.PORT:
                        Port newPort = new Port();
                        Vector3 portPosition = Vector3.Zero;
                        Quaternion portRot = Quaternion.Identity;
                        l.worldMatrix.Decompose(out garbage, out portRot, out portPosition);
                        newPort.modelName = l.modelName;
                        newPort.worldMatrix = l.worldMatrix;
                        newPort.SetPosition(portPosition);
                        newPort.isEnabled = l.enabled;
                        newPort.objectsToTrigger = l.linkedObjects;
                        newPort.objectID = l.objectID;
                        this.portObjects.Add(newPort);
                        break;
                    case LevelMap.LevelObjects.OBJECTTYPE.SWITCH:
                        Switch newSwitch = new Switch();
                        Vector3 switchPosition = Vector3.Zero;
                        Quaternion switchRot = Quaternion.Identity;
                        l.worldMatrix.Decompose(out garbage, out switchRot, out switchPosition);
                        newSwitch.modelName = l.modelName;
                        newSwitch.worldMatrix = l.worldMatrix;
                        newSwitch.SetPosition(switchPosition);
                        newSwitch.isEnabled = true;
                        newSwitch.objectsToTrigger = l.linkedObjects;
                        newSwitch.objectID = l.objectID;
                        break;
                    case LevelMap.LevelObjects.OBJECTTYPE.TRIGGER:
                        Trigger newTrigger = new Trigger();
                        Vector3 triggerPosition = Vector3.Zero;
                        l.worldMatrix.Decompose(out garbage, out garbagequat, out triggerPosition);
                        newTrigger.SetPosition(triggerPosition);
                        newTrigger.isEnabled = true;
                        newTrigger.objectsToTrigger = l.linkedObjects;
                        newTrigger.objectID = l.objectID;
                        triggerObjects.Add(newTrigger);
                        break;
                    case LevelMap.LevelObjects.OBJECTTYPE.WAYPOINT:
                        Waypoint newWaypoint = new Waypoint();
                        Vector3 waypointPosition;
                        l.worldMatrix.Decompose(out garbage, out garbagequat, out waypointPosition);
                        newWaypoint.SetPosition(waypointPosition);
                        newWaypoint.isEnabled = l.enabled;
                        newWaypoint.objectID = l.objectID;
                        waypointsObjects.Add(newWaypoint);
                        break;
                    case LevelMap.LevelObjects.OBJECTTYPE.PLAYER:
                        player.worldMatrix = l.worldMatrix;
                        player.modelName = l.modelName;
                        break;
                    case LevelMap.LevelObjects.OBJECTTYPE.DOOR:
                        DoorObject newDoor = new DoorObject();
                        newDoor.worldMatrix = l.worldMatrix;
                        newDoor.modelName = l.modelName;
                        newDoor.objectID = l.objectID;
                        doorObjects.Add(newDoor);
                        break;
                    case LevelMap.LevelObjects.OBJECTTYPE.MOVABLEPLATFORM://considering making an if statement for vertical or horisontal MPs
                        MovablePlatform newPlatform = new MovablePlatform();
                        newPlatform.worldMatrix = l.worldMatrix;
                        newPlatform.modelName = l.modelName;
                        newPlatform.objectID = l.objectID;
                        newPlatform.isEnabled = true;
                        this.platformObjects.Add(newPlatform);
                        break;
                    case LevelObjects.OBJECTTYPE.PIPE:
                        Pipe newPipe = new Pipe();
                        newPipe.worldMatrix = l.worldMatrix;
                        newPipe.modelName = l.modelName;
                        newPipe.objectID = l.objectID;
                        pipeObjects.Add(newPipe);
                        break;
                    default:
                        break;
                }
            }

            foreach (LevelMap.Lights l in streamTemp.listOfLights)
            {
                switch (l.type)
                {
                    case Lights.LightType.DIRECTIONAL:
                        lights.CreateDirectionalLight(l.direction, new Color(l.lightColor), new Color(l.lightSpecularColour));
                        break;
                    case Lights.LightType.POINT:
                        lights.CreatePointLight(l.position, l.intensity, new Color(l.lightColor), new Color(l.lightSpecularColour)).SourceRadius = l.radius;
                        break;
                    default:
                        break;
                }
            }

            playerFollowLight = lights.CreatePointLight(new Vector3(0, 0, 0), 25, new Color(25, 25, 25, 0), new Color(50, 50, 50, 100));
            lights.RemoveLight(playerFollowLight);
            playerFollowLight.SourceRadius = 300;
            lights.AddLight(playerFollowLight);
        }

        //public void Initialize(ref DrawTargetScreen screen, ContentRegister content, UpdateManager updateManager, string levelName)
        //{
        //    physicSystem = new PhysicsSystem();
        //    physicSystem.CollisionSystem = new CollisionSystemSAP();
        //
        //    physicSystem.EnableFreezing = true;
        //    physicSystem.SolverType = PhysicsSystem.Solver.Normal;
        //    physicSystem.CollisionSystem.UseSweepTests = true;
        //
        //    physicSystem.NumCollisionIterations = 4;
        //    physicSystem.NumContactIterations = 6;
        //    physicSystem.NumPenetrationRelaxtionTimesteps = 4;
        //    physicSystem.Gravity = physicSystem.Gravity * 10;
        //
        //    //camera = new Camera3D();
        //    camera.LookAt(new Vector3(0, 40, 0), new Vector3(0, 45, 1000), new Vector3(0, 1, 0));
        //    camera.Projection.FieldOfView = (float)0.7853982;
        //    camera.Projection.FarClip = 10000;
        //    screen = new DrawTargetScreen(camera);
        //    screen.ClearBuffer.ClearColour = Color.Chocolate;
        //
        //    foreach (StaticObject s in staticObjects)
        //        content.Add(s);
        //    foreach (DynamicObject s in dynamicObjects)
        //        content.Add(s);
        //    foreach (NPC s in npcList)
        //    {
        //        content.Add(s);
        //        s.init();
        //    }
        //    //foreach (TriggerObject s in triggerObjects)
        //    //    content.Add(s);
        //
        //    content.Add(player);
        //
        //    content.Add(backGround);
        //
        //    screen.Add(this);
        //}

        public UpdateFrequency  Update(UpdateState state)
        {
            player.Update(state);
            hud.playerhealth = player.health;
            hud.playerLives = player.Lives;
            hud.playerAntiGrav = player.AntiGravPower;
            hud.Update();

            //lights.RemoveLight(playerFollowLight);
            playerFollowLight.Position = player.position + new Vector3(0, 110, 80);
            //lights.AddLight(playerFollowLight);

            //Fixing later sry tegan
            // Tegan: Background scrolling here. You can change the speed, as well as the position
            //backGround.GetTexture(0).Position = new Vector2(-player.position.X / 20, -player.position.Y / 20); //background
            backGround.GetTexture(1).Position = new Vector2((-player.position.X / 70000)-1, (-player.position.Y / 70000)-1); //speed: smaller the number the faster it moves
            backGround.GetTexture(2).Position = new Vector2((-player.position.X / 10000)-1, (-player.position.Y / 10000)-1); //position: negative #is down/to the left

            //backGround.GetTexture(1).Position = new Vector2((-player.position.X / 7) - 1000, -player.position.Y / 7 - 1200); //speed: smaller the number the faster it moves
            //backGround.GetTexture(2).Position = new Vector2((-player.position.X / 3) - 1000, -player.position.Y / 3 - 1200); //position: negative #is down/to the left

            if (staticObjects.Count > 0)
                foreach (StaticObject s in staticObjects)
                    s.Update(state);

            if (portObjects.Count > 0)
                foreach (Port p in portObjects)
                    p.Update(state);

            if (doorObjects.Count > 0)
                foreach (DoorObject p in doorObjects)
                    p.Update(state);

            if (switchObjects.Count > 0)
                foreach (Switch s in switchObjects)
                    s.Update(state);

            if (dynamicObjects.Count > 0)
                foreach (DynamicObject d in dynamicObjects)
                    d.Update(state);

            if (npcList.Count > 0)
            {
                NPC.setPlayer(ref player);
                for (int i = 0; i < npcList.Count; i++)
                {
                    npcList[i].Update(state);
                    if (npcList[i].AlphaChange >= 1.0f)
                    {
                        contentRegister.Remove(npcList[i]);
                        npcList.RemoveAt(i);
                    }
                }
            }

            //THESE GET UPDATED INSIDE HandleMovablePlatforms(..);
            //if (platformObjects.Count > 0)
            //    foreach (MovablePlatform d in platformObjects)
            //        d.Update(state);

            HandleMovablePlatforms(state);

            HandlePlayerDamageByProximityToNPCs(state);

            HandleNPCMovement(state);

            HandlePlayerTriggerInteractions(state);

            HandlePlayerPortInteractions(state);

            HandlePlayerAttacks(state);

            HandleSpawnPoints(state);

            HandleFallingToYourDeath(state);

            UpdateCamera(state);

            if (timeStep < 1.0f / 60.0f)
                physicSystem.Integrate(timeStep);
            else physicSystem.Integrate(1.0f / 60.0f);
            timeStep = (float)state.DeltaTimeSeconds;

            return UpdateFrequency.FullUpdate60hz;
        }

        private void HandleNPCMovement(UpdateState state)
        {
            foreach (NPC n in npcList)
            {
                if (n.IWantAggression == true)
                {
                    if (n.GetDistanceFromObject(player.position) <= 200.0f)//change value for Enrage range
                    { n.bEnraged = true; }
                    if (n.GetDistanceFromObject(n.OldPosition) >= n.chaseDistance)
                    { n.bEnraged = false; n.bReset = true; }  
                }
            }
            if (waypointsObjects != null)
            {
                foreach (Waypoint w in waypointsObjects)
                {
                    foreach (NPC n in npcList)
                    {
                        //if npc s is within distance from waypoint
                        if (n.GetDistanceFromObject(w.GetPosition()) <= 30.0f && w.isEnabled)
                        {
                            if (n.bEnraged == false)
                            {
                                n.ChangeDirection();
                            }
                            n.Update(state);
                        }
                    }
                }
            }
        }

        private void HandlePlayerAttacks(UpdateState state)
        {
            if (npcList != null)
            {
                NPC closestNPC = null;

                
//#if XBOX360
                //InputState playerInput = state.PlayerInput[PlayerIndex.One].InputState;
                //if(playerInput.Triggers.RightTrigger > 0.1f || playerInput.Triggers.LeftTrigger > 0.1f)
                //{
//#else
                //if (state.KeyboardState.KeyState.D.OnPressed || reCycle > 0)
                //{
//#endif
                    if (reCycle > 0)
                    { reCycle--; }

                    double prevDistanceToPlayer = 0;
                    foreach (NPC n in npcList)
                    {
                        if (closestNPC != null && !n.IsDead)
                        {
                            double newDistanceToPlayer = n.GetDistanceFromObjectsHead(player.position);
                            if (newDistanceToPlayer < prevDistanceToPlayer)
                            {
                                closestNPC = n;
                                prevDistanceToPlayer = newDistanceToPlayer;
                            }
                        }
                        else if (!n.IsDead)
                        {
                            prevDistanceToPlayer = n.GetDistanceFromObjectsHead(player.position);
                            closestNPC = n;
                        }
                    }
                    if (closestNPC != null && prevDistanceToPlayer <= 125.0f)
                    {
                        if (player.GetBoundingBox().Maximum.X > closestNPC.GetBoundingBox().Minimum.X
                            && player.GetBoundingBox().Minimum.X < closestNPC.GetBoundingBox().Maximum.X
                            && player.GetBoundingBox().Maximum.Y > closestNPC.GetBoundingBox().Maximum.Y
                            && player.GetBoundingBox().Maximum.Y < closestNPC.GetBoundingBox().Maximum.Y + 125)
                        {
                            player.StopAnimation();
                            player.AttackAnimation();
                            reCycle++;//this fixes a bug with the tendril attack
                            player.closestNPC = closestNPC;//gives the player the position of the closestNPC for the tendrils
                            npcList[npcList.IndexOf(closestNPC)].TakeDamage(player.AttackPower);
                        }
                    }
                    else
                    {
                        player.closestNPC = null;
                    }
                //}
            }
        }

        private void HandlePlayerPortInteractions(UpdateState state) // Infection Mechanic
        {
            if (portRecycle == 0)
            {
                player.closestNPC = null;
            }

            if (portObjects != null)
            {
#if XBOX360
                InputState playerInput = state.PlayerInput[PlayerIndex.One].InputState;
                if(playerInput.Buttons.X.OnPressed)
                {
#else
                if (state.KeyboardState.KeyState.F.OnPressed || state.PlayerInput[0].InputState.Buttons.X.OnPressed || portRecycle > 0 )
                {
#endif
                    if (portRecycle > 0)
                    { portRecycle--; }
                    ///////////////////
                    storyboard = new Storyboard(new Vector2(0, 0), new Vector2(windowWidth, windowHeight), "ViroPosterFinal", 2);

                    List<int> staticObjectsToEnable = null;

                    if (player.timeSinceTendrilToPortInteraction >= player.minTimeBetweenTTPIChange)
                    {

                        foreach (Port s in portObjects)
                        {
                            //if port s is within distance from player
                            if (s.GetDistanceFromObject(player.GetPosition()) <= 150.0f && s.isEnabled)
                            {
                                NPC temp = new NPC();
                                temp.position = s.position;
                                player.closestNPC = temp;
                                portRecycle = 2;
                                player.attackingPort = true;
                                player.Update(state);
                                player.closestNPC = null;
                                player.Update(state);
                                player.health += 30;
                                if (player.health > 100)
                                    player.health = 100;
                                if (s.GetTriggeredObjectsList().Count > 0)
                                {
                                    staticObjectsToEnable = s.GetTriggeredObjectsList();
                                    break;
                                }
                            }
                        }
                    }

                    if (staticObjectsToEnable != null && staticObjectsToEnable.Count > 0)
                    {
                        //player.ReverseGravity();
                        foreach (int i in staticObjectsToEnable)
                        {
                            foreach (StaticObject d in staticObjects)
                            {
                                if (d.ObjectID == i && !d.isEnabled)
                                {
                                    d.isEnabled = true;
                                    if (d.PhysicsBody != null)
                                    {
                                        PhysicsSystem.CurrentPhysicsSystem.AddBody(d.PhysicsBody);
                                    }
                                    d.InfectObject();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void HandlePlayerTriggerInteractions(UpdateState state)
        {
            if (triggerObjects != null)
            {
                List<int> dynamicObjectsToTrigger = new List<int>();

                foreach (Trigger s in triggerObjects)
                {
                    //if npc s is within distance from player
                    if (s.GetDistanceFromObject(player.GetPosition()) <= 80.0f && s.isEnabled)
                    {
                        if (s.GetTriggeredObjectsList().Count > 0)
                        {
                            dynamicObjectsToTrigger = s.GetTriggeredObjectsList();
                            break;
                        }
                    }
                }
                foreach (int i in dynamicObjectsToTrigger)
                {
                    foreach (DoorObject d in doorObjects)
                    {
                        if (d.ObjectID == i)
                        {
                            d.Activate();
                        }
                    }
                }
            }
        }

        private void HandleMovablePlatforms(UpdateState state)
        {
            if (platformObjects.Count > 0)
            {
                for (int i = 0; i < platformObjects.Count; i++)
                {
                    //Handle player being pushed along with the platform.
                    platformObjects[i].player = player;
                    
                    if (player.position.X + 15.0f > platformObjects[i].position.X && player.position.X - 15.0f < platformObjects[i].position.X)
                    { distanceOffset = 0; }
                    else if (player.position.X + 30.0f > platformObjects[i].position.X && player.position.X - 30.0f < platformObjects[i].position.X)
                    { distanceOffset = 15; }
                    else if (player.position.X + 60.0f > platformObjects[i].position.X && player.position.X - 60.0f < platformObjects[i].position.X)
                    { distanceOffset = 30; }
                    else
                    { distanceOffset = 0.0f; }

                    if (platformObjects[i].GetDistanceFromObjectsHead(player.position) <= 5.0f + distanceOffset)
                    {
                        player.Body.maxActorSpeed = 325.0f;
                        player.Body.actorAcceleration = 0.0f;
                        platformObjects[i].player.onMP = true;
                        platformObjects[i].hasPlayer = true;
                        platformObjects[i].Update(state);
                        player = platformObjects[i].player;
                    }
                    else
                    {
                        player.Body.maxActorSpeed = 500.0f;
                        player.Body.actorAcceleration = 300.0f;
                        player.onMP = false;
                        platformObjects[i].hasPlayer = false;
                        platformObjects[i].Update(state);
                    }
                }
            }

            foreach (Waypoint w in waypointsObjects)
            {
                foreach (MovablePlatform n in platformObjects)
                {
                    //if npc s is within distance from waypoint
                    if (n.GetDistanceFromObject(w.GetPosition()) <= 30.0f && w.isEnabled)
                    {
                        n.ChangeDirection();
                    }
                }
            }
        }

        public void HandleSpawnPoints(UpdateState state)
        {
            //for (int i = 0; i < SpawnTriggers.Count; i++)
            //{
            //    if (player.GetDistanceFromObject(SpawnTriggers[i]) <= 150.0f)
            //    {
            //        currentSpawnPointNum = i + 1;
            //    }
            //}
            player.currentSpawnPoint = SpawnPoints[currentSpawnPointNum];
        }

        public void HandleFallingToYourDeath(UpdateState state)
        {
            if (player.position.Y < -7000)
            {
                Vector3 com = player.SetMass(10.0f);
                player.Body.DisableBody();
                player.Body.AllowFreezing = true;
                player.Body.Immovable = true;
                player.Body.MoveTo(player.currentSpawnPoint + com, player.orientation);
                player.Body.SetBodyInvInertia(0.0f, 0.0f, 0.0f);
                player.Body.AllowFreezing = false;
                player.Body.Immovable = false;
                player.Body.EnableBody();
            }
        }

        private void InfectObjects()
        {
            SoundManager.Sound.PlaySound("Misc16");
            foreach (StaticObject stat in staticObjects)
            {
                if (stat.GetDistanceFromObject(player.GetPosition()) < 400.0f && stat.isInfected == false)
                {
                    if (player.health < 100) { player.health += stat.hpValue; }
                    if (player.health > 100) { player.health = 100; }
                    stat.isInfected = true;
                    stat.InfectObject();
                    hud.playerhealth = player.health;
                }
            }
        }

        public void InfectMP()
        {
            for (int i = 0; i < platformObjects.Count; i++)
            {
                if (platformObjects[i].GetDistanceFromObjectsHead(player.position) <= 100.0f)
                {
                    if (platformObjects[i].bMoving) { platformObjects[i].bMoving = false; }
                    else if (!platformObjects[i].bMoving) { platformObjects[i].bMoving = true; }
                }
            }
        }

        private void HandlePlayerDamageByProximityToNPCs(UpdateState state)
        {
            //List<IGameObject> objectDistances = new List<IGameObject>();
            foreach (NPC s in npcList)
            {
                //if npc s is within distance from player
                if (s.GetDistanceFromObject(player.GetPosition()) <= (s.BoundingBox.Radius * 1.5) && !s.IsDead)
                {
                    player.TakeDamage(s.AttackPower);
                }
            }

#if WINDOWS
            if (state.KeyboardState.KeyState.I.OnPressed || state.PlayerInput[0].InputState.Buttons.Y.OnPressed)
            {
                Thread infect = new Thread(new ThreadStart(InfectObjects));
                infect.Start();
                InfectMP();
            }

            if (state.KeyboardState.KeyState.U.OnPressed)
            {
                player.ReverseGravity();
            }

            if (state.KeyboardState.KeyState.R.OnPressed)
            {
                player.QuadRun();
            }
#else
            if (state.PlayerInput[PlayerIndex.One].InputState.Buttons.X.OnPressed)
            {
                Thread infect = new Thread(new ThreadStart(InfectObjects));
                infect.Start();
            }
#endif
        }

        private void HandleNodeInteractions()
        {

        }

        public void UpdateCamera(UpdateState state)
        {
            Vector3 playerPosition = Vector3.Zero;
            Vector3 p = Vector3.Zero;
            Quaternion t = new Quaternion();

            player.worldMatrix.Decompose(out p, out t, out playerPosition);

            Vector3 cameraOffset = new Vector3(300, 150, 0);

            playerPosition.Z = camera.Position.Z;
            camera.Position = playerPosition + cameraOffset;

            /*if (((ActorBody)player.PhysicsBody).upsideDown)
            {
                //junk.Z = (float)Math.Atan(2*((rotation.W * rotation.X) + (rotation.Y*rotation.Z))/((rotation.W * rotation.W)-(rotation.X * rotation.X)-(rotation.Y * rotation.Y)-(rotation.Z * rotation.Z)));
                Matrix g = camera.CameraMatrix * Matrix.CreateRotationZ(MathHelper.ToRadians(180));
                if (cameraRotation < MathHelper.ToRadians(180))
                {
                    camera.CameraMatrix *= Matrix.CreateRotationZ(MathHelper.ToRadians(2.0f));
                    cameraRotation += MathHelper.ToRadians(2.0f);
                }
            }*/
        }

        public void Draw(DrawState state)
        {
            if (renderDepth)
            {
                backGround.Draw(state);
                IModelShaderProvider temp;
                Shaders.DepthShader depthShader = new Shaders.DepthShader();
                //using (state.DrawFlags.Push(new MaterialLightCollectionFlag(lights)))
                {
                    foreach (StaticObject s in staticObjects)
                    {
                        temp = s.model.ShaderProvider;
                        s.model.ShaderProvider = depthShader;
                        s.Draw(state);
                        s.model.ShaderProvider = temp;
                    }

                    foreach (DynamicObject s in dynamicObjects)
                    {
                        temp = s.model.ShaderProvider;
                        s.model.ShaderProvider = depthShader;
                        s.Draw(state);
                        s.model.ShaderProvider = temp;
                    }

                    foreach (DoorObject s in doorObjects)
                    {
                        temp = s.model.ShaderProvider;
                        s.model.ShaderProvider = depthShader;
                        s.Draw(state);
                        s.model.ShaderProvider = temp;
                    }

                    foreach (Port s in portObjects)
                    {
                        temp = s.model.ShaderProvider;
                        s.model.ShaderProvider = depthShader;
                        s.Draw(state);
                        s.model.ShaderProvider = temp;
                    }

                    foreach (Switch s in switchObjects)
                    {
                        temp = s.model.ShaderProvider;
                        s.model.ShaderProvider = depthShader;
                        s.Draw(state);
                        s.model.ShaderProvider = temp;
                    }

                    foreach (NPC s in npcList)
                    {
                        temp = s.model.ShaderProvider;
                        s.model.ShaderProvider = depthShader;
                        s.Draw(state);
                        s.model.ShaderProvider = temp;
                    }

                    foreach (MovablePlatform s in platformObjects)
                    {
                        temp = s.model.ShaderProvider;
                        s.model.ShaderProvider = depthShader;
                        s.Draw(state);
                        s.model.ShaderProvider = temp;
                    }

                    //foreach (Pipe s in pipeObjects)
                    //{
                    //    temp = s.model.ShaderProvider;
                    //    s.model.ShaderProvider = depthShader;
                    //    s.Draw(state);
                    //    s.model.ShaderProvider = temp;
                    //}

                    temp = player.model.ShaderProvider;
                    player.model.ShaderProvider = depthShader;
                    player.Draw(state);
                    player.model.ShaderProvider = temp;

                    //avgFps.Text.SetText(state.ApproximateFrameRate);
                    //avgFps.Draw(state);

                }
            }
            else
            {
                backGround.Draw(state);
                using (state.DrawFlags.Push(new MaterialLightCollectionFlag(lights)))
                {
                    foreach (StaticObject s in staticObjects)
                        s.Draw(state);

                    foreach (DynamicObject s in dynamicObjects)
                        s.Draw(state);

                    foreach (DoorObject s in doorObjects)
                        s.Draw(state);

                    foreach (Port s in portObjects)
                        s.Draw(state);

                    foreach (Switch s in switchObjects)
                        s.Draw(state);

                    foreach (NPC s in npcList)
                        s.Draw(state);

                    foreach (MovablePlatform s in platformObjects)
                        s.Draw(state);

                    foreach (Pipe s in pipeObjects)
                        s.Draw(state);

                    player.Draw(state);
                }

                //avgFps.Text.SetText(state.ApproximateFrameRate);
                //avgFps.Draw(state);
            }

#if DEBUGDRAWERENABLED
            if (Main.debugDrawerToggle)
            {
                Matrix viewMatrix = Matrix.Identity;
                camera.GetCameraMatrix(out viewMatrix);
                Main.debugDrawer.Draw(state, viewMatrix, camera.Projection.ProjectionMatrix);
            }
#endif
        }

        public bool CullTest(ICuller culler)
        {
            return true;
        }

        public void InitSpawns(List<Vector3> spawnPoints, List<Vector3> spawnTriggers)
        {
            Vector3 tempSpawn = new Vector3(-2000.0f, 5868.0f, 0.0f);//startPoint {X:-2000 Y:5868.086 Z:0}
            spawnPoints.Add(tempSpawn);
            //tempSpawn = new Vector3(-100.0f, -2000.0f, 0.0f);/*spawnPoint1*/ Vector3 tempTrigger = new Vector3(200.0f, -1300.0f, 0.0f);//spawnTrigger1
            //spawnPoints.Add(tempSpawn); spawnTriggers.Add(tempTrigger);
            //tempSpawn = new Vector3(50.0f, -3200.0f, 0.0f);/*spawnPoint2*/ tempTrigger = new Vector3(200.0f, -2500.0f, 0.0f);//spawnTrigger2
            //spawnPoints.Add(tempSpawn); spawnTriggers.Add(tempTrigger);
            //tempSpawn = new Vector3(740.0f, -3300.0f, 0.0f);/*spawnPoint3*/ tempTrigger = new Vector3(490.0f, -3000.0f, 0.0f);//spawnTrigger3
            //spawnPoints.Add(tempSpawn); spawnTriggers.Add(tempTrigger);
            //tempSpawn = new Vector3(2300.0f, -1100.0f, 0.0f);/*spawnPoint4*/ tempTrigger = new Vector3(2200.0f, -1150.0f, 0.0f);//spawnTrigger4
            //spawnPoints.Add(tempSpawn); spawnTriggers.Add(tempTrigger);
            //tempSpawn = new Vector3(2625.0f, 560.0f, 0.0f);/*spawnPoint5*/ tempTrigger = new Vector3(2500.0f, 900.0f, 0.0f);//spawnTrigger5
            //spawnPoints.Add(tempSpawn); spawnTriggers.Add(tempTrigger);
        }
    }

    class LightSourceDrawer : IDraw
    {
        private IDraw geometry;
        private Vector3 position;
        private Color lightColour;

        public LightSourceDrawer(Vector3 position, IDraw geometry, Color lightColour)
        {
            this.position = position;
            this.geometry = geometry;
            this.lightColour = lightColour;
        }

        public void Draw(DrawState state)
        {

            using (state.WorldMatrix.PushTranslateMultiply(ref position))
            {
                DrawSphere(state);
            }
        }

        private void DrawSphere(DrawState state)
        {
            //draw the geometry with a solid colour shader
            if (geometry.CullTest(state))
            {
                Xen.Ex.Shaders.FillSolidColour shader = state.GetShader<Xen.Ex.Shaders.FillSolidColour>();

                shader.FillColour = lightColour.ToVector4();

                using (state.Shader.Push(shader))
                {
                    geometry.Draw(state);
                }
            }
        }

        public bool CullTest(ICuller culler)
        {
            return true;
        }
    }
}
