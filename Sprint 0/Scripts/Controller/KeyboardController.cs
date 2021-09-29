using Microsoft.Xna.Framework.Input;
using Sprint_0;
using Sprint_0.Scripts.Commands;

namespace Sprint_0.Scripts.Controller
{
	public class KeyboardController : IController
	{
		private enum testProjectile { ARROW, BOOMERANG, FIRESPELL, BOMB };

		KeyboardState ks;
		CommandQuit cq;
		Command1Arrow a1;
		Command2Arrow a2;
		Command3Arrow a3;
		Command4Arrow a4;
		Command1Boomerang b1;
		Command2Boomerang b2;
		Command3Boomerang b3;
		Command4Boomerang b4;
		Command1FireSpell f1;
		Command2FireSpell f2;
		Command3FireSpell f3;
		Command4FireSpell f4;
		Command1Bomb bomb1;
		Command2Bomb bomb2;
		Command3Bomb bomb3;
		Command4Bomb bomb4;
		CommandNextItem nextItem;
		CommandLastItem lastItem;
		private Game1 game;

		public KeyboardController(Game1 game)
		{
			this.game = game;
			cq = new CommandQuit(this.game);
			a1 = new Command1Arrow(this.game);
			a2 = new Command2Arrow(this.game);
			a3 = new Command3Arrow(this.game);
			a4 = new Command4Arrow(this.game);
			b1 = new Command1Boomerang(this.game);
			b2 = new Command2Boomerang(this.game);
			b3 = new Command3Boomerang(this.game);
			b4 = new Command4Boomerang(this.game);
			f1 = new Command1FireSpell(this.game);
			f2 = new Command2FireSpell(this.game);
			f3 = new Command3FireSpell(this.game);
			f4 = new Command4FireSpell(this.game);
			bomb1 = new Command1Bomb(this.game);
			bomb2 = new Command2Bomb(this.game);
			bomb3 = new Command3Bomb(this.game);
			bomb4 = new Command4Bomb(this.game);
			nextItem = new CommandNextItem(this.game);
			lastItem = new CommandLastItem(this.game);
			ks = Keyboard.GetState();
		}

		public void Update()
		{
			ks = Keyboard.GetState();

			// TODO: Remove test code before merging
			testProjectile testValue = testProjectile.FIRESPELL;

			if (ks.IsKeyDown(Keys.D0) || ks.IsKeyDown(Keys.NumPad0))
			{
				cq.Execute();
			}
			else if (ks.IsKeyDown(Keys.D1) || ks.IsKeyDown(Keys.NumPad1))
			{
				if (testValue == testProjectile.ARROW)
				{
					a1.Execute();
				}
				else if (testValue == testProjectile.BOOMERANG)
				{
					b1.Execute();
				}
				else if (testValue == testProjectile.FIRESPELL)
                {
					f1.Execute();
                }
				else if (testValue == testProjectile.BOMB)
				{
					bomb1.Execute();
				}
			}
			else if (ks.IsKeyDown(Keys.D2) || ks.IsKeyDown(Keys.NumPad2))
			{
				if (testValue == testProjectile.ARROW)
				{
					a2.Execute();
				}
				else if (testValue == testProjectile.BOOMERANG)
				{
					b2.Execute();
				}
				else if (testValue == testProjectile.FIRESPELL)
				{
					f2.Execute();
				}
				else if (testValue == testProjectile.BOMB)
				{
					bomb2.Execute();
				}
			}
			else if (ks.IsKeyDown(Keys.D3) || ks.IsKeyDown(Keys.NumPad3))
			{
				if (testValue == testProjectile.ARROW)
				{
					a3.Execute();
				}
				else if (testValue == testProjectile.BOOMERANG)
				{
					b3.Execute();
				}
				else if (testValue == testProjectile.FIRESPELL)
				{
					f3.Execute();
				}
				else if (testValue == testProjectile.BOMB)
				{
					bomb3.Execute();
				}
			}
			else if (ks.IsKeyDown(Keys.D4) || ks.IsKeyDown(Keys.NumPad4))
			{
				if (testValue == testProjectile.ARROW)
				{
					a4.Execute();
				}
				else if (testValue == testProjectile.BOOMERANG)
				{
					b4.Execute();
				}
				else if (testValue == testProjectile.FIRESPELL)
				{
					f4.Execute();
				}
				else if (testValue == testProjectile.BOMB)
				{
					bomb4.Execute();
				}
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