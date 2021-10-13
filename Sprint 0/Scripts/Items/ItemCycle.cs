using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Items
{
    public class ItemCycle
    {
        private List<IItem> cycle;
        private int currentIndex;

        public ItemCycle(Vector2 spawnLoc)
        {
            cycle = new List<IItem>();
            cycle.Add(ItemFactory.Instance.CreateBlueRuby(spawnLoc));
            cycle.Add(ItemFactory.Instance.CreateYellowRuby(spawnLoc));
            cycle.Add(ItemFactory.Instance.CreateSmallHeartItem(spawnLoc));
            cycle.Add(ItemFactory.Instance.CreateHeartContainer(spawnLoc));
            cycle.Add(ItemFactory.Instance.CreateFairy(spawnLoc));
            cycle.Add(ItemFactory.Instance.CreateClock(spawnLoc));
            cycle.Add(ItemFactory.Instance.CreateBasicKey(spawnLoc));
            cycle.Add(ItemFactory.Instance.CreateBoomerangItem(spawnLoc));
            cycle.Add(ItemFactory.Instance.CreateBombItem(spawnLoc));
            cycle.Add(ItemFactory.Instance.CreateBowItem(spawnLoc));
            cycle.Add(ItemFactory.Instance.CreateBasicKey(spawnLoc));
            cycle.Add(ItemFactory.Instance.CreateMagicKey(spawnLoc));
            cycle.Add(ItemFactory.Instance.CreateCompass(spawnLoc));
            cycle.Add(ItemFactory.Instance.CreateTriforcePiece(spawnLoc));

            currentIndex = 0;
        }

        public IItem getNextItem()
        {
            if (currentIndex < (cycle.Count - 1))
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
            return cycle[currentIndex];
        }

        public IItem getLastItem()
        {
            if (currentIndex <= 0)
            {
                currentIndex = cycle.Count - 1;
            }
            else
            {
                currentIndex--;
            }
            return cycle[currentIndex];
        }
    }
}