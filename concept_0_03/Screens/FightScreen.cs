using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace concept_0_03
{
    class FightScreen : IGameScreen
    {
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;
        private bool isMusicOn;

        private List<Component> m_components;
        private SoundEffect click;

        private string optionOne = "weiss";
        private string optionTwo = "rot";
        private string optionThree = "blau";
        private string optionFour = "gruen";
        private string currentWord = "rot";

        private Text m_eHealthText;
        private int enemyHealth = 20;
        private string fullEnemyHealthText;

        public bool IsPaused { get; private set; }

        private SoundEffect bgSong;
        private SoundEffectInstance bgMusic;

        public FightScreen(IGameScreenManager gameScreenManager)
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

            #region Enemy Health Rendering
            fullEnemyHealthText = "Enemy Health: " + enemyHealth;

            var x = ((800 / 2) - (m_font.MeasureString(fullEnemyHealthText).X / 2)) + (((800 / 2) - (m_font.MeasureString(fullEnemyHealthText).X / 2))/2);
            var y = 550;
            Vector2 m_textPosition = new Vector2(x, y);
            Color m_color = Color.Black;

            m_eHealthText = new Text(fullEnemyHealthText, m_font, m_textPosition, m_color);
            #endregion

            #region Answer Button 1
            var answerButton1 = new Button(content.Load<Texture2D>("Menu/Red/red_button00"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(275, 200),
                Text = optionOne,
            };

            answerButton1.Click += AnswerButton1_Click;
            #endregion
            #region Answer Button 2
            var answerButton2 = new Button(content.Load<Texture2D>("Menu/Red/red_button00"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(175, 250),
                Text = optionTwo,
            };

            answerButton2.Click += AnswerButton2_Click;
            #endregion
            #region Answer Button 3
            var answerButton3 = new Button(content.Load<Texture2D>("Menu/Red/red_button00"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(375, 250),
                Text = optionThree,
            };

            answerButton3.Click += AnswerButton3_Click;
            #endregion
            #region Answer Button 4
            var answerButton4 = new Button(content.Load<Texture2D>("Menu/Red/red_button00"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(275, 300),
                Text = optionFour,
            };

            answerButton4.Click += AnswerButton4_Click;
            #endregion

            m_components = new List<Component>()
            {
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
        }

        private void AnswerButton2_Click(object sender, EventArgs e)
        {
            click.Play();

            if (optionTwo == currentWord)
            {
                enemyHealth -= 5;
            }
        }

        private void AnswerButton3_Click(object sender, EventArgs e)
        {
            click.Play();

            if (optionThree == currentWord)
            {
                enemyHealth -= 5;
            }
        }

        private void AnswerButton4_Click(object sender, EventArgs e)
        {
            click.Play();

            if (optionFour == currentWord)
            {
                enemyHealth -= 5;
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

            if (enemyHealth <= 0)
            {
                bgMusic.Stop();
                m_ScreenManager.PopScreen();
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            m_eHealthText.Draw(spriteBatch);

            foreach (var component in m_components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
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
