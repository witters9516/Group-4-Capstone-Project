using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace concept_0_03
{
    class GameScreenManager : IGameScreenManager
    {
        //Fields
        private Action m_onGameExit;
        //Readonly Variables
        private readonly SpriteBatch m_spriteBatch;
        private readonly ContentManager m_contentManager;
        private readonly List<IGameScreen> m_gameScreens = new List<IGameScreen>();

        //Overloaded Constructor
        public GameScreenManager(SpriteBatch spriteBatch, ContentManager contentManager)
        {
            m_spriteBatch = spriteBatch;
            m_contentManager = contentManager;
        }

        //Removes screens from list and then adds a new screen.
        public void ChangeScreen(IGameScreen screen)
        {
            RemoveAllScreens();

            m_gameScreens.Add(screen);

            screen.Init(m_contentManager);
        }

        //Adds a new Screen to the list.
        public void PushScreen(IGameScreen screen)
        {
            if(!IsScreenListEmpty)
            {
                var curScreen = GetCurrentScreen();
                curScreen.Pause();
            }

            m_gameScreens.Add(screen);
            screen.Init(m_contentManager);
        }

        //Removes the current Screen from the list.
        public void PopScreen()
        {
            if(!IsScreenListEmpty)
            {
                RemoveCurrentScreen();
            }

            if(!IsScreenListEmpty)
            {
                var curScreen = GetCurrentScreen();
                curScreen.Resume();
            }
        }

        #region Screen Helper Functions
        private bool IsScreenListEmpty
        {
            get { return m_gameScreens.Count <= 0; }
        }

        private IGameScreen GetCurrentScreen()
        {
            return m_gameScreens[m_gameScreens.Count - 1];
        }

        private void RemoveAllScreens()
        {
            while (!IsScreenListEmpty)
            {
                RemoveCurrentScreen();
            }
        }

        private void RemoveCurrentScreen()
        {
            var screen = GetCurrentScreen();

            screen.Dispose();

            m_gameScreens.Remove(screen);
        }
        #endregion

        //Handles Keyboard Input
        public void HandleInput(GameTime gameTime)
        {
            if (!IsScreenListEmpty)
            {
                var screen = GetCurrentScreen();

                if (!screen.IsPaused)
                {
                    screen.HandleInput(gameTime);
                }
            }
        }

        //Handles updating UI elements
        public void Update(GameTime gameTime)
        {
            if (!IsScreenListEmpty)
            {
                var screen = GetCurrentScreen();

                if (!screen.IsPaused)
                {
                    screen.Update(gameTime);
                }
            }
        }

        //Draws UI Elements
        public void Draw(GameTime gameTime)
        {
            if (!IsScreenListEmpty)
            {
                var screen = GetCurrentScreen();

                if (!screen.IsPaused)
                {
                    screen.Draw(gameTime, m_spriteBatch);
                }
            }
        }

        //Changes Between Screens
        public void ChangeBetweenScreens()
        {
            if (!IsScreenListEmpty)
            {
                var screen = GetCurrentScreen();

                if (!screen.IsPaused)
                {
                    screen.ChangeBetweenScreens();
                }
            }
        }

        //Exit Function
        public void Exit()
        {
            m_onGameExit?.Invoke();
        }

        //Action Event
        public event Action OnGameExit
        {
            add { m_onGameExit += value; }
            remove { m_onGameExit -= value; }
        }

        //Dispose
        public void Dispose()
        {
            RemoveAllScreens();
        }
    }
}
