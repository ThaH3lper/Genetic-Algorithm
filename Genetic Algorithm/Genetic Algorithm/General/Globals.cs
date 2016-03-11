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
        //Screen resulution
        public static int screenWidth = 1280, screenHeight = 720;

        //Gravit in the world
        public static float gravity = 1000f;

        //A Global random
        public static Random rand = new Random();

        //Content
        public static SpriteFont font;
        public static Texture2D sheet, pixel;

        //Range of jump power that the entitys can get.
        public static float maxJumpPower = 1200, minJumpPower = 700;

        //Where we want to spawn the entitys.
        public static Vector2 startPos = new Vector2(200, 100);

        //Keep track of the top amount of jumps made by a entity.
        public static int amountJumps = 0;

        //Set to true to show debug boxes/collision boxes.
        public static bool debug = false;

        /// <summary>
        /// Load all the content.
        /// </summary>
        /// <param name="gaMain">GAMain so we can load the content.</param>
        public static void Load(GAMain gaMain)
        {
            sheet = gaMain.Content.Load<Texture2D>("Sheet");
            pixel = gaMain.Content.Load<Texture2D>("pixel");
            font = gaMain.Content.Load<SpriteFont>("font");
        }
    }
}
