using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Xen;
using Xen.Graphics;
using Xen.Ex.Graphics2D;
using Xen.Camera;

namespace Viro
{
    enum BUTTON { NULL, START, OPTIONS, HOWTO, SLIDERSOUND, EXIT, VOLUME, CONTROLS, RESUME }

    class Menu : IDraw
    {
        enum MENUSTATE { MAIN, OPTIONS, SETTINGS, CONTROLS, HOWTO, PAUSE }
        MENUSTATE menuState;

        MainMenu mainMenu;
        OptionsMenu optionsMenu;
        ControlsMenu controlsMenu;
        SettingsMenu settingMenu;
        HowToMenu howToMenu;
        GameMenu gameMenu;

        bool gameStarting;

        public Menu() { }

        public void Initialize(ref DrawTargetScreen screen, ContentRegister content)
        {
            menuState = MENUSTATE.MAIN;
            gameStarting = false;

            Camera2D camera = new Camera2D();
            screen = new DrawTargetScreen(camera);
            screen.ClearBuffer.ClearColour = Color.Black;

            mainMenu = new MainMenu();
            mainMenu.Initialize(ref screen, content);

            optionsMenu = new OptionsMenu();
            optionsMenu.Initialize(content);

            controlsMenu = new ControlsMenu();
            controlsMenu.Initialize(content);

            settingMenu = new SettingsMenu();
            settingMenu.Initialize(content);

            howToMenu = new HowToMenu();
            howToMenu.Initialize(content);

            gameMenu = new GameMenu();
            gameMenu.Initialize(content);

            screen.Add(this);
        }

        public BUTTON Update(UpdateState state)
        {
            switch (menuState)
            {
                case MENUSTATE.MAIN:
                    BUTTON t = mainMenu.Update(state);
                    if (t == BUTTON.START)
                    {
                        //menuState = MENUSTATE.PAUSE;
                        return t;
                    }
                    else if (t == BUTTON.OPTIONS)
                        menuState = MENUSTATE.OPTIONS;
                    else
                        return t;
                    break;
                case MENUSTATE.OPTIONS:
                    BUTTON s = optionsMenu.Update(state);
                    if (s == BUTTON.EXIT)
                        menuState = MENUSTATE.MAIN;
                    else if (s == BUTTON.CONTROLS)
                        menuState = MENUSTATE.CONTROLS;
                    else if (s == BUTTON.OPTIONS)
                        menuState = MENUSTATE.SETTINGS;
                    else if (s == BUTTON.HOWTO)
                        menuState = MENUSTATE.HOWTO;
                    else
                        return s;
                    break;
                case MENUSTATE.CONTROLS:
                    BUTTON r = controlsMenu.Update(state);
                    if (r == BUTTON.EXIT)
                        menuState = MENUSTATE.OPTIONS;
                    break;
                case MENUSTATE.SETTINGS:
                    BUTTON q = settingMenu.Update(state);
                    if (q == BUTTON.EXIT)
                        menuState = MENUSTATE.OPTIONS;
                    break;
                case MENUSTATE.HOWTO:
                    BUTTON w = howToMenu.Update(state);
                    if (w == BUTTON.EXIT)
                        menuState = MENUSTATE.OPTIONS;
                    break;
                case MENUSTATE.PAUSE:
                    BUTTON  e = gameMenu.Update(state);
                    return e;
                    break;
            }
            return BUTTON.NULL;
        }

        public void Draw(DrawState state)
        {
            switch (menuState)
            {
                case MENUSTATE.MAIN:
                    mainMenu.Draw(state);
                    break;
                case MENUSTATE.OPTIONS:
                    optionsMenu.Draw(state);
                    break;
                case MENUSTATE.CONTROLS:
                    controlsMenu.Draw(state);
                    break;
                case MENUSTATE.SETTINGS:
                    settingMenu.Draw(state);
                    break;
                case MENUSTATE.HOWTO:
                    howToMenu.Draw(state);
                    break;
            }
        }

        public bool CullTest(ICuller culler)
        {
            return true;
        }
    }

    class MainMenu
    {
        List<Buttons> buttons;
        Buttons selected;
        Background Bg;

        public MainMenu() { }

