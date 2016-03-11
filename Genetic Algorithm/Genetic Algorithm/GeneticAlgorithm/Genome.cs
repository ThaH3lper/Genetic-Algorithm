using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    class Genome
    {
        private List<Gene> genes;   //The genes in this genome.
        private int amount;         //The amount of genome.

        /// <summary>
        /// Copnstructor. Creates an amount of random genes.
        /// </summary>
        /// <param name="amount">The amount of genes.</param>
        public Genome(int amount)
        {
            this.amount = amount;
            genes = new List<Gene>();
            for (int i = 0; i < amount; i++)
                genes.Add(new Gene());
        }

        /// <summary>
        /// Constructor, used to copy genome.
        /// </summary>
        /// <param name="genes">Specific genes that this genome should have.</param>
        /// <param name="amount">Specific amount that this genome should have.</param>
        public Genome(List<Gene> genes, int amount)
        {
            this.genes = genes;
            this.amount = amount;
        }

        /// <summary>
        /// Copy this genome and all the genes inside.
        /// </summary>
        /// <returns>A copy of this genome.</returns>
        public Genome Copy()
        {
            List<Gene> temp = new List<Gene>();
            foreach (Gene gene in genes)
                temp.Add(gene.Copy());
            return new Genome(temp, amount);
        }

        /// <summary>
        /// Mutate this genome. Can mutate all the genes.
        /// </summary>
        /// <param name="percentOfGene">The amount in precentage of genes that should be mutated.</param>
        public void Mutate(float percentOfGene)
        {
            for (int i = 0; i < genes.Count; i++)
            {
                if(percentOfGene > Globals.rand.NextDouble())
                    genes[i].Mutate();
            }

        }
        /// <summary>
        /// Mutate this genome. Can only mutate genes that are related to jumps three behind the best entity.
        /// </summary>
        /// <param name="percentOfGene">The amount in precentage of genes that should be mutated.</param>
        public void New_Mutate(float percentOfGene)
        {
            int start = Globals.amountJumps - 3;
            for (int i = (start < 0) ? 0 : start; i < genes.Count; i++)
            {
                if (percentOfGene > Globals.rand.NextDouble())
                    genes[i].Mutate();
            }

        }

        /// <summary>
        /// Get the gene at a specific index.
        /// </summary>
        /// <param name="index">The index of the gene.</param>
        /// <returns>The gene at the index.</returns>
        public Gene GetGene(int index)
        {
            if (index >= amount)
                return genes.ElementAt(amount - 1);
            return genes.ElementAt(index);
        }

        /// <summary>
        /// Get the amount of genes in this genome.
        /// </summary>
        /// <returns>The amount of genes.</returns>
        public int GetAmount(){ return amount; }

        /// <summary>
        /// Set a gene at specific index.
        /// </summary>
        /// <param name="index">The index we want to insert to.</param>
        /// <param name="gene">The gene we want to insert.</param>
        public void SetGene(int index, Gene gene){ genes.Insert(index, gene); }
    }
}
