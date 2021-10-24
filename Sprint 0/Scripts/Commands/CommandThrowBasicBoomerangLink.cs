using Sprint_0.Scripts.Projectiles;

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
            game.projectileSet.projectiles.Add(ProjectileFactory.Instance.CreateLinkBasicBoomerang(link.ItemSpawnPosition, link.FacingDirection));
        }
    }
}
