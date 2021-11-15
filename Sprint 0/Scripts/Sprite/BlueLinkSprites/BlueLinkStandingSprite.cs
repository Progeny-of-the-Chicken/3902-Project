using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.LinkSprites
{
    public class BlueLinkStandingSprite : ISprite
    {
        private Texture2D sheet;
        private Rectangle frame;
        private FacingDirection direction;

        public BlueLinkStandingSprite(LinkStateMachine state)
        {
            this.direction = state.FacingDirection;
            sheet = LinkSpriteFactory.Instance.GetBlueSpriteSheet();
            setFramesForDirection();
        }

        public void Update(GameTime gt)
        {
            //just standing no need to update
        }

        public void Draw(SpriteBatch sb, Vector2 loc)
        {
            if (direction == FacingDirection.Left)
                sb.Draw(sheet, new Rectangle((int)loc.X, (int)loc.Y, ObjectConstants.scaledStdWidthHeight, ObjectConstants.scaledStdWidthHeight), frame, Color.White, ObjectConstants.zeroRotation, new Vector2(), SpriteEffects.FlipHorizontally, ObjectConstants.noLayerDepth);
            else
                sb.Draw(sheet, new Rectangle((int)loc.X, (int)loc.Y, ObjectConstants.scaledStdWidthHeight, ObjectConstants.scaledStdWidthHeight), frame, Color.White);
        }

        private void setFramesForDirection()
        {
            switch (direction)
            {
                case FacingDirection.Up:
                    frame = SpriteRectangles.linkBackwardSpritesheetLocation_1;
                    break;
                case FacingDirection.Down:
                    frame = SpriteRectangles.linkForwardSpritesheetLocation_1;
                    break;
                case FacingDirection.Left:
                case FacingDirection.Right:
                    frame = SpriteRectangles.linkRightSpritesheetLocation_1;
                    break;
                default:
                    break;
            }
        }
    }
}
