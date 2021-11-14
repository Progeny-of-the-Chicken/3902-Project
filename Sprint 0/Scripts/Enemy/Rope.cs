using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class Rope : IEnemy
    {
        ISprite sprite;

        ISprite leftSprite;
        ISprite rightSprite;

        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;

        float timeSinceMove = ObjectConstants.counterInitialVal_float;
        float timeSinceKnockback = ObjectConstants.counterInitialVal_float;

        public int Damage { get => ObjectConstants.RopeDamage; }
        int health = ObjectConstants.RopeStartingHealth;
        bool delete = false;
        bool inKnockBack = false;

        Vector2 location;
        Vector2 direction;
        Vector2 knockbackDirection;

        public Rope(Vector2 location)
        {
            this.location = location;
            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            
            rightSprite = EnemySpriteFactory.Instance.CreateRightRopeSprite(SpriteRectangles.ropeFrames);
            leftSprite = EnemySpriteFactory.Instance.CreateLeftRopeSprite(SpriteRectangles.ropeFrames);
            sprite = rightSprite;
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.ropeFrames[ObjectConstants.zero].Size.ToVector2() * ObjectConstants.scale).ToPoint()));
            SetRandomDirection();

            ObjectsFromObjectsFactory.Instance.CreateEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            if (!inKnockBack)
            {
                Move(gt);
                sprite.Update(gt);
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
            if (timeSinceMove >= ObjectConstants.RopeMoveTime)
            {
                SetRandomDirection();
                timeSinceMove = ObjectConstants.counterInitialVal_float;
            }
            location += direction * ObjectConstants.RopeMoveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
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
            if (random[ObjectConstants.firstInArray] % ObjectConstants.oneInTwo == ObjectConstants.zero_int)
                direction = Vector2.UnitX;
            else
                direction = Vector2.UnitY;
            if (random[ObjectConstants.secondInArray] % ObjectConstants.oneInTwo == ObjectConstants.zero_int)
                direction *= ObjectConstants.vectorFlip;
            if (direction == ObjectConstants.LeftUnitVector)
                sprite = leftSprite;
            else
                sprite = rightSprite;
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
