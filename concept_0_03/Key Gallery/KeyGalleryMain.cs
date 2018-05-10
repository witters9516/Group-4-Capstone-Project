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
    class KeyGalleryMain : IGameScreen
    {
        #region Script Variables
        //Standard Script Variables
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;
        private Command m_command;
        //Buttons and Variables for them.
        Texture2D buttonTexture;
        SpriteFont buttonFont;
        //Buttons
        Button BackButton;
        public string sbtext = "Golden Keys";
        Button World1Button;
        Button World2Button;
        Button World3Button;
        //KeygalleryImage and path.
        Texture2D image_KeyGalleryTitle;
        string path;
        private List<Component> m_components;   //List of components.
        private SoundEffect click;              //Sound Effect
        //IsPaused
        public bool IsPaused { get; private set; }
        #endregion

        //Constructor.
        public KeyGalleryMain(IGameScreenManager gameScreenManager)
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
            path = "KeyGallery/KeyGalleryTitle";
            
            //Set Content for Key Gallery Screen.
            image_KeyGalleryTitle = content.Load<Texture2D>(path);
            
            //Set Button Background UI elements.
            buttonTexture = content.Load<Texture2D>("Menu/Grey/grey_button04");
            buttonFont = content.Load<SpriteFont>("Fonts/Font");

            //Create Buttons
            World1Button = CreateButton(new Vector2(315, 310), "World 1 Keys");
            World2Button = CreateButton(new Vector2(315, 360), "World 2 Keys");
            World3Button = CreateButton(new Vector2(315, 410), "World 3 Keys");
            BackButton = CreateButton(new Vector2(315, 460), "Back");

            //Set Click Functions to button.
            World1Button.Click += World1Keys_Click;
            World2Button.Click += World2Keys_Click;
            World3Button.Click += World3Keys_Click;
            BackButton.Click += BackButton_Click;

            //List of components containing all the buttons for the screen.
            m_components = new List<Component>()
            {
                World1Button,
                World2Button,
                World3Button,
                BackButton
            };
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();    //Begin SpriteBatch

            //Draw Key Gallery Title
            spriteBatch.Draw(image_KeyGalleryTitle, new Vector2(0, 0), Color.White);

            //Draw all buttons to screen.
            foreach (var i in m_components)
                i.Draw(gameTime, spriteBatch);

            spriteBatch.End();  //End SpriteBatch
        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

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

        #region Button Click and Press Functions
        private void World1Keys_Click(object sender, EventArgs e)
        {
            click.Play();   //play Audio Click Effect

            //Call Draw to reload pics
            WorldKeyDisplay temp = new WorldKeyDisplay(m_ScreenManager);
            temp.worldDisplayed = 1;

            //Change Screens Based on what screen is 
            m_ScreenManager.PushScreen(temp);
        }

        private void World2Keys_Click(object sender, EventArgs e)
        {
            click.Play();   //play Audio Click Effect

            //Call Draw to reload pics
            WorldKeyDisplay temp = new WorldKeyDisplay(m_ScreenManager);
            temp.worldDisplayed = 2;

            //Change Screens Based on what screen is 
            m_ScreenManager.PushScreen(temp);
        }

        private void World3Keys_Click(object sender, EventArgs e)
        {
            click.Play();   //play Audio Click Effect

            //Call Draw to reload pics
            WorldKeyDisplay temp = new WorldKeyDisplay(m_ScreenManager);
            temp.worldDisplayed = 3;

            //Change Screens Based on what screen is 
            m_ScreenManager.PushScreen(temp);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            click.Play();   //Play Audio Clip

            m_ScreenManager.PopScreen();    //Pop the current Screen
        }

        private void BackButton_Pressed()
        {
            click.Play();   //Play Audio Clip

            m_ScreenManager.PopScreen();    //Pop the current Screen
        }
        #endregion
    }
}
