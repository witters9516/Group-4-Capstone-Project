using System;
using System.Collections.Generic;
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

        public bool IsPaused { get; private set; }

        #region Level Boxes and Player Info

        private Player Player;

        private Sprite LevelOne;

        private bool intersectsLevelOne = false;

        #endregion

        public WorldMapScreen(IGameScreenManager gameScreenManager)
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

            bgSong = content.Load<SoundEffect>("Music/Carpe Diem");
            bgMusic = bgSong.CreateInstance();

            bgMusic.IsLooped = true;
            bgMusic.Play();

            Player = new Player(Game1.activePlayerTexture);
            LevelOne = new Sprite(content.Load<Texture2D>("block"));

            LevelOne.Position = new Vector2(100,100);
            LevelOne.Colour = new Color(143, 100, 100, 30);

            m_components = new List<Component>()
            {
                Player,
                LevelOne,
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
        }

        public void Dispose()
        {
            
        }
    }
}
