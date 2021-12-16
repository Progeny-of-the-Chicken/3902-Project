using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using System;

namespace Sprint_0.Scripts.Enemy
{
    class SpikeTrap : IEnemy
    {
        //
        ISprite sprite;
        IEnemyCollider DamageCollider;
        IEnemyCollider DetectionColliderRight;
        IEnemyCollider DetectionColliderLeft;
        IEnemyCollider DetectionColliderUp;
        IEnemyCollider DetectionColliderDown;
        public IEnemyCollider Collider { get => DamageCollider; }
        public IEnemyCollider ColliderRight { get => DetectionColliderRight; }

        public IEnemyCollider ColliderLeft { get => DetectionColliderLeft; }

        public IEnemyCollider ColliderUp { get => DetectionColliderUp; }

        public IEnemyCollider ColliderDown { get => DetectionColliderDown; }
        Rectangle RectangleXLeft;
        Rectangle RectangleXRight;
        Rectangle RectangleYDown;
        Rectangle RectangleYUp;
        Vector2 OriginalLocation;
        float moveSpeed;
        int damage;
        bool movingBack;
        bool moving;
        public int Damage { get => damage; }
        public Vector2 Position { get => location; }
        public bool CanBeAffectedByPlayer { get => true; }
        bool delete = false;
        private float verticalDistBeforeStop, horizontalDistBeforeStop;
        Vector2 location;
        Vector2 direction;
        public SpikeTrap(Vector2 location)
        {
            this.location = location;
            moveSpeed = ObjectConstants.spikeTrapSpeed;
            OriginalLocation = location;
            direction = ObjectConstants.zeroVector;

            setRectanglesForColliders();
            DamageCollider = new GenericEnemyCollider(this, new Rectangle((int)location.X, (int)location.Y, (SpriteRectangles.spikeTrapFrame.Width * ObjectConstants.scale), (SpriteRectangles.spikeTrapFrame.Height * ObjectConstants.scale)));

            DetectionColliderRight = new DetectionColliderRight(this, RectangleXRight);
            DetectionColliderLeft = new DetectionColliderLeft(this, RectangleXLeft);
            DetectionColliderUp = new DetectionColliderUp(this, RectangleYUp);
            DetectionColliderDown = new DetectionColliderDown(this, RectangleYDown);

            movingBack = false;
            moving = false;
            sprite = (SpikeTrapSprite)EnemySpriteFactory.Instance.CreateSpikeTrapSprite();
        }

        public void Update(GameTime gt)
        {
            if (moving)
                Move(gt);
            sprite.Update(gt);
        }

        void Move(GameTime gt)
        {
            if (!movingBack)
            {
                moveTowardCenter((float)gt.ElapsedGameTime.TotalSeconds);
            }
            else
            {
                moveBackToStart((float)gt.ElapsedGameTime.TotalSeconds);
            }
            DamageCollider.Update(location);
        }

        private void moveTowardCenter(float dt)
        {
            location += direction * moveSpeed * dt;
            //if we are moving left/right and have gone half of the detection distance, turn around
            if (Math.Abs(direction.Y) < ObjectConstants.verySmallVal && Math.Abs(OriginalLocation.X - location.X) > horizontalDistBeforeStop)
            {
                movingBack = true;
            }
            //if we are moving up/down and have gone half of the detection distance turn around
            else if (Math.Abs(direction.X) < ObjectConstants.verySmallVal && Math.Abs(OriginalLocation.Y - location.Y) > verticalDistBeforeStop)
            {
                movingBack = true;
            }
            DamageCollider.Update(location);
        }

