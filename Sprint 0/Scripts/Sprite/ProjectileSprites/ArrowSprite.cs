using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.ProjectileSprites
{
    public class ArrowSprite : ISprite
    {
        private Texture2D spritesheet;
        private Rectangle frame;
        private double rotation;
        private Vector2 rotationOffset = new Vector2(8, 2.5f);
        private int scale = 2;

        public ArrowSprite(Texture2D textures, FacingDirection direction, bool silver)
        {
            spritesheet = textures;
            if (!silver)
            {
                frame = new Rectangle(10, 190, 16, 5);
            }
            else
            {
                frame = new Rectangle(36, 190, 16, 5);
            }
            switch (direction)
            {
                case FacingDirection.Right:
                    rotation = 0;
                    break;
                case FacingDirection.Up:
                    rotation = (3 * Math.PI) / 2;
                    break;
                case FacingDirection.Left:
                    rotation = Math.PI;
                    break;
                case FacingDirection.Down:
                    rotation = Math.PI / 2;
                    break;
                default:
                    break;
            }
        }

        public void Update(GameTime gt)
        {
            // No animation
        }

        public void Draw(SpriteBatch sb, Vector2 location)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            sb.Draw(spritesheet, dest, frame, Color.White, (float)rotation, rotationOffset, SpriteEffects.None, 0);
        }
    }
}
