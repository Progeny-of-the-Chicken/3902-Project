using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.SpriteFactories;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Commands.EnemyAbilities
{
    public class CommandShootMagicProjectileTowardLink : ICommand
    {
        private EnemyStateMachine stateMachine;

        public CommandShootMagicProjectileTowardLink(EnemyStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void Execute()
        {
            Vector2 distanceVector = SpawnHelper.Instance.CenterLocationOnSpawner(Link.Instance.Position, new Vector2(ObjectConstants.linkWidthHeight), ObjectConstants.magicProjectileWidthHeight) - stateMachine.Location;
            Vector2 abs = new Vector2(Math.Abs(distanceVector.X), Math.Abs(distanceVector.Y));
            Vector2 xyScale = new Vector2(distanceVector.X / (abs.X + abs.Y), distanceVector.Y / (abs.X + abs.Y));
            ObjectsFromObjectsFactory.Instance.CreateMagicProjectileFromEnemy(stateMachine.Location, xyScale);
        }
    }
}
