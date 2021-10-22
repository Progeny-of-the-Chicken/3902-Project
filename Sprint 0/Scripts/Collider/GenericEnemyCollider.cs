﻿using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider
{
    class GenericEnemyCollider : IEnemyCollider
    {

        public IEnemy owner { get => _owner; }
        private IEnemy _owner;
        public Rectangle collisionRectangle { get => collisionRectangle; }
        private Rectangle rectangle;
        public GenericEnemyCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this._owner = owner;
            this.rectangle = collisionRectangle;
        }
        public void Update(Vector2 location)
        {
            rectangle.Location = location.ToPoint();
        }

        public void OnPlayerCollision(ILink player)
        {
            player.TakeDamage(owner.Damage);
        }

        public void OnProjectileCollision(FacingDirection collisionDirection, IProjectile projectile)
        {
            Vector2 direction = Vector2.Zero;
            //Move away from the collision
            switch (collisionDirection)
            {
                case FacingDirection.Right:
                    direction.X = -1;
                    break;
                case FacingDirection.Left:
                    direction.X = 1;
                    break;
                case FacingDirection.Down:
                    direction.Y = -1;
                    break;
                case FacingDirection.Up:
                    direction.Y += 1;
                    break;
                default:
                    break;
            }
            _owner.TakeDamage(projectile.damage);
            _owner.KnockBack(direction);
        }
    }
}
