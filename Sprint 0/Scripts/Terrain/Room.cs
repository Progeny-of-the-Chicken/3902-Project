using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using Sprint_0;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Projectiles;
using System;

public class Room : IRoom
{
	private Vector2 roomLocation;
	private Rectangle spritesheetLocation;
	private string roomId;
	private string filePath;
	private int scale;
	private ILink link;
	private List<IEnemy> enemies;
	private ItemEntities itemSet;
	private ProjectileEntities projectileSet;
	private List<ITerrain> blocks;

	//want to make change the doors into one line instead of 8 lines
	private string[] eastDoor;
	private string[] northDoor;
	private string[] westDoor;
	private string[] southDoor;
	private string[] special;

	public Room(string roomId, ILink link)
	{
		this.scale = Constants.scale;
		this.roomId = roomId;
		int roomRow, roomCol;
		roomRow = Int32.Parse(roomId.Substring(4, 1));
		roomCol = Int32.Parse(roomId.Substring(5, 1));
		roomLocation = new Vector2(roomCol, roomRow);
		this.link = link;
		enemies = new List<IEnemy>();
		itemSet = new ItemEntities();
		projectileSet = new ProjectileEntities();
		blocks = new List<ITerrain>();
		LoadRoom();
	}

	public void Update(GameTime gt)
	{
		link.Update(gt);
        foreach (IEnemy enemy in enemies)
        {
			enemy.Update(gt);
        }
		itemSet.Update(gt);
		projectileSet.Update(gt);
		foreach(ITerrain block in blocks)
        {
			block.Update();
        }
	}


	public void Draw(SpriteBatch spriteBatch)
	{
		//This needs to be updated once we have more than dungeon 1
		Texture2D texture = TerrainSpriteFactory.Instance.GetDungeon1RoomSpritesheet();
		spriteBatch.Draw(texture, new Rectangle(0, 64 * scale, 256 * scale, 176 * scale), spritesheetLocation, Color.White);

		link.Draw(spriteBatch);
		foreach (IEnemy enemy in enemies)
		{
			enemy.Draw(spriteBatch);
		}
		itemSet.Draw(spriteBatch);
		projectileSet.Draw(spriteBatch);
		foreach (ITerrain block in blocks)
		{
			block.Draw(spriteBatch);
		}
	}

	public string RoomId()
    {
		return roomId;
    }

	public void LoadRoom()
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
		///Users/davidnovikov/Documents/3902-Project/Sprint 0/bin/Debug/netcoreapp3.
        filePath = Environment.CurrentDirectory.ToString() + @"/../../../Scripts/Terrain/LevelData/Dungeon1/" + roomId + ".csv";
		TextFieldParser csvReader = new TextFieldParser(filePath);
		csvReader.Delimiters = new string[] { "," };
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
		//Todo
	}

	void LoadDoors()
	{
		//Todo
	}

	void LoadSpecial()
	{
		//Todo
	}

	public void AddProjectile(IProjectile item)
    {
		projectileSet.Add(item);
    }
}
