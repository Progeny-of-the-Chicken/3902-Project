using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Terrain;

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
            RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateSwordAttackHitbox(link.Position, link.FacingDirection));
            link.UseSword();
        }
    }
}
