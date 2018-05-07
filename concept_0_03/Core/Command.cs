using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace concept_0_03
{
    class Command
    {
        GameTime gameTime;
        IGameScreenManager gameScreenManager;

        private bool didFightStart;

        #region Constructors

        public Command()
        {

        }

        public Command(IGameScreenManager m_screenManager)
        {
            gameScreenManager = m_screenManager;
        }

        public Command(GameTime m_gameTime)
        {
            gameTime = m_gameTime;
        }

        public Command(IGameScreenManager m_screenManager, GameTime m_gameTime)
        {
            gameScreenManager = m_screenManager;
            gameTime = m_gameTime;
        }

        #endregion

        // --
        #region Options

        #region Open/Close Options

        public void OpenOptionsMenu(IGameScreenManager m_screenManager)
        {
            m_screenManager.PushScreen(new OptionsScreen(m_screenManager));
        }

        public void CloseOptionsMenu(IGameScreenManager m_screenManager)
        {
            m_screenManager.PopScreen();
        }

        #endregion

        #region Music On/Off

        public void ToggleAudio()
        {
            switch (Game1.m_audioState)
            {
                case Game1.AudioState.OFF:
                    Game1.currentInstance.Stop();

                    Game1.m_audioState = Game1.AudioState.PLAYING;
                    break;
                case Game1.AudioState.PAUSED:
                    Game1.currentInstance.Stop();

                    Game1.m_audioState = Game1.AudioState.PLAYING;
                    break;
                case Game1.AudioState.PLAYING:
                    Game1.currentInstance.Play();

                    Game1.m_audioState = Game1.AudioState.PAUSED;
                    break;
            }
        }

        #endregion

        #region Save Game -- Unimplemented

        public void SaveGame(IGameScreenManager m_screenManager)
        {
            // Actual save game code not yet coded

            Console.WriteLine("Save Game");
        }

        #endregion

        #endregion

        // --
        #region World Map Screen

        #region Enter Current World

        public int EnterLevel(int currentLevel, IGameScreenManager m_screenManager, int levelsUnlocked, SoundEffect bgm)
        {
            switch (currentLevel)
            {
                case 0:
                    break;
                case 1:
                    if (levelsUnlocked > 0)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-1"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 1)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 2:

                    if (levelsUnlocked > 1)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-2"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 2)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 3:
                    if (levelsUnlocked > 2)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-3"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 3)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 4:
                    if (levelsUnlocked > 3)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-4"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 4)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 5:
                    if (levelsUnlocked > 4)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-5"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 5)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 6:
                    if (levelsUnlocked > 5)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-6"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 6)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 7:
                    if (levelsUnlocked > 6)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-7"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 7)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 8:
                   if (levelsUnlocked > 7)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-8"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 8)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 9:
                    if (levelsUnlocked > 8)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-9"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 9)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 10:
                    if (levelsUnlocked > 9)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-10"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 10)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 11:
                    if (levelsUnlocked > 10)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-11"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 11)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 12:
                    if (levelsUnlocked > 11)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-1"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 12)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;

                case 13:
                    if (levelsUnlocked > 12)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-2"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 13)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;

                case 14:
                    if (levelsUnlocked > 13)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-3"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 14)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;

                case 15:
                    if (levelsUnlocked > 14)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-4"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 15)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 16:
                    if (levelsUnlocked > 15)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-5"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 16)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 17:
                    if (levelsUnlocked > 16)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-6"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 17)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 18:
                    if (levelsUnlocked > 17)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-7"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 18)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 19:
                    if (levelsUnlocked > 18)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-8"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 19)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 20:
                    if (levelsUnlocked > 19)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-9"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 20)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 21:
                    if (levelsUnlocked > 20)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-10"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 21)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 22:
                    if (levelsUnlocked > 21)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-11"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 22)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
            }


            return levelsUnlocked;
        }

        #endregion

        #endregion

        // --
        #region Menu Screen

        #region New Game

        public void NewGame(IGameScreenManager m_screenManager)
        {
            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();

            m_screenManager.ChangeScreen(new CharacterSelectionScreen(m_screenManager));
        }

        #endregion

        #region Load Game -- Not implementated

        public void LoadGame(IGameScreenManager m_screenManager)
        {
            // Load Game Code would go here, currently non-functional

            Console.WriteLine("Load Game");
        }

        #endregion

        #endregion

        // --
        #region Character Creation Screen

        #region Player Selection

        #region Player One

        public string ChoosePlayerOne()
        {
            Game1.activePlayerTexture = CharacterSelectionScreen.player01;
            Game1.activePlayer_FightTexture = CharacterSelectionScreen.player01_Fight;

            string whichCharacter = "Player01";
            return whichCharacter;
        }

        #endregion
        #region Player Two

        public string ChoosePlayerTwo()
        {
            Game1.activePlayerTexture = CharacterSelectionScreen.player02;
            Game1.activePlayer_FightTexture = CharacterSelectionScreen.player02_Fight;

            string whichCharacter = "Player02";
            return whichCharacter;
        }

        #endregion
        #region Player Three

        public string ChoosePlayerThree()
        {
            Game1.activePlayerTexture = CharacterSelectionScreen.player03;
            Game1.activePlayer_FightTexture = CharacterSelectionScreen.player03_Fight;

            string whichCharacter = "Player03";
            return whichCharacter;
        }

        #endregion

        #endregion

        #region Game Start

        public void StartGame(IGameScreenManager m_screenManager)
        {
            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();

            m_screenManager.ChangeScreen(new WorldMapScreen(m_screenManager));
        }

        #endregion

        #endregion

        #region Music

        public void WorldMapMusicOn(SoundEffect bgm)
        {
            Game1.currentInstance = bgm.CreateInstance();
            Game1.currentInstance.IsLooped = true;

            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Play();

            didFightStart = false;
        }

        public void MusicOff()
        {
            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();
        }

        #endregion

    }
}
