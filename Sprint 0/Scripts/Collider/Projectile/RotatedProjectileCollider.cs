using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Projectile
{
    public class RotatedProjectileCollider : IProjectileCollider
    {
        private Rectangle _hitbox;
        private Vector2 positionOffset;

        public IProjectile Owner { get; }

        public Rectangle Hitbox { get => _hitbox; }

        public RotatedProjectileCollider(IProjectile owner, FacingDirection direction)
        {
            Owner = owner;
            if (owner is Arrow)
            {
                // No size variation between basic and silver arrows
                _hitbox = SpriteRectangles.basicArrowFrame;
            }
            else if (owner is SwordAttackHitbox)
            {
                _hitbox = ObjectConstants.swordAttackHitBoxSize;
            }
            _hitbox.Size *= new Point(ObjectConstants.scale);

            AdjustHitbox(direction);
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint() + positionOffset.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            // No collision response
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            enemy.TakeDamage(Owner.Damage);
            enemy.KnockBack(Overlap.DirectionToMoveObjectOff(_hitbox, enemy.Collider.Hitbox));
        }

        //----- Helper method for initializing the hitbox -----//

        private void AdjustHitbox(FacingDirection direction)
        {
            // Rotate hitbox pi/2 if needed, keep location at top-left corner
            switch (direction)
            {
                case FacingDirection.Right:
                    // No change
                    break;
                case FacingDirection.Up:
                    _hitbox = SwapDimensions(_hitbox);
                    positionOffset = ObjectConstants.degreeRotationCW90_v * _hitbox.Height;
                    break;
                case FacingDirection.Left:
                    positionOffset = ObjectConstants.degreesRotationCW180_v * _hitbox.Height;
                    break;
                case FacingDirection.Down:
                    _hitbox = SwapDimensions(_hitbox);
                    positionOffset = ObjectConstants.degreesRotationCW270_v * _hitbox.Height;
                    break;
                default:
                    break;
            }
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