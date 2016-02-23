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

        public SimulationWorld()
        {
            popultion = new Population(this, 1000);
            InitTramps();
        }
        public void Reset()
        {
            InitTramps();
        }
        public void InitTramps()
        {
            leftTramp = new Trampolin(this, new Vector2(320, 500), 120, 1.5f);
            rightTramp = new Trampolin(this, new Vector2(960, 500), 180, 2f);
        }

        public void Update(float delta)
        {
            popultion.Update(delta);
            leftTramp.Update(delta);
            rightTramp.Update(delta);
            if(popultion.IsDead())
            {
                popultion.SortAfterFitness();
                popultion.BreadPopulation();
                Reset();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            popultion.Draw(spriteBatch);
            leftTramp.Draw(spriteBatch);
            rightTramp.Draw(spriteBatch);

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

        public float GetDistansTo(Entity e, bool left)
        {
            if (left)
                return (e.GetPos() - leftTramp.GetPos()).Length();
            else
                return (e.GetPos() - rightTramp.GetPos()).Length();
        }
    }
}