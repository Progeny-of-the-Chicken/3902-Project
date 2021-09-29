﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Items
{
    public interface IItem
    {
        void Update(GameTime gameTime);

        void Draw(SpriteBatch _spriteBatch);

        bool CheckDelete();
    }
}
