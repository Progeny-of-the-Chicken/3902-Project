using Microsoft.Xna.Framework;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Items
{
    public class ItemFactory
    {
        private static ItemFactory instance = new ItemFactory();

        public static ItemFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemFactory()
        {
        }

        public IItem CreateSmallHeartItem(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.smallHeartFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale), ItemType.SmallHeartItem);
        }

        public IItem CreateHeartContainer(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.heartContainerFrame.Size.ToVector2() * ObjectConstants.scale), ItemType.HeartContainer);
        }

        public IItem CreateFairy(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.fairyFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale), ItemType.Fairy);
        }

        public IItem CreateClock(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.clockFrame.Size.ToVector2() * ObjectConstants.scale), ItemType.Clock);
        }

        public IItem CreateBlueRuby(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.blueRubyFrame.Size.ToVector2() * ObjectConstants.scale), ItemType.BlueRuby);
        }

        public IItem CreateYellowRuby(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.yellowRubyFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale), ItemType.YellowRuby);
        }

        public IItem CreateBasicMapItem(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.basicMapFrame.Size.ToVector2() * ObjectConstants.scale), ItemType.BasicMapItem);
        }

        public IItem CreateBoomerangItem(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.basicBoomerangFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale), ItemType.BoomerangItem);
        }

        public IItem CreateBombItem(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.bombItemFrame.Size.ToVector2() * ObjectConstants.scale), ItemType.BombItem);
        }

        public IItem CreateBowItem(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.bowItemFrame.Size.ToVector2() * ObjectConstants.scale), ItemType.BowItem);
        }

        public IItem CreateBasicKey(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.basicKeyFrame.Size.ToVector2() * ObjectConstants.scale), ItemType.BasicKey);
        }

        public IItem CreateMagicKey(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.magicKeyFrame.Size.ToVector2() * ObjectConstants.scale), ItemType.MagicKey);
        }

        public IItem CreateCompass(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.compassFrame.Size.ToVector2() * ObjectConstants.scale), ItemType.Compass);
        }

        public IItem CreateTriforcePiece(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.triforcePieceFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale), ItemType.TriforcePiece);
        }

        public IItem CreateBasicArrowItem(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.basicArrowItemFrame.Size.ToVector2() * ObjectConstants.scale), ItemType.BasicArrowItem);
        }

        public IItem CreateSilverArrowItem(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.silverArrowItemFrame.Size.ToVector2() * ObjectConstants.scale), ItemType.SilverArrowItem);
        }

        public IItem CreateBlueRingItem(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.blueRingItemFrame.Size.ToVector2() * ObjectConstants.scale), ItemType.BlueRing);
        }
        public IItem CreateShotgunItem(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.shotGunItemFrame.Size.ToVector2() * ObjectConstants.scale), ItemType.ShotgunItem);
        }
        public IItem CreateShotgunShellItem(Vector2 location, Vector2 spawnerDimensions)
        {
            return new Item(SpawnHelper.Instance.CenterLocationOnSpawner(location, spawnerDimensions, SpriteRectangles.shotGunShellItemFrame.Size.ToVector2() * ObjectConstants.scale), ItemType.ShotgunShellItem);
        }
    }
}
