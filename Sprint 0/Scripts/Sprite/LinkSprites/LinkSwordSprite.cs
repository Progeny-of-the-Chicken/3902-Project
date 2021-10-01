using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts
{
    public class LinkSwordSprite : ISprite
    {
        private Texture2D sheet;
        private Rectangle destinationPos;
        private Rectangle linkSwordFrame1;
        private Rectangle linkSwordFrame2;
        private Rectangle linkSwordFrame3;
        private Rectangle linkSwordFrame4;
        private Rectangle currentFrame;
        private Direction direction;
        private Vector2 position;
        private int animateSwordCounter;

        public LinkSwordSprite(LinkStateMachine linkState)
        {
            this.direction = linkState.FacingDirection;
            animateSwordCounter = 30;
            this.position = linkState.Position;
            sheet = LinkSpriteFactory.Instance.GetSpriteSheet();
            setFramesBasedOnDirection();
        }

        //we will need to set the destination dynamically because of the left and right sprites position on the sprite sheet
        private void setDestinationSizeBasedOnDirection()
        {
            switch (direction)
            {
                case Direction.Left:
                    destinationPos = new Rectangle((int)position.X - currentFrame.Width * 3 + 48, (int)position.Y, currentFrame.Width * 3, 48);
                    break;
                case Direction.Right:
                    destinationPos = new Rectangle((int)position.X, (int)position.Y, currentFrame.Width * 3, 48);
                    break;
                case Direction.Up:
                    destinationPos = new Rectangle((int)position.X, (int)position.Y - currentFrame.Height * 3 + 48, 48, currentFrame.Height * 3);
                    break;
                case Direction.Down:
                    destinationPos = new Rectangle((int)position.X, (int)position.Y, 48, currentFrame.Height * 3);
                    break;
            }
        }

        private void setFramesBasedOnDirection()
        {
            switch (direction)
            {
                case Direction.Left:
                    linkSwordFrame1 = new Rectangle(0, 77, 16, 16);
                    linkSwordFrame2 = new Rectangle(18, 77, 27, 16);
                    linkSwordFrame3 = new Rectangle(46, 77, 24, 16);
                    linkSwordFrame4 = new Rectangle(69, 77, 16, 16);
                    break;
                case Direction.Right:
                    linkSwordFrame1 = new Rectangle(0, 77, 16, 16);
                    linkSwordFrame2 = new Rectangle(18, 77, 27, 16);
                    linkSwordFrame3 = new Rectangle(46, 77, 24, 16);
                    linkSwordFrame4 = new Rectangle(69, 77, 16, 16);
                    break;
                case Direction.Up:
                    linkSwordFrame1 = new Rectangle(1, 108, 16, 18);
                    linkSwordFrame2 = new Rectangle(18, 97, 16, 29);
                    linkSwordFrame3 = new Rectangle(37, 97, 16, 29);
                    linkSwordFrame4 = new Rectangle(54, 108, 16, 18);
                    break;
                case Direction.Down:
                    linkSwordFrame1 = new Rectangle(1, 47, 16, 18);
                    linkSwordFrame2 = new Rectangle(18, 47, 16, 29);
                    linkSwordFrame3 = new Rectangle(35, 47, 16, 29);
                    linkSwordFrame4 = new Rectangle(53, 47, 16, 18);
                    break;
            }
        }

        private void setCurrentFrame()
        {
            switch (animateSwordCounter)
            {
                case int f when (f <= 7):
                    currentFrame = linkSwordFrame1;
                    break;
                case int f when (f <= 15 && f > 7):
                    currentFrame = linkSwordFrame2;
                    break;
                case int f when (f <= 24 && f > 15):
                    currentFrame = linkSwordFrame3;
                    break;
                case int f when (f < 30 && f > 24):
                    currentFrame = linkSwordFrame4;
                    break;
            }
        }

        public void Draw(SpriteBatch sb, GameTime gt)
        {
            if (direction == Direction.Left)
            
                sb.Draw(sheet, destinationPos, currentFrame, Color.White, 0, new Vector2(), SpriteEffects.FlipHorizontally, 0);
            else
                sb.Draw(sheet, destinationPos, currentFrame, Color.White);
        }

        public void Update()
        {
            animateSwordCounter++;
            animateSwordCounter %= 30;

            setCurrentFrame();

            setDestinationSizeBasedOnDirection();
        }
    }
}
