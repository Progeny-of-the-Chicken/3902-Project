using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.ProjectileSprites
{
    public class SwordAttackHitboxSprite : ISprite
    {
        private Texture2D spritesheet;
        private Rectangle frame = new Rectangle(360, 324, 11, 3);
        private int scale = 2;

        private double rotation;

        public SwordAttackHitboxSprite(Texture2D textures, FacingDirection direction)
        {
            // Transparent, frame is empty
            spritesheet = textures;
            switch (direction)
            {
                case FacingDirection.Right:
                    rotation = 0.0;
                    break;
                case FacingDirection.Up:
                    rotation = Math.PI / 2;
                    break;
                case FacingDirection.Left:
                    rotation = Math.PI;
                    break;
                case FacingDirection.Down:
                    rotation = 3 * Math.PI / 2;
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
            sb.Draw(spritesheet, dest, frame, Color.White, (float)rotation, new Vector2(0, 0), SpriteEffects.None, 0);
        }
    }
}
