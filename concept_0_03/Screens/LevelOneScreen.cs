﻿using System;
using System.Collections.Generic;
using System.Timers;
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

        private SoundEffect bgSong;
        private SoundEffectInstance bgMusic;
        private bool isMusicStopped = false;

        private Player _player;
        private Sprite obstacle;

        #region Enemy One Variables
        private Vector2 enemyOnePosition = new Vector2(300,400);
        private Rectangle enemyOneBounds = new Rectangle(150, 250, 200, 200);
        private int enemyMovementLeftRight;
        private int enemyMovementUpDown;
        bool enemyOneDefeated = false;

        bool getNewRandom = false;
        #endregion

        private Random random1 = new Random(Guid.NewGuid().GetHashCode());
        private Random random2 = new Random(Guid.NewGuid().GetHashCode());
        private Timer timer = new Timer();

        public bool IsPaused { get; private set; }
        public Player Player { get => _player; set => _player = value; }
        public Sprite Obstacle { get => obstacle; set => obstacle = value; }

        public LevelOneScreen(IGameScreenManager gameScreenManager)
        {
            m_ScreenManager = gameScreenManager;

            #region Timer Stuff

            enemyMovementLeftRight = random1.Next(1, 21);
            enemyMovementUpDown = random2.Next(1, 21);

            timer.AutoReset = true;
            timer.Interval = 400;
            timer.Start();

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
            click = content.Load<SoundEffect>("SFX/Select_Click");

            bgSong = content.Load<SoundEffect>("Music/Pixelland");
            bgMusic = bgSong.CreateInstance();

            bgMusic.IsLooped = true;
            bgMusic.Play();

            Player = new Player(content.Load<Texture2D>("block"));
            Obstacle = new Sprite(content.Load<Texture2D>("collision_wall"));

            Obstacle.Position = enemyOnePosition;
            
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
                enemyOneDefeated = true;

                Player.Position = new Vector2(Player.Position.X + 5, Player.Position.Y);
                Obstacle.Position = new Vector2(-30, -50);
            }

            if (isMusicStopped == true)
            {
                isMusicStopped = false;
                bgMusic.Resume();
            }

            #region Enemy One Movement

            if (Obstacle.Position.X > enemyOneBounds.Left && Obstacle.Position.Y > enemyOneBounds.Top &&
                Obstacle.Position.X < enemyOneBounds.Right && Obstacle.Position.Y < enemyOneBounds.Bottom)
            {
                timer.Elapsed += new ElapsedEventHandler(GetNewRandom);

                if (getNewRandom == true)
                {
                    enemyMovementLeftRight = random1.Next(1, 21);
                    enemyMovementUpDown = random2.Next(1, 21);
                    getNewRandom = false;

                }

                if (enemyMovementLeftRight < 6)
                {
                    if (Obstacle.Position.X < enemyOneBounds.Right - 2)
                    {
                        enemyOnePosition.X += 2;
                    }
                    else
                    {
                        enemyMovementLeftRight = random1.Next(1, 21);
                    }
                }
                else if (enemyMovementLeftRight >= 16)
                {
                    if (Obstacle.Position.X > enemyOneBounds.Left + 2)
                    {
                        enemyOnePosition.X -= 2;
                    }
                    else
                    {
                        enemyMovementLeftRight = random1.Next(1, 21);
                    }
                }

                if (enemyMovementUpDown >= 11 && enemyMovementUpDown < 16)
                {
                    if (Obstacle.Position.Y < enemyOneBounds.Bottom - 2)
                    {
                        enemyOnePosition.Y += 2;
                    }
                    else
                    {
                        enemyMovementUpDown = random2.Next(1, 21);
                    }
                }
                else if (enemyMovementUpDown >= 6 && enemyMovementUpDown < 11)
                {
                    if (Obstacle.Position.Y > enemyOneBounds.Top + 2)
                    {
                        enemyOnePosition.Y -= 2;
                    }
                    else
                    {
                        enemyMovementUpDown = random2.Next(1, 21);
                    }
                }

                Obstacle.Position = enemyOnePosition;
            }

            #endregion
        }

        private void GetNewRandom(object sender, ElapsedEventArgs e)
        {
            getNewRandom = true;
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
