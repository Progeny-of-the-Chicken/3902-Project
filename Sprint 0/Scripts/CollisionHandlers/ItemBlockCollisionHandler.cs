using System.Collections.Generic;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.CollisionHandlers
{
    public class ItemBlockCollisionHandler : ICollisionHandler
    {
        private HashSet<IItem> items;
        private HashSet<ITerrain> blocks;


        public ItemBlockCollisionHandler(HashSet<IItem> items, HashSet<ITerrain> blocks)
        {
            this.items = items;
            this.blocks = blocks;
        }

        public void Update()
        {
            foreach (IItem items in items)
            {
                foreach (ITerrain block in blocks)
                {
                    if (block.Collider.Hitbox.Intersects(items.Collider.Hitbox))
                    {
                        block.Collider.OnItemCollision(items);
                    }
                }
            }
        }
    }
}