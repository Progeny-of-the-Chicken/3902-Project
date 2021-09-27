﻿using System;
using Sprint_0;
using Sprint_0.Scripts.Items;

public class Command1Arrow : ICommand
{
	private Game1 game;

	public Command1Arrow(Game1 game)
	{
		this.game = game;
	}

	public void Execute()
	{
		// TODO: Move item factory dependency to player sprite class
		game.ic.items.Add(ItemSpriteFactory.Instance.CreateArrow(game.GetCenterScreen(), Arrow.Direction.RIGHT, false));
	}
}
