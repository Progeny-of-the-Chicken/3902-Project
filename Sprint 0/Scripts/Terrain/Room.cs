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
using Sprint_0.Scripts.Sets;

public class Room : IRoom
{
	private Vector2 roomLocation;
	private Rectangle spritesheetLocation;
	private string roomId;
	private string filePath;
	private int scale;
	private int YOFFSET;
	private int WALLOFFSET;
	private ILink link;
	private EnemySet enemySet;
	private ItemEntities itemSet;
	private ProjectileEntities projectileSet;
	private List<ITerrain> blocks;

	public Room(string roomId, ILink link)
	{
		this.scale = Constants.scale;
		this.WALLOFFSET = 32 * this.scale;
		this.YOFFSET = 64 * this.scale;

		this.roomId = roomId;
		int roomRow, roomCol;
		roomRow = Int32.Parse(roomId.Substring(5, 1));
		roomCol = Int32.Parse(roomId.Substring(4, 1));
		roomLocation = new Vector2(roomCol, roomRow);

		this.link = link;
		enemySet = new EnemySet();
		itemSet = new ItemEntities();
		projectileSet = new ProjectileEntities();
		blocks = new List<ITerrain>();

		LoadRoom();
	}

	public void Update(GameTime gt)
	{
		link.Update(gt);
		enemySet.Update(gt);
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
		spriteBatch.Draw(texture, new Rectangle(0, YOFFSET, 256 * scale, 176 * scale), spritesheetLocation, Color.White);

		link.Draw(spriteBatch);
		enemySet.Draw(spriteBatch);
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

		filePath = Environment.CurrentDirectory.ToString() + @"/../../../Scripts/Terrain/LevelData/Dungeon1/" + roomId + ".csv";
		TextFieldParser csvReader = new TextFieldParser(filePath);
		csvReader.Delimiters = new string[] { "," };

		LoadBlockColliders(csvReader);
        LoadEnemies(csvReader);
        LoadItems(csvReader);
        LoadDoors(csvReader);
		if (!csvReader.EndOfData) LoadSpecial(csvReader);
    }

	void LoadBlockColliders(TextFieldParser csvReader)
	{
		string[] blockColliderString = csvReader.ReadFields();
	}

	void LoadEnemies(TextFieldParser csvReader)
	{
		string[] enemyString = csvReader.ReadFields();
		for (int i = 0; i < enemyString.Length; i+= 2)
        {
			if (!enemyString[i].Equals(""))
            {
				//first string in each pair notates location
				float enemyLocationX = float.Parse(enemyString[i].Substring(0, enemyString[i].IndexOf(" "))) * 16 * this.scale + WALLOFFSET;
				float enemyLocationY = float.Parse(enemyString[i].Substring(enemyString[i].IndexOf(" "))) * 16 * this.scale + YOFFSET + WALLOFFSET;
				Vector2 enemyLocation = new Vector2(enemyLocationX, enemyLocationY);

				//second string in each pair notates enemy type
				switch (enemyString[i+1])
                {
					case "Aquamentus":
						enemySet.Add(EnemyFactory.Instance.CreateAquamentus(enemyLocation, scale));
						break;
					case "Gel":
						enemySet.Add(EnemyFactory.Instance.CreateGel(enemyLocation, scale));
						break;
					case "Goriya":
						enemySet.Add(EnemyFactory.Instance.CreateGoriya(enemyLocation, scale));
						break;
					case "Keese":
						enemySet.Add(EnemyFactory.Instance.CreateKeese(enemyLocation, scale));
						break;
					case "OldMan":
						enemySet.Add(EnemyFactory.Instance.CreateOldMan(enemyLocation, scale));
						break;
					case "Stalfos":
						enemySet.Add(EnemyFactory.Instance.CreateStalfos(enemyLocation, scale));
						break;
					case "Zol":
						enemySet.Add(EnemyFactory.Instance.CreateZol(enemyLocation, scale));
						break;
					default:
						Console.WriteLine("Typo in Room " + roomId);
						break;
				}
            }
        }
	}

	void LoadItems(TextFieldParser csvReader)
	{
		string[] itemString = csvReader.ReadFields();
		for (int i = 0; i < itemString.Length; i += 2)
		{
			if (!itemString[i].Equals(""))
			{
				//first string in each pair notates location
				float itemLocationX = float.Parse(itemString[i].Substring(0, itemString[i].IndexOf(" "))) * 16 * this.scale + WALLOFFSET;
				float itemLocationY = float.Parse(itemString[i].Substring(itemString[i].IndexOf(" "))) * 16 * this.scale + YOFFSET + WALLOFFSET;
				Vector2 itemLocation = new Vector2(itemLocationX, itemLocationY);

				switch(itemString[i+1])
                {
					case "Compass":
						itemSet.Add(ItemFactory.Instance.CreateCompass(itemLocation));
						break;
					case "HeartContainer":
						itemSet.Add(ItemFactory.Instance.CreateHeartContainer(itemLocation));
						break;
					case "Key":
						itemSet.Add(ItemFactory.Instance.CreateBasicKey(itemLocation));
						break;
					case "Map":
						itemSet.Add(ItemFactory.Instance.CreateBasicMapItem(itemLocation));
						break;
					case "TriforcePiece":
						itemSet.Add(ItemFactory.Instance.CreateTriforcePiece(itemLocation));
						break;
					default:
						Console.WriteLine("Type in Room " + roomId);
						break;
                }
			}
		}
			}

	void LoadDoors(TextFieldParser csvReader)
	{
		string[] doorString = csvReader.ReadFields();
		for (int i = 0; i < doorString.Length; i += 2)
        {
			if (doorString[i] != "")
            {
				float doorLocationX;
				float doorLocationY;
				if (i % 4 == 0)
                {
					doorLocationY = YOFFSET + 88 * scale; 
					if (i == 0)
                    {
						doorLocationX = 144 * scale;
                    } else
                    {
						doorLocationX = 0;
                    }
                } else
                {
					doorLocationX = 112 * scale;
					if (i == 2)
                    {
						doorLocationY = YOFFSET;
                    } else
                    {
						doorLocationY = YOFFSET + 144 * scale;
					}
					Vector2 doorLocation = new Vector2(doorLocationX, doorLocationY);
				}
			}
			//Do one of the many doors
        }
	}

	void LoadSpecial(TextFieldParser csvReader)
	{
		string[] specialString = csvReader.ReadFields();
	}

	public void AddProjectile(IProjectile item)
    {
		projectileSet.Add(item);
    }
}
