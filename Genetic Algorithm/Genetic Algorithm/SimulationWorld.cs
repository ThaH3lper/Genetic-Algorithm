using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Genetic_Algorithm
{
    public class SimulationWorld
    {
        List<GameObject> gameObjects;
        Trampolin leftTramp, rightTramp;

        public SimulationWorld()
        {
            gameObjects = new List<GameObject>();

            for (int i = 0; i < 1000; i++)
            {
                AddGameObject(new AIEntity(this, new Vector2(200, 100)));
            }

            InitTrampolins();
        }

        public void AddGameObject(GameObject o)
        {
            gameObjects.Add(o);
        }

        public void InitTrampolins()
        {
            leftTramp = new Trampolin(this, new Vector2(320, 500), 120, 1.5f);
            AddGameObject(leftTramp);
            rightTramp = new Trampolin(this, new Vector2(960, 500), 180, 2f);
            AddGameObject(rightTramp);
        }

        public void Update(float delta)
        {
            foreach (GameObject o in gameObjects)
                o.Update(delta);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (GameObject o in gameObjects)
                o.Draw(spriteBatch);
            spriteBatch.End();
        }

        public bool IsEntityOnTrampoline(Entity e, bool left)
        {
            if(left)
            {
                if (leftTramp.GetRecHit().Intersects(e.GetRecHit()))
                    return true;
            }
            else
            {
                if (rightTramp.GetRecHit().Intersects(e.GetRecHit()))
                    return true;
            }
            return false;
        }
    }
}