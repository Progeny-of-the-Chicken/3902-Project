using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Commands
{
    public class CommandThrowMagicalBoomerangLink : ICommand
    {
        private Game1 game;
        private Link link;

        public CommandThrowMagicalBoomerangLink(Game1 game)
        {
            this.game = game;
            link = game.link;
        }

        public void Execute()
        {
            RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateLinkMagicalBoomerang(link.ItemSpawnPosition, link.FacingDirection, link));
            link.UseItem();
        }
    }
}
