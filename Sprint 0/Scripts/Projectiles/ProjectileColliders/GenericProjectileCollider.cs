using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Projectiles.ProjectileColliders
{
    public class GenericProjectileCollider : IProjectileCollider
    {
        private Rectangle _hitbox;

        public IProjectile Owner { get; }

        public Rectangle Hitbox { get => _hitbox; }

        public GenericProjectileCollider(IProjectile owner)
        {
            Owner = owner;
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint();
        }
    }
}
