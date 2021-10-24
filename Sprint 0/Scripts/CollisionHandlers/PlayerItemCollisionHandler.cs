using System.Collections.Generic;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.CollisionHandlers
{
    public class PlayerItemCollisionHandler
    {
        private ILink link;
        private HashSet<IItem> items;
        private HashSet<IEnemy> enemies;

        public PlayerItemCollisionHandler(ILink link, HashSet<IItem> items, HashSet<IEnemy> enemies)
        {
            this.link = link;
            this.items = items;
            this.enemies = enemies;
        }

        public void Update()
        {
            foreach (IItem item in items)
            {
                // TODO: Compare link collider against item collider
                // link.Collider.Hitbox.Intersect(item.Collider.Hitbox);
            }
        }

        //----- Collision response methods -----//

        private void HandleGenericItemCollision(IItem item)
        {
            item.Despawn();
        }

        private void HandleClockCollision(IItem clock)
        {
            // TODO: Implement enemies freezing
            clock.Despawn();
        }
    }
}
