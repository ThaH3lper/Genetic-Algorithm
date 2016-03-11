using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    class Population
    {
        private AIEntity[] entitys;     //The entitys in the population.
        private List<AIEntity> dead;    //The dead entitys gets added to this list.

        private SimulationWorld world;  //The world this population lives in.
        private int amount;             //The amount of entitys in this population.

        /// <summary>
        /// Constuctor. Creates the entitys in the population.
        /// </summary>
        /// <param name="world">The world the population lives in.</param>
        /// <param name="amount">The amount of entitys in this population.</param>
        public Population(SimulationWorld world, int amount)
        {
            this.amount = amount;
            this.world = world;
            entitys = new AIEntity[amount];
            dead = new List<AIEntity>();

            for (int i = 0; i < amount; i++)
                entitys[i] = new AIEntity(world);
        }

        /// <summary>
        /// Update the population.
        /// </summary>
        /// <param name="delta">The delta time.</param>
        public void Update(float delta)
        {
            foreach (AIEntity e in entitys)
            {
                e.Update(delta);
                if (e.IsDead() && !dead.Contains(e))
                    dead.Add(e);
            }
        }

        /// <summary>
        /// Mutate the population.
        /// </summary>
        /// <param name="percentageOfGeneMutation">The percentage of genes that should be mutated.</param>
        public void Mutate(float percentageOfGeneMutation)
        {
            for (int i = 1; i < amount; i++)
            {
                entitys[i].GetGenome().New_Mutate(percentageOfGeneMutation);            //Use the new mutation method.
                //entitys[i].GetGenome().Mutate(percentageOfGeneMutation);              //Use the old mutation method.
                entitys[i].UpdateMutation();                                            //Update the mutation for the entity.
            }
        }

        /// <summary>
        /// Draw the population.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (AIEntity e in entitys)
                e.Draw(spriteBatch);
            spriteBatch.DrawString(Globals.font, "Living: " + (amount - dead.Count), new Vector2(0, 0), Color.Black);
        }

        /// <summary>
        /// Breed this population.
        /// </summary>
        public void Breed()
        {
            dead.Clear();
            BreedMachine.Breed(world, this);
        }

        /// <summary>
        /// Check if all the entitys in the population is dead.
        /// </summary>
        /// <returns>True if all entitys are dead.</returns>
        public bool IsDead(){ return (dead.Count == entitys.Length); }

        /// <summary>
        /// Sort the population after fitness.
        /// </summary>
        public void SortAfterFitness(){ SortAlgorithm.MergeSort(entitys, 0, entitys.Length - 1); }

        /// <summary>
        /// Get the amount of entitys in this population.
        /// </summary>
        /// <returns>The amount of entitys.</returns>
        public int GetAmount() { return amount; }

        /// <summary>
        /// Get the entitys in this population.
        /// </summary>
        /// <returns>the entitys in a array.</returns>
        public AIEntity[] GetEntitys() { return entitys; }
    }
}
