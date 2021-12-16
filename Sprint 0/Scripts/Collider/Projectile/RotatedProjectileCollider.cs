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
        private Vector2 swordHitboxLocationOffset = ObjectConstants.zeroVector;

        public IProjectile Owner { get; }

        public Rectangle Hitbox { get => _hitbox; }

        public RotatedProjectileCollider(IProjectile owner, FacingDirection direction)
        {
            Owner = owner;

            _hitbox = GetHitboxForOwner();
            AdjustHitbox(direction);
            if (Owner is SwordAttackHitbox)
            {
                SetSwordHitboxLocationOffset(direction);
            }
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint() - centerOffset.ToPoint() + swordHitboxLocationOffset.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            // No collision response
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            if (enemy is Darknut && enemy.CanBeAffectedByPlayer)
            {
                ((Darknut)enemy).TryTakeDamage(Owner.Damage, Overlap.DirectionToMoveObjectOff(_hitbox, enemy.Collider.Hitbox));
            }
            else if (enemy is MegaDarknut && enemy.CanBeAffectedByPlayer)
            {
                ((MegaDarknut)enemy).TryTakeDamage(Owner.Damage, Overlap.DirectionToMoveObjectOff(_hitbox, enemy.Collider.Hitbox));
            }
            else if (enemy.CanBeAffectedByPlayer)
            {
                enemy.GradualKnockBack(Overlap.DirectionToMoveObjectOff(_hitbox, enemy.Collider.Hitbox));
                enemy.TakeDamage(Owner.Damage);
            }
            else if (Owner is ShotgunPelletProjectile)
            {
                enemy.TakeDamage(Owner.Damage);
            }
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

        private Rectangle SwapDimensions(Rectangle rectangle)
        {
            Rectangle returnRectangle = rectangle;
            int temp = returnRectangle.Height;
            returnRectangle.Height = returnRectangle.Width;
            returnRectangle.Width = temp;
            return returnRectangle;
        }

        private void SetSwordHitboxLocationOffset(FacingDirection direction)
        {
            if (direction == FacingDirection.Up)
            {
                swordHitboxLocationOffset = ObjectConstants.UpUnitVector * ObjectConstants.swordHitboxLength * ObjectConstants.scale;
            }
            else if (direction == FacingDirection.Left)
            {
                swordHitboxLocationOffset = ObjectConstants.LeftUnitVector * ObjectConstants.swordHitboxLength * ObjectConstants.scale;
            }
        }
    }
}