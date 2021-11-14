using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.GameState.InventoryState.Display
{
    public class BackdropDisplay : IDisplay
    {
        private Dictionary<ISprite, Vector2> backdropSprites = new Dictionary<ISprite, Vector2>();

        public BackdropDisplay()
        {
            backdropSprites.Add(InventorySpriteFactory.Instance.CreateWeaponBackdropSprite(), ObjectConstants.backdropSpawnLocation);
            backdropSprites.Add(InventorySpriteFactory.Instance.CreateMapBackdropSprite(), ObjectConstants.backdropSpawnLocation + ObjectConstants.mapBackdropFromBackdrop);
            backdropSprites.Add(InventorySpriteFactory.Instance.CreateMapColorCoverSprite(), ObjectConstants.backdropSpawnLocation + ObjectConstants.discoveredRoomsInitialLocationFromBackdrop);
            foreach (Rectangle destRec in SpriteRectangles.backdropCoverFrames)
            {
                backdropSprites.Add(InventorySpriteFactory.Instance.CreateCoverSprite(destRec), ObjectConstants.backdropSpawnLocation + (destRec.Location.ToVector2() * ObjectConstants.scale));
            }
        }

        public void Update(GameTime gt)
        {
            // No animation
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gt)
        {
            foreach (KeyValuePair<ISprite, Vector2> backdrop in backdropSprites)
            {
                backdrop.Key.Draw(spriteBatch, backdrop.Value);
            }
        }

        public void Scroll(Vector2 displacement)
        {
            foreach (KeyValuePair<ISprite, Vector2> backdrop in backdropSprites)
            {
                backdropSprites[backdrop.Key] += displacement;
            }
        }
    }
}
