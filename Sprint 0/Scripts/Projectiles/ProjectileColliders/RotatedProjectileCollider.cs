using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Projectiles.ProjectileColliders
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
                _hitbox = SpriteRectangles.basicArrowFrame;
            }
            else if (owner is SwordAttackHitbox)
            {
                _hitbox = new Rectangle(0, 0, ObjectConstants.swordHitboxLength, ObjectConstants.swordHitboxWidth);
            }
            _hitbox.Size *= new Point(ObjectConstants.scale);

            AdjustHitbox(direction);
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint() + positionOffset.ToPoint();
        }

        public void OnPlayerCollision(ILink player)
        {
            // TODO: call Link knockback, reduce health by owner damage
            Owner.Despawn();
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            // TODO: call Enemy knockback, reduce health by owner damage
            Owner.Despawn();
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
                    positionOffset = new Vector2(0, -1 * _hitbox.Height);
                    break;
                case FacingDirection.Left:
                    positionOffset = new Vector2(-1 * _hitbox.Width, -1 * _hitbox.Height);
                    break;
                case FacingDirection.Down:
                    _hitbox = SwapDimensions(_hitbox);
                    positionOffset = new Vector2(-1 * _hitbox.Width, 0);
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