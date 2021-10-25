using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Projectile
{
    public interface IProjectileCollider
    {
        IProjectile Owner { get; }

        Rectangle Hitbox { get; }

        void Update(Vector2 location);

        void OnPlayerCollision(Link link);

        void OnEnemyCollision(IEnemy enemy);
    }
}