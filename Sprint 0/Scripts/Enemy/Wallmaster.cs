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
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    class Wallmaster : IEnemy
    {

        ISprite sprite;
        ISprite openSprite;
        ISprite closeSprite;

        IEnemyCollider DamageCollider;
        IEnemyCollider WallMDColliderRight;
        IEnemyCollider WallMDColliderLeft;
        IEnemyCollider WallMDColliderUp;
        IEnemyCollider WallMDColliderDown;
        public IEnemyCollider Collider { get => DamageCollider; }
        public IEnemyCollider WMDColliderRight { get => WallMDColliderRight; }

        public IEnemyCollider WMDColliderLeft { get => WallMDColliderLeft; }

        public IEnemyCollider WMDColliderUp { get => WallMDColliderUp; }

        public IEnemyCollider WMDColliderDown { get => WallMDColliderDown; }

        Rectangle openFrame = new Rectangle(392, 10, 18, 16);
        Rectangle closeFrame = new Rectangle(410, 11, 14, 16);
        Rectangle upFrame;
        Rectangle downFrame;
        Rectangle leftFrame;
        Rectangle rightFrame;

        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;
        public int Damage { get => _damage; }
        public Vector2 Position { get => location; }
        public bool CanBeAffectedByPlayer { get => true; }
        int _damage;
        int health = 3;
        const int knockbackDistance = 50;
        bool delete = false;
        bool grab = false;
        int count;

        const float moveTime = 1;
        float moveSpeed;
        float timeSinceMove = 0;
        int loc = 0;

        Vector2 location;
        Vector2 direction;

        Link grabbedLink;
        public Wallmaster(Vector2 location)
        {
            this.location = location;

            moveSpeed = ObjectConstants.WallMasterMoveSpeed;
            direction = ObjectConstants.LeftUnitVector;
            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            openSprite = (WallmasterOpenSprite)EnemySpriteFactory.Instance.CreateWallmasterOpenSprite();
            closeSprite = (WallmasterCloseSprite)EnemySpriteFactory.Instance.CreateWallmasterCloseSprite();

            sprite = openSprite;
            upFrame = new Rectangle((int)location.X, (int)location.Y - (2 * ObjectConstants.standardWidthHeight), ObjectConstants.standardWidthHeight, ObjectConstants.standardWidthHeight);
            downFrame = new Rectangle((int)location.X, (int)location.Y + (3 * ObjectConstants.standardWidthHeight), ObjectConstants.standardWidthHeight, ObjectConstants.standardWidthHeight);
            leftFrame = new Rectangle((int)location.X - (2 * ObjectConstants.standardWidthHeight), (int)location.Y, ObjectConstants.standardWidthHeight, ObjectConstants.standardWidthHeight);
            rightFrame = new Rectangle((int)location.X + (3 * ObjectConstants.standardWidthHeight), (int)location.Y, ObjectConstants.standardWidthHeight, ObjectConstants.standardWidthHeight);
            DamageCollider = new WallmasterEnemyCollider(this, new Rectangle(0, 0, (int)(openFrame.Width * ObjectConstants.scale), (int)(openFrame.Height * ObjectConstants.scale)));
            WallMDColliderDown = new WMDColliderDown(this, downFrame);
            WallMDColliderUp = new WMDColliderUp(this, upFrame);
            WallMDColliderRight = new WMDColliderRight(this, rightFrame);
            WallMDColliderLeft = new WMDColliderLeft(this, leftFrame);
            count = 0;
        }

        public void Update(GameTime gt)
        {
            if (grab == false)
            {
                SearchMove(gt);
                sprite.Update(gt);
                DamageCollider.Update(location);
            }
            else
            {
                yeetLink();
                sprite.Update(gt);
            }
        }

        void SearchMove(GameTime gt)
        {
            if (loc == 1)
            {
                MoveUpWM(gt);
            }
            else if (loc == 2)
            {
                MoveDownWM(gt);
            }
            else if (loc == 3)
            {
                MoveLeftWM(gt);
            }
            else if (loc == 4)
            {
                MoveRightWM(gt);
            }

        }

        void MoveRightWM(GameTime gt)
        {
            if (count < 40)
            {
                direction = -Vector2.UnitX;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            }
            else if (count >= 40 && count < 115)
            {
                direction = Vector2.UnitY;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            }
            else if (count >= 115 && count < 140)
            {
                direction = Vector2.UnitX;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            }
            else if (count >= 140)
            {
                direction = Vector2.Zero;
            }

        }

        void MoveLeftWM(GameTime gt)
        {
            if (count < 40)
            {
                direction = Vector2.UnitX;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            }
            else if (count >= 40 && count < 115)
            {
                direction = Vector2.UnitY;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            }
            else if (count >= 115 && count < 140)
            {
                direction = -Vector2.UnitX;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            }
            else if (count >= 140)
            {
                direction = Vector2.Zero;
            }

        }

        void MoveUpWM(GameTime gt)
        {
            if (count < 40)
            {
                direction = Vector2.UnitY;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            }
            else if (count >= 40 && count < 115)
            {
                direction = Vector2.UnitX;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            }
            else if (count >= 115 && count < 140)
            {
                direction = -Vector2.UnitY;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            }
            else if (count >= 140)
            {
                direction = Vector2.Zero;
            }

        }

        void MoveDownWM(GameTime gt)
        {
            if (count < 40)
            {
                direction = -Vector2.UnitY;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            }
            else if (count >= 40 && count < 115)
            {
                direction = Vector2.UnitX;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            }
            else if (count >= 115 && count < 140)
            {
                direction = Vector2.UnitY;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            }
            else if (count >= 140)
            {
                direction = Vector2.Zero;
            }

        }

        void yeetLink()
        {
            if (location.X != 0)
            {
                --location.X;
                grabbedLink.ResetPosition(location);
            }
            else
            {

                RoomManager.Instance.SwitchToRoom("Room25");
                grabbedLink.UnSuspend();
            }
        }

        public void ChangeDir(int dir)
        {
            loc = dir;
        }

        public void GrabLink(Link player)
        {
            //todo 
            //change to closed hand, move link
            sprite = closeSprite;
            grab = true;
            grabbedLink = player;
            //change to first dungeon room
        }

        public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= ObjectConstants.zero)
            {
                ObjectsFromObjectsFactory.Instance.CreateStaticEffect(location, Effect.EffectType.Pop);
                delete = true;
                SFXManager.Instance.PlayEnemyDeath();
            }
            SFXManager.Instance.PlayEnemyHit();
        }
        public void KnockBack(Vector2 knockback)
        {
            location += knockback * knockbackDistance;
        }
        public void Freeze(float duration)
        {
            // TODO: Implement
        }
        public bool CheckDelete()
        {
            return delete;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }

        public void SuddenKnockBack(Vector2 knockback)
        {
           //none
        }

        public void GradualKnockBack(Vector2 knockback)
        {
            //none
        }
    }
}