using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

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
            spritesheet = content.Load<Texture2D>("LoZItems");
        }

        public ISprite CreateSmallHeartItemSprite()
        {
            List<Rectangle> frames = new List<Rectangle>();
            frames.Add(new Rectangle(0, 0, 7, 8));
            frames.Add(new Rectangle(0, 8, 7, 8));
            return new AnimatedItemSprite(spritesheet, frames);
        }

        public ISprite CreateHeartContainerSprite()
        {
            Rectangle frame = new Rectangle(25, 1, 13, 13);
            return new NonAnimatedItemSprite(spritesheet, frame);
        }

        public ISprite CreateFairySprite()
        {
            List<Rectangle> frames = new List<Rectangle>();
            frames.Add(new Rectangle(40, 0, 8, 16));
            frames.Add(new Rectangle(48, 0, 8, 16));
            return new AnimatedItemSprite(spritesheet, frames);
        }

        public ISprite CreateClockSprite()
        {
            Rectangle frame = new Rectangle(58, 0, 11, 16);
            return new NonAnimatedItemSprite(spritesheet, frame);
        }

        public ISprite CreateBlueRubySprite()
        {
            Rectangle frame = new Rectangle(72, 0, 8, 16);
            return new NonAnimatedItemSprite(spritesheet, frame);
        }

        public ISprite CreateYellowRubySprite()
        {
            List<Rectangle> frames = new List<Rectangle>();
            frames.Add(new Rectangle(72, 0, 8, 16));
            frames.Add(new Rectangle(72, 16, 8, 16));
            return new AnimatedItemSprite(spritesheet, frames);
        }

        public ISprite CreateBasicMapSprite()
        {
            Rectangle frame = new Rectangle(88, 0, 8, 16);
            return new NonAnimatedItemSprite(spritesheet, frame);
        }

        public ISprite CreateBoomerangItemSprite()
        {
            Rectangle frame = new Rectangle(129, 3, 5, 8);
            return new NonAnimatedItemSprite(spritesheet, frame);
        }

        public ISprite CreateBombItemSprite()
        {
            Rectangle frame = new Rectangle(136, 0, 8, 14);
            return new NonAnimatedItemSprite(spritesheet, frame);
        }

        public ISprite CreateBowItemSprite()
        {
            Rectangle frame = new Rectangle(144, 0, 8, 16);
            return new NonAnimatedItemSprite(spritesheet, frame);
        }

        public ISprite CreateBasicKeySprite()
        {
            Rectangle frame = new Rectangle(240, 0, 8, 16);
            return new NonAnimatedItemSprite(spritesheet, frame);
        }

        public ISprite CreateMagicKeySprite()
        {
            Rectangle frame = new Rectangle(248, 0, 8, 16);
            return new NonAnimatedItemSprite(spritesheet, frame);
        }

        public ISprite CreateCompassSprite()
        {
            Rectangle frame = new Rectangle(258, 1, 11, 12);
            return new NonAnimatedItemSprite(spritesheet, frame);
        }

        public ISprite CreateTriforcePieceSprite()
        {
            List<Rectangle> frames = new List<Rectangle>();
            frames.Add(new Rectangle(275, 3, 10, 10));
            frames.Add(new Rectangle(275, 19, 10, 10));
            return new AnimatedItemSprite(spritesheet, frames);
        }
    }
}
