using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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

        public IItem CreateSmallHeartTreasure(Vector2 location)
        {
            return new AnimatedTreasure(ItemSpriteFactory.Instance.CreateSmallHeartTreasureSprite(), location);
        }

        public IItem CreateHeartContainer(Vector2 location)
        {
            return new NonAnimatedTreasure(ItemSpriteFactory.Instance.CreateHeartContainerSprite(), location);
        }

        public IItem CreateFairy(Vector2 location)
        {
            return new AnimatedTreasure(ItemSpriteFactory.Instance.CreateFairySprite(), location);
        }

        public IItem CreateClock(Vector2 location)
        {
            return new NonAnimatedTreasure(ItemSpriteFactory.Instance.CreateClockSprite(), location);
        }

        public IItem CreateBlueRuby(Vector2 location)
        {
            return new NonAnimatedTreasure(ItemSpriteFactory.Instance.CreateBlueRubySprite(), location);
        }

        public IItem CreateYellowRuby(Vector2 location)
        {
            return new AnimatedTreasure(ItemSpriteFactory.Instance.CreateYellowRubySprite(), location);
        }

        public IItem CreateBasicMap(Vector2 location)
        {
            return new NonAnimatedTreasure(ItemSpriteFactory.Instance.CreateBasicMapSprite(), location);
        }

        public IItem CreateBoomerangTreasure(Vector2 location)
        {
            return new NonAnimatedTreasure(ItemSpriteFactory.Instance.CreateBoomerangTreasureSprite(), location);
        }

        public IItem CreateBombTreasure(Vector2 location)
        {
            return new NonAnimatedTreasure(ItemSpriteFactory.Instance.CreateBombTreasureSprite(), location);
        }

        public IItem CreateBowTreasure(Vector2 location)
        {
            return new NonAnimatedTreasure(ItemSpriteFactory.Instance.CreateBowTreasureSprite(), location);
        }

        public IItem CreateBasicKey(Vector2 location)
        {
            return new NonAnimatedTreasure(ItemSpriteFactory.Instance.CreateBasicKeySprite(), location);
        }

        public IItem CreateMagicKey(Vector2 location)
        {
            return new NonAnimatedTreasure(ItemSpriteFactory.Instance.CreateMagicKeySprite(), location);
        }

        public IItem CreateCompass(Vector2 location)
        {
            return new NonAnimatedTreasure(ItemSpriteFactory.Instance.CreateCompassSprite(), location);
        }

        public IItem CreateTriforcePiece(Vector2 location)
        {
            return new AnimatedTreasure(ItemSpriteFactory.Instance.CreateTriforcePieceSprite(), location);
        }

        public IItem CreateArrow(Vector2 location, Arrow.Direction direction, bool silver)
        {
            return new Arrow(location, direction, silver);
        }

        public IItem CreateBoomerang(Vector2 location, Boomerang.Direction direction, bool magical)
        {
            return new Boomerang(location, direction, magical);
        }

        public IItem CreateBomb(Vector2 location, Bomb.Direction direction)
        {
            return new Bomb(location, direction);
        }

        public IItem CreateFireSpell(Vector2 location, FireSpell.Direction direction)
        {
            return new FireSpell(location, direction);
        }
    }
}
