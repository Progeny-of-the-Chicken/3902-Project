using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Movement.MovementStrategy
{
    public class OffsetFromEnemyStrategy : IMovementStrategy
    {
        private IEnemy enemy;
        private Vector2 offset;

        public OffsetFromEnemyStrategy(IEnemy enemy, Vector2 offset)
        {
            this.enemy = enemy;
            this.offset = offset;
        }

        public Vector2 Move(GameTime gameTime, Vector2 location)
        {
            return enemy.Position + offset;
        }
    }
}
