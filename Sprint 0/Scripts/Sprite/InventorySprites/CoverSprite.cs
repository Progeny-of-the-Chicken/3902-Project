using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.InventorySprites
{
    public class CoverSprite : ISprite
    {
        private Texture2D spritesheet;
        private Rectangle cover;

        public CoverSprite(Texture2D textures, Rectangle destRec)
        {
            spritesheet = textures;
            cover = destRec;
            cover.Size *= new Point(ObjectConstants.scale);
        }

        public void Update(GameTime gt)
        {
            // No animation
        }

        public void Draw(SpriteBatch sb, Vector2 location)
        {
            cover.Location = location.ToPoint();
            sb.Draw(spritesheet, cover, Color.Black);
        }
    }
}
