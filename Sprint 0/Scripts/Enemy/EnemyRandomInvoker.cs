using System.Collections.Generic;
using System.Security.Cryptography;
using Sprint_0.Scripts.Commands;

namespace Sprint_0.Scripts.Enemy
{
    public class EnemyRandomInvoker
    {
        private static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        private byte[] random;
        List<ICommand> commands;

        public EnemyRandomInvoker()
        {
            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            randomDir = new RNGCryptoServiceProvider();
        }

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void ExecuteRandomCommand()
        {
            randomDir.GetBytes(random);
            commands[random[ObjectConstants.firstInArray] % commands.Count].Execute();
        }
    }
}
