﻿using System;
using Sprint_0;
using Sprint_0.Scripts.Items;

public class Command2Arrow : ICommand
{
	private Game1 game;

	public Command2Arrow(Game1 game)
	{
		this.game = game;
	}

	public void Execute()
	{
		// TODO: Move item factory dependency to player sprite class
		game.itemSet.items.Add(ItemFactory.Instance.CreateArrow(game.GetCenterScreen(), Arrow.Direction.UP, false));
	}
}
