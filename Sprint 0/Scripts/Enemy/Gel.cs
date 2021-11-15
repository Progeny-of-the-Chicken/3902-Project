using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;


namespace Sprint_0.Scripts.Enemy
{
    class Gel : IEnemy
    {
        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();

        ISprite sprite;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        byte[] random;

        float timeSinceMove = ObjectConstants.counterInitialVal_float;
        float timeSinceKnockback = ObjectConstants.counterInitialVal_float;
        bool delete = false;
        bool inKnockBack = false;

        public int Damage { get => ObjectConstants.GelDamage; }
        int health = ObjectConstants.GelStartingHealth;

        Vector2 location;
        Vector2 direction;
        Vector2 knockbackDirection;

        public Gel(Vector2 location)
        {
            this.location = location;
            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            sprite = EnemySpriteFactory.Instance.CreateGelSprite(SpriteRectangles.gelFrames);

            Rectangle collision = new Rectangle(location.ToPoint(), (SpriteRectangles.gelFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale).ToPoint());
            collider = new GenericEnemyCollider(this, collision);

            SetRandomDirection();

            ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Explosion);
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
            if (timeSinceMove >= ObjectConstants.GelMoveTime + ObjectConstants.GelPauseTime)
            {
                SetRandomDirection();
                timeSinceMove = ObjectConstants.counterInitialVal_float;
            }
            if(timeSinceMove >= ObjectConstants.GelPauseTime)
            {
                location += direction * ObjectConstants.GelMoveSpeed * (float)t.ElapsedGameTime.TotalSeconds;
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
            if (random[ObjectConstants.firstInArray] % ObjectConstants.oneInTwo == ObjectConstants.zero_int)
                direction = Vector2.UnitX;
            else
                direction = Vector2.UnitY;
            if (random[ObjectConstants.secondInArray] % ObjectConstants.oneInTwo == ObjectConstants.zero_int)
                direction *= ObjectConstants.vectorFlip;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= ObjectConstants.zero)
            {
                ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Pop);
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
