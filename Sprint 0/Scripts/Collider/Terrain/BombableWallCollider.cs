using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;

namespace Sprint_0.Scripts.Collider.Terrain
{
    public class BombableWallCollider : IWallCollider
    {
        private IWall owner;
        private Rectangle hitbox;

        public BombableWallCollider(IWall owner, Rectangle hitbox)
        {
            this.owner = owner;
            this.hitbox = hitbox;
        }

        public IWall Owner { get => owner; }

        public Rectangle Hitbox { get => hitbox; }

        public void OnEnemyCollision(IEnemy enemy)
        {
            Vector2 adjustmentForEnemy = Overlap.DirectionToMoveObjectOff(this.hitbox, enemy.Collider.collisionRectangle);
            enemy.KnockBack(adjustmentForEnemy);
            
        }

        public void OnLinkCollision(Link link)
        {
            //Vector2 adjustmentForEnemy = Overlap.DirectionToMoveObjectOff(this.hitbox, link.Collider.collisionRectangle); TODO: get links collider to find his position
            //link.(adjustmentForEnemy); TODO: update links position
            link.StopMoving();
        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            System.Diagnostics.Debug.WriteLine(projectile);
            if (projectile is BlastZone)
            {
                owner.SwapDoor();
            }

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
               //((Bomb)projectile).MoveOutOfWall(Overlap.DirectionToMoveObjectOff(hitbox, projectile.Collider.Hitbox));
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
