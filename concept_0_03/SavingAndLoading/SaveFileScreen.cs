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
    class SaveFileScreen : IGameScreen
    {
        #region Script Variables
        //Standard Script Variables
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;
        private Command m_command;
        //Buttons and Variables for them.
        Texture2D buttonTexture;
        Texture2D buttonTexture_SaveFile1;
        Texture2D buttonTexture_SaveFile2;
        Texture2D buttonTexture_SaveFile3;
        SpriteFont buttonFont;
        //Buttons
        Button BackButton;
        public string sbtext = "Golden Keys";
        Button Save1Button;
        Button Save2Button;
        Button Save3Button;
        //KeygalleryImage and path.
        Texture2D image_SaveFileTitle;
        string path = "KeyGallery/KeyGalleryTitle";
        Texture2D image_BG;
        string BGpath = "BGs/bgMountainsViolet";

        private List<Component> m_components;   //List of components.
        private SoundEffect click;              //Sound Effect
        //IsPaused
        public bool IsPaused { get; private set; }
        #endregion

        //Constructor.
        public SaveFileScreen(IGameScreenManager gameScreenManager)
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
            //Set content for Audio Click.
            click = content.Load<SoundEffect>("SFX/Select_Click");

            //Set Path For keyGallery Screen.
            image_BG = content.Load<Texture2D>(BGpath);

            //Set Path For keyGallery Screen.
            path = "LoadFile/SaveFileTitle";

            //Set Content for Key Gallery Screen.
            image_SaveFileTitle = content.Load<Texture2D>(path);

            //Set Button Background UI elements.
            buttonTexture = content.Load<Texture2D>("Menu/Grey/grey_button04");
            buttonTexture_SaveFile1 = content.Load<Texture2D>("LoadFile/LoadFile1");
            buttonTexture_SaveFile2 = content.Load<Texture2D>("LoadFile/LoadFile2");
            buttonTexture_SaveFile3 = content.Load<Texture2D>("LoadFile/LoadFile3");

            //Load Font
            buttonFont = content.Load<SpriteFont>("Fonts/Font");

            //Create Buttons
            Save1Button = CreateButton(buttonTexture_SaveFile1, new Vector2(15, 275), "");
            Save2Button = CreateButton(buttonTexture_SaveFile2, new Vector2(275, 275), "");
            Save3Button = CreateButton(buttonTexture_SaveFile3, new Vector2(535, 275), "");
            BackButton = CreateButton(buttonTexture, new Vector2(315, 460), "Back");

            //Set Click Functions to button.
            Save1Button.Click += SaveFile1_Click;
            Save2Button.Click += SaveFile2_Click;
            Save3Button.Click += SaveFile3_Click;
            BackButton.Click += BackButton_Click;

            //List of components containing all the buttons for the screen.
            m_components = new List<Component>()
            {
                Save1Button,
                Save2Button,
                Save3Button,
                BackButton
            };
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();    //Begin SpriteBatch

            //Draw BackGround
            spriteBatch.Draw(image_BG, new Vector2(0, 0), Color.White);

            //Draw Key Gallery Title
            spriteBatch.Draw(image_SaveFileTitle, new Vector2(100, 0), Color.White);

            //Draw all buttons to screen.
            foreach (var i in m_components)
                i.Draw(gameTime, spriteBatch);

            spriteBatch.End();  //End SpriteBatch
        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                m_exitGame = true;
            }

            //if (keyboard.IsKeyDown(Keys.Back) == true)
            //    BackButton_Pressed();
        }

        public void ChangeBetweenScreens()
        {
            if (m_exitGame)
            {
                m_ScreenManager.Exit();
            }
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
        private Button CreateButton(Texture2D bT, Vector2 v2, string text)
        {
            Button tempButton = new Button(bT, buttonFont)
            {

                Position = v2,
                Text = text,
            };

            return tempButton;
        }

        private void SaveInfo(int saveFileNumber)
        {
            int temp = 0;   //Temporary int value to load a certain character.

            if (Game1.activePlayerTexture == Game1.charaOne_World)
                temp = 1;   //Set Temp to 1
            if (Game1.activePlayerTexture == Game1.charaTwo_World)
                temp = 2;   //Set Temp to 2
            if (Game1.activePlayerTexture == Game1.charaThree_World)
                temp = 3;   //Set Temp to 3

            //Save info
            SaveInformation.SaveFileInfo(new SavedDataFile(saveFileNumber, temp, Game1.levelsUnlocked, WorldMapScreen.keyInventory.GetSilverKeyList(), WorldMapScreen.keyInventory.GetGoldKeyList()));
        }
        #endregion

        #region Button Click and Press Functions
        private void SaveFile1_Click(object sender, EventArgs e)
        {
            click.Play();   //play Audio Click Effect

            if (Game1.isOnWorldMap == true)
                SaveInfo(1);    //Save Information into file 1.

            m_ScreenManager.PopScreen();    //pop the current screen.
        }

        private void SaveFile2_Click(object sender, EventArgs e)
        {
            click.Play();   //play Audio Click Effect

            if (Game1.isOnWorldMap == true)
                SaveInfo(2);    //Save Information into file 2.

            m_ScreenManager.PopScreen();    //pop the current screen.

        }

        private void SaveFile3_Click(object sender, EventArgs e)
        {
            click.Play();   //play Audio Click Effect

            if (Game1.isOnWorldMap == true)
                SaveInfo(3);    //Save Information into file 3.

            m_ScreenManager.PopScreen();    //pop the current screen.
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            click.Play();   //Play Audio Clip
            m_ScreenManager.PopScreen();    //Pop The current Screen
        }

        private void BackButton_Pressed()
        {
            click.Play();   //Play Audio Clip
            m_ScreenManager.PopScreen();    //Pop the current Screen
        }
        #endregion
    }
}
