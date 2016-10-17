using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using JigLibX.Collision;
using JigLibX.Math;
using JigLibX.Utils;
using JigLibX.Physics;


namespace Viro.Physics
{
    public class ActorBody : Body
    {

        public ActorBody()
            : base()
        {
        }

        public Vector3 DesiredVelocity { get; set; }

        public float speedAlteration = 1.0f;

        public float maxActorSpeed = 500.0f;
        public float actorAcceleration = 300.0f;
        public const float playerJumpVelocity = 1200.0f;
        public bool falling = false;
        public bool doJump = false;
        public bool doMoveLeft = false;
        public bool doMoveRight = false;
        public bool isInAir = false;
        public bool upsideDown = false;
        private bool ultraJump = false;

        public void UltraJump()
        {
            ultraJump = true;
        }

        public void DoJump()
        {
            doJump = true;
        }

        public void MoveLeft()
        {
            doMoveLeft = true;
        }

        public void MoveRight()
        {
            doMoveRight = true;
        }

        public override void AddExternalForces(float dt)
        {
            ClearForces();

            Vector3 oldVelocity = Velocity;
            oldVelocity.Z = 0;
            Velocity = oldVelocity;

            Vector3 deltaVel = DesiredVelocity - Velocity;
            bool running = true;

            if (DesiredVelocity.LengthSquared() < JiggleMath.Epsilon) running = false;
            else deltaVel.Normalize();

            //deltaVel.Y = 0.0f;

            // start fast, slow down slower
            if (running) deltaVel *= 10.0f / speedAlteration;
            else deltaVel *= 2.0f;

            float forceFactor = 1000.0f;

            if (CollisionSkin.Collisions.Count > 0)
            {
                foreach (CollisionInfo info in CollisionSkin.Collisions)
                {
                    Vector3 N = info.DirToBody0;
                    if (this == info.SkinInfo.Skin1.Owner)
                        Vector3.Negate(ref N, out N);

                    float dot = Vector3.Dot(N, Orientation.Up);

                    if (dot > 0.8f)  //Sticking/Climbing
                    {
                        if (ultraJump)
                        {
                            Vector3 vel = Velocity; vel.Y = (playerJumpVelocity*2) + (speedAlteration * -1);
                            Velocity = vel;
                            SoundManager.Sound.PlaySound("jump4");
                        }
                        if (doJump)
                        {
                            Vector3 vel = Velocity; vel.Y = playerJumpVelocity + (speedAlteration * -1);
                            Velocity = vel;
                            SoundManager.Sound.PlaySound("jump4");
                        }

                        if (doMoveLeft)
                        {
                            Vector3 vel = Velocity; vel.X = -maxActorSpeed + speedAlteration;
                            Velocity = vel;
                        }

                        if (doMoveRight)
                        {
                            Vector3 vel = Velocity; vel.X = maxActorSpeed + (speedAlteration * -1);
                            Velocity = vel;
                        }
                        if (doMoveLeft == false && doMoveRight == false) { Vector3 vel = Velocity; vel.X = 0; Velocity = vel; }

                        deltaVel.Z = 0; // Zero out the Z axis, This is a 2D GAME

                        AddBodyForce(deltaVel * Mass * dt * forceFactor);
                        break;
                    }

                }
                isInAir = false;
            }
            else//In Air movement
            {
                isInAir = true;
                if (doMoveLeft)
                {
                    Vector3 vel = Velocity; vel.X = -maxActorSpeed + speedAlteration;
                    Velocity = vel;
                }

                if (doMoveRight)
                {
                    Vector3 vel = Velocity; vel.X = maxActorSpeed + speedAlteration;
                    Velocity = vel;
                }
                if (doMoveLeft == false && doMoveRight == false) { Vector3 vel = Velocity; vel.X = 0; Velocity = vel; }

                deltaVel.Z = 0; // Zero out the Z axis, This is a 2D GAME
                AddBodyForce(deltaVel * Mass * dt * 50.0f);
            }

            ultraJump = false;
            doJump = false;
            doMoveLeft = false;
            doMoveRight = false;

            if (Velocity.Y < -200.0f)
                falling = true;
            else
                falling = false;

            AddGravityToExternalForce();

        }
    }
}
