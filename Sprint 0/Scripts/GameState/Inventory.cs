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
                WeaponType.Bomb
            };
            SelectedWeaponIndex = ObjectConstants.selectedItemStartingIndex;
            BlueRing = true;
            Map = false;
            Compass = false;
            Rupee = ObjectConstants.inventoryStartingRupees;
            Key = ObjectConstants.inventoryStartingKeys;
            Bomb = ObjectConstants.inventoryStartingBombs;
        }

        public List<WeaponType> Weapons { get; set; }

        public int SelectedWeaponIndex { get; set; }

        public bool BlueRing { get; set; }

        public bool Map { get; set; }

        public bool Compass { get; set; }

        public int Rupee { get; set; }

        public int Key { get; set; }

        public int Bomb { get; set; }
    }
}
