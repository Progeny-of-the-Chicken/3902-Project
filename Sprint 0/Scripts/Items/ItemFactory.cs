using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Items.ItemClasses;

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
            return new SmallHeartItem(location);
        }

        public IItem CreateHeartContainer(Vector2 location)
        {
            return new HeartContainer(location);
        }

        public IItem CreateFairy(Vector2 location)
        {
            return new Fairy(location);
        }

        public IItem CreateClock(Vector2 location)
        {
            return new Clock(location);
        }

        public IItem CreateBlueRuby(Vector2 location)
        {
            return new BlueRuby(location);
        }

        public IItem CreateYellowRuby(Vector2 location)
        {
            return new YellowRuby(location);
        }

        public IItem CreateBasicMapItem(Vector2 location)
        {
            return new BasicMapItem(location);
        }

        public IItem CreateBoomerangItem(Vector2 location)
        {
            return new BoomerangItem(location);
        }

        public IItem CreateBombItem(Vector2 location)
        {
            return new BombItem(location);
        }

        public IItem CreateBowItem(Vector2 location)
        {
            return new BowItem(location);
        }

        public IItem CreateBasicKey(Vector2 location)
        {
            return new BasicKey(location);
        }

        public IItem CreateMagicKey(Vector2 location)
        {
            return new MagicKey(location);
        }

        public IItem CreateCompass(Vector2 location)
        {
            return new Compass(location);
        }

        public IItem CreateTriforcePiece(Vector2 location)
        {
            return new TriforcePiece(location);
        }
    }
}
