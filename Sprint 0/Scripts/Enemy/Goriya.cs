using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
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

        public int Damage { get => ObjectConstants.GoriyaDamage; }
        int health = ObjectConstants.GoriyaStartingHealth;
        bool delete = false;
        bool inKnockBack = false;

        float timeSinceMove = ObjectConstants.counterInitialVal_float;
        float timeSinceKnockback = ObjectConstants.counterInitialVal_float;
        FacingDirection direction;
        Vector2 location;
        Vector2 knockbackDirection;
        (Vector2 directionVector, ISprite sprite) dependency;

        Dictionary<FacingDirection, (Vector2 vector, ISprite sprite)> directionDependencies;
        public Goriya(Vector2 location)
        {

            this.location = location;

            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            randomDir = new RNGCryptoServiceProvider();
            directionDependencies = new Dictionary<FacingDirection, (Vector2 vector, ISprite sprite)>();
            directionDependencies.Add(FacingDirection.Right, (ObjectConstants.RightUnitVector, EnemySpriteFactory.Instance.CreateRightGoriyaSprite()));
            directionDependencies.Add(FacingDirection.Left, (ObjectConstants.LeftUnitVector, EnemySpriteFactory.Instance.CreateLeftGoriyaSprite()));
            directionDependencies.Add(FacingDirection.Up, (ObjectConstants.UpUnitVector, EnemySpriteFactory.Instance.CreateBackGoriyaSprite()));
            directionDependencies.Add(FacingDirection.Down, (ObjectConstants.DownUnitVector, EnemySpriteFactory.Instance.CreateFrontGoriyaSprite()));
            direction = FacingDirection.Down;
            directionDependencies.TryGetValue(direction, out dependency);

            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.goriyaFrontFrame.Size.ToVector2() * ObjectConstants.scale).ToPoint()));

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
                timeSinceMove = ObjectConstants.counterInitialVal_float;
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
            if (random[ObjectConstants.secondInArray] % ObjectConstants.oneInFive == ObjectConstants.zero_int)
            {
                ShootProjectile();
            }
            else
            {
                direction = (FacingDirection)(random[ObjectConstants.firstInArray] % ObjectConstants.oneInFour);
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
            dependency.sprite.Draw(sb, location);
            if (boomerang != null)
            {
                boomerang.Draw(sb);
            }
        }
    }
}

