using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;


namespace Sprint_0.Scripts.Enemy
{
    class Keese : IEnemy
    {
        ISprite sprite;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        Rectangle[] frames = { new Rectangle(200, 14, 16, 12), new Rectangle(183, 14, 18, 10) };


        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;
        
        float timeSinceMove = 0;

        public int Damage { get => ObjectConstants.KeeseDamage; }
        int health = ObjectConstants.KeeseStartingHealth;
        bool delete = false;

        Vector2 location;
        Vector2 directionVector;

        public Keese(Vector2 location)
        {
            this.location = location;
            directionVector = Vector2.Zero;
            random = new byte[2];
            sprite = EnemySpriteFactory.Instance.CreateKeeseSprite(frames);
            Rectangle collision = new Rectangle(location.ToPoint(), (frames[0].Size.ToVector2() * ObjectConstants.scale).ToPoint());
            collider = new GenericEnemyCollider(this, collision);
        }

        public void Update(GameTime gt)
        {
            Move(gt);
            if(directionVector != Vector2.Zero)
            {
                sprite.Update(gt);
            }
        }

        public void Move(GameTime gt)
        {
            timeSinceMove += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= ObjectConstants.KeeseMoveTime)
            {
                SetRandomDirection();
                timeSinceMove = 0;
            }
            location += directionVector * ObjectConstants.KeeseMoveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
            collider.Update(location);
        }
        void SetRandomDirection()
        {
            randomDir.GetBytes(random);
            directionVector.X = (random[0] % 3) - 1;
            directionVector.Y = (random[1] % 3) - 1;
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            delete = (health <= 0);
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
