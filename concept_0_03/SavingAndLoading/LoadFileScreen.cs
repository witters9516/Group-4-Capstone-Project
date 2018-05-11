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
    class LoadFileScreen : IGameScreen
    {
        #region Script Variables
        //Standard Script Variables
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;
        private Command m_command;
        //Buttons and Variables for them.
        Texture2D buttonTexture;
        Texture2D buttonTexture_LoadFile1;
        Texture2D buttonTexture_LoadFile2;
        Texture2D buttonTexture_LoadFile3;
        SpriteFont buttonFont;
        //Buttons
        Button BackButton;
        public string sbtext = "Golden Keys";
        Button Load1Button;
        Button Load2Button;
        Button Load3Button;
        //KeygalleryImage and path.
        Texture2D image_LoadFileTitle;
        string path;
        Texture2D image_BG;
        string BGpath = "BGs/bgMountainsViolet";

        private List<Component> m_components;   //List of components.
        private SoundEffect click;              //Sound Effect
        //IsPaused
        public bool IsPaused { get; private set; }
        #endregion

        //Constructor.
        public LoadFileScreen(IGameScreenManager gameScreenManager)
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
            //Set caontent for Audio Click.
            click = content.Load<SoundEffect>("SFX/Select_Click");

            //Set Path For keyGallery Screen.
            image_BG = content.Load<Texture2D>(BGpath);

            //Set Path For keyGallery Screen.
            path = "LoadFile/LoadFileTitle";

            //Set Content for Key Gallery Screen.
            image_LoadFileTitle = content.Load<Texture2D>(path);

            //Set Button Background UI elements.
            buttonTexture = content.Load<Texture2D>("Menu/Grey/grey_button04");
            buttonTexture_LoadFile1 = content.Load<Texture2D>("LoadFile/LoadFile1");
            buttonTexture_LoadFile2 = content.Load<Texture2D>("LoadFile/LoadFile2");
            buttonTexture_LoadFile3 = content.Load<Texture2D>("LoadFile/LoadFile3");

            //Set buttonFont
            buttonFont = content.Load<SpriteFont>("Fonts/Font");

            //Create Buttons
            Load1Button = CreateButton(buttonTexture_LoadFile1, new Vector2(15, 275), "");
            Load2Button = CreateButton(buttonTexture_LoadFile2, new Vector2(275, 275), "");
            Load3Button = CreateButton(buttonTexture_LoadFile3, new Vector2(535, 275), "");
            BackButton = CreateButton(buttonTexture, new Vector2(315, 460), "Back");

            //Set Click Functions to button.
            Load1Button.Click += LoadFile1_Click;
            Load2Button.Click += LoadFile2_Click;
            Load3Button.Click += LoadFile3_Click;
            BackButton.Click += BackButton_Click;

            //List of components containing all the buttons for the screen.
            m_components = new List<Component>()
            {
                Load1Button,
                Load2Button,
                Load3Button,
                BackButton
            };
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();    //Begin SpriteBatch

            //Draw BackGround
            spriteBatch.Draw(image_BG, new Vector2(0, 0), Color.White);

            //Draw Key Gallery Title
            spriteBatch.Draw(image_LoadFileTitle, new Vector2(100, 0), Color.White);

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
        //Short Hand Button Creation Method
        private Button CreateButton(Texture2D bT, Vector2 v2, string text)
        {
            Button tempButton = new Button(bT, buttonFont)
            {

                Position = v2,
                Text = text,
            };

            return tempButton;
        }
        #endregion

        #region Button Click and Press Functions
        private void LoadFile1_Click(object sender, EventArgs e)
        {
            click.Play();   //play Audio Click Effect

            //Create a worldMapScreen
            //Use Game1.SaveFile1 Variables to change all of the variables needed to in World map screen
            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();

            Game1.opener = 1;
            m_command.StartGame(m_ScreenManager);

        }

        private void LoadFile2_Click(object sender, EventArgs e)
        {
            click.Play();   //play Audio Click Effect

            //Create a worldMapScreen
            //Use Game1.SaveFile1 Variables to change all of the variables needed to in World map screen
            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();

            Game1.opener = 2;
            m_command.StartGame(m_ScreenManager);

        }

        private void LoadFile3_Click(object sender, EventArgs e)
        {
            click.Play();   //play Audio Click Effect

            //Create a worldMapScreen
            //Use Game1.SaveFile1 Variables to change all of the variables needed to in World map screen
            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();

            Game1.opener = 3;
            m_command.StartGame(m_ScreenManager);

        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            click.Play();   //Play Audio Clip

            m_ScreenManager.ChangeScreen(new MenuScreen(m_ScreenManager));    //Pop the current Screen
        }

        private void BackButton_Pressed()
        {
            click.Play();   //Play Audio Clip

            m_ScreenManager.PopScreen();    //Pop the current Screen
        }
        #endregion
    }
}
