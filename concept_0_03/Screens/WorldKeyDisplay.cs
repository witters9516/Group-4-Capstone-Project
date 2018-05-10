using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace concept_0_03
{
    class WorldKeyDisplay : IGameScreen
    {
        #region Script Variables
        //Standard Game Screen Variables.
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;
        private Command m_command;
        //Buttons and Variables for them.
        Texture2D buttonTexture;
        SpriteFont buttonFont;
        //Buttons
        Button switchListButton;
        public string sbtext = "Golden Keys";
        Button BackButton;
        //Current Keys List
        List<KeyClass> currentDisplayedKeys;
        //needed for Filling the Gallery.
        public int worldDisplayed = 1;
        int spotCount;
        int line;
        
        private List<Component> m_components;   //List of components.
        private SoundEffect click;              //SoundEffect
        //IsPaused
        public bool IsPaused { get; private set; }
        //Image Paths and Textures.
        Texture2D image_KeyGallery;
        Texture2D image_NotUnlocked;
        Texture2D image_SilverKey;
        Texture2D image_GoldenKey;
        Texture2D image_Background;
        string path;
        string path2;
        string path3;
        string path4;
        string path5;
        #endregion

        //Constructor
        public WorldKeyDisplay(IGameScreenManager gameScreenManager)
        {
            m_ScreenManager = gameScreenManager;
            m_command = new Command(m_ScreenManager);
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }

        public void Init(ContentManager content)
        {
            //Set up button click audio effect
            click = content.Load<SoundEffect>("SFX/Select_Click");
            //Set currentDisplayedKeys
            currentDisplayedKeys = WorldMapScreen.keyInventory.GetSilverKeyList();
            //Set paths for content
            path = "KeyGallery/KeyGalleryFrame";
            path2 = "KeyGallery/NotObtainedKey";
            path3 = "KeyGallery/SilverKey";
            path4 = "KeyGallery/GoldKey";
            path5 = "BGs/bgMountains";

            //Set images with paths
            image_KeyGallery = content.Load<Texture2D>(path);
            image_NotUnlocked = content.Load<Texture2D>(path2);
            image_SilverKey = content.Load<Texture2D>(path3);
            image_GoldenKey = content.Load<Texture2D>(path4);
            image_Background = content.Load<Texture2D>(path5);

            //Set button UI elements.
            buttonTexture = content.Load<Texture2D>("Menu/Blue/blue_button04");
            buttonFont = content.Load<SpriteFont>("Fonts/Font");

            //Create Buttons
            switchListButton = CreateButton(new Vector2(570, 65), sbtext);
            BackButton = CreateButton(new Vector2(590, 5), "Back");

            //Set Click Functions to button.
            switchListButton.Click += SwitchListsButton_Click;
            BackButton.Click += Back_Click;

            //Create a component leist with all UI.
            m_components = new List<Component>()
            {
                switchListButton,
                BackButton
            };
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();    //Begin SpriteBatch

            //Background
            spriteBatch.Draw(image_Background, new Rectangle(0, 0, 800, 600), Color.White);

            //1.Fill Gallery With colored keys based on switchListButton Text.
            if (switchListButton.Text == "Golden Keys")
                FillGalleryWithPictures(spriteBatch, WorldMapScreen.keyInventory.GetSilverKeyList());
            else
                FillGalleryWithPictures(spriteBatch, WorldMapScreen.keyInventory.GetGoldKeyList());

            //2. Fill in remaining blank spaces.
            FillRemainingEmptyPictures(spriteBatch);


            //3. Load up other UI objects.
            spriteBatch.Draw(image_KeyGallery, new Rectangle(0, -2, 802, 602), Color.White);

            //Draw all buttons to screen.
            foreach (var i in m_components)
                i.Draw(gameTime, spriteBatch);

            spriteBatch.End();  //Begin SpriteBatch
        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();
            
            //KeyBoard input statments.
            if (keyboard.IsKeyDown(Keys.Back) == true)
                Back_Pressed();
        }

        public void ChangeBetweenScreens()
        {
            if (m_exitGame)
                m_ScreenManager.Exit();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var component in m_components)
                component.Update(gameTime);
        }

        #region Script Personalized Functions
        #region CreateButton Function
        //Creates a Button and returns it.
        private Button CreateButton(Vector2 v2, string text)
        {
            Button tempButton = new Button(buttonTexture, buttonFont)
            {

                Position = v2,
                Text = text,
            };

            return tempButton;
        }
        #endregion

        #region FillGalleryFunctions
        private void FillGalleryWithPictures(SpriteBatch spriteBatch, List<KeyClass> list)
        {
            //Set tempImage temporarily.
            Texture2D tempImage = image_SilverKey;
            
            //Line and spot count variables.
            line = 0;
            spotCount = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetKeyWorld() == worldDisplayed)
                {
                    //Check to see what image to place down.
                    if (list[i].GetObtained() == true)
                    {
                        if (list[i].GetKeyType() == KeyClass.KeyType.Gold)
                            tempImage = image_GoldenKey;    //tempImage set to Golden Key Image.
                        else if (list[i].GetKeyType() == KeyClass.KeyType.Silver)
                            tempImage = image_SilverKey;    //tempImage set to Silver Key Image.
                    }
                    else
                        tempImage = image_NotUnlocked;  //tempImage set to Not Unlocked Image.

                    //Draw the image to the screen.
                    spriteBatch.Draw(tempImage, new Rectangle(49 + (spotCount * 176), 120 + (line * 147), 170, 140), Color.White);

                    spotCount++;    //Increment spotcount

                }

                //If spotCount is at the last spot on a row, increment line and set spotCount to zero.
                if (spotCount == 4)
                {
                    line++;         //Increment Line
                    spotCount = 0;  //Set spotCount to 0.
                }
            }
        }

        private void FillRemainingEmptyPictures(SpriteBatch spriteBatch)
        {
            //Set tempImage temporarily.
            Texture2D tempImage = image_SilverKey;

            //Variables for blocked out spaces
            int scount = spotCount;
            int lcount = line;
            for (int k = 0; k < (12 - (4 * lcount)) - scount; k++)
            {
                //Draw a blacked out image.
                spriteBatch.Draw(tempImage, new Rectangle(49 + (spotCount * 176), 120 + (line * 147), 170, 140), Color.Black);
                
                //Increment spotCount.
                spotCount++;

                if (spotCount == 4)
                {
                    line++;         //Increment Line
                    spotCount = 0;  //Set spotCount to 0.
                }
            }
        }
        #endregion
        #endregion

        #region Button Press Functions
        #region Switch From Gold Keys To Silver Keys
        private void SwitchListsButton_Click(object sender, EventArgs e)
        {
            click.Play();   //Play Audio Clip

            //Change SwitchListButton Text.
            if (switchListButton.Text == "Golden Keys")
                switchListButton.Text = "Silver Keys";

            //Call Draw to reload pics
            WorldKeyDisplay temp = new WorldKeyDisplay(m_ScreenManager);
            temp.worldDisplayed = this.worldDisplayed;
            temp.sbtext = switchListButton.Text;

            //Change Screens Based on what screen is 
            if (sbtext == "Golden Keys")
                m_ScreenManager.PushScreen(temp);
            else
                m_ScreenManager.PopScreen();

            //Set switchListButton text to golden keys.
            switchListButton.Text = "Golden Keys";
        }

        private void SwitchListsButton_Pressed()
        {
            click.Play();   //Play Audio Clip

            //Change SwitchListButton Text.
            if (switchListButton.Text == "Golden Keys")
                switchListButton.Text = "Silver Keys";

            //Call Draw to reload pics
            WorldKeyDisplay temp = new WorldKeyDisplay(m_ScreenManager);
            temp.worldDisplayed = this.worldDisplayed;
            temp.sbtext = switchListButton.Text;

            //Change Screens Based on what screen is 
            if (sbtext == "Golden Keys")
                m_ScreenManager.PushScreen(temp);
            else
                m_ScreenManager.PopScreen();

            //Set switchListButton text to golden keys.
            switchListButton.Text = "Golden Keys";
        }
        #endregion

        #region Back Button Button Functions
        private void Back_Click(object sender, EventArgs e)
        {
            click.Play();   //Play Audio Clip

            if (this.sbtext == "Golden Keys")
                m_ScreenManager.PopScreen(); //Pop Once
            else
                for (int i = 0; i < 2; i++)
                    m_ScreenManager.PopScreen(); //Pop Twice
        }

        private void Back_Pressed()
        {
            click.Play();   //Play Audio Clip

            if (this.sbtext == "Golden Keys")
                m_ScreenManager.PopScreen(); //Pop Once
            else
                for (int i = 0; i < 2; i++)
                    m_ScreenManager.PopScreen(); //Pop Twice
        }
        #endregion
        #endregion
    }
}
