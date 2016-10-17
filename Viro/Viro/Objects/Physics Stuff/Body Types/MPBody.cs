using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using JigLibX.Collision;
using JigLibX.Math;
using JigLibX.Utils;
using JigLibX.Physics;


namespace Viro.Objects.Physics_Stuff.Body_Types
{
    class MPBody : Body
    {

        public MPBody() : base()
        {

        }

        public Vector3 DesiredVelocity { get; set; }

        public const float maxActorSpeed = 325.0f;
        public const float maxActorUpSpeed = 10.0f;
        public const float actorAcceleration = 1.0f;

        private bool doMoveLeft = false;
        private bool doMoveRight = false;
        private bool doMoveUp = false;
        private bool doMoveDown = false;

        public bool hasPlayer = false;

        public void MoveLeft()
        {
            doMoveLeft = true;
        }

        public void MoveRight()
        {
            doMoveRight = true;
        }

        public void MoveUp() { doMoveUp = true; }
        public void MoveDown() { doMoveDown = true; }

        public override void AddExternalForces(float dt)
        {
            ClearForces();

            //Vector3 oldVelocity = Velocity;
            Vector3 oldVelocity = Vector3.Zero;
            oldVelocity.Z = 0;
            Velocity = oldVelocity;

            Vector3 deltaVel = DesiredVelocity - Velocity;
            bool running = true;

            if (DesiredVelocity.LengthSquared() < JiggleMath.Epsilon) running = false;
            else deltaVel.Normalize();

            //deltaVel.Y = 0.0f;

            // start fast, slow down slower
            if (running) deltaVel *= 10.0f;
            else deltaVel *= 2.0f;

            if (doMoveLeft)
            {
                Vector3 vel = Vector3.Zero; vel.X = -maxActorSpeed;
                Velocity = vel;   
            }

            if (doMoveRight)
            {
                Vector3 vel = Vector3.Zero; vel.X = maxActorSpeed;
                Velocity = vel;  
            }
            if (doMoveUp)
            {
                Vector3 vel = Velocity; vel.Y = 5.0f;
                Velocity = vel;
            }
            else if (doMoveDown)
            {
                Vector3 vel = Velocity; vel.Y = -5.0f;
                Velocity = vel;
            }
            
            deltaVel.Z = 0; // Zero out the Z axis, This is a 2D GAME
            AddBodyForce(deltaVel * Mass * dt * 50.0f);
          
            doMoveLeft = false;
            doMoveRight = false;
            //AddGravityToExternalForce();
        }
    }
}