using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Collider;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Projectiles.ProjectileClasses;
using Sprint_0.Scripts.GameState;

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
                    Inventory.Instance.Weapons.Add(WeaponType.BasicBoomerang);
                    break;
                case ItemType.BowItem:
                    Inventory.Instance.Weapons.Add(WeaponType.Bow);
                    break;
                case ItemType.BombItem:
                    // TODO: Add bombs to inventory
                    break;
                case ItemType.BasicMapItem:
                    Inventory.Instance.Map = true;
                    break;
                case ItemType.Compass:
                    Inventory.Instance.Compass = true;
                    break;
                // TODO: Add more cases for remaining items pertaining to HUD
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
