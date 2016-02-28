using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Genetic_Algorithm
{
    public class SimulationWorld
    {
        Population popultion;
        Trampolin leftTramp, rightTramp;
        Blocker blocker;

        public SimulationWorld()
        {
            popultion = new Population(this, 500);
            InitWorld();
        }
        public void InitWorld()
        {
            leftTramp = new Trampolin(this, new Vector2(320, 500), 120, 1.5f);
            rightTramp = new Trampolin(this, new Vector2(960, 500), 180, 2f);
            blocker = new Blocker(this, new Vector2(Globals.screenWidth/2, 500), 300);
        }

        public void Update(float delta)
        {
            leftTramp.Update(delta);
            rightTramp.Update(delta);
            blocker.Update(delta);

            popultion.Update(delta);

            if(popultion.IsDead())
            {
                popultion.SortAfterFitness();
                Logger.LoggPopulation(popultion);
                popultion.Breed();
                popultion.Mutate(0.15f);
                System.Console.WriteLine("Amount of jumps: " + Globals.amountJumps);
                InitWorld();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            popultion.Draw(spriteBatch);
            leftTramp.Draw(spriteBatch);
            rightTramp.Draw(spriteBatch);
            blocker.Draw(spriteBatch);

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

        public Blocker IsEntityCollidingBlocker(Entity e)
        {
            if (blocker.GetRecHit().Intersects(e.GetRecHit()))
                return blocker;
            return null;
        }

        public float GetDistansTo(Entity e, bool left)
        {
            if (left)
                return (e.GetPos() - leftTramp.GetPos()).Length();
            else
                return (e.GetPos() - rightTramp.GetPos()).Length();
        }
    }
}