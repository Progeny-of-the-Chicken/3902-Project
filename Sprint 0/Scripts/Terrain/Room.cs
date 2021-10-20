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
	private string filePath;
	private int scale;
	private string[] blockColliders;
	private string[] enemies;
    private string[] items;

	//want to make change the doors into one line instead of 8 lines
    private string[] eastDoor;
	private string[] northDoor;
	private string[] westDoor;
	private string[] southDoor;
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
		spriteBatch.Draw(texture, new Rectangle(0, 64 * scale, 256 * scale, 176 * scale), spritesheetLocation, Color.White);
	}

	void LoadRoom()
	{
		spritesheetLocation = new Rectangle(257 * (int)roomLocation.X, 177 * (int)roomLocation.Y, 256, 176);

		ReadCSV();
		LoadBlockColliders();
		LoadEnemies();
		LoadItems();
		LoadDoors();
		LoadSpecial();
	}

	void ReadCSV()
	{
		//Setup CSV file and parser
		//Relative paths are a pain to figure out right now, ask during code review
		filePath = @"C:\Users\oshii\source\repos\Sprint 0\3902-Project\Sprint 0\Scripts\Terrain\LevelData\Dungeon1\Room";
		filePath += roomLocation.X.ToString() + roomLocation.Y.ToString() + ".csv";
		TextFieldParser csvReader = new TextFieldParser(filePath);
		csvReader.Delimiters = new string[] { "," };

		//Read csv file to string arrays
		blockColliders = csvReader.ReadFields();
		enemies = csvReader.ReadFields();
		items = csvReader.ReadFields();
		eastDoor = csvReader.ReadFields();
		if (!csvReader.EndOfData) northDoor = csvReader.ReadFields();
		if (!csvReader.EndOfData) westDoor = csvReader.ReadFields();
		if (!csvReader.EndOfData) southDoor = csvReader.ReadFields();
		if (!csvReader.EndOfData) special = csvReader.ReadFields();
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
