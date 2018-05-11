using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace concept_0_03
{
    class OptionsScreen : IGameScreen
    {
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;
        private Command m_command;

        private List<Component> m_components;
        private SoundEffect click;

        // UI Variables
        public Button musicButton;
        public float currentVolume;
        
        KeyboardState oldState;

        public bool IsPaused { get; private set; }

        public OptionsScreen(IGameScreenManager gameScreenManager)
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
            click = content.Load<SoundEffect>("SFX/Select_Click");

            #region Resume Button
            var resumeButton = new Button(content.Load<Texture2D>("Menu/Grey/grey_button00"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(300, 200),
                Text = "Resume"
            };

            resumeButton.Click += ResumeButton_Click;

            #endregion
            #region Save Button
            var saveButton = new Button(content.Load<Texture2D>("Menu/Grey/grey_button00"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(300, 250),
                Text = "Save"
            };

            saveButton.Click += SaveButton_Click;
            #endregion
            #region Music Button
            musicButton = new Button(content.Load<Texture2D>("Menu/Grey/grey_button00"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(300, 300),
                Text = "Music",
            };

            musicButton.Click += MusicButton_Click;
            #endregion
            #region Quit Button
            var quitButton = new Button(content.Load<Texture2D>("Menu/Red/red_button00"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(300, 350),
                Text = "Quit"
            };

            quitButton.Click += QuitButton_Click;
            #endregion

            var screenBackground = new Sprite(content.Load<Texture2D>("BGs/bgWaterfallOrange"))
            {
                Position = new Vector2(-100, -2)
            };

            m_components = new List<Component>()
            {
                screenBackground,

                resumeButton,
                saveButton,
                musicButton,
                quitButton,
            };
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            click.Play();

            m_command.CloseOptionsMenu(m_ScreenManager);
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            m_exitGame = true;
        }

        private void MusicButton_Click(object sender, EventArgs e)
        {
            click.Play();

            m_command.ToggleAudio();
            Game1.currentInstance.Volume = Game1.musicVolume;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            click.Play();

            m_command.SaveGame(m_ScreenManager);
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

            GetMusicVolume();
        }

        //Get Music Volume and Display volume level.
        public void GetMusicVolume()
        {
            currentVolume = Game1.musicVolume * 100;
            musicButton.Text = "Music: " + currentVolume.ToString() + "%";
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();    //Begin SpriteBatch

            //Draw all components to screen
            foreach (var component in m_components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();    //End SpriteBatch
        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                m_exitGame = true;
            }

            oldState = keyboard;
        }

        public void Dispose()
        {
            
        }
    }
}
