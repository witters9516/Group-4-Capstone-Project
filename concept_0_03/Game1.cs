using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace concept_0_03
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private IGameScreenManager m_screenManager;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 600,
                PreferredBackBufferWidth = 800,
            };
            IsMouseVisible = true;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }
        
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            m_screenManager = new GameScreenManager(spriteBatch, Content);
            m_screenManager.OnGameExit += Exit;

            m_screenManager.ChangeScreen(new MenuScreen(m_screenManager));
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            if(m_screenManager != null)
            {
                m_screenManager.Dispose();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            m_screenManager.ChangeBetweenScreens();

            m_screenManager.HandleInput(gameTime);
            m_screenManager.Update(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            m_screenManager.Draw(gameTime);

            Window.Title = "Game Title Here???";

            base.Draw(gameTime);
        }
    }
}
