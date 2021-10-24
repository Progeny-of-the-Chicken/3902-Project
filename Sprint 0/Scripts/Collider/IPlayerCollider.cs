using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts
{
    public interface IPlayerCollider
    {
        public Link owner { get; }
        public Rectangle collisionRectangle { get; }

        public void Update(Vector2 location);

        public void onBlockCollision(ITerrain block);

        public void onItemCollision(IItem item);
    }
}
