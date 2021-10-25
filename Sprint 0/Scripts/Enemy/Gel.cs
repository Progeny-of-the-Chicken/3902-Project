using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Collider.Enemy;


namespace Sprint_0.Scripts.Enemy
{
    class Gel : IEnemy
    {
        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        
        ISprite sprite;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        Rectangle[] frames = { new Rectangle(1, 15, 8, 9), new Rectangle(10, 15, 8, 9) };

        byte[] random;

        const float moveTime = 1;
        const float pauseTime = 1;
        float moveSpeed;
        float timeSinceMove = 0;
        bool delete = false;

        public int Damage { get => _damage; }
        int _damage = 1;
        int health = 1;
        
        Vector2 location;
        Vector2 direction;

        public Gel(Vector2 location, float scale)
        {
            this.location = location;
            moveSpeed = 25 * scale;
            direction = new Vector2(-1, 0);
            random = new byte[2];
            sprite = EnemySpriteFactory.Instance.CreateGelSprite(scale, frames);

            Rectangle collision = new Rectangle(0, 0, (int) (frames[0].Width * scale), (int) (frames[0].Height * scale));
            collider = new GenericEnemyCollider(this, collision);
        }

        public void Update(GameTime t)
        {
            timeSinceMove += (float)t.ElapsedGameTime.TotalSeconds;
            if(timeSinceMove >= pauseTime)
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

        public void TakeDamage(int damage)
        {
            health -= damage;
            delete = (health <= 0);
        }
        public void KnockBack(Vector2 knockback)
        {
            location += knockback;
        }
        public bool CheckDelete()
        {
            return delete;
        }
        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}
