using System.Collections.Generic;

namespace Sprint_0.Scripts.GameState
{
    public class Inventory : IInventory
    {
        private static Inventory instance = new Inventory();

        public static Inventory Instance
        {
            get
            {
                return instance;
            }
        }

        private Inventory()
        {
            Weapons = new List<WeaponType>
            {
                WeaponType.BlueCandle,
                WeaponType.BasicBoomerang,
                WeaponType.MagicalBoomerang,
                WeaponType.BasicArrow,
                WeaponType.Bomb
            };
            SelectedWeaponIndex = ObjectConstants.selectedItemStartingIndex;
            Map = false;
            Compass = false;
        }

        public List<WeaponType> Weapons { get; set; }

        public int SelectedWeaponIndex { get; set; }

        public bool Map { get; set; }

        public bool Compass { get; set; }

        // TODO: Add more properties as needed by HUD
    }
}
