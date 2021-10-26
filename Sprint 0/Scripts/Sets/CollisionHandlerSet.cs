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

        public CollisionHandlerSet(ILink link, HashSet<IEnemy> enemies, HashSet<IItem> items, HashSet<IProjectile> projectiles, HashSet<ITerrain> blocks, HashSet<IWall> walls)
        {
            collisionHandlers = new HashSet<ICollisionHandler>();
            collisionHandlers.Add(new ProjectilePlayerCollisionHandler(projectiles, link));
            collisionHandlers.Add(new ProjectileEnemyCollisionHandler(projectiles, enemies));
            collisionHandlers.Add(new ProjectileBlockCollisionHandler(projectiles, blocks));
            collisionHandlers.Add(new PlayerItemCollisionHandler(link, items));
            collisionHandlers.Add(new PlayerBlockCollisionHandler(link, blocks));
            collisionHandlers.Add(new EnemyBlockCollisionHandler(enemies, blocks));
            collisionHandlers.Add(new ProjectileWallCollisionHandler(projectiles, walls));
            collisionHandlers.Add(new EnemyWallCollisionHandler(enemies, walls));
            collisionHandlers.Add(new PlayerWallCollisionHandler(link, walls));
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
