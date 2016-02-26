using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    class BreedMachine
    {
        public static void Breed(SimulationWorld world, Population population)
        {
            AIEntity[] entitys = population.GetEntitys();
            //Genome g = entitys[0].GetGenome().Copy();
            //entitys[0] = new AIEntity(world, g);
            //entitys[0].Selected = true;

            int topAmount = (int)(population.GetAmount() * 0.5f);

            BreedSection(world, 0, topAmount, entitys, population.GetAmount());
            }

        private static void BreedSection(SimulationWorld world, int start, int end, AIEntity[] entitys, int populationAmount)
        {
            for (int i = start; i < end; i+=2)
            {
                Genome a = entitys[i].GetGenome();
                Genome b = entitys[i+1].GetGenome();
                //Console.WriteLine(i + " " + (i + 1) + " -> ");
                BreedGenome(world, a, b, i, entitys, populationAmount);
                entitys[i] = new AIEntity(world, a.Copy());
                entitys[i + 1] = new AIEntity(world, b.Copy());
            }
        }

        private static void BreedGenome(SimulationWorld world, Genome a, Genome b, int newEntityIndex, AIEntity[] entitys, int populationAmount)
        {
            int amount = a.GetAmount();
            Genome c = new Genome(amount);
            Genome d = new Genome(amount);
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
            int newIndex = populationAmount - newEntityIndex - 1;
            entitys[newIndex] = new AIEntity(world, c);
            entitys[newIndex - 1] = new AIEntity(world, d);
            //Console.WriteLine(newIndex + " " + (newIndex - 1) + " <- ");
        }
     }
}
