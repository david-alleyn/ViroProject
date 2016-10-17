#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Xen.Ex.Graphics2D;
using Xen;
#endregion

namespace Viro.Physics
{
   //MASS
   //Used to build a rope, acts as the pivot between 'springs'.
   public class Mass
   {
       public Vector3 Position;
       public Vector3 prevPosition;
       public Vector3 Velocity;
       public bool Anchor;
       public bool grabbed;
       public float Friction;
       public Mass(Vector3 pos)
       {
           Position = pos;
           prevPosition = pos;
           Velocity = Vector3.Zero;
           Anchor = false;
           grabbed = false;
           Friction = 1.0f;
       }
       public void Draw()//draw for debugging
       {
          
       }
   }
   //SPRING
   //Used to build a rope, these are the sections that move together to create
   //the illusion of a string. The more sections the more 'ropelike'
    //it will be.

   public class Spring 
   {
       public float K;
       public float minLength;
       public float maxLength;
       public float restLength;
       public Vector3 Force;
       public int StartNode;
       public int EndNode;
       public Spring(float k, float rest, float max, float min, int start, int end)

       {
           K = k;
           restLength = rest;
           minLength = min;
           maxLength = max;
           StartNode = start;
           EndNode = end;
           Force = Vector3.Zero;
       }
   }
   public class Tendril 
   {
       public float Offset = 0.0f;
       public Vector3 playerPosition = new Vector3();
       public bool facingRight = false;
       public bool movingUp = false;
       //Holds all the masses used in the rope
       public List<Mass> massArray = new List<Mass>();
       //Holds all the springs used in the rope
       public List<Spring> springArray = new List<Spring>();
       //Number of times to iterate through the constraint
        //calculations. !IMPORTANT FOR NON-ELASTIC ROPES!
       public int iterations;
       //Is the rope elastic or not.
       public bool elastic;
       Vector3 startPosition;
       int segments;
       int length;
       protected double minTimeBetweenDirectionChange = 1.4f;
       public double timeSinceLastTendrilDirectionChange = 0;

       Random rand = new Random();
       //MAIN CONSTRUCTOR
       //segs: number of segments (springs) the rope has
       //length: the length of each segment (not the total length of the rope)
       //startPos: the starting position of the rope. this will be
        //the position of massArray[0]
       //k: the variable used for elastic calculations ( see 'Hooke's
        //Law' ). Usually should be lower than 0.5f or crazy will ensue
       //isElastic: if the rope will be elastic or regular (string vs. bungee)
       //physiterations: Number of times to iterate through the
        //constraint calculations. !IMPORTANT FOR NON-ELASTIC ROPES!
       public Tendril(int segs, int length, Vector3 startPos, float k, bool isElastic, int physiterations)
       {
           this.length = length;
           segments = segs;
           iterations = physiterations;
           elastic = isElastic;
           startPosition = startPos;

           Init();
       }

       protected void Init()
       {
           for (int i = 0; i < segments; i++)
           {
               massArray.Add(new Mass(startPosition + new Vector3(0, 500 + i * 10, 0)));
           }

           massArray[0].Anchor = true;

           for (int i = 0; i < segments - 1; i++)
           {
               springArray.Add(new Spring(0.02f, length / (segments - 1), (length / (segments - 1))*1.1f, (length / (segments - 1))*0.99f, i, i + 1));
               //k springyness, default length, max length, min length, possition in mass array that it is attached too, end);

           }

       }

