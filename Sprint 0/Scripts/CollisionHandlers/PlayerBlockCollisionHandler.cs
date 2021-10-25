using System.Collections.Generic;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.CollisionHandlers
{
    public class PlayerBlockCollisionHandler : ICollisionHandler
    {
        private ILink link;
        private HashSet<ITerrain> blocks;

        public PlayerBlockCollisionHandler(ILink link, HashSet<ITerrain> blocks)
        {
            this.link = link;
            this.blocks = blocks;
        }

        public void Update()
        {
            foreach (ITerrain block in blocks)
            {
                if (block.Collider.Hitbox.Intersects(link.collider.CollisionRectangle))
                {
                    block.Collider.OnLinkCollision((Link)link);
                }
            }
        }
    }
}
