using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace concept_0_03
{
    internal class Utility
    {
        internal static Vector2 CenterTextHorizontal(int windowWidth, float yPos, SpriteFont spriteFont, string text)
        {
            var textSize = spriteFont.MeasureString(text);

            return new Vector2((windowWidth / 2) - (textSize.X / 2), yPos);
        }

        internal static Vector2 CenterTextVertical(int windowHeight, float xPos, SpriteFont spriteFont, string text)
        {
            var textSize = spriteFont.MeasureString(text);

            return new Vector2(xPos, (windowHeight / 2) - (textSize.Y / 2));
        }

        internal static Vector2 CenterText(int windowHeight, int windowWidth, SpriteFont spriteFont, string text)
        {
            var textSize = spriteFont.MeasureString(text);

            return new Vector2((windowWidth / 2) - (textSize.X / 2), (windowHeight / 2) - (textSize.Y / 2));
        }
    }
}
