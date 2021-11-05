﻿using System.Collections.Generic;
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
    private EffectSet effectSet;
    private List<ITerrain> blocks;
    private List<IWall> walls;
    private CollisionHandlerSet collisionHandlerSet;
    private List<IProjectile> projectileQueue;
    private List<IEffect> effectQueue;

    private bool enemiesFlag;
    private List<String> RoomClear;

    public Room(string roomId, ILink link)
    {
        this.scale = ObjectConstants.scale;
        this.WALLOFFSET = ObjectConstants.wallOffset;
        this.YOFFSET = ObjectConstants.yOffsetForRoom;

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
        spriteBatch.Draw(texture, new Rectangle(ObjectConstants.xOffsetForRoom, YOFFSET, ObjectConstants.roomWidth * scale, ObjectConstants.roomHeight * scale), spritesheetLocation, Color.White);

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
        enemySet.Draw(spriteBatch);
        link.Draw(spriteBatch);
        effectSet.Draw(spriteBatch);
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
                    float blockLocationX = float.Parse(blockColliderString[i].Substring(ObjectConstants.xPosForParse, blockColliderString[i].IndexOf(ObjectConstants.spaceStr))) * 16 * this.scale + WALLOFFSET;
                    float blockLocationY = float.Parse(blockColliderString[i].Substring(blockColliderString[i].IndexOf(ObjectConstants.spaceStr))) * 16 * this.scale + YOFFSET + WALLOFFSET;
                    Vector2 blockLocation = new Vector2(blockLocationX, blockLocationY);

                    blocks.Add(new InvisibleSprite(blockLocation));
                }
            }
        }
    }

    void LoadEnemies(TextFieldParser csvReader)
    {
        string[] enemyString = csvReader.ReadFields();
        for (int i = 0; i < enemyString.Length; i += 2)
        {
            if (!enemyString[i].Equals(""))
            {
                //first string in each pair notates location
                float enemyLocationX = float.Parse(enemyString[i].Substring(ObjectConstants.xPosForParse, enemyString[i].IndexOf(ObjectConstants.spaceStr))) * 16 * this.scale + WALLOFFSET;
                float enemyLocationY = float.Parse(enemyString[i].Substring(enemyString[i].IndexOf(ObjectConstants.spaceStr))) * 16 * this.scale + YOFFSET + WALLOFFSET;
                Vector2 enemyLocation = new Vector2(enemyLocationX, enemyLocationY);

                //second string in each pair notates enemy type
                switch (enemyString[i + 1])
                {
                    case "Aquamentus":
                        enemySet.Add(EnemyFactory.Instance.CreateAquamentus(enemyLocation));
                        break;
                    case "BladeTrap":
                        enemySet.Add(EnemyFactory.Instance.CreateSpikeTrap(enemyLocation));
                        break;
                    case "Gel":
                        enemySet.Add(EnemyFactory.Instance.CreateGel(enemyLocation));
                        break;
                    case "Goriya":
                        enemySet.Add(EnemyFactory.Instance.CreateGoriya(enemyLocation));
                        break;
                    case "Keese":
                        enemySet.Add(EnemyFactory.Instance.CreateKeese(enemyLocation));
                        break;
                    case "OldMan":
                        enemySet.Add(EnemyFactory.Instance.CreateOldMan(enemyLocation));
                        break;
                    case "Stalfos":
                        enemySet.Add(EnemyFactory.Instance.CreateStalfos(enemyLocation));
                        break;
                    case "WallMaster":
                        enemySet.Add(EnemyFactory.Instance.CreateWallMaster(enemyLocation));
                        break;
                    case "Zol":
                        enemySet.Add(EnemyFactory.Instance.CreateZol(enemyLocation));
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
                float itemLocationX = float.Parse(itemString[i].Substring(ObjectConstants.xPosForParse, itemString[i].IndexOf(ObjectConstants.spaceStr))) * 16 * this.scale + WALLOFFSET;
                float itemLocationY = float.Parse(itemString[i].Substring(itemString[i].IndexOf(ObjectConstants.spaceStr))) * 16 * this.scale + YOFFSET + WALLOFFSET;
                Vector2 itemLocation = new Vector2(itemLocationX, itemLocationY);

                switch (itemString[i + 1])
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
        {
            walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorString[0], doorLocation, this));
            if (doorString[0].Equals("EastClosedSprite"))
            {
                enemiesFlag = true;
                RoomClear.Add(doorString[0]);
            }
        }
        else
            walls.Add(WallSpriteFactory.Instance.CreateEastWallSprite(doorLocation, this));

        //North
        doorLocation.X = 112 * scale;
        doorLocation.Y = YOFFSET;
        if (doorString.Length > 2 && doorString[2] != "")
        {
            walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorString[2], doorLocation, this));
            if (doorString[2].Equals("NorthClosedSprite"))
            {
                enemiesFlag = true;
                RoomClear.Add(doorString[2]);
            }
        }
        else
            walls.Add(WallSpriteFactory.Instance.CreateNorthWallSprite(doorLocation, this));

        //West
        doorLocation.X = 0;
        doorLocation.Y = YOFFSET + 72 * scale;
        if (doorString.Length > 4 && doorString[4] != "")
        {
            walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorString[4], doorLocation, this));
            if (doorString[4].Equals("WestClosedSprite"))
            {
                enemiesFlag = true;
                RoomClear.Add(doorString[4]);
            }
        }
        else
            walls.Add(WallSpriteFactory.Instance.CreateWestWallSprite(doorLocation, this));

        //South
        doorLocation.X = 112 * scale;
        doorLocation.Y = YOFFSET + 144 * scale;
        if (doorString.Length > 6 && doorString[6] != "")
        {
            walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorString[6], doorLocation, this));
            if (doorString[6].Equals("SouthClosedSprite"))
            {
                enemiesFlag = true;
                RoomClear.Add(doorString[6]);
            }
        }
        else
            walls.Add(WallSpriteFactory.Instance.CreateSouthWallSprite(doorLocation, this));

    }

    void LoadSpecial(TextFieldParser csvReader)
    {
        string[] specialString = csvReader.ReadFields();
        for (int i = 0; i < specialString.Length; i += 2)
        {
            if (specialString[i] == "")
            {
                break;
            }
            float specialLocationX = float.Parse(specialString[i].Substring(ObjectConstants.xPosForParse, specialString[i].IndexOf(ObjectConstants.spaceStr))) * 16 * this.scale + WALLOFFSET;
            float specialLocationY = float.Parse(specialString[i].Substring(specialString[i].IndexOf(ObjectConstants.spaceStr))) * 16 * this.scale + YOFFSET + WALLOFFSET;
            Vector2 specialLocation = new Vector2(specialLocationX, specialLocationY);
            switch (specialString[i + 1])
            {
                case "MoveableBlockSprite":
                    blocks.Add(new MoveableBlockSprite(specialLocation));
                    break;
                case "StairSprite":
                    blocks.Add(new StairSprite(specialLocation));
                    break;
                case "HeartContainer":
                case "Key":
                    enemiesFlag = true;
                    RoomClear.Add(specialString[i]);
                    RoomClear.Add(specialString[i + 1]);
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
        walls.Remove(doorToRemove);
        walls.Add(WallSpriteFactory.Instance.CreateWallFromString(doorToAdd, doorLocation, this));
    }

    public bool isAllEnemiesDead()
    {
        return enemySet.Enemies.Count == 0;
    }

    private void RoomCleared()
    {
        String[] strArray = RoomClear.ToArray();
        for (int i = 0; i < strArray.Length; i++)
        {
            enemiesFlag = false;
            switch (strArray[i])
            {
                case "EastClosedSprite":
                    ChangeDoor(walls.ToArray()[8], "EastDoorSprite");
                    break;
                case "NorthClosedSprite":
                    ChangeDoor(walls.ToArray()[9], "NorthDoorSprite");
                    break;
                case "WestClosedSprite":
                    ChangeDoor(walls.ToArray()[10], "WestDoorSprite");
                    break;
                case "SouthClosedSprite":
                    ChangeDoor(walls.ToArray()[11], "SouthDoorSprite");
                    break;
                default:
                    //Not a door
                    float specialLocationX = float.Parse(strArray[i].Substring(ObjectConstants.xPosForParse, strArray[i].IndexOf(ObjectConstants.spaceStr))) * 16 * this.scale + WALLOFFSET;
                    float specialLocationY = float.Parse(strArray[i].Substring(strArray[i].IndexOf(ObjectConstants.spaceStr))) * 16 * this.scale + YOFFSET + WALLOFFSET;
                    Vector2 specialLocation = new Vector2(specialLocationX, specialLocationY);
                    i++;
                    switch (strArray[i])
                    {
                        case "Key":
                            itemSet.Add(ItemFactory.Instance.CreateBasicKey(specialLocation));
                            break;
                        case "HeartContainer":
                            itemSet.Add(ItemFactory.Instance.CreateHeartContainer(specialLocation));
                            break;
                    }
                    break;
            }
        }
    }
}
