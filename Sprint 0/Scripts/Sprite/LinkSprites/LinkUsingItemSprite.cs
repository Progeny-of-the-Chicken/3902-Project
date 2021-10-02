using System;
using Sprint_0.Scripts.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.LinkSprites
{
    public class LinkUsingItemSprite: ISprite
    {
        private Texture2D sheet;
        private Rectangle UsingItemDownSource = new Rectangle(107, 11, 16, 16);
        private Rectangle UsingItemLeftSource = new Rectangle(124, 12, 16, 16);
        private Rectangle UsingItemUpSource = new Rectangle(141, 11, 16, 16);
        private Direction direction;
        private Rectangle frame;
        private Vector2 position;
        private const int standardWidthHeight = 48;

        public LinkUsingItemSprite(LinkStateMachine state)
        {
            this.position = state.Position;
            this.direction = state.FacingDirection;
            sheet = LinkSpriteFactory.Instance.GetSpriteSheet();
            setFramesForDirection();
        }


        public void Update()
        {
            //No Update
        }


        public void Draw(SpriteBatch sb, GameTime gt)
        {
            if (direction == Direction.Left)
                sb.Draw(sheet, new Rectangle((int)position.X, (int)position.Y, 48, standardWidthHeight), frame, Color.White, 0, new Vector2(), SpriteEffects.FlipHorizontally, 0);
            else
                sb.Draw(sheet, new Rectangle((int)position.X, (int)position.Y, standardWidthHeight, standardWidthHeight), frame, Color.White);
        }

        

    private void setFramesForDirection()
    {
        switch (direction)
        {
            case Direction.Up:
                frame = UsingItemUpSource;
                break;
            case Direction.Down:
                frame = UsingItemDownSource;
                break;
            case Direction.Left:
            case Direction.Right:
                frame = UsingItemLeftSource;
                break;
            default:
                break;
        }
    }
}
}
