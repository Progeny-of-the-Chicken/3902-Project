using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using System.Security.Cryptography;


namespace Sprint_0.Scripts.Enemy
{
    public class Zol : IEnemy
    {
        ISprite sprite;
        IEnemyCollider collider;

        Rectangle[] frames = { new Rectangle(78, 11, 14, 16), new Rectangle(95, 11, 14, 16) };

        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;

        float moveTime = 1;
        float moveSpeed;
        float timeSinceMove = 0;
        float pauseTime = 1;

        public int damage { get => _damage; }
        int _damage;
        int health = 1;
        const int knockbackDistance = 50;

        Vector2 location;
        Vector2 direction;

        public Zol(Vector2 location, float scale)
        {
            this.location = location;
            moveSpeed = 25 * scale;
            direction = new Vector2(-1, 0);
            random = new byte[2];
            sprite = (ZolSprite)EnemySpriteFactory.Instance.CreateZolSprite(scale, frames);
            collider = new GenericEnemyCollider(this, new Rectangle(0, 0, (int)(frames[0].Width * scale), (int)(frames[0].Height * scale)));
        }
        public void Update(GameTime t)
        {
            timeSinceMove += (float)t.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= pauseTime)
            {
                Move(t);
            }
            sprite.Update(t);
            collider.Update(location);
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
        public void TakeDamage(int damage, Vector2 knockback)
        {
            health -= damage;
            location += knockback * knockbackDistance;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
