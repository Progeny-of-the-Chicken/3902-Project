using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Items
{
    public class Item : IItem
    {
        private ItemType type;
        private ISprite sprite;
        private Vector2 pos;
        private bool delete = false;

        public Item(Vector2 spawnLoc, ItemType type)
        {
            this.type = type;
            sprite = GetSprite(type);
            pos = spawnLoc;
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, pos);
        }

        public bool CheckDelete()
        {
            return delete;
        }

        public void Despawn()
        {
            delete = true;
        }

        //----- Helper method for handling sprite type -----//

        private ISprite GetSprite(ItemType type)
        {
            ISprite returnSprite;
            switch (type)
            {
                case ItemType.SmallHeartItem:
                    returnSprite = ItemSpriteFactory.Instance.CreateSmallHeartItemSprite();
                    break;
                case ItemType.HeartContainer:
                    returnSprite = ItemSpriteFactory.Instance.CreateHeartContainerSprite();
                    break;
                case ItemType.Fairy:
                    returnSprite = ItemSpriteFactory.Instance.CreateFairySprite();
                    break;
                case ItemType.Clock:
                    returnSprite = ItemSpriteFactory.Instance.CreateClockSprite();
                    break;
                case ItemType.BlueRuby:
                    returnSprite = ItemSpriteFactory.Instance.CreateBlueRubySprite();
                    break;
                case ItemType.YellowRuby:
                    returnSprite = ItemSpriteFactory.Instance.CreateYellowRubySprite();
                    break;
                case ItemType.BasicMapItem:
                    returnSprite = ItemSpriteFactory.Instance.CreateBasicMapItemSprite();
                    break;
                case ItemType.BoomerangItem:
                    returnSprite = ItemSpriteFactory.Instance.CreateBoomerangItemSprite();
                    break;
                case ItemType.BombItem:
                    returnSprite = ItemSpriteFactory.Instance.CreateBombItemSprite();
                    break;
                case ItemType.BowItem:
                    returnSprite = ItemSpriteFactory.Instance.CreateBowItemSprite();
                    break;
                case ItemType.BasicKey:
                    returnSprite = ItemSpriteFactory.Instance.CreateBasicKeySprite();
                    break;
                case ItemType.MagicKey:
                    returnSprite = ItemSpriteFactory.Instance.CreateMagicKeySprite();
                    break;
                case ItemType.Compass:
                    returnSprite = ItemSpriteFactory.Instance.CreateCompassSprite();
                    break;
                case ItemType.TriforcePiece:
                    returnSprite = ItemSpriteFactory.Instance.CreateTriforcePieceSprite();
                    break;
                default:
                    // Should never fire
                    returnSprite = ItemSpriteFactory.Instance.CreateYellowRubySprite();
                    break;
            }
            return returnSprite;
        }
    }
}
