using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03
{
    class KeyClass
    {
        //Variables
        int keyWorld;
        int keyLevel;
        string keyLevelName;
        KeyType keyType;
        bool obtained = false;

        //Public enum for the key type.
        public enum KeyType
        {
            Gold,
            Silver,
            NotObtained
        };

        //Constructors
        public KeyClass()
        {
            keyLevelName = "";
            keyType = KeyType.Gold;
            obtained = false;
        }

        //Overloaded Constructor.
        public KeyClass(int kWorld, int kLevel, string keyColor)
        {
            keyWorld = kWorld;
            keyLevel = kLevel;
            keyLevelName = kWorld.ToString() + "-" + kLevel.ToString();
            if (keyColor == "Gold")
                keyType = KeyType.Gold;
            else if (keyColor == "Silver")
                keyType = KeyType.Silver;
            else
                keyType = KeyType.NotObtained;
            obtained = false;
        }

        //Getters
        //The GetKeyWorld returns keyWorld.
        public int GetKeyWorld()
        {
            return keyWorld;
        }
        //The GetKeyLevel returns keyLevel.
        public int GetKeyLevel()
        {
            return keyLevel;
        }
        //The GetKeyLevelName returns keyLevelName.
        public string GetKeyLevelName()
        {
            return keyLevelName;
        }
        //The GetKeyType returns keyType.
        public KeyType GetKeyType()
        {
            return keyType;
        }
        //The GetObtained returns obtained.
        public bool GetObtained()
        {
            return obtained;
        }

        //Setters
        //The SetKeyName method takes an int as an argument.
        //It then sets keyWorld to that int.
        public void SetKeyName(int world)
        {
            keyWorld = world;
        }

        //The SetKeyLevel method takes an int as an argument.
        //It then sets keyLevel to that int.
        public void SetKeyLevel(int level)
        {
            keyLevel = level;
        }

        //The SetKeyLevelName method takes an string as an argument.
        //It then sets keyLevelName to that string.
        public void SetKeyLevelName(string levelName)
        {
            keyLevelName = levelName;
        }

        //The SetKeyType method takes an KeyType as an argument.
        //It then sets keyType to that KeyType.
        public void SetKeyType(KeyType type)
        {
            keyType = type;
        }

        //The SetObtained method takes an bool as an argument.
        //It then sets obtained to that bool.
        public void SetObtained(bool b)
        {
            obtained = b;
        }
    }
}
