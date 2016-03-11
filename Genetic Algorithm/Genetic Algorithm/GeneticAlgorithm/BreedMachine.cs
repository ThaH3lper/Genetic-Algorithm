using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    class BreedMachine
    {
        /// <summary>
        /// Breed the population in the world.
        /// </summary>
        /// <param name="world">The world the population lives in.</param>
        /// <param name="population">The population we want to breed.</param>
        public static void Breed(SimulationWorld world, Population population)
        {
            AIEntity[] entitys = population.GetEntitys();

            //Bread the top half section to the lower half.
            int topAmount = (int)(population.GetAmount() * 0.5f);
            for (int i = 0; i < topAmount; i += 2)
            {
                Genome a = entitys[i].GetGenome();
                Genome b = entitys[i + 1].GetGenome();
                BreedGenome(world, a, b, i, entitys, population.GetAmount());
                entitys[i] = new AIEntity(world, a.Copy());
                entitys[i + 1] = new AIEntity(world, b.Copy());
            }
        }

        /// <summary>
        /// Breed two Genome with "Uniform crossover".
        /// </summary>
        /// <param name="world">Thw world the population lives in.</param>
        /// <param name="a">The genome of the first parent.</param>
        /// <param name="b">The genome of the second parent.</param>
        /// <param name="newEntityIndex">Where we want the childs to be inserted in the entity arraylist.</param>
        /// <param name="entitys">The entitys in the population.</param>
        /// <param name="populationAmount">The amount of entitys in the population.</param>
        private static void BreedGenome(SimulationWorld world, Genome a, Genome b, int newEntityIndex, AIEntity[] entitys, int populationAmount)
        {
            int amount = a.GetAmount();

            //Creat the new Genome.
            Genome c = new Genome(amount);
            Genome d = new Genome(amount);

            //For each gen select which parent they get there genes from.
            for (int i = 0; i < amount; i++)
            {
                if (Globals.rand.NextDouble() > 0.5f)
                {
                    c.SetGene(i, a.GetGene(i).Copy());
                    d.SetGene(i, b.GetGene(i).Copy());
                }
                else
                {
                    d.SetGene(i, b.GetGene(i).Copy());
                    c.SetGene(i, a.GetGene(i).Copy());
                }
            }

            //Insert the new genome into new entitys and replace them in the list.
            int newIndex = populationAmount - newEntityIndex - 1;
            entitys[newIndex] = new AIEntity(world, c);
            entitys[newIndex - 1] = new AIEntity(world, d);
        }
     }
}
