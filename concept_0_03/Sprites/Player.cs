using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace concept_0_03
{
    public class Player : Sprite
    {
        //Fields
        public bool playerCanMove;

        //Constructor
        public Player(Texture2D texture)
            : base(texture)
        {
            playerCanMove = true;
        }

        //Update movement
        public override void Update(GameTime gameTime)
        {
            //Variables
            var velocity = new Vector2();
            var speed = 3f;

            //Check For movement
            if (playerCanMove)
            {
                #region Up & Down Movement -- CURRENTLY ON
                //Up 2 Down Checks
                if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
                    velocity.Y = -speed;    //UP
                else if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
                    velocity.Y = speed;     //DOWN
                #endregion

                #region Left & Right Movement -- CURRENTLY ON
                //Left 2 Right Checks
                if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
                    velocity.X = -speed;    //LEFT
                else if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
                    velocity.X = speed;     //RIGHT
                #endregion
            }
            
            Position += velocity;   //Change Velocity
        }
    }
}
