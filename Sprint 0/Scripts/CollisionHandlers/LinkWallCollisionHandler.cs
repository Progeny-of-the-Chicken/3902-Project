using System.Collections.Generic;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.CollisionHandlers
{
    public class LinkWallCollisionHandler : ICollisionHandler
    {
        private Link link;
        private HashSet<IWall> walls;

        public LinkWallCollisionHandler(Link link, HashSet<IWall> walls)
        {
            this.link = link;
            this.walls = walls;
        }

        public void Update()
        {
            foreach (IWall wall in walls)
            {
                //if (wall.Collider.Hitbox.Intersects(link.Position))
            }
        }
    }
}
