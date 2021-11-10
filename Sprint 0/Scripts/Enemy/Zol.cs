using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using System.Security.Cryptography;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;

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
        float timeSinceKnockback = 0;
        bool inKnockBack = false;
        bool delete = false;

        public int Damage { get => ObjectConstants.ZolDamage; }
        int health = ObjectConstants.ZolStartingHealth;

        Vector2 location;
        Vector2 direction;
        Vector2 knockbackDirection;

        public Zol(Vector2 location)
        {
            this.location = location;
            direction = new Vector2(-1, 0);
            random = new byte[2];
            sprite = EnemySpriteFactory.Instance.CreateZolSprite(frames);
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (frames[0].Size.ToVector2() * ObjectConstants.scale).ToPoint()));

            ObjectsFromObjectsFactory.Instance.CreateEffect(location, Effect.EffectType.Explosion);
        }
        public void Update(GameTime t)
        {
            if (!inKnockBack)
            {
                Move(t);
            }
            else
            {
                GetKnockedBack(t);
            }
            collider.Update(location);
            sprite.Update(t);
        }

        public void Move(GameTime t)
        {
            timeSinceMove += (float)t.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= ObjectConstants.ZolMoveTime + ObjectConstants.ZolPauseTime)
            {
                SetRandomDirection();
                timeSinceMove = 0;
            }
            if (timeSinceMove >= ObjectConstants.ZolPauseTime)
            {
                location += direction * ObjectConstants.ZolMoveSpeed * (float)t.ElapsedGameTime.TotalSeconds;
            }
        }
        void GetKnockedBack(GameTime t)
        {
            timeSinceKnockback += (float)t.ElapsedGameTime.TotalSeconds;
            location += knockbackDirection * ObjectConstants.DefaultEnemyKnockbackSpeed * (float)t.ElapsedGameTime.TotalSeconds;
            if (timeSinceKnockback >= ObjectConstants.DefaultEnemyKnockbackTime)
            {
                inKnockBack = false;
                timeSinceKnockback = 0;
            }
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
            if (health <= 0)
            {
                ObjectsFromObjectsFactory.Instance.CreateEffect(location, Effect.EffectType.Pop);
                delete = true;
            }
        }
        public void SuddenKnockBack(Vector2 knockback)
        {
            location += knockback;
        }
        public void GradualKnockBack(Vector2 knockback)
        {
            inKnockBack = true;
            knockback.Normalize();
            knockbackDirection = knockback;
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
