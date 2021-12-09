using System;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts
{
    public class DropHandler
    {
        private static DropHandler instance = new DropHandler();
        private int killCounter;
        Random random;
        public static DropHandler Instance
        {
            get
            {
                return instance;
            }
        }

        private DropHandler()
        {
            killCounter = ObjectConstants.counterInitialVal_int;
            random = new Random();
        }

        public void DropItem(IEnemy enemy)
        {
            double dropFreq = getDropFrequencyForType(enemy.GetType());
            double randomNum = random.NextDouble();


            if (randomNum < dropFreq)
                dropNextItem(enemy);

            killCounter++;
        }

        private void dropNextItem(IEnemy enemy)
        {
            int index = killCounter % 10;

            ItemType[] itemList = getItemListForType(enemy.GetType());

            ObjectsFromObjectsFactory.Instance.CreateItemDrop(enemy.Position, enemy.Collider.Hitbox.Size.ToVector2(), itemList[index]);
        }

        private ItemType[] getItemListForType(Type enemy)
        {
            //since the X group shouldn't get this far, we don't have to worry about returning an empty list
            ItemType[] list = new ItemType[10];
            if (ObjectConstants.groupAEnemies.Contains(enemy))
                list = ObjectConstants.groupAItems;
            if (ObjectConstants.groupBEnemies.Contains(enemy))
                list = ObjectConstants.groupBItems;
            if (ObjectConstants.groupCEnemies.Contains(enemy))
                list = ObjectConstants.groupCItems;
            if (ObjectConstants.groupDEnemies.Contains(enemy))
                list = ObjectConstants.groupDItems;
            if (ObjectConstants.groupXEnemies.Contains(enemy))
                list = ObjectConstants.groupXItems;
            return list;
        }
        private double getDropFrequencyForType(Type enemy)
        {
            double frequency = 0;
            if (ObjectConstants.groupAEnemies.Contains(enemy))
                frequency = ObjectConstants.groupADropRate;
            if (ObjectConstants.groupBEnemies.Contains(enemy))
                frequency = ObjectConstants.groupBDropRate;
            if (ObjectConstants.groupCEnemies.Contains(enemy))
                frequency = ObjectConstants.groupCDropRate;
            if (ObjectConstants.groupDEnemies.Contains(enemy))
                frequency = ObjectConstants.groupDDropRate;
            if (ObjectConstants.groupXEnemies.Contains(enemy))
                frequency = ObjectConstants.groupXDropRate;
            return frequency;
        }
    }
}
