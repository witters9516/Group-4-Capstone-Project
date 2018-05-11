using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace concept_0_03
{
    class GameOverScreen : IGameScreen
    {
        //Screen Main Variables
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;
        private List<Component> m_components;
        private SoundEffect bgSong;
        private Text gameOver;
        public bool IsPaused { get; private set; }

        //Constructor
        public GameOverScreen(IGameScreenManager gameScreenManager)
        {
            m_ScreenManager = gameScreenManager;
        }

        public void ChangeBetweenScreens()
        {
            if (m_exitGame)
            {
                m_ScreenManager.Exit();
            }
        }

        public void Init(ContentManager content)
        {
            #region Game Over Text Rendering
            Vector2 m_Position = new Vector2(350, 150); //Set Position
            Color m_Color = Color.Black;                //Set Color

            //Set gameOver Variables
            gameOver = new Text("Game Over", content.Load<SpriteFont>("Fonts/TitleFont"), m_Position, m_Color);
            gameOver.CenterHorizontal(800, 150);
            #endregion

            // Background
            var background = new Sprite(content.Load<Texture2D>("BGs/bgGameOver"));

            #region Music
            //Set Battle Music
            bgSong = content.Load<SoundEffect>("Music/SweetDreamsNonLoop");

            //Configure m_audioState
            switch (Game1.m_audioState)
            {
                case Game1.AudioState.OFF:
                    Game1.currentInstance = bgSong.CreateInstance();
                    Game1.currentInstance.Volume = Game1.musicVolume;

                    break;
                case Game1.AudioState.PAUSED:
                    Game1.currentInstance = bgSong.CreateInstance();
                    Game1.currentInstance.Volume = Game1.musicVolume;

                    break;
                case Game1.AudioState.PLAYING:
                    Game1.currentInstance = bgSong.CreateInstance();
                    Game1.currentInstance.Volume = Game1.musicVolume;

                    Game1.currentInstance.Play();
                    break;
            }
            #endregion
            #region Button Variables
            //Set Button Variables
            var buttonTexture = content.Load<Texture2D>("Menu/Grey/grey_button04");
            var buttonFont = content.Load<SpriteFont>("Fonts/Font");

            #endregion
            #region Menu Button
            //Create Menu Button and click events
            var menuButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(305, 250),
                Text = "Return to Menu"
            };

            menuButton.Click += MenuButton_Click;

            #endregion
            #region Quit Button
            //Create Quit Button and click events
            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(305, 300),
                Text = "Quit",
            };

            quitGameButton.Click += QuitGameButton_Click;

            #endregion
            //List Of components for drawing
            m_components = new List<Component>()
            {
                background,
                menuButton,
                quitGameButton,
            };
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            //Turn Music Off
            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();
            //Set game variables back to default.
            Game1.isOnWorldMap = false; //Prevents saving in the options screen.
            Game1.levelsUnlocked = 0;   //Sets the starting level back to zero.
            //Change Screen Back to Main Menu
            m_ScreenManager.ChangeScreen(new MenuScreen(m_ScreenManager));
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            m_exitGame = true;
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }

        public void Update(GameTime gameTime)
        {
            foreach (var component in m_components)
                component.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();    //Begin spriteBatch

            //Draw gameOver
            gameOver.Draw(spriteBatch);

            //Draw components to screen.
            foreach (var component in m_components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();    //End spriteBatch
        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                m_exitGame = true;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
