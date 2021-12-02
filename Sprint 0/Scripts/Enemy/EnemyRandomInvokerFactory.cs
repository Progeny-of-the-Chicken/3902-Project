﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Commands.EnemyAbilities;

namespace Sprint_0.Scripts.Enemy
{
    public class EnemyRandomInvokerFactory
    {
        private static EnemyRandomInvokerFactory instance = new EnemyRandomInvokerFactory();

        public static EnemyRandomInvokerFactory Instance
        {
            get {
                return instance;
            }
        }

        private EnemyRandomInvokerFactory()
        {
        }

        public EnemyRandomInvoker CreateInvokerForEnemy(EnemyType type, EnemyStateMachine stateMachine, IEnemy enemy)
        {
            EnemyRandomInvoker invoker = new EnemyRandomInvoker();
            // Movement
            switch (type)
            {
                case EnemyType.Aquamentus:
                    InitializeMoveCommands(invoker, stateMachine, GetHorizontalVectors());
                    break;
                case EnemyType.Stalfos:
                case EnemyType.Gel:
                case EnemyType.Zol:
                case EnemyType.Goriya:
                case EnemyType.Rope:
                case EnemyType.Dodongo:
                case EnemyType.Bubble:
                    InitializeMoveCommands(invoker, stateMachine, GetCardinalVectors());
                    break;
                case EnemyType.Keese:
                    InitializeMoveCommands(invoker, stateMachine, GetFlyVectors());
                    break;
            }
            // Abilities
            switch (type)
            {
                case EnemyType.Goriya:
                    invoker.AddCommand(new CommandEnemyThrowBoomerang(enemy, stateMachine));
                    break;
                case EnemyType.Aquamentus:
                    invoker.AddCommand(new CommandShootThreeMagicProjectileSpread(stateMachine));
                    break;
            }
            return invoker;
        }

        //----- Helper for getting enemy unique abilities -----//

        private void InitializeMoveCommands(EnemyRandomInvoker invoker, EnemyStateMachine stateMachine, List<Vector2> vectors)
        {
            foreach (Vector2 vector in vectors)
            {
                invoker.AddCommand(new CommandMove(stateMachine, vector));
            }
        }

        //----- Vector assignment -----//

        private List<Vector2> GetFlyVectors()
        {
            return new List<Vector2>
            {
                ObjectConstants.RightUnitVector,
                ObjectConstants.UpRightUnitVector,
                ObjectConstants.UpUnitVector,
                ObjectConstants.UpLeftUnitVector,
                ObjectConstants.LeftUnitVector,
                ObjectConstants.DownLeftUnitVector,
                ObjectConstants.DownUnitVector,
                ObjectConstants.DownRightUnitVector,
                ObjectConstants.zeroVector
            };
        }

        private List<Vector2> GetCardinalVectors()
        {
            return new List<Vector2>
            {
                ObjectConstants.RightUnitVector,
                ObjectConstants.UpUnitVector,
                ObjectConstants.LeftUnitVector,
                ObjectConstants.DownUnitVector,
            };
        }

        private List<Vector2> GetHorizontalVectors()
        {
            return new List<Vector2>
            {
                ObjectConstants.RightUnitVector,
                ObjectConstants.LeftUnitVector
            };
        }
    }
}
