using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.GameState;

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
            if (!link.SwordIsSheathed) {
                RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateSwordAttackHitbox(link.Position, link.FacingDirection));
                if (link.Health == link.MaxHealth)
                {
                    RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateSwordBeam(link.Position, link.FacingDirection));
                }
                link.UseSword();
            }
        }
    }
}
