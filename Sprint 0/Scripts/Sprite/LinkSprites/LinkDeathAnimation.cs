using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint_0.Scripts.Sprite.LinkSprites
{
    public class LinkDeathSprite : ISprite
    {
        private Texture2D sheet;
        private Rectangle frame;
        private Vector2 position;
        private FacingDirection direction;
        private float animationCounter;
        private float changeFrameCounter;
        private Color randColor;
        private Random rand = new Random();

        public LinkDeathSprite(LinkStateMachine state)
        {
            position = state.Position;
            this.direction = FacingDirection.Down;
            sheet = LinkSpriteFactory.Instance.GetSpriteSheet();
            SetFramesForDirection();
            animationCounter = ObjectConstants.counterInitialVal_float;
            changeFrameCounter = ObjectConstants.counterInitialVal_float;
        }


        public void Update(GameTime gt)
        {
            float dt = (float)gt.ElapsedGameTime.TotalSeconds;
            animationCounter += dt;
            changeFrameCounter += dt;
            bool changeFrame = changeFrameCounter > ObjectConstants.linkFrameChangeFreq;
            randColor = Color.White;
            if (changeFrame)
            {
                changeFrameCounter = ObjectConstants.counterInitialVal_float;
                if (animationCounter < ObjectConstants.linkTakeDamageTime)
                    randColor = new Color(RandomRGB(), RandomRGB(), RandomRGB());
                else
                    SetNewDirection();
            }
        }

        private int RandomRGB()
        {
            return ObjectConstants.rgbHalfOfMax + rand.Next(ObjectConstants.rgbHalfOfMax);
        }

        public void Draw(SpriteBatch sb, Vector2 loc)
        {
            if (direction == FacingDirection.Left)
                sb.Draw(sheet, new Rectangle((int)position.X, (int)position.Y, ObjectConstants.scaledStdWidthHeight, ObjectConstants.scaledStdWidthHeight), frame, randColor, ObjectConstants.zeroRotation, new Vector2(), SpriteEffects.FlipHorizontally, ObjectConstants.noLayerDepth);
            else
                sb.Draw(sheet, new Rectangle((int)position.X, (int)position.Y, ObjectConstants.scaledStdWidthHeight, ObjectConstants.scaledStdWidthHeight), frame, randColor);
        }

        private void SetNewDirection()
        {
            FacingDirection newDirection = FacingDirection.Down;
            switch (direction)
            {
                case FacingDirection.Down:
                    newDirection = FacingDirection.Right;
                    break;
                case FacingDirection.Left:
                    newDirection = FacingDirection.Down;
                    break;
                case FacingDirection.Right:
                    newDirection = FacingDirection.Up;
                    break;
                case FacingDirection.Up:
                    newDirection = FacingDirection.Left;
                    break;
                default:
                    break;
            }
            direction = newDirection;
            SetFramesForDirection();
        }

        private void SetFramesForDirection()
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
