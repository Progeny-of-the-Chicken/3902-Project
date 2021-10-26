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
        IEnemyCollider DamageCollider;
        IEnemyCollider XDetectionCollider;
        IEnemyCollider YDetectionCollider;
        public IEnemyCollider Collider {get => DamageCollider;}
        public IEnemyCollider XCollider { get => XDetectionCollider; }

        public IEnemyCollider YCollider { get => YDetectionCollider; }

        Rectangle damageFrame = new Rectangle(164, 59, 16, 16);
        Rectangle RectangleX;
        Rectangle RectangleY;
        Vector2 OriginalLocation;
        float moveSpeed;
        bool hasHit = false;
        int damage;
        public Vector2 Location { get => location; }

        public int Damage { get => damage; }
        const int knockbackDistance = 50;
        bool delete = false;

        Vector2 location;
        Vector2 direction;
        public SpikeTrap(Vector2 location)
        {
            this.location = location;
            moveSpeed = 25 * ObjectConstants.scale;
            OriginalLocation = location;
            direction = Vector2.Zero;
            RectangleX = new Rectangle((int)location.X - (12 * ObjectConstants.standardWidthHeight * ObjectConstants.scale), (int)location.Y, (25 * ObjectConstants.standardWidthHeight * ObjectConstants.scale), ObjectConstants.standardWidthHeight);
            RectangleY = new Rectangle((int)location.X, ((int)location.Y - (7 * ObjectConstants.standardWidthHeight * ObjectConstants.scale)), ObjectConstants.standardWidthHeight, (15 * ObjectConstants.standardWidthHeight * ObjectConstants.scale));
            DamageCollider = new GenericEnemyCollider(this, new Rectangle((int)location.X, (int)location.Y , (int)(damageFrame.Width * ObjectConstants.scale), (int)(damageFrame.Height * ObjectConstants.scale)));
            XDetectionCollider = new DetectionCollider(this, RectangleX);
            YDetectionCollider = new DetectionCollider(this, RectangleY);
            sprite = (SpikeTrapSprite)EnemySpriteFactory.Instance.CreateSpikeTrapSprite(ObjectConstants.scale, damageFrame);
        }

        public void Update(GameTime gt)
        {
            if (hasHit == false)
            {
                Move(gt);
                sprite.Update(gt);
            } else
            {
                SetOriginalPosition(gt);
            }
            
            
        }

        void Move(GameTime gt)
        {
            //move according to link's position
            location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
            
            DamageCollider.Update(location);
        }

        public void SetHasHit(Vector2 direction)
        {
            this.direction = direction;
            hasHit = true;
        }

        public void SetOriginalPosition(GameTime gt)
        {
            if (location != OriginalLocation)
            {
                location -= direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
            } else
            {
                hasHit = false;
                direction = Vector2.Zero;
            }
            
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
