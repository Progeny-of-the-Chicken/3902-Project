using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;
using System.Collections.Generic;

namespace Sprint_0.Scripts.Enemy
{
    public class Rope : IEnemy
    {
        ISprite leftSprite;
        ISprite rightSprite;

        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }
        public IEnemyCollider ChaseCollider { get => dependency.chaseCollider; }

        IEnemyCollider leftCollider;
        IEnemyCollider rightCollider;

        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;

        float timeSinceMove = ObjectConstants.counterInitialVal_float;
        float timeSinceKnockback = ObjectConstants.counterInitialVal_float;

        public int Damage { get => ObjectConstants.RopeDamage; }
        int health = ObjectConstants.RopeStartingHealth;

        bool delete = false;
        bool inKnockBack = false;
        bool chasing = false;
        Vector2 location;

        FacingDirection direction;
        Vector2 knockbackDirection;

        (Vector2 directionVector, ISprite sprite, IEnemyCollider chaseCollider) dependency;

        Dictionary<FacingDirection, (Vector2, ISprite, IEnemyCollider)> directionDependencies;
        public Rope(Vector2 location)
        {
            this.location = location;
            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.ropeFrames[ObjectConstants.zero].Size.ToVector2() * ObjectConstants.scale).ToPoint()));
            leftCollider = new RopeDetectionCollider(this, new Rectangle(0, (int)location.Y, (int)location.X, ObjectConstants.scaledStdWidthHeight));
            rightCollider = new RopeDetectionCollider(this, new Rectangle((location + ObjectConstants.RightUnitVector * ObjectConstants.scaledStdWidthHeight).ToPoint(), new Point(ObjectConstants.roomWidth, ObjectConstants.scaledStdWidthHeight)));
            
            leftSprite = EnemySpriteFactory.Instance.CreateLeftRopeSprite();
            rightSprite = EnemySpriteFactory.Instance.CreateRightRopeSprite();

            directionDependencies = new Dictionary<FacingDirection, (Vector2, ISprite, IEnemyCollider)>();
            directionDependencies.Add(FacingDirection.Left, (ObjectConstants.LeftUnitVector, leftSprite, leftCollider));
            directionDependencies.Add(FacingDirection.Right, (ObjectConstants.RightUnitVector, rightSprite, rightCollider));
            directionDependencies.Add(FacingDirection.Up, (ObjectConstants.UpUnitVector, rightSprite, rightCollider));
            directionDependencies.Add(FacingDirection.Down, (ObjectConstants.DownUnitVector, rightSprite, rightCollider));
            SetRandomDirection();

            ObjectsFromObjectsFactory.Instance.CreateEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            if (!inKnockBack)
            {
                Move(gt);
                dependency.sprite.Update(gt);
            }
            else
            {
                GetKnockedBack(gt);
            }
            collider.Update(location);
            dependency.chaseCollider.Update(location);
        }

        public void Move(GameTime gt)
        {
            timeSinceMove += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= ObjectConstants.RopeMoveTime)
            {
                SetRandomDirection();
                timeSinceMove = ObjectConstants.counterInitialVal_float;
            }
            if (chasing)    location += dependency.directionVector * ObjectConstants.RopeChaseSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
            else            location += dependency.directionVector * ObjectConstants.RopeMoveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
            
            chasing = false;
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
            direction = (FacingDirection)(random[ObjectConstants.firstInArray] % ObjectConstants.oneInFour);
            directionDependencies.TryGetValue(direction, out dependency);
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            SFXManager.Instance.PlayEnemyHit();
            if (health <= ObjectConstants.zero)
            {
                SFXManager.Instance.PlayEnemyDeath();
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

        public void ChaseLink()
        {
            chasing = true;
            if (direction != FacingDirection.Left)
            {
                direction = FacingDirection.Right;
                directionDependencies.TryGetValue(direction, out dependency);
            }
        }

        public bool CheckDelete()
        {
            return delete;
        }

        public void Draw(SpriteBatch sb)
        {
            dependency.sprite.Draw(sb, location);
        }
    }
}
