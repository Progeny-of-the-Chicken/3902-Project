using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.VisualBasic.FileIO;
using Sprint_0;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Projectiles;
using System;
using Sprint_0.Scripts.Sets;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.Effect;
using Sprint_0.Scripts;

public class Room : IRoom
{
    public Vector2 roomLocation { get; }
    private Rectangle spritesheetLocation;
    private string roomId;
    private string filePath;
    private int scale;
	private int WALLOFFSET;
    private int YOFFSET;
	private Vector2 _roomDrawPoint;
	public Vector2 roomDrawPoint { get => _roomDrawPoint; }

	private ILink link;
	private EnemySet enemySet;
	private ItemEntities itemSet;
	private ProjectileEntities projectileSet;
	private EffectSet effectSet;
	private List<ITerrain> blocks;
	private List<IWall> walls;
	private CollisionHandlerSet collisionHandlerSet;
	private List<IProjectile> projectileQueue;
	private List<IEffect> effectQueue;

	private bool enemiesFlag;
	private List<String> RoomClear;
	private bool inTransition = false;

    public Room(string roomId, ILink link)
    {
        // Point of reference that is used for the Draw() method. Used to easily translate the room during transitions.
        this._roomDrawPoint = new Vector2(ObjectConstants.xPosForWestDoor * scale, ObjectConstants.yPosForNorthDoor * scale + ObjectConstants.yOffsetForRoom);

        this.scale = ObjectConstants.scale;
        this.YOFFSET = ObjectConstants.yOffsetForRoom;
        this.WALLOFFSET = ObjectConstants.wallOffset;
        this.roomId = roomId;
        int roomRow, roomCol;
        roomRow = Int32.Parse(roomId.Substring(ObjectConstants.rowParsePosition, ObjectConstants.rowAndColPraseLen));
        roomCol = Int32.Parse(roomId.Substring(ObjectConstants.colParsePosition, ObjectConstants.rowAndColPraseLen));
        roomLocation = new Vector2(roomCol, roomRow);
        this.link = link;

        enemySet = new EnemySet();
        itemSet = new ItemEntities();
        projectileSet = new ProjectileEntities();
        blocks = new List<ITerrain>();
        walls = new List<IWall>();
        effectSet = new EffectSet();
        enemiesFlag = false;

        RoomClear = new List<string>();

        projectileQueue = new List<IProjectile>();
        effectQueue = new List<IEffect>();

        LoadRoom();
        collisionHandlerSet = new CollisionHandlerSet(link, enemySet.Enemies, itemSet.itemSet, projectileSet.ProjectileSet, new HashSet<ITerrain>(blocks), new HashSet<IWall>(walls));
    }

    public void Update(GameTime gt)
    {
        link.Update(gt);
        enemySet.Update(gt);
        itemSet.Update(gt);
        projectileSet.Update(gt);

        foreach (ITerrain block in blocks)
        {
            block.Update();
        }

        effectSet.Update(gt);
        collisionHandlerSet.Update();

        if (enemiesFlag && isAllEnemiesDead())
        {
            RoomCleared();
        }

        TransferQueuedEffects();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
		//This needs to be updated once we have more than dungeon 1
		Texture2D texture = TerrainSpriteFactory.Instance.GetDungeon1RoomSpritesheet();
		spriteBatch.Draw(texture, new Rectangle((int)_roomDrawPoint.X, (int)_roomDrawPoint.Y, 256 * scale, 176 * scale), spritesheetLocation, Color.White);

		// If room is in transtion state, then we don't need to draw the enemies, items, effects, etc.
		if (!inTransition)
        {
			foreach (ITerrain block in blocks)
			{
				block.Draw(spriteBatch);
			}

			TransferQueuedProjectiles();
			foreach (IWall door in walls)

			{
				door.Draw(spriteBatch);
			}

			itemSet.Draw(spriteBatch);
			projectileSet.Draw(spriteBatch);
			link.Draw(spriteBatch);
			enemySet.Draw(spriteBatch);
			effectSet.Draw(spriteBatch);
		}
	}

    

    public string RoomId()
    {
        return roomId;
    }

