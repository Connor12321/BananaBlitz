using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BananaBlitz
{
    public abstract class Components
    {

        public abstract void Draw(GameTime gameTime, SpriteBatch _spriteBatch);

        public abstract void Update(GameTime gameTime);

    }
}
