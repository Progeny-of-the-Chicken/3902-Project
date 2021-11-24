using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Commands.EnemyAbilities;

namespace Sprint_0.Scripts.Enemy
{
    public class EnemyRandomInvokerFactory
    {
        private List<Vector2> FlyVectors;
        private List<Vector2> CardinalVectors;
        private List<Vector2> HorizontalVectors;

        private static EnemyRandomInvokerFactory instance = new EnemyRandomInvokerFactory();

        public static EnemyRandomInvokerFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemyRandomInvokerFactory()
        {
            FlyVectors = new List<Vector2>
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
            CardinalVectors = new List<Vector2>
            {
                ObjectConstants.RightUnitVector,
                ObjectConstants.UpUnitVector,
                ObjectConstants.LeftUnitVector,
                ObjectConstants.DownUnitVector,
            };
            HorizontalVectors = new List<Vector2>
            {
                ObjectConstants.RightUnitVector,
                ObjectConstants.LeftUnitVector
            };
        }

        public EnemyRandomInvoker CreateRandomInvokerForEnemy(EnemyStateMachine stateMachine, EnemyType type)
        {
            EnemyRandomInvoker invoker = new EnemyRandomInvoker();
            // Movement
            switch (type)
            {
                case EnemyType.Aquamentus:
                    InitializeMoveCommands(invoker, stateMachine, HorizontalVectors);
                    break;
                case EnemyType.Stalfos:
                case EnemyType.Gel:
                case EnemyType.Zol:
                case EnemyType.Goriya:
                case EnemyType.Rope:
                case EnemyType.Dodongo:
                    InitializeMoveCommands(invoker, stateMachine, CardinalVectors);
                    break;
                case EnemyType.Keese:
                    InitializeMoveCommands(invoker, stateMachine, FlyVectors);
                    break;
            }
            // Abilities
            switch (type)
            {
                case EnemyType.Goriya:
                    invoker.AddCommand(new CommandEnemyThrowBoomerang(stateMachine));
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
    }
}
