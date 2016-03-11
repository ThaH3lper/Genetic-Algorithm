using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Genetic_Algorithm
{
    public class GAMain : Game
    {
        private GraphicsDeviceManager graphics; //Graphicdevice to be able to paint.
        private SpriteBatch spriteBatch;        //Spritebatch so we can paint on the graphic device.

        private SimulationWorld world;          //A simulation world.

        public GAMain()
        {
            //Setup Graphics.
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Globals.screenWidth;
            graphics.PreferredBackBufferHeight = Globals.screenHeight;
            Content.RootDirectory = "Content";

            //Reset all textfiles / loggers.
            Logger.ResetAll();
        }
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.Load(this);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            world = new SimulationWorld();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();
            if (KeyMouseReader.KeyClick(Keys.Escape))
                Exit();

            //Calculate delta and multiply it with 2.2.
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            delta *= 2.2f;
        
            //Update the simulation world.
            world.Update(delta);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            world.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
