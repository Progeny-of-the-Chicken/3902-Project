﻿using System;
using Sprint_0;
using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Commands
{
    public class Command3Boomerang : ICommand
    {
        private Game1 game;

        public Command3Boomerang(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // TODO: Move item factory dependency to player sprite class
            game.itemSet.items.Add(ItemSpriteFactory.Instance.CreateBoomerang(game.GetCenterScreen(), Boomerang.Direction.DOWN, false));
        }
    }
}
