using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    class Globals
    {
        public static Texture2D sheet, pixel;
        public static int screenWidth = 1280, screenHeight = 720;

        public static float gravity = 15f;
        public static float rotationSpeed = 10f;

        public static Random rand = new Random();

        public static float maxJumpPower = 17, minJumpPower = 10;

        public static bool debug = false;

        public static void Load(GAMain gaMain)
        {
            sheet = gaMain.Content.Load<Texture2D>("Sheet");
            pixel = gaMain.Content.Load<Texture2D>("pixel");
        }
    }
}
