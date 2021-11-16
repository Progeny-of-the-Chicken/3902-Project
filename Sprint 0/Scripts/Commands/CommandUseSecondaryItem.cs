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
            link = Link.Instance;
        }

        public void Execute()
        {
            WeaponType type = Inventory.Instance.Weapons[Inventory.Instance.SelectedWeaponIndex];
            switch (type)
            {
                case WeaponType.Bow:
                    if (Inventory.Instance.Rupee > 0 && Inventory.Instance.SilverArrows)
                    {
                        RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateArrow(link.Position, link.FacingDirection, true));
                        Inventory.Instance.Rupee--;
                    }
                    else if (Inventory.Instance.Rupee > 0 && Inventory.Instance.BasicArrows)
                    {
                        RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateArrow(link.Position, link.FacingDirection, false));
                        Inventory.Instance.Rupee--;
                    }
                    break;
                case WeaponType.BasicBoomerang:
                    RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateLinkBasicBoomerang(link.Position, link.FacingDirection, link));
                    break;
                case WeaponType.MagicalBoomerang:
                    RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateLinkMagicalBoomerang(link.Position, link.FacingDirection, link));
                    break;
                case WeaponType.Bomb:
                    if (Inventory.Instance.Bomb > 0)
                    {
                        RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateBomb(link.Position, link.FacingDirection));
                        Inventory.Instance.Bomb--;
                    }
                    break;
                case WeaponType.BlueCandle:
                    RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateFireSpell(link.Position, link.FacingDirection));
                    break;
                case WeaponType.Potion:
                    Link.Instance.HealBy((int)(Link.Instance.MaxHealth));
                    Inventory.Instance.RemoveWeapon(WeaponType.Potion);
                    break;
            }
            link.UseItem();
        }
    }
}
