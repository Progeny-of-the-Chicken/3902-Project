using Sprint_0.Scripts.GameState;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.Projectiles;

namespace Sprint_0.Scripts.Commands
{
    public class CommandUseSecondaryItem : ICommand
    {
        private Game1 game;
        private Link link;

        public CommandUseSecondaryItem(Game1 game)
        {
            this.game = game;
            link = game.link;
        }

        public void Execute()
        {
            WeaponType type = Inventory.Instance.Weapons[Inventory.Instance.SelectedWeaponIndex];
            switch (type)
            {
                case WeaponType.Bow:
                    // Prioritize silver arrows
                    if (Inventory.Instance.Weapons.Contains(WeaponType.SilverArrow))
                    {
                        RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateArrow(link.Position, link.FacingDirection, true));
                    }
                    else if (Inventory.Instance.Weapons.Contains(WeaponType.BasicArrow))
                    {
                        RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateArrow(link.Position, link.FacingDirection, false));
                    }
                    break;
                case WeaponType.BasicBoomerang:
                    RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateLinkBasicBoomerang(link.Position, link.FacingDirection, link));
                    break;
                case WeaponType.MagicalBoomerang:
                    RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateLinkMagicalBoomerang(link.Position, link.FacingDirection, link));
                    break;
                case WeaponType.Bomb:
                    RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateBomb(link.Position, link.FacingDirection));
                    break;
                case WeaponType.BlueCandle:
                    RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateFireSpell(link.Position, link.FacingDirection));
                    break;
            }
            link.UseItem();
        }
    }
}
