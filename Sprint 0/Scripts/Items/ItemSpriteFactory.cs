using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Items
{
    public class ItemSpriteFactory
    {
        private Texture2D projectileSpritesheet;
        private Texture2D treasureSpritesheet;

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
            projectileSpritesheet = content.Load<Texture2D>("LoZSprites");
            treasureSpritesheet = content.Load<Texture2D>("LoZItems");
        }

        public IItem CreateSmallHeartTreasure(Vector2 spawnLoc)
        {
            List<Rectangle> frames = new List<Rectangle>();
            frames.Add(new Rectangle(0, 0, 7, 8));
            frames.Add(new Rectangle(0, 8, 7, 8));
            return new AnimatedTreasure(treasureSpritesheet, frames, spawnLoc);
        }

        public IItem CreateHeartContainer(Vector2 spawnLoc)
        {
            Rectangle frame = new Rectangle(25, 1, 13, 13);
            return new NonAnimatedTreasure(treasureSpritesheet, frame, spawnLoc);
        }

        public IItem CreateFairy(Vector2 spawnLoc)
        {
            List<Rectangle> frames = new List<Rectangle>();
            frames.Add(new Rectangle(40, 0, 8, 16));
            frames.Add(new Rectangle(48, 0, 8, 16));
            return new AnimatedTreasure(treasureSpritesheet, frames, spawnLoc);
        }

        public IItem CreateClock(Vector2 spawnLoc)
        {
            Rectangle frame = new Rectangle(58, 0, 11, 16);
            return new NonAnimatedTreasure(treasureSpritesheet, frame, spawnLoc);
        }

        public IItem CreateBlueRuby(Vector2 spawnLoc)
        {
            Rectangle frame = new Rectangle(72, 0, 8, 16);
            return new NonAnimatedTreasure(treasureSpritesheet, frame, spawnLoc);
        }

        public IItem CreateYellowRuby(Vector2 spawnLoc)
        {
            List<Rectangle> frames = new List<Rectangle>();
            frames.Add(new Rectangle(72, 0, 8, 16));
            frames.Add(new Rectangle(72, 16, 8, 16));
            return new AnimatedTreasure(treasureSpritesheet, frames, spawnLoc);
        }

        public IItem CreateBasicMap(Vector2 spawnLoc)
        {
            Rectangle frame = new Rectangle(88, 0, 8, 16);
            return new NonAnimatedTreasure(treasureSpritesheet, frame, spawnLoc);
        }

        public IItem CreateBoomerangTreasure(Vector2 spawnLoc)
        {
            Rectangle frame = new Rectangle(129, 3, 5, 8);
            return new NonAnimatedTreasure(treasureSpritesheet, frame, spawnLoc);
        }

        public IItem CreateBombTreasure(Vector2 spawnLoc)
        {
            Rectangle frame = new Rectangle(136, 0, 8, 14);
            return new NonAnimatedTreasure(treasureSpritesheet, frame, spawnLoc);
        }

        public IItem CreateBowTreasure(Vector2 spawnLoc)
        {
            Rectangle frame = new Rectangle(144, 0, 8, 16);
            return new NonAnimatedTreasure(treasureSpritesheet, frame, spawnLoc);
        }

        public IItem CreateBasicKey(Vector2 spawnLoc)
        {
            Rectangle frame = new Rectangle(240, 0, 8, 16);
            return new NonAnimatedTreasure(treasureSpritesheet, frame, spawnLoc);
        }

        public IItem CreateMagicKey(Vector2 spawnLoc)
        {
            Rectangle frame = new Rectangle(248, 0, 8, 16);
            return new NonAnimatedTreasure(treasureSpritesheet, frame, spawnLoc);
        }

        public IItem CreateCompass(Vector2 spawnLoc)
        {
            Rectangle frame = new Rectangle(258, 1, 11, 12);
            return new NonAnimatedTreasure(treasureSpritesheet, frame, spawnLoc);
        }

        public IItem CreateTriforcePiece(Vector2 spawnLoc)
        {
            List<Rectangle> frames = new List<Rectangle>();
            frames.Add(new Rectangle(275, 3, 10, 10));
            frames.Add(new Rectangle(275, 19, 10, 10));
            return new AnimatedTreasure(treasureSpritesheet, frames, spawnLoc);
        }

        public IItem CreateArrow(Vector2 spawnLoc, Arrow.Direction dir, bool silver)
        {
            return new Arrow(projectileSpritesheet, spawnLoc, dir, silver);
        }

        public IItem CreateBoomerang(Vector2 spawnLoc, Boomerang.Direction dir, bool magical)
        {
            return new Boomerang(projectileSpritesheet, spawnLoc, dir, magical);
        }

        public IItem CreateFireSpell(Vector2 spawnLoc, FireSpell.Direction dir)
        {
            return new FireSpell(projectileSpritesheet, spawnLoc, dir);
        }

        public IItem CreateBomb(Vector2 spawnLoc, Bomb.Direction dir)
        {
            return new Bomb(projectileSpritesheet, spawnLoc, dir);
        }
    }
}
