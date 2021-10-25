using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class NPCCollider : IEnemyCollider
    {
        IEnemy _owner;
        Rectangle rectangle;
        public IEnemy owner => throw new NotImplementedException();

        public Rectangle collisionRectangle => throw new NotImplementedException();

        public NPCCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this._owner = owner;
            this.rectangle = collisionRectangle;
        }
        public void OnPlayerCollision(Link player, Rectangle overlap)
        {
            Vector2 pushBack = Vector2.Zero;

            //Collided on left or right
            if(overlap.Width > overlap.Height)
            {
                //Collided on the left, so push right
                if(overlap.X == rectangle.X)
                {
                    pushBack.X = overlap.Width;
                }
                //Collided on the right, so push left
                else
                {
                    pushBack.X = -overlap.Width;
                }
            }
            else
            {
                //Collided on the top, so push down
                if(overlap.Y == rectangle.Y)
                {
                    pushBack.Y = overlap.Height;
                }
                //Collided on the bottom, so push up
                else
                {
                    pushBack.Y = -overlap.Height;
                }
            }
            player.BounceBackInDirection(pushBack);
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            //can implement ability to counterattack, however that's low on our priorities for now
        }

        public void Update(Vector2 location)
        {
            //unused
        }
    }
}
