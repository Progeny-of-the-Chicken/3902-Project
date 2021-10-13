using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite
{
    public class NonAnimatedTreasureSprite : ISprite
    {
        private Texture2D spritesheet;
        private Rectangle frame;
        private int scale = 2;

        public NonAnimatedTreasureSprite(Texture2D textures, Rectangle sourceRec)
        {
            spritesheet = textures;
            frame = sourceRec;
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
