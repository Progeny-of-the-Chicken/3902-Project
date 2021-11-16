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
        bool grab = false;
        int count;

        const float moveTime = 1;
        float moveSpeed;
        float timeSinceMove = 0;

        Vector2 location;
        Vector2 direction;

        Link grabbedLink; 
        public Wallmaster(Vector2 location)
        {
            this.location = location;
            moveSpeed = 25 * ObjectConstants.scale;
            direction = Vector2.Zero;
            random = new byte[2];
            openSprite = (WallmasterOpenSprite)EnemySpriteFactory.Instance.CreateWallmasterOpenSprite(ObjectConstants.scale, openFrame);
            closeSprite = (WallmasterCloseSprite)EnemySpriteFactory.Instance.CreateWallmasterCloseSprite(ObjectConstants.scale, openFrame);
            sprite = openSprite;
            collider = new GenericEnemyCollider(this, new Rectangle(0, 0, (int)(openFrame.Width * ObjectConstants.scale), (int)(openFrame.Height * ObjectConstants.scale)));
            count = 0;
        }

        public void Update(GameTime gt)
        {
            //if (grab == false)
           // {
                SearchMove(gt);
                sprite.Update(gt);
                collider.Update(location);
            //} else
            //{
             //   yeetLink();
           //     sprite.Update(gt);
           // }
        }

        void SearchMove(GameTime gt)
        {
            if (count < 20)
            {
                direction = -Vector2.UnitY;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            } else if (count >= 20 && count < 75)
            {
                direction = Vector2.UnitX;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            } else if (count >= 75 && count < 95)
            {
                direction = Vector2.UnitY;
                location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
                count++;
            } else if (count >= 95)
            {
                direction = Vector2.Zero;
                count = 0;
            }

        }

        void yeetLink()
        {
            if (location.X != 0)
            {
                --location.X;
                grabbedLink.ResetPosition(location);
            } else
            {

                RoomManager.Instance.SwitchToRoom("Room25");
                grabbedLink.UnSuspend();
            }
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