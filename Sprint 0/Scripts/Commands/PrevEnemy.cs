using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_0.Scripts.Commands
{
    class PrevEnemy : ICommand
    {
        Game1 game;
        public PrevEnemy(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.PrevEnemy();
        }
    }
}
