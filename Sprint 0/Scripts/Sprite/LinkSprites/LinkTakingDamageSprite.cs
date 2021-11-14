using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint_0.Scripts.Sprite.LinkSprites
{
    public class LinkTakingDamageSprite : ISprite
    {
        private Texture2D sheet;
        private Rectangle frame;
        private FacingDirection direction;
        private int colorCounter;
        private Color randColor;
        private Random rand = new Random();


        public LinkTakingDamageSprite(LinkStateMachine state)
        {
            this.direction = state.FacingDirection;
            sheet = LinkSpriteFactory.Instance.GetSpriteSheet();
            setFramesForDirection();
            colorCounter = ObjectConstants.counterInitialVal_int;
        }


        public void Update(GameTime gt)
        {
            colorCounter++;
            if (colorCounter % ObjectConstants.oneInFive == ObjectConstants.zero_int)
                randColor = new Color(RandomRGB() + rand.Next(RandomRGB()), RandomRGB() + rand.Next(RandomRGB()), RandomRGB() + rand.Next(RandomRGB()));

        }

        private int RandomRGB()
        {
            return ObjectConstants.rgbHalfOfMax + rand.Next(ObjectConstants.rgbHalfOfMax);
        }

        public void Draw(SpriteBatch sb, Vector2 loc)
        {
            if (direction == FacingDirection.Left)
                sb.Draw(sheet, new Rectangle((int)loc.X, (int)loc.Y, ObjectConstants.scaledStdWidthHeight, ObjectConstants.scaledStdWidthHeight), frame, randColor, ObjectConstants.zeroRotation, new Vector2(), SpriteEffects.FlipHorizontally, ObjectConstants.noLayerDepth);
            else
                sb.Draw(sheet, new Rectangle((int)loc.X, (int)loc.Y, ObjectConstants.scaledStdWidthHeight, ObjectConstants.scaledStdWidthHeight), frame, randColor);
        }

        private void setFramesForDirection()
        {
            switch (direction)
            {
                case FacingDirection.Down:
                    frame = SpriteRectangles.linkForwardSpritesheetLocation_1;
                    break;
                case FacingDirection.Left:
                case FacingDirection.Right:
                    frame = SpriteRectangles.linkRightSpritesheetLocation_1;
                    break;
                case FacingDirection.Up:
                    frame = SpriteRectangles.linkBackwardSpritesheetLocation_1;
                    break;
                default:
                    break;
            }
        }
    }
}
