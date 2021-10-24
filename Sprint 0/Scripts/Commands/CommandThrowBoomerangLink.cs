using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.Commands
{
    public class CommandThrowBoomerangLink : ICommand
    {
        private Game1 game;
        private Link link;

        public CommandThrowBoomerangLink(Game1 game)
        {
            this.game = game;
            link = game.link;
        }

        public void Execute()
        {
            game.projectileSet.projectiles.Add(ProjectileFactory.Instance.CreateLinkMagicalBoomerang(link.ItemSpawnPosition, link.FacingDirection));
            link.UseItem();
        }
    }
}
