using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles.ProjectileColliders;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class BlastZone : IProjectile
    {
        private IProjectileCollider collider;
        private bool delete = false;

        public int Damage { get => ObjectConstants.basicSwordDamage; }

        public IProjectileCollider Collider { get => collider; }

        public BlastZone(Vector2 location, FacingDirection direction)
        {
            // TODO: Add collider
        }

        public void Update(GameTime gameTime)
        {
            delete = true;
        }

        public void Draw(SpriteBatch sb)
        {
            // Transparent, no drawing needed
        }

        public bool CheckDelete()
        {
            return delete;
        }

        public void Despawn()
        {
            // Should never need to be called
            delete = true;
        }
    }
}
