using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace concept_0_03
{
    static class SaveInformation
    {
        #region Public Save Functions
        //Public Master Function to Save Data
        public static void SaveFileInfo(SavedDataFile sdf)
        {
            // Writing data:
            string[] POtoken = new string[3];
            POtoken[0] = sdf.GetSaveFileNumber().ToString();    //Set Save File Number to index 0
            POtoken[1] = sdf.GetWhichCharacter().ToString();    //Set whichCharcter to index 1
            POtoken[2] = sdf.GetLevelsUnlocked().ToString();    //Set levelsUnlocked to index 2

            //Rewrite all lines with new data
            File.WriteAllLines(GetSaveFilePlayerInfoFilePath(sdf.GetSaveFileNumber()), POtoken);

            //Create a list names LevelObtainedKeys
            List<string> LevelObtainedKeys = new List<string>();

            //Create string arrays to hold keys
            string[] PKGoldToken = new string[sdf.GetObtainedGoldenKeys().Count];
            string[] PKSilverToken = new string[sdf.GetObtainedGoldenKeys().Count];

            //Get the levelNames of all obtained keys in Golden Key List
            for (int i = 0; i < sdf.GetObtainedGoldenKeys().Count; i++)
                if(sdf.GetObtainedGoldenKeys()[i].GetObtained() == true)
                    LevelObtainedKeys.Add(sdf.GetObtainedGoldenKeys()[i].GetKeyLevelName());

            PKGoldToken = LevelObtainedKeys.ToArray();      //Change from list to array

            //Reset LevelObtainedKeys
            LevelObtainedKeys = new List<string>();

            //Get the levelNames of all obtained keys in Silver Key List
            for (int i = 0; i < sdf.GetObtainedSilverKeys().Count; i++)
                if (sdf.GetObtainedSilverKeys()[i].GetObtained() == true)
                    LevelObtainedKeys.Add(sdf.GetObtainedSilverKeys()[i].GetKeyLevelName());

            PKSilverToken = LevelObtainedKeys.ToArray();  //Change from list to array

            //Rewrite all lines with new data
            File.WriteAllLines(GetSaveFilePlayerObtainedGoldenKeysFilePath(sdf.GetSaveFileNumber()), PKGoldToken);      //Golden Key Info
            File.WriteAllLines(GetSaveFilePlayerObtainedSilverKeysFilePath(sdf.GetSaveFileNumber()), PKSilverToken);    //Silver Key Info
        }
        #endregion

        #region Switch Functions
        //Get Player Info txt file
        private static string GetSaveFilePlayerInfoFilePath(int sfNumber)
        {
            switch (sfNumber)
            {
                case 1:
                    return "SF1_PlayerInfo.txt";
                case 2:
                    return "SF2_PlayerInfo.txt";
                case 3:
                    return "SF3_PlayerInfo.txt";
                default:
                    return "SF1_PlayerInfo.txt";
            }
        }

        //Get Player Golden Keys txt file
        private static string GetSaveFilePlayerObtainedGoldenKeysFilePath(int sfNumber)
        {
            switch (sfNumber)
            {
                case 1:
                    return "SF1_PlayerObtainedGoldenKeys.txt";
                case 2:
                    return "SF2_PlayerObtainedGoldenKeys.txt";
                case 3:
                    return "SF3_PlayerObtainedGoldenKeys.txt";
                default:
                    return "SF1_PlayerObtainedGoldenKeys.txt";
            }
        }

        //Get Player Silver Keys txt file
        private static string GetSaveFilePlayerObtainedSilverKeysFilePath(int sfNumber)
        {
            switch (sfNumber)
            {
                case 1:
                    return "SF1_PlayerObtainedSilverKeys.txt";
                case 2:
                    return "SF2_PlayerObtainedSilverKeys.txt";
                case 3:
                    return "SF3_PlayerObtainedSilverKeys.txt";
                default:
                    return "SF1_PlayerObtainedSilverKeys.txt";
            }
        }
        #endregion
    }
}
