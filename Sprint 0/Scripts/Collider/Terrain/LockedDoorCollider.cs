using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.GameState;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.Terrain;

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
            enemy.SuddenKnockBack(adjustmentForEnemy);
            
        }

        public void OnLinkCollision(Link link)
        {
            link.StopMoving();
            link.PushBackInstantlyBy(Overlap.DirectionToMoveObjectOff(this.hitbox, link.collider.CollisionRectangle));
            if (Inventory.Instance.MagicKey)
            {
                UnlockNeighborDoor();
                owner.SwapDoor();
            }
            else if (Inventory.Instance.Key > 0)
            {
                UnlockNeighborDoor();
                owner.SwapDoor();
                Inventory.Instance.Key--;
            }
        }

        private void UnlockNeighborDoor()
        {
            Room adjacentRoom = (Room) RoomManager.Instance.LoadRoom(owner.NextRoom);
            if (owner.GetType() == typeof(EastLockedSprite))
            {
                for (int i = 0; i < adjacentRoom.walls.Count; i++)
                {
                    if (adjacentRoom.walls[i].GetType() == typeof(WestLockedSprite))
                    {
                        System.Diagnostics.Debug.WriteLine("Owner is " + owner);
                        System.Diagnostics.Debug.WriteLine("Swapping" + adjacentRoom.walls[i] + " from " + owner.NextRoom);
                        adjacentRoom.walls[i].SwapDoor();
                    }
                }
            } else if (owner.GetType() == typeof(NorthLockedSprite))
            {
                for (int i = 0; i < adjacentRoom.walls.Count; i++)
                {
                    if (adjacentRoom.walls[i].GetType() == typeof(SouthLockedSprite))
                    {
                        System.Diagnostics.Debug.WriteLine("Owner is " + owner);
                        System.Diagnostics.Debug.WriteLine("Swapping" + adjacentRoom.walls[i] + " from " + owner.NextRoom);
                        adjacentRoom.walls[i].SwapDoor();
                    }
                }
            } else if (owner.GetType() == typeof(WestLockedSprite))
            {
                for (int i = 0; i < adjacentRoom.walls.Count; i++)
                {
                    if (adjacentRoom.walls[i].GetType() == typeof(EastLockedSprite))
                    {
                        System.Diagnostics.Debug.WriteLine("Owner is " + owner);
                        System.Diagnostics.Debug.WriteLine("Swapping" + adjacentRoom.walls[i] + " from " + owner.NextRoom);
                        adjacentRoom.walls[i].SwapDoor();
                    }
                }
            } else
            {
                for (int i = 0; i < adjacentRoom.walls.Count; i++)
                {
                    if (adjacentRoom.walls[i].GetType() == typeof(NorthLockedSprite))
                    {
                        System.Diagnostics.Debug.WriteLine("Owner is " + owner);
                        System.Diagnostics.Debug.WriteLine("Swapping" + adjacentRoom.walls[i] + " from " + owner.NextRoom);
                        adjacentRoom.walls[i].SwapDoor();
                    }
                }
            }
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