        public void Initialize(ref DrawTargetScreen screen, ContentRegister content)
        {
            buttons = new List<Buttons>();

            Bg = new Background();
            Bg.AddTexture(@"Menu/Screens/menu");
            content.Add(Bg);

            Buttons tempButton = new Buttons();
            tempButton.Initialize(new Vector2(screen.Width / 25, screen.Height / 25), @"Menu/Buttons/QuitBtn", BUTTON.EXIT);
            buttons.Add(tempButton);

            tempButton = new Buttons();
            tempButton.Initialize(new Vector2(screen.Width / 25, screen.Height / 25 + 75), @"Menu/Buttons/OptionsBtn", BUTTON.OPTIONS);
            buttons.Add(tempButton);

            tempButton = new Buttons();
            tempButton.Initialize(new Vector2(screen.Width / 25, screen.Height / 25 + 150), @"Menu/Buttons/StartBtn", BUTTON.START);
            buttons.Add(tempButton);

            selected = new Buttons();
            selected.Initialize(new Vector2(-35, screen.Height / 25 + 125), @"Menu/Selected", BUTTON.START);
            content.Add(selected);

            foreach (Buttons b in buttons)
                content.Add(b);

            selected.Texture.AlphaBlendState = AlphaBlendState.Alpha;
        }

        public BUTTON Update(UpdateState state)
        {
#if XBOX360
            if (state.PlayerInput[PlayerIndex.One].InputState.ThumbSticks.LeftStick.Y == -1)
#else
            if (state.KeyboardState.KeyState.Down.OnPressed || state.PlayerInput[0].InputState.Buttons.DpadDown.OnPressed)
#endif
                if (selected.SELECTED != BUTTON.EXIT)
                {
                    SoundManager.Sound.PlaySound("MenuSound1");
                    selected.POSITION -= new Vector2(0, 75);
                    if (selected.SELECTED == BUTTON.OPTIONS)
                        selected.SELECTED = BUTTON.EXIT;
                    else
                        selected.SELECTED = BUTTON.OPTIONS;
                }
                else
                {
                    SoundManager.Sound.PlaySound("MenuSound1");
                    selected.POSITION += new Vector2(0, 150);
                    selected.SELECTED = BUTTON.START;
                }
#if XBOX360
            else if (state.PlayerInput[PlayerIndex.One].InputState.ThumbSticks.LeftStick.Y == 1)
#else
            else if (state.KeyboardState.KeyState.Up.OnPressed || state.PlayerInput[0].InputState.Buttons.DpadUp.OnPressed)
#endif
                if (selected.SELECTED == BUTTON.START)
                {
                    SoundManager.Sound.PlaySound("MenuSound1");
                    selected.POSITION -= new Vector2(0, 150);
                    selected.SELECTED = BUTTON.EXIT;
                }
                else
                {
                    SoundManager.Sound.PlaySound("MenuSound1");
                    selected.POSITION += new Vector2(0, 75);
                    if (selected.SELECTED == BUTTON.OPTIONS)
                        selected.SELECTED = BUTTON.START;
                    else
                        selected.SELECTED = BUTTON.OPTIONS;
                }
#if XBOX360
            if (state.PlayerInput[PlayerIndex.One].InputState.Buttons.A.OnPressed)
#else
            if (state.KeyboardState.KeyState.Enter.OnPressed || state.PlayerInput[0].InputState.Buttons.A.OnPressed)
#endif
            {
                SoundManager.Sound.PlaySound("MenuSound1");
                return selected.SELECTED;
            }
            else
                return BUTTON.NULL;
        }

        public void Draw(DrawState state)
        {
            Bg.Draw(state);
            selected.Draw(state);
            foreach (Buttons b in buttons)
                b.Draw(state);
        }

        public bool CullTest(ICuller culler)
        {
            return true;
        }
    }

    class OptionsMenu
    {
        Background Bg;
        Buttons exit;
        Buttons selected;
        Buttons controls;
        Buttons options;
        Buttons howTo;

        public OptionsMenu() { }

