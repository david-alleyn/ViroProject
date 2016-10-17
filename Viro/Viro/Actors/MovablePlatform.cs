using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Xen;
using Xen.Input.State;
using Xen.Ex.Graphics2D;
using Xen.Ex;
using Viro.Physics;
using Viro.Objects;

using JigLibX.Physics;
using JigLibX.Collision;
using JigLibX.Geometry;

using Xen.Graphics;
using Xen.Ex.Graphics;
using Xen.Ex.Graphics.Content;
using Viro.Objects.Physics_Stuff.Body_Types;

namespace Viro.Actors
{
    public class MovablePlatform : PhysicObject, IContentOwner, IDraw
    {
        public Player player = new Player();
        public Vector3 oldPosition = new Vector3();
        public Vector3 OriginalPosition = Vector3.Zero;
        public bool bMoveRight = false;
        public bool bMoveLeft = true;
        public bool bMoving = false;
        public bool hasPlayer = true;
        public bool playerNotJumping = true;
        public bool playerNotMoving = true;
        private bool doOnce = true;

        protected double minTimeBetweenDirectionChange = 0.5f; //At least 0.25 seconds between attacks;
        protected double timeSinceLastDirectionChange = 0;
        protected double minTimeBetweenJumpAntiGravDelay = 0.5f;
        protected double timeSinceLastJumpAntiGravDelay = 0;
        protected double minTimeBetweenPlayerMove = 0.5f;
        protected double timeSinceLastPlayerMove = 0;

        public Vector3 playerPosition = new Vector3();
        public int countStuck = 0;

        public MovablePlatform(ContentRegister content, Vector3 position, String modelContentName) :
            base(content, position, modelContentName) { OriginalPosition = position; }

        public MovablePlatform() : base() { OriginalPosition = position; }

        public void init()
        {
            OriginalPosition = position;
            ((ActorBody)body).Immovable = true;
        }

        public void ChangeDirection()
        {
            if (timeSinceLastDirectionChange >= minTimeBetweenDirectionChange)
            {
                timeSinceLastDirectionChange = 0;

                if (bMoveLeft == true)//switch back
                {
                    bMoveRight = true; bMoveLeft = false;
                }
                else if (bMoveRight == true)//when at the edge switch direction
                {
                    bMoveLeft = true; bMoveRight = false;
                }
            }
        }

        public override void Update(UpdateState state)
        {
            base.Update(state);

            if (doOnce)
            {
                OriginalPosition = position;
                //((MPBody)body).Immovable = true;
                doOnce = false;
            }

            ((MPBody)body).MoveTo(new Vector3(position.X, OriginalPosition.Y, position.Z), orientation);

            if (hasPlayer == true && ((ActorBody)player.PhysicsBody).doJump == true)
            {
                playerNotJumping = false;
            }

            if (bMoving)
            {
                ((MPBody)body).Immovable = false;
                if (position.Y > OriginalPosition.Y)
                {
                    ((MPBody)body).MoveDown();
                }
                if (position.Y < OriginalPosition.Y)
                {
                    ((MPBody)body).MoveUp();
                }
                if (this.GetDistanceFromObject(OriginalPosition) >= 750.0f)
                {
                    ((MPBody)body).MoveTo(OriginalPosition, orientation);
                }

                if (oldPosition.X == position.X)
                {
                    if (countStuck < 21) { countStuck++; }
                    if (countStuck >= 21)
                    {
                        countStuck = 0;
                        ((MPBody)body).MoveTo(OriginalPosition, orientation);
                    }
                }
                else
                {
                    countStuck = 0;
                }
            }
            else
            {
                ((MPBody)body).Immovable = true;// this fixed the jump bug
            }

            if (playerNotMoving == false)
            {
                //if x seconds have gone by since the player moved
                if (timeSinceLastPlayerMove < minTimeBetweenPlayerMove)
                {
                    timeSinceLastPlayerMove += state.DeltaTimeSeconds;
                }
                else
                {
                    playerNotMoving = true;
                    timeSinceLastPlayerMove = 0;
                }
            }

            if (timeSinceLastDirectionChange < minTimeBetweenDirectionChange)
            {
                timeSinceLastDirectionChange += state.DeltaTimeSeconds;
            }

            if (bMoving == true)
            {
                if (bMoveLeft == true)
                {
                    if (hasPlayer == true && player.position.Y + 10.0f >= this.position.Y && playerNotJumping == true) 
                    {
                        //if (playerNotMoving == true)//if the player is not moving them move the player
                        //{
                            ((ActorBody)player.PhysicsBody).MoveLeft();
                        //}
                        ((MPBody)body).hasPlayer = true; 
                    }
                    else 
                    {
                        ((MPBody)body).hasPlayer = false; 
                    }

                    ((MPBody)body).MoveLeft();
                }
                if (bMoveRight == true)
                {
                    if (hasPlayer == true && player.position.Y + 10.0f >= this.position.Y && playerNotJumping == true) 
                    {
                        //if (playerNotMoving == true)
                        //{
                            ((ActorBody)player.PhysicsBody).MoveRight();
                        //}
                        ((MPBody)body).hasPlayer = true; 
                    }
   
                    else 
                    { 
                        ((MPBody)body).hasPlayer = false; 
                    }
                    ((MPBody)body).MoveRight();
                }
            }
            oldPosition = position;
        }

