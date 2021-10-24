using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles.ProjectileColliders;

namespace Sprint_0.Scripts.Projectiles
{
    public interface IProjectile
    {
        int Damage { get; }

        IProjectileCollider Collider { get; }

        void Update(GameTime gt);

        void Draw(SpriteBatch sb);

        bool CheckDelete();

        void Despawn();
    }
}
