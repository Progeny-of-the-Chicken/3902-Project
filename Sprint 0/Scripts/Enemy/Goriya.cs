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
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    class Goriya : IEnemy
    {
        IProjectile boomerang;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        static RNGCryptoServiceProvider randomDir;
        byte[] random;

        Rectangle frontFrame = new Rectangle(222, 10, 15, 17);
        Rectangle backFrame = new Rectangle(240, 10, 14, 17);
        Rectangle[] rightFrames = { new Rectangle(256, 10, 14, 17), new Rectangle(274, 11, 16, 16) };

        public int Damage { get => ObjectConstants.GoriyaDamage; }
        int health = ObjectConstants.GoriyaStartingHealth;
        bool delete = false;
        bool inKnockBack = false;

        float timeSinceMove = 0;
        float timeSinceKnockback = 0;

        FacingDirection direction;
        Vector2 location;
        Vector2 knockbackDirection;
        (Vector2 directionVector, ISprite sprite) dependency;

        Dictionary<FacingDirection, (Vector2 vector, ISprite sprite)> directionDependencies;
        public Goriya(Vector2 location)
        {

            this.location = location;

            random = new byte[3];
            randomDir = new RNGCryptoServiceProvider();
            directionDependencies = new Dictionary<FacingDirection, (Vector2 vector, ISprite sprite)>();
            directionDependencies.Add(FacingDirection.Right, (Vector2.UnitX, EnemySpriteFactory.Instance.CreateRightGoriyaSprite(rightFrames)));
            directionDependencies.Add(FacingDirection.Left, (-Vector2.UnitX, EnemySpriteFactory.Instance.CreateLeftGoriyaSprite(rightFrames)));
            directionDependencies.Add(FacingDirection.Up, (-Vector2.UnitY, EnemySpriteFactory.Instance.CreateBackGoriyaSprite(backFrame)));
            directionDependencies.Add(FacingDirection.Down, (Vector2.UnitY, EnemySpriteFactory.Instance.CreateFrontGoriyaSprite(frontFrame)));
            direction = FacingDirection.Down;
            directionDependencies.TryGetValue(direction, out dependency);

            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (frontFrame.Size.ToVector2() * ObjectConstants.scale).ToPoint()));

            boomerang = null;

            ObjectsFromObjectsFactory.Instance.CreateEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime t)
        {
            if (boomerang == null)
            {
                if (!inKnockBack) 
                { 
                    Move(t);
                    dependency.sprite.Update(t);
                }
                else 
                {
                    GetKnockedBack(t);
                }
            }
            else
            {
                boomerang.Update(t);
                if (boomerang.CheckDelete())
                {
                    boomerang = null;
                }
            }
            collider.Update(location);
        }
        public void Move(GameTime t)
        {
            timeSinceMove += (float)t.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= ObjectConstants.GoriyaMoveTime)
            {
                SetRandomDirection();
                timeSinceMove = 0;
            }
            location += dependency.directionVector * ObjectConstants.GoriyaMoveSpeed * (float)t.ElapsedGameTime.TotalSeconds;
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
            //First byte is direction, second is whether it will shoot instead
            randomDir.GetBytes(random);
            if (random[1] % 5 == 0)
            {
                ShootProjectile();
            }
            else
            {
                direction = (FacingDirection)(random[0] % 4);
                directionDependencies.TryGetValue(direction, out dependency);
            }
        }

        public void ShootProjectile()
        {
            boomerang = ObjectsFromObjectsFactory.Instance.CreateBoomerangFromEnemy(location, direction, this);
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

        public void Draw(SpriteBatch sb)
        {
            dependency.sprite.Draw(sb, location);
            if(boomerang != null)
            {
                boomerang.Draw(sb);
            }
        }
    }
}