        public void Initialize(ContentRegister content)
        {
            Bg = new Background();
            Bg.AddTexture(@"Menu/Screens/menu");
            content.Add(Bg);

            exit = new Buttons();
            exit.Initialize(Vector2.Zero, @"Menu/Buttons/BackBtn", BUTTON.EXIT);
            content.Add(exit);
            exit.Texture.HorizontalAlignment = HorizontalAlignment.Centre;
            exit.Texture.VerticalAlignment = VerticalAlignment.Centre;
            exit.POSITION = new Vector2(0, -150);

            controls = new Buttons();
            controls.Initialize(Vector2.Zero, @"Menu/Buttons/ControlsBtn", BUTTON.CONTROLS);
            content.Add(controls);
            controls.Texture.HorizontalAlignment = HorizontalAlignment.Centre;
            controls.Texture.VerticalAlignment = VerticalAlignment.Centre;
            controls.POSITION = new Vector2(0, -75);

            options = new Buttons();
            options.Initialize(Vector2.Zero, @"Menu/Buttons/SettingsBtn", BUTTON.OPTIONS);
            content.Add(options);
            options.Texture.HorizontalAlignment = HorizontalAlignment.Centre;
            options.Texture.VerticalAlignment = VerticalAlignment.Centre;
            options.POSITION = new Vector2(0, 0);

            howTo = new Buttons();
            howTo.Initialize(Vector2.Zero, @"Menu/Buttons/HowToPlayBtn", BUTTON.HOWTO);
            content.Add(howTo);
            howTo.Texture.HorizontalAlignment = HorizontalAlignment.Centre;
            howTo.Texture.VerticalAlignment = VerticalAlignment.Centre;
            howTo.POSITION = new Vector2(0, 75);

            selected = new Buttons();
            selected.Initialize(Vector2.Zero, @"Menu/Selected", BUTTON.START);
            content.Add(selected);
            selected.Texture.HorizontalAlignment = HorizontalAlignment.Centre;
            selected.Texture.VerticalAlignment = VerticalAlignment.Centre;
            selected.SELECTED = BUTTON.HOWTO;
            selected.POSITION = howTo.POSITION;
        }

        public BUTTON Update(UpdateState state)
        {
#if XBOX360
            if (state.PlayerInput[PlayerIndex.One].InputState.ThumbSticks.LeftStick.Y == -1)
#else
            if (state.KeyboardState.KeyState.Down.OnPressed || state.PlayerInput[0].InputState.Buttons.DpadDown.OnPressed)
#endif
            {
                switch (selected.SELECTED)
                {
                    case BUTTON.OPTIONS:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.CONTROLS;
                        selected.POSITION = controls.POSITION;
                        break;
                    case BUTTON.EXIT:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.HOWTO;
                        selected.POSITION = howTo.POSITION;
                        break;
                    case BUTTON.CONTROLS:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.EXIT;
                        selected.POSITION = exit.POSITION;
                        break;
                    case BUTTON.HOWTO:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.OPTIONS;
                        selected.POSITION = options.POSITION;
                        break;
                }
            }
#if XBOX360
            else if (state.PlayerInput[PlayerIndex.One].InputState.ThumbSticks.LeftStick.Y == 1)
#else
            else if (state.KeyboardState.KeyState.Up.OnPressed || state.PlayerInput[0].InputState.Buttons.DpadUp.OnPressed)
#endif
            {
                switch (selected.SELECTED)
                {
                    case BUTTON.OPTIONS:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.HOWTO;
                        selected.POSITION = howTo.POSITION;
                        break;
                    case BUTTON.HOWTO:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.EXIT;
                        selected.POSITION = exit.POSITION;
                        break;
                    case BUTTON.EXIT:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.CONTROLS;
                        selected.POSITION = controls.POSITION;
                        break;
                    case BUTTON.CONTROLS:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.OPTIONS;
                        selected.POSITION = options.POSITION;
                        break;
                }
            }
#if XBOX360
            if (state.PlayerInput[PlayerIndex.One].InputState.Buttons.A.OnPressed)
#else
            if (state.KeyboardState.KeyState.Enter.OnPressed || state.PlayerInput[0].InputState.Buttons.A.OnPressed)
#endif
            {
                SoundManager.Sound.PlaySound("MenuSound1");
                switch (selected.SELECTED)
                {
                    case BUTTON.CONTROLS:
                        return BUTTON.CONTROLS;
                    case BUTTON.OPTIONS:
                        return BUTTON.OPTIONS;
                    case BUTTON.HOWTO:
                        return BUTTON.HOWTO;
                    case BUTTON.EXIT:
                        return BUTTON.EXIT;
                }
            }
            return BUTTON.NULL;
        }

