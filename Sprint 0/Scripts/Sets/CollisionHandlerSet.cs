using System.Collections.Generic;
using Sprint_0.Scripts.CollisionHandlers;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.Sets
{
    public class CollisionHandlerSet
    {
        private HashSet<ICollisionHandler> collisionHandlers;

        public CollisionHandlerSet(ILink link, HashSet<IEnemy> enemies, HashSet<IItem> items, HashSet<IProjectile> projectiles, HashSet<ITerrain> blocks)
        {
            collisionHandlers = new HashSet<ICollisionHandler>();
            collisionHandlers.Add(new ProjectilePlayerCollisionHandler(projectiles, link));
            collisionHandlers.Add(new ProjectileEnemyCollisionHandler(projectiles, enemies));
            collisionHandlers.Add(new ProjectileBlockCollisionHandler(projectiles, blocks));
            collisionHandlers.Add(new PlayerItemCollisionHandler(link, items));
            collisionHandlers.Add(new PlayerEnemyCollisionHandler((Link) link, enemies));
            collisionHandlers.Add(new EnemyEnemyCollisionHandler(enemies));
        }

        public void Update()
        {
            foreach (ICollisionHandler collisionHandler in collisionHandlers)
            {
                collisionHandler.Update();
            }
        }
    }
}
