using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    class Genome
    {
        List<Gene> genes;
        public Genome(int amount)
        {
            genes = new List<Gene>();
            for (int i = 0; i < amount; i++)
            {
                genes.Add(new Gene());
            }
        }

        public Gene GetGene(int index)
        {
            return genes.ElementAt(index);
        }
    }
}
