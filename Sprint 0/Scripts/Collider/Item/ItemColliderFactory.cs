using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Collider.Item
{
    public class ItemColliderFactory
    {
        private static ItemColliderFactory instance = new ItemColliderFactory();

        public static ItemColliderFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemColliderFactory()
        {
        }

        public IItemCollider CreateSmallHeartItemCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateHeartContainerCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateFairyCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateClockCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateBlueRubyCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateYellowRubyCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateBasicMapItemCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateBoomerangItemCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateBombItemCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateBowItemCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateBasicKeyCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateMagicKeyCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateCompassCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateTriforcePieceCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateBasicArrowItemCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }

        public IItemCollider CreateSilverArrowItemCollider(IItem item)
        {
            return new GenericItemCollider(item);
        }
    }
}