        public void Draw(DrawState state)
        {
            Bg.Draw(state);
            selected.Draw(state);
            howTo.Draw(state);
            options.Draw(state);
            controls.Draw(state);
            exit.Draw(state);
        }
    }

    class SettingsMenu
    {
        Background Bg;
        Slider slider;
        Slider sliderFx;
        Buttons exit;
        Buttons selected;

        public SettingsMenu() { }

        public void Initialize(ContentRegister content)
        {
            Bg = new Background();
            Bg.AddTexture(@"Menu/Screens/menu");
            content.Add(Bg);

            exit = new Buttons();
            exit.Initialize(Vector2.Zero, @"Menu/Buttons/BackBtn", BUTTON.EXIT);
            content.Add(exit);
            exit.Texture.HorizontalAlignment = HorizontalAlignment.Centre;
            exit.Texture.VerticalAlignment = VerticalAlignment.Centre;
            exit.POSITION = new Vector2(0, -150);

            slider = new Slider();
            slider.Initialize(new Vector2(0, -75));
            content.Add(slider);

            sliderFx = new Slider();
            sliderFx.Initialize(new Vector2(0, 0));
            content.Add(sliderFx);

            selected = new Buttons();
            selected.Initialize(Vector2.Zero, @"Menu/Selected", BUTTON.START);
            content.Add(selected);
            selected.Texture.HorizontalAlignment = HorizontalAlignment.Centre;
            selected.Texture.VerticalAlignment = VerticalAlignment.Centre;

            selected.SELECTED = BUTTON.SLIDERSOUND;
            selected.POSITION = sliderFx.BARPOSITION;
        }

        public BUTTON Update(UpdateState state)
        {
#if XBOX360
            if (state.PlayerInput[PlayerIndex.One].InputState.ThumbSticks.LeftStick.Y == -1)
#else
            if (state.KeyboardState.KeyState.Down.OnPressed || state.PlayerInput[0].InputState.Buttons.DpadDown.OnPressed)
#endif
            {
                switch (selected.SELECTED)
                {
                    case BUTTON.SLIDERSOUND:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.OPTIONS;
                        selected.POSITION = slider.BARPOSITION;
                        break;
                    case BUTTON.OPTIONS:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.EXIT;
                        selected.POSITION = exit.POSITION;
                        SoundManager.Sound.PlaySound("MenuSound1");
                        break;
                    case BUTTON.EXIT:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.SLIDERSOUND;
                        selected.POSITION = sliderFx.BARPOSITION;
                        break;
                }
            }
#if XBOX360
            else if (state.PlayerInput[PlayerIndex.One].InputState.ThumbSticks.LeftStick.Y == 1)
#else
            else if (state.KeyboardState.KeyState.Up.OnPressed || state.PlayerInput[0].InputState.Buttons.DpadUp.OnPressed)
#endif
            {
                switch (selected.SELECTED)
                {
                    case BUTTON.SLIDERSOUND:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.EXIT;
                        selected.POSITION = exit.POSITION;
                        break;
                    case BUTTON.OPTIONS:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.SLIDERSOUND;
                        selected.POSITION = sliderFx.BARPOSITION;
                        break;
                    case BUTTON.EXIT:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.OPTIONS;
                        selected.POSITION = slider.BARPOSITION;
                        break;
                }
            }

            if (selected.SELECTED == BUTTON.OPTIONS)
            {
                Vector2 sliderPos = slider.Update(state);
                sliderPos.X = sliderPos.X / 400 + 0.5f;
                MathHelper.Clamp(sliderPos.X, 0.0f, 1.0f);
                Console.WriteLine(sliderPos.X);
                SoundManager.Sound.SetMusicVolume(sliderPos.X);
            }

            if (selected.SELECTED == BUTTON.SLIDERSOUND)
            {
                Vector2 sliderFxPos = sliderFx.Update(state);
                sliderFxPos.X = sliderFxPos.X / 400 + 0.5f;
                MathHelper.Clamp(sliderFxPos.X, 0.0f, 1.0f);
                Console.WriteLine(sliderFxPos.X);
                SoundManager.Sound.SetFxVolume(sliderFxPos.X);
            }
#if XBOX360
            if (state.PlayerInput[PlayerIndex.One].InputState.Buttons.A.OnPressed)
#else
            if (state.KeyboardState.KeyState.Enter.OnPressed || state.PlayerInput[0].InputState.Buttons.A.OnPressed)
#endif
            {
                SoundManager.Sound.PlaySound("MenuSound1");
                switch (selected.SELECTED)
                {
                    case BUTTON.EXIT:
                        return BUTTON.EXIT;
                }
            }
            return BUTTON.NULL;
        }

