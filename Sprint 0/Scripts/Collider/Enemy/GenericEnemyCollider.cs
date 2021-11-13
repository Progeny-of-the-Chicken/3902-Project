using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Collider.Enemy
{
    class GenericEnemyCollider : IEnemyCollider
    {

        public IEnemy Owner { get => owner; }
        private IEnemy owner;
        public Rectangle Hitbox { get => hitbox; }
        private Rectangle hitbox;
        public GenericEnemyCollider(IEnemy owner, Rectangle collisionRectangle)
        {
            this.owner = owner;
            this.hitbox = collisionRectangle;
        }
        public void Update(Vector2 location)
        {
            hitbox.Location = location.ToPoint();
        }

        public void OnPlayerCollision(Link player)
        {
            if (player.CanBeAffectedByEnemy)
            {
                Vector2 pushBack = Overlap.DirectionToMoveObjectOff(this.hitbox, player.collider.CollisionRectangle);
                //playing it safe to avoid dividebyzero
                if (!pushBack.Equals(Vector2.Zero))
                {
                    pushBack.Normalize();
                    pushBack *= ObjectConstants.DefaultEnemyKnockback;
                }
                player.PushBackGentlyBy(pushBack);
                player.TakeDamage(Owner.Damage);
            }
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            if (projectile is Arrow)
            {
                projectile.Despawn();
            }
        }
    }
}
