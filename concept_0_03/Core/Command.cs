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
        GameTime gameTime;                      //Script's gameTime
        IGameScreenManager gameScreenManager;   //Scripts's gameScreenManager

        //Constructor Functions
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
        // Option Menu Methods
        #region Options

        #region Open/Close Options
        //Opens the Options Menu
        public void OpenOptionsMenu(IGameScreenManager m_screenManager)
        {
            m_screenManager.PushScreen(new OptionsScreen(m_screenManager));
        }
        
        //Closes the Options Menu
        public void CloseOptionsMenu(IGameScreenManager m_screenManager)
        {
            m_screenManager.PopScreen();
        }

        #endregion

        #region Music On/Off
        //The ToggleAudio method controls the music volume.
        //Based on the volume level currently active, this
        //will set it one volume level lower. If the volume
        //level is at its lowest level, it sets it to the 
        //highest level.
        public void ToggleAudio()
        {
            int temp = 1;   //Temporary int.

            //Determine temp.
            if (Game1.musicVolume == 1.0f)
                temp = 1;
            else if (Game1.musicVolume == 0.5f)
                temp = 2;
            else if (Game1.musicVolume == 0.0f)
                temp = 3;

            //Change Volume Level.
            switch (temp)
            {
                case 1:
                    Game1.musicVolume = 0.5f;
                    break;

                case 2:
                    Game1.musicVolume = 0.0f;
                    break;

                case 3:
                    Game1.musicVolume = 1.0f;
                    break;
            }
        }
        #endregion

        #region Save Game -- Unimplemented
        //Used To Save the Game.
        public void SaveGame(IGameScreenManager m_screenManager)
        {
            m_screenManager.PushScreen(new SaveFileScreen(m_screenManager));    //Push Save File Screen.
        }
        #endregion

        #endregion
        // World Map Screen Methods
        #region World Map Screen
        #region Enter Current World
        //Controls all level entrance battle initializers.
        public int EnterLevel(int currentLevel, IGameScreenManager m_screenManager, int levelsUnlocked, SoundEffect bgm)
        {
            //In Each Case is as follows
            //1. Music turned off
            //2. Game1.isFightOn set to true.
            //3. //didFightStart Set to true.
            //4. Push a Fight Screen using a specific level Tag
            //5. Increment levelsUnlocked
            //6. Return levelsUnlocked.
            switch (currentLevel)
            {
                case 0:
                    break;
                case 1:
                    if (levelsUnlocked > 0)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-1"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 1)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 2:

                    if (levelsUnlocked > 1)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-2"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 2)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 3:
                    if (levelsUnlocked > 2)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-3"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 3)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 4:
                    if (levelsUnlocked > 3)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-4"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 4)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 5:
                    if (levelsUnlocked > 4)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-5"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 5)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 6:
                    if (levelsUnlocked > 5)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-6"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 6)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 7:
                    if (levelsUnlocked > 6)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-7"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 7)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 8:
                   if (levelsUnlocked > 7)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-8"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 8)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 9:
                    if (levelsUnlocked > 8)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-9"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 9)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 10:
                    if (levelsUnlocked > 9)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-10"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 10)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 11:
                    if (levelsUnlocked > 10)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "1-11"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 11)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 12:
                    if (levelsUnlocked > 11)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-1"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 12)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked

                case 13:
                    if (levelsUnlocked > 12)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-2"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 13)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked

                case 14:
                    if (levelsUnlocked > 13)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-3"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 14)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked

                case 15:
                    if (levelsUnlocked > 14)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-4"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 15)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 16:
                    if (levelsUnlocked > 15)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-5"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 16)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 17:
                    if (levelsUnlocked > 16)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-6"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 17)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 18:
                    if (levelsUnlocked > 17)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-7"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 18)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 19:
                    if (levelsUnlocked > 18)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-8"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 19)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 20:
                    if (levelsUnlocked > 19)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-9"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 20)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 21:
                    if (levelsUnlocked > 20)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-10"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 21)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 22:
                    if (levelsUnlocked > 21)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "2-11"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 22)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 23:
                    if (levelsUnlocked > 22)
                    {
                        MusicOff();

                        Game1.isFightOn = true;

                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-1"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 23)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 24:
                    if (levelsUnlocked > 23)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-2"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 24)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 25:
                    if (levelsUnlocked > 24)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-3"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 25)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 26:
                    if (levelsUnlocked > 25)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-4"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 26)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 27:
                    if (levelsUnlocked > 26)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-5"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 27)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 28:
                    if (levelsUnlocked > 27)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-6"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 28)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 29:
                    if (levelsUnlocked > 28)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-7"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 29)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 30:
                    if (levelsUnlocked > 29)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-8"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 30)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 31:
                    if (levelsUnlocked > 30)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-9"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 31)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 32:
                    if (levelsUnlocked > 31)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-10"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 32)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 33:
                    if (levelsUnlocked > 32)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-11"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 33)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
                case 34:
                    if (levelsUnlocked > 33)
                    {
                        MusicOff();

                        Game1.isFightOn = true;
                        
                        m_screenManager.PushScreen(new FightScreen(m_screenManager, "3-12"));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    //Increment levelsUnlocked
                    if (levelsUnlocked == 34)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;  //Return levelsUnlocked
            }

            return levelsUnlocked;  //Return levelsUnlocked
        }
        #endregion
        #endregion
        // Menu Screen Methods
        #region Menu Screen
        #region New Game
        //Loads a new game by transferring the player to character selection.
        public void NewGame(IGameScreenManager m_screenManager)
        {
            //Turn Off Music
            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();
            //Load Character Selection Screen
            m_screenManager.ChangeScreen(new CharacterSelectionScreen(m_screenManager));
        }

        #endregion

        #region Load Game -- Not implementated
        //Loads Up the Load File Screen.
        public void LoadGame(IGameScreenManager m_screenManager)
        {
            //Turn Off Music
            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();
            //Load Load File Screen
            m_screenManager.ChangeScreen(new LoadFileScreen(m_screenManager));  //Load File Screen Appears
        }
        #endregion
        #endregion
        // Character Creation Screen Methods
        #region Character Creation Screen
        #region Player Selection
        #region Player One
        //Changes Player Textures to the First Character.
        public string ChoosePlayerOne()
        {
            Game1.activePlayerTexture = Game1.charaOne_World;
            Game1.activePlayer_FightTexture = Game1.charaOne_Fight;

            string whichCharacter = "Player01";
            return whichCharacter;
        }
        #endregion
        #region Player Two
        //Changes Player Textures to the Second Character.
        public string ChoosePlayerTwo()
        {
            Game1.activePlayerTexture = Game1.charaTwo_World;
            Game1.activePlayer_FightTexture = Game1.charaTwo_Fight;

            string whichCharacter = "Player02";
            return whichCharacter;
        }
        #endregion
        #region Player Three
        //Changes Player Textures to the Third Character.
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
        //This Method Begins the game by Changing Screens to the World Map
        public void StartGame(IGameScreenManager m_screenManager)
        {
            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();

            m_screenManager.ChangeScreen(new WorldMapScreen(m_screenManager));
        }
        #endregion
        #endregion
        //Music Methods
        #region Music
        //World Map Music is turned on.
        public void WorldMapMusicOn(SoundEffect bgm)
        {
            Game1.currentInstance = bgm.CreateInstance();
            Game1.currentInstance.IsLooped = true;
            Game1.currentInstance.Volume = Game1.musicVolume;

            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Play();
        }

        //Music is turned off.
        public void MusicOff()
        {
            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();
        }
        #endregion
    }
}
