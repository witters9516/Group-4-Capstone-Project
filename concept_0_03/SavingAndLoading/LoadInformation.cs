using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace concept_0_03
{
    static class LoadInformation
    {
        //fields
        static StreamReader reader;

        #region Public Loading Methods
        //This is the master function For Loading Saved Data.
        public static SavedDataFile LoadSavedInformation(SavedDataFile sdf, int sdfNumber)
        {
            //Get TextFiles.
            string PO_TextFile = GetPlayerDataPath(sdfNumber);          //Get Player Info txt file.
            string PGK_TextFile = GetPlayerGoldenKeysPath(sdfNumber);   //Get Golden Keys txt file.
            string PSK_TextFile = GetPlayerSilverKeysPath(sdfNumber);   //Get Silver Keys txt file.

            //Get Informations and return it to sdf.
            sdf = LoadOtherPlayerData(sdf, PO_TextFile);     //Get main player data
            sdf = LoadInKeys(sdf, PGK_TextFile, "gold");     //Get acquired Golden Keys 
            sdf = LoadInKeys(sdf, PSK_TextFile, "silver");   //Get acquired Silver Keys

            //Return sdf for use.
            return sdf;
        }
        #endregion

        #region Private Loading Methods
        //This Function Loads The Battle and Player Variables into an object.
        private static SavedDataFile LoadOtherPlayerData(SavedDataFile sdf, string textFile)
        {
            //Variables
            reader = File.OpenText(textFile);           //Open a txt file for reading.
            List<string> token = new List<string>();    //Create a token list to hold the info.

            //Loop to read all lines and add the info to token.
            while (!reader.EndOfStream)
            {
                string temp = reader.ReadLine();
                token.Add(temp);
            }

            //Set info
            sdf.SetSaveFileNumber(int.Parse(token[0])); //Set Save File Number
            sdf.SetWhichCharacter(int.Parse(token[1])); //Set Which Character Selected
            sdf.SetLevelsUnlocked(int.Parse(token[2])); //Set Levels Unlocked
            
            //Closing code
            reader.Close(); //Close Reader
            return sdf; //Return sdf object.
        }

        //Reads in SaveFile Personal Obtained Keys File. Then returns the list of keys back.
        private static SavedDataFile LoadInKeys(SavedDataFile sdf, string filename, string goldOrSilver)
        {
            //Variables
            List<string> Keys = new List<string>();         //Create list to hold the LevelKeyNames of the keys obtained.
            StreamReader sr = new StreamReader(filename);   //Create a StreamReader.

            //Loop to read all lines and add the info to Keys list.
            while (!sr.EndOfStream)
            {
                string temp = sr.ReadLine();
                Keys.Add(temp);
            }

            //Load in obtained keys.
            foreach (string str in Keys)
                if(goldOrSilver == "gold")
                    sdf.SetObtainedGoldenKeys(WorldMapScreen.keyInventory.FindKeyAndSetObtainToTrue(goldOrSilver, str));
                else
                    sdf.SetObtainedSilverKeys(WorldMapScreen.keyInventory.FindKeyAndSetObtainToTrue(goldOrSilver, str));

            //Closing Code
            sr.Close(); //Close sr
            return sdf; //Return sdf object.
        }
        #endregion

        #region Switch Methods
        //Get Player Info txt file
        private static string GetPlayerDataPath(int sdfNumber)
        {
            switch (sdfNumber)
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
        private static string GetPlayerGoldenKeysPath(int sdfNumber)
        {
            switch (sdfNumber)
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
        private static string GetPlayerSilverKeysPath(int sdfNumber)
        {
            switch (sdfNumber)
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
