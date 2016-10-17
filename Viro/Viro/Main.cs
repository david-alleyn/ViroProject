using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

using Xen;
using Xen.Ex.Filters;
using Xen.Graphics;
using Xen.Camera;
using Viro.Actors;
using Viro.Shaders;

namespace Viro
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Main : Application
    {
        enum State { MAINMENU, GAME, GAMEMENU, NULL, STORYBOARD, DEATHBOARD, PAUSE }
        State GameState = State.MAINMENU;
        private DrawTargetScreen screen;

        Xen.Ex.Graphics2D.ShaderElement blur;
        Xen.Ex.Graphics2D.ShaderElement bloom;
        Xen.Ex.Graphics2D.ShaderElement bloomCombined;

        Level level;
        ContentRegister levelContent;
        ContentRegister menuContent;

        //DEBUG DRAWER REQUIRES THIS
        public static GraphicsDevice graphicsDevice;
        public static DebugDrawer debugDrawer;
        public static bool debugDrawerToggle = false;
        //DEBUG DRAWER REQUIRES THIS

        Menu menu;
        Storyboard storyboard;
        Storyboard deathboard;

        bool isPaused = false;

        protected override void Initialise()
        {
            // TODO: Add your initialization logic here
            menuContent = new ContentRegister(this);

            //display.Add(screen);
            
            menu = new Menu();
            menu.Initialize(ref screen, menuContent);

            SoundManager.Sound.PlaySound("MenuTheme1");
        }

#if !XBOX360
        protected override void SetupGraphicsDeviceManager(GraphicsDeviceManager graphics, ref RenderTargetUsage presentation)
        {

#if !XBOX360
            //DisplayMode mode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
            graphics.IsFullScreen = true;
            //graphics.PreferredBackBufferWidth = mode.Width;
            //graphics.PreferredBackBufferHeight = mode.Height;
            //graphics.PreferMultiSampling = true;
            //graphics.SynchronizeWithVerticalRetrace = true;
#else
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferMultiSampling = true;
            graphics.SynchronizeWithVerticalRetrace = true;
#endif
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferMultiSampling = true;
            graphics.SynchronizeWithVerticalRetrace = true;

            base.SetupGraphicsDeviceManager(graphics, ref presentation);
                    
            //REQUIRED FOR DEBUG DRAWER
            debugDrawer = new DebugDrawer();
        }
#endif
        protected override void InitialisePlayerInput(Xen.Input.PlayerInputCollection playerInput)
        {
           // if (playerInput[PlayerIndex.One].ControlInput == Xen.Input.ControlInput.KeyboardMouse)
           //     playerInput[PlayerIndex.One].InputMapper.CentreMouseToWindow = true;

            base.InitialisePlayerInput(playerInput);
        }

        protected override void Update(UpdateState state)
        {
            //quit when the back button is pressed (escape on the PC)
            if (state.PlayerInput[PlayerIndex.One].InputState.Buttons.Back.OnPressed)
                this.Shutdown();

#if !XBOX360

            if (state.KeyboardState.KeyState.F1.OnPressed)
#else
            if (state.PlayerInput[PlayerIndex.One].InputState.Buttons.Start.OnPressed)
#endif
            {
                //GameState = State.PAUSE;
            }

            //TESTING CODE! SHAUN'S
#if !XBOX360
            if (state.KeyboardState.KeyState.C.OnPressed)
            {
                debugDrawerToggle = !debugDrawerToggle;
            } 

            if (state.KeyboardState.KeyState.F10.OnPressed)
#else
            if (state.PlayerInput[PlayerIndex.One].InputState.Buttons.Start.OnPressed)
#endif      
            {
                switch (GameState)
                {
                    case State.GAME:
                        GameState = State.GAMEMENU;
                        levelContent.Dispose();
                        menuContent = new ContentRegister(this);
                        menu = new Menu();
                        menu.Initialize(ref screen, menuContent);
                        break;
                    default:
                        break;
                }
            }
            //END OF TESTING CODE!

            switch (GameState)
            {
                case State.GAME:
                    level.Update(state);
                    if (level.player.IsDead == true)
                    {
                        deathboard = new Storyboard(new Vector2(0, 0), new Vector2(this.WindowWidth, this.WindowHeight), "Failed", 2);
                        Content.Add(deathboard);
                        screen.Add(deathboard);
                        GameState = State.DEATHBOARD;
                    }
                    break;
                case State.MAINMENU: case State.GAMEMENU:
                    switch (menu.Update(state))
                    {
                        case BUTTON.START:
                            storyboard = new Storyboard(new Vector2(0, 0), new Vector2(this.WindowWidth, this.WindowHeight), "Hallway", "Prisonfinal", "ViroPosterFinal", 1);
                            Content.Add(storyboard);
                            screen.Add(storyboard);
                            //menuContent.Dispose();
                            GameState = State.STORYBOARD;
                            screen.Remove(menu);
                            //menu = null;
                            break;
                        case BUTTON.OPTIONS:
                            break;
                        case BUTTON.EXIT:
                            this.Shutdown();
                            break;
                        default:
                            break;
                    }
                    break;
                case State.STORYBOARD:
                    storyboard.Update(state);
                    if (storyboard.isComplete == true)
                    {
                        GameState = State.GAME;
                        levelContent = new ContentRegister(this);
                        level = new Level(ref screen, ref levelContent, UpdateManager, "LevelComplete", this.WindowWidth, this.WindowHeight);
                        level.windowHeight = this.WindowHeight;
                        level.windowWidth = this.WindowWidth;

                        //post process shaders
                        Shaders.Bloom.Bloom bloomShader = new Shaders.Bloom.Bloom();
                        bloom = new Xen.Ex.Graphics2D.ShaderElement(bloomShader, new Vector2(this.WindowWidth, this.WindowHeight));
                        level.bloomTexture.Add(bloom);

                        Shaders.CombineBloom.BloomCombine bloomCombineShader = new Shaders.CombineBloom.BloomCombine();
                        bloomCombined = new Xen.Ex.Graphics2D.ShaderElement(bloomCombineShader, new Vector2(this.WindowWidth, this.WindowHeight));
                        level.combinedBloomTexture.Add(bloomCombined);

                        Shaders.DoF.PostProcessDOF dofShader = new Shaders.DoF.PostProcessDOF();
                        //Shader values
                        dofShader.Far = 5000.0f;
                        //dofShader.Near = 100.0f;
                        //dofShader.Range = 200.0f;
                        dofShader.Distance = 900.0f;
                        blur = new Xen.Ex.Graphics2D.ShaderElement(dofShader, new Vector2(this.WindowWidth, this.WindowHeight));
                        screen.Insert(0, blur);

                        string LastCue = SoundManager.Sound.GetSound();
                        SoundManager.Sound.StopMusic();
                        SoundManager.Sound.PlaySound("LevelTheme1");
                        screen.Remove(storyboard);
                        storyboard = null;
                        Content.Remove(storyboard);
                        
                        Xen.Ex.Graphics2D.TexturedElement displayTexture = null;
                        displayTexture = new Xen.Ex.Graphics2D.TexturedElement(level.drawTexture, new Vector2(this.WindowWidth, this.WindowHeight));
                        //screen.Add(displayTexture);
                    }
                    break;
                case State.DEATHBOARD:
                    level.Update(state);
                    deathboard.Update(state);
                    if (deathboard.isComplete == true)
                    {
                        GameState = State.GAMEMENU;
                        levelContent.Dispose();
                        menuContent = new ContentRegister(this);
                        menu = new Menu();
                        menu.Initialize(ref screen, menuContent);
                    }
                    break;
                case State.PAUSE:
                    if (isPaused == false)
                    {
                        isPaused = true;
                        screen.Add(menu);
                    }

                    switch (menu.Update(state))
                    {
                        case BUTTON.START:
                            isPaused = false;
                            screen.Remove(menu);
                            GameState = State.GAME;
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        protected override void Frame(FrameState state)
        {
            if (GameState == State.GAME || GameState == State.DEATHBOARD)
            {
                level.renderDepth = false;
                level.drawTexture.Draw(state);

                level.renderDepth = true;
                level.depthTexture.Draw(state);

                ((Shaders.Bloom.Bloom)(bloom.Shader)).BaseScene = level.drawTexture.GetTexture();
                level.bloomTexture.Draw(state);

                BlurFilter filter = new BlurFilter(BlurFilterFormat.SevenSampleBlur, 0.5f, level.bloomTexture, level.intermediateTexture);
                filter.Draw(state);

                ((Shaders.CombineBloom.BloomCombine)(bloomCombined.Shader)).Bloom = level.bloomTexture.GetTexture();
                ((Shaders.CombineBloom.BloomCombine)(bloomCombined.Shader)).ColorMap = level.drawTexture.GetTexture();
                level.combinedBloomTexture.Draw(state);

                filter = new BlurFilter(BlurFilterFormat.FifteenSampleBlur, 0.5f, level.drawTexture, level.intermediateTexture);
                filter.Draw(state);


                ((Shaders.DoF.PostProcessDOF)(blur.Shader)).BaseScene = level.combinedBloomTexture.GetTexture();
                ((Shaders.DoF.PostProcessDOF)(blur.Shader)).BlurScene = level.drawTexture.GetTexture();
                ((Shaders.DoF.PostProcessDOF)(blur.Shader)).DepthMap = level.depthTexture.GetTexture();

                screen.Draw(state);
            }
            else
                screen.Draw(state);
        }

        //public void LoadLevel(string name)
        //{
        //    Stream fileStream = new FileStream("../../../../../Viro/ViroContent/Levels/" + name + ".xnb", FileMode.Open);
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Level));
        //    level = (Level)xmlSerializer.Deserialize(fileStream);
        //
        //    fileStream.Close();
        //}
    }
}
