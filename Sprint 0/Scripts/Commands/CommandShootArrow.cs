using Sprint_0.Scripts.Projectiles;

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
            game.projectileSet.projectiles.Add(ProjectileFactory.Instance.CreateArrow(link.ItemSpawnPosition, link.FacingDirection, true));
            link.UseItem();
        }
    }
}
