using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts
{
    public interface IPlayerCollider
    {
        public Link Owner { get; }
        public Rectangle CollisionRectangle { get; }

        public void Update(Vector2 location);

        public void OnBlockCollision(ITerrain block);

        public void OnItemCollision(IItem item);

        public void OnProjectileCollision(IProjectile proj);
    }
}
