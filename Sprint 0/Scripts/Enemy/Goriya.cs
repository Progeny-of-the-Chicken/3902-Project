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

        float timeSinceMove = ObjectConstants.counterInitialVal_float;

        FacingDirection direction;
        Vector2 location;
        (Vector2 directionVector, ISprite sprite) dependency;

        Dictionary<FacingDirection, (Vector2 vector, ISprite sprite)> directionDependencies;
        public Goriya(Vector2 location)
        {

            this.location = location;

            random = new byte[ObjectConstants.GoriyaRandomBytes];
            randomDir = new RNGCryptoServiceProvider();
            directionDependencies = new Dictionary<FacingDirection, (Vector2 vector, ISprite sprite)>();
            directionDependencies.Add(FacingDirection.Right, (Vector2.UnitX, EnemySpriteFactory.Instance.CreateRightGoriyaSprite(SpriteRectangles.goriyaRightFrames)));
            directionDependencies.Add(FacingDirection.Left, (-Vector2.UnitX, EnemySpriteFactory.Instance.CreateLeftGoriyaSprite(SpriteRectangles.goriyaRightFrames)));
            directionDependencies.Add(FacingDirection.Up, (-Vector2.UnitY, EnemySpriteFactory.Instance.CreateBackGoriyaSprite(SpriteRectangles.goriyaBackFrame)));
            directionDependencies.Add(FacingDirection.Down, (Vector2.UnitY, EnemySpriteFactory.Instance.CreateFrontGoriyaSprite(SpriteRectangles.goriyaFrontFrame)));
            direction = FacingDirection.Down;
            directionDependencies.TryGetValue(direction, out dependency);

            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.goriyaFrontFrame.Size.ToVector2() * ObjectConstants.scale).ToPoint()));

            boomerang = null;
        }

        public void Update(GameTime t)
        {
            if (boomerang == null)
            {
                Move(t);
                dependency.sprite.Update(t);
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

        public void Move(GameTime gt)
        {
            timeSinceMove += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= ObjectConstants.GoriyaMoveTime)
            {
                SetRandomDirection();
                timeSinceMove = ObjectConstants.counterInitialVal_float;
            }
            location += dependency.directionVector * ObjectConstants.GoriyaMoveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
        }

        void SetRandomDirection()
        {
            //First byte is direction, second is whether it will shoot instead
            randomDir.GetBytes(random);
            if (random[ObjectConstants.secondInArray] % ObjectConstants.oneInFive == ObjectConstants.zero)
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
            boomerang = ObjectsFromObjectsFactory.Instance.CreateBoomerangFromEnemy(location, direction);
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            delete = (health <= ObjectConstants.zeroHealth);
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
            dependency.sprite.Draw(sb, location);
            if(boomerang != null)
            {
                boomerang.Draw(sb);
            }
        }
    }
}

