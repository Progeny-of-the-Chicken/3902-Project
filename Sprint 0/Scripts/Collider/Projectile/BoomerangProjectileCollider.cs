using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Projectile
{
    public class BoomerangProjectileCollider : IProjectileCollider
    {
        private Rectangle _hitbox;

        public IProjectile Owner { get; }

        public Rectangle Hitbox { get => _hitbox; }

        public BoomerangProjectileCollider(IProjectile owner)
        {
            this.Owner = owner;
            // No size variation between basic and magical boomerangs
            _hitbox = SpriteRectangles.basicBoomerangFrames[ObjectConstants.firstFrame];
            _hitbox.Size *= new Point(ObjectConstants.scale);
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link link)
        {
            if (!Owner.Friendly)
            {
                link.TakeDamage(Owner.Damage);
                link.PushBackGentlyBy(Overlap.DirectionToMoveObjectOff(link.collider.CollisionRectangle, _hitbox));
                ((Boomerang)Owner).BounceOffWall();
            }
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            if (Owner.Friendly)
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
                ((Boomerang)Owner).BounceOffWall();
            }
            else if (!Owner.Friendly && ((Boomerang)Owner).ReturnState && ((Boomerang)Owner).EnemyOwner is Goriya)
            {
                ((Goriya)((Boomerang)Owner).EnemyOwner).BoomerangCaught = true;
            }
        }
    }
}
