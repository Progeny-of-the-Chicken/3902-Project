namespace Sprint_0.Scripts.Commands
{
	public class CommandLastItem : ICommand
	{
		private Game1 game;

		public CommandLastItem(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			this.game.ic.sprint2Item = game.ic.sprint2Cycle.getLastItem();
		}
	}
}
