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
            RectangleXLeft = new Rectangle((int)location.X - (12 * ObjectConstants.standardWidthHeight * ObjectConstants.scale), (int)location.Y, (13 * ObjectConstants.standardWidthHeight * ObjectConstants.scale), ObjectConstants.standardWidthHeight * 2);
            RectangleXRight = new Rectangle((int)location.X, (int)location.Y, (12 * ObjectConstants.standardWidthHeight * ObjectConstants.scale), ObjectConstants.standardWidthHeight * 2);
            RectangleYDown = new Rectangle((int)location.X, ((int)location.Y - (7 * ObjectConstants.standardWidthHeight * ObjectConstants.scale)), ObjectConstants.standardWidthHeight * 2, (8 * ObjectConstants.standardWidthHeight * ObjectConstants.scale));
            RectangleYUp = new Rectangle((int)location.X, (int)location.Y, ObjectConstants.standardWidthHeight * 2, (7 * ObjectConstants.standardWidthHeight * ObjectConstants.scale));
            //RectangleX = new Rectangle((int)location.X - (12 * ObjectConstants.standardWidthHeight * ObjectConstants.scale), (int)location.Y, (25 * ObjectConstants.standardWidthHeight * ObjectConstants.scale), ObjectConstants.standardWidthHeight);
            //RectangleY = new Rectangle((int)location.X, ((int)location.Y - (7 * ObjectConstants.standardWidthHeight * ObjectConstants.scale)), ObjectConstants.standardWidthHeight, (15 * ObjectConstants.standardWidthHeight * ObjectConstants.scale));
            DamageCollider = new GenericEnemyCollider(this, new Rectangle((int)location.X, (int)location.Y , (int)(damageFrame.Width * ObjectConstants.scale), (int)(damageFrame.Height * ObjectConstants.scale)));
            //XDetectionCollider = new DetectionCollider(this, RectangleX);
            DetectionColliderRight = new DetectionColliderRight(this, RectangleXRight);
            DetectionColliderLeft = new DetectionColliderLeft(this, RectangleXLeft);
            //YDetectionCollider = new DetectionCollider(this, RectangleY);
            DetectionColliderUp = new DetectionColliderUp(this, RectangleYUp);
            DetectionColliderDown = new DetectionColliderDown(this, RectangleYDown);
            sprite = (SpikeTrapSprite)EnemySpriteFactory.Instance.CreateSpikeTrapSprite(ObjectConstants.scale, damageFrame);
            count = 0;
            back = false;
        }

        public void Update(GameTime gt)
        {
            if (hasHit == false)
            {
                Move(gt);
                sprite.Update(gt);
            }
        }

        public void Move(GameTime gt)
        {
            //move according to link's position
            if (back == false)
            {
                location += direction * (moveSpeed * 2) * (float)gt.ElapsedGameTime.TotalSeconds; //fix
                count++;
                if (count == 75)
                {
                    back = true;
                    count *= 2;
                }
            } else
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

        public void SetDirection(Vector2 direction)
        {
            this.direction = direction;
        }

        public void MoveRight()
        {
            direction = Vector2.UnitX;
        }

        public void MoveLeft()
        {
            direction = -Vector2.UnitX;
        }

        public void MoveUp()
        {
            direction = Vector2.UnitY;
        }

        public void MoveDown()
        {
            direction = -Vector2.UnitY;
        }

        public void SetHasHit()
        {
            hasHit = true;
        }

      //  public void SetOriginalPosition(GameTime gt)
       // {
       //     if (count > 5 && count > 0)
         //   {
          //      location -= direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
         //   } else
          //  {
          //      hasHit = false;
         //       direction = Vector2.Zero;
          //      count = 0;
         //   }
            
       // }


        public void TakeDamage(int damage)
        {
            //these do not take damage
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
