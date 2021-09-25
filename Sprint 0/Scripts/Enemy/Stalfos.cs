using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint_0.Scripts.Enemy
{
    public class Stalfos : IEnemy
    {
        enum Direction { Up, Down, Left, Right, Still };

        private static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();

        Stalfos(Rectangle sourceRectangle)
        {

        }

        public void Update(GameTime t)
        {

        }

        public void Move()
        {

        }

        public void ShootProjectile()
        {
            //not needed
        }

        public void Draw(SpriteBatch sb)
        {

        }
    }
}
