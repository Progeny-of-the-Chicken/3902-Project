using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Items
{
    public class Bomb : IItem
    {
        public enum Direction { UP, DOWN, LEFT, RIGHT };

        private ISprite sprite;
        private Vector2 pos;
        private int displacement = 50;
        private bool delete = false;
        private double startTime = 0;
        private double fuseDurationSeconds = 2.0;
        private bool explode = false;
        private double explodeDurationSeconds = 0.3;

        public Bomb(Vector2 spawnLoc, Direction dir)
        {
            pos = spawnLoc;
            switch (dir)
            {
                case Direction.RIGHT:
                    pos.X += displacement;
                    break;
                case Direction.UP:
                    pos.Y += displacement;
                    break;
                case Direction.LEFT:
                    pos.X -= displacement;
                    break;
                case Direction.DOWN:
                    pos.Y -= displacement;
                    break;
                default:
                    break;
            }
            sprite = ItemSpriteFactory.Instance.CreateBombSprite();
        }

        public void Update(GameTime gt)
        {
            // Animation control
            sprite.Update(gt);
            if (!explode)
            {
                startTime += gt.ElapsedGameTime.TotalSeconds;
                if (startTime > fuseDurationSeconds)
                {
                    explode = true;
                    sprite = ItemSpriteFactory.Instance.CreateBombExplodeSprite();
                    startTime = 0.0;
                }
            }
            else
            {
                startTime += gt.ElapsedGameTime.TotalSeconds;
                if (startTime > explodeDurationSeconds)
                {
                    delete = true;
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, pos);
        }

        public bool CheckDelete()
        {
            return delete;
        }
    }
}
