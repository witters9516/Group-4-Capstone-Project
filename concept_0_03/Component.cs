using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace concept_0_03
{
    public abstract class Component
    {
        //Public  Draw
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        //Public  Update
        public abstract void Update(GameTime gameTime);
    }
}