    //Start csv parsing
    public void LoadRoom()
    {
        spritesheetLocation = new Rectangle(ObjectConstants.roomWidthForScanIn * (int)roomLocation.X + ObjectConstants.roomReadInAdjustment, ObjectConstants.roomHeightForScanIn * (int)roomLocation.Y + ObjectConstants.roomReadInAdjustment, ObjectConstants.roomWidth, ObjectConstants.roomHeight);

        filePath = Environment.CurrentDirectory.ToString() + ObjectConstants.pathForCsvFiles + roomId + ObjectConstants.cvsExtension;
        TextFieldParser csvReader = new TextFieldParser(filePath);
        csvReader.Delimiters = new string[] { ObjectConstants.separator };

        ObjectsFromObjectsFactory.Instance.LoadRoom(this);

        LoadBlockColliders(csvReader);
        LoadEnemies(csvReader);
        LoadItems(csvReader);
        if (!csvReader.EndOfData) LoadDoors(csvReader);
        if (!csvReader.EndOfData) LoadSpecial(csvReader);
    }

    void LoadBlockColliders(TextFieldParser csvReader)
    {
        string[] blockColliderString = csvReader.ReadFields();
        if (blockColliderString[ObjectConstants.firstInArray] != ObjectConstants.lineIsEmpty)
        {
            for (int i = ObjectConstants.counterInitialVal_int; i < blockColliderString.Length; i++)
            {
                if (!blockColliderString[i].Equals(ObjectConstants.emptyStr))
                {
                    //first string in each pair notates location
                    float blockLocationX = float.Parse(blockColliderString[i].Substring(ObjectConstants.xPosForParse, blockColliderString[i].IndexOf(ObjectConstants.spaceStr))) * ObjectConstants.standardWidthHeight * this.scale + WALLOFFSET;
                    float blockLocationY = float.Parse(blockColliderString[i].Substring(blockColliderString[i].IndexOf(ObjectConstants.spaceStr))) * ObjectConstants.standardWidthHeight * this.scale + YOFFSET + WALLOFFSET;
                    Vector2 blockLocation = new Vector2(blockLocationX, blockLocationY);

                    blocks.Add(new InvisibleSprite(blockLocation));
                }
            }
        }
    }

    void LoadEnemies(TextFieldParser csvReader)
    {
        string[] enemyString = csvReader.ReadFields();
        for (int i = ObjectConstants.counterInitialVal_int; i < enemyString.Length; i += ObjectConstants.coordinateReadInAdjustment)
        {
            if (!enemyString[i].Equals(ObjectConstants.emptyStr))
            {
                //first string in each pair notates location
                float enemyLocationX = float.Parse(enemyString[i].Substring(ObjectConstants.xPosForParse, enemyString[i].IndexOf(ObjectConstants.spaceStr))) * ObjectConstants.standardWidthHeight * this.scale + WALLOFFSET;
                float enemyLocationY = float.Parse(enemyString[i].Substring(enemyString[i].IndexOf(ObjectConstants.spaceStr))) * ObjectConstants.standardWidthHeight * this.scale + YOFFSET + WALLOFFSET;
                Vector2 enemyLocation = new Vector2(enemyLocationX, enemyLocationY);

                //second string in each pair notates enemy type
                switch (enemyString[i + ObjectConstants.nextCharInString])
                {
                    case ObjectConstants.AquamentusStr:
                        enemySet.Add(EnemyFactory.Instance.CreateAquamentus(enemyLocation));
                        break;
                    case ObjectConstants.BladeTrapStr:
                        enemySet.Add(EnemyFactory.Instance.CreateSpikeTrap(enemyLocation));
                        break;
                    case ObjectConstants.GelStr:
                        enemySet.Add(EnemyFactory.Instance.CreateGel(enemyLocation));
                        break;
                    case ObjectConstants.GoriyaStr:
                        enemySet.Add(EnemyFactory.Instance.CreateGoriya(enemyLocation));
                        break;
                    case ObjectConstants.KeeseStr:
                        enemySet.Add(EnemyFactory.Instance.CreateKeese(enemyLocation));
                        break;
                    case ObjectConstants.OldManStr:
                        enemySet.Add(EnemyFactory.Instance.CreateOldMan(enemyLocation));
                        break;
                    case ObjectConstants.StalfosStr:
                        enemySet.Add(EnemyFactory.Instance.CreateStalfos(enemyLocation));
                        break;
                    case ObjectConstants.WallMasterStr:
                        enemySet.Add(EnemyFactory.Instance.CreateWallMaster(enemyLocation));
                        break;
                    case ObjectConstants.ZolStr:
                        enemySet.Add(EnemyFactory.Instance.CreateZol(enemyLocation));
                        break;
                    default:
                        Console.WriteLine(ObjectConstants.typoInRoomMessage + roomId);
                        break;
                }
            }
        }
    }

