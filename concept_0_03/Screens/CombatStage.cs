using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace concept_0_03
{
    class CombatStage : IGameScreen
    {
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;
        private bool isMusicOn;
        private bool wasOptionsOpened;

        private List<Component> m_components;
        private SoundEffect click;

        private string optionOne = "weiss";
        private string optionTwo = "rot";
        private string optionThree = "blau";
        private string optionFour = "gruen";
        private string currentWord = "rot";
        private string questionBeginning = "Please translate: ";
        private string questionWord = "red";
        private Text m_questionText;

        private Text m_eHealthText;
        private int enemyHealth = 20;
        private string fullEnemyHealthText;

        private Text m_pHealthText;
        private int playerHealth = 20;
        private string fullPlayerHealthText;

        public bool IsPaused { get; private set; }

        private SoundEffect bgSong;
        private SoundEffectInstance bgMusic;
        private KeyboardState oldState;

        public CombatStage(IGameScreenManager gameScreenManager)
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
            SpriteFont m_font = content.Load<SpriteFont>("Fonts/Font");
            click = content.Load<SoundEffect>("SFX/Select_Click");
            bgSong = content.Load<SoundEffect>("Music/Reformat");
            bgMusic = bgSong.CreateInstance();

            bgMusic.IsLooped = true;
            bgMusic.Play();

            var questionBackground = new Sprite(content.Load<Texture2D>("BG/bgMountains"));
            questionBackground.Position = new Vector2(-100,-100);

            #region Enemy Health Rendering
            fullEnemyHealthText = "Enemy Health: " + enemyHealth;

            Vector2 m_eHealthPosition = new Vector2(525, 560);
            Color m_eHealthColor = Color.Black;

            m_eHealthText = new Text(fullEnemyHealthText, m_font, m_eHealthPosition, m_eHealthColor);
            #endregion
            #region Player Health Rendering
            fullPlayerHealthText = "Player Health: " + playerHealth;

            Vector2 m_pHealthPosition = new Vector2(225, 560);
            Color m_pHealthColor = Color.Black;

            m_pHealthText = new Text(fullPlayerHealthText, m_font, m_pHealthPosition, m_pHealthColor);
            #endregion
            #region Question Rendering
            questionBeginning = "Please translate: " + questionWord;

            Vector2 m_questionPosition = new Vector2(1, 20);
            Color m_questionColor = Color.Black;

            m_questionText = new Text(questionBeginning, m_font, m_questionPosition, m_questionColor);
            m_questionText.CenterHorizontal(800, 30);
            #endregion

            #region Answer Button 1
            var answerButton1 = new Button(content.Load<Texture2D>("Menu/Red/red_button03"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(305, 200),
                Text = optionOne,
            };

            answerButton1.Click += AnswerButton1_Click;
            #endregion
            #region Answer Button 2
            var answerButton2 = new Button(content.Load<Texture2D>("Menu/Blue/blue_button03"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(205, 250),
                Text = optionTwo,
            };

            answerButton2.Click += AnswerButton2_Click;
            #endregion
            #region Answer Button 3
            var answerButton3 = new Button(content.Load<Texture2D>("Menu/Blue/Blue_button03"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(405, 250),
                Text = optionThree,
            };

            answerButton3.Click += AnswerButton3_Click;
            #endregion
            #region Answer Button 4
            var answerButton4 = new Button(content.Load<Texture2D>("Menu/Red/red_button03"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(305, 300),
                Text = optionFour,
            };

            answerButton4.Click += AnswerButton4_Click;
            #endregion

            m_components = new List<Component>()
            {
                questionBackground,

                answerButton1,
                answerButton2,
                answerButton3,
                answerButton4,
            };
        }

        #region Click Methods

        private void AnswerButton1_Click(object sender, EventArgs e)
        {
            click.Play();

            if (optionOne == currentWord)
            {
                enemyHealth -= 5;
            }
            else
            {
                playerHealth -= 5;
            }
        }

        private void AnswerButton2_Click(object sender, EventArgs e)
        {
            click.Play();

            if (optionTwo == currentWord)
            {
                enemyHealth -= 5;
            }
            else
            {
                playerHealth -= 5;
            }
        }

        private void AnswerButton3_Click(object sender, EventArgs e)
        {
            click.Play();

            if (optionThree == currentWord)
            {
                enemyHealth -= 5;
            }
            else
            {
                playerHealth -= 5;
            }
        }

        private void AnswerButton4_Click(object sender, EventArgs e)
        {
            click.Play();

            if (optionFour == currentWord)
            {
                enemyHealth -= 5;
            }
            else
            {
                playerHealth -= 5;
            }
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

        public void Update(GameTime gameTime)
        {
            foreach (var component in m_components)
                component.Update(gameTime);

            m_eHealthText.Message = "Enemy Health: " + enemyHealth;
            m_pHealthText.Message = "Player Health: " + playerHealth;
            m_questionText.Message = "Quick, what's \"" + questionWord + "\" in German! ";
            m_questionText.CenterHorizontal(800, 30);

            if (enemyHealth <= 0)
            {
                bgMusic.Stop();
                m_ScreenManager.PopScreen();
            }

            if (playerHealth <= 0)
            {
                bgMusic.Stop();
                m_ScreenManager.ChangeScreen(new GameOverScreen(m_ScreenManager));
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            m_eHealthText.Draw(spriteBatch);
            m_pHealthText.Draw(spriteBatch);

            foreach (var component in m_components)
                component.Draw(gameTime, spriteBatch);

            m_questionText.Draw(spriteBatch);

            spriteBatch.End();
        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                m_exitGame = true;
            }

            if (keyboard.IsKeyDown(Keys.Back))
            {
                m_ScreenManager.PushScreen(new OptionsScreen(m_ScreenManager));
            }

            #region Answer on Button Press
            /* -- Get these to do something somehow...
            if (oldState.IsKeyUp(Keys.W) && keyboard.IsKeyDown(Keys.W))
            { 
                // AnswerButton1_Click;
            }
            if (oldState.IsKeyUp(Keys.A) && keyboard.IsKeyDown(Keys.A))
            {
                // AnswerButton2_Click;
            }
            if (oldState.IsKeyUp(Keys.D) && keyboard.IsKeyDown(Keys.D))
            { 
                // AnswerButton3_Click;
            }
            if (oldState.IsKeyUp(Keys.S) && keyboard.IsKeyDown(Keys.S))
            {
                // AnswerButton4_Click;
            }
            */
            #endregion

            oldState = keyboard;
        }

        public void Dispose()
        {

        }
    }
}