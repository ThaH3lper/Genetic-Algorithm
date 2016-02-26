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
        public Gene(float rotation, float jumpPower)
        {
            this.rotation = rotation;
            this.jumpPower = jumpPower;
        }

        public Gene Copy()
        {
            return new Gene(rotation, jumpPower);
        }

        public void RealValueMutation()
        {
            
            //float addAngle = (float)((Globals.rand.NextDouble() * Math.PI) - Math.PI / 2);
            if (rotation - (Math.PI * 0.6f) < -Math.PI/2)
                rotation = (float)((Globals.rand.NextDouble() * Math.PI * 0.6) - Math.PI / 2);
            else if (rotation + (Math.PI * 0.6f) > Math.PI / 2)
                rotation = (float)(Math.PI / 2 - (Globals.rand.NextDouble() * Math.PI * 0.6));
            else
                rotation = (float)(rotation - (Math.PI / 2 * 0.6f) + (Globals.rand.NextDouble() * Math.PI * 0.6));

            //Total replacement
            jumpPower = (float)((Globals.rand.NextDouble() * (Globals.maxJumpPower - Globals.minJumpPower)) + Globals.minJumpPower);
        }
    }
}
