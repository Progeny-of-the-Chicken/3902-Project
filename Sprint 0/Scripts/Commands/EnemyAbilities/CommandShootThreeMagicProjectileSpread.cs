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
            ObjectsFromObjectsFactory.Instance.CreateThreeMagicProjectilesFromEnemy(stateMachine.Location, stateMachine.GetDirection);
        }
    }
}