        public void Draw(DrawState state)
        {
            Bg.Draw(state);
            selected.Draw(state);
            slider.Draw(state);
            sliderFx.Draw(state);
            exit.Draw(state);
        }
    }

    class ControlsMenu
    {
        Background Bg;
        Buttons exit;
        Buttons selected;

        public ControlsMenu() { }

        public void Initialize(ContentRegister content)
        {
            Bg = new Background();
            Bg.AddTexture(@"Menu/Screens/Controls");
            content.Add(Bg);

            exit = new Buttons();
            exit.Initialize(Vector2.Zero, @"Menu/Buttons/BackBtn", BUTTON.EXIT);
            content.Add(exit);
            exit.Texture.HorizontalAlignment = HorizontalAlignment.Centre;
            exit.Texture.VerticalAlignment = VerticalAlignment.Centre;
            exit.POSITION = new Vector2(0, -300);

            selected = new Buttons();
            selected.Initialize(Vector2.Zero, @"Menu/Selected", BUTTON.START);
            content.Add(selected);
            selected.Texture.HorizontalAlignment = HorizontalAlignment.Centre;
            selected.Texture.VerticalAlignment = VerticalAlignment.Centre;

            selected.SELECTED = BUTTON.EXIT;
            selected.POSITION = exit.POSITION;
        }

        public BUTTON Update(UpdateState state)
        {
#if XBOX360
            if (state.PlayerInput[PlayerIndex.One].InputState.Buttons.A.OnPressed)
#else
            if (state.KeyboardState.KeyState.Enter.OnPressed || state.PlayerInput[0].InputState.Buttons.A.OnPressed)
#endif
            {
                SoundManager.Sound.PlaySound("MenuSound1");
                switch (selected.SELECTED)
                {
                    case BUTTON.EXIT:
                        return BUTTON.EXIT;
                }
            }
            return BUTTON.NULL;
        }

        public void Draw(DrawState state)
        {
            Bg.Draw(state);
            selected.Draw(state);
            exit.Draw(state);
        }
    }

    class HowToMenu
    {
        Background Bg;
        Buttons exit;
        Buttons selected;

        public HowToMenu() { }

        public void Initialize(ContentRegister content)
        {
            Bg = new Background();
            Bg.AddTexture(@"Menu/Screens/HowToPlay");
            content.Add(Bg);

            exit = new Buttons();
            exit.Initialize(Vector2.Zero, @"Menu/Buttons/BackBtn", BUTTON.EXIT);
            content.Add(exit);
            exit.Texture.HorizontalAlignment = HorizontalAlignment.Centre;
            exit.Texture.VerticalAlignment = VerticalAlignment.Centre;
            exit.POSITION = new Vector2(0, -300);

            selected = new Buttons();
            selected.Initialize(Vector2.Zero, @"Menu/Selected", BUTTON.START);
            content.Add(selected);
            selected.Texture.HorizontalAlignment = HorizontalAlignment.Centre;
            selected.Texture.VerticalAlignment = VerticalAlignment.Centre;

            selected.SELECTED = BUTTON.EXIT;
            selected.POSITION = exit.POSITION;
        }

