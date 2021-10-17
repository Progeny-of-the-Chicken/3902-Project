using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_0.Scripts.Enemy
{
    interface IEnemyCollider
    {
        public IEnemy owner { get; }
        public Rectangle collisionRectangle { get; }

        public void Update(Vector2 location);

        public void OnPlayerCollision(ILink player);

        public void OnProjectileCollision(FacingDirection direction, IProjectile projectile);
    }
}
