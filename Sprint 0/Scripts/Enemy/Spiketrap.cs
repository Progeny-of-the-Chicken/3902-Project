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
        public IEnemyCollider Collider {get => DamageCollider;}
        public IEnemyCollider ColliderRight { get => DetectionColliderRight; }

        public IEnemyCollider ColliderLeft { get => DetectionColliderLeft; }

        public IEnemyCollider ColliderUp { get => DetectionColliderUp; }

        public IEnemyCollider ColliderDown { get => DetectionColliderDown; }

        Rectangle damageFrame = new Rectangle(164, 59, 16, 16);
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

        //
        //TODO: additional refactoring needed with magic numbers
        public Vector2 Location { get => location; }
        public int Damage { get => damage; }
        bool delete = false;

        Vector2 location;
        Vector2 direction;
        public SpikeTrap(Vector2 location)
        {
            //
            this.location = location;
            moveSpeed = 25 * ObjectConstants.scale;
            OriginalLocation = location;
            direction = Vector2.Zero;
            RectangleXLeft = new Rectangle((int)location.X - (12 * ObjectConstants.scaledStdWidthHeight), (int)location.Y, (13 * ObjectConstants.scaledStdWidthHeight), ObjectConstants.scaledStdWidthHeight);
            RectangleXRight = new Rectangle((int)location.X, (int)location.Y, (12 * ObjectConstants.scaledStdWidthHeight), ObjectConstants.scaledStdWidthHeight);
            RectangleYDown = new Rectangle((int)location.X, ((int)location.Y - (7 * ObjectConstants.standardWidthHeight * ObjectConstants.scale)), ObjectConstants.standardWidthHeight, (8 * ObjectConstants.standardWidthHeight * ObjectConstants.scale));
            RectangleYUp = new Rectangle((int)location.X, (int)location.Y, ObjectConstants.scaledStdWidthHeight, (7 * ObjectConstants.scaledStdWidthHeight));
            //RectangleX = new Rectangle((int)location.X - (12 * ObjectConstants.standardWidthHeight * ObjectConstants.scale), (int)location.Y, (25 * ObjectConstants.standardWidthHeight * ObjectConstants.scale), ObjectConstants.standardWidthHeight);
            //RectangleY = new Rectangle((int)location.X, ((int)location.Y - (7 * ObjectConstants.standardWidthHeight * ObjectConstants.scale)), ObjectConstants.standardWidthHeight, (15 * ObjectConstants.standardWidthHeight * ObjectConstants.scale));
            DamageCollider = new GenericEnemyCollider(this, new Rectangle((int)location.X, (int)location.Y, (SpriteRectangles.spikeTrapFrame.Width * ObjectConstants.scale), (SpriteRectangles.spikeTrapFrame.Height * ObjectConstants.scale)));
            //XDetectionCollider = new DetectionCollider(this, RectangleX);
            DetectionColliderRight = new DetectionColliderRight(this, RectangleXRight);
            DetectionColliderLeft = new DetectionColliderLeft(this, RectangleXLeft);
            //YDetectionCollider = new DetectionCollider(this, RectangleY);
            DetectionColliderUp = new DetectionColliderUp(this, RectangleYUp);
            DetectionColliderDown = new DetectionColliderDown(this, RectangleYDown);
            sprite = (SpikeTrapSprite)EnemySpriteFactory.Instance.CreateSpikeTrapSprite(SpriteRectangles.spikeTrapFrame);
            count = 0;
            back = false;
            //
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
                location += direction * (moveSpeed * 2) * (float)gt.ElapsedGameTime.TotalSeconds; //fix
                count++;
                if (count == 75)
                {
                    back = true;
                    count *= 2;
                }
            }
            else
            {
                location -= direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count--;
                if (count == 0)
                {
                    back = false;
                    direction = Vector2.Zero;
                }
            }
            DamageCollider.Update(location);
        }

        public void SetHasHit(Vector2 direction)
        {
            this.direction = direction;
            hasHit = true;
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
