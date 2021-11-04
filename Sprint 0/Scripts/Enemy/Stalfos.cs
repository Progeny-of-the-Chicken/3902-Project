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
    public class Stalfos : IEnemy
    {
        ISprite sprite;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        Rectangle frame = new Rectangle(1, 59, 16, 16);

        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;

        float timeSinceMove = 0;

        public int Damage { get => ObjectConstants.StalfosDamage; }
        int health = ObjectConstants.StalfosStartingHealth;
        bool delete = false;

        Vector2 location;
        Vector2 direction;

        public Stalfos(Vector2 location)
        {
            this.location = location;
            random = new byte[2];
            sprite = EnemySpriteFactory.Instance.CreateStalfosSprite(frame);
            collider = new GenericEnemyCollider(this, new Rectangle(location.ToPoint(), (frame.Size.ToVector2() * ObjectConstants.scale).ToPoint()));
            SetRandomDirection();

            ObjectsFromObjectsFactory.Instance.CreateEffect(location, Effect.EffectType.Explosion);
        }

        public void Update(GameTime gt)
        {
            Move(gt);
            sprite.Update(gt);
        }

        void Move(GameTime gt)
        {
            timeSinceMove += (float)gt.ElapsedGameTime.TotalSeconds;

            if (timeSinceMove >= ObjectConstants.StalfosMoveTime)
            {
                SetRandomDirection();
                timeSinceMove = 0;
            }
            location += direction * ObjectConstants.StalfosMoveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
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
            if (health <= 0)
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
