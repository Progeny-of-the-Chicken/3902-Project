using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.GameStateHandlers
{
    public class GameplayStateHandler: IGameStateHandler
    {
        private IRoomManager roomManager;

        public GameplayStateHandler(Link link)
        {
            roomManager = RoomManager.Instance;
            roomManager.Init(link);
        }

        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            roomManager.Draw(sb);
        }

        public void Update(GameTime gameTime)
        {
            roomManager.Update(gameTime);
        }
    }
}
