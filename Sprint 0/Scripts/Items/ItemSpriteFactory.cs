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
            Rectangle frame;
            if (!silver)
            {
                if (dir == Arrow.Direction.RIGHT || dir == Arrow.Direction.LEFT)
                {
                    frame = new Rectangle(10, 190, 16, 5);
                }
                else
                {
                    frame = new Rectangle(3, 185, 5, 16);
                }
            }
            else
            {
                if (dir == Arrow.Direction.RIGHT || dir == Arrow.Direction.LEFT)
                {
                    frame = new Rectangle(36, 190, 16, 5);
                }
                else
                {
                    frame = new Rectangle(29, 185, 5, 16);
                }
            }
            
            return new Arrow(projectileSpritesheet, frame, spawnLoc, dir, silver);
        }

        public IItem CreateArrowPuff(Vector2 spawnLoc)
        {
            List<Rectangle> frames = new List<Rectangle>();
            frames.Add(new Rectangle(53, 189, 8, 8));
            return new ProjectilePuff(projectileSpritesheet, frames, spawnLoc);
        }

        public IItem CreateBoomerang(Vector2 spawnLoc, Boomerang.Direction dir, bool magical)
        {
            List<Rectangle> frames = new List<Rectangle>();
            if (!magical)
            {
                frames.Add(new Rectangle(64, 189, 8, 8));
                frames.Add(new Rectangle(73, 189, 8, 8));
                frames.Add(new Rectangle(82, 189, 8, 8));
                frames.Add(new Rectangle(91, 189, 8, 8));
            }
            else
            {
                frames.Add(new Rectangle(100, 189, 8, 8));
                frames.Add(new Rectangle(109, 189, 8, 8));
                frames.Add(new Rectangle(118, 189, 8, 8));
                frames.Add(new Rectangle(127, 189, 8, 8));
            }

            return new Boomerang(projectileSpritesheet, frames, spawnLoc, dir, magical);
        }

        public IItem CreateFireSpell(Vector2 spawnLoc, FireSpell.Direction dir)
        {
            Rectangle frame = new Rectangle(215, 185, 16, 16);
            return new FireSpell(projectileSpritesheet, frame, spawnLoc, dir);
        }

        public IItem CreateBomb(Vector2 spawnLoc, Bomb.Direction dir)
        {
            List<Rectangle> frames = new List<Rectangle>();
            frames.Add(new Rectangle(145, 185, 16, 16));
            frames.Add(new Rectangle(162, 185, 16, 16));
            frames.Add(new Rectangle(179, 185, 16, 16));
            frames.Add(new Rectangle(196, 185, 16, 16));
            return new Bomb(projectileSpritesheet, frames, spawnLoc, dir);
        }
    }
}
