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



namespace Sprint_0.Scripts.Enemy
{
    class Wallmaster : IEnemy
    {

        ISprite sprite;
        ISprite openSprite;
        ISprite closeSprite;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        Rectangle openFrame = new Rectangle(392, 10, 18, 16);
        Rectangle closeFrame = new Rectangle(410, 11, 14, 16);

        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;
        public int Damage { get => _damage; }
        int _damage;
        int health = 3;
        const int knockbackDistance = 50;
        bool delete = false;

        const float moveTime = 1;
        float moveSpeed;
        float timeSinceMove = 0;

        Vector2 location;
        Vector2 direction;
        public Wallmaster(Vector2 location, float scale)
        {
            this.location = location;
            moveSpeed = 25 * scale;
            direction = new Vector2(-1, 0);
            random = new byte[2];
            openSprite = (WallmasterOpenSprite)EnemySpriteFactory.Instance.CreateWallmasterOpenSprite(scale, openFrame);
            closeSprite = (WallmasterCloseSprite)EnemySpriteFactory.Instance.CreateWallmasterCloseSprite(scale, openFrame);
            sprite = openSprite;
            collider = new GenericEnemyCollider(this, new Rectangle(0, 0, (int)(openFrame.Width * scale), (int)(openFrame.Height * scale)));
        }

        public void Update(GameTime gt)
        {
            Move(gt);
            sprite.Update(gt);
            collider.Update(location);
        }

        void Move(GameTime gt)
        {
            timeSinceMove += (float)gt.ElapsedGameTime.TotalSeconds;

            if (timeSinceMove >= moveTime)
            {
                SetRandomDirection();
                timeSinceMove = 0;
            }
            location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
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

        public void GrabLink()
        {
            //todo 
            //change to closed hand, move link
            sprite = closeSprite;

            //change to first dungeon room
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            delete = (health <= 0);
        }
        public void KnockBack(Vector2 knockback)
        {
            location += knockback * knockbackDistance;
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