using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class SwordAttackHitbox : IProjectile
    {
        private Rectangle frame;
        private bool delete = false;

        private int swordCounter = ObjectConstants.swordHitboxCounter;

        public SwordAttackHitbox(Vector2 spawnLoc, FacingDirection direction)
        {
            if ((direction == FacingDirection.Left) || (direction == FacingDirection.Right))
            {
                frame = new Rectangle((int)spawnLoc.X, (int)spawnLoc.Y, ObjectConstants.swordHitboxLength * ObjectConstants.scale, ObjectConstants.swordHitboxWidth * ObjectConstants.scale);
            }
            else
            {
                frame = new Rectangle((int)spawnLoc.X, (int)spawnLoc.Y, ObjectConstants.swordHitboxWidth * ObjectConstants.scale, ObjectConstants.swordHitboxLength * ObjectConstants.scale);
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
