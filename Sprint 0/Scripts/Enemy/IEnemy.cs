using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint_0.Scripts.Enemy
{
    public interface IEnemy
    {
        public void Update(GameTime t);

        void Draw(SpriteBatch sb);

    }
}
