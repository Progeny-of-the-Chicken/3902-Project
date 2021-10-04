using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Commands
{
    class NextEnemy : ICommand
    {
        Game1 game;
        public NextEnemy(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.NextEnemy();
        }
    }
}
