using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Sprite
{
    public class BlackBackground: ISprite
    {
        private Texture2D spritesheet;
        private Rectangle frame = SpriteRectangles.blackHUDCoverFrame;
        private int scale = ObjectConstants.scale;

        public BlackBackground(Texture2D textures)
        {
            spritesheet = textures;
        }

        public void Update(GameTime gt)
        {
            // No animation
        }

        public void Draw(SpriteBatch sb, Vector2 location)
        {
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, ObjectConstants.fullScreen, ObjectConstants.fullScreen);
            sb.Draw(spritesheet, dest, frame, Color.Black);
        }
    }
}
