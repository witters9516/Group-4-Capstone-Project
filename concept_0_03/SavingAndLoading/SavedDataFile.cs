using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace concept_0_03
{
    class SavedDataFile
    {
        //Fields
        int whichSavedFile; //Save File Number (1-3)
        int whichCharacter; //Character chosen at new game
        int levelsUnlocked; //Number of levels the player has already unlocked.
        List<KeyClass> ObtainedSilverKeys = new List<KeyClass>();   //Silver Keys List
        List<KeyClass> ObtainedGoldKeys = new List<KeyClass>();     //Golden Keys List

        //2 constructors
        //1. For a brand new save
        //2. For a Loaded Save.
        public SavedDataFile(int saveFileNumber, int character,  int lvlsUnlocked, List<KeyClass> SilList, List<KeyClass> GoldList)
        {
            whichSavedFile = saveFileNumber;    //Set whichSavedFile
            whichCharacter = character;         //Set whichCharacter
            levelsUnlocked = lvlsUnlocked;      //Set levelsUnlocked
            ObtainedSilverKeys = SilList;       //Set ObtainedSilverKeys
            ObtainedGoldKeys = GoldList;        //Set ObtainedGoldKeys
        }

        public SavedDataFile(int sfNumber)
        {
            whichSavedFile = sfNumber;      //Set whichSavedFile
            whichCharacter = 1;             //Set whichCharacter
            levelsUnlocked = 1;             //Set levelsUnlocked
        }

        //Getters
        public int GetSaveFileNumber()
        {
            return whichSavedFile;      //Return whichSavedFile
        }

        public int GetWhichCharacter()
        {
            return whichCharacter;      //Return whichCharacter
        }

        public int GetLevelsUnlocked()
        {
            return levelsUnlocked;      //Return levelsUnlocked
        }

        public List<KeyClass> GetObtainedSilverKeys()
        {
            return ObtainedSilverKeys;      //Return ObtainedSilverKeys
        }

        public List<KeyClass> GetObtainedGoldenKeys()
        {
            return ObtainedGoldKeys;      //Return ObtainedGoldKeys
        }

        //Setters
        public void SetSaveFileNumber(int i)
        {
            whichSavedFile = i;      //Set whichSavedFile
        }

        public void SetWhichCharacter(int i)
        {
            whichCharacter = i;      //Set whichCharacter
        }

        public void SetLevelsUnlocked(int i)
        {
            levelsUnlocked = i;      //Set levelsUnlocked
        }

        public void SetObtainedSilverKeys(List<KeyClass> list)
        {
            ObtainedSilverKeys = list;      //Set ObtainedSilverKeys
        }

        public void SetObtainedGoldenKeys(List<KeyClass> list)
        {
            ObtainedGoldKeys = list;      //Set ObtainedGoldKeys
        }
    }
}
