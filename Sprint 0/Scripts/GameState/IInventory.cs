using System.Collections.Generic;

namespace Sprint_0.Scripts.GameState
{
    public interface IInventory
    {
        List<WeaponType> Weapons { get; set; }

        int SelectedWeaponIndex { get; set; }

        bool Map { get; set; }

        bool Compass { get; set; }

        // TODO: Add the remaining necessary properties for the HUD
    }
}
