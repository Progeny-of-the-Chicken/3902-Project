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
        bool delete = false;

        public int Damage { get => ObjectConstants.GelDamage; }
        int health = ObjectConstants.GelStartingHealth;

        Vector2 location;
        Vector2 direction;

        public Gel(Vector2 location)
        {
            this.location = location;
            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            sprite = EnemySpriteFactory.Instance.CreateGelSprite(SpriteRectangles.gelFrames);

            Rectangle collision = new Rectangle(location.ToPoint(), (SpriteRectangles.gelFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale).ToPoint());
            collider = new GenericEnemyCollider(this, collision);

            SetRandomDirection();

            ObjectsFromObjectsFactory.Instance.CreateEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime t)
        {
            timeSinceMove += (float)t.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= ObjectConstants.GelPauseTime)
            {
                Move(t);
            }
            sprite.Update(t);
        }

        public void Move(GameTime t)
        {
            if (timeSinceMove >= ObjectConstants.GelMoveTime + ObjectConstants.GelPauseTime)
            {
                SetRandomDirection();
                timeSinceMove = ObjectConstants.counterInitialVal_float;
            }

            location += direction * ObjectConstants.GelMoveSpeed * (float)t.ElapsedGameTime.TotalSeconds;
            collider.Update(location);
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
                ObjectsFromObjectsFactory.Instance.CreateEffect(location, Effect.EffectType.Pop);
                delete = true;
            }
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
