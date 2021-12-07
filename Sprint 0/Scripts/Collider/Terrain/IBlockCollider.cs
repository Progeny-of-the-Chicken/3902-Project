using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Items;


namespace Sprint_0.Scripts.Collider.Terrain
{
    public interface IBlockCollider
    {
        public ITerrain Owner { get; }

        public Rectangle Hitbox { get; }

        void Update(Vector2 location);

        void OnProjectileCollision(IProjectile projectile);

        void OnEnemyCollision(IEnemy enemy);

        void OnLinkCollision(Link link);

        void OnItemCollision(IItem item);
    }
}
