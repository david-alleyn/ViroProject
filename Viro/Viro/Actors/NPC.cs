using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Xen;
using Xen.Input.State;
using Viro.Physics;

namespace Viro.Actors
{
    public class NPC : Actor, IDraw
    {
        public bool IWantAggression = false;//false if u dont want the enemies to chase you down, true if you do.
        public bool bMoveRight = false;
        public bool bMoveLeft = true;
        public bool bMoving = true;
        public bool bEnraged = false;//chase the player
        public bool bReset = false;//reset when the player has been chased for 1200.0f
        public static Player player = new Player();
        public Vector3 OldPosition = new Vector3();
        public double chaseDistance = 1200.0f;

        protected double minTimeBetweenDirectionChange = 0.5f; //At least 0.25 seconds between attacks;
        protected double timeSinceLastDirectionChange = 0;

        public NPC(ContentRegister content, Vector3 position, String modelContentName) : 
            base(content, position, modelContentName) 
        {
            deathSound = "Scream1";
        }

        public NPC() : base() 
        {
            deathSound = "Scream1";
        }

        public static void setPlayer(ref Player p)
        {
            player = p;
        }

        public void init()
        {
            OldPosition = position;
            //should be walk inform matt later that bug needs to be fixed
            currentAnimation = model.GetAnimationController().PlayLoopingAnimation(model.GetAnimationController().AnimationIndex("Walk"));
        }

        public void ChangeDirection()
        {
            if (timeSinceLastDirectionChange >= minTimeBetweenDirectionChange)
            {
                timeSinceLastDirectionChange = 0;

                if (bEnraged == false)
                {
                    if (bMoveLeft == true)
                    {
                        bMoveLeft = false;
                        bMoveRight = true;
                    }
                    else if (bMoveRight == true)
                    {
                        bMoveLeft = true;
                        bMoveRight = false;
                    }
                }
            }
        }

        public override void Update(UpdateState state)
        {
            base.Update(state);

            if (timeSinceLastDirectionChange < minTimeBetweenDirectionChange)
            {
                timeSinceLastDirectionChange += state.DeltaTimeSeconds;
            }

            if (bReset == true && IsDead != true)
            { ResetNPC(); }

            if (bEnraged == true)
            {
                if (player.position.X < body.Position.X)
                { bMoveLeft = true; bMoveRight = false; }
                if (player.position.X >= body.Position.X)
                { bMoveLeft = false; bMoveRight = true; }
                if (player.position.Y > body.Position.Y)
                { ((ActorBody)body).DoJump(); }
            }

            if (IsDead != true)
            {
                if (bMoving == true)
                {
                    if (bMoveLeft == true)
                    {
                        ((ActorBody)body).MoveLeft();
                    }
                    else if (bMoveRight == true)
                    {
                        ((ActorBody)body).MoveRight();
                    }
                }
            }
            //Vector2 rotation = new Vector2(0.0f);
            //Vector3 position = new Vector3(0.0f);
            //Matrix tempMatrix = new Matrix();
            //tempMatrix = Matrix.Identity;

            //worldMatrix.Translation += position;
            //Matrix.Invert(ref worldMatrix, out tempMatrix);
            //tempMatrix *= Matrix.CreateRotationY(rotation.Y);
            //worldMatrix *= (tempMatrix * worldMatrix);
        }

        public void ResetNPC()
        {
            ((ActorBody)body).MoveTo(OldPosition, body.OldOrientation);
            bReset = false;
        }
        
    }

    
}
