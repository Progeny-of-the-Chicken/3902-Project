using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Projectiles
{
    public interface IProjectile
    {
        int damage { get; }

        void Update(GameTime gt);

        void Draw(SpriteBatch sb);

        bool CheckDelete();

        void Despawn();
    }
}
