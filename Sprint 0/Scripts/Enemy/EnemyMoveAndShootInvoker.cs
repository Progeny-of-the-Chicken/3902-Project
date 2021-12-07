using System.Collections.Generic;
using System.Security.Cryptography;
using Sprint_0.Scripts.Commands;

namespace Sprint_0.Scripts.Enemy
{
    public class EnemyMoveAndShootInvoker
    {
        private static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        private byte[] random;
        List<(ICommand command, int weight)> commands = new List<(ICommand command, int weight)>();
        private ICommand abilityCommand;
        private int totalWeight = ObjectConstants.zero;

        public EnemyMoveAndShootInvoker()
        {
            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            randomDir = new RNGCryptoServiceProvider();
        }

        public void AddCommand(ICommand command)
        {
            commands.Add((command, ObjectConstants.DefaultEnemyAbilityChanceWeight));
            totalWeight++;
        }

        public void AddAbility(ICommand command)
        {
            abilityCommand = command;
        }

        public void ExecuteRandomMoveCommand()
        {
            randomDir.GetBytes(random);
            int randomIndex = random[ObjectConstants.firstInArray] % totalWeight;
            int commandIndex = 0;
            while (randomIndex >= commands[commandIndex].weight)
            {
                randomIndex -= commands[commandIndex].weight;
                commandIndex++;
            }
            commands[commandIndex].command.Execute();
        }

        public void ExecuteAbility()
        {
            abilityCommand.Execute();
        }
    }
}