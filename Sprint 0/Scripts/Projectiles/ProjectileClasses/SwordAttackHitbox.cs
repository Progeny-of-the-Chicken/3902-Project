using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Collider.Projectile;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class SwordAttackHitbox : IProjectile
    {
        private Vector2 pos;
        private IProjectileCollider collider;
        private bool delete = false;
        private bool friendly = false;

        private int swordCounter = ObjectConstants.swordHitboxCounter;

        public bool Friendly { get => friendly; }

        public int Damage { get => ObjectConstants.basicSwordDamage; }

        public IProjectileCollider Collider { get => collider; }

        public SwordAttackHitbox(Vector2 spawnLoc, FacingDirection direction)
        {
            pos = spawnLoc;
            collider = ProjectileColliderFactory.Instance.CreateSwordAttackHitboxCollider(this, direction);
            friendly = true;
            SFXManager.Instance.PlaySwordSlash();
        }

        public void Update(GameTime gt)
        {
            collider.Update(pos);
            swordCounter--;
            if (swordCounter <= ObjectConstants.counterInitialVal_int)
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
