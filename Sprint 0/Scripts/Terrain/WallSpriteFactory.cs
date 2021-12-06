using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;

class WallSpriteFactory
{
    private Texture2D overworldSpritesheet;
    private Texture2D dungeonSpritesheet;
    private Texture2D dungeon1RoomSpritesheet;

    private static WallSpriteFactory instance = new WallSpriteFactory();

    public static WallSpriteFactory Instance
    {
        get
        {
            return instance;
        }
    }

    private WallSpriteFactory()
    {
    }

    public void LoadAllTextures(ContentManager content)
    {
        //Handled by TerrainSpriteFactory
    }

    public IWall CreateWallFromString(String str, Vector2 location, Room room, String nextRoom)
    {
        switch (str)
        {
            case ObjectConstants.EastBombableSpriteStr:
                return CreateEastBombableSprite(location, room, nextRoom);
            case ObjectConstants.EastBombedSpriteStr:
                return CreateEastBombedSprite(location, room, nextRoom);
            case ObjectConstants.EastClosedSpriteStr:
                return CreateEastClosedSprite(location, room, nextRoom);
            case ObjectConstants.EastDoorSpriteStr:
                return CreateEastDoorSprite(location, room, nextRoom);
            case ObjectConstants.EastLockedSpriteStr:
                return CreateEastLockedSprite(location, room, nextRoom);
            case ObjectConstants.EastWallSpriteStr:
                return CreateEastWallSprite(location, room);
            case ObjectConstants.NorthBombableSpriteStr:
                return CreateNorthBombableSprite(location, room, nextRoom);
            case ObjectConstants.NorthBombedSpriteStr:
                return CreateNorthBombedSprite(location, room, nextRoom);
            case ObjectConstants.NorthClosedSpriteStr:
                return CreateNorthClosedSprite(location, room, nextRoom);
            case ObjectConstants.NorthDoorSpriteStr:
                return CreateNorthDoorSprite(location, room, nextRoom);
            case ObjectConstants.NorthLockedSpriteStr:
                return CreateNorthLockedSprite(location, room, nextRoom);
            case ObjectConstants.NorthWallSpriteStr:
                return CreateNorthWallSprite(location, room);
            case ObjectConstants.WestBombableSpriteStr:
                return CreateWestBombableSprite(location, room, nextRoom);
            case ObjectConstants.WestBombedSpriteStr:
                return CreateWestBombedSprite(location, room, nextRoom);
            case ObjectConstants.WestClosedSpriteStr:
                return CreateWestClosedSprite(location, room, nextRoom);
            case ObjectConstants.WestDoorSpriteStr:
                return CreateWestDoorSprite(location, room, nextRoom);
            case ObjectConstants.WestLockedSpriteStr:
                return CreateWestLockedSprite(location, room, nextRoom);
            case ObjectConstants.WestWallSpriteStr:
                return CreateWestWallSprite(location, room);
            case ObjectConstants.SouthBombableSpriteStr:
                return CreateSouthBombableSprite(location, room, nextRoom);
            case ObjectConstants.SouthBombedSpriteStr:
                return CreateSouthBombedSprite(location, room, nextRoom);
            case ObjectConstants.SouthClosedSpriteStr:
                return CreateSouthClosedSprite(location, room, nextRoom);
            case ObjectConstants.SouthDoorSpriteStr:
                return CreateSouthDoorSprite(location, room, nextRoom);
            case ObjectConstants.SouthLockedSpriteStr:
                return CreateSouthLockedSprite(location, room, nextRoom);
            case ObjectConstants.SouthWallSpriteStr:
                return CreateSouthWallSprite(location, room);
            case ObjectConstants.InvisibleWallStr:
                return CreateInvisibleWallSprite(location, room);
            default:
                return new EastBombedSprite(location, room, nextRoom);
        }
    }
    public IWall CreateInvisibleWallSprite(Vector2 location, Room room)
    {
        return new InvisibleWall(location, room);
    }

