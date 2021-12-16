using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class DetectionColliderDown : IEnemyCollider
    {
        public IEnemy Owner { get => Owner; }
        private SpikeTrap _owner;
        public Rectangle Hitbox { get => rectangle; }
        private Rectangle rectangle;
        public DetectionColliderDown(IEnemy owner, Rectangle Hitbox)
        {
            this._owner = (SpikeTrap)owner;
            this.rectangle = Hitbox;
        }
        public void Update(Vector2 location)
        {
            // rectangle.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            _owner.MoveDown();

        }

        public void OnProjectileCollision(IProjectile projectile)
        {
        }
    }
}
