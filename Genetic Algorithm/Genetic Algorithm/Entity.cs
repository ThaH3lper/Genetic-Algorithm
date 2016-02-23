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
        bool roatationHigher;
        protected bool left;
        bool dead;

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
            velocity.Y += delta * Globals.gravity;
            pos += velocity;

            recHit.X = (int)(pos.X - recHit.Width/2);
            recHit.Y = (int)(pos.Y - recHit.Height);

            if (roatationHigher)
            {
                if (rotation < nextRotation)
                    rotation += delta * Globals.rotationSpeed;
                else
                    rotation = nextRotation;
            }
            else
            {
                if (rotation > nextRotation)
                    rotation -= delta * Globals.rotationSpeed;
                else
                    rotation = nextRotation;
            }

            rotationRec = new Rectangle((int)(recHit.X + origin.X), (int)(recHit.Y + origin.Y), recHit.Width, recHit.Height);

            if(world.IsEntityOnTrampoline(this, left))
                Jump();
            if (pos.Y > Globals.screenHeight + recHit.Height)
                dead = true;
        }

        public void SetNextGene(Gene gene)
        {
            jumpPower = gene.jumpPower;
            if (rotation < Math.PI)
            {
                roatationHigher = true;
                nextRotation = gene.rotation + (float)(Math.PI * 2);
            }
            else
            {
                nextRotation = gene.rotation;
                roatationHigher = false;
            }
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
            if (Globals.debug)
            {
                spriteBatch.Draw(Globals.pixel, recHit, Color.FromNonPremultiplied(255, 0, 0, 150));
                spriteBatch.Draw(Globals.pixel, new Rectangle((int)pos.X, (int)pos.Y, 5, 5), Color.FromNonPremultiplied(0, 255, 0, 255));
            }

            spriteBatch.Draw(texture, rotationRec, recDraw, color, rotation, origin, SpriteEffects.None, 1f);
        }
    }
}
