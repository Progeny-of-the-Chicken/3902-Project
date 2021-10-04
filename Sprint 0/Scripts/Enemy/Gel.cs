using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Enemy
{
    class Gel : IEnemy
    {
        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        
        ISprite sprite;

        byte[] random;

        const float moveTime = 1;
        const float pauseTime = 1;
        const float moveSpeed = 100;
        float timeSinceMove = 0;
        
        Vector2 location;
        Vector2 direction;

        public Gel(Vector2 location)
        {
            this.location = location;
            direction = new Vector2(-1, 0);
            random = new byte[2];
            sprite = EnemySpriteFactory.Instance.CreateGelSprite();
        }

        public void Update(GameTime t)
        {
            timeSinceMove += (float)t.ElapsedGameTime.TotalSeconds;
            if(timeSinceMove >= pauseTime)
            {
                Move(t);
            }
            sprite.Update(t);   
        }

        public void Move(GameTime t)
        {
            if (timeSinceMove >= moveTime + pauseTime)
            {
                SetRandomDirection();
                timeSinceMove = 0;
            }
            
            location += direction * moveSpeed * (float)t.ElapsedGameTime.TotalSeconds;
        }
        void SetRandomDirection()
        {
            //First byte is vertical/horizontal, second is +/-
            randomDir.GetBytes(random);
            if (random[0] % 2 == 0)
            {
                direction.X = (random[1] % 2) * 2 - 1;
                direction.Y = 0;
            }
            else
            {
                direction.X = 0;
                direction.Y = (random[1] % 2) * 2 - 1;
            }
        }
        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}
