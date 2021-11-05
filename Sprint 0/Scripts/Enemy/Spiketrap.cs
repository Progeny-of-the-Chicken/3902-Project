﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;

namespace Sprint_0.Scripts.Enemy
{
    class SpikeTrap : IEnemy
    {
        //TODO: additional refactoring needed with magic numbers
        ISprite sprite;
        IEnemyCollider DamageCollider;
        IEnemyCollider XDetectionCollider;
        IEnemyCollider YDetectionCollider;
        public IEnemyCollider Collider { get => DamageCollider; }
        public IEnemyCollider XCollider { get => XDetectionCollider; }

        public IEnemyCollider YCollider { get => YDetectionCollider; }

        Rectangle RectangleX;
        Rectangle RectangleY;
        Vector2 OriginalLocation;
        float moveSpeed;
        bool hasHit = false;
        int damage;
        public Vector2 Location { get => location; }

        public int Damage { get => damage; }
        const int knockbackDistance = 50;//TODO: magic number 50
        bool delete = false;

        Vector2 location;
        Vector2 direction;
        public SpikeTrap(Vector2 location)
        {
            this.location = location;
            moveSpeed = ObjectConstants.spikeTrapSpeed * ObjectConstants.scale;
            OriginalLocation = location;
            direction = Vector2.Zero;
            RectangleX = new Rectangle((int)location.X - (12 * ObjectConstants.scaledStdWidthHeight), (int)location.Y, (25 * ObjectConstants.scaledStdWidthHeight), ObjectConstants.standardWidthHeight);
            RectangleY = new Rectangle((int)location.X, ((int)location.Y - (7 * ObjectConstants.scaledStdWidthHeight)), ObjectConstants.standardWidthHeight, (15 * ObjectConstants.scaledStdWidthHeight));
            DamageCollider = new GenericEnemyCollider(this, new Rectangle((int)location.X, (int)location.Y, (SpriteRectangles.spikeTrapFrame.Width * ObjectConstants.scale), (SpriteRectangles.spikeTrapFrame.Height * ObjectConstants.scale)));
            XDetectionCollider = new DetectionCollider(this, RectangleX);
            YDetectionCollider = new DetectionCollider(this, RectangleY);
            sprite = (SpikeTrapSprite)EnemySpriteFactory.Instance.CreateSpikeTrapSprite(ObjectConstants.scale, SpriteRectangles.spikeTrapFrame);
        }

        public void Update(GameTime gt)
        {
            if (hasHit == false)
            {
                Move(gt);
                sprite.Update(gt);
            }
            else
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
            }
            else
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
