using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Commands
{
    public class CommandShootArrow : ICommand
    {
        private Game1 game;
        private Link link;

        public CommandShootArrow(Game1 game)
        {
            this.game = game;
            link = game.link;
        }

        public void Execute()
        {
            RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateArrow(link.ItemSpawnPosition, link.FacingDirection, true));
            link.UseItem();
        }
    }
}
