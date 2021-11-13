using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.ProjectileSprites
{
    public class ArrowSprite : ISprite
    {
        private Texture2D spritesheet;
        private Rectangle frame;
        private double rotation;
        private int scale = ObjectConstants.scale;

        public ArrowSprite(Texture2D textures, FacingDirection direction, bool silver)
        {
            spritesheet = textures;
            if (!silver)
            {
                frame = SpriteRectangles.basicArrowFrame;
            }
            else
            {
                frame = SpriteRectangles.silverArrowFrame;
            }
            switch (direction)
            {
                case FacingDirection.Right:
                    rotation = ObjectConstants.zeroRotation;
                    break;
                case FacingDirection.Up:
                    rotation = ObjectConstants.degreeRotationCW270_s;
                    break;
                case FacingDirection.Left:
                    rotation = ObjectConstants.degreeRotationCW180_s;
                    break;
                case FacingDirection.Down:
                    rotation = ObjectConstants.degreeRotationCW90_s;
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
            sb.Draw(spritesheet, dest, frame, Color.White, (float)rotation, ObjectConstants.arrowRotationOffset, SpriteEffects.None, ObjectConstants.noLayerDepth);
        }
    }
}
