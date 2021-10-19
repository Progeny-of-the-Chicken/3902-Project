using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class SwordAttackHitbox : IProjectile
    {
        private Rectangle frame;
        private bool delete = false;

        private int swordCounter = 17;

        public SwordAttackHitbox(Vector2 spawnLoc, FacingDirection direction)
        {
            if ((direction == FacingDirection.Left) || (direction == FacingDirection.Right))
            {
                frame = new Rectangle((int)spawnLoc.X, (int)spawnLoc.Y, 11, 3);
            }
            else
            {
                frame = new Rectangle((int)spawnLoc.X, (int)spawnLoc.Y, 3, 11);
            }
        }

        public void Update(GameTime gt)
        {
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
