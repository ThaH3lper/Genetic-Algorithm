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

        public void RealValueMutation(float mutation)
        {
            
            float addAngle = (float)((Globals.rand.NextDouble() * Math.PI) - Math.PI / 2) * mutation;
            if (rotation + addAngle < -Math.PI / 2)
            {
                float below = (float)((rotation + addAngle) + Math.PI / 2);
                rotation -= below;
            }
            else if (rotation + addAngle > Math.PI / 2)
            {
                float above = (float)((rotation + addAngle) - Math.PI / 2);
                rotation -= above;
            }
            else
                rotation += addAngle;

            float addPower = (float)((Globals.rand.NextDouble() * (Globals.maxJumpPower - Globals.minJumpPower)) + Globals.minJumpPower) * mutation;
            if (jumpPower + addPower > Globals.maxJumpPower)
            {
                float above = (jumpPower + addPower) - Globals.maxJumpPower;
                jumpPower -= above;
            }
            else if (jumpPower + addPower < Globals.minJumpPower)
            {
                float below = Globals.minJumpPower - (jumpPower + addPower);
                jumpPower += below;
            }
            else
                jumpPower += addPower;
        }
    }
}
