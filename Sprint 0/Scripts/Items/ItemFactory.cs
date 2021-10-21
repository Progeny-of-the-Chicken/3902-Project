using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Items.ItemColliders;

namespace Sprint_0.Scripts.Items
{
    public class ItemFactory
    {
        private static ItemFactory instance = new ItemFactory();

        public static ItemFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemFactory()
        {
        }

        public IItem CreateSmallHeartItem(Vector2 location)
        {
            return new Item(location, ItemType.SmallHeartItem);
        }

        public IItem CreateHeartContainer(Vector2 location)
        {
            return new Item(location, ItemType.HeartContainer);
        }

        public IItem CreateFairy(Vector2 location)
        {
            return new Item(location, ItemType.Fairy);
        }

        public IItem CreateClock(Vector2 location)
        {
            return new Item(location, ItemType.Clock);
        }

        public IItem CreateBlueRuby(Vector2 location)
        {
            return new Item(location, ItemType.BlueRuby);
        }

        public IItem CreateYellowRuby(Vector2 location)
        {
            return new Item(location, ItemType.YellowRuby);
        }

        public IItem CreateBasicMapItem(Vector2 location)
        {
            return new Item(location, ItemType.BasicMapItem);
        }

        public IItem CreateBoomerangItem(Vector2 location)
        {
            return new Item(location, ItemType.BoomerangItem);
        }

        public IItem CreateBombItem(Vector2 location)
        {
            return new Item(location, ItemType.BombItem);
        }

        public IItem CreateBowItem(Vector2 location)
        {
            return new Item(location, ItemType.BowItem);
        }

        public IItem CreateBasicKey(Vector2 location)
        {
            return new Item(location, ItemType.BasicKey);
        }

        public IItem CreateMagicKey(Vector2 location)
        {
            return new Item(location, ItemType.MagicKey);
        }

        public IItem CreateCompass(Vector2 location)
        {
            return new Item(location, ItemType.Compass);
        }

        public IItem CreateTriforcePiece(Vector2 location)
        {
            return new Item(location, ItemType.TriforcePiece);
        }
    }
}
