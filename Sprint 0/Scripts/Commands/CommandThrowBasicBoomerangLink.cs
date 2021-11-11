using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Commands
{
    public class CommandThrowBasicBoomerangLink : ICommand
    {
        private Game1 game;
        private Link link;

        public CommandThrowBasicBoomerangLink(Game1 game)
        {
            this.game = game;
            this.link = game.link;
        }

        public void Execute()
        {
            RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateLinkBasicBoomerang(link.ItemSpawnPosition, link.FacingDirection, link));
        }
    }
}
