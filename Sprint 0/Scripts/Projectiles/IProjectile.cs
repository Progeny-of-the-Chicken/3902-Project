﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Projectiles
{
    public interface IProjectile
    {
        void Update(GameTime gt);

        void Draw(SpriteBatch sb);

        bool CheckDelete();
    }
}