    void LoadItems(TextFieldParser csvReader)
    {
        string[] itemString = csvReader.ReadFields();
        for (int i = ObjectConstants.counterInitialVal_int; i < itemString.Length; i += ObjectConstants.coordinateReadInAdjustment)
        {
            if (!itemString[i].Equals(ObjectConstants.emptyStr))
            {
                //first string in each pair notates location
                float itemLocationX = float.Parse(itemString[i].Substring(ObjectConstants.xPosForParse, itemString[i].IndexOf(ObjectConstants.spaceStr))) * ObjectConstants.standardWidthHeight * this.scale + WALLOFFSET;
                float itemLocationY = float.Parse(itemString[i].Substring(itemString[i].IndexOf(ObjectConstants.spaceStr))) * ObjectConstants.standardWidthHeight * this.scale + YOFFSET + WALLOFFSET;
                Vector2 itemLocation = new Vector2(itemLocationX, itemLocationY);

                switch (itemString[i + ObjectConstants.nextCharInString])
                {
                    case ObjectConstants.BowItemStr:
                        itemSet.Add(ItemFactory.Instance.CreateBowItem(itemLocation));
                        break;
                    case ObjectConstants.CompassStr:
                        itemSet.Add(ItemFactory.Instance.CreateCompass(itemLocation));
                        break;
                    case ObjectConstants.HeartContainerStr:
                        itemSet.Add(ItemFactory.Instance.CreateHeartContainer(itemLocation));
                        break;
                    case ObjectConstants.KeyStr:
                        itemSet.Add(ItemFactory.Instance.CreateBasicKey(itemLocation));
                        break;
                    case ObjectConstants.MapStr:
                        itemSet.Add(ItemFactory.Instance.CreateBasicMapItem(itemLocation));
                        break;
                    case ObjectConstants.TriforcePieceStr:
                        itemSet.Add(ItemFactory.Instance.CreateTriforcePiece(itemLocation));
                        break;
                    default:
                        Console.WriteLine(ObjectConstants.typoInRoomMessage + roomId);
                        break;
                }
            }
        }
    }

