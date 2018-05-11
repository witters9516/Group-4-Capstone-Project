using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace concept_0_03
{
    internal class Text
    {
        //Variables to be used.
        internal string Message { get; set; }
        internal SpriteFont SpriteFont { get; set; }
        internal Vector2 Position { get; set; }
        internal Color Color { get; set; }

        //Constructor
        public Text(string _message, SpriteFont _spriteFont, Vector2 _position, Color _color)
        {
            Message = _message;
            SpriteFont = _spriteFont;
            Position = _position;
            Color = _color;
        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFont, Message, Position, Color);
        }

        //Center from left to right
        public void CenterHorizontal(int windowWidth, float yPos)
        {
            Position = Utility.CenterTextHorizontal(windowWidth, yPos, SpriteFont, Message);
        }

        //Center from top to Bottom
        public void CenterVertical(int windowHeight, float xPos)
        {
            Position = Utility.CenterTextVertical(windowHeight, xPos, SpriteFont, Message);
        }

        //Center Text Position.
        public void CenterText(int windowHeight, int windowWidth)
        {
            Position = Utility.CenterText(windowHeight, windowWidth, SpriteFont, Message);
        }
    }
}
