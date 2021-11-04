using Sprint_0.Scripts.Projectiles;

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
            game.roomManager.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateLinkMagicalBoomerang(link.ItemSpawnPosition, link.FacingDirection, link));
            link.UseItem();
        }
    }
}
