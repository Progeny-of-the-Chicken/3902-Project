using Sprint_0.Scripts.GameState.InventoryState;
using System.Collections.Generic;

namespace Sprint_0.Scripts.GameState
{
    public class Inventory
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
            Init();
        }

        private void Init()
        {
            Weapons = new List<WeaponType>
            {
                WeaponType.BlueCandle,
                WeaponType.BasicBoomerang,
                WeaponType.MagicalBoomerang,
                WeaponType.Bomb,
                WeaponType.Potion
            };
            SelectedWeaponIndex = ObjectConstants.selectedItemStartingIndex;
            BlueRing = false;
            MagicKey = false;
            BasicArrows = false;
            SilverArrows = false;
            Map = false;
            Compass = false;
            Rupee = ObjectConstants.inventoryStartingRupees;
            Key = ObjectConstants.inventoryStartingKeys;
            Bomb = ObjectConstants.inventoryStartingBombs;
            ShotgunShells = ObjectConstants.inventoryStartingShotgunShells;
        }

        public void reset()
        {
            Init();
        }

        public List<WeaponType> Weapons { get; set; }

        public void RemoveWeapon(WeaponType weapon)
        {
            if (Weapons.IndexOf(weapon) == SelectedWeaponIndex)
            {
                SelectedWeaponIndex = ObjectConstants.firstInArray;
            }
            Weapons.Remove(weapon);
            InventoryManager.Instance.UpdateDisplay();
        }

        public void AddWeapon(WeaponType weapon)
        {
            Weapons.Add(weapon);
            InventoryManager.Instance.UpdateDisplay();
        }

        public bool HasWeapon(WeaponType weapon)
        {
            return Weapons.Contains(weapon);
        }

        public int SelectedWeaponIndex { get; set; }

        public bool BlueRing { get; set; }

        public bool MagicKey { get; set; }

        public bool BasicArrows { get; set; }

        public bool SilverArrows { get; set; }

        public bool Map { get; set; }

        public bool Compass { get; set; }

        public int Rupee { get; set; }

        public int Key { get; set; }

        public int Bomb { get; set; }

        public int ShotgunShells { get; set; }
    }
}
