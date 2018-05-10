﻿using System;
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
            switch (Game1.musicVolume)
            {
                case 1.0f:
                    Game1.musicVolume = 0.5f;
                    break;

                case 0.5f:
                    Game1.musicVolume = 0.0f;
                    break;

                case 0.0f:
                    Game1.musicVolume = 1.0f;
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
                case 23:
                    if (levelsUnlocked > 22)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-1"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 23)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 24:
                    if (levelsUnlocked > 23)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-2"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 24)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 25:
                    if (levelsUnlocked > 24)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-3"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 25)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 26:
                    if (levelsUnlocked > 25)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-4"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 26)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 27:
                    if (levelsUnlocked > 26)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-5"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 27)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 28:
                    if (levelsUnlocked > 27)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-6"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 28)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 29:
                    if (levelsUnlocked > 28)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-7"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 29)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 30:
                    if (levelsUnlocked > 29)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-8"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 30)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 31:
                    if (levelsUnlocked > 30)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-9"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 31)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 32:
                    if (levelsUnlocked > 31)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-10"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 32)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 33:
                    if (levelsUnlocked > 32)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-11"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 33)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 34:
                    if (levelsUnlocked > 33)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        didFightStart = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-12"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 34)
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
            Game1.activePlayerTexture = Game1.charaOne_World;
            Game1.activePlayer_FightTexture = Game1.charaOne_Fight;

            string whichCharacter = "Player01";
            return whichCharacter;
        }

        #endregion
        #region Player Two

        public string ChoosePlayerTwo()
        {
            Game1.activePlayerTexture = Game1.charaTwo_World;
            Game1.activePlayer_FightTexture = Game1.charaTwo_Fight;

            string whichCharacter = "Player02";
            return whichCharacter;
        }

        #endregion
        #region Player Three

        public string ChoosePlayerThree()
        {
            Game1.activePlayerTexture = Game1.charaThree_World;
            Game1.activePlayer_FightTexture = Game1.charaThree_Fight;

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
            Game1.currentInstance.Volume = Game1.musicVolume;

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
