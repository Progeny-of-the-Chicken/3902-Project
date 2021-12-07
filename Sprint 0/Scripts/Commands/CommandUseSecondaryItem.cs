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
            if (link.CanDoNewAction)
            {
                useSecondaryItem();
            }
        }

        private void useSecondaryItem()
        {
            WeaponType type = Inventory.Instance.Weapons[Inventory.Instance.SelectedWeaponIndex];
            bool usingShotgun = false;
            switch (type)
            {
                case WeaponType.Bow:
                    UseBow();
                    break;
                case WeaponType.BasicBoomerang:
                    UseBasicBoomerang();
                    break;
                case WeaponType.MagicalBoomerang:
                    UseMagicalBoomerang();
                    break;
                case WeaponType.Bomb:
                    UseBomb();
                    break;
                case WeaponType.BlueCandle:
                    UseBlueCandle();
                    break;
                case WeaponType.Potion:
                    UsePotion();
                    break;
                case WeaponType.Shotgun:
                    usingShotgun = true;
                    UseShotgun();
                    break;
            }
            //We need this to prevent a link state change if link uses a shotgun but doesn't have any shells left
            if (!usingShotgun)
                link.UseItem();
        }

        private void UseBow()
        {
            if (Inventory.Instance.Rupee > 0 && Inventory.Instance.SilverArrows)
            {
                RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateArrow(link.Position, link.FacingDirection, true));
                Inventory.Instance.Rupee--;
                link.UseItem();
            }
            else if (Inventory.Instance.Rupee > 0 && Inventory.Instance.BasicArrows)
            {
                RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateArrow(link.Position, link.FacingDirection, false));
                Inventory.Instance.Rupee--;
                link.UseItem();
            }
        }

        private void UseBasicBoomerang()
        {
            if (Link.Instance.BoomerangReady)
            {
                RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateLinkBasicBoomerang(link.Position, link.FacingDirection, link));
                Link.Instance.BoomerangReady = false;
                link.UseItem();
            }
        }

        private void UseMagicalBoomerang()
        {
            if (Link.Instance.BoomerangReady)
            {
                RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateLinkMagicalBoomerang(link.Position, link.FacingDirection, link));
                Link.Instance.BoomerangReady = false;
                link.UseItem();
            }
        }

        private void UseBomb()
        {
            if (Inventory.Instance.Bomb > 0)
            {
                RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateBomb(link.Position, link.FacingDirection));
                Inventory.Instance.Bomb--;
                link.UseItem();
            }
        }

        private void UseBlueCandle()
        {
            RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateFireSpell(link.Position, link.FacingDirection));
            link.UseItem();
        }

        private void UsePotion()
        {
            Link.Instance.HealBy((int)(Link.Instance.MaxHealth));
            Inventory.Instance.RemoveWeapon(WeaponType.Potion);
            link.UseItem();
        }

        private void UseShotgun()
        {
            if (Inventory.Instance.ShotgunShells > 0)
            {
                Inventory.Instance.ShotgunShells--;
                Link.Instance.UseShotgun();
                for (int i = 0; i < ObjectConstants.pelletsPerBlast; i++)
                    RoomManager.Instance.CurrentRoom.AddProjectile(ProjectileFactory.Instance.CreateShotgunPellet(link.Position, link.FacingDirection));
            }
        }
    }
}
