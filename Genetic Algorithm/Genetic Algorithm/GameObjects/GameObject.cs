using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Genetic_Algorithm
{
    public class GameObject
    {
        protected Rectangle recDraw;        //The rectangel from the texture.
        protected Rectangle recHit;         //The rectangle to draw to and check collision.
        protected Texture2D texture;        //The texture of gameobject.
        protected Color color;              //The tint color.
        protected SimulationWorld world;    //The world to spawn in.

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="world">The world to spawn in.</param>
        /// <param name="recHit">The collision rectangle.</param>
        /// <param name="recDraw">The rectangle to take from texture.</param>
        /// <param name="texture">The texture to applay to object.</param>
        public GameObject(SimulationWorld world, Rectangle recHit, Rectangle recDraw, Texture2D texture)
        {
            this.world = world;
            this.recHit = recHit;
            this.recDraw = recDraw;
            this.texture = texture;
            this.color = Color.Black;
        }

        public virtual void Update(float delta){}

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, recHit, recDraw, color);
        }

        /// <summary>
        /// Get the collision rectangle.
        /// </summary>
        /// <returns>The collision rectangle.</returns>
        public Rectangle GetRecHit(){return recHit;}
    }
}