    void LoadDoors(TextFieldParser csvReader)
    {
        Vector2 doorLocation = new Vector2(ObjectConstants.xPosForDoorOrigin, YOFFSET);
        //Add 8 Wall segments
        //North wall left side
        walls.Add(new InvisibleHorizontalWall(doorLocation, this));
        //West wall top side
        walls.Add(new InvisibleVerticleWall(doorLocation, this));
        //North wall right side
        doorLocation.X = scale * ObjectConstants.xPosForDoorRight;
        walls.Add(new InvisibleHorizontalWall(doorLocation, this));
        //East wall top side
        doorLocation.X = scale * ObjectConstants.xPosForEastDoor;
        walls.Add(new InvisibleVerticleWall(doorLocation, this));
        //East wall bottom side
        doorLocation.Y += scale * ObjectConstants.yPosForDoorBottom;
        walls.Add(new InvisibleVerticleWall(doorLocation, this));
        //West wall bottom side
        doorLocation.X = ObjectConstants.zero;
        walls.Add(new InvisibleVerticleWall(doorLocation, this));
        //South wall left side
        doorLocation.Y = YOFFSET + scale * ObjectConstants.yPosForDoorLeft;
        walls.Add(new InvisibleHorizontalWall(doorLocation, this));
        //South wall right side
        doorLocation.X = scale * ObjectConstants.xPosForDoorRight;
        walls.Add(new InvisibleHorizontalWall(doorLocation, this));

        string[] doorString = csvReader.ReadFields();

        //East
        doorLocation.X = ObjectConstants.xPosForEastDoor * scale;
        doorLocation.Y = ObjectConstants.yPosForEastWestDoor * scale + YOFFSET;
        if (doorString[ObjectConstants.firstInArray] != ObjectConstants.emptyStr)
        {
            walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorString[ObjectConstants.firstInArray], doorLocation, this, doorString[ObjectConstants.firstInArray + ObjectConstants.nextInArray]));
            if (doorString[ObjectConstants.firstInArray].Equals(ObjectConstants.EastClosedSpriteStr))
            {
                enemiesFlag = true;
                RoomClear.Add(doorString[ObjectConstants.firstInArray]);
            }
        }
        else
        {
            walls.Add(WallSpriteFactory.Instance.CreateEastWallSprite(doorLocation, this));
        }

        //North
        doorLocation.X = ObjectConstants.xPosForNorthSouthDoor * scale;
        doorLocation.Y = ObjectConstants.yPosForNorthDoor * scale + YOFFSET;
        if (doorString.Length > ObjectConstants.secondDoorInArray && doorString[ObjectConstants.secondDoorInArray] != ObjectConstants.emptyStr)
        {
            walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorString[ObjectConstants.secondDoorInArray], doorLocation, this, doorString[ObjectConstants.secondDoorInArray + ObjectConstants.nextInArray]));
            if (doorString[ObjectConstants.secondDoorInArray].Equals(ObjectConstants.NorthClosedSpriteStr))
            {
                enemiesFlag = true;
                RoomClear.Add(doorString[ObjectConstants.secondDoorInArray]);
            }
        }
        else
        {
            walls.Add(WallSpriteFactory.Instance.CreateNorthWallSprite(doorLocation, this));
        }

        //West
        doorLocation.X = ObjectConstants.xPosForWestDoor * scale;
        doorLocation.Y = ObjectConstants.yPosForEastWestDoor * scale + YOFFSET;
        if (doorString.Length > ObjectConstants.thirdDoorInArray && doorString[ObjectConstants.thirdDoorInArray] != ObjectConstants.emptyStr)
        {
            walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorString[ObjectConstants.thirdDoorInArray], doorLocation, this, doorString[ObjectConstants.thirdDoorInArray + ObjectConstants.nextInArray]));
            if (doorString[ObjectConstants.thirdDoorInArray].Equals(ObjectConstants.WestClosedSpriteStr))
            {
                enemiesFlag = true;
                RoomClear.Add(doorString[ObjectConstants.thirdDoorInArray]);
            }
        }
        else
            walls.Add(WallSpriteFactory.Instance.CreateWestWallSprite(doorLocation, this));

        //South
        doorLocation.X = ObjectConstants.xPosForNorthSouthDoor * scale;
        doorLocation.Y = ObjectConstants.yPosForSouthDoor * scale + YOFFSET;
        if (doorString.Length > ObjectConstants.fourthDoorInArray && doorString[ObjectConstants.fourthDoorInArray] != ObjectConstants.emptyStr)
        {
            walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorString[ObjectConstants.fourthDoorInArray], doorLocation, this, doorString[ObjectConstants.fourthDoorInArray + ObjectConstants.nextInArray]));
            if (doorString[ObjectConstants.fourthDoorInArray].Equals(ObjectConstants.SouthClosedSpriteStr))
            {
                enemiesFlag = true;
                RoomClear.Add(doorString[ObjectConstants.fourthDoorInArray]);
            }
        }
        else
            walls.Add(WallSpriteFactory.Instance.CreateSouthWallSprite(doorLocation, this));

    }

    void LoadSpecial(TextFieldParser csvReader)
    {
        string[] specialString = csvReader.ReadFields();
        for (int i = ObjectConstants.counterInitialVal_int; i < specialString.Length; i += ObjectConstants.coordinateReadInAdjustment)
        {
            if (specialString[i] == ObjectConstants.emptyStr)
            {
                break;
            }
            float specialLocationX = float.Parse(specialString[i].Substring(ObjectConstants.xPosForParse, specialString[i].IndexOf(ObjectConstants.spaceStr))) * ObjectConstants.standardWidthHeight * this.scale + WALLOFFSET;
            float specialLocationY = float.Parse(specialString[i].Substring(specialString[i].IndexOf(ObjectConstants.spaceStr))) * ObjectConstants.standardWidthHeight * this.scale + YOFFSET + WALLOFFSET;
            Vector2 specialLocation = new Vector2(specialLocationX, specialLocationY);
            switch (specialString[i + ObjectConstants.nextCharInString])
            {
                case ObjectConstants.MoveableBlockSpriteStr:
                    blocks.Add(new MoveableBlockSprite(specialLocation));
                    break;
                case ObjectConstants.StairSpriteStr:
                    blocks.Add(new StairSprite(specialLocation));
                    break;
                case ObjectConstants.HeartContainerStr:
                case ObjectConstants.KeyStr:
                    enemiesFlag = true;
                    RoomClear.Add(specialString[i]);
                    RoomClear.Add(specialString[i + ObjectConstants.nextCharInString]);
                    break;
                default:
                    //You shouldn't end up here
                    break;
            }
        }
    }

    public void AddProjectile(IProjectile item)
    {
        projectileQueue.Add(item);
    }

    private void TransferQueuedProjectiles()
    {
        foreach (IProjectile projectile in projectileQueue)
        {
            projectileSet.Add(projectile);
        }
        projectileQueue.Clear();
    }

    public void AddEffect(IEffect effect)
    {
        effectQueue.Add(effect);
    }

    public void AddEnemy(IEnemy enemy)
    {
        enemySet.Add(enemy);
    }

    private void TransferQueuedEffects()
    {
        foreach (IEffect effect in effectQueue)
        {
            effectSet.Add(effect);
        }
        effectQueue.Clear();
    }

    public void ChangeDoor(IWall doorToRemove, String doorToAdd)
    {
        Vector2 doorLocation = new Vector2(doorToRemove.Collider.Hitbox.X, doorToRemove.Collider.Hitbox.Y);
        string nextRoom = doorToRemove.NextRoom;
        if (walls.Remove(doorToRemove))
        {
            walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorToAdd, doorLocation, this, nextRoom));
            System.Diagnostics.Debug.WriteLine(doorToAdd);
            collisionHandlerSet = new CollisionHandlerSet(link, enemySet.Enemies, itemSet.itemSet, projectileSet.ProjectileSet, new HashSet<ITerrain>(blocks), new HashSet<IWall>(walls));
        }
    }

    public bool isAllEnemiesDead()
    {
        return enemySet.Enemies.Count == 0;
    }

    private void RoomCleared()
    {
        String[] strArray = RoomClear.ToArray();
        for (int i = ObjectConstants.counterInitialVal_int; i < strArray.Length; i++)
        {
            enemiesFlag = false;
            switch (strArray[i])
            {
                case ObjectConstants.EastClosedSpriteStr:
                    ChangeDoor(walls.ToArray()[ObjectConstants.EastDoorSpritePos], ObjectConstants.EastDoorSpriteStr);
                    break;
                case ObjectConstants.NorthClosedSpriteStr:
                    ChangeDoor(walls.ToArray()[ObjectConstants.NorthDoorSpritePos], ObjectConstants.NorthDoorSpriteStr);
                    break;
                case ObjectConstants.WestClosedSpriteStr:
                    ChangeDoor(walls.ToArray()[ObjectConstants.WestDoorSpritePos], ObjectConstants.WestDoorSpriteStr);
                    break;
                case ObjectConstants.SouthClosedSpriteStr:
                    ChangeDoor(walls.ToArray()[ObjectConstants.SouthDoorSpritePos], ObjectConstants.SouthDoorSpriteStr);
                    break;
                default:
                    //Not a door
                    float specialLocationX = float.Parse(strArray[i].Substring(ObjectConstants.xPosForParse, strArray[i].IndexOf(ObjectConstants.spaceStr))) * ObjectConstants.standardWidthHeight * this.scale + WALLOFFSET;
                    float specialLocationY = float.Parse(strArray[i].Substring(strArray[i].IndexOf(ObjectConstants.spaceStr))) * ObjectConstants.standardWidthHeight * this.scale + YOFFSET + WALLOFFSET;
                    Vector2 specialLocation = new Vector2(specialLocationX, specialLocationY);
                    i++;
                    switch (strArray[i])
                    {
						case ObjectConstants.KeyStr:
							itemSet.Add(ItemFactory.Instance.CreateBasicKey(specialLocation));
							SFXManager.Instance.PlayKeySpawn();
							break;
						case ObjectConstants.HeartContainerStr:
							itemSet.Add(ItemFactory.Instance.CreateHeartContainer(specialLocation));
							break;
                    }
                    break;
            }
        }
    }

    public void PrepareForTransition()
    {
		inTransition = true;
    }

    public void TransitionEnded()
    {
		inTransition = false;
		this._roomDrawPoint = new Vector2(ObjectConstants.xPosForWestDoor * scale, ObjectConstants.yPosForNorthDoor * scale + ObjectConstants.yOffsetForRoom);
	}

	public void UpdateDrawPoint(Vector2 dp)
    {
		this._roomDrawPoint = dp;
	}
}
