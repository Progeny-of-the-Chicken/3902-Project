using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.InventorySprites
{
    public class MapColorCoverSprite : ISprite
    {
        private Texture2D spritesheet;
        private Rectangle frame = SpriteRectangles.mapColorCoverSpriteFrame;
        private int scale = ObjectConstants.scale;
        private int scaleToMap = ObjectConstants.mapColorCoverWidthHeightScale;

        public MapColorCoverSprite(Texture2D textures)
        {
            spritesheet = textures;
        }

        public void Update(GameTime gt)
        {
            // No animation
        }

        public void Draw(SpriteBatch sb, Vector2 location)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, frame.Width * scale * scaleToMap, frame.Height * scale * scaleToMap);
            sb.Draw(spritesheet, dest, frame, Color.White);
        }
    }
}
