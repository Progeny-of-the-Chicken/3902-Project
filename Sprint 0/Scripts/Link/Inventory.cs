using System.Collections.Generic;
using Sprint_0.Scripts.GameState;

namespace Sprint_0.Scripts.Link
{
    public class Inventory : IInventory
    {
        private Inventory instance = new Inventory();

        public Inventory Instance
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
                WeaponType.BasicBoomerang
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
