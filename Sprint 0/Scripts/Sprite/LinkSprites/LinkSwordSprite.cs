using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.SpriteFactories;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts
{
    public class LinkSwordSprite : ISprite
    {
        private Texture2D sheet;
        private Rectangle destinationPos;
        private Rectangle[] linkSwordFrames;
        private Rectangle currentFrame;
        private FacingDirection direction;
        private Vector2 position;
        private int animateSwordCounter;

        public LinkSwordSprite(LinkStateMachine linkState)
        {
            this.direction = linkState.FacingDirection;
            animateSwordCounter = ObjectConstants.defaultCounterLength;
            this.position = linkState.Position;
            sheet = LinkSpriteFactory.Instance.GetBaseSpriteSheet();
            setFramesBasedOnDirection();
        }

        //we will need to set the destination dynamically because of the left and right sprites position on the sprite sheet
        private void setDestinationSizeBasedOnDirection()
        {
            switch (direction)
            {
                case FacingDirection.Left:
                    destinationPos = new Rectangle((int)position.X - currentFrame.Width * ObjectConstants.scale + ObjectConstants.scaledStdWidthHeight, (int)position.Y, currentFrame.Width * ObjectConstants.scale, ObjectConstants.scaledStdWidthHeight);
                    break;
                case FacingDirection.Right:
                    destinationPos = new Rectangle((int)position.X, (int)position.Y, currentFrame.Width * ObjectConstants.scale, ObjectConstants.scaledStdWidthHeight);
                    break;
                case FacingDirection.Up:
                    destinationPos = new Rectangle((int)position.X, (int)position.Y - currentFrame.Height * ObjectConstants.scale + ObjectConstants.scaledStdWidthHeight, ObjectConstants.scaledStdWidthHeight, currentFrame.Height * ObjectConstants.scale);
                    break;
                case FacingDirection.Down:
                    destinationPos = new Rectangle((int)position.X, (int)position.Y, ObjectConstants.scaledStdWidthHeight, currentFrame.Height * ObjectConstants.scale);
                    break;
            }
        }

        private void setFramesBasedOnDirection()
        {
            switch (direction)
            {
                case FacingDirection.Left:
                case FacingDirection.Right:
                    linkSwordFrames = SpriteRectangles.linkSwordFramesRight;
                    break;
                case FacingDirection.Down:
                    linkSwordFrames = SpriteRectangles.linkSwordFramesDown;
                    break;
                case FacingDirection.Up:
                    linkSwordFrames = SpriteRectangles.linkSwordFramesUp;
                    break;
                default:
                    break;
            }
        }

        private void setCurrentFrame()
        {
            currentFrame = linkSwordFrames[linkSwordFrames.Length * animateSwordCounter / ObjectConstants.defaultCounterLength];
        }

        public void Draw(SpriteBatch sb, Vector2 loc)
        {
            if (direction == FacingDirection.Left)

                sb.Draw(sheet, destinationPos, currentFrame, Color.White, ObjectConstants.zeroRotation, new Vector2(), SpriteEffects.FlipHorizontally, ObjectConstants.noLayerDepth);
            else
                sb.Draw(sheet, destinationPos, currentFrame, Color.White);
        }

        public void Update(GameTime gt)
        {
            animateSwordCounter++;
            animateSwordCounter %= ObjectConstants.defaultCounterLength;

            setCurrentFrame();

            setDestinationSizeBasedOnDirection();
        }
    }
}
