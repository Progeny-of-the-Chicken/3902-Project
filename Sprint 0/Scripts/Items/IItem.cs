using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Collider.Item;

namespace Sprint_0.Scripts.Items
{
    public interface IItem
    {
        ItemType Type { get; }

        IItemCollider Collider { get; }

        void Update(GameTime gt);

        void Draw(SpriteBatch sb);
        void MoveItemBlock(Vector2 adjustment);

        bool CheckDelete();

        void Despawn();
    }
}
