using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite.InventorySprites
{
    public class TreasureRoomMapMarkerSprite : ISprite
    {
        private Texture2D spritesheet;
        private Rectangle frame = SpriteRectangles.treasureRoomMapMarkerFrame;
        private int scale = ObjectConstants.scale;

        public TreasureRoomMapMarkerSprite(Texture2D textures)
        {
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
