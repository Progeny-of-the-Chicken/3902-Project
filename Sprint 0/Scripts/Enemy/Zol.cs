using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using System.Security.Cryptography;
using Sprint_0.Scripts.Collider.Enemy;


namespace Sprint_0.Scripts.Enemy
{
    public class Zol : IEnemy
    {
        ISprite sprite;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        Rectangle[] frames = { new Rectangle(78, 11, 14, 16), new Rectangle(95, 11, 14, 16) };

        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;

        float timeSinceMove = 0;
        bool delete = false;

        public int Damage { get => ObjectConstants.ZolDamage; }
        int health = ObjectConstants.ZolStartingHealth;

        Vector2 location;
        Vector2 direction;

        public Zol(Vector2 location)
        {
            this.location = location;
            direction = new Vector2(-1, 0);
            random = new byte[2];
            sprite = EnemySpriteFactory.Instance.CreateZolSprite(frames);
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (frames[0].Size.ToVector2() * ObjectConstants.scale).ToPoint()));
        }
        public void Update(GameTime t)
        {
            timeSinceMove += (float)t.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= ObjectConstants.ZolPauseTime)
            {
                Move(t);
            }
            sprite.Update(t);
        }

        public void Move(GameTime t)
        {
            if (timeSinceMove >= ObjectConstants.ZolMoveTime + ObjectConstants.ZolPauseTime)
            {
                SetRandomDirection();
                timeSinceMove = 0;
            }

            location += direction * ObjectConstants.ZolMoveSpeed * (float)t.ElapsedGameTime.TotalSeconds;
            collider.Update(location);
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
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
