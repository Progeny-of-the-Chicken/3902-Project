using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.LinkSprites
{
    public class LinkUsingItemSprite : ISprite
    {
        private Texture2D sheet;
        private FacingDirection direction;
        private Rectangle frame;

        public LinkUsingItemSprite(LinkStateMachine state)
        {
            this.direction = state.FacingDirection;
            sheet = LinkSpriteFactory.Instance.GetBaseSpriteSheet();
            setFramesForDirection();
        }

        public void Update(GameTime gt)
        {
            //No Update
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
                    frame = SpriteRectangles.linkUsingItemUpFrame;
                    break;
                case FacingDirection.Down:
                    frame = SpriteRectangles.linkUsingItemDownFrame;
                    break;
                case FacingDirection.Left:
                case FacingDirection.Right:
                    frame = SpriteRectangles.linkUsingItemRightFrame;
                    break;
                default:
                    break;
            }
        }
    }
}
