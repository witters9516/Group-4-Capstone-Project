using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace concept_0_03
{
    class LevelOneScreen : IGameScreen
    {
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;

        private List<Component> m_components;
        private SoundEffect click;
        private Player _player;
        private Sprite obstacle;
        private bool isMusicStopped = false;

        public bool IsPaused { get; private set; }
        public Player Player { get => _player; set => _player = value; }
        public Sprite Obstacle { get => obstacle; set => obstacle = value; }

        private SoundEffect bgSong;
        private SoundEffectInstance bgMusic;

        public LevelOneScreen(IGameScreenManager gameScreenManager)
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
            click = content.Load<SoundEffect>("SFX/Select_Click");

            bgSong = content.Load<SoundEffect>("Music/Pixelland");
            bgMusic = bgSong.CreateInstance();

            bgMusic.IsLooped = true;
            bgMusic.Play();

            Player = new Player(content.Load<Texture2D>("block"));
            Obstacle = new Sprite(content.Load<Texture2D>("collision_wall"));

            Obstacle.Position = new Vector2(300, 400);
            
            m_components = new List<Component>()
            {
                // new Sprite(Content.Load<Texture2D>("stars")),
                Player,
                Obstacle,
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

            if (Player.Rectangle.Intersects(Obstacle.Rectangle))
            {
                bgMusic.Pause();
                isMusicStopped = true;
                m_ScreenManager.PushScreen(new FightScreen(m_ScreenManager));
                Player.Position = new Vector2(Player.Position.X + 5, Player.Position.Y);
                Obstacle.Position = new Vector2(-30, -50);
            }

            if (isMusicStopped == true)
            {
                isMusicStopped = false;
                bgMusic.Resume();
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
        }

        public void Dispose()
        {
            
        }
    }
}
