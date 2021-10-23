using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Items.ItemColliders
{
    public interface IItemCollider
    {
        IItem Owner { get; }

        Rectangle Hitbox { get; }

        void Update(Vector2 location);
    }
}