    public IWall CreateEastBombableSprite(Vector2 location, Room room, String nextRoom)
    {
        return new EastBombableSprite(location, room, nextRoom);
    }

    public IWall CreateEastBombedSprite(Vector2 location, Room room, String nextRoom)
    {
        return new EastBombedSprite(location, room, nextRoom);
    }

    public IWall CreateEastClosedSprite(Vector2 location, Room room, String nextRoom)
    {
        return new EastClosedSprite(location, room, nextRoom);
    }
    public IWall CreateEastDoorSprite(Vector2 location, Room room, String nextRoom)
    {
        return new EastDoorSprite(location, room, nextRoom);
    }
    public IWall CreateEastLockedSprite(Vector2 location, Room room, String nextRoom)
    {
        return new EastLockedSprite(location, room, nextRoom);
    }
    public IWall CreateEastWallSprite(Vector2 location, Room room)
    {
        return new EastWallSprite(location, room);
    }
    public IWall CreateNorthBombableSprite(Vector2 location, Room room, String nextRoom)
    {
        return new NorthBombableSprite(location, room, nextRoom);
    }
    public IWall CreateNorthBombedSprite(Vector2 location, Room room, String nextRoom)
    {
        return new NorthBombedSprite(location, room, nextRoom);
    }
    public IWall CreateNorthClosedSprite(Vector2 location, Room room, String nextRoom)
    {
        return new NorthClosedSprite(location, room, nextRoom);
    }
    public IWall CreateNorthDoorSprite(Vector2 location, Room room, String nextRoom)
    {
        return new NorthDoorSprite(location, room, nextRoom);
    }
    public IWall CreateNorthLockedSprite(Vector2 location, Room room, String nextRoom)
    {
        return new NorthLockedSprite(location, room, nextRoom);
    }
    public IWall CreateNorthWallSprite(Vector2 location, Room room)
    {
        return new NorthWallSprite(location, room);
    }
    public IWall CreateWestBombableSprite(Vector2 location, Room room, String nextRoom)
    {
        return new WestBombableSprite(location, room, nextRoom);
    }
    public IWall CreateWestBombedSprite(Vector2 location, Room room, String nextRoom)
    {
        return new WestBombedSprite(location, room, nextRoom);
    }
    public IWall CreateWestClosedSprite(Vector2 location, Room room, String nextRoom)
    {
        return new WestClosedSprite(location, room, nextRoom);
    }
    public IWall CreateWestDoorSprite(Vector2 location, Room room, String nextRoom)
    {
        return new WestDoorSprite(location, room, nextRoom);
    }
    public IWall CreateWestLockedSprite(Vector2 location, Room room, String nextRoom)
    {
        return new WestLockedSprite(location, room, nextRoom);
    }
    public IWall CreateWestWallSprite(Vector2 location, Room room)
    {
        return new WestWallSprite(location, room);
    }
    public IWall CreateSouthBombableSprite(Vector2 location, Room room, String nextRoom)
    {
        return new SouthBombableSprite(location, room, nextRoom);
    }
    public IWall CreateSouthBombedSprite(Vector2 location, Room room, String nextRoom)
    {
        return new SouthBombedSprite(location, room, nextRoom);
    }
    public IWall CreateSouthClosedSprite(Vector2 location, Room room, String nextRoom)
    {
        return new SouthClosedSprite(location, room, nextRoom);
    }
    public IWall CreateSouthDoorSprite(Vector2 location, Room room, String nextRoom)
    {
        return new SouthDoorSprite(location, room, nextRoom);
    }
    public IWall CreateSouthLockedSprite(Vector2 location, Room room, String nextRoom)
    {
        return new SouthLockedSprite(location, room, nextRoom);
    }
    public IWall CreateSouthWallSprite(Vector2 location, Room room)
    {
        return new SouthWallSprite(location, room);
    }
}
