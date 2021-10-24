﻿using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts
{
    public class LinkCollider : IPlayerCollider
    {
        private Link _owner;
        private Rectangle hitbox;

        public Link owner { get => _owner; }
        public Rectangle collisionRectangle { get => hitbox; }


        public LinkCollider(Link owner, Rectangle initialPosition)
        {
            _owner = owner;
            hitbox = initialPosition;
        }


        public void onBlockCollision(ITerrain block)
        {
            FacingDirection currDirection = _owner.FacingDirection;
            _owner.BounceBackInDirection(oppositeDirection(currDirection));
        }

        public void onItemCollision(IItem item)
        {
            item.Despawn();
        }

        public void Update(Vector2 location)
        {
            hitbox.Location = location.ToPoint();
        }

        private FacingDirection oppositeDirection(FacingDirection dir)
        {
            switch (dir)
            {
                case FacingDirection.Right:
                    return FacingDirection.Left;
                case FacingDirection.Left:
                    return FacingDirection.Right;
                case FacingDirection.Up:
                    return FacingDirection.Down;
                case FacingDirection.Down:
                    return FacingDirection.Up;
                default:
                    return FacingDirection.Up;
            }
        }
    }
}
