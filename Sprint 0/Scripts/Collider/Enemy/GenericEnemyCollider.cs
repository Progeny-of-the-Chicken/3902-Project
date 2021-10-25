using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class GenericEnemyCollider : IEnemyCollider
    {

        public IEnemy Owner { get => owner; }
        private IEnemy owner;
        public Rectangle Hitbox { get => hitbox; }
        private Rectangle hitbox;

        private const int knockBack = 50;
        public GenericEnemyCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this.owner = owner;
            this.hitbox = collisionRectangle;
        }
        public void Update(Vector2 location)
        {
            hitbox.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            player.TakeDamage(Owner.Damage);

            Vector2 pushBack = Overlap.DirectionToMoveObjectOff(this.hitbox, player.collider.CollisionRectangle);
            player.PushBackBy(pushBack);
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
