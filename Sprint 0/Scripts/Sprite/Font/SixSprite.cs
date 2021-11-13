using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.Font
{
    class SixSprite : ISprite
    {
        private Texture2D spritesheet;
        private Rectangle frame = SpriteRectangles.fontSixFrame;
        private int scale = ObjectConstants.scale;

        public SixSprite(Texture2D textures)
        {
            spritesheet = textures;
        }

        public void Update(GameTime gt)
        {
            //Should be empty
        }


        public void Draw(SpriteBatch sb, Vector2 location)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale, frame.Height * scale);
            sb.Draw(spritesheet, dest, frame, Color.White);
        }
    }
}
