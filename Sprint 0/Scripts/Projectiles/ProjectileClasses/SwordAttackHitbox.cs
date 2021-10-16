using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class SwordAttackHitbox : IProjectile
    {
        private ISprite sprite;
        private Vector2 pos;
        private bool delete = false;

        private double swingDurationSeconds = 0.2;

        public SwordAttackHitbox(Vector2 spawnLoc)
        {
            sprite = ProjectileSpriteFactory.Instance.CreateSwordAttackHitboxSprite();
            pos = spawnLoc;
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
            swingDurationSeconds -= gt.ElapsedGameTime.TotalSeconds;
            if (swingDurationSeconds <= 0)
            {
                delete = true;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, pos);
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
