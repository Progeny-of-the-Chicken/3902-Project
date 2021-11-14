using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts;
using Sprint_0.Scripts.GameState.InventoryState;

namespace Sprint_0.GameStateHandlers
{
    public class InventoryStateHandler: IGameStateHandler
    {
        private IInventoryManager inventoryManager;

        public InventoryStateHandler()
        {
            inventoryManager = InventoryManager.Instance;
            inventoryManager.Init();
        }

        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            inventoryManager.Draw(sb, gameTime);
        }

        public void Update(GameTime gameTime)
        {
            inventoryManager.Update(gameTime);
        }
    }
}
