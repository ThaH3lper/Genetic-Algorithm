using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    class BreedMachine
    {
        public static void Breed(SimulationWorld world, AIEntity[] entitys)
        {
            Genome g = entitys[0].GetGenome().Copy();
            entitys[0] = new AIEntity(world, g);
            entitys[0].Selected = true;

            //Copy The best over
            int start = 1;
            int stop = 500; //FIX!

            BreedSection(world, start, stop, 0, entitys);
            }

        private static void BreedSection(SimulationWorld world, int start, int end, int bestParent, AIEntity[] entitys)
        {
            Genome a = entitys[bestParent].GetGenome();
            for (int i = start; i < end; i++)
            {
                Genome b = entitys[i].GetGenome();
                BreedGenome(world, a, b, i, entitys);
            }
        }

        private static void BreedGenome(SimulationWorld world, Genome a, Genome b, int newEntityIndex, AIEntity[] entitys)
        {
            int amount = a.GetAmount();
            Genome newGenome = new Genome(amount);
            for (int i = 0; i < amount; i++)
            {
                if(Globals.rand.NextDouble() > 0.5f)
                    newGenome.SetGene(i, a.GetGene(i).Copy());
                else
                    newGenome.SetGene(i, b.GetGene(i).Copy());
            }
            entitys[newEntityIndex] = new AIEntity(world, newGenome);           
        }
     }
}
