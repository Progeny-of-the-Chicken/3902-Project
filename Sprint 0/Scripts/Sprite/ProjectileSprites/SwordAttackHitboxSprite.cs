using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.ProjectileSprites
{
    public class SwordAttackHitboxSprite : ISprite
    {
        private Texture2D spritesheet;
        private Rectangle frame = new Rectangle(360, 324, 11, 3);
        private int scale = 2;

        public SwordAttackHitboxSprite(Texture2D textures)
        {
            // Transparent, frame is empty
            spritesheet = textures;
        }

        public void Update(GameTime gt)
        {
            // No animation
        }

        public void Draw(SpriteBatch sb, Vector2 location)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            sb.Draw(spritesheet, dest, frame, Color.White);
        }
    }
}
