using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Sprite;


namespace Sprint_0.Scripts.Enemy
{
    class Keese : IEnemy
    {
        enum Direction { Up, Down, Left, Right, UpLeft, UpRight, DownLeft, DownRight};

        private static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        private KeeseSprite sprite;
        private Vector2 location;
        public Keese(Vector2 location)
        {
            this.location = location;
            sprite = (KeeseSprite)EnemySpriteFactory.Instance.CreateKeeseSprite();
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
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
            sprite.Draw(sb, location);
        }
    }
}
