using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Genetic_Algorithm
{
    public class SimulationWorld
    {
        private Population popultion;               //The population that we breed, mutate and make "better".
        private Trampolin leftTramp, rightTramp;    //The trampolines that circle around.
        private Blocker blocker;                    //The block in the middle.

        /// <summary>
        /// Constructor. Creates population and initilizes the world.
        /// </summary>
        public SimulationWorld()
        {
            popultion = new Population(this, 500);
            InitWorld();
        }

        /// <summary>
        /// Create the trampolines and the block in the middle.
        /// </summary>
        public void InitWorld()
        {
            leftTramp = new Trampolin(this, new Vector2(320, 500), 120, 1.5f);
            rightTramp = new Trampolin(this, new Vector2(960, 500), 180, 2f);
            blocker = new Blocker(this, new Vector2(Globals.screenWidth/2, 500), 300);
        }

        /// <summary>
        /// Update the world.
        /// </summary>
        /// <param name="delta">Delta time</param>
        public void Update(float delta)
        {
            //Update the world elements.
            leftTramp.Update(delta);
            rightTramp.Update(delta);
            blocker.Update(delta);

            //Update population
            popultion.Update(delta);

            //If population is dead, start the next generation
            if(popultion.IsDead())
            {
                popultion.SortAfterFitness();                                           //Sort the population after fitness
                Logger.LoggPopulation(popultion);                                       //Logg the best resultat.
                popultion.Breed();                                                      //Breed the population.
                popultion.Mutate(0.15f);                                                //Mutate the population.
                System.Console.WriteLine("Amount of jumps: " + Globals.amountJumps);
                InitWorld();                                                            //Restart world.
            }
        }

        /// <summary>
        /// Draw everything in the world.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            popultion.Draw(spriteBatch);
            leftTramp.Draw(spriteBatch);
            rightTramp.Draw(spriteBatch);
            blocker.Draw(spriteBatch);

            spriteBatch.End();
        }

        /// <summary>
        /// Collision detection with trampolines.
        /// </summary>
        /// <param name="e">The entity that we want to check.</param>
        /// <param name="left">Is it the left or right trmpoline?</param>
        /// <returns></returns>
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

        /// <summary>
        /// Collision detection for the block in the middle.
        /// </summary>
        /// <param name="e">The entity we want to check.</param>
        /// <returns></returns>
        public Blocker IsEntityCollidingBlocker(Entity e)
        {
            if (blocker.GetRecHit().Intersects(e.GetRecHit()))
                return blocker;
            return null;
        }

        /// <summary>
        /// Get the distance to the trampoline.
        /// </summary>
        /// <param name="e">The entity we want to check from.</param>
        /// <param name="left">Is it the left or right trampoline?</param>
        /// <returns></returns>
        public float GetDistansTo(Entity e, bool left)
        {
            if (left)
                return (e.GetPos() - leftTramp.GetPos()).Length();
            else
                return (e.GetPos() - rightTramp.GetPos()).Length();
        }
    }
}