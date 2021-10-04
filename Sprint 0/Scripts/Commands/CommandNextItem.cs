namespace Sprint_0.Scripts.Commands
{
	public class CommandNextItem : ICommand
	{
		private Game1 game;

		public CommandNextItem(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			this.game.itemSet.sprint2Item = game.itemSet.sprint2Cycle.getNextItem();
		}
	}
}