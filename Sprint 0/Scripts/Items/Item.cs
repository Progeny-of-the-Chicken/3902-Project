using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.ItemColliders;

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
            InitializeDependencies(Type);
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

        //----- Helper method for initializing dependencies by type -----//

        private void InitializeDependencies(ItemType type)
        {
            switch (type)
            {
                case ItemType.SmallHeartItem:
                    Collider = ItemColliderFactory.Instance.CreateSmallHeartItemCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateSmallHeartItemSprite();
                    break;
                case ItemType.HeartContainer:
                    Collider = ItemColliderFactory.Instance.CreateHeartContainerCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateHeartContainerSprite();
                    break;
                case ItemType.Fairy:
                    Collider = ItemColliderFactory.Instance.CreateFairyCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateFairySprite();
                    break;
                case ItemType.Clock:
                    Collider = ItemColliderFactory.Instance.CreateClockCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateClockSprite();
                    break;
                case ItemType.BlueRuby:
                    Collider = ItemColliderFactory.Instance.CreateBlueRubyCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateBlueRubySprite();
                    break;
                case ItemType.YellowRuby:
                    Collider = ItemColliderFactory.Instance.CreateYellowRubyCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateYellowRubySprite();
                    break;
                case ItemType.BasicMapItem:
                    Collider = ItemColliderFactory.Instance.CreateBasicMapItemCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateBasicMapItemSprite();
                    break;
                case ItemType.BoomerangItem:
                    Collider = ItemColliderFactory.Instance.CreateBoomerangItemCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateBoomerangItemSprite();
                    break;
                case ItemType.BombItem:
                    Collider = ItemColliderFactory.Instance.CreateBombItemCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateBombItemSprite();
                    break;
                case ItemType.BowItem:
                    Collider = ItemColliderFactory.Instance.CreateBowItemCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateBowItemSprite();
                    break;
                case ItemType.BasicKey:
                    Collider = ItemColliderFactory.Instance.CreateBasicKeyCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateBasicKeySprite();
                    break;
                case ItemType.MagicKey:
                    Collider = ItemColliderFactory.Instance.CreateMagicKeyCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateMagicKeySprite();
                    break;
                case ItemType.Compass:
                    Collider = ItemColliderFactory.Instance.CreateCompassCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateCompassSprite();
                    break;
                case ItemType.TriforcePiece:
                    Collider = ItemColliderFactory.Instance.CreateTriforcePieceCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateTriforcePieceSprite();
                    break;
                default:
                    // Should never fire
                    Collider = ItemColliderFactory.Instance.CreateSmallHeartItemCollider(this);
                    sprite = ItemSpriteFactory.Instance.CreateSmallHeartItemSprite();
                    break;
            }
        }
    }
}
