using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles.ProjectileColliders;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class SwordAttackHitbox : IProjectile
    {
        private Vector2 pos;
        private IProjectileCollider collider;
        private bool delete = false;

        private int swordCounter = ObjectConstants.swordHitboxCounter;

        public int Damage { get => ObjectConstants.basicSwordDamage; }

        public IProjectileCollider Collider { get => collider; }

        public SwordAttackHitbox(Vector2 spawnLoc, FacingDirection direction)
        {
            pos = spawnLoc;
            collider = new RotatedProjectileCollider(this, direction);
        }

        public void Update(GameTime gt)
        {
            collider.Update(pos);
            swordCounter--;
            if (swordCounter <= 0)
            {
                delete = true;
            }
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
