using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Projectiles.ProjectileColliders
{
    public interface IPlayerProjectileCollider : IProjectileCollider
    {
        void OnEnemyCollision(IEnemy enemy);
    }
}