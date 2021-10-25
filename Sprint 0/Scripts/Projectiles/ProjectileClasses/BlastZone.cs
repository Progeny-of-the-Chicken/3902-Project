using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Collider.Projectile;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class BlastZone : IProjectile
    {
        private IProjectileCollider collider;
        private bool delete = false;
        private bool friendly = false;

        public bool Friendly { get => friendly; }

        public int Damage { get => ObjectConstants.basicSwordDamage; }

        public IProjectileCollider Collider { get => collider; }

        public BlastZone(Vector2 location)
        {
            collider = new BlastZoneProjectileCollider(this);
            friendly = true;
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
