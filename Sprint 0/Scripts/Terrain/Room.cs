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
using Sprint_0.Scripts.Terrain;

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
	private List<IWall> walls;
	private CollisionHandlerSet collisionHandlerSet;
	private List<IProjectile> projectileQueue;

	public Room(string roomId, ILink link)
	{
		this.scale = ObjectConstants.scale;
		this.WALLOFFSET = 33 * this.scale;
		this.YOFFSET = 63 * this.scale;

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
		walls = new List<IWall>();

		projectileQueue = new List<IProjectile>();

		LoadRoom();

		collisionHandlerSet = new CollisionHandlerSet(link, enemySet.Enemies, itemSet.itemSet, projectileSet.ProjectileSet, new HashSet<ITerrain>(blocks), new HashSet<IWall>(walls));
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
		collisionHandlerSet.Update();
	}


	public void Draw(SpriteBatch spriteBatch)
	{
		//This needs to be updated once we have more than dungeon 1
		Texture2D texture = TerrainSpriteFactory.Instance.GetDungeon1RoomSpritesheet();
		spriteBatch.Draw(texture, new Rectangle(0, YOFFSET, 256 * scale, 176 * scale), spritesheetLocation, Color.White);

		foreach (ITerrain block in blocks)
		{
			block.Draw(spriteBatch);
		}

		AddQueuedProjectiles();

		foreach (IWall door in walls)
		{
			door.Draw(spriteBatch);
		}
		itemSet.Draw(spriteBatch);
		projectileSet.Draw(spriteBatch);
		enemySet.Draw(spriteBatch);
		link.Draw(spriteBatch);
	}

	public string RoomId()
    {
		return roomId;
    }

	//Start csv parsing
	public void LoadRoom()
	{
        spritesheetLocation = new Rectangle(257 * (int)roomLocation.X + 1, 177 * (int)roomLocation.Y + 1, 256, 176);

		filePath = Environment.CurrentDirectory.ToString() + @"/../../../Scripts/Terrain/LevelData/Dungeon1/" + roomId + ".csv";
		TextFieldParser csvReader = new TextFieldParser(filePath);
		csvReader.Delimiters = new string[] { "," };

		LoadBlockColliders(csvReader);
        LoadEnemies(csvReader);
        LoadItems(csvReader);
		if (!csvReader.EndOfData) LoadDoors(csvReader);
		if (!csvReader.EndOfData) LoadSpecial(csvReader);

		ObjectsFromObjectsFactory.Instance.LoadRoom(this);
    }

	void LoadBlockColliders(TextFieldParser csvReader)
	{
		string[] blockColliderString = csvReader.ReadFields();
		if (blockColliderString[0] != "None")
		{
			for (int i = 0; i < blockColliderString.Length; i++)
			{
				if (!blockColliderString[i].Equals(""))
				{
					//first string in each pair notates location
					float blockLocationX = float.Parse(blockColliderString[i].Substring(0, blockColliderString[i].IndexOf(" "))) * 16 * this.scale + WALLOFFSET - this.scale;
					float blockLocationY = float.Parse(blockColliderString[i].Substring(blockColliderString[i].IndexOf(" "))) * 16 * this.scale + YOFFSET + WALLOFFSET - this.scale;
					Vector2 blockLocation = new Vector2(blockLocationX, blockLocationY);

					blocks.Add(new InvisibleSprite(blockLocation));
				}
			}
		}
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
					case "BowItem":
						itemSet.Add(ItemFactory.Instance.CreateBowItem(itemLocation));
						break;
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
		Vector2 doorLocation = new Vector2(0, YOFFSET);
		//Add 8 Wall segments
		//North wall left side
		walls.Add(new InvisibleHorizontalWall(doorLocation, this));
		//West wall top side
		walls.Add(new InvisibleVerticleWall(doorLocation, this));
		//North wall right side
		doorLocation.X = scale * 144;
		walls.Add(new InvisibleHorizontalWall(doorLocation, this));
		//East wall top side
		doorLocation.X = scale * 224;
		walls.Add(new InvisibleVerticleWall(doorLocation, this));
		//East wall bottom side
		doorLocation.Y += scale * 104;
		walls.Add(new InvisibleVerticleWall(doorLocation, this));
		//West wall bottom side
		doorLocation.X = 0;
		walls.Add(new InvisibleVerticleWall(doorLocation, this));
		//South wall left side
		doorLocation.Y = YOFFSET + scale * 144;
		walls.Add(new InvisibleHorizontalWall(doorLocation, this));
		//South wall right side
		doorLocation.X = scale * 144;
		walls.Add(new InvisibleHorizontalWall(doorLocation, this));

		string[] doorString = csvReader.ReadFields();
		
		//East
		doorLocation.X = 224 * scale;
		doorLocation.Y = YOFFSET + 72 * scale;
		if (doorString[0] != "")
			walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorString[0], doorLocation, this));
		else
			walls.Add(WallSpriteFactory.Instance.CreateEastWallSprite(doorLocation, this));
		
		//North
		doorLocation.X = 112 * scale;
		doorLocation.Y = YOFFSET;
		if (doorString.Length > 2 && doorString[2] != "")
			walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorString[2], doorLocation, this));
		else
			walls.Add(WallSpriteFactory.Instance.CreateNorthWallSprite(doorLocation, this));
		
		//West
		doorLocation.X = 0;
		doorLocation.Y = YOFFSET + 72 * scale;
		if (doorString.Length > 4 && doorString[4] != "")
			walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorString[4], doorLocation, this));
		else
			walls.Add(WallSpriteFactory.Instance.CreateWestWallSprite(doorLocation, this));

		//South
		doorLocation.X = 112 * scale;
		doorLocation.Y = YOFFSET + 144 * scale;
		if (doorString.Length > 6 && doorString[6] != "")
			walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorString[6], doorLocation, this));
		else
			walls.Add(WallSpriteFactory.Instance.CreateSouthWallSprite(doorLocation, this));

	}

	void LoadSpecial(TextFieldParser csvReader)
	{
		string[] specialString = csvReader.ReadFields();
	}

	public void AddProjectile(IProjectile item)
    {
		projectileQueue.Add(item);
    }

	private void AddQueuedProjectiles()
    {
		foreach (IProjectile projectile in projectileQueue)
        {
			projectileSet.Add(projectile);
        }
    }

	public void ChangeDoor(IWall doorToRemove, String doorToAdd)
    {
		Vector2 doorLocation = new Vector2(doorToRemove.Collider.Hitbox.X, doorToRemove.Collider.Hitbox.Y);
		walls.Remove(doorToRemove);
		walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorToAdd, doorLocation, this));
    }
}
