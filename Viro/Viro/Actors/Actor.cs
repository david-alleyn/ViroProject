using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;


using Xen;
using Xen.Ex.Graphics;

using Viro.Physics;
using Xen.Ex.Graphics2D;
using Xen.Graphics;
using Microsoft.Xna.Framework.Graphics;
using Xen.Ex.Graphics.Content;
using Viro.Shaders;
using JigLibX.Physics;

namespace Viro.Actors
{
    public class Actor : CharacterObject, IContentOwner
    {
        AnimationController animationController;
        AnimationInstance nextAnimation;
        public AnimationInstance currentAnimation;

        protected AnimationInstance walkAnimation;
        protected AnimationInstance idleAnimation;
        protected AnimationInstance jumpAnimation;
        protected AnimationInstance deathAnimation;
        protected AnimationInstance attackAnimation;
        protected AnimationInstance fallingAnimation;
        protected AnimationInstance recoilAnimation;
        protected AnimationInstance quadRunAnimation;
        protected AnimationInstance runAnimation;

        static Texture2D randomShaderNumbers;

        TextElement deathAnimationDebug;

        bool isDead = false;
        public int health = 100;
        int attackPower = 10;
        double minTimeBetweenIncomingDamage = 0.25f; //At least 0.25 seconds between attacks;
        double timeSinceLastImpact = 0;
        float alphaChange;
        public bool reviveMe = false;
        public int Lives = 2;
        public bool deathAnimating = false;
        public string deathSound;
        public bool LookingLeft = false;
        public bool isInAir = false;
        public enum State { IDLE, WALK_LEFT, WALK_RIGHT, JUMP, DEATH, ATTACK, FALL, RECOIL, QUADRUN, RUN };
        public State currentState = State.IDLE;

        public float AlphaChange
        {
            get { return alphaChange; }
        }

