using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    class Keese : IEnemy
    {
        ISprite sprite;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;

        float timeSinceMove = ObjectConstants.counterInitialVal_float;
        float timeSinceKnockback = ObjectConstants.counterInitialVal_float;
        public int Damage { get => ObjectConstants.KeeseDamage; }
        int health = ObjectConstants.KeeseStartingHealth;
        bool delete = false;
        bool inKnockBack = false;

        Vector2 location;
        Vector2 directionVector;
        Vector2 knockbackDirection;

        public Keese(Vector2 location)
        {
            this.location = location;
            directionVector = Vector2.Zero;
            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            sprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
            Rectangle collision = new Rectangle(location.ToPoint(), (SpriteRectangles.keeseFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale).ToPoint());
            collider = new GenericEnemyCollider(this, collision);

            ObjectsFromObjectsFactory.Instance.CreateEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            if (!inKnockBack)
            {
                Move(gt);
                if (directionVector != Vector2.Zero)
                {
                    sprite.Update(gt);
                }
            }
            else
            {
                GetKnockedBack(gt);
            }
            collider.Update(location);
        }

        public void Move(GameTime gt)
        {
            timeSinceMove += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= ObjectConstants.KeeseMoveTime)
            {
                SetRandomDirection();
                timeSinceMove = ObjectConstants.counterInitialVal_float;
            }
            location += directionVector * ObjectConstants.KeeseMoveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
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
            randomDir.GetBytes(random);
            directionVector.X = (random[ObjectConstants.firstInArray] % ObjectConstants.oneInThree) + ObjectConstants.adjustByNegativeOne;
            directionVector.Y = (random[ObjectConstants.secondInArray] % ObjectConstants.oneInThree) + ObjectConstants.adjustByNegativeOne;
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= ObjectConstants.zero)
            {
                ObjectsFromObjectsFactory.Instance.CreateEffect(location, Effect.EffectType.Pop);
                delete = true;
                SFXManager.Instance.PlayEnemyDeath();
            }
            SFXManager.Instance.PlayEnemyHit();
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

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }
    }
}
