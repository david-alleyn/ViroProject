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
using Viro.Shaders;

namespace Viro.Actors
{
    public class Player : Actor, IContentOwner
    {
        public Vector3 OldNPCPosition = Vector3.Zero;
        public NPC closestNPC = null;
        const float rotationLimit = 1.7853982f;
        const float rotationSpeed = 0.3926991f;
        //30    0.02617994
        //60    0.01308997
        //15    0.05235988
        //10    0.07853982
        // 5    0.15707964
        // 4    0.19634955
        // 3    0.2617994
        // 2    0.3926991

        //TextElement debugOutput;
        Vector2 rotation = new Vector2(0.0f);
        Tendril tendril1;
        Tendril tendril2;
        Tendril tendril3;
        Tendril tendril4;
        List<TendrilObject> tendrilMeshes1 = new List<TendrilObject>();
        List<TendrilObject> tendrilMeshes2 = new List<TendrilObject>();
        List<TendrilObject> tendrilMeshes3 = new List<TendrilObject>();
        List<TendrilObject> tendrilMeshes4 = new List<TendrilObject>();
        //public bool upsideDown = false;
        ReadOnlyArrayCollection<Transform> boneAnimationTransforms;
        public double AntiGravPower = 100.0f;
        private int step = 0;
        private double tempDist = 0.0f;
        public bool attackingPort = false;
        public Vector3 currentSpawnPoint = Vector3.Zero;
        protected double minTimeBetweenChange = 10.0f;
        public double timeSinceChange = 0;
        public double timeSinceTendrilToPortInteraction = 0;

        public float accumulatedThumbstickTime = 0.0f;
        public double minTimeBetweenTTPIChange = 2.0f;
        public bool lookingLeft = false;
        public bool isJumping = false;
        public bool onMP = false;
        private bool quadrunning = false;
        private int walkCounter = 0;
        private int fallCounter = 0;
        public ActorBody Body { get { return ((ActorBody)body); } set { this.body = value; } }


        public Player(ContentRegister content, Vector3 position, String modelContentName)
            : base(content, position, modelContentName)
        {
            //debugOutput = new TextElement();
            health = 100;
            AttackPower = 100;
            deathSound = "Scream2";
            body.StoreState();
        }

        public Player()
            : base()
        {
            deathSound = "Scream2";
            //debugOutput = new TextElement();
            AttackPower = 100;
            health = 100;
        }

