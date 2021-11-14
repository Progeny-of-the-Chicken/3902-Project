using System;
using Microsoft.Xna.Framework;

public interface IController
{
	void Update();
	void SetPauseState(bool paused);
}