        public void ActOnPlayer(ref Player player)
        {
            if (bMoveRight == true)
            {
                ((ActorBody)player.PhysicsBody).MoveRight();
            }
            if (bMoveLeft == true)
            {
                ((ActorBody)player.PhysicsBody).MoveLeft();
            }
        }

        public override void LoadContent(ContentState state)
        {
            base.LoadContent(state);

            body = new MPBody();
            collision = new CollisionSkin(body);
            //collision.callbackFn += new CollisionCallbackFn(collision_callbackFn);
            //Vector3 capsuleTop = new Vector3((model.ModelData.StaticBounds.Minimum.X + model.ModelData.StaticBounds.Maximum.X) / 2, model.ModelData.StaticBounds.Maximum.Y, 0);
            float capsuleHeight = Math.Abs(model.ModelData.StaticBounds.Maximum.Y);
            float capsuleRadius = (Math.Abs(model.ModelData.StaticBounds.Minimum.X) + Math.Abs(model.ModelData.StaticBounds.Maximum.X)) / 2;
            Vector3 capsuleTop = new Vector3((model.ModelData.StaticBounds.Minimum.X + model.ModelData.StaticBounds.Maximum.X) / 2, model.ModelData.StaticBounds.Maximum.Y - capsuleRadius, 0);

            Vector3 boxMiddleLengths = new Vector3(Math.Abs(model.ModelData.StaticBounds.Minimum.X) + Math.Abs(model.ModelData.StaticBounds.Maximum.X), (Math.Abs(model.ModelData.StaticBounds.Minimum.Y) + Math.Abs(model.ModelData.StaticBounds.Maximum.Y)), Math.Abs(model.ModelData.StaticBounds.Minimum.Z) + Math.Abs(model.ModelData.StaticBounds.Maximum.Z));

            //float yValueOfModelBounds = model.ModelData.StaticBounds.Minimum.Y;
            //Sphere sphereTop = new Sphere(capsuleTop, capsuleRadius);
            //Sphere sphereBottom = new Sphere(capsuleTop - new Vector3(0, capsuleTop.Y - capsuleRadius, 0), capsuleRadius);
            Box boxMiddle = new Box(model.ModelData.StaticBounds.Minimum, Matrix.Identity, boxMiddleLengths);
            //Capsule capsule = new Capsule(capsuleTop /* + (new Vector3(0, -capsuleRadius, 0) * 2) */, Matrix.CreateRotationX(MathHelper.PiOver2), capsuleRadius, 0);
            //collision.AddPrimitive(capsule, (int)MaterialTable.MaterialID.NotBouncyNormal);

            //collision.AddPrimitive(sphereTop, (int)MaterialTable.MaterialID.NotBouncyNormal);
            //collision.AddPrimitive(sphereBottom, (int)MaterialTable.MaterialID.NotBouncyNormal);
            collision.AddPrimitive(boxMiddle, (int)MaterialTable.MaterialID.NotBouncyNormal);

            body.CollisionSkin = this.collision;
            Vector3 com = SetMass(10.0f);


            body.MoveTo(position + com, Matrix.Identity);

            //collision.ApplyLocalTransform(new JigLibX.Math.Transform(-com, Matrix.Identity));

            body.SetBodyInvInertia(0.0f, 0.0f, 0.0f);

            //CharacterBody = body as ActorBody;
            
            body.AllowFreezing = false;
            body.Immovable = false;
            body.EnableBody();
        }

        public override void Draw(DrawState state)
        {
            base.Draw(state);
        }
    }


}

