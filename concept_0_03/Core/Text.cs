using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace concept_0_03
{
    internal class Text
    {
        internal string Message { get; set; }
        internal SpriteFont SpriteFont { get; set; }
        internal Vector2 Position { get; set; }
        internal Color Color { get; set; }

        public Text(string _message, SpriteFont _spriteFont, Vector2 _position, Color _color)
        {
            Message = _message;
            SpriteFont = _spriteFont;
            Position = _position;
            Color = _color;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFont, Message, Position, Color);
        }

        public void CenterHorizontal(int windowWidth, float yPos)
        {
            Position = Utility.CenterTextHorizontal(windowWidth, yPos, SpriteFont, Message);
        }

        public void CenterVertical(int windowHeight, float xPos)
        {
            Position = Utility.CenterTextVertical(windowHeight, xPos, SpriteFont, Message);
        }

        public void CenterText(int windowHeight, int windowWidth)
        {
            Position = Utility.CenterText(windowHeight, windowWidth, SpriteFont, Message);
        }
    }
}
