using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Projectiles.ProjectileColliders
{
    public interface IProjectileCollider
    {
        IProjectile Owner { get; }

        Rectangle Hitbox { get; }

        void Update(Vector2 location);

        void OnPlayerCollision(ILink link);

        void OnEnemyCollision(IEnemy enemy);

        void OnBlockCollision(ITerrain block);
    }
}