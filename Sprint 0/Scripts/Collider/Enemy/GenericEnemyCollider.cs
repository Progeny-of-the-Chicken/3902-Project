using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class GenericEnemyCollider : IEnemyCollider
    {

        public IEnemy owner { get => _owner; }
        private IEnemy _owner;
        public Rectangle collisionRectangle { get => collisionRectangle; }
        private Rectangle rectangle;

        private const int knockBack = 50;
        public GenericEnemyCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this._owner = owner;
            this.rectangle = collisionRectangle;
        }
        public void Update(Vector2 location)
        {
            rectangle.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player, Rectangle overlap)
        {
            player.TakeDamage(owner.Damage);
            Vector2 pushBack = Vector2.Zero;

            //Collided on left or right
            if (overlap.Width > overlap.Height)
            {
                //Collided on the left, so push right
                if (overlap.X == rectangle.X)
                {
                    pushBack.X = knockBack;
                }
                //Collided on the right, so push left
                else
                {
                    pushBack.X = -knockBack;
                }
            }
            else
            {
                //Collided on the top, so push down
                if (overlap.Y == rectangle.Y)
                {
                    pushBack.Y = knockBack;
                }
                //Collided on the bottom, so push up
                else
                {
                    pushBack.Y = -knockBack;
                }
            }
            player.BounceBackInDirection(pushBack);
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            projectile.Despawn();
        }
    }
}
