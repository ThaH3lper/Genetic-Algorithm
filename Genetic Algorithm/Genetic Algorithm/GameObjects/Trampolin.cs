using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Genetic_Algorithm
{
    public class Trampolin : GameObject
    {
        private Vector2 pos;    //The position of trampoline.
        private float rotation; //The current rotation.
        private float speed;    //The rotation speed.
        private float radian;   //The radian for rotation.

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="world">The world to spawn to.</param>
        /// <param name="pos">The position of trampoline.</param>
        /// <param name="radian">The radian of the circulation.</param>
        /// <param name="speed">The speed of the circultaion.</param>
        public Trampolin(SimulationWorld world, Vector2 pos, float radian, float speed) : base(world, new Rectangle(0, 0, 40, 10), new Rectangle(0, 0, 1, 1), Globals.pixel)
        {
            this.pos = pos;
            this.radian = radian;
            this.speed = speed;
        }
        public override void Update(float delta)
        {
            rotation += delta * speed;
            Vector2 newpos = (new Vector2((float)-Math.Sin(rotation), (float)Math.Cos(rotation)) * radian) + pos;
            recHit.X = (int)(newpos.X - recHit.Width / 2);
            recHit.Y = (int)(newpos.Y);
        }

        /// <summary>
        /// Return the position of trampoline.
        /// </summary>
        /// <returns>The postion of trampoline.</returns>
        public Vector2 GetPos() { return pos; }

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
