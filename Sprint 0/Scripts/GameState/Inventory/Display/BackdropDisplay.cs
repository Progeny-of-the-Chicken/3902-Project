using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.GameState.InventoryState.Display
{
    public class BackdropDisplay : IDisplay
    {
        private ISprite backdropSprite;
        private Vector2 location;

        public BackdropDisplay()
        {
            backdropSprite = InventorySpriteFactory.Instance.CreateBackdropSprite();
            location = ObjectConstants.backdropSpawnLocation;
        }

        public void Update(GameTime gt)
        {
            // No animation
            // TODO: Check whether placeholder colors need to be covered by black boxes
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gt)
        {
            backdropSprite.Draw(spriteBatch, location);
        }

        public void Scroll(Vector2 displacement)
        {
            location += displacement;
        }
    }
}
