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

        public AIEntity(SimulationWorld world, Vector2 pos) : base(world, pos)
        {
            genome = new Genome(10);
            lastJump = 0;
            SetNextGene(genome.GetGene(lastJump));
        }

        public override void Update(float delta)
        {
            base.Update(delta);
            if(lastJump != jumps)
            {
                lastJump = jumps;
                SetNextGene(genome.GetGene(jumps));
            }
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
