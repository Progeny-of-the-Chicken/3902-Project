using System;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.SpriteFactories;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Commands.EnemyAbilities
{
    public class CommandShootThreeMagicProjectileSpread : ICommand
    {
        private EnemyStateMachine stateMachine;

        public CommandShootThreeMagicProjectileSpread(EnemyStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void Execute()
        {
            Vector2 spawnerPos = stateMachine.Location;
            Vector2 destinationVector = SpawnHelper.Instance.CenterLocationOnSpawner(Link.Instance.Position, new Vector2(ObjectConstants.linkWidthHeight), ObjectConstants.magicProjectileWidthHeight);
            double adjacent = destinationVector.X - spawnerPos.X;
            double opposite = destinationVector.Y - spawnerPos.Y;
            double hypotenuse = Math.Sqrt(Math.Pow(adjacent, 2) + Math.Pow(opposite, 2));
            double angle = Math.Acos(adjacent / hypotenuse);

            ObjectsFromObjectsFactory.Instance.CreateMagicProjectileFromEnemy(spawnerPos, new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)));
            ObjectsFromObjectsFactory.Instance.CreateMagicProjectileFromEnemy(spawnerPos, new Vector2((float)Math.Cos(angle + ObjectConstants.AquamentusProjectileSpreadRadians), (float)Math.Sin(angle + ObjectConstants.AquamentusProjectileSpreadRadians)));
            ObjectsFromObjectsFactory.Instance.CreateMagicProjectileFromEnemy(spawnerPos, new Vector2((float)Math.Cos(angle - ObjectConstants.AquamentusProjectileSpreadRadians), (float)Math.Sin(angle - ObjectConstants.AquamentusProjectileSpreadRadians)));

            /*
            Vector2 distanceVector = SpawnHelper.Instance.CenterLocationOnSpawner(Link.Instance.Position, new Vector2(ObjectConstants.linkWidthHeight), ObjectConstants.magicProjectileWidthHeight) - stateMachine.Location;
            Vector2 abs = new Vector2(Math.Abs(distanceVector.X), Math.Abs(distanceVector.Y));
            Vector2 xyScale = new Vector2(distanceVector.X / (abs.X + abs.Y), distanceVector.Y / (abs.X + abs.Y));
            ObjectsFromObjectsFactory.Instance.CreateMagicProjectileFromEnemy(stateMachine.Location, xyScale);

            double angle = Math.Acos(xyScale.X) + ObjectConstants.AquamentusProjectileSpreadRadians;
            ObjectsFromObjectsFactory.Instance.CreateMagicProjectileFromEnemy(stateMachine.Location, new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)));
            angle = Math.Acos(xyScale.X) - ObjectConstants.AquamentusProjectileSpreadRadians;
            ObjectsFromObjectsFactory.Instance.CreateMagicProjectileFromEnemy(stateMachine.Location, new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)));
            */

            stateMachine.SetState(EnemyState.AbilityCast, (float)ObjectConstants.AquamentusShootTime);
        }
    }
}
