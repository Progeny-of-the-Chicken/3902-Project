using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Collider;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Projectiles;

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
            item.Despawn();
        }

        public void OnProjectileCollision(IProjectile proj)
        {
            proj.Despawn();
        }

        public void Update(Vector2 location)
        {
            hitbox.Location = location.ToPoint();
        }
    }
}
