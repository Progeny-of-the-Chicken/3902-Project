using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class BlastZone : IProjectile
    {
        private Rectangle frame;
        private bool delete = false;

        public int damage { get => ObjectConstants.basicSwordDamage; }

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
