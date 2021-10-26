using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.Commands
{
    public class LinkUseSword : ICommand
    {
        private Link link;
        private Game1 game;

        public LinkUseSword(Link link, Game1 game)
        {
            this.link = link;
            this.game = game;
        }

        public void Execute()
        {
            game.roomManager.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateSwordAttackHitbox(link.Position, link.FacingDirection));
            link.UseSword();
        }
    }
}
