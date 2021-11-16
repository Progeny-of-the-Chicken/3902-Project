using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Commands
{
    public class DropItemCommand : ICommand
    {
        public DropItemCommand()
        { }

        public void Execute() { }
        public void Execute(IEnemy enemy)
        {
            DropHandler.Instance.DropItem(enemy, RoomManager.Instance.CurrentRoom.ItemSet);
        }
    }
}
