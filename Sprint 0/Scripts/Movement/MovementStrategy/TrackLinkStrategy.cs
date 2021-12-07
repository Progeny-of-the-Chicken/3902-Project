using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Movement.MovementStrategy
{
    public class TrackLinkStrategy : IMovementStrategy
    {
        private float speed;
        private Vector2 spawnerDimensions;

        public TrackLinkStrategy(float speed, Vector2 spawnerDimensions)
        {
            this.speed = speed;
            this.spawnerDimensions = spawnerDimensions;
        }

        public Vector2 Move(GameTime gameTime, Vector2 location)
        {
            Vector2 distanceVector = SpawnHelper.Instance.CenterLocationOnSpawner(Link.Instance.Position, new Vector2(ObjectConstants.linkWidthHeight), spawnerDimensions) - location;
            Vector2 abs = new Vector2(Math.Abs(distanceVector.X), Math.Abs(distanceVector.Y));
            Vector2 xyScale = new Vector2(distanceVector.X / (abs.X + abs.Y), distanceVector.Y / (abs.X + abs.Y));
            return location += new Vector2((int)(speed * gameTime.ElapsedGameTime.TotalSeconds)) * xyScale;
        }
    }
}
