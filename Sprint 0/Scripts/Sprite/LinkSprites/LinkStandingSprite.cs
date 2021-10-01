using System;
using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.LinkSprites
{
    public class LinkStandingSprite: ISprite
    {
        private Texture2D sheet;

        private Rectangle forwardSpritesheetLocation = new Rectangle(1, 11, 15, 16);
        private Rectangle rightSpritesheetLocation = new Rectangle(34, 11, 16, 16);
        private Rectangle backwardSpritesheetLocation = new Rectangle(70, 11, 15, 16);
        private Rectangle frame;
        private Vector2 position;
        private Direction direction;
        private Rectangle destination;

        private int pixel = 3;
        private int standardWidthHeight; // Defined by pixel


        public LinkStandingSprite(LinkStateMachine state)
        {
            standardWidthHeight = 16 * pixel;
            position = state.Position;
            this.direction = state.FacingDirection;
            sheet = LinkSpriteFactory.Instance.GetSpriteSheet();
            setFramesForDirection();
        }


        public void Update()
        {
            //just standing no need to update
        }


        public void Draw(SpriteBatch sb, GameTime gt)
        {
            if(direction == Direction.Left)
                sb.Draw(sheet, new Rectangle((int)position.X, (int)position.Y, standardWidthHeight, standardWidthHeight), frame, Color.White, 0, new Vector2(), SpriteEffects.FlipHorizontally, 0);
            else
                sb.Draw(sheet, new Rectangle((int)position.X, (int)position.Y, standardWidthHeight, standardWidthHeight), frame, Color.White);
        }

        private void setFramesForDirection()
        {
            switch (direction)
            {
                case Direction.Up:
                    frame = backwardSpritesheetLocation;
                    break;
                case Direction.Down:
                    frame = forwardSpritesheetLocation;
                    break;
                case Direction.Left:
                    frame = rightSpritesheetLocation;
                    break;
                case Direction.Right:
                    frame = rightSpritesheetLocation;
                    break;
                default:
                    break;
            }
        }
    }
}
