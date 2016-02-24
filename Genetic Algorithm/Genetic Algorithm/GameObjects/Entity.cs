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
        float rotation, nextRotation;
        Vector2 origin;
        Vector2 pos;
        Rectangle rotationRec;
        Vector2 velocity;
        float jumpPower;
        protected int jumps;
        protected bool left;
        protected bool dead;
        public bool Selected = false;

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
            velocity.Y += Globals.gravity * delta;

            yAxisUpdate(delta);
            xAxisUpdate(delta);

            rotation = nextRotation;
            rotationRec = new Rectangle((int)(recHit.X + origin.X), (int)(recHit.Y + origin.Y), recHit.Width, recHit.Height);

            if (world.IsEntityOnTrampoline(this, left))
                Jump();
            if (pos.Y > Globals.screenHeight + recHit.Height)
                dead = true;
        }

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

        public void SetNextGene(Gene gene)
        {
            jumpPower = gene.jumpPower;
            nextRotation = gene.rotation;
        }

        public void Jump()
        {
            Vector2 angleVector = new Vector2((float)Math.Sin(rotation), (float)-Math.Cos(rotation));
            angleVector.Normalize();

            velocity = jumpPower * angleVector;

            jumps++;
            left = (!left);
        }
        protected int GetJumps() { return jumps; }

        public Vector2 GetPos() { return pos; }

        public bool IsDead() { return dead; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Globals.debug || Selected)
            {
                spriteBatch.Draw(Globals.pixel, recHit, Color.FromNonPremultiplied(255, 0, 0, 150));
                spriteBatch.Draw(Globals.pixel, new Rectangle((int)pos.X, (int)pos.Y, 20, 20), Color.FromNonPremultiplied(0, 255, 0, 255));
            }

            spriteBatch.Draw(texture, rotationRec, recDraw, color, rotation, origin, SpriteEffects.None, 1f);
        }
    }
}
