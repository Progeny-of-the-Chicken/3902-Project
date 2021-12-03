using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Movement.MovementStrategy
{
    public class OrbitEnemyStrategy : IMovementStrategy
    {
        private double orbitTimeRadians;
        private int radius;
        private IEnemy enemy;
        private double timeSinceLastMove = ObjectConstants.zero_double;

        public OrbitEnemyStrategy(double orbitTimeRadians, int radius, IEnemy enemy)
        {
            this.orbitTimeRadians = orbitTimeRadians;
            this.radius = radius;
            this.enemy = enemy;
        }

        public Vector2 Move(GameTime gt, Vector2 location)
        {
            timeSinceLastMove += gt.ElapsedGameTime.TotalSeconds * orbitTimeRadians;
            Vector2 center = SpawnHelper.Instance.CenterLocationOnSpawner(enemy.Position, ObjectConstants.PatraWidthHeight, ObjectConstants.PatraMinionWidthHeight);
            return center + new Vector2((int)(radius * Math.Sin(timeSinceLastMove)), (int)(radius * Math.Cos(timeSinceLastMove)));
        }
    }
}
