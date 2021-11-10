using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class SpikeTrapCollider : IEnemyCollider
    {

        public IEnemy owner { get => owner; }
        private SpikeTrap _owner;
        public Rectangle collisionRectangle { get => rectangle; }
        private Rectangle rectangle;
        public SpikeTrapCollider(IEnemy owner, Rectangle collisionRectangle)
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
            player.TakeDamage(owner.Damage);
            _owner.SetHasHit();
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
