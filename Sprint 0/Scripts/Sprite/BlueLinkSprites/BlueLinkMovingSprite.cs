using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.LinkSprites
{
    public class BlueLinkMovingSprite : ISprite
    {
        private Texture2D sheet;
        private FacingDirection direction;
        private LinkStateMachine state;
        int x;
        int y;
        private float changeFrameCounter;
        private Rectangle frame1;
        private Rectangle frame2;
        private bool isFrame1 = true;

        public BlueLinkMovingSprite(LinkStateMachine state)
        {
            this.state = state;
            this.direction = state.FacingDirection;
            sheet = LinkSpriteFactory.Instance.GetBlueSpriteSheet();
            setFramesForDirection();
            changeFrameCounter = ObjectConstants.counterInitialVal_float;
        }

        public void Update(GameTime gt)
        {
            float dt = (float)gt.ElapsedGameTime.TotalSeconds;
            changeFrameCounter += dt;
            bool changeFrame = changeFrameCounter > ObjectConstants.linkFrameChangeFreq;
            if (changeFrame)
            {
                changeFrameCounter = ObjectConstants.counterInitialVal_float;
                isFrame1 = !isFrame1;

            }
            x = (int)state.Position.X;
            y = (int)state.Position.Y;
        }

        //TODO: should draw and update according to links location
        public void Draw(SpriteBatch sb, Vector2 loc)
        {
            if (isFrame1)
            {
                drawFrame1(sb);
            }
            else
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

                    sb.Draw(sheet, new Rectangle(offsetX, y, ObjectConstants.scaledStdWidthHeight, ObjectConstants.scaledStdWidthHeight), frame1, Color.White, ObjectConstants.zeroRotation, new Vector2(), SpriteEffects.FlipHorizontally, ObjectConstants.noLayerDepth);
                    break;
                default:
                    sb.Draw(sheet, new Rectangle(x, y, ObjectConstants.scaledStdWidthHeight, ObjectConstants.scaledStdWidthHeight), frame1, Color.White);
                    break;
            }
        }

        private void drawFrame2(SpriteBatch sb)
        {
            switch (direction)
            {
                case FacingDirection.Left:
                    sb.Draw(sheet, new Rectangle(x, y, ObjectConstants.scaledStdWidthHeight, ObjectConstants.scaledStdWidthHeight), frame2, Color.White, ObjectConstants.zeroRotation, new Vector2(), SpriteEffects.FlipHorizontally, ObjectConstants.noLayerDepth);
                    break;
                case FacingDirection.Down:
                    int offsetX = x + ObjectConstants.scale;
                    sb.Draw(sheet, new Rectangle(offsetX, y, ObjectConstants.scaledStdWidthHeight, ObjectConstants.scaledStdWidthHeight), frame2, Color.White);
                    break;
                default:
                    sb.Draw(sheet, new Rectangle(x, y, ObjectConstants.scaledStdWidthHeight, ObjectConstants.scaledStdWidthHeight), frame2, Color.White);
                    break;
            }
        }

        private void setFramesForDirection()
        {
            switch (direction)
            {
                case FacingDirection.Up:
                    frame1 = SpriteRectangles.linkBackwardSpritesheetLocation_1;
                    frame2 = SpriteRectangles.linkBackwardSpritesheetLocation_2;
                    break;
                case FacingDirection.Down:
                    frame1 = SpriteRectangles.linkForwardSpritesheetLocation_1;
                    frame2 = SpriteRectangles.linkForwardSpritesheetLocation_2;
                    break;
                case FacingDirection.Left:
                case FacingDirection.Right:
                    frame1 = SpriteRectangles.linkRightSpritesheetLocation_1;
                    frame2 = SpriteRectangles.linkRightSpritesheetLocation_2;
                    break;
                default:
                    break;
            }
        }
    }
}
