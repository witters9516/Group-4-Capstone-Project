﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace concept_0_03
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        #region Traveling Variables

        #region Traveling Textures
        // KEEPS CURRENT PLAYER
        public static Texture2D activePlayerTexture;
        public static Texture2D activePlayer_FightTexture;

        #region Player Textures
        // PLAYER OPTION TEXTURES, FOR LOADING
        public static Texture2D charaOne_World;
        public static Texture2D charaOne_Fight;

        public static Texture2D charaTwo_World;
        public static Texture2D charaTwo_Fight;

        public static Texture2D charaThree_World;
        public static Texture2D charaThree_Fight;
        #endregion

        // KEEPS CURRENT COMPANION
        public static Texture2D activeCompanionTexture;
        public static Texture2D activeCompanion_FightTexture;

        // KEEPS CURRENT ENEMY
        public static Texture2D activeEnemyTexture;
        #endregion

        public static int levelsUnlocked = 1;

        #region Traveling Song Variables

        public static SoundEffect worldMapBGM;
        public static float musicVolume = 1.0f;
        public static SoundEffect currentSong;
        public static SoundEffectInstance currentInstance;

        #endregion

        public static bool isFightOn = false;

        #endregion

        private IGameScreenManager m_screenManager;

        public enum GameState
        {
            STARTUP,
            RUNNING,
            PAUSED,
            LOADING,
            IN_FIGHT
        }

        public enum AudioState
        {
            PLAYING,
            PAUSED,
            OFF
        }

        public static GameState m_gameState;
        public static AudioState m_audioState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 600,
                PreferredBackBufferWidth = 800,
            };
            IsMouseVisible = true;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            m_gameState = GameState.STARTUP;
            m_audioState = AudioState.OFF;

        }
        
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            activePlayerTexture = Content.Load<Texture2D>("Player/player01_Front");

            // Set The Traveling Content
            activeCompanionTexture = Content.Load<Texture2D>("NPCs/carl");
            activeCompanion_FightTexture = Content.Load<Texture2D>("NPCs/Carl_Fight");
            worldMapBGM = Content.Load<SoundEffect>("Music/WorldMapLoop");

            // Player Textures
            charaOne_World = Content.Load<Texture2D>("Player/player01_Front");
            charaTwo_World = Content.Load<Texture2D>("Player/player02_Front");
            charaThree_World = Content.Load<Texture2D>("Player/player03_Front");

            charaOne_Fight = Content.Load<Texture2D>("Player/player01_Fight");
            charaTwo_Fight = Content.Load<Texture2D>("Player/player02_Fight");
            charaThree_Fight = Content.Load<Texture2D>("Player/player03_Fight");

            m_screenManager = new GameScreenManager(spriteBatch, Content);
            m_screenManager.OnGameExit += Exit;

            // Start Game By Loading Menu Screen
            m_screenManager.ChangeScreen(new MenuScreen(m_screenManager));

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            if(m_screenManager != null)
            {
                m_screenManager.Dispose();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            m_screenManager.ChangeBetweenScreens();

            m_screenManager.HandleInput(gameTime);
            m_screenManager.Update(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            m_screenManager.Draw(gameTime);

            Window.Title = "Japakeys";

            base.Draw(gameTime);
        }
    }
}
