using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Collider.Enemy;



namespace Sprint_0.Scripts.Enemy
{
    class Wallmaster : IEnemy
    {

        ISprite sprite;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;

        const float moveTime = 1;
        float moveSpeed;
        float timeSinceMove = 0;

        Vector2 location;
        Vector2 direction;
        public Wallmaster(Vector2 location, float scale)
        {
            this.location = location;
            moveSpeed = 25 * scale;
            direction = new Vector2(-1, 0);
            random = new byte[2];
            sprite = (WallmasterOpenSprite)EnemySpriteFactory.Instance.CreateWallmasterOpenSprite(scale);
        }

        public void Update(GameTime gt)
        {
            Move(gt);
            sprite.Update(gt);
        }

        void Move(GameTime gt)
        {
            timeSinceMove += (float)gt.ElapsedGameTime.TotalSeconds;

            if (timeSinceMove >= moveTime)
            {
                SetRandomDirection();
                timeSinceMove = 0;
            }
            location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
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