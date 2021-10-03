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
        private byte[] random;
        private float moveTime = 1;
        private float moveSpeed = 100;
        private float timeSinceMove = 0;
        private Vector2 directionVector;
        public Keese(Vector2 location)
        {
            this.location = location;
            directionVector = new Vector2(-1, 0);
            sprite = (KeeseSprite)EnemySpriteFactory.Instance.CreateKeeseSprite();
            random = new byte[2];
        }

        public void Update(GameTime gt)
        {
            Move(gt);
            if(directionVector != Vector2.Zero)
            {
                sprite.Update(gt);
            }
        }

        public void Move(GameTime gt)
        {
            timeSinceMove += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= moveTime)
            {
                //Get a random direction to move in
                randomDir.GetBytes(random);
                directionVector.X = (random[0] % 3) - 1;
                directionVector.Y = (random[1] % 3) - 1;
                timeSinceMove = 0;
            }
            location += directionVector * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}