        public override void Update(UpdateState state)
        {
            if (((ActorBody)body).isInAir) { isInAir = true; }
            else { isInAir = false; }

            LookingLeft = lookingLeft;
            PauseGravity();

            if (((ActorBody)body).upsideDown)
            {
                if (AntiGravPower > 0)
                {
                    AntiGravPower -= 0.5f; //at 1.0f about 2.5 secs in length with 100 antigrav
                }
                else
                {
                    ReverseGravity();
                }
            }
            else
            {
                if (AntiGravPower < 100)
                {
                    AntiGravPower += 0.1f;
                }
                if (AntiGravPower > 100)
                {
                    AntiGravPower = 100.0f;
                }
            }

            Transform boneTransform = model.ModelData.Skeleton.BoneWorldTransforms[6];
            boneTransform *= boneAnimationTransforms[6];

            Matrix m;
            boneTransform.GetMatrix(out m);
            m *= worldMatrix;
            boneTransform = new Transform(m, false);

            Vector3 v = new Vector3(boneTransform.Translation.X, boneTransform.Translation.Y, boneTransform.Translation.Z);
            if (attackingPort == true && timeSinceTendrilToPortInteraction >= minTimeBetweenTTPIChange)
            {
                timeSinceChange += state.DeltaTimeSeconds;
                timeSinceTendrilToPortInteraction = 0;
                attackingPort = false;
            }
            
            timeSinceTendrilToPortInteraction += state.DeltaTimeSeconds;

            if (timeSinceChange >= minTimeBetweenChange)
            {
                attackingPort = false;
                tendril1.massArray[6].Position = position;
                tendril2.massArray[6].Position = position;
                tendril3.massArray[6].Position = position;
                tendril4.massArray[6].Position = position;
                timeSinceChange = 0;
                closestNPC = null;
            }

            if (closestNPC != null)
            {
                v = new Vector3(0.0f, -175.0f, 0.0f);
                if (position.X < closestNPC.position.X) { v.X = 175.0f; }
                if (position.X > closestNPC.position.X) { v.X = -175.0f; }

                tendril1.massArray[6].Position = v + closestNPC.position;
                tendril2.massArray[6].Position = v + closestNPC.position;
                tendril3.massArray[6].Position = v + closestNPC.position;
                tendril4.massArray[6].Position = v + closestNPC.position;
            }
            else
            {
                if (OldNPCPosition != Vector3.Zero)
                {
                    if (step == 0)
                    {
                        if (position.X < OldNPCPosition.X)
                        {
                            tempDist = (this.GetDistanceFromObject(OldNPCPosition) + 150);
                        }
                        if (position.X > OldNPCPosition.X)
                        {
                            tempDist = ((this.GetDistanceFromObject(OldNPCPosition) + 150) * -1);
                        }
                        v.X += ((float)tempDist * 0.1f);
                    }
                    else
                    {
                        v.X += ((float)tempDist * 0.1f);
                    }

                    if (step <= 9)
                    {
                        step++;
                    }
                    
                    if (step > 9)
                    {
                        step = 0;
                        OldNPCPosition = Vector3.Zero;
                        //if (attackingPort == true) { attackingPort = false; }
                    }
                    if (attackingPort == true)
                    {
                        tendril1.massArray[6].Position = v + OldNPCPosition;
                        tendril2.massArray[6].Position = v + OldNPCPosition;
                        tendril3.massArray[6].Position = v + OldNPCPosition;
                        tendril4.massArray[6].Position = v + OldNPCPosition;
                    }
                }

                //removing 7.5f from the x puts the start of the tendrils directly in the middle of the head.
                Vector3 startPositionFix = new Vector3(-8.0f, 0.0f, 0.0f);
                
                tendril1.massArray[0].Position = v + startPositionFix;
                tendril2.massArray[0].Position = v + startPositionFix;
                tendril3.massArray[0].Position = v + startPositionFix;
                tendril4.massArray[0].Position = v + startPositionFix;
                
            }
            tendril1.playerPosition = position;
            tendril1.Update(state);
            tendril2.playerPosition = position;
            tendril2.Update(state);
            tendril3.playerPosition = position;
            tendril3.Update(state);
            tendril4.playerPosition = position;
            tendril4.Update(state);

            for (int i = 0; i < tendrilMeshes1.Count; i++)
            {
                tendrilMeshes1[i].SetPosition(tendril1.massArray[i].Position);

                if(i != tendril1.massArray.Count-1)
                {
                    Vector3 dir = tendril1.massArray[i].Position - tendril1.massArray[i+1].Position;
                    dir.Normalize();// + 
                    float rotation = (float)Math.Atan2(dir.Y, dir.X);
                    tendrilMeshes1[i].orientation = Matrix.CreateFromYawPitchRoll(0,0,rotation);
                }
            }

            for (int i = 0; i < tendrilMeshes2.Count; i++)
            {
                tendrilMeshes2[i].SetPosition(tendril2.massArray[i].Position);

                if (i != tendril2.massArray.Count - 1)
                {
                    Vector3 dir = tendril2.massArray[i].Position - tendril2.massArray[i + 1].Position;
                    dir.Normalize();
                    float rotation = (float)Math.Atan2(dir.Y, dir.X);
                    tendrilMeshes2[i].orientation = Matrix.CreateFromYawPitchRoll(0, 0, rotation);
                }
            }

            for (int i = 0; i < tendrilMeshes3.Count; i++)
            {
                tendrilMeshes3[i].SetPosition(tendril3.massArray[i].Position);

                if (i != tendril1.massArray.Count - 1)
                {
                    Vector3 dir = tendril3.massArray[i].Position - tendril3.massArray[i + 1].Position;
                    dir.Normalize();
                    float rotation = (float)Math.Atan2(dir.Y, dir.X);
                    tendrilMeshes3[i].orientation = Matrix.CreateFromYawPitchRoll(0, 0, rotation);
                }
            }
            for (int i = 0; i < tendrilMeshes4.Count; i++)
            {
                tendrilMeshes4[i].SetPosition(tendril4.massArray[i].Position);

                if (i != tendril1.massArray.Count - 1)
                {
                    Vector3 dir = tendril4.massArray[i].Position - tendril4.massArray[i + 1].Position;
                    dir.Normalize();
                    float rotation = (float)Math.Atan2(dir.Y, dir.X);
                    tendrilMeshes4[i].orientation = Matrix.CreateFromYawPitchRoll(0, 0, rotation);
                }
            }


            if (!IsDead && !deathAnimation.Enabled)
            {
#if XBOX360
                InputState playerInput = state.PlayerInput[PlayerIndex.One].InputState;

                //position.X += playerInput.ThumbSticks.LeftStick.X;
                //position.Y += playerInput.ThumbSticks.LeftStick.Y;
                if (playerInput.Buttons.DpadUp.IsDown)
                {
                    //body.Velocity += new Vector3(0, playerSpeed, 0);
                }
                else if (playerInput.Buttons.DpadDown.IsDown)
                {
                    //body.Velocity += new Vector3(0, -playerSpeed, 0);
                }
                if (playerInput.Buttons.DpadRight.IsDown)
                {
                    //body.Velocity += new Vector3(playerSpeed, body.Velocity.Y, 0);
                    ((ActorBody)body).MoveRight();

                    Quaternion temp = new Quaternion();
                    Vector3 t = new Vector3();
                    worldMatrix.Decompose(out t, out temp, out t);
                    if (temp.Y < rotationLimit)
                        rotation.Y += rotationSpeed;

                    WalkingAnimation();
                }
                else if (playerInput.Buttons.DpadLeft.IsDown)
                {
                    //position.X -= playerSpeed;
                    //body.Velocity += new Vector3(-playerSpeed, body.Velocity.Y, 0);
                    ((ActorBody)body).MoveLeft();

                    Quaternion temp = new Quaternion();
                    Vector3 t = new Vector3();
                    worldMatrix.Decompose(out t, out temp, out t);
                    if (temp.Y > -rotationLimit)
                        rotation.Y -= rotationSpeed;

                    WalkingAnimation();
                }
                if (playerInput.Buttons.A.OnPressed)
                {
                    ((ActorBody)body).DoJump();
                }
                if (playerInput.Buttons.DpadLeft.OnReleased || playerInput.Buttons.DpadRight.OnReleased)
                {
                    StopAnimation();
                }
            }
#else

                if (((ActorBody)body).falling == true)
                {
                    if (fallCounter < 130)
                    { FallingAnimation(); }
                    else
                    {
                        fallCounter++;
                    }
                }
                else
                {
                    fallCounter = 0;
                }

                if (!lookingLeft)
                {
                    if (rotation.Y < rotationLimit)
                        rotation.Y += rotationSpeed;
                }
                else
                {
                    if (rotation.Y > -rotationLimit + 0.23f)
                        rotation.Y -= rotationSpeed;
                }

                if (state.KeyboardState.KeyState.Right.IsDown || state.PlayerInput[0].InputState.ThumbSticks.LeftStick.X > 0.1f || state.KeyboardState.KeyState.Left.IsDown || state.PlayerInput[0].InputState.ThumbSticks.LeftStick.X < -0.1f)
                {
                    

                    if (!((ActorBody)body).isInAir)
                    {
                        if (state.PlayerInput[0].InputState.ThumbSticks.LeftStick.X > 0.1f || state.PlayerInput[0].InputState.ThumbSticks.LeftStick.X < -0.1f)
                            accumulatedThumbstickTime += state.DeltaTimeSeconds;

                        if (!quadrunning)
                        {
                            if (walkCounter < 5)
                            {
                                if (state.KeyboardState.KeyState.Right.IsPressedRepeats(state, 2.7f, 0.3f) || accumulatedThumbstickTime > 2.7f)
                                {
                                    if (state.PlayerInput[0].InputState.ThumbSticks.LeftStick.X > 0.1f)
                                    {
                                        WalkingAnimation(); walkCounter++; accumulatedThumbstickTime = 0; return;
                                    }
                                    else
                                    {
                                        WalkingAnimation(); walkCounter++; return;
                                    }
                                }
                                else if (state.KeyboardState.KeyState.Left.IsPressedRepeats(state, 2.7f, 0.3f) || accumulatedThumbstickTime > 2.7f)
                                {
                                    if (state.PlayerInput[0].InputState.ThumbSticks.LeftStick.X < -0.1f)
                                    {
                                        WalkingAnimation(); walkCounter++; accumulatedThumbstickTime = 0; return;
                                    }
                                    else
                                    {
                                        WalkingAnimation(); walkCounter++; return;
                                    }
                                }
                            }
                            else
                            {
                                if (state.KeyboardState.KeyState.Right.IsPressedRepeats(state, 2.7f, 0.15f) || accumulatedThumbstickTime > 2.7f)
                                {
                                    if (state.PlayerInput[0].InputState.ThumbSticks.LeftStick.X > 0.1f)
                                    {
                                        RunAnimation(); accumulatedThumbstickTime = 0; return;
                                    }
                                    else
                                    {
                                        RunAnimation(); return;
                                    }
                                }
                                else if (state.KeyboardState.KeyState.Left.IsPressedRepeats(state, 2.7f, 0.15f) || state.PlayerInput[0].InputState.ThumbSticks.LeftStick.X < -0.1f || accumulatedThumbstickTime > 2.7f)
                                {
                                    if (state.PlayerInput[0].InputState.ThumbSticks.LeftStick.X < -0.1f)
                                    {
                                        RunAnimation(); accumulatedThumbstickTime = 0; return;
                                    }
                                    else
                                    {
                                        RunAnimation(); return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (state.KeyboardState.KeyState.Right.IsPressedRepeats(state, 2.7f, 0.15f) || accumulatedThumbstickTime > 2.7f)
                            { if(state.PlayerInput[0].InputState.ThumbSticks.LeftStick.X > 0.1f)
                                QuadRunAnimation(); accumulatedThumbstickTime = 0; return; }
                            else if (state.KeyboardState.KeyState.Left.IsPressedRepeats(state, 2.7f, 0.15f) || state.PlayerInput[0].InputState.ThumbSticks.LeftStick.X < -0.1f || accumulatedThumbstickTime > 2.7f)
                            { if(state.PlayerInput[0].InputState.ThumbSticks.LeftStick.X < -0.1f)
                                QuadRunAnimation(); accumulatedThumbstickTime = 0; return; }
                        }
                    }

                    if (state.KeyboardState.KeyState.Right.IsDown || state.PlayerInput[0].InputState.ThumbSticks.LeftStick.X > 0.1f)
                    {
                        //body.Velocity += new Vector3(playerSpeed, /* body.Velocity.Y */ 0, 0);
                        ((ActorBody)body).MoveRight();
                        TendrilFaceR();

                        lookingLeft = false;
                        if (!quadrunning)
                        {
                            WalkingAnimation();
                        }
                        else
                        {
                            QuadRunAnimation();
                        }
                    }
                    else if (state.KeyboardState.KeyState.Left.IsDown || state.PlayerInput[0].InputState.ThumbSticks.LeftStick.X < -0.1f)
                    {
                        //position.X -= playerSpeed;
                        //body.Velocity += new Vector3(-playerSpeed, /* body.Velocity.Y */ 0, 0);
                        ((ActorBody)body).MoveLeft();
                        TendrilFaceL();

                        lookingLeft = true;
                        if (!quadrunning)
                        {
                            WalkingAnimation();
                        }
                        else
                        {
                            QuadRunAnimation();
                        }
                    }
                }
                else
                {
                    if (!((ActorBody)body).falling)
                        StandingAnimation();
                    walkCounter = 0;
                }
                
                if (state.KeyboardState.KeyState.Space.OnPressed || state.PlayerInput[0].InputState.Buttons.A.OnPressed)
                {
                    //if (onMP == false)
                    //{
                        ((ActorBody)body).DoJump();
                    /*}
                    else
                    {
                        ((ActorBody)body).MoveTo(new Vector3(position.X, (position.Y - 15.0f), position.Z), orientation);//somehow this "fixes" a massive bug when jumping on the platforms
                        ((ActorBody)body).UltraJump();
                    }*/
                    JumpingAnimation();
                }
                
                //TESTING CODE SHAUN
                //if (!state.KeyboardState.KeyState.Right.IsDown && !state.KeyboardState.KeyState.Left.IsDown)
                //{
                //    StandingAnimation();
                //}
                //END OF TEST CODE

            }
            else
            {
                foreach (TendrilObject t in tendrilMeshes1)
                    t.DisolveTendrils();
                foreach (TendrilObject t in tendrilMeshes2)
                    t.DisolveTendrils();
                foreach (TendrilObject t in tendrilMeshes3)
                    t.DisolveTendrils();
                foreach (TendrilObject t in tendrilMeshes4)
                    t.DisolveTendrils();
            }

            if (health <= 0 && IsDead == false)
            {
                foreach (TendrilObject t in tendrilMeshes1)
                    t.KillTendrils();
                foreach (TendrilObject t in tendrilMeshes2)
                    t.KillTendrils();
                foreach (TendrilObject t in tendrilMeshes3)
                    t.KillTendrils();
                foreach (TendrilObject t in tendrilMeshes4)
                    t.KillTendrils();
                
            }

            if (state.KeyboardState.KeyState.Q.OnPressed || reviveMe == true)
            {
                
                if (!IsDead)
                {
                    health = 0;
                    foreach (TendrilObject t in tendrilMeshes1)
                        t.KillTendrils();
                    foreach (TendrilObject t in tendrilMeshes2)
                        t.KillTendrils();
                    foreach (TendrilObject t in tendrilMeshes3)
                        t.KillTendrils();
                    foreach (TendrilObject t in tendrilMeshes4)
                        t.KillTendrils();
                }
                if (reviveMe == true)
                {
                    body.RestoreState();
                    IsDead = false;
                    ((ActorBody)body).speedAlteration = 100.0f;//change to dampen velocity after death 
                    health = 100;
                    reviveMe = false;
                    Lives--;
                    body.MoveTo(currentSpawnPoint, orientation);
                    body.Velocity = Vector3.Zero;
                }
            }
#endif

            /*if (((ActorBody)body).upsideDown)
            {
                //body.AddBodyForce(new Vector3(0.0f, 500.0f, 0.0f));

                //need to modify velocity Y by * -1

                if (rotation.X < MathHelper.ToRadians(180))
                {
                    rotation.X += MathHelper.ToRadians(180);
                }
            }*/
            Vector3 tempPos = new Vector3();
            tempPos = body.Position;
            tempPos.Z = 0;
            body.Position = tempPos;
            //worldMatrix.Translation += position;
            //Matrix.Invert(ref worldMatrix, out tempMatrix);
            orientation = Matrix.CreateRotationY(rotation.Y) * Matrix.CreateRotationZ(rotation.X);
            //worldMatrix *= (tempMatrix * worldMatrix);

            base.Update(state);
        }

        public override void Draw(DrawState state)
        {
            boneAnimationTransforms = model.GetAnimationController().GetTransformedBones(state);

            String output = "Player's position: X: " + Convert.ToString(worldMatrix.Translation.X) + " Y: " + Convert.ToString(worldMatrix.Translation.Y) + " Z: " + Convert.ToString(worldMatrix.Translation.Z) +
                "\nCapsule position: X: " + Convert.ToString(body.Position.X) + " Y: " + Convert.ToString(body.Position.Y) + " Z: " + Convert.ToString(body.Position.Z);

            //debugOutput.Position = new Vector2(0, 0);
            //debugOutput.Text.SetText(output);
            //debugOutput.Draw(state);

            for (int i = 0; i < tendrilMeshes1.Count; i++)
               tendrilMeshes1[i].Draw(state);
           
            for (int i = 0; i < tendrilMeshes2.Count; i++)
               tendrilMeshes2[i].Draw(state);
           
            for (int i = 0; i < tendrilMeshes3.Count; i++)
              tendrilMeshes3[i].Draw(state);
            
            for (int i = 0; i < tendrilMeshes4.Count; i++)
              tendrilMeshes4[i].Draw(state);

             base.Draw(state);
        }

        public override void LoadContent(ContentState state)
        {
            base.LoadContent(state);
            //debugOutput.Font = state.Load<Microsoft.Xna.Framework.Graphics.SpriteFont>(@"Font/Arial");
        }

        public void InitTendrils(ContentRegister content)
        {
            tendril1 = new Tendril(9, 100, this.position + new Vector3((float)random.NextDouble() * 10), 0, false, 50);
            tendril2 = new Tendril(9, 110, this.position + new Vector3((float)random.NextDouble() * 10), 0, false, 50);
            tendril3 = new Tendril(9, 90, this.position + new Vector3((float)random.NextDouble() * 10), 0, false, 50);
            tendril4 = new Tendril(9, 105, this.position + new Vector3((float)random.NextDouble() * 10), 0, false, 50);

            //for seperate movement of the tendrils
            tendril1.Offset = -0.15f;
            tendril2.Offset = 0.15f;
            tendril3.Offset = 0.05f;
            tendril4.Offset = -0.05f;

            for (int i = 0; i < tendril1.massArray.Count-1; i++)
            {
                tendrilMeshes1.Add(new TendrilObject(content, Vector3.Zero, Matrix.Identity, "Models/tendril"));
                content.Add(tendrilMeshes1[i]);
                tendrilMeshes1[i].PhysicsBody.DisableBody();
                tendrilMeshes1[i].PhysicsSkin.RemoveAllPrimitives();
            }

            for (int i = 0; i < tendril2.massArray.Count-1; i++)
            {
                tendrilMeshes2.Add(new TendrilObject(content, Vector3.Zero, Matrix.Identity, "Models/tendril"));
                content.Add(tendrilMeshes2[i]);
                tendrilMeshes2[i].PhysicsBody.DisableBody();
                tendrilMeshes2[i].PhysicsSkin.RemoveAllPrimitives();
            }

            for (int i = 0; i < tendril3.massArray.Count-1; i++)
            {
                tendrilMeshes3.Add(new TendrilObject(content, Vector3.Zero, Matrix.Identity, "Models/tendril"));
                content.Add(tendrilMeshes3[i]);
                tendrilMeshes3[i].PhysicsBody.DisableBody();
                tendrilMeshes3[i].PhysicsSkin.RemoveAllPrimitives();
            }

            for (int i = 0; i < tendril4.massArray.Count-1; i++)
            {
                tendrilMeshes4.Add(new TendrilObject(content, Vector3.Zero, Matrix.Identity, "Models/tendril"));
                content.Add(tendrilMeshes4[i]);
                tendrilMeshes4[i].PhysicsBody.DisableBody();
                tendrilMeshes4[i].PhysicsSkin.RemoveAllPrimitives();
            }
        }

        public void ReverseGravity()
        {
            if (!((ActorBody)body).upsideDown)
            {
                JigLibX.Physics.PhysicsSystem.CurrentPhysicsSystem.Gravity = new Vector3(0.0f, 500.0f, 0.0f);
                ((ActorBody)body).upsideDown = true;
            }
            else
            {
                JigLibX.Physics.PhysicsSystem.CurrentPhysicsSystem.Gravity = new Vector3(0.0f, -1500.0f, 0.0f);
                ((ActorBody)body).upsideDown = false;
            }
        }

        public void PauseGravity()
        {
            if (onMP == true)
            {
                JigLibX.Physics.PhysicsSystem.CurrentPhysicsSystem.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
            }
            else
            {
                if (((ActorBody)body).upsideDown)
                {
                    JigLibX.Physics.PhysicsSystem.CurrentPhysicsSystem.Gravity = new Vector3(0.0f, 500.0f, 0.0f);
                }
                else
                {
                    JigLibX.Physics.PhysicsSystem.CurrentPhysicsSystem.Gravity = new Vector3(0.0f, -1500.0f, 0.0f);
                }
            }
        }

        public void TendrilFaceR()
        {
            tendril1.facingRight = true;
            tendril2.facingRight = true;
            tendril3.facingRight = true;
            tendril4.facingRight = true;
        }

        public void TendrilFaceL()
        {
            tendril1.facingRight = false;
            tendril2.facingRight = false;
            tendril3.facingRight = false;
            tendril4.facingRight = false;
        }

        public void QuadRun()
        {
            if (!quadrunning) { quadrunning = true; }
            else if(quadrunning) { quadrunning = false; }
        }
    }
}
