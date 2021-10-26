using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Terrain;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;


namespace Sprint_0.Scripts.Collider.Enemy
{
    class WallmasterEnemyCollider : IEnemyCollider
    {
        public IEnemy Owner { get => owner; }
        private Wallmaster owner;
        public Rectangle Hitbox { get => rectangle; }
        private Rectangle rectangle;
        public WallmasterEnemyCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this.owner = (Wallmaster)owner;
            this.rectangle = collisionRectangle;
        }
        public void Update(Vector2 location)
        {
            rectangle.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            player.Suspend();
            owner.GrabLink(player);
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

