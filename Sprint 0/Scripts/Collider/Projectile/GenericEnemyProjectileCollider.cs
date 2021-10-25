﻿using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Projectile
{
    public class GenericEnemyProjectileCollider : IProjectileCollider
    {
        private Rectangle _hitbox;

        public IProjectile Owner { get; }

        public Rectangle Hitbox { get => _hitbox; }

        public GenericEnemyProjectileCollider(IProjectile owner)
        {
            Owner = owner;
            if (Owner is MagicProjectile)
            {
                // TODO: get dimensions from enemy sprite
                _hitbox = new Rectangle(0, 0, 8, 8);
            }
            _hitbox.Size *= new Point(ObjectConstants.scale);
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            // TODO: call Link knockback
            player.TakeDamage(Owner.Damage);
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            // No collision response
        }
    }
}