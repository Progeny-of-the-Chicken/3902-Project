using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Item;

namespace Sprint_0.Scripts.Items
{
    public class Item : IItem
    {
        private ISprite sprite;
        private Vector2 pos;
        private bool delete = false;

        public ItemType Type { get; }

        public IItemCollider Collider { get; set; }

        public Item(Vector2 spawnLoc, ItemType type)
        {
            Type = type;
            sprite = GetSpriteForItemType(Type);
            Collider = new GenericItemCollider(this);
            pos = spawnLoc;
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
            Collider.Update(pos);
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
            switch (Type)
            {
                case ItemType.SmallHeartItem:
                    SFXManager.Instance.PlayPickUpHeart();
                    break;
                case ItemType.BlueRuby:
                case ItemType.YellowRuby:
                    SFXManager.Instance.PlayPickUpRupee();
                    break;
                case ItemType.BoomerangItem:
                case ItemType.BowItem:
                    SFXManager.Instance.PlayFanfare();
                    break;
                case ItemType.TriforcePiece:
                    SFXManager.Instance.StopMusic();
                    SFXManager.Instance.PlayTriforcePiece();
                    break;
                default:
                    SFXManager.Instance.PlayPickUpItem();
                    break;
            }
            delete = true;
        }

        //----- Helper method for initializing dependencies by type -----//

        private ISprite GetSpriteForItemType(ItemType type)
        {
            return type switch
            {
                ItemType.SmallHeartItem => ItemSpriteFactory.Instance.CreateSmallHeartItemSprite(),
                ItemType.HeartContainer => ItemSpriteFactory.Instance.CreateHeartContainerSprite(),
                ItemType.Fairy => ItemSpriteFactory.Instance.CreateFairySprite(),
                ItemType.Clock => ItemSpriteFactory.Instance.CreateClockSprite(),
                ItemType.BlueRuby => ItemSpriteFactory.Instance.CreateBlueRubySprite(),
                ItemType.YellowRuby => ItemSpriteFactory.Instance.CreateYellowRubySprite(),
                ItemType.BasicMapItem => ItemSpriteFactory.Instance.CreateBasicMapItemSprite(),
                ItemType.BoomerangItem => ItemSpriteFactory.Instance.CreateBoomerangItemSprite(),
                ItemType.BombItem => ItemSpriteFactory.Instance.CreateBombItemSprite(),
                ItemType.BowItem => ItemSpriteFactory.Instance.CreateBowItemSprite(),
                ItemType.BasicKey => ItemSpriteFactory.Instance.CreateBasicKeySprite(),
                ItemType.MagicKey => ItemSpriteFactory.Instance.CreateMagicKeySprite(),
                ItemType.Compass => ItemSpriteFactory.Instance.CreateCompassSprite(),
                ItemType.TriforcePiece => ItemSpriteFactory.Instance.CreateTriforcePieceSprite(),
                ItemType.BasicArrowItem => ItemSpriteFactory.Instance.CreateBasicArrowSprite(),
                ItemType.SilverArrowItem => ItemSpriteFactory.Instance.CreateSilverArrowSprite(),
                ItemType.BlueRing => ItemSpriteFactory.Instance.CreateBlueRingSprite(),
                ItemType.ShotgunItem => ItemSpriteFactory.Instance.CreateShotgunItemSprite(),
                ItemType.ShotgunShellItem => ItemSpriteFactory.Instance.CreateShotgunShellItemSprite(),
                _ => ItemSpriteFactory.Instance.CreateSmallHeartItemSprite()
            };
        }
    }
}
