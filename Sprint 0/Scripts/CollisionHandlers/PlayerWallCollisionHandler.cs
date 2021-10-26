using System.Collections.Generic;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.CollisionHandlers
{
    public class PlayerWallCollisionHandler : ICollisionHandler
    {
        private ILink link;
        private HashSet<IWall> walls;

        public PlayerWallCollisionHandler(ILink link, HashSet<IWall> walls)
        {
            this.link = link;
            this.walls = walls;
        }

        public void Update()
        {
            foreach (IWall wall in walls)
            {
                if (wall.Collider.Hitbox.Intersects(link.collider.CollisionRectangle))
                {
                    wall.Collider.OnLinkCollision((Link)link);
                }
            }
        }
    }
}