using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Commands;

namespace Sprint_0.Scripts.Controller
{
	public class KeyboardController : IController
	{
		KeyboardState ks;
		CommandQuit cq;
		CommandNextItem nextItem;
		CommandLastItem lastItem;
		CommandShootArrow useFirstItem;
		CommandThrowBoomerangLink useSecondItem;
		CommandCastFireSpell useThirdItem;
		CommandPlaceBomb useFourthItem;

		private Game1 game;

		public KeyboardController(Game1 game)
		{
			this.game = game;
			cq = new CommandQuit(this.game);
			nextItem = new CommandNextItem(this.game);
			lastItem = new CommandLastItem(this.game);
			useFirstItem = new CommandShootArrow(this.game);
			useSecondItem = new CommandThrowBoomerangLink(this.game);
			useThirdItem = new CommandCastFireSpell(this.game);
			useFourthItem = new CommandPlaceBomb(this.game);
			
			ks = Keyboard.GetState();
		}

		public void Update()
		{
			ks = Keyboard.GetState();

			if (ks.IsKeyDown(Keys.D0) || ks.IsKeyDown(Keys.NumPad0))
			{
				cq.Execute();
			}
			else if (ks.IsKeyDown(Keys.D1) || ks.IsKeyDown(Keys.NumPad1))
			{
				useFirstItem.Execute();
			}
			else if (ks.IsKeyDown(Keys.D2) || ks.IsKeyDown(Keys.NumPad2))
			{
				useSecondItem.Execute();
			}
			else if (ks.IsKeyDown(Keys.D3) || ks.IsKeyDown(Keys.NumPad3))
			{
				useThirdItem.Execute();
			}
			else if (ks.IsKeyDown(Keys.D4) || ks.IsKeyDown(Keys.NumPad4))
			{
				useFourthItem.Execute();
			}
			else if (ks.IsKeyDown(Keys.U))
			{
				nextItem.Execute();
			}
			else if (ks.IsKeyDown(Keys.I))
            {
				lastItem.Execute();
            }
		}
	}
}