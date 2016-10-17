using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Xen.Ex.Graphics2D;
using Xen;
using Xen.Graphics;

using Viro.Actors;

namespace Viro
{
    public class HUD : IDraw, IContentOwner
    {
        public int playerhealth;
        public int playerLives;
        public double playerAntiGrav;

        List<TexturedElement> healthBars = new List<TexturedElement>();
        List<TexturedElement> AntiGravBars = new List<TexturedElement>();
        List<TexturedElement> lives = new List<TexturedElement>();
        List<string> barNames = new List<string>();
        List<string> AGbarNames = new List<string>();
        string liveName;
        int barCounter = 0;
        int antiGravCounter = 0;
        int livesCounter = 0;
        Vector2 size;

        public HUD(Vector2 size, string name1, string name2, string name3, string name4, string name5, string name6, string name7, string name8, string name9, string name10, string liveImage)
        {
            this.size = size;
            barNames.Add(name1);
            barNames.Add(name2);
            barNames.Add(name3);
            barNames.Add(name4);
            barNames.Add(name5);
            barNames.Add(name6);
            barNames.Add(name7);
            barNames.Add(name8);
            barNames.Add(name9);
            barNames.Add(name10);
            liveName = liveImage;
        }

        public virtual void LoadContent(ContentState state)
        {
            for (int k = 1; k < 11; k++)
            {
                string tempName = "AntiGravBar" + (k);
                AGbarNames.Add(tempName);
            }

            for (int i = 0; i < 10; i++)
            {
                Texture2D tempTex = state.Load<Texture2D>("Health/" + barNames[i]);
                healthBars.Add(new TexturedElement(tempTex, size));
                healthBars[i].Position = new Vector2((i / 30.0f), 0.9f);
                healthBars[i].AlphaBlendState = AlphaBlendState.Alpha;
                healthBars[i].NormalisedCoordinates = true;
            }
            for (int x = 0; x < 3; x++)
            {
                Texture2D tempTex = state.Load<Texture2D>("Health/" + liveName);
                lives.Add(new TexturedElement(tempTex, size));
                lives[x].Position = new Vector2(0.9f - (x / 30.0f), 0.9f);
                lives[x].AlphaBlendState = AlphaBlendState.Alpha;
                lives[x].NormalisedCoordinates = true;
            }
            for (int i = 0; i < 10; i++)
            {
                Texture2D tempTex = state.Load<Texture2D>("Health/" + AGbarNames[i]);
                AntiGravBars.Add(new TexturedElement(tempTex, size));
                AntiGravBars[i].Position = new Vector2((i / 30.0f), 0.8f);
                AntiGravBars[i].AlphaBlendState = AlphaBlendState.Alpha;
                AntiGravBars[i].NormalisedCoordinates = true;
            }
        }

        public void Update()
        {

            if (playerhealth == 100)
            {
                barCounter = 10;
            }
            else if (playerhealth < 100 && playerhealth >= 90)
            {
                barCounter = 9;
            }
            else if (playerhealth < 90 && playerhealth >= 80)
            {
                barCounter = 8;
            }
            else if (playerhealth < 80 && playerhealth >= 70)
            {
                barCounter = 7;
            }
            else if (playerhealth < 70 && playerhealth >= 60)
            {
                barCounter = 6;
            }
            else if (playerhealth < 60 && playerhealth >= 50)
            {
                barCounter = 5;
            }
            else if (playerhealth < 50 && playerhealth >= 40)
            {
                barCounter = 4;
            }
            else if (playerhealth < 40 && playerhealth >= 30)
            {
                barCounter = 3;
            }
            else if (playerhealth < 30 && playerhealth >= 20)
            {
                barCounter = 2;
            }
            else if (playerhealth < 20 && playerhealth > 10)
            {
                barCounter = 1;
            }
            else if (playerhealth <= 0)
            {
                barCounter = 0;
            }

            if (playerLives == 2)
            {
                livesCounter = 2;
            }
            else if(playerLives == 1)
            {
                livesCounter = 1;
            }
            else if (playerLives == 0)
            {
                livesCounter = 0;
            }

            if (playerAntiGrav == 100)
            {
                antiGravCounter = 10;
            }
            else if (playerAntiGrav < 100 && playerAntiGrav >= 90)
            {
                antiGravCounter = 9;
            }
            else if (playerAntiGrav < 90 && playerAntiGrav >= 80)
            {
                antiGravCounter = 8;
            }
            else if (playerAntiGrav < 80 && playerAntiGrav >= 70)
            {
                antiGravCounter = 7;
            }
            else if (playerAntiGrav < 70 && playerAntiGrav >= 60)
            {
                antiGravCounter = 6;
            }
            else if (playerAntiGrav < 60 && playerAntiGrav >= 50)
            {
                antiGravCounter = 5;
            }
            else if (playerAntiGrav < 50 && playerAntiGrav >= 40)
            {
                antiGravCounter = 4;
            }
            else if (playerAntiGrav < 40 && playerAntiGrav >= 30)
            {
                antiGravCounter = 3;
            }
            else if (playerAntiGrav < 30 && playerAntiGrav >= 20)
            {
                antiGravCounter = 2;
            }
            else if (playerAntiGrav < 20 && playerAntiGrav > 10)
            {
                antiGravCounter = 1;
            }
            else if (playerAntiGrav <= 0)
            {
                antiGravCounter = 0;
            }
        }

        public void Draw(DrawState state)
        {
            if (barCounter != 0)
            {
                for (int i = 0; i < barCounter; i++)
                {
                    healthBars[i].Draw(state);
                }
            }
            else
            {

            }
            if (livesCounter != 0)
            {
                for (int i = 0; i < livesCounter; i++)
                {
                    lives[i].Draw(state);
                }
            }
            else
            {

            }
            if (antiGravCounter != 0)
            {
                for (int i = 0; i < antiGravCounter; i++)
                {
                    AntiGravBars[i].Draw(state);
                }
            }
        }

        public bool CullTest(ICuller culler)
        {
            return true;
        }
    }
}
