using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Collider.Enemy;


namespace Sprint_0.Scripts.Enemy
{
    class Gel : IEnemy
    {
        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        
        ISprite sprite;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        Rectangle[] frames = { new Rectangle(1, 15, 8, 9), new Rectangle(10, 15, 8, 9) };

        byte[] random;

        float timeSinceMove = 0;
        bool delete = false;

        public int Damage { get => ObjectConstants.GelDamage; }
        int health = ObjectConstants.GelStartingHealth;
        
        Vector2 location;
        Vector2 direction;

        public Gel(Vector2 location)
        {
            this.location = location;
            random = new byte[2];
            sprite = EnemySpriteFactory.Instance.CreateGelSprite(frames);

            Rectangle collision = new Rectangle(location.ToPoint(), (frames[0].Size.ToVector2() * ObjectConstants.scale).ToPoint());
            collider = new GenericEnemyCollider(this, collision);
            
            SetRandomDirection();
        }

        public void Update(GameTime t)
        {
            timeSinceMove += (float)t.ElapsedGameTime.TotalSeconds;
            if(timeSinceMove >= ObjectConstants.GelPauseTime)
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
                timeSinceMove = 0;
            }
            
            location += direction * ObjectConstants.GelMoveSpeed * (float)t.ElapsedGameTime.TotalSeconds;
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
            delete = (health <= 0);
            SFXManager.Instance.PlayEnemyHit();
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