       public void Update(UpdateState state)
       {
           if (timeSinceLastTendrilDirectionChange < minTimeBetweenDirectionChange)
           {
               timeSinceLastTendrilDirectionChange += state.DeltaTimeSeconds;
           }
           if (timeSinceLastTendrilDirectionChange >= minTimeBetweenDirectionChange)
           {
               timeSinceLastTendrilDirectionChange = 0.0;

               if (movingUp == true)
                {
                    movingUp = false;
                }
               else if (movingUp == false)
                {
                    movingUp = true;
                }
           }
           //Rope system uses Verlet Integration
            //(http://en.wikipedia.org/wiki/Verlet_integration).
           //Doesn't need to be completely understood, but basically
            //it's a more stable system than traditional ways.
           //This is necessary when dealing with potentially unstable
            //spring systems (raise a rope's K value to 0.8f and you'll see).
           //Damping. This causes the system to lose energy like it
            //would in the real world due to friction, air, gravity etc...
           //For no damping use 2.0f. Without this you get perpetual motion.

           float energylossX = 1.7f;
           float energylossY = 1.7f;
           float energylossZ = 2.0f;
           Vector3 temp = Vector3.Zero;
           Vector3 difference = Vector3.Zero;
           //float Offset = 10.0f;

           //Loop through masses. Add gravity to them, perform Verlet
            //integration if it's not an anchor.
           for (int m = 0; m < massArray.Count; m++)
           {
               if (!massArray[m].Anchor)
               {
                   if (massArray[m].Position.Y < (playerPosition.Y + 150.0f) && massArray[m].Position.Y > (playerPosition.Y - 150.0f))
                   {
                       if (movingUp == false)//if tendrils are higher then the head+offset go down
                       {
                           massArray[m].Velocity.Y += (-0.35f - Offset);//this is gravity
                       }
                       if (movingUp == true)//if tendrils are lower then the head+offset go up
                       {
                           massArray[m].Velocity.Y += (0.25f + Offset);
                       }
                   }
                   else
                   {
                       if (massArray[m].Position.Y > (playerPosition.Y + 150.0f))
                       {
                           massArray[m].Velocity.Y += (-0.35f - Offset);
                       }
                       if (massArray[m].Position.Y < (playerPosition.Y - 150.0f))
                       {
                           massArray[m].Velocity.Y += (0.25f + Offset);
                       }
                   }
                   //changes the direction of the "gravity" to suit the player's direction
                   if (facingRight == true)
                   {
                       massArray[m].Velocity.X += -0.25f;
                   }
                   if (facingRight == false)
                   {
                       massArray[m].Velocity.X += 0.25f;
                   }
                   energylossX = 2.0f;
                   energylossY = 1.5f;
                   energylossZ = 2.0f;

                   temp = Vector3.Zero;
                   difference = Vector3.Zero;
                   difference.X = ((energylossX *massArray[m].Position.X) - ((energylossX - 1) *massArray[m].prevPosition.X) + massArray[m].Velocity.X) -massArray[m].Position.X;
                   difference.Y = ((energylossY *massArray[m].Position.Y) - ((energylossY - 1) *massArray[m].prevPosition.Y) + massArray[m].Velocity.Y) -massArray[m].Position.Y;
                   difference.Z = ((energylossZ *massArray[m].Position.Z) - ((energylossY - 1) *massArray[m].prevPosition.Z) + massArray[m].Velocity.Z) -massArray[m].Position.Z;
                   
                   
                   temp.X = (energylossX *massArray[m].Position.X) - ((energylossX - 1) *massArray[m].prevPosition.X) + massArray[m].Velocity.X;
                   temp.Y = (energylossY *massArray[m].Position.Y) - ((energylossY - 1) *massArray[m].prevPosition.Y) + massArray[m].Velocity.Y;
                   temp.Z = (energylossY *massArray[m].Position.Z) - ((energylossY - 1) *massArray[m].prevPosition.Z) + massArray[m].Velocity.Z;

                   massArray[m].prevPosition = massArray[m].Position;
                   massArray[m].Position = temp;
                   massArray[m].Velocity.X = 0;
                   massArray[m].Velocity.Y = 0;
                   massArray[m].Velocity.Z = 0;

               }
           }

           Vector3 delta;
           float deltalength;
           float diff;
           for (int i = 0; i < iterations; i++)
           {
               //Loop through all the springs.
               for (int s = 0; s < springArray.Count; s++)
               {
                   //Difference in distance between start and end of spring.
                   delta = massArray[springArray[s].EndNode].Position - massArray[springArray[s].StartNode].Position;
                   //Distance between start and end of spring.
                   deltalength = (float)delta.Length();
                   if (elastic == false)
                   {
                       //If the rope is not elastic, find the
                        //difference between the length the spring should be
                       //and the length it is currently. Then move
                        //it's ends until it's the correct length again.
                       diff = ((deltalength - springArray[s].restLength) / deltalength);
                       if (massArray[springArray[s].StartNode].Anchor != true)
                       {
                        
                           massArray[springArray[s].StartNode].Position.X += (float)(delta.X *0.5f * diff);

                           massArray[springArray[s].StartNode].Position.Y += (float)(delta.Y * 0.5f * diff);

                           massArray[springArray[s].StartNode].Position.Z += (float)(delta.Z * 0.5f * diff);
                       }
                       if (massArray[springArray[s].EndNode].Anchor != true)
                       {

                            massArray[springArray[s].EndNode].Position.X -= (float)(delta.X * 0.5f * diff);

                            massArray[springArray[s].EndNode].Position.Y -= (float)(delta.Y * 0.5f * diff);

                            massArray[springArray[s].EndNode].Position.Z -= (float)(delta.Z * 0.5f * diff);

                       }
                   }
                   if (elastic == true)
                   {
                       //If the rope is elastic find the force the
                        //spring should be exerting based on how much it's stretched
                       //and it's K value.
                       float xNorm = (massArray[springArray[s].StartNode].Position.X - massArray[springArray[s].EndNode].Position.X) / deltalength;
                       float yNorm = (massArray[springArray[s].StartNode].Position.Y - massArray[springArray[s].EndNode].Position.Y) / deltalength;
                       float zNorm = (massArray[springArray[s].StartNode].Position.Z - massArray[springArray[s].EndNode].Position.Z) / deltalength;
                       // Hooke's Law. The equation for springs.
                       // Force = -K * stretchedAmount
                       float a = -springArray[s].K * (deltalength - springArray[s].restLength);
                       springArray[s].Force.X = (xNorm * a);
                       springArray[s].Force.Y = (yNorm * a);
                       springArray[s].Force.Z = (zNorm * a);
                       massArray[springArray[s].StartNode].Position += springArray[s].Force;
                       massArray[springArray[s].EndNode].Position -= springArray[s].Force;
                       if (massArray[springArray[s].StartNode].Anchor == true)
                       {

                        massArray[springArray[s].StartNode].Position -= springArray[s].Force;
                       }
                       if (massArray[springArray[s].EndNode].Anchor == true)
                       {
                           massArray[springArray[s].EndNode].Position += springArray[s].Force;
                       }
                   }
               }
           }
       }

       public void Draw(DrawState state)
       {
           
       }
   }
}