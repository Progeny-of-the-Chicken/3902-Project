using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Items.ItemColliders
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
                    _hitbox = SpriteRectangles.smallHeartFrames[0];
                    break;
                case ItemType.HeartContainer:
                    _hitbox = SpriteRectangles.heartContainerFrame;
                    break;
                case ItemType.Fairy:
                    _hitbox = SpriteRectangles.fairyFrames[0];
                    break;
                case ItemType.Clock:
                    _hitbox = SpriteRectangles.clockFrame;
                    break;
                case ItemType.BlueRuby:
                    _hitbox = SpriteRectangles.blueRubyFrame;
                    break;
                case ItemType.YellowRuby:
                    _hitbox = SpriteRectangles.yellowRubyFrames[0];
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
                    _hitbox = SpriteRectangles.triforcePieceFrames[0];
                    break;
                default:
                    // Should never happen
                    _hitbox = SpriteRectangles.smallHeartFrames[0];
                    break;
            }
        }

        public void Update(Vector2 location)
        {
            _hitbox.Location = location.ToPoint();
        }
    }
}
