using System;
using System.Collections.Generic;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace concept_0_03
{
    class WorldMapScreen : IGameScreen
    {
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;
        
        private List<Component> m_components;
        private SoundEffect click;

        private SoundEffect bgSong;
        private SoundEffectInstance bgMusic;
        private bool isMusicStopped = false;
        private int currentLevel = 0;

        public bool IsPaused { get; private set; }

        private Timer moveToNextLevel = new Timer();
        bool justMovedToNextLevel = false;

        #region Level Boxes and Player Info

        private Player Player;

        private Sprite LevelOne;
        private Sprite LevelTwo;
        private Sprite LevelThree;
        private Sprite LevelFour;

        private bool intersectsLevelOne = false;

        #endregion

        public WorldMapScreen(IGameScreenManager gameScreenManager)
        {
            m_ScreenManager = gameScreenManager;

            #region Timer Stuff
            
            moveToNextLevel.Interval = 500;

            #endregion
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

            bgSong = content.Load<SoundEffect>("Music/Carpe Diem");
            bgMusic = bgSong.CreateInstance();

            bgMusic.IsLooped = true;
            bgMusic.Volume = 0.5f;
            bgMusic.Play();

            Sprite background = new Sprite(content.Load<Texture2D>("map wip"));

            Player = new Player(Game1.activePlayerTexture);
            Player.playerCanMove = false;

            #region Level Entrance Rendering

            LevelOne = new Sprite(content.Load<Texture2D>("block"));

            LevelOne.Position = new Vector2(73,70);
            LevelOne.Colour = new Color(143, 100, 100, 10);

            LevelTwo = new Sprite(content.Load<Texture2D>("block"));

            LevelTwo.Position = new Vector2(182, 175);
            LevelTwo.Colour = new Color(150, 100, 230, 10);

            #endregion

            Player.Position = new Vector2(-5, 240);

            m_components = new List<Component>()
            {
                background,
                LevelOne,
                LevelTwo,
                Player,
            };
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

            if (Player.Rectangle.Intersects(LevelOne.Rectangle))
            {
                intersectsLevelOne = true;
            }
            else
            {
                intersectsLevelOne = false;
            }

            moveToNextLevel.Elapsed += MoveToNextLevel_Elapsed;
        }

        private void MoveToNextLevel_Elapsed(object sender, ElapsedEventArgs e)
        {
            justMovedToNextLevel = false;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

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

            if (keyboard.IsKeyDown(Keys.Back))
            {
                bgMusic.Pause();
                isMusicStopped = true;

                m_ScreenManager.PushScreen(new OptionsScreen(m_ScreenManager));
            }

            if (keyboard.IsKeyDown(Keys.Enter))
            {
                if (intersectsLevelOne == true)
                {
                    bgMusic.Pause();
                    isMusicStopped = true;

                    m_ScreenManager.PushScreen(new LevelOneScreen(m_ScreenManager));
                }

                // does it intersect with Level Two, etc, etc
            }

            if (keyboard.IsKeyDown(Keys.Left) && justMovedToNextLevel == false)
            {
                switch (currentLevel)
                {
                    case 0:
                        break;
                    case 1:
                        Player.Position = new Vector2(-5, 240);
                        currentLevel = 0;

                        justMovedToNextLevel = true;
                        moveToNextLevel.Start();
                        break;
                    case 2:
                        Player.Position = LevelOne.Position;
                        currentLevel = 1;

                        justMovedToNextLevel = true;
                        moveToNextLevel.Start();
                        break;
                    case 3:
                        Player.Position = LevelTwo.Position;
                        currentLevel = 2;

                        justMovedToNextLevel = true;
                        moveToNextLevel.Start();
                        break;

                }
            }

            if (keyboard.IsKeyDown(Keys.Right) && justMovedToNextLevel == false)
            {
                switch (currentLevel)
                {
                    case 0:
                        Player.Position = LevelOne.Position;
                        currentLevel = 1;

                        justMovedToNextLevel = true;
                        moveToNextLevel.Start();
                        break;
                    case 1:
                        Player.Position = LevelTwo.Position;
                        currentLevel = 2;

                        justMovedToNextLevel = true;
                        moveToNextLevel.Start();
                        break;

                }
            }
        }

        public void Dispose()
        {
            
        }
    }
}