        public bool IsDead
        {
            get
            {
                return isDead;
            }
            set
            {
                isDead = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        public int AttackPower
        {
            get
            {
                return attackPower;
            }
            set
            {
                attackPower = value;
            }
        }

        public double MinTimeBetweenIncomingDamage
        {
            get
            {
                return minTimeBetweenIncomingDamage;
            }
            set
            {
                minTimeBetweenIncomingDamage = value;
            }
        }

        protected Actor(ContentRegister content, Vector3 position, String modelContentName)
            : base(content, position, modelContentName)
        {
            currentAnimation = new AnimationInstance();
            nextAnimation = new AnimationInstance();
            nextAnimation.Enabled = false;
            deathAnimationDebug = new TextElement();
            deathAnimationDebug.Text.SetText("ENEMY HAS DIED!!!");
            deathAnimationDebug.Position = new Vector2(100.0f, -100.0f);
        }

        public Actor()
            : base()
        {
            currentAnimation = new AnimationInstance();
            nextAnimation = new AnimationInstance();
            nextAnimation.Enabled = false;
            deathAnimationDebug = new TextElement();
            deathAnimationDebug.Text.SetText("ENEMY HAS DIED!!!");
            deathAnimationDebug.Position = new Vector2(100.0f, -100.0f);
        }

        public void WalkingAnimation()
        {
            if (!walkAnimation.Enabled && !nextAnimation.Enabled && deathAnimating == false && !jumpAnimation.Enabled && !((ActorBody)body).falling)
            {
                if (LookingLeft) { currentState = State.WALK_LEFT; }
                else { currentState = State.WALK_RIGHT; }
                walkAnimation = animationController.PlayLoopingAnimation(model.GetAnimationController().AnimationIndex("Walk"));
                walkAnimation.PlaybackSpeed = 2.5f;
                nextAnimation = walkAnimation;
                nextAnimation.Weighting = 0.0f;
            }
        }

        public void JumpingAnimation()
        {
            if (!jumpAnimation.Enabled && !nextAnimation.Enabled && !attackAnimation.Enabled && !((ActorBody)body).falling)
            {
                currentState = State.JUMP;
                jumpAnimation = model.GetAnimationController().PlayAnimation(model.GetAnimationController().AnimationIndex("Jump_Up"));
                jumpAnimation.PlaybackSpeed = 1.5f;
                nextAnimation = jumpAnimation;
                nextAnimation.Weighting = 0.0f;
            }
        }

        public void FallingAnimation()
        {
            if (!fallingAnimation.Enabled && !nextAnimation.Enabled && !attackAnimation.Enabled && ((ActorBody)body).falling)
            {
                currentState = State.FALL;
                fallingAnimation = model.GetAnimationController().PlayLoopingAnimation(model.GetAnimationController().AnimationIndex("Jump_Mid"));
                fallingAnimation.PlaybackSpeed = 1.5f;
                nextAnimation = fallingAnimation;
                nextAnimation.Weighting = 0.0f;
            }
        }

        public void StandingAnimation()
        {
            if (!nextAnimation.Enabled && !idleAnimation.Enabled && !attackAnimation.Enabled && deathAnimating == false && !((ActorBody)body).falling && currentState != State.QUADRUN && !jumpAnimation.Enabled)
            {
                currentState = State.IDLE;
                idleAnimation = model.GetAnimationController().PlayLoopingAnimation(model.GetAnimationController().AnimationIndex("Idle"));
                nextAnimation = idleAnimation;
                nextAnimation.Weighting = 0.0f;
            }
        }

        public void DeathAnimation()
        {
            if (!nextAnimation.Enabled && !((ActorBody)body).falling)
            {
                currentState = State.DEATH;
                deathAnimation = model.GetAnimationController().PlayAnimation(model.GetAnimationController().AnimationIndex("Die"));
                nextAnimation = deathAnimation;
                nextAnimation.Weighting = 0.0f;
                deathAnimating = true;
            }
        }

        public void AttackAnimation()
        {
            if (!attackAnimation.Enabled)
            {
                currentState = State.ATTACK;
                attackAnimation = model.GetAnimationController().PlayAnimation(model.GetAnimationController().AnimationIndex("Attack_Land"));
                nextAnimation = attackAnimation;
                nextAnimation.Weighting = 0.0f;
            }
        }

        public void RecoilAnimation()
        {
            if (!recoilAnimation.Enabled)
            {
                currentState = State.RECOIL;
                recoilAnimation = model.GetAnimationController().PlayAnimation(model.GetAnimationController().AnimationIndex("Recoil"));
                //attackAnimation.PlaybackSpeed = 0.75f;
                nextAnimation = recoilAnimation;
                nextAnimation.Weighting = 0.0f;
            }
        }

        public void QuadRunAnimation()
        {
            if (!quadRunAnimation.Enabled && !jumpAnimation.Enabled)
            {
                currentState = State.QUADRUN;
                quadRunAnimation = model.GetAnimationController().PlayLoopingAnimation(model.GetAnimationController().AnimationIndex("Quad_Run"));
                attackAnimation.PlaybackSpeed = 2.5f;
                nextAnimation = quadRunAnimation;
                nextAnimation.Weighting = 0.0f;
            }
        }

        public void RunAnimation()
        {
            if (!runAnimation.Enabled && !jumpAnimation.Enabled && !fallingAnimation.Enabled)
            {
                currentState = State.RUN;
                runAnimation = model.GetAnimationController().PlayLoopingAnimation(model.GetAnimationController().AnimationIndex("Run"));
                attackAnimation.PlaybackSpeed = 2.5f;
                nextAnimation = runAnimation;
                nextAnimation.Weighting = 0.0f;
            }
        }

        public void StopAnimation()
        {
            currentAnimation.StopAnimation(0.75f);
            nextAnimation.StopAnimation(0.75f);
        }

        public void TakeDamage(int amountOfDamage)
        {
            if (timeSinceLastImpact >= minTimeBetweenIncomingDamage)
            {
                health -= amountOfDamage;
                timeSinceLastImpact = 0;
                //RecoilAnimation();
            }
        }

        public override void Update(UpdateState state)
        {
            timeSinceLastImpact += state.DeltaTimeSeconds;
            if (nextAnimation.Enabled)
                currentAnimation.Weighting *= 0.75f;
            else
                currentAnimation.Weighting = 1.0f;
            nextAnimation.Weighting = 1 - currentAnimation.Weighting;
            nextAnimation.Enabled = nextAnimation.Weighting > 0.025f;
            currentAnimation.Enabled = currentAnimation.Weighting > 0.175f;
            Console.WriteLine(currentAnimation.Weighting);
            if (!currentAnimation.Enabled)
            {
                currentAnimation = nextAnimation;
                nextAnimation = new AnimationInstance();
                nextAnimation.Enabled = false;
            }   
            
            if (health <= 0 && isDead == false && deathAnimating == false)
            {
                if (Lives > 0)
                {
                    DeathAnimation();
                }
                else if (Lives == 0)
                {
                    DisolveShader s = new DisolveShader();
                    s.NOISETEXTURE = randomShaderNumbers;
                    model.ShaderProvider = s;
                    isDead = true;
                    //body.DisableBody();
                    SoundManager.Sound.PlaySound(deathSound);
                    DeathAnimation();
                    PhysicsSystem.CurrentPhysicsSystem.RemoveBody(this.PhysicsBody);
                }
            }
            else if (health <= 0 && isDead == false && deathAnimating)
            {
                if (deathAnimation.AnimationFinished)
                { 
                    deathAnimating = false;
                    reviveMe = true;
                }
            }
            if (isDead)
            {
                if (alphaChange < 1.0f)
                    alphaChange += 0.008f;
                ((DisolveShader)(model.ShaderProvider)).ALPHACHANGE = alphaChange;
                if (deathAnimation.AnimationFinished)
                {
                    deathAnimation = model.GetAnimationController().PlayAnimation(model.GetAnimationController().AnimationIndex("Die"));
                }
            }

            if (timeSinceLastImpact < minTimeBetweenIncomingDamage)
            {
                timeSinceLastImpact += state.DeltaTimeSeconds;
            }

            base.Update(state);
        }

        public override void Draw(DrawState state)
        {
            if (IsDead)
            {
                deathAnimationDebug.Draw(state);
            }

            //After custom drawing
            base.Draw(state);
        }

        public override void LoadContent(ContentState state)
        {
            deathAnimationDebug.Font = state.Load<Microsoft.Xna.Framework.Graphics.SpriteFont>(@"Font/Arial");

            randomShaderNumbers = state.Load<Texture2D>("Noise");

            base.LoadContent(state);
           
            animationController = model.GetAnimationController();

            //currentAnimation = animationController.PlayLoopingAnimation(animationController.AnimationIndex("Idle"));
        }
    }
}


