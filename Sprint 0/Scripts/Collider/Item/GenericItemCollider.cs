using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Collider.Item
{
    public class GenericItemCollider : IItemCollider
    {
        private Rectangle _hitbox;

        public IItem Owner { get; }

        public Rectangle Hitbox { get => _hitbox; }

        public GenericItemCollider(IItem owner)
        {
            Owner = owner;
            switch (Owner.Type)
            {
                case ItemType.SmallHeartItem:
                    _hitbox = SpriteRectangles.smallHeartFrames[ObjectConstants.firstFrame];
                    break;
                case ItemType.HeartContainer:
                    _hitbox = SpriteRectangles.heartContainerFrame;
                    break;
                case ItemType.Fairy:
                    _hitbox = SpriteRectangles.fairyFrames[ObjectConstants.firstFrame];
                    break;
                case ItemType.Clock:
                    _hitbox = SpriteRectangles.clockFrame;
                    break;
                case ItemType.BlueRuby:
                    _hitbox = SpriteRectangles.blueRubyFrame;
                    break;
                case ItemType.YellowRuby:
                    _hitbox = SpriteRectangles.yellowRubyFrames[ObjectConstants.firstFrame];
                    break;
                case ItemType.BasicMapItem:
                    _hitbox = SpriteRectangles.basicMapFrame;
                    break;
                case ItemType.BoomerangItem:
                    _hitbox = SpriteRectangles.boomerangItemFrame;
                    break;
                case ItemType.BombItem:
                    _hitbox = SpriteRectangles.bombFrame;
                    break;
                case ItemType.BowItem:
                    _hitbox = SpriteRectangles.bowItemFrame;
                    break;
                case ItemType.BasicKey:
                    _hitbox = SpriteRectangles.basicKeyFrame;
                    break;
                case ItemType.MagicKey:
                    _hitbox = SpriteRectangles.magicKeyFrame;
                    break;
                case ItemType.Compass:
                    _hitbox = SpriteRectangles.compassFrame;
                    break;
                case ItemType.TriforcePiece:
                    _hitbox = SpriteRectangles.triforcePieceFrames[ObjectConstants.firstFrame];
                    break;
                default:
                    // Should never happen
                    _hitbox = SpriteRectangles.smallHeartFrames[ObjectConstants.firstFrame];
                    break;
            }
            _hitbox.Size *= new Point(ObjectConstants.scale);
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint();
        }

        public void OnLinkCollision(Link link)
        {
            link.PickUpItem();
        }
    }
}
