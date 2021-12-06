using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class ChaseDetectionCollider : IEnemyCollider
    {
        public IEnemy Owner { get => owner; }
        private IEnemy owner;
        public Rectangle Hitbox { get => rectangle; }
        private Rectangle rectangle;
        private Vector2 location;
        public ChaseDetectionCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this.owner = owner;
            this.rectangle = collisionRectangle;
            location = Vector2.Zero;
        }
        public void Update(Vector2 location)
        {
            //Left rectangle update
            if(this.location.X > location.X)
                rectangle = new Rectangle(0, (int)location.Y, (int)location.X, Hitbox.Height);
            else
                rectangle = new Rectangle((location + ObjectConstants.RightUnitVector * ObjectConstants.scaledStdWidthHeight).ToPoint(), new Point(ObjectConstants.roomWidth, ObjectConstants.scaledStdWidthHeight));

            this.location = location;
        }

        public void OnPlayerCollision(Link player)
        {
            if (owner is Rope)
            {
                ((Rope)owner).ChaseLink();
            }
            else if (owner is MegaDarknut)
            {
                ((MegaDarknut)owner).ChaseLink();
            }
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            //None
        }
    }
}
