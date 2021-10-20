using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.VisualBasic.FileIO;
using System.IO;

public class Room : IRoom
{
	private Vector2 roomLocation;
	private Rectangle spritesheetLocation;
	private static string filePath = @"LevelData\Dungeon1\Room";
	private int scale;
	private string[] blockColliders;
	private string[] enemies;
	private string[] items;
	private string[][] doors;
	private string[] special;

	public Room(int scale)
	{
		this.scale = scale;
		//Todo
		roomLocation = new Vector2(2, 5);
		LoadRoom();
	}

	public void Update()
    {
		//Todo
    }

	public void Draw(SpriteBatch spriteBatch)
    {
		//This needs to be updated once we have more than dungeon 1
		Texture2D texture = TerrainSpriteFactory.Instance.GetDungeon1RoomSpritesheet();
		spriteBatch.Draw(texture, new Rectangle(0, 16 * scale, 256 * scale, 176 * scale), spritesheetLocation, Color.White);
	}

	void LoadRoom()
    {
		filePath += roomLocation.X.ToString() + roomLocation.Y.ToString();
		spritesheetLocation = new Rectangle(257 * (int) roomLocation.X, 177 * (int) roomLocation.Y, 256, 176);

		LoadBlockColliders();
		LoadEnemies();
		LoadItems();
		LoadDoors();
		LoadSpecial();
    }

	void LoadBlockColliders()
    {
		//Todo
    }

	void LoadEnemies()
    {
		//Todo
    }

	void LoadItems()
    {

    }

	void LoadDoors()
    {
		//Todo
    }

	void LoadSpecial()
    {
		//Todo
    }
}
