using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Genetic_Algorithm
{
    class AIEntity : Entity
    {
        private Genome genome;              //The genome this entity jumps after.
        private int lastJump;               //The amount of succsessful jumps.
        private float fittingValue;         //The fittingvalue
        private float range;                //The range in points to the next platform.

        /// <summary>
        /// Constructor, creates a genome whit 250 genes.
        /// </summary>
        /// <param name="world">The world to live in.</param>
        public AIEntity(SimulationWorld world) : this(world, new Genome(250)) { }

        /// <summary>
        /// Constructor, Creates entity with defined genome.
        /// </summary>
        /// <param name="world">The world to live in.</param>
        /// <param name="genome">The specific genome.</param>
        public AIEntity(SimulationWorld world, Genome genome) : base(world, Globals.startPos)
        {
            this.genome = genome;
            fittingValue = 0;
            lastJump = 0;
            UpdateMutation();
        }

        /// <summary>
        /// Update the mutation of the entity.
        /// </summary>
        public void UpdateMutation(){ SetNextGene(genome.GetGene(lastJump)); }


        /// <summary>
        /// Update the entity.
        /// </summary>
        public override void Update(float delta)
        {
            base.Update(delta);
            if (dead)
                return;
            if(lastJump != jumps)
            {
                lastJump = jumps;
                SetNextGene(genome.GetGene(jumps));
                range = 0;

                //Update best jump?
                if (Globals.amountJumps < lastJump)
                    Globals.amountJumps = lastJump;
            }

            //Update fitting value.
            float distance = world.GetDistansTo(this, left);
            float temp = 1 - (((distance > 1200.0f) ? 1200.0f : distance) / 1200.0f);
            range = (temp > range) ? temp : range;

            fittingValue = lastJump + range;  
        }

        /// <summary>
        /// Get the fitting value.
        /// </summary>
        /// <returns>the fitting value.</returns>
        public float GetFittingValue() { return fittingValue; }

        /// <summary>
        /// Get the genome of the entity.
        /// </summary>
        /// <returns>The genome.</returns>
        public Genome GetGenome() { return genome; }

        /// <summary>
        /// Draw the entity.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
