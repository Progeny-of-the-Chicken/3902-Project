using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Items
{
    public class TreasureCycle
    {
        private List<IItem> cycle;
        private int currentIndex;

        public TreasureCycle(Vector2 spawnLoc)
        {
            cycle = new List<IItem>();
            cycle.Add(ItemSpriteFactory.Instance.CreateBlueRuby(spawnLoc));
            cycle.Add(ItemSpriteFactory.Instance.CreateYellowRuby(spawnLoc));
            cycle.Add(ItemSpriteFactory.Instance.CreateSmallHeartTreasure(spawnLoc));
            cycle.Add(ItemSpriteFactory.Instance.CreateHeartContainer(spawnLoc));
            cycle.Add(ItemSpriteFactory.Instance.CreateFairy(spawnLoc));
            cycle.Add(ItemSpriteFactory.Instance.CreateClock(spawnLoc));
            cycle.Add(ItemSpriteFactory.Instance.CreateBasicKey(spawnLoc));
            cycle.Add(ItemSpriteFactory.Instance.CreateBoomerangTreasure(spawnLoc));
            cycle.Add(ItemSpriteFactory.Instance.CreateBombTreasure(spawnLoc));
            cycle.Add(ItemSpriteFactory.Instance.CreateBowTreasure(spawnLoc));
            cycle.Add(ItemSpriteFactory.Instance.CreateBasicKey(spawnLoc));
            cycle.Add(ItemSpriteFactory.Instance.CreateMagicKey(spawnLoc));
            cycle.Add(ItemSpriteFactory.Instance.CreateCompass(spawnLoc));
            cycle.Add(ItemSpriteFactory.Instance.CreateTriforcePiece(spawnLoc));

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