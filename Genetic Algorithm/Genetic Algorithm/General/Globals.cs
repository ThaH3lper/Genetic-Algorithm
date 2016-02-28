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

        public static float gravity = 1000f;
        public static float rotationSpeed = 20f;

        public static Random rand = new Random();

        public static SpriteFont font;

        public static float maxJumpPower = 1200, minJumpPower = 700;

        public static Vector2 startPos = new Vector2(200, 100);

        public static int amountJumps = 0;

        public static bool debug = false;

        public static void Load(GAMain gaMain)
        {
            sheet = gaMain.Content.Load<Texture2D>("Sheet");
            pixel = gaMain.Content.Load<Texture2D>("pixel");
            font = gaMain.Content.Load<SpriteFont>("font");
        }
    }
}
