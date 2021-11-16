using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;

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
        bool hasHit = false;
        int damage;
        int count;
        bool back;
        public Vector2 Location { get => location; }
        public int Damage { get => damage; }
        public Vector2 Position { get => location; }
        bool delete = false;

        Vector2 location;
        Vector2 direction;
        public SpikeTrap(Vector2 location)
        {
            this.location = location;
            moveSpeed = ObjectConstants.spikeTrapSpeed;
            OriginalLocation = location;
            direction = Vector2.Zero;
            RectangleXLeft = new Rectangle((int)location.X - (ObjectConstants.roomWidthInBlocks * ObjectConstants.scaledStdWidthHeight), (int)location.Y, (ObjectConstants.roomWidthInBlocks + ObjectConstants.spikeTrapSpawnAdjustment * ObjectConstants.scaledStdWidthHeight), ObjectConstants.scaledStdWidthHeight * ObjectConstants.doubleTheValue);
            RectangleXRight = new Rectangle((int)location.X, (int)location.Y, (ObjectConstants.roomWidthInBlocks * ObjectConstants.scaledStdWidthHeight), ObjectConstants.scaledStdWidthHeight * ObjectConstants.doubleTheValue);
            RectangleYDown = new Rectangle((int)location.X, ((int)location.Y - (ObjectConstants.roomHeightInBlocks * ObjectConstants.standardWidthHeight * ObjectConstants.scale)), ObjectConstants.standardWidthHeight * ObjectConstants.doubleTheValue, (ObjectConstants.roomHeightInBlocks + ObjectConstants.spikeTrapSpawnAdjustment * ObjectConstants.standardWidthHeight * ObjectConstants.scale));
            RectangleYUp = new Rectangle((int)location.X, (int)location.Y, ObjectConstants.scaledStdWidthHeight * ObjectConstants.doubleTheValue, (ObjectConstants.roomHeightInBlocks * ObjectConstants.scaledStdWidthHeight));
            DamageCollider = new GenericEnemyCollider(this, new Rectangle((int)location.X, (int)location.Y, (SpriteRectangles.spikeTrapFrame.Width * ObjectConstants.scale), (SpriteRectangles.spikeTrapFrame.Height * ObjectConstants.scale)));
            DetectionColliderRight = new DetectionColliderRight(this, RectangleXRight);
            DetectionColliderLeft = new DetectionColliderLeft(this, RectangleXLeft);
            DetectionColliderUp = new DetectionColliderUp(this, RectangleYUp);
            DetectionColliderDown = new DetectionColliderDown(this, RectangleYDown);
            count = ObjectConstants.counterInitialVal_int;
            back = false;
            sprite = (SpikeTrapSprite)EnemySpriteFactory.Instance.CreateSpikeTrapSprite();
        }

        public void Update(GameTime gt)
        {
            Move(gt);
            sprite.Update(gt);
        }

        void Move(GameTime gt)
        {
            if (back == false)
            {
                location += direction * (moveSpeed * ObjectConstants.doubleTheValue) * (float)gt.ElapsedGameTime.TotalSeconds; //fix
                count++;
                if (count == ObjectConstants.SpikeTrapWidthMovementTicks && direction.Y == ObjectConstants.zero_float)
                {
                    back = true;
                    count *= ObjectConstants.doubleTheValue;
                }
                else if (count == ObjectConstants.SpikeTrapHeightMovementTicks && direction.X == ObjectConstants.zero_float)
                {
                    back = true;
                    count *= ObjectConstants.doubleTheValue;
                }
            }
            else
            {
                location -= direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count--;
                if (count == ObjectConstants.counterInitialVal_int)
                {
                    back = false;
                    direction = Vector2.Zero;
                }
            }
            DamageCollider.Update(location);
        }

        public void SetDirection(Vector2 direction)
        {
            this.direction = direction;
        }

        public void MoveRight()
        {
            if (direction.X == ObjectConstants.zero_float && direction.Y == ObjectConstants.zero_float)
            {
                direction = Vector2.UnitX;

            }
        }

        public void MoveLeft()
        {
            if (direction.X == ObjectConstants.zero_float && direction.Y == ObjectConstants.zero_float)
            {
                direction = -Vector2.UnitX;
            }
        }

        public void MoveUp()
        {
            if (direction.X == ObjectConstants.zero_float && direction.Y == ObjectConstants.zero_float)
            {
                direction = Vector2.UnitY;
            }
        }

        public void MoveDown()
        {
            if (direction.X == ObjectConstants.zero_float && direction.Y == ObjectConstants.zero_float)
            {
                direction = -Vector2.UnitY;
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
