﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
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
            spritesheet = content.Load<Texture2D>("LoZItems");
        }

        public ISprite CreateSmallHeartItemSprite()
        {
            return new AnimatedItemSprite(spritesheet, ObjectConstants.smallHeartFrames);
        }

        public ISprite CreateHeartContainerSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, ObjectConstants.heartContainerFrame);
        }

        public ISprite CreateFairySprite()
        {
            return new AnimatedItemSprite(spritesheet, ObjectConstants.fairyFrames);
        }

        public ISprite CreateClockSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, ObjectConstants.clockFrame);
        }

        public ISprite CreateBlueRubySprite()
        {
            return new NonAnimatedItemSprite(spritesheet, ObjectConstants.blueRubyFrame);
        }

        public ISprite CreateYellowRubySprite()
        {
            return new AnimatedItemSprite(spritesheet, ObjectConstants.yellowRubyFrames);
        }

        public ISprite CreateBasicMapItemSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, ObjectConstants.basicMapFrame);
        }

        public ISprite CreateBoomerangItemSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, ObjectConstants.boomerangItemFrame);
        }

        public ISprite CreateBombItemSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, ObjectConstants.bombItemFrame);
        }

        public ISprite CreateBowItemSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, ObjectConstants.bowItemFrame);
        }

        public ISprite CreateBasicKeySprite()
        {
            return new NonAnimatedItemSprite(spritesheet, ObjectConstants.basicKeyFrame);
        }

        public ISprite CreateMagicKeySprite()
        {
            return new NonAnimatedItemSprite(spritesheet, ObjectConstants.magicKeyFrame);
        }

        public ISprite CreateCompassSprite()
        {
            return new NonAnimatedItemSprite(spritesheet, ObjectConstants.compassFrame);
        }

        public ISprite CreateTriforcePieceSprite()
        {
            return new AnimatedItemSprite(spritesheet, ObjectConstants.triforcePieceFrames);
        }
    }
}
