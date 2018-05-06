using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03
{
    class KeyInventory
    {
        //Variables
        List<KeyClass> SilverKeyList = new List<KeyClass>();
        List<KeyClass> GoldKeyList = new List<KeyClass>();

        //public Constructor
        public KeyInventory()
        {
            CreateListOfKeys();
        }

        //Create the lists of keys.
        private void CreateListOfKeys()
        {
            SilverKeyList = AddKeysToList(SilverKeyList, "Silver"); //Create Silver List
            GoldKeyList = AddKeysToList(GoldKeyList, "Gold");       //Create Gold List
        }

        //The AddKeyToList Method fills a temporary list with keys up to the 
        //number of worlds and levels in each world. It then returns a list.
        private List<KeyClass> AddKeysToList(List<KeyClass> list, string color)
        {
            //List of level quantities contained in each world.
            List<int> WorldLevelCount = new List<int>() { 11, 11, 12 };

            //Variables
            int worldcount = 1;
            int levelcount = 1;

            //Nested loop for creating all the keys.
            for (int a = 0; a < WorldLevelCount.Count; a++)
                for (int i = 0; i < WorldLevelCount[a]; i++)
                {
                    list.Add(new KeyClass(worldcount, levelcount, color));  //Add Created key to list.
                    levelcount++;                                           //increment levelCount.
                    if (levelcount == WorldLevelCount[a] + 1)
                    {
                        levelcount = 1;
                        worldcount++;
                    }

                }
            return list;    //Return list.
        }

        //The FindKeyAndSetObtainToTrue Method takes 2 strings as parameters.
        //goldOrSilver - chooses a list based on argument given.
        //worldLevelName - the level tag to find the specific key.
        public List<KeyClass> FindKeyAndSetObtainToTrue(string goldOrSilver, string worldLevelName)
        {
            List<KeyClass> tempList;

            if (goldOrSilver.ToLower() == "gold")
                tempList = GoldKeyList;
            else
                tempList = SilverKeyList;

            for (int i = 0; i < tempList.Count; i++)
                if (tempList[i].GetKeyLevelName() == worldLevelName)
                    tempList[i].SetObtained(true);

            return tempList;
        }

        //Getters and Setters
        //The GetSilverKeyList Method returns the SilverKeyList.
        public List<KeyClass> GetSilverKeyList()
        {
            return SilverKeyList;
        }
        //The GetGoldKeyList Method returns the SilverKeyList.
        public List<KeyClass> GetGoldKeyList()
        {
            return GoldKeyList;
        }
        //The SetSilverKeyList Method takes a list as an argument.
        //It then sets SilverKeyList to that last.
        public void SetSilverKeyList(List<KeyClass> list)
        {
            SilverKeyList = list;
        }
        //The SetGoldKeyList Method takes a list as an argument.
        //It then sets GoldKeyList to that last.
        public void SetGoldKeyList(List<KeyClass> list)
        {
            GoldKeyList = list;
        }
    }
}
