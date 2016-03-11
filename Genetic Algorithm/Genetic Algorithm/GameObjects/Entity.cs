using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Genetic_Algorithm
{
    public class Entity : GameObject
    {
        private float rotation;             //The rotation of next jump.
        private Vector2 origin;             //The offset to center of entity.
        private Vector2 pos;                //The position of entity.
        private Rectangle offsetDrawRec;    //The drawrectangle for rotated entity.
        private Vector2 velocity;           //Entitys velocity.
        private float jumpPower;            //The jump power to next jump.
        protected int jumps;                //Amount of jumps done.
        protected bool left;                //Left of right platform that should be next jump.
        protected bool dead;                //Is the entity dead.

        /// <summary>
        /// Constructor. Creates the entity.
        /// </summary>
        /// <param name="world">The world to spawn to.</param>
        /// <param name="pos">The position of entity.</param>
        public Entity(SimulationWorld world, Vector2 pos) : base(world, new Rectangle(0, 0, 32, 32), new Rectangle(0, 0, 32, 32), Globals.sheet)
        {
            this.pos = pos;
            jumpPower = 0;
            rotation = 0;
            left = true;
            origin = new Vector2(recHit.Width / 2, recHit.Height / 2);
            dead = false;

        }
        public override void Update(float delta)
        {
            //Add gravity.
            velocity.Y += Globals.gravity * delta;

            //Update each axis.
            yAxisUpdate(delta);
            xAxisUpdate(delta);

            offsetDrawRec = new Rectangle((int)(recHit.X + origin.X), (int)(recHit.Y + origin.Y), recHit.Width, recHit.Height);

            if (world.IsEntityOnTrampoline(this, left))
                Jump();
            if (pos.Y > Globals.screenHeight + recHit.Height)
                dead = true;
        }

        /// <summary>
        /// Update the x axis movement.
        /// </summary>
        public void xAxisUpdate(float delta)
        {
            pos.X += velocity.X * delta;
            recHit.X = (int)(pos.X - recHit.Width / 2);
            Blocker blocker = world.IsEntityCollidingBlocker(this);
            if (blocker != null)
            {
                if(velocity.X >= 0)
                    pos.X = blocker.GetRecHit().X - recHit.Width / 2;
                else
                    pos.X = blocker.GetRecHit().X + blocker.GetRecHit().Width + recHit.Width / 2;

                velocity.X = 0f;
                recHit.X = (int)(pos.X - recHit.Width / 2);
            }

        }

        /// <summary>
        /// Update the y axis movement.
        /// </summary>
        public void yAxisUpdate(float delta)
        {
            pos.Y += velocity.Y * delta;
            recHit.Y = (int)(pos.Y - recHit.Height);
            Blocker blocker = world.IsEntityCollidingBlocker(this);
            if (blocker != null)
            {
                if (velocity.Y > 0)
                {
                    pos.Y = blocker.GetRecHit().Y - 5;
                    velocity.Y *= -1f;
                }
                else
                {
                    pos.Y = blocker.GetRecHit().Y + blocker.GetRecHit().Height + recHit.Height + 5;
                    velocity.Y = 0;
                }
                recHit.Y = (int)(pos.Y - recHit.Height);
            }
        }

        /// <summary>
        /// Set the entity to the values of the gene.
        /// </summary>
        /// <param name="gene">The gene to get values from.</param>
        public void SetNextGene(Gene gene)
        {
            jumpPower = gene.jumpPower;
            rotation = gene.rotation;
        }

        /// <summary>
        /// Make the entity jump using the gene values.
        /// </summary>
        public void Jump()
        {
            Vector2 angleVector = new Vector2((float)Math.Sin(rotation), (float)-Math.Cos(rotation));
            angleVector.Normalize();

            velocity = jumpPower * angleVector;

            jumps++;
            left = (!left);
        }

        /// <summary>
        /// Get amount of jumps.
        /// </summary>
        /// <returns>Amount of jumps.</returns>
        protected int GetJumps() { return jumps; }

        /// <summary>
        /// Get position of entity.
        /// </summary>
        /// <returns>Entitys position.</returns>
        public Vector2 GetPos() { return pos; }

        /// <summary>
        /// Is the entity dead
        /// </summary>
        /// <returns>Returns TRUE if dead.</returns>
        public bool IsDead() { return dead; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Globals.debug)
            {
                spriteBatch.Draw(Globals.pixel, recHit, Color.FromNonPremultiplied(255, 0, 0, 150));
                spriteBatch.Draw(Globals.pixel, new Rectangle((int)pos.X, (int)pos.Y, 20, 20), Color.FromNonPremultiplied(0, 255, 0, 255));
            }

            spriteBatch.Draw(texture, offsetDrawRec, recDraw, color, rotation, origin, SpriteEffects.None, 1f);
        }
    }
}
