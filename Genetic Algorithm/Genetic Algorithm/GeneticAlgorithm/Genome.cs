using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    class Genome
    {
        List<Gene> genes;
        int amount;
        public Genome(int amount)
        {
            this.amount = amount;
            genes = new List<Gene>();
            for (int i = 0; i < amount; i++)
            {
                genes.Add(new Gene());
            }
        }

        public Genome(List<Gene> genes, int amount)
        {
            this.genes = genes;
            this.amount = amount;
        }

        public int GetAmount()
        {
            return amount;
        }

        public Genome Copy()
        {
            List<Gene> temp = new List<Gene>();
            foreach (Gene gene in genes)
                temp.Add(gene.Copy());
            return new Genome(temp, amount);
        }

        public void Mutate(float percentOfGene)
        {
            for (int i = 0; i < genes.Count; i++)
            {
                if(percentOfGene > Globals.rand.NextDouble())
                    genes[i].RealValueMutation();
            }

        }
        public void New_Mutate(float percentOfGene)
        {
            int start = Globals.amountJumps - 3;
            for (int i = (start < 0) ? 0 : start; i < genes.Count; i++)
            {
                if (percentOfGene > Globals.rand.NextDouble())
                    genes[i].RealValueMutation();
            }

        }

        public Gene GetGene(int index)
        {
            if (index >= amount)
                return genes.ElementAt(amount - 1);
            return genes.ElementAt(index);
        }

        public void SetGene(int index, Gene gene)
        {
            genes.Insert(index, gene);
        }
    }
}
