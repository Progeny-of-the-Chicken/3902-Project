using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint_0.Scripts.Sprite.LinkSprites
{
    public class LinkDeathSprite : ISprite
    {
        private Texture2D sheet;

        private Rectangle forwardSpritesheetLocation = new Rectangle(1, 11, 15, 16);
        private Rectangle rightSpritesheetLocation = new Rectangle(34, 11, 16, 16);
        private Rectangle backwardSpritesheetLocation = new Rectangle(70, 11, 15, 16);
        private Rectangle frame;
        private Vector2 position;
        private FacingDirection direction;
        private int animationCounter;
        private Color randColor;
        private Random rand = new Random();
        private const int standardWidthHeight = 48;


        public LinkDeathSprite(LinkStateMachine state)
        {
            position = state.Position;
            this.direction = FacingDirection.Down;
            sheet = LinkSpriteFactory.Instance.GetSpriteSheet();
            SetFramesForDirection();
            animationCounter = 0;
        }


        public void Update(GameTime gt)
        {
            animationCounter++;
            if(animationCounter < 30)
            {
                if (animationCounter % 5 == 0)
                    randColor = new Color(128 + rand.Next(128), 128 + rand.Next(128), 128 + rand.Next(128));
            }
            else
            {
                randColor = Color.White;
                if (animationCounter % 5 == 0)
                    SetNewDirection();
            }

        }


        public void Draw(SpriteBatch sb, Vector2 loc)
        {
            if (direction == FacingDirection.Left)
                sb.Draw(sheet, new Rectangle((int)position.X, (int)position.Y, standardWidthHeight, standardWidthHeight), frame, randColor, 0, new Vector2(), SpriteEffects.FlipHorizontally, 0);
            else
                sb.Draw(sheet, new Rectangle((int)position.X, (int)position.Y, standardWidthHeight, standardWidthHeight), frame, randColor);
        }

        private void SetNewDirection()
        {
            FacingDirection newDirection = FacingDirection.Down;
            switch (direction)
            {
                case FacingDirection.Down:
                    newDirection = FacingDirection.Left;
                    break;
                case FacingDirection.Left:
                    newDirection = FacingDirection.Right;
                    break;
                case FacingDirection.Right:
                    newDirection = FacingDirection.Down;
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
                    frame = forwardSpritesheetLocation;
                    break;
                case FacingDirection.Left:
                case FacingDirection.Right:
                    frame = rightSpritesheetLocation;
                    break;
                default:
                    break;
            }
        }
    }
}
