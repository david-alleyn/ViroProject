using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

using Xen;
using Xen.Graphics;
using Xen.Ex.Graphics2D;
using Xen.Camera;
using Xen.Ex.Graphics;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

using LevelMap;

namespace LevelEditor
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Main : Application, IDraw
    {

        #region Declarations

        enum ESTATE { MENU, EDITOR }
        ESTATE editorState = ESTATE.MENU;

        enum STATECONTENT { DYNAMIC, STATIC, NPC, PLAYER, MOVABLEPLATFORM, LIGHTS, SELECT, LINKOBJECT }
        STATECONTENT userState = STATECONTENT.STATIC;

        private DrawTargetScreen screen;
        Camera3D camera;
        Vector3 cameraPos, cameraTarget;
        Vector3 MousePosWorld = new Vector3(0.0f);
        Level level = null;

        LevelMap.LevelObjects currentObject;
        LevelMap.LevelObjects currentLINKMODEObject; // object selected for LINKMODE
        int linkModeIndex = 0;
        LevelMap.Lights currentLight;

        int objectNumber = 0;

        List<LevelMap.LevelObjects> staticObjects;
        List<LevelMap.LevelObjects> dynamicObjects;
        List<LevelMap.LevelObjects> npcList;
        List<LevelMap.LevelObjects> movablePlatforms;
        List<LevelMap.Lights> lightList;

        LevelMap.LevelObjects player;

        private TextElementRect textElement;
        private TextElementRect helpDisplay;

        string levelName;

        bool inMenu = false;
        private float listPos;

        #endregion

        protected override void Initialise()
        {
            listPos = 0.0f;
            camera = new Camera3D();
            cameraPos = new Vector3(0, 45, 750);
            cameraTarget = new Vector3(0, 40, 0);

            camera.LookAt(cameraTarget, cameraPos, new Vector3(0, 1, 0));
            camera.Projection.FieldOfView = (float)0.7853982;
            camera.Projection.FarClip = 10000;
            
            screen = new DrawTargetScreen(camera);
            screen.ClearBuffer.ClearColour = Color.Chocolate;

            InitializeText();

            staticObjects = new List<LevelMap.LevelObjects>();
            dynamicObjects = new List<LevelMap.LevelObjects>();
            npcList = new List<LevelMap.LevelObjects>();
            lightList = new List<LevelMap.Lights>();
            movablePlatforms = new List<LevelObjects>();
            

            player = new LevelMap.LevelObjects();

            SetLists();

            screen.Add(this);
        }

        private void InitializeText()
        {
            helpDisplay = new TextElementRect(new Vector2(400, 200));
            helpDisplay.Text.SetText("\"New\" or \"Load\"");

            this.helpDisplay.VerticalAlignment = VerticalAlignment.Centre;
            this.helpDisplay.HorizontalAlignment = HorizontalAlignment.Centre;
            this.helpDisplay.TextHorizontalAlignment = TextHorizontalAlignment.Centre;
            this.helpDisplay.TextVerticalAlignment = VerticalAlignment.Centre;

            screen.Add(helpDisplay);

            this.textElement = new TextElementRect(new Vector2(400, 200));
            this.textElement.Colour = Color.Black;

            //align the element to the bottom centre of the screen
            this.textElement.VerticalAlignment = VerticalAlignment.Bottom;
            this.textElement.HorizontalAlignment = HorizontalAlignment.Centre;

            //centre align the text
            this.textElement.TextHorizontalAlignment = TextHorizontalAlignment.Centre;
            //centre the text in the middle of the 400x200 area of the element
            this.textElement.TextVerticalAlignment = VerticalAlignment.Centre;

            screen.Add(textElement);
        }

        protected override void InitialisePlayerInput(Xen.Input.PlayerInputCollection playerInput)
        {
            //if (playerInput[PlayerIndex.One].ControlInput == Xen.Input.ControlInput.KeyboardMouse)
            //    playerInput[PlayerIndex.One].InputMapper.CentreMouseToWindow = true;
            playerInput[PlayerIndex.One].InputMapper.MouseVisible = true;
            base.InitialisePlayerInput(playerInput);
        }

        protected override void LoadContent(ContentState state)
        {
            //Load a normal XNA sprite font
            SpriteFont xnaSpriteFont = state.Load<SpriteFont>(@"Font/Arial");

            //both elements require the font to be set before they are drawn
            this.textElement.Font = xnaSpriteFont;
            this.helpDisplay.Font = xnaSpriteFont;
            base.LoadContent(state);
        }
        public void StartEditor()
        {
            editorState = ESTATE.EDITOR;

            currentObject = staticObjects[objectNumber];
            currentLight = lightList[objectNumber];

            if (level == null)
                level = new Level();
            else
            {
                foreach (LevelMap.LevelObjects l in level.map.listOfObjects)
                    Content.Add(l);
                level.Init();
            }
        }

        public void LoadLevel(string name)
        {
            //levelName = name;
            //Stream fileStream = new FileStream("../../../../../Viro/ViroContent/Levels/" + name + ".xnb", FileMode.Open);
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<LevelMap.LevelMap>));
            //level = new Level();
            //level.listOfObjects = (List<LevelMap.LevelMap>)xmlSerializer.Deserialize(fileStream);
            //fileStream.Close();
            //StartEditor();

            XmlReaderSettings settingsReader = new XmlReaderSettings();
            level = new Level();
            using (XmlReader reader = XmlReader.Create("../../../../../Viro/ViroContent/Levels/" + name + ".xml", settingsReader))
            {
                level.map = IntermediateSerializer.Deserialize<LevelMap.LevelMap>(reader, null);
            }

            levelName = name;

            //Remake all objectIDs and WIPE all trigger/port/switch links - TEMPORARY CODE
            //IDs start at 44 (I believe some pre-allocations made by some Lists cause this to happen. For now re-assignments will begin at 44)

            //int objectIDcount = 44;
            //foreach (LevelObjects lo in level.map.listOfObjects)
            //{
            //    lo.objectID = objectIDcount;
            //    objectIDcount++;
            //    lo.linkedObjects.Clear();
            //}

            //textElement.Text.SetText("IDs have been re-assigned and trigger/switch/port links have been cleared\nand all objects have been set to ENABLED on game-load.");

            //Set the correct "last objectID assigned" variable within LevelObjects

            int lastObjectID = 0;

            foreach (LevelObjects lo in level.map.listOfObjects)
            {
                if (lo.objectID > lastObjectID)
                    lastObjectID = lo.objectID;
            }

            LevelObjects.lastGivenID = lastObjectID;

            StartEditor();
        }

        public void SaveLevel(string name)
        {
            //Stream fileStream = new FileStream("../../../../../Viro/ViroContent/Levels/" + name + ".xnb", FileMode.OpenOrCreate);
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<LevelMap.LevelMap>));
            //xmlSerializer.Serialize(fileStream, level.listOfObjects);
            //fileStream.Close();

            XmlWriterSettings settingsWriter = new XmlWriterSettings();
            settingsWriter.Indent = true;

            using (XmlWriter writer = XmlWriter.Create("../../../../../Viro/ViroContent/Levels/" + name + ".xml", settingsWriter))
            {
                IntermediateSerializer.Serialize<LevelMap.LevelMap>(writer, level.map, null);
            }
        }

