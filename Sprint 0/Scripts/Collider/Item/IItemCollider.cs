using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Collider.Item
{
    public interface IItemCollider
    {
        IItem Owner { get; }

        Rectangle Hitbox { get; }

        void Update(Vector2 location);
    }
}
