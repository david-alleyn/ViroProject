using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Xen;
using Xen.Graphics;
using Xen.Ex.Graphics2D;

namespace Viro
{
    class Storyboard : IDraw, IContentOwner
    {
        Vector2 position;
        Vector2 size;

        int type;
        int counter = 0;
        int stillNum;
        public bool isComplete = false;

        float mAlphaValue = 0.0f;
        float mFadeIncrement = 0.1f;
        double mFadeDelay = 0.1;

        List<SpriteElement> textures = new List<SpriteElement>();
        List<string> textureNames = new List<string>();

        public Storyboard(Vector2 pos, Vector2 size, string name1, string name2, string name3, int Type)
        {
            Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            this.size = size;
            textureNames.Add(name1);
            textureNames.Add(name2);
            textureNames.Add(name3);
            position = pos;
            type = Type;
            stillNum = 3;
        }

        public Storyboard(Vector2 pos, Vector2 size, string name1, int Type)
        {
            Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            this.size = size;
            textureNames.Add(name1);
            position = pos;
            type = Type;
            stillNum = 1;
            mFadeDelay = 3.5f;
        }

        public virtual void LoadContent(ContentState state)
        {
            if (type == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    Texture2D tempTex = state.Load<Texture2D>("Storyboard/" + textureNames[i]);
                    if (size == Vector2.Zero)
                        this.size = new Vector2(tempTex.Bounds.Width, tempTex.Bounds.Height);
                    textures.Add(new SpriteElement(tempTex));
                    textures[i].AddSprite(position, size);
                    textures[i].SetSpritePosition(0, position);
                    textures[i].AlphaBlendState = AlphaBlendState.Alpha;
                }
            }
            else if (type == 2)
            {
                Texture2D tempTex = state.Load<Texture2D>("Storyboard/" + textureNames[0]);
                if (size == Vector2.Zero)
                   this.size = new Vector2(tempTex.Bounds.Width, tempTex.Bounds.Height);
                
                textures.Add(new SpriteElement(tempTex));

                textures[0].AddSprite(position, size);
                textures[0].SetSpritePosition(0, position);
                textures[0].AlphaBlendState = AlphaBlendState.Alpha;
                textures[0].SetSpriteColour(0, new Vector4(1, 1, 1, 0.0f));
            }
        }

        public void Draw(DrawState state)
        {
            textures[counter].Draw(state);
        }

        public void Update(UpdateState state)
        {
            mFadeDelay -= state.DeltaTimeSeconds;

#if !XBOX360
            if (state.KeyboardState.KeyState.Enter.OnPressed || state.PlayerInput[0].InputState.Buttons.A.OnPressed)
#else
            if (state.PlayerInput[0].InputState.Buttons.A.OnPressed)
#endif
            {
                counter++;
            }

            if (mFadeDelay <= 0)
            {
                mFadeDelay = 0.01;

                mAlphaValue += mFadeIncrement;

                if (mAlphaValue >= 1.0f || mAlphaValue <= 0.0f)
                {
                    mFadeDelay = 6.0;
                    mFadeIncrement *= -1;
                    if (mAlphaValue <= 0)
                    {
                        counter++;
                        mFadeDelay = 0.01;
                    }
                }
            }

            if (counter == stillNum)
                isComplete = true;

            if(!isComplete)
                textures[counter].SetSpriteColour(0, new Vector4(1, 1, 1, mAlphaValue));
        }

        public bool CullTest(ICuller culler)
        {
            return true;
        }
    }
}