#if !XBOX360
        protected override void SetupGraphicsDeviceManager(GraphicsDeviceManager graphics, ref RenderTargetUsage presentation)
        {
            graphics.IsFullScreen = false;
            
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;

            base.SetupGraphicsDeviceManager(graphics, ref presentation);
        }
#endif

        protected override void Update(UpdateState state)
        {
            //quit when the back button is pressed (escape on the PC)
            if (state.PlayerInput[PlayerIndex.One].InputState.Buttons.Back.OnPressed)
                this.Shutdown();

            switch (editorState)
            {
                case ESTATE.MENU:
                    UpdateMenu(state);
                    break;

                case ESTATE.EDITOR:
                    UpdateEditor(state);
                    break;

                default:
                    break;
            }
        }

        private void UpdateEditor(UpdateState state)
        {
            if (state.KeyboardState.KeyState.Q.OnPressed)
            {
                if (userState == STATECONTENT.SELECT)
                    userState = STATECONTENT.STATIC;
                inMenu = !inMenu;
            }
            if (state.KeyboardState.KeyState.W.OnPressed)
            {
                userState = STATECONTENT.SELECT;
                currentObject = null;
                inMenu = false;
            }

            switch (inMenu)
            {
                case false:
                    Vector3 mousePosDelta = new Vector3(state.MouseState.X - (this.WindowWidth / 2), -state.MouseState.Y + (this.WindowHeight / 2), 0.0f);
                    MousePosWorld += mousePosDelta;
                    currentLight.ChangePosition(new Vector3(mousePosDelta.X, mousePosDelta.Y, 0.0f));

                    if (state.MouseState.MiddleButton.IsDown)
                    {
                        Mouse.SetPosition(this.WindowWidth / 2, this.WindowHeight / 2);
                        cameraPos += new Vector3(-mousePosDelta.X, -mousePosDelta.Y, -state.MouseState.ScrollWheelDelta);
                        cameraTarget += new Vector3(-mousePosDelta.X, -mousePosDelta.Y, 0.0f);
                        camera.LookAt(cameraTarget, cameraPos, new Vector3(0, 1, 0));
                    }
                    if (state.MouseState.ScrollWheelDelta != 0 && !state.KeyboardState.KeyState.LeftAlt.IsDown && !state.KeyboardState.KeyState.E.IsDown && !state.KeyboardState.KeyState.R.IsDown)
                    {
                        cameraPos += new Vector3(0.0f, 0.0f, -state.MouseState.ScrollWheelDelta);
                        camera.LookAt(cameraTarget, cameraPos, new Vector3(0, 1, 0));
                    }

                    #region Select
                    if (userState == STATECONTENT.SELECT) // To delete objects OR enter LINKOBJECT mode (for linking objects to triggers/switchs/ports)
                    {
                        state.PlayerInput[0].InputMapper.MouseVisible = true;
                        if (state.MouseState.LeftButton.OnPressed)
                        {
                            LevelObjects obj;
                            obj = CheckObjects(level.map.listOfObjects);
                            if (obj != null)
                            {
                                if (obj.obj == LevelObjects.OBJECTTYPE.STATIC)
                                {
                                    Mouse.SetPosition(this.WindowWidth / 2, this.WindowHeight / 2);
                                    currentObject = obj;
                                    level.map.listOfObjects.Remove(obj);
                                    userState = STATECONTENT.STATIC;
                                }
                                else if (obj.obj == LevelObjects.OBJECTTYPE.PORT ||
                                    obj.obj == LevelObjects.OBJECTTYPE.SWITCH ||
                                    obj.obj == LevelObjects.OBJECTTYPE.TRIGGER)
                                {
                                    // Enter a special trigger/switch/port mode. After selecting a trigger/switch/port, begin selecting NEW "linked objects". Press Enter to save the list.
                                    // THE COMMENTED CODE IS THE OLD SELECTION CODE

                                    //Mouse.SetPosition(this.WindowWidth / 2, this.WindowHeight / 2);
                                    //currentObject = obj;
                                    //level.map.listOfObjects.Remove(obj);
                                    //userState = STATECONTENT.DYNAMIC;
                                    userState = STATECONTENT.LINKOBJECT; // Enter LINKOBJECT mode.

                                    currentLINKMODEObject = obj;
                                    linkModeIndex = level.map.listOfObjects.IndexOf(obj);
                                    break;
                                }
                                else if (obj.obj == LevelObjects.OBJECTTYPE.MINION)
                                {
                                    Mouse.SetPosition(this.WindowWidth / 2, this.WindowHeight / 2);
                                    currentObject = obj;
                                    level.map.listOfObjects.Remove(obj);
                                    userState = STATECONTENT.NPC;
                                }
                                else if (obj.obj == LevelObjects.OBJECTTYPE.DOOR)
                                {
                                    Mouse.SetPosition(this.WindowWidth / 2, this.WindowHeight / 2);
                                    currentObject = obj;
                                    level.map.listOfObjects.Remove(obj);
                                    userState = STATECONTENT.DYNAMIC;
                                }
                                else if (obj.obj == LevelObjects.OBJECTTYPE.WAYPOINT)
                                {
                                    Mouse.SetPosition(this.WindowWidth / 2, this.WindowHeight / 2);
                                    currentObject = obj;
                                    level.map.listOfObjects.Remove(obj);
                                    userState = STATECONTENT.DYNAMIC;
                                }
                                else if (obj.obj == LevelObjects.OBJECTTYPE.MOVABLEPLATFORM)
                                {
                                    Mouse.SetPosition(this.WindowWidth / 2, this.WindowHeight / 2);
                                    currentObject = obj;
                                    level.map.listOfObjects.Remove(obj);
                                    userState = STATECONTENT.MOVABLEPLATFORM;
                                }
                                //if (currentObject != null)
                                //{
                                    MousePosWorld = currentObject.GetPosition;
                                //}
                                break;
                            }
                        }
                    }
                    else if (userState == STATECONTENT.LINKOBJECT)
                    {
                        state.PlayerInput[0].InputMapper.MouseVisible = true;

                        if (state.KeyboardState.KeyState.LeftControl.IsDown)
                            if (state.KeyboardState.KeyState.Z.OnPressed)
                                if (currentLINKMODEObject.linkedObjects.Count > 0)
                                    currentLINKMODEObject.linkedObjects.RemoveAt(currentLINKMODEObject.linkedObjects.Count - 1);

                        if (state.KeyboardState.KeyState.Enter.OnPressed)
                        {
                            level.map.listOfObjects[linkModeIndex] = currentLINKMODEObject;
                            userState = STATECONTENT.STATIC;
                            currentObject = staticObjects[0]; //Reset back to normal
                            Mouse.SetPosition(this.WindowWidth / 2, this.WindowHeight / 2);
                        }

                        if (state.KeyboardState.KeyState.Delete.OnPressed)
                        {
                            Mouse.SetPosition(this.WindowWidth / 2, this.WindowHeight / 2);
                            currentObject = level.map.listOfObjects[linkModeIndex];
                            level.map.listOfObjects.RemoveAt(linkModeIndex);
                            userState = STATECONTENT.DYNAMIC;
                        }

                        if (state.MouseState.LeftButton.OnPressed)
                        {
                            LevelObjects obj;
                            obj = CheckObjects(level.map.listOfObjects);
                            if (obj != null)
                            {
                                if(currentLINKMODEObject.obj == LevelObjects.OBJECTTYPE.PORT)
                                {
                                    if (obj.obj == LevelObjects.OBJECTTYPE.STATIC)
                                    {
                                        currentLINKMODEObject.linkedObjects.Add(obj.objectID);
                                    }
                                }
                                else if (currentLINKMODEObject.obj == LevelObjects.OBJECTTYPE.SWITCH || currentLINKMODEObject.obj == LevelObjects.OBJECTTYPE.TRIGGER)                                {
                                    if (obj.obj == LevelObjects.OBJECTTYPE.DOOR)
                                    {
                                        currentLINKMODEObject.linkedObjects.Add(obj.objectID);
                                    }
                                }
                            }
                            
                        }
                        MousePosWorld = currentLINKMODEObject.GetPosition;
                        break;
                    }
                    #endregion Select
                    #region NotInMenu
                    else
                    {
                        if (state.KeyboardState.KeyState.LeftControl.IsDown)
                        {
                            state.PlayerInput[0].InputMapper.MouseVisible = true;
                            if (state.MouseState.LeftButton.OnPressed)
                            {
                                LevelObjects obj;
                                obj = CheckObjects(level.map.listOfObjects);
                                if (obj != null)
                                {
                                    int objectIndex = level.map.listOfObjects.IndexOf(obj);
                                    obj.enabled = !obj.enabled;
                                    level.map.listOfObjects[objectIndex] = obj;
                                    Mouse.SetPosition(this.WindowWidth / 2, this.WindowHeight / 2);
                                    textElement.Text.SetText("Selected Object is now: " + obj.enabled.ToString());
                                }
                            }
                            break;
                        }

                        Mouse.SetPosition(this.WindowWidth / 2, this.WindowHeight / 2);
                        state.PlayerInput[0].InputMapper.MouseVisible = false;

                        
                        if (state.MouseState.LeftButton.OnPressed)
                        {
                            if (userState != STATECONTENT.LIGHTS)
                                level.AddObject(currentObject);
                            else
                                level.AddLight(currentLight);
                        }

                        #region changeObjectAlt
                        if (state.KeyboardState.KeyState.LeftAlt.IsDown)
                        {
                            if (state.MouseState.ScrollWheelDelta != 0)
                            {
                                switch (userState)
                                {
                                    case STATECONTENT.DYNAMIC:
                                        if (state.MouseState.ScrollWheelDelta > 1)
                                        {
                                            objectNumber++;
                                            if (objectNumber >= dynamicObjects.Count)
                                                objectNumber = 0;
                                        }
                                        else if (state.MouseState.ScrollWheelDelta < -1)
                                        {
                                            objectNumber--;
                                            if (objectNumber < 0)
                                                objectNumber = dynamicObjects.Count - 1;
                                        }
                                        currentObject = dynamicObjects[objectNumber];
                                        break;
                                    case STATECONTENT.STATIC:
                                        if (state.MouseState.ScrollWheelDelta > 1)
                                        {
                                            objectNumber++;
                                            if (objectNumber >= staticObjects.Count)
                                                objectNumber = 0;
                                        }
                                        else if (state.MouseState.ScrollWheelDelta < -1)
                                        {
                                            objectNumber--;
                                            if (objectNumber < 0)
                                                objectNumber = staticObjects.Count - 1;
                                        }
                                        currentObject = staticObjects[objectNumber];
                                        break;
                                    case STATECONTENT.NPC:
                                        if (state.MouseState.ScrollWheelDelta > 1)
                                        {
                                            objectNumber++;
                                            if (objectNumber >= npcList.Count)
                                                objectNumber = 0;
                                        }
                                        else if (state.MouseState.ScrollWheelDelta < -1)
                                        {
                                            objectNumber--;
                                            if (objectNumber < 0)
                                                objectNumber = npcList.Count - 1;
                                        }
                                        currentObject = npcList[objectNumber];
                                        break;
                                    case STATECONTENT.LIGHTS:
                                        if (state.MouseState.ScrollWheelDelta > 1)
                                        {
                                            objectNumber++;
                                            if (objectNumber >= lightList.Count)
                                                objectNumber = 0;
                                        }
                                        else if (state.MouseState.ScrollWheelDelta < -1)
                                        {
                                            objectNumber--;
                                            if (objectNumber < 0)
                                                objectNumber = lightList.Count - 1;
                                        }
                                        currentLight = lightList[objectNumber];
                                        break;
                                    case STATECONTENT.PLAYER:
                                        currentObject = player;
                                        break;
                                    case STATECONTENT.MOVABLEPLATFORM:
                                        if (state.MouseState.ScrollWheelDelta > 1)
                                        {
                                            objectNumber++;
                                            if (objectNumber >= movablePlatforms.Count)
                                                objectNumber = 0;
                                        }
                                        else if (state.MouseState.ScrollWheelDelta < -1)
                                        {
                                            objectNumber--;
                                            if (objectNumber < 0)
                                                objectNumber = movablePlatforms.Count - 1;
                                        }
                                        currentObject = movablePlatforms[objectNumber];
                                        break;
                                }
                            }
                        }
                        #endregion changeObjectAlt

                        if (state.KeyboardState.KeyState.R.IsDown)
                        {
                            if(state.MouseState.ScrollWheelDelta > 1)
                                currentObject.ChangeRotation(new Vector3(0, 0, MathHelper.ToRadians(90)));
                            else if(state.MouseState.ScrollWheelDelta < -1)
                                currentObject.ChangeRotation(new Vector3(0, 0, MathHelper.ToRadians(-90)));

                            if(mousePosDelta.X > 20)
                                currentObject.ChangeRotation(new Vector3(MathHelper.ToRadians(90), 0, 0));
                            else if (mousePosDelta.X < -20)
                                currentObject.ChangeRotation(new Vector3(MathHelper.ToRadians(90), 0, 0));

                            if (mousePosDelta.Y > 20)
                                currentObject.ChangeRotation(new Vector3(0, MathHelper.ToRadians(90), 0));
                            else if (mousePosDelta.Y < -20)                        
                                currentObject.ChangeRotation(new Vector3(0, MathHelper.ToRadians(90), 0));
                            //else
                            //    currentObject.ChangeRotation(new Vector3((MousePosWorld.X - (MousePosWorld.X % 30.000f)),
                            //                                         (MousePosWorld.Y - (MousePosWorld.Y % 30.000f)), 0));
                        }
                        else if (state.KeyboardState.KeyState.R.OnReleased)
                        {
                            MousePosWorld = currentObject.GetPosition;
                        }
                        else if (state.KeyboardState.KeyState.E.IsDown)
                        {
                            currentObject.ChangePosition(new Vector3(0.0f, 0.0f, state.MouseState.ScrollWheelDelta));
                        }
                        //else if (state.KeyboardState.KeyState.E.OnReleased)
                        //{
                        //    currentObject.ChangePosition(new Vector3(0.0f, 0.0f, -currentObject.GetPosition.Z));
                        //}
                        else if (!state.KeyboardState.KeyState.LeftShift.IsDown && currentObject != null)
                        {
                            Vector3 temp = new Vector3();
                            temp.X = (MousePosWorld.X - (MousePosWorld.X % 50.000f));
                            temp.Y = (MousePosWorld.Y - (MousePosWorld.Y % 50.000f));
                            temp.Z = currentObject.GetPosition.Z;
                            currentObject.SetPosition(temp);
                        }
                        else
                            currentObject.ChangePosition(new Vector3(mousePosDelta.X, mousePosDelta.Y, 0.0f));
                    }
                    #endregion NotInMenu
                    break;
                case true:
                    #region inMenu
                    state.PlayerInput[0].InputMapper.MouseVisible = true;
                    if (state.MouseState.ScrollWheelDelta != 0)
                        listPos -= state.MouseState.ScrollWheelDelta;
                    if (state.MouseState.LeftButton.OnPressed)
                    {
                        Ray ray = getRay();

                        switch (userState)
                        {
                            case STATECONTENT.STATIC:
                                foreach (LevelObjects l in staticObjects)
                                {
                                    if (CheckRayCollision(l, ray))
                                    {
                                        currentObject = l;
                                        MousePosWorld = currentObject.GetPosition;
                                        inMenu = false;
                                        break;
                                    }
                                }
                                break;
                        }
                    }
                    #endregion inMenu
                    break;
            }

            if (state.KeyboardState.KeyState.LeftControl.IsDown)
            {
                if (state.KeyboardState.KeyState.Z.OnPressed)
                    level.RemoveObject();
                else if (state.KeyboardState.KeyState.S.OnPressed)
                {
                    helpDisplay.Text.SetText("Saving...");
                    screen.Add(helpDisplay);
                    SaveLevel(levelName);
                    screen.Remove(helpDisplay);
                    helpDisplay.Text.SetText("Saved");
                }
            }
            //helpDisplay.Text.SetText(currentObject.GetPosition);

            if (state.KeyboardState.KeyState.D1.OnPressed)
            {
                userState = STATECONTENT.STATIC;
                objectNumber = 0;
                currentObject = staticObjects[objectNumber];
            }
            else if (state.KeyboardState.KeyState.D2.OnPressed)
            {
                userState = STATECONTENT.DYNAMIC;
                objectNumber = 0;
                currentObject = dynamicObjects[objectNumber];
            }
            else if (state.KeyboardState.KeyState.D3.OnPressed)
            {
                userState = STATECONTENT.NPC;
                objectNumber = 0;
                currentObject = npcList[objectNumber];
            }
            else if (state.KeyboardState.KeyState.D4.OnPressed)
            {
                userState = STATECONTENT.PLAYER;
                currentObject = player;
            }
            else if (state.KeyboardState.KeyState.D5.OnPressed)
            {
                userState = STATECONTENT.LIGHTS;
                objectNumber = 0;
                currentLight = lightList[objectNumber];
                currentLight.position = currentObject.GetPosition;
            }
            else if (state.KeyboardState.KeyState.D6.OnPressed)
            {
                userState = STATECONTENT.MOVABLEPLATFORM;
                objectNumber = 0;
                currentObject = movablePlatforms[objectNumber];
            }
        }

        private void UpdateMenu(UpdateState state)
        {
            List<Microsoft.Xna.Framework.Input.Keys> pressedKeys = new List<Microsoft.Xna.Framework.Input.Keys>();
            state.KeyboardState.GetPressedKeys(pressedKeys);

            foreach (Microsoft.Xna.Framework.Input.Keys key in pressedKeys)
            {
                if (key == Keys.Back)
                    textElement.Text.TrimEnd(1);
                else if (key == Keys.Enter)
                {
                    if (textElement.Text == "New")
                    {
                        helpDisplay.Text.SetText("Enter the New Level Name");
                    }
                    else if (textElement.Text == "Load")
                    {
                        helpDisplay.Text.SetText("Enter the File Name");
                    }
                    else
                    {
                        if (helpDisplay.Text == "Enter the File Name")
                            LoadLevel(textElement.Text);
                        else if (helpDisplay.Text == "Enter the New Level Name")
                        {
                            levelName = textElement.Text;
                            //screen.Remove(helpDisplay);
                            screen.Remove(textElement);
                            StartEditor();
                        }
                    }
                    textElement.Text.SetText("");
                }
                else
                {
                    char c;
                    if (state.KeyboardState.TryGetKeyChar(key, out c))
                        this.textElement.Text.Append(c);
                }
            }
        }

        protected override void Frame(FrameState state)
        {
            screen.Draw(state);
        }

        public void Draw(DrawState state)
        {
            if(editorState == ESTATE.EDITOR)
            {
                using (state.RenderState.Push())
                {
                    level.Draw(state);
                    state.RenderState.CurrentBlendState = AlphaBlendState.Additive;
                    if (userState == STATECONTENT.LIGHTS && currentLight != null)
                        currentLight.Draw(state);
                    else if (currentObject != null)
                        currentObject.Draw(state);
                }
                if(inMenu)
                {
                    float offset = 0.0f;

                    switch (userState)
                    {
                        case STATECONTENT.DYNAMIC:
                            foreach (LevelObjects l in dynamicObjects)
                                DrawLevelObject(l, ref offset, state);
                            break;
                        case STATECONTENT.STATIC:
                            foreach (LevelObjects l in staticObjects)
                                DrawLevelObject(l, ref offset, state);
                            break;
                        case STATECONTENT.NPC:
                            foreach (LevelObjects l in npcList)
                                DrawLevelObject(l, ref offset, state);
                            player.Draw(state);
                            break;
                    }
                }
            }
        }

        private void DrawLevelObject(LevelObjects l, ref float offset, DrawState state)
        {
            Vector3 projectedPosition;
            Vector2 position = new Vector2(-0.35f, 0.0f);

            camera.ProjectFromCoordinate(ref position, camera.Position.Z, out projectedPosition);

            l.SetPosition(projectedPosition); //= Matrix.CreateTranslation(projectedPosition) * Matrix.CreateTranslation(new Vector3(-1200, listPos + offset, 0));// *Matrix.CreateTranslation(cameraOriginalPos);
            l.ChangePosition(new Vector3(0, listPos + offset, 0));
            l.Draw(state);

            offset += l.GetModel().ModelData.StaticBounds.Maximum.Y * 2;
        }

        public bool CullTest(ICuller culler)
        {
            return true;
        }

        public Ray getRay()
        {
            Vector2 mousePos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            Vector3 outerPos, innerPos, line;
            camera.ProjectFromTarget(ref mousePos, 0.0f, out innerPos, screen);
            camera.ProjectFromTarget(ref mousePos, camera.Projection.FarClip, out outerPos, screen);
            line = outerPos - innerPos;

            line.Y *= -1;
            return new Ray(innerPos, line);
        }

        public LevelObjects CheckObjects(List<LevelObjects> obj)
        {
            Ray ray = getRay();
            List<LevelObjects> objectsCollidedByRay = new List<LevelObjects>();
            LevelObjects collidedObject = null;
            float zDepth = float.MaxValue; // Assuming ray reaches "end of world" and finds nothing
            float zThickness = float.MaxValue; // Assuming Maximum size bounding box.
            foreach (LevelObjects l in obj)
            {
                if(CheckRayCollision(l, ray))
                {
                    objectsCollidedByRay.Add(l);
                }
            }
            foreach (LevelObjects s in objectsCollidedByRay)
            {
                float tempZThickness = Math.Abs(s.GetModel().ModelData.StaticBounds.Minimum.Z - s.GetModel().ModelData.StaticBounds.Maximum.Z);
                float tempZDepth = (s.GetModel().ModelData.StaticBounds.Minimum.Z + s.GetModel().ModelData.StaticBounds.Maximum.Z) / 2;

                if (tempZDepth < zDepth || tempZDepth > zDepth && tempZThickness < zThickness)
                {
                    zDepth = tempZDepth;
                    zThickness = tempZThickness;
                    collidedObject = s;
                }
            }

            if (collidedObject != null)
            {
                return collidedObject;
            }
            else
            {
                return null;
            }
        }

        public bool CheckRayCollision(LevelObjects l, Ray ray)
        {
            //if (l.modelName != "Levels/LevelObjects/testlevel")
           // {
                Vector3 minBox = Vector3.Zero, maxBox = Vector3.Zero;
                l.GetModel().CalculateBounds(out minBox, out maxBox);
                BoundingBox box = new BoundingBox(minBox, maxBox);
                box.Min += l.GetPosition;
                box.Max += l.GetPosition;

                if (ray.Intersects(box) != null)
                    return true;
           // }
            return false;            
        }

        public void SetLists()
        {
            #region Actor
            npcList.Add(new LevelMap.LevelObjects("Models/dude", LevelMap.LevelObjects.OBJECTTYPE.MINION));
            npcList.Add(new LevelMap.LevelObjects("Models/Rocket", LevelMap.LevelObjects.OBJECTTYPE.MINION));
            npcList.Add(new LevelMap.LevelObjects("Models/Turtle", LevelMap.LevelObjects.OBJECTTYPE.MINION));
            npcList.Add(new LevelMap.LevelObjects("Models/BetaVirus", LevelMap.LevelObjects.OBJECTTYPE.MINION));
            npcList.Add(new LevelMap.LevelObjects("Models/WalkerAnimation", LevelMap.LevelObjects.OBJECTTYPE.MINION));
            npcList.Add(new LevelMap.LevelObjects("Levels/LevelObjects/FloatingPlatform", LevelMap.LevelObjects.OBJECTTYPE.MOVABLEPLATFORM));
            player = new LevelMap.LevelObjects("Models/viro", LevelMap.LevelObjects.OBJECTTYPE.PLAYER);
            #endregion Actor
            #region Static
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/1x1", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/1x1a", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/1x1b", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/1x2", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/1x3", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/1x4", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/1x5", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/1x6", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/1x7", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/1x8", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/1x9", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/1x10", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/dangerfloor1a", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/dangerfloor1b", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/dangerfloor1c", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/dangerfloor2a", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/dangerfloor2b", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/dangerfloor2c", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/dangerfloor3a", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/dangerfloor3b", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/dangerfloor3c", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/floatyPlatform1", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/floatyPlatform2", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/floatyPlatform3", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/floatyPlatform4", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/slantedBlock1", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/slantedBlock2", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/slantedBlock3", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/slantedBlock4", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/slantedBlock5", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/smallerBlock1", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/smallerBlock2", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/smallerBlock3", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/smallerBlock4", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/CapacitorLarge02", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/CapacitorMedium01", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/CapacitorSmall01", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/PipeDiagonal1", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/PipeDiagonal2", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/PipeEnd", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/PipeMid1", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/PipeMid2", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/testlevel", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/LevelInfection", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/Infected_Platform", LevelMap.LevelObjects.OBJECTTYPE.STATIC));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/Blue_neon_pipes", LevelMap.LevelObjects.OBJECTTYPE.PIPE));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/green_neon_pipes", LevelMap.LevelObjects.OBJECTTYPE.PIPE));
            staticObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/red_neon_pipes", LevelMap.LevelObjects.OBJECTTYPE.PIPE));

            #endregion Static
            #region Dynamic
            dynamicObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/viroPortLeft", LevelMap.LevelObjects.OBJECTTYPE.PORT));
            dynamicObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/viroPortRight", LevelMap.LevelObjects.OBJECTTYPE.PORT));
            dynamicObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/2x1door", LevelObjects.OBJECTTYPE.DOOR));
            dynamicObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/trigger", LevelObjects.OBJECTTYPE.TRIGGER));
            dynamicObjects.Add(new LevelMap.LevelObjects("Levels/LevelObjects/waypoint", LevelObjects.OBJECTTYPE.WAYPOINT));
            #endregion Dynamic
            #region Movable Platforms
            movablePlatforms.Add(new LevelMap.LevelObjects("Levels/LevelObjects/1x2", LevelMap.LevelObjects.OBJECTTYPE.MOVABLEPLATFORM));
            #endregion
            #region Lights
            lightList.Add(new LevelMap.Lights(LevelMap.Lights.LightType.POINT, new Vector4(50, 50, 50, 100), 20, new Vector4(25, 25, 25, 0)));
            lightList.Add(new LevelMap.Lights(LevelMap.Lights.LightType.DIRECTIONAL, new Vector4(50, 150, 150, 100), new Vector3(-1, 1, 1), new Vector4(100, 100, 100, 0)));
            #endregion Lights

            foreach (LevelMap.LevelObjects l in staticObjects)
                Content.Add(l);
            foreach (LevelMap.LevelObjects l in dynamicObjects)
                Content.Add(l);
            foreach (LevelMap.LevelObjects l in npcList)
                Content.Add(l);
            foreach (LevelMap.LevelObjects l in movablePlatforms)
                Content.Add(l);

            Content.Add(player);
        }
    }
}
