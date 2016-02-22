using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    public class Gene
    {
        public float jumpPower { get; private set; }
        public float rotation { get; private set; }

        public Gene()
        {
            rotation = (float) ((Globals.rand.NextDouble() * Math.PI) - Math.PI/2);
            jumpPower = (float) ((Globals.rand.NextDouble() * (Globals.maxJumpPower - Globals.minJumpPower)) + Globals.minJumpPower);
        }

        public Gene(Gene gene, float mutation)
        {
            //Todo
        }
    }
}
