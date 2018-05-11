using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace concept_0_03
{
    class MenuScreen : IGameScreen
    {
        //Screen Variables
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;
        private Command m_command;
        private Text m_titleText;
        private List<Component> m_components;
        private SoundEffect click;
        private SoundEffect bgSong;
        public bool IsPaused { get; private set; }

        #region Touch Input Testing -- Nonfunctional
        TouchCollection touchCollection;
        #endregion

        //Constructor
        public MenuScreen(IGameScreenManager gameScreenManager)
        {
            m_ScreenManager = gameScreenManager;
            m_command = new Command(m_ScreenManager);
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
            #region Touch Input Testing -- Nonfunctional
            TouchPanel.EnabledGestures = GestureType.Tap | GestureType.DoubleTap;
            #endregion

            //Font loaded
            SpriteFont m_font = content.Load <SpriteFont>("Fonts/TitleFont");
            //Load Click and Battle Game Music
            click = content.Load<SoundEffect>("SFX/Select_Click");
            bgSong = content.Load<SoundEffect>("Music/GoodMemories");
            //Battle game music variables set.
            Game1.currentInstance = bgSong.CreateInstance();
            Game1.currentInstance.IsLooped = true;
            Game1.currentInstance.Volume = Game1.musicVolume;
            Game1.m_audioState = Game1.AudioState.PLAYING;
            Game1.currentInstance.Play();

            //Background Sprite
            var screenBackground = new Sprite(content.Load<Texture2D>("BGs/bgMountains"))
            {
                Position = new Vector2(-100, -2)
            };

            //Title Variables
            #region Title Stuff
            var x = (800 / 2) - (600 / 2);
            var y = 0;
            Vector2 m_titlePosition = new Vector2(x, y);
            

            var japakeysLogo = new Sprite(content.Load<Texture2D>("Menu/japakeysLogo"))
            {
                Position = m_titlePosition
            };
            #endregion

            #region Button Variables
            //Button Textures
            var buttonTexture = content.Load<Texture2D>("Menu/Grey/grey_button04");
            var buttonFont = content.Load<SpriteFont>("Fonts/Font");
            #endregion

            //In Game Buttons
            #region New Game Button

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(305, 200),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            #endregion
            #region Load Button

            var loadGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(305, 250),
                Text = "Load Game",
            };

            loadGameButton.Click += LoadGameButton_Click;

            #endregion
            #region Options Button

            var optionsGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(305, 300),
                Text = "Options",
            };

            optionsGameButton.Click += OptionsGameButton_Click;

            #endregion
            #region Quit Button

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(305, 350),
                Text = "Quit",
            };

            quitGameButton.Click += QuitGameButton_Click;

            #endregion

            //List of Components
            m_components = new List<Component>()
            {
                screenBackground,

                newGameButton,
                loadGameButton,
                optionsGameButton,
                quitGameButton,

                japakeysLogo,
            };
        }

        #region Button Methods

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            click.Play();

            m_command.NewGame(m_ScreenManager);
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            click.Play();

            m_command.LoadGame(m_ScreenManager);
        }

        private void OptionsGameButton_Click(object sender, EventArgs e)
        {
            click.Play();

            m_command.OpenOptionsMenu(m_ScreenManager);
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            m_exitGame = true;
        }
        #endregion

        #region Touch Methods

        private void NewGameButton_Pressed()
        {
            click.Play();

            m_command.NewGame(m_ScreenManager);
        }

        private void LoadGameButton_Pressed()
        {
            click.Play();

            m_command.LoadGame(m_ScreenManager);
        }

        private void OptionsButton_Pressed()
        {
            click.Play();

            m_command.OpenOptionsMenu(m_ScreenManager);
        }

        private void QuitButton_Pressed()
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
            spriteBatch.Begin();    //Begin SpriteBatch

            //Draw all components to screen
            foreach (var component in m_components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();    //End SpriteBatch
        }

        public void Update(GameTime gameTime)
        {
            foreach (var component in m_components)
                component.Update(gameTime);
        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            #region Touch Input Testing -- Nonfunctional

            touchCollection = TouchPanel.GetState();

            foreach (TouchLocation tl in touchCollection)
            {
                if (tl.State == TouchLocationState.Pressed &&
                tl.Position.X > 305 &&
                tl.Position.X < 495 &&
                tl.Position.Y > 200 &&
                tl.Position.Y < 249)
                {
                    NewGameButton_Pressed();
                }

                if (tl.State == TouchLocationState.Pressed &&
                tl.Position.X > 305 &&
                tl.Position.X < 495 &&
                tl.Position.Y > 250 &&
                tl.Position.Y < 299)
                {
                    LoadGameButton_Pressed();
                }

                if (tl.State == TouchLocationState.Pressed &&
                tl.Position.X > 305 &&
                tl.Position.X < 495 &&
                tl.Position.Y > 300 &&
                tl.Position.Y < 349)
                {
                    OptionsButton_Pressed();
                }

                if (tl.State == TouchLocationState.Pressed &&
                tl.Position.X > 305 &&
                tl.Position.X < 495 &&
                tl.Position.Y > 350 &&
                tl.Position.Y < 499)
                {
                    QuitButton_Pressed();
                }
            }

            #endregion

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
