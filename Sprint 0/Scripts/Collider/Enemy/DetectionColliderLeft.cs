using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class DetectionColliderLeft : IEnemyCollider
    {
        public IEnemy owner { get => owner; }
        private SpikeTrap _owner;
        public Rectangle collisionRectangle { get => rectangle; }
        private Rectangle rectangle;
        public DetectionColliderLeft(IEnemy owner, Rectangle collisionRectangle)
        {
            this._owner = (SpikeTrap)owner;
            this.rectangle = collisionRectangle;
        }
        public void Update(Vector2 location)
        {
            rectangle.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            //Rectangle intersect = Rectangle.Intersect(player.collider.CollisionRectangle, this.collisionRectangle);
            //Vector2 direction = Vector2.Zero;
            //if (intersect.Width >= intersect.Height)
            //{
            //  direction = Vector2.UnitX;
            //if (intersect.Location.X < _owner.Location.X)
            //{
            //        direction *= -1;
            //    }
            //}
            //else
            //{

            //    direction = Vector2.UnitY;
            //    if (intersect.Location.X < _owner.Location.Y)
            //    {
            //        direction *= -1;
            //    }
            //}

            //TODO: PLAYER MOVE DOWN
            _owner.MoveLeft();

        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            if (projectile is Arrow)
            {
                projectile.Despawn();
            }
        }
    }
}
