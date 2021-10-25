using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    public interface IEnemyCollider
    {
        public IEnemy Owner { get; }
        public Rectangle Hitbox { get; }

        public void Update(Vector2 location);

        public void OnPlayerCollision(Link player);

        public void OnProjectileCollision(IProjectile projectile);

        public void OnEnemyCollision(IEnemy enemy);
    }
}
