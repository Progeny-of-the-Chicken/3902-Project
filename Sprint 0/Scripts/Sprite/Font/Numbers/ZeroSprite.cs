using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.Font
{
    class ZeroSprite : ISprite
    {
        private Texture2D spritesheet;
        private Rectangle frame = SpriteRectangles.fontZeroFrame;
        private int scale = ObjectConstants.scale;

        public ZeroSprite(Texture2D textures)
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
