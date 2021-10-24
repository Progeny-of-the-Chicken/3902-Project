using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.Commands
{
    public class CommandPlaceBomb : ICommand
    {
        private Game1 game;
        private Link link;

        public CommandPlaceBomb(Game1 game)
        {
            this.game = game;
            link = game.link;
        }

        public void Execute()
        {
            game.projectileSet.projectiles.Add(ProjectileFactory.Instance.CreateBomb(link.ItemSpawnPosition, link.FacingDirection));
        }
    }
}
