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
        private Rectangle rightSpritesheetLocation_1 = new Rectangle(34, 11, 16, 16);
        private Rectangle rightSpritesheetLocation_2 = new Rectangle(51, 12, 16, 16);
        private Rectangle backwardSpritesheetLocation_1 = new Rectangle(70, 11, 15, 16);
        private Rectangle backwardSpritesheetLocation_2 = new Rectangle(87, 11, 15, 16);

        private FacingDirection direction;
        private LinkStateMachine state;
        int x;
        int y;

        private int stepSpeed = 5; // Lower is faster
        private int frameNum = 0;
        private int maxFrames = 30;
        private Rectangle frame1;
        private Rectangle frame2;
        private bool isFrame1 = true;

        private int pixel = 3;
        private int standardWidthHeight; // Defined by pixel


        public LinkMovingSprite(LinkStateMachine state)
        {
            standardWidthHeight = 16 * pixel;
            this.state = state;
            this.direction = state.FacingDirection;
            sheet = LinkSpriteFactory.Instance.GetSpriteSheet();
            setFramesForDirection();
        }


        public void Update(GameTime gt)
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

            x = (int)state.Position.X;
            y = (int)state.Position.Y;
        }


        public void Draw(SpriteBatch sb, Vector2 loc)
        { 
            if (isFrame1)
            {
                drawFrame1(sb);
            } else
            {
                drawFrame2(sb);
            }
        }




        /*------------------------- Helper methods -------------------------*/

        private void drawFrame1(SpriteBatch sb)
        {
            switch (direction)
            {
                case FacingDirection.Left:
                    int offsetX = x;

                    sb.Draw(sheet, new Rectangle(offsetX, y, standardWidthHeight, standardWidthHeight), frame1, Color.White, 0, new Vector2(), SpriteEffects.FlipHorizontally, 0);
                    break;
                default:
                    sb.Draw(sheet, new Rectangle(x, y, standardWidthHeight, standardWidthHeight), frame1, Color.White);
                    break;
            }
        }

        private void drawFrame2(SpriteBatch sb)
        {
            switch (direction)
            {
                case FacingDirection.Left:
                    sb.Draw(sheet, new Rectangle(x, y, standardWidthHeight, standardWidthHeight), frame2, Color.White, 0, new Vector2(), SpriteEffects.FlipHorizontally, 0);
                    break;
                case FacingDirection.Down:
                    int offsetX = x + pixel;

                    sb.Draw(sheet, new Rectangle(offsetX, y, standardWidthHeight, standardWidthHeight), frame2, Color.White);
                    break;
                default:
                    sb.Draw(sheet, new Rectangle(x, y, standardWidthHeight, standardWidthHeight), frame2, Color.White);
                    break;
            }
        }

        private void setFramesForDirection()
        {
            switch (direction)
            {
                case FacingDirection.Up:
                    frame1 = backwardSpritesheetLocation_1;
                    frame2 = backwardSpritesheetLocation_2;
                    break;
                case FacingDirection.Down:
                    frame1 = forwardSpritesheetLocation_1;
                    frame2 = forwardSpritesheetLocation_2;
                    break;
                case FacingDirection.Left:
                    frame1 = rightSpritesheetLocation_1;
                    frame2 = rightSpritesheetLocation_2;
                    break;
                case FacingDirection.Right:
                    frame1 = rightSpritesheetLocation_1;
                    frame2 = rightSpritesheetLocation_2;
                    break;
                default:
                    break;
            }
        }
    }
}
