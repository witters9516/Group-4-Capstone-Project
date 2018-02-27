using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace concept_0_03
{
    class MenuScreen : IGameScreen
    {
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;

        private Text m_titleText;
        private List<Component> m_components;
        private SoundEffect click;

        private SoundEffect bgSong;
        private SoundEffectInstance bgMusic;
        private bool isMusicStopped = false;

        public bool IsPaused { get; private set; }

        public MenuScreen(IGameScreenManager gameScreenManager)
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
            SpriteFont m_font = content.Load <SpriteFont>("Fonts/TitleFont");
            click = content.Load<SoundEffect>("SFX/Select_Click");

            bgSong = content.Load<SoundEffect>("Music/Bit Quest");
            bgMusic = bgSong.CreateInstance();

            bgMusic.IsLooped = true;
            bgMusic.Play();

            #region Title Stuff
            string titleText = "GAME TITLE HERE";
            var x = (800 / 2) - (m_font.MeasureString(titleText).X / 2);
            var y = 100;
            Vector2 m_textPosition = new Vector2(x, y);
            Color m_color = Color.Black;

            m_titleText = new Text(titleText, m_font, m_textPosition, m_color);
            #endregion

            #region Button Variables

            var buttonTexture = content.Load<Texture2D>("Menu/Grey/grey_button00");
            var buttonFont = content.Load<SpriteFont>("Fonts/Font");

            #endregion

            #region New Game Button

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            #endregion
            #region Load Button

            var loadGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Load Game",
            };

            loadGameButton.Click += LoadGameButton_Click;

            #endregion
            #region Options Button

            var optionsGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
                Text = "Options",
            };

            optionsGameButton.Click += OptionsGameButton_Click;

            #endregion
            #region Quit Button

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 350),
                Text = "Quit",
            };

            quitGameButton.Click += QuitGameButton_Click;

            #endregion

            m_components = new List<Component>()
            {
                newGameButton,
                loadGameButton,
                optionsGameButton,
                quitGameButton,
            };
        }

        #region Button Methods
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            click.Play();
            bgMusic.Stop();
            m_ScreenManager.ChangeScreen(new LevelOneScreen(m_ScreenManager));
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            click.Play();

            Console.WriteLine("Load Game");
        }

        private void OptionsGameButton_Click(object sender, EventArgs e)
        {
            bgMusic.Stop();
            isMusicStopped = true;

            m_ScreenManager.PushScreen(new OptionsScreen(m_ScreenManager));
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            m_exitGame = true;
        }
        #endregion

        public void Pause()
        {
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            m_titleText.Draw(spriteBatch);

            foreach (var component in m_components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var component in m_components)
                component.Update(gameTime);

            if (isMusicStopped == true)
            {
                isMusicStopped = false;
                bgMusic.Play();
            }
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
