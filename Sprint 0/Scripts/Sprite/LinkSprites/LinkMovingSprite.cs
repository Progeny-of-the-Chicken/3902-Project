using System;
using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.LinkSprites
{
    public class LinkMovingSprite: ISprite
    {
        private Texture2D sheet;

        private Rectangle forwardSpritesheetLocation_1 = new Rectangle(1, 11, 15, 16);
        private Rectangle forwardSpritesheetLocation_2 = new Rectangle(19, 11, 15, 16);
        private Rectangle rightSpritesheetLocation_1 = new Rectangle(34, 11, 15, 16);
        private Rectangle rightSpritesheetLocation_2 = new Rectangle(51, 12, 14, 16);
        private Rectangle backwardSpritesheetLocation_1 = new Rectangle(70, 11, 15, 16);
        private Rectangle backwardSpritesheetLocation_2 = new Rectangle(87, 11, 15, 16);

        private Direction direction;

        private int stepSpeed = 10; // Lower is faster
        private int stepsPerSec = 3;
        private int frameNum = 0;
        private int maxFrames = 30;
        private Rectangle frame1;
        private Rectangle frame2;
        private bool isFrame1 = true;



        public LinkMovingSprite(Direction direction)
        {
            this.direction = direction;
            sheet = LinkSpriteFactory.Instance.GetSpriteSheet();
            setFramesForDirection();
        }


        public void Update()
        {
            frameNum++;
            if (frameNum == maxFrames)
            {
                frameNum = 0;
            }

            // Every set number of frames, determined by the stepSpeed, the next frame of the step will be loaded.
            if ((frameNum % stepSpeed) == 0)
            {
                isFrame1 = !isFrame1;
            }
        }


        public void Draw(SpriteBatch sb, GameTime gt)
        {
            if (isFrame1)
            {
                sb.Draw(sheet, new Rectangle(100, 100, 50, 50), frame1, Color.White);
            } else
            {
                sb.Draw(sheet, new Rectangle(100, 100, 50, 50), frame2, Color.White);
            }
        }


        private void setFramesForDirection()
        {
            switch (direction)
            {
                case Direction.Up:
                    frame1 = backwardSpritesheetLocation_1;
                    frame2 = backwardSpritesheetLocation_2;
                    break;
                case Direction.Down:
                    frame1 = forwardSpritesheetLocation_1;
                    frame2 = forwardSpritesheetLocation_2;
                    break;
                case Direction.Left:
                    frame1 = rightSpritesheetLocation_1;
                    frame2 = rightSpritesheetLocation_2;
                    break;
                case Direction.Right:
                    frame1 = rightSpritesheetLocation_1;
                    frame2 = rightSpritesheetLocation_2;
                    break;
                default:
                    break;
            }
        }
    }
}