        public BUTTON Update(UpdateState state)
        {
#if XBOX360
            if (state.PlayerInput[PlayerIndex.One].InputState.Buttons.A.OnPressed)
#else
            if (state.KeyboardState.KeyState.Enter.OnPressed || state.PlayerInput[0].InputState.Buttons.A.OnPressed)
#endif
            {
                SoundManager.Sound.PlaySound("MenuSound1");
                switch (selected.SELECTED)
                {
                    case BUTTON.EXIT:
                        return BUTTON.EXIT;
                }
            }
            return BUTTON.NULL;
        }

        public void Draw(DrawState state)
        {
            Bg.Draw(state);
            selected.Draw(state);
            exit.Draw(state);
        }
    }

    class Background : IContentOwner
    {
        List<TexturedElement> textures;
        List<string> textureName;

        public Background()
        {
            textures = new List<TexturedElement>();
            textureName = new List<string>();
        }

        public TexturedElement GetTexture(int num)
        {
            return textures[num];
        }

        public void AddTexture(string name)
        {
            textureName.Add(name);
        }

        public virtual void LoadContent(ContentState state)
        {
            foreach (string t in textureName)
            {
                Texture2D temp = state.Load<Texture2D>(t);
                textures.Add(new TexturedElement(temp, new Vector2(1, 1)));
                textures[textures.Count - 1].NormalisedCoordinates = true;
            }
        }

        public void Update(UpdateState state)
        {
        }

        public void Draw(DrawState state)
        {
            foreach (TexturedElement t in textures)
                t.Draw(state);
        }
    }

    class Buttons : IContentOwner
    {
        Vector2 position;
        Vector2 size;
        BUTTON button;

        TexturedElement texture;
        string textureName;

        public TexturedElement Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public BUTTON SELECTED
        {
            get { return button; }
            set { button = value; }
        }

        public Vector2 POSITION
        {
            get { return texture.Position; }
            set { texture.Position = value; }
        }

        public Buttons()
        {
        }

        public void Initialize(Vector2 pos, Vector2 size, string name, BUTTON b)
        {
            this.size = size;
            textureName = name;
            position = pos;
            button = b;
        }

        public void Initialize(Vector2 pos, string name, BUTTON b)
        {
            textureName = name;
            position = pos;
            button = b;
        }

        public virtual void LoadContent(ContentState state)
        {
            Texture2D tempTex = state.Load<Texture2D>(textureName);
            if (size == Vector2.Zero)
                this.size = new Vector2(tempTex.Bounds.Width, tempTex.Bounds.Height);
            texture = new TexturedElement(tempTex, size);
            texture.Position = position;

            texture.AlphaBlendState = AlphaBlendState.Alpha;
        }

        public void Draw(DrawState state)
        {
            texture.Draw(state);
        }
    }

    class Slider : IContentOwner
    {
        TexturedElement sliderBar;
        TexturedElement slider;
        Vector2 pos;

        public Vector2 BARPOSITION
        {
            get { return sliderBar.Position; }
        }

        public Vector2 POSITION
        {
            get { return pos; }
            set { pos = value; }
        }

        public Slider() { }

        public void Initialize(Vector2 pos)
        {
            this.pos = pos;
        }

        public virtual void LoadContent(ContentState state)
        {
            Texture2D tempTex = state.Load<Texture2D>(@"Menu/Slider/SliderBar");
            Vector2 size = new Vector2(tempTex.Bounds.Width, tempTex.Bounds.Height);
            sliderBar = new TexturedElement(tempTex, size);
            sliderBar.HorizontalAlignment = HorizontalAlignment.Centre;
            sliderBar.VerticalAlignment = VerticalAlignment.Centre;

            tempTex = state.Load<Texture2D>(@"Menu/Slider/Slider");
            size = new Vector2(tempTex.Bounds.Width, tempTex.Bounds.Height);
            slider = new TexturedElement(tempTex, size);
            slider.HorizontalAlignment = HorizontalAlignment.Centre;
            slider.VerticalAlignment = VerticalAlignment.Centre;
            slider.Position = pos;
            sliderBar.Position = pos;
        }

