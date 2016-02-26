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
        Genome genome;
        int lastJump;
        float fittingLevel, range;

        public AIEntity(SimulationWorld world) : this(world, new Genome(105)) { }
        public AIEntity(SimulationWorld world, Genome genome) : base(world, Globals.startPos)
        {
            this.genome = genome;
            fittingLevel = 0;
            lastJump = 0;
            SetNextGene(genome.GetGene(lastJump));
        }

        public void UpdateMutation()
        {
            SetNextGene(genome.GetGene(lastJump));
        }

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
            }
            float distance = world.GetDistansTo(this, left);
            float temp = 1 - (((distance > 1200.0f) ? 1200.0f : distance) / 1200.0f);
            range = (temp > range) ? temp : range;

            fittingLevel = lastJump + range;  
        }
        public float GetFittingLevel() { return fittingLevel; }

        public Genome GetGenome() { return genome; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
