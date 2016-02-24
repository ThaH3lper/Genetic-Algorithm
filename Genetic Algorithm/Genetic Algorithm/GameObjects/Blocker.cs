using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Genetic_Algorithm
{
    public class Blocker : GameObject
    {
        Vector2 pos;
        Vector2 orginalPos;
        float upMovement;
        float speed;
        float velocity;

        public Blocker(SimulationWorld world, Vector2 pos, float upMovement) : base(world, new Rectangle(0, 0, 50, 200), new Rectangle(0, 0, 1, 1), Globals.pixel)
        {
            speed = 100;
            velocity = speed;
            this.pos = pos;
            orginalPos = pos;
            this.upMovement = upMovement;
        }

        public override void Update(float delta)
        {
            if(velocity < 0)
            {
                pos.Y -= speed * delta;
                if (pos.Y < orginalPos.Y - upMovement)
                    velocity *= -1.0f;
            }
            else
            {
                pos.Y += speed * delta;
                if (pos.Y > orginalPos.Y)
                    velocity *= -1.0f;
            }

            recHit.X = (int)(pos.X - recHit.Width / 2);
            recHit.Y = (int)(pos.Y - recHit.Height / 2);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (Globals.debug)
            {
                spriteBatch.Draw(Globals.pixel, recHit, Color.FromNonPremultiplied(255, 0, 0, 150));
                spriteBatch.Draw(Globals.pixel, new Rectangle((int)pos.X, (int)pos.Y, 5, 5), Color.FromNonPremultiplied(0, 255, 0, 255));
            }
        }
    }
}
