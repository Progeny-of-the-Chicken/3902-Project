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
        KeeseSprite sprite;

        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;
        
        const float moveTime = 1;
        const float moveSpeed = 100;
        float timeSinceMove = 0;
        
        Vector2 location;
        Vector2 directionVector;

        public Keese(Vector2 location)
        {
            this.location = location;
            directionVector = Vector2.Zero;
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
                SetRandomDirection();
                timeSinceMove = 0;
            }
            location += directionVector * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
        }
        void SetRandomDirection()
        {
            randomDir.GetBytes(random);
            directionVector.X = (random[0] % 3) - 1;
            directionVector.Y = (random[1] % 3) - 1;
        }
        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}
