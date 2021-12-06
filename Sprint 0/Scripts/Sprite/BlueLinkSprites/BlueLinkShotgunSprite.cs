using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.SpriteFactories;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts
{
    public class BlueLinkShotgunSprite : ISprite
    {
        private Texture2D sheet;
        private Rectangle destinationPos;
        private Rectangle[] linkShotgunFrames;
        private Rectangle currentFrame;
        private FacingDirection direction;
        private Vector2 position;
        private int animateShotgunCounter;

        public BlueLinkShotgunSprite(LinkStateMachine linkState)
        {
            this.direction = linkState.FacingDirection;
            animateShotgunCounter = ObjectConstants.defaultCounterLength;
            this.position = linkState.Position;
            sheet = LinkSpriteFactory.Instance.GetBlueShotgunSpriteSheet();
            setFramesBasedOnDirection();
        }

        //we will need to set the destination dynamically because of the left and right sprites position on the sprite sheet
        private void setDestinationSizeBasedOnDirection()
        {
            switch (direction)
            {
                case FacingDirection.Left:
                    destinationPos = new Rectangle((int)position.X - currentFrame.Width * ObjectConstants.scale + ObjectConstants.scaledStdWidthHeight, (int)position.Y, currentFrame.Width * ObjectConstants.scale, currentFrame.Height * ObjectConstants.scale);
                    break;
                case FacingDirection.Right:
                    destinationPos = new Rectangle((int)position.X, (int)position.Y, currentFrame.Width * ObjectConstants.scale, currentFrame.Height * ObjectConstants.scale);
                    break;
                case FacingDirection.Up:
                    destinationPos = new Rectangle((int)position.X, (int)position.Y - currentFrame.Height * ObjectConstants.scale + ObjectConstants.scaledStdWidthHeight, currentFrame.Width * ObjectConstants.scale, currentFrame.Height * ObjectConstants.scale);
                    break;
                case FacingDirection.Down:
                    destinationPos = new Rectangle((int)position.X, (int)position.Y, currentFrame.Width * ObjectConstants.scale, currentFrame.Height * ObjectConstants.scale);
                    break;
            }
        }

        private void setFramesBasedOnDirection()
        {
            switch (direction)
            {
                case FacingDirection.Left:
                case FacingDirection.Right:
                    linkShotgunFrames = SpriteRectangles.linkShotgunFramesRight;
                    break;
                case FacingDirection.Down:
                    linkShotgunFrames = SpriteRectangles.linkShotgunFramesDown;
                    break;
                case FacingDirection.Up:
                    linkShotgunFrames = SpriteRectangles.linkShotgunFramesUp;
                    break;
                default:
                    break;
            }
        }

        private void setCurrentFrame()
        {
            currentFrame = linkShotgunFrames[linkShotgunFrames.Length * animateShotgunCounter / ObjectConstants.defaultCounterLength];
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
            animateShotgunCounter++;
            animateShotgunCounter %= ObjectConstants.defaultCounterLength;

            setCurrentFrame();

            setDestinationSizeBasedOnDirection();
        }
    }
}
