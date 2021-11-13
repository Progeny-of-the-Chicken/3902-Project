using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;

namespace Sprint_0.Scripts.Collider.Terrain
{
    public class LockedDoorCollider : IWallCollider
    {
        private IWall owner;
        private Rectangle hitbox;

        public LockedDoorCollider(IWall owner, Rectangle hitbox)
        {
            this.owner = owner;
            this.hitbox = hitbox;
        }

        public IWall Owner { get => owner; }

        public Rectangle Hitbox { get => hitbox; }

        public void OnEnemyCollision(IEnemy enemy)
        {
            Vector2 adjustmentForEnemy = Overlap.DirectionToMoveObjectOff(this.hitbox, enemy.Collider.Hitbox);
            enemy.KnockBack(adjustmentForEnemy);

        }

        public void OnLinkCollision(Link link)
        {
            link.StopMoving();
            link.PushBackInstantlyBy(Overlap.DirectionToMoveObjectOff(this.hitbox, link.collider.CollisionRectangle));
            owner.SwapDoor();
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            if (projectile is Boomerang)
            {
                ((Boomerang)projectile).BounceOffWall();
            }
            else if (projectile is FireSpell)
            {
                ((FireSpell)projectile).linger = true;
            }
            else if (projectile is Bomb)
            {
                ((Bomb)projectile).MoveOutOfWall(Overlap.DirectionToMoveObjectOff(hitbox, projectile.Collider.Hitbox));
            }
            else
            {
                projectile.Despawn();
            }
        }

        public void Update(Vector2 location)
        {
            //All walls do not move
        }
    }
}