        public Vector2 Update(UpdateState state)
        {
            if (state.KeyboardState.KeyState.Right.IsDown || state.PlayerInput[0].InputState.Buttons.DpadRight.IsDown)
            {
                if (slider.Position.X < 170.0f)
                {
                    pos.X += 1.0f;
                    slider.Position = pos;
                }
            }
            else if (state.KeyboardState.KeyState.Left.IsDown || state.PlayerInput[0].InputState.Buttons.DpadLeft.IsDown)
            {
                if (slider.Position.X > -170.0f)
                {
                    pos.X -= 1.0f;
                    slider.Position = pos;
                }
            }
            return slider.Position;
        }

        public void Draw(DrawState state)
        {
            sliderBar.Draw(state);
            slider.Draw(state);


        }
    }

    class GameMenu
    {
        Background Bg;
        Buttons exit;
        Buttons resume;
        Buttons selected;

        public GameMenu() { }

        public void Initialize(ContentRegister content)
        {
            Bg = new Background();
            Bg.AddTexture(@"Menu/Screens/menu");
            content.Add(Bg);

            exit = new Buttons();
            exit.Initialize(Vector2.Zero, @"Menu/Buttons/BackBtn", BUTTON.EXIT);
            content.Add(exit);
            exit.Texture.HorizontalAlignment = HorizontalAlignment.Centre;
            exit.Texture.VerticalAlignment = VerticalAlignment.Centre;
            exit.POSITION = new Vector2(0, -150);

            resume = new Buttons();
            resume.Initialize(Vector2.Zero, @"Menu/Buttons/ControlsBtn", BUTTON.CONTROLS);
            content.Add(resume);
            resume.Texture.HorizontalAlignment = HorizontalAlignment.Centre;
            resume.Texture.VerticalAlignment = VerticalAlignment.Centre;
            resume.POSITION = new Vector2(0, -75);

            selected = new Buttons();
            selected.Initialize(Vector2.Zero, @"Menu/Selected", BUTTON.START);
            content.Add(selected);
            selected.Texture.HorizontalAlignment = HorizontalAlignment.Centre;
            selected.Texture.VerticalAlignment = VerticalAlignment.Centre;
            selected.SELECTED = BUTTON.HOWTO;
            selected.POSITION = resume.POSITION;
        }

        public BUTTON Update(UpdateState state)
        {
#if XBOX360
            if (state.PlayerInput[PlayerIndex.One].InputState.ThumbSticks.LeftStick.Y == -1)
#else
            if (state.KeyboardState.KeyState.Down.OnPressed || state.PlayerInput[0].InputState.Buttons.DpadDown.OnPressed)
#endif
            {
                switch (selected.SELECTED)
                {
                    case BUTTON.EXIT:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.START;
                        selected.POSITION = resume.POSITION;
                        break;
                    case BUTTON.START:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.EXIT;
                        selected.POSITION = exit.POSITION;
                        break;
                }
            }
#if XBOX360
            else if (state.PlayerInput[PlayerIndex.One].InputState.ThumbSticks.LeftStick.Y == 1)
#else
            else if (state.KeyboardState.KeyState.Up.OnPressed || state.PlayerInput[0].InputState.Buttons.DpadUp.OnPressed)
#endif
            {
                switch (selected.SELECTED)
                {
                    case BUTTON.EXIT:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.START;
                        selected.POSITION = resume.POSITION;
                        break;
                    case BUTTON.START:
                        SoundManager.Sound.PlaySound("MenuSound1");
                        selected.SELECTED = BUTTON.EXIT;
                        selected.POSITION = exit.POSITION;
                        break;
                }
            }
#if XBOX360
            if (state.PlayerInput[PlayerIndex.One].InputState.Buttons.A.OnPressed)
#else
            if (state.KeyboardState.KeyState.Enter.OnPressed || state.PlayerInput[0].InputState.Buttons.A.OnPressed)
#endif
            {
                SoundManager.Sound.PlaySound("MenuSound1");
                switch (selected.SELECTED)
                {
                    case BUTTON.START:
                        return BUTTON.START;
                    case BUTTON.EXIT:
                        return BUTTON.EXIT;
                }
            }
            return BUTTON.NULL;
        }

        public void Draw(DrawState state)
        {
            Bg.Draw(state);
            selected.Draw(state);
            resume.Draw(state);
            exit.Draw(state);
        }
    }
}
