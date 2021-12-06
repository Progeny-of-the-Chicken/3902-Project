using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Movement
{
    public interface IMovementStrategy
    {
        Vector2 Move(GameTime gameTime, Vector2 location);
    }
}
