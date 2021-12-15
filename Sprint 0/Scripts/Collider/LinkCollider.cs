using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Collider;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.GameState;
using Sprint_0.Scripts.Terrain;
using Sprint_0.GameStateHandlers;
using System.Threading.Tasks;

namespace Sprint_0.Scripts
{
    public class LinkCollider : IPlayerCollider
    {
        private Link _owner;
        private Rectangle hitbox;

        public Link Owner { get => _owner; }
        public Rectangle CollisionRectangle { get => hitbox; }


        public LinkCollider(Link owner, Rectangle initialPosition)
        {
            _owner = owner;
            hitbox = initialPosition;
        }


        public void OnBlockCollision(ITerrain block)
        {
            //Vector2 tryToPushBlockBack = Overlap.DirectionToMoveObjectOff(this.hitbox, block.Collider.collisionRectangle);
            //block.KnockBack(tryToPushBlockBack);
            //TODO: ITerrain needs to have a public collider and a push back method
        }

        public void OnEnemyCollision(IEnemy enemy)
        {
            //Link can't do anything here
        }

        public void OnItemCollision(IItem item)
        {
            switch (item.Type)
            {
                case ItemType.BoomerangItem:
                    if (!Inventory.Instance.HasWeapon(WeaponType.BasicBoomerang))
                    {
                        Inventory.Instance.AddWeapon(WeaponType.BasicBoomerang);
                    }
                    break;
                case ItemType.BowItem:
                    if (!Inventory.Instance.HasWeapon(WeaponType.Bow))
                    {
                        Inventory.Instance.AddWeapon(WeaponType.Bow);
                    }
                    break;
                case ItemType.BombItem:
                    Inventory.Instance.Bomb += ObjectConstants.bombsFromDrop;
                    break;
                case ItemType.BasicMapItem:
                    Inventory.Instance.Map = true;
                    break;
                case ItemType.Compass:
                    Inventory.Instance.Compass = true;
                    break;
                case ItemType.SmallHeartItem:
                    Link.Instance.HealBy(ObjectConstants.fullHeartHealthValue);
                    break;
                case ItemType.HeartContainer:
                    Link.Instance.MaxHealth += ObjectConstants.fullHeartHealthValue;
                    Link.Instance.HealBy(ObjectConstants.fullHeartHealthValue);
                    break;
                case ItemType.Fairy:
                    Link.Instance.HealBy(Link.Instance.MaxHealth);
                    break;
                case ItemType.BlueRuby:
                    Inventory.Instance.Rupee += ObjectConstants.inventoryBlueRupeeValue;
                    break;
                case ItemType.YellowRuby:
                    Inventory.Instance.Rupee += ObjectConstants.inventoryYellowRupeeValue;
                    break;
                case ItemType.BasicKey:
                    Inventory.Instance.Key += ObjectConstants.inventoryBasicKeyValue;
                    break;
                case ItemType.Clock:
                    RoomManager.Instance.CurrentRoom.FreezeEnemies();
                    break;
                case ItemType.MagicKey:
                    Inventory.Instance.MagicKey = true;
                    break;
                case ItemType.TriforcePiece:
                    TimeSpan seconds = SFXManager.Instance.triforcePiece.Duration;
                    GameStateManager.Instance.WonGame();
                    Task.Delay(seconds).ContinueWith(o => { GameStateManager.Instance.GameOver(); });
                    break;
                case ItemType.BasicArrowItem:
                    Inventory.Instance.BasicArrows = true;
                    break;
                case ItemType.SilverArrowItem:
                    Inventory.Instance.SilverArrows = true;
                    break;
                case ItemType.ShotgunItem:
                    if (!Inventory.Instance.HasWeapon(WeaponType.Shotgun))
                    {
                        Inventory.Instance.AddWeapon(WeaponType.Shotgun);
                    }
                    break;
                case ItemType.ShotgunShellItem:
                    Inventory.Instance.ShotgunShells += ObjectConstants.shotgunShellsPerPickUp;
                    break;
                case ItemType.BlueRing:
                    Inventory.Instance.BlueRing = true;
                    break;
            }
            item.Despawn();
        }

        public void OnProjectileCollision(IProjectile proj)
        {
            if (proj is Boomerang && proj.Friendly && ((Boomerang)proj).ReturnState)
            {
                proj.Despawn();
            }
        }

        public void Update(Vector2 location)
        {
            hitbox.Location = location.ToPoint();
        }

        //----- Helper method for different item type responses -----//

        private void RemoveMe()
        {

        }
    }
}
