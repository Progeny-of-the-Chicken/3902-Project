using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Collider.Projectile;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class BlastZone : IProjectile
    {
        private IProjectileCollider collider;
        private Vector2 pos;
        private int blastZoneCounter = ObjectConstants.blastZoneCounter;
        private bool delete = false;
        private bool friendly = false;

        public bool Friendly { get => friendly; }

        public int Damage { get => ObjectConstants.basicSwordDamage; }

        public IProjectileCollider Collider { get => collider; }

        public BlastZone(Vector2 location)
        {
            pos = location;
            collider = ProjectileColliderFactory.Instance.CreateBlastZoneCollider(this);
            friendly = true;
        }

        public void Update(GameTime gameTime)
        {
            collider.Update(pos);
            if (blastZoneCounter <= 0)
            {
                delete = true;
            }
            blastZoneCounter--;
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
