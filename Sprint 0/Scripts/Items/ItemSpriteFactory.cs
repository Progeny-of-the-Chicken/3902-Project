using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Sprite.ItemSprites;

namespace Sprint_0.Scripts.Items
{
    public class ItemSpriteFactory
    {
        private Texture2D spritesheet;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            spritesheet = content.Load<Texture2D>(ObjectConstants.itemFile);
        }

        public ISprite CreateSmallHeartItemSprite()
        {
            return new AnimatedItemSprite(spritesheet, SpriteRectangles.smallHeartFrames);
        }

        public ISprite CreateHeartContainerSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, SpriteRectangles.heartContainerFrame);
        }

        public ISprite CreateFairySprite()
        {
            return new AnimatedItemSprite(spritesheet, SpriteRectangles.fairyFrames);
        }

        public ISprite CreateClockSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, SpriteRectangles.clockFrame);
        }

        public ISprite CreateBlueRubySprite()
        {
            return new NonAnimatedItemSprite(spritesheet, SpriteRectangles.blueRubyFrame);
        }

        public ISprite CreateYellowRubySprite()
        {
            return new AnimatedItemSprite(spritesheet, SpriteRectangles.yellowRubyFrames);
        }

        public ISprite CreateBasicMapItemSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, SpriteRectangles.basicMapFrame);
        }

        public ISprite CreateBoomerangItemSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, SpriteRectangles.boomerangItemFrame);
        }

        public ISprite CreateBombItemSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, SpriteRectangles.bombItemFrame);
        }

        public ISprite CreateBowItemSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, SpriteRectangles.bowItemFrame);
        }

        public ISprite CreateBasicKeySprite()
        {
            return new NonAnimatedItemSprite(spritesheet, SpriteRectangles.basicKeyFrame);
        }

        public ISprite CreateMagicKeySprite()
        {
            return new NonAnimatedItemSprite(spritesheet, SpriteRectangles.magicKeyFrame);
        }

        public ISprite CreateCompassSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, SpriteRectangles.compassFrame);
        }

        public ISprite CreateTriforcePieceSprite()
        {
            return new AnimatedItemSprite(spritesheet, SpriteRectangles.triforcePieceFrames);
        }

        public ISprite CreateBasicArrowSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, SpriteRectangles.basicArrowItemFrame);
        }

        public ISprite CreateSilverArrowSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, SpriteRectangles.silverArrowItemFrame);
        }

        public ISprite CreateBlueRingSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, SpriteRectangles.blueRingItemFrame);
        }
    }
}
