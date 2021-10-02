using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint_0.Scripts.Sprite.LinkSprites
{
    public class LinkTakingDamageSprite: ISprite
    {
        private Texture2D sheet;

        private Rectangle forwardSpritesheetLocation = new Rectangle(1, 11, 15, 16);
        private Rectangle rightSpritesheetLocation = new Rectangle(34, 11, 16, 16);
        private Rectangle backwardSpritesheetLocation = new Rectangle(70, 11, 15, 16);
        private Rectangle frame;
        private Vector2 position;
        private Direction direction;
        private int colorCounter;
        private Color randColor;
        private Random rand = new Random();
        private const int standardWidthHeight = 48;


        public LinkTakingDamageSprite(LinkStateMachine state)
        {
            position = state.Position;
            this.direction = state.FacingDirection;
            sheet = LinkSpriteFactory.Instance.GetSpriteSheet();
            setFramesForDirection();
            colorCounter = 0;
        }


        public void Update()
        {
            colorCounter++;
            if (colorCounter % 5 == 0)
                randColor = new Color(128 + rand.Next(128), 128 + rand.Next(128), 128 + rand.Next(128));

        }


        public void Draw(SpriteBatch sb, GameTime gt)
        {
            if(direction == Direction.Left)
                sb.Draw(sheet, new Rectangle((int)position.X, (int)position.Y, standardWidthHeight, standardWidthHeight), frame, randColor, 0, new Vector2(), SpriteEffects.FlipHorizontally, 0);
            else
                sb.Draw(sheet, new Rectangle((int)position.X, (int)position.Y, standardWidthHeight, standardWidthHeight), frame, randColor);
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
                case Direction.Right:
                    frame = rightSpritesheetLocation;
                    break;
                default:
                    break;
            }
        }
    }
}
