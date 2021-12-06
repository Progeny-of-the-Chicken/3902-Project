using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.ProjectileSprites
{
    public class ShotgunPelletSprite : ISprite
    {
        private Texture2D spritesheet;
        private Rectangle frame;
        private double rotation;
        private int scale = ObjectConstants.scale;

        public ShotgunPelletSprite(Texture2D textures, FacingDirection direction)
        {
            spritesheet = textures;
            frame = SpriteRectangles.shotgunPelletProjectileFrame;
            switch (direction)
            {
                case FacingDirection.Right:
                    rotation = ObjectConstants.degreeRotationCW270_s;
                    break;
                case FacingDirection.Up:
                    rotation = ObjectConstants.degreeRotationCW180_s;
                    break;
                case FacingDirection.Left:
                    rotation = ObjectConstants.degreeRotationCW90_s;
                    break;
                case FacingDirection.Down:
                    rotation = ObjectConstants.zeroRotation;
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
