using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class DodongoDetectionCollider : IEnemyCollider
    {
        public IEnemy Owner { get => owner; }
        private Dodongo owner;
        public Rectangle Hitbox { get => rectangle; }
        private Rectangle rectangle;
        private Vector2 location;
        public DodongoDetectionCollider(Dodongo owner, Rectangle collisionRectangle)
        {
            this.owner = owner;
            this.rectangle = collisionRectangle;
            location = Vector2.Zero;
        }
        public void Update(Vector2 location)
        {
            //Left rectangle update
            if(this.location.X > location.X)
                rectangle = new Rectangle(0, (int)location.Y, (int)location.X, ObjectConstants.scaledStdWidthHeight);
            else
                rectangle = new Rectangle((location + ObjectConstants.RightUnitVector * ObjectConstants.scaledStdWidthHeight).ToPoint(), new Point(ObjectConstants.roomWidth, ObjectConstants.scaledStdWidthHeight));

            this.location = location;
        }

        public void OnPlayerCollision(Link player)
        {
            //unused
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            Bomb bomb = projectile as Bomb;
            if(bomb != null)
            {
                bomb.Despawn();
                owner.GradualKnockBack(Vector2.Zero);
            }
        }
    }
}
