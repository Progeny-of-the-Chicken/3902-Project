using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Items
{
    public class NonAnimatedTreasure : IItem
    {
        private Texture2D treasureSpritesheet;
        private Rectangle sourceRec;
        private Rectangle destinationRec;

        public NonAnimatedTreasure(Texture2D spritesheet, Rectangle textureLocation, Vector2 spawnLoc)
        {
            treasureSpritesheet = spritesheet;
            sourceRec = textureLocation;
            destinationRec = new Rectangle(
                (int)spawnLoc.X - (sourceRec.Width / 2), (int)spawnLoc.Y - (sourceRec.Height / 2),
                2 * sourceRec.Width, 2 * sourceRec.Height
            );
        }

        public bool Update(GameTime gameTime)
        {
            // No animation
            return false;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(treasureSpritesheet, destinationRec, sourceRec, Color.White);
        }
    }
}
