using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    public class Gene
    {
        public float jumpPower { get; private set; }    //The Jump power of the jump.
        public float rotation { get; private set; }     //The rotation/angle of the jump.

        /// <summary>
        /// Construcor, creates random values.
        /// </summary>
        public Gene()
        {
            rotation = (float) ((Globals.rand.NextDouble() * Math.PI) - Math.PI/2);
            jumpPower = (float) ((Globals.rand.NextDouble() * (Globals.maxJumpPower - Globals.minJumpPower)) + Globals.minJumpPower);
        }

        /// <summary>
        /// Construcor, used when gene is copied.
        /// </summary>
        /// <param name="rotation">Specific rotaton.</param>
        /// <param name="jumpPower">Specific jumpPower.</param>
        public Gene(float rotation, float jumpPower)
        {
            this.rotation = rotation;
            this.jumpPower = jumpPower;
        }

        /// <summary>
        /// Copy the gene.
        /// </summary>
        /// <returns>A exact copy of the gene.</returns>
        public Gene Copy()
        {
            return new Gene(rotation, jumpPower);
        }

        /// <summary>
        /// Mutate this Gene.
        /// </summary>
        public void Mutate()
        {        
            //Real value mutate the rotation.
            if (rotation - (Math.PI * 0.6f) < -Math.PI/2)
                rotation = (float)((Globals.rand.NextDouble() * Math.PI * 0.6) - Math.PI / 2);
            else if (rotation + (Math.PI * 0.6f) > Math.PI / 2)
                rotation = (float)(Math.PI / 2 - (Globals.rand.NextDouble() * Math.PI * 0.6));
            else
                rotation = (float)(rotation - (Math.PI / 2 * 0.6f) + (Globals.rand.NextDouble() * Math.PI * 0.6));

            //Total replacem the jump power.
            jumpPower = (float)((Globals.rand.NextDouble() * (Globals.maxJumpPower - Globals.minJumpPower)) + Globals.minJumpPower);
        }
    }
}
