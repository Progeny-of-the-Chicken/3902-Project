using System;
using Sprint_0;

public class CommandSwapDoor : ICommand
{
	private Room room;
	IWall doorToSwitch;
	String newDoor;

	public CommandSwapDoor(Room room, IWall doorToSwitch, String newDoor)
	{
		this.room = room;
		this.doorToSwitch = doorToSwitch;
		this.newDoor = newDoor;
	}

	public void Execute()
	{
		room.ChangeDoor(doorToSwitch, newDoor);
	}
}
