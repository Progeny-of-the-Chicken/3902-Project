using System.Collections.Generic;
using System.Security.Cryptography;
using Sprint_0.Scripts.Commands;

namespace Sprint_0.Scripts.Enemy
{
    public class EnemyRandomInvoker
    {
        private static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        private byte[] random;
        List<(ICommand command, int weight)> commands = new List<(ICommand command, int weight)>();
        private int totalWeight = ObjectConstants.zero;

        public EnemyRandomInvoker()
        {
            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            randomDir = new RNGCryptoServiceProvider();
        }

        public void AddCommand(ICommand command)
        {
            commands.Add((command, ObjectConstants.DefaultEnemyAbilityChangeWeight));
            totalWeight++;
        }

        public void AddCommandWithWeight(ICommand command, int weight)
        {
            commands.Add((command, weight));
            totalWeight += weight;
        }

        public void ExecuteRandomCommand()
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
    }
}
