using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Projectile
{
    public class RotatedProjectileCollider : IProjectileCollider
    {
        private Rectangle _hitbox;
        private Vector2 centerOffset;

        public IProjectile Owner { get; }

        public Rectangle Hitbox { get => _hitbox; }

        public RotatedProjectileCollider(IProjectile owner, FacingDirection direction)
        {
            Owner = owner;

            _hitbox = GetHitboxForOwner();
            AdjustHitbox(direction);
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint() - centerOffset.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            // No collision response
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            enemy.TakeDamage(Owner.Damage);
            enemy.GradualKnockBack(Overlap.DirectionToMoveObjectOff(_hitbox, enemy.Collider.Hitbox));
        }

        //----- Helper method for initializing the hitbox -----//

        private Rectangle GetHitboxForOwner()
        {
            Rectangle frame;
            if (Owner is Arrow)
            {
                frame = SpriteRectangles.basicArrowFrame;
            }
            else if (Owner is SwordAttackHitbox)
            {
                frame = ObjectConstants.swordAttackHitBoxSize;
            }
            else if (Owner is ShotgunPelletProjectile)
            {
                frame = SpriteRectangles.shotgunPelletProjectileFrame;
            }
            else
            {
                // Sword beam
                frame = SpriteRectangles.swordBeamFrames[ObjectConstants.firstFrame];
            }
            return frame;
        }

        private void AdjustHitbox(FacingDirection direction)
        {
            if (direction == FacingDirection.Up || direction == FacingDirection.Down)
            {
                SwapDimensions(_hitbox);
            }
            _hitbox.Size *= new Point(ObjectConstants.scale);
            centerOffset = _hitbox.Size.ToVector2() / ObjectConstants.oneInTwo;
        }

        private Vector2 GetCenterOfDimensions(Vector2 dimensions)
        {
            return dimensions / ObjectConstants.oneInTwo;
        }

        private Rectangle SwapDimensions(Rectangle rectangle)
        {
            Rectangle returnRectangle = rectangle;
            int temp = returnRectangle.Height;
            returnRectangle.Height = returnRectangle.Width;
            returnRectangle.Width = temp;
            return returnRectangle;
        }
    }
}