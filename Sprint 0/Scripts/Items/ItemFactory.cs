using System.Collections.Generic;
using Microsoft.Xna.Framework;

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
            return new AnimatedItem(ItemSpriteFactory.Instance.CreateSmallHeartItemSprite(), location);
        }

        public IItem CreateHeartContainer(Vector2 location)
        {
            return new NonAnimatedItem(ItemSpriteFactory.Instance.CreateHeartContainerSprite(), location);
        }

        public IItem CreateFairy(Vector2 location)
        {
            return new AnimatedItem(ItemSpriteFactory.Instance.CreateFairySprite(), location);
        }

        public IItem CreateClock(Vector2 location)
        {
            return new NonAnimatedItem(ItemSpriteFactory.Instance.CreateClockSprite(), location);
        }

        public IItem CreateBlueRuby(Vector2 location)
        {
            return new NonAnimatedItem(ItemSpriteFactory.Instance.CreateBlueRubySprite(), location);
        }

        public IItem CreateYellowRuby(Vector2 location)
        {
            return new AnimatedItem(ItemSpriteFactory.Instance.CreateYellowRubySprite(), location);
        }

        public IItem CreateBasicMap(Vector2 location)
        {
            return new NonAnimatedItem(ItemSpriteFactory.Instance.CreateBasicMapSprite(), location);
        }

        public IItem CreateBoomerangItem(Vector2 location)
        {
            return new NonAnimatedItem(ItemSpriteFactory.Instance.CreateBoomerangItemSprite(), location);
        }

        public IItem CreateBombItem(Vector2 location)
        {
            return new NonAnimatedItem(ItemSpriteFactory.Instance.CreateBombItemSprite(), location);
        }

        public IItem CreateBowItem(Vector2 location)
        {
            return new NonAnimatedItem(ItemSpriteFactory.Instance.CreateBowItemSprite(), location);
        }

        public IItem CreateBasicKey(Vector2 location)
        {
            return new NonAnimatedItem(ItemSpriteFactory.Instance.CreateBasicKeySprite(), location);
        }

        public IItem CreateMagicKey(Vector2 location)
        {
            return new NonAnimatedItem(ItemSpriteFactory.Instance.CreateMagicKeySprite(), location);
        }

        public IItem CreateCompass(Vector2 location)
        {
            return new NonAnimatedItem(ItemSpriteFactory.Instance.CreateCompassSprite(), location);
        }

        public IItem CreateTriforcePiece(Vector2 location)
        {
            return new AnimatedItem(ItemSpriteFactory.Instance.CreateTriforcePieceSprite(), location);
        }
    }
}
