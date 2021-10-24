using System.Collections.Generic;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.CollisionHandlers
{
    public class PlayerItemCollisionHandler : ICollisionHandler
    {
        private ILink link;
        private HashSet<IItem> items;

        public PlayerItemCollisionHandler(ILink link, HashSet<IItem> items)
        {
            this.link = link;
            this.items = items;
        }

        public void Update()
        {
            foreach (IItem item in items)
            {
                // TODO: Compare link collider against item collider
                // link.Collider.Hitbox.Intersect(item.Collider.Hitbox);
            }
        }
    }
}
