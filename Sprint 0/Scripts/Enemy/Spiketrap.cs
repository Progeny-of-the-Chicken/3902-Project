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
    class SpikeTrap : IEnemy
    {
        ISprite sprite;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        Rectangle frame = new Rectangle(161, 58, 24, 18);

        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;

        const float moveTime = 1;
        float moveSpeed;
        float timeSinceMove = 0;

        public int Damage { get => _damage; }
        int _damage;
        int health = 3;
        const int knockbackDistance = 50;
        bool delete = false;

        Vector2 location;
        Vector2 direction;
        public SpikeTrap(Vector2 location, float scale)
        {
            this.location = location;
            moveSpeed = 25 * scale;
            direction = new Vector2(-1, 0);
            random = new byte[2];
            sprite = (SpikeTrapSprite)EnemySpriteFactory.Instance.CreateSpikeTrapSprite(scale, frame);
        }

        public void Update(GameTime gt)
        {
            Move(gt);
            sprite.Update(gt);
        }

        void Move(GameTime gt)
        {
            //move according to link's position
            //if link is under, move down
            //if link is above, move up
            //if link is left, move left
            //if link is down, move down,
           // SetOriginalPosition(sprite, linkPosition);
        }

        void SetOriginalPosition(ISprite sprite, Vector2 linkPosition )
        {
            //set original position
        }

        public void TakeDamage(int damage)
        {
            //these do not take damage
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