        private void moveBackToStart(float dt)
        {
            location -= direction * moveSpeed * (float)ObjectConstants.halfAdjustment * dt ;
            //if we are moving left/right and are close enough, snap back
            if (Math.Abs(direction.Y) < ObjectConstants.verySmallVal && Math.Abs(OriginalLocation.X - location.X) < ObjectConstants.spikeTrapSnapDist)
            {
                stopAtStart();
            }
            //if we are moving up/down and are close enough, snap back
            else if (Math.Abs(direction.X) < ObjectConstants.verySmallVal && Math.Abs(OriginalLocation.Y - location.Y) < ObjectConstants.spikeTrapSnapDist)
            {
                stopAtStart();
            }
            DamageCollider.Update(location);
        }

        private void stopAtStart()
        {
            location = OriginalLocation;
            moving = false;
            movingBack = false;
            direction = ObjectConstants.zeroVector;
        }

        void setRectanglesForColliders()
        {
            int x, y, width, height;

            x = (int)location.X - (ObjectConstants.roomWidthInBlocks * ObjectConstants.scaledStdWidthHeight);
            y = (int)location.Y;
            width = ((ObjectConstants.roomWidthInBlocks + ObjectConstants.spikeTrapSpawnAdjustment) * ObjectConstants.scaledStdWidthHeight);
            height = ObjectConstants.scaledStdWidthHeight;
            RectangleXLeft = new Rectangle(x, y, width, height);

            x = (int)location.X;
            y = (int)location.Y;
            width = ((ObjectConstants.roomWidthInBlocks + ObjectConstants.spikeTrapSpawnAdjustment) * ObjectConstants.scaledStdWidthHeight);
            height = ObjectConstants.scaledStdWidthHeight;
            RectangleXRight = new Rectangle(x, y, width, height);

            x = (int)location.X;
            y = (int)location.Y;
            width = ObjectConstants.scaledStdWidthHeight;
            height = ((ObjectConstants.roomHeightInBlocks + ObjectConstants.spikeTrapSpawnAdjustment) * ObjectConstants.scaledStdWidthHeight);
            RectangleYDown = new Rectangle(x, y, width, height);

            x = (int)location.X;
            y = ((int)location.Y - (ObjectConstants.roomHeightInBlocks * ObjectConstants.scaledStdWidthHeight));
            width = ObjectConstants.scaledStdWidthHeight;
            height = ((ObjectConstants.roomHeightInBlocks + ObjectConstants.spikeTrapSpawnAdjustment) * ObjectConstants.scaledStdWidthHeight);
            RectangleYUp = new Rectangle(x, y, width, height);

            verticalDistBeforeStop = ((ObjectConstants.roomHeightInBlocks - ObjectConstants.oneInTwo) * ObjectConstants.scaledStdWidthHeight) / ObjectConstants.oneInTwo;
            horizontalDistBeforeStop = ((ObjectConstants.roomWidthInBlocks - ObjectConstants.oneInTwo) * ObjectConstants.scaledStdWidthHeight) / ObjectConstants.oneInTwo;
        }

        public void MoveRight()
        {
            if (direction == ObjectConstants.zeroVector)
            {
                direction = Vector2.UnitX;
                moving = true;
            }
        }

        public void MoveLeft()
        {
            if (direction == ObjectConstants.zeroVector)
            {
                direction = Vector2.UnitX * ObjectConstants.vectorFlip;
                moving = true;
            }
        }

        public void MoveUp()
        {
            if (direction == ObjectConstants.zeroVector)
            {
                direction = Vector2.UnitY * ObjectConstants.vectorFlip;
                moving = true;
            }
        }

        public void MoveDown()
        {
            if (direction == ObjectConstants.zeroVector)
            {
                direction = Vector2.UnitY;
                moving = true;
            }
        }

        public void TakeDamage(int damage)
        {
            //these do not take damage
        }
        public void SuddenKnockBack(Vector2 knockback)
        {
            location += knockback;
        }
        public void GradualKnockBack(Vector2 knockback)
        {
            //Though your blade crashes against the spike trap's steel, it does not yield 
            //(not implemented)
        }
        public void Freeze(float duration)
        {
            // Spiketrap does not get frozen
        }
        public void ChangeDirection()
        {
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
