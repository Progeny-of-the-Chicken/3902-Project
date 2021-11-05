using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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

    public IWall CreateWallFromString(String str, Vector2 location, Room room)
    {
        switch (str)
        {
            case "EastBombableSprite":
                return CreateEastBombableSprite(location, room);
            case "EastBombedSprite":
                return CreateEastClosedSprite(location, room);
            case "EastClosedSprite":
                return CreateEastClosedSprite(location, room);
            case "EastDoorSprite":
                return CreateEastDoorSprite(location, room);
            case "EastLockedSprite":
                return CreateEastLockedSprite(location, room);
            case "EastWallSprite":
                return CreateEastWallSprite(location, room);
            case "NorthBombableSprite":
                return CreateNorthBombableSprite(location, room);
            case "NorthBombedSprite":
                return CreateNorthClosedSprite(location, room);
            case "NorthClosedSprite":
                return CreateNorthClosedSprite(location, room);
            case "NorthDoorSprite":
                return CreateNorthDoorSprite(location, room);
            case "NorthLockedSprite":
                return CreateNorthLockedSprite(location, room);
            case "NorthWallSprite":
                return CreateNorthWallSprite(location, room);
            case "WestBombableSprite":
                return CreateWestBombableSprite(location, room);
            case "WestBombedSprite":
                return CreateWestClosedSprite(location, room);
            case "WestClosedSprite":
                return CreateWestClosedSprite(location, room);
            case "WestDoorSprite":
                return CreateWestDoorSprite(location, room);
            case "WestLockedSprite":
                return CreateWestLockedSprite(location, room);
            case "WestWallSprite":
                return CreateWestWallSprite(location, room);
            case "SouthBombableSprite":
                return CreateSouthBombableSprite(location, room);
            case "SouthBombedSprite":
                return CreateSouthClosedSprite(location, room);
            case "SouthClosedSprite":
                return CreateSouthClosedSprite(location, room);
            case "SouthDoorSprite":
                return CreateSouthDoorSprite(location, room);
            case "SouthLockedSprite":
                return CreateSouthLockedSprite(location, room);
            case "SouthWallSprite":
                return CreateSouthWallSprite(location, room);
            default:
                return new EastBombedSprite(location, room);
        }
    }

    public IWall CreateEastBombableSprite(Vector2 location, Room room)
    {
        return new EastBombableSprite(location, room);
    }

    public IWall CreateEastBombedSprite(Vector2 location, Room room)
    {
        return new EastBombedSprite(location, room);
    }

    public IWall CreateEastClosedSprite(Vector2 location, Room room)
    {
        return new EastClosedSprite(location, room);
    }
    public IWall CreateEastDoorSprite(Vector2 location, Room room)
    {
        return new EastDoorSprite(location, room);
    }
    public IWall CreateEastLockedSprite(Vector2 location, Room room)
    {
        return new EastLockedSprite(location, room);
    }
    public IWall CreateEastWallSprite(Vector2 location, Room room)
    {
        return new EastWallSprite(location, room);
    }
    public IWall CreateNorthBombableSprite(Vector2 location, Room room)
    {
        return new NorthBombableSprite(location, room);
    }
    public IWall CreateNorthBombedSprite(Vector2 location, Room room)
    {
        return new NorthBombedSprite(location, room);
    }
    public IWall CreateNorthClosedSprite(Vector2 location, Room room)
    {
        return new NorthClosedSprite(location, room);
    }
    public IWall CreateNorthDoorSprite(Vector2 location, Room room)
    {
        return new NorthDoorSprite(location, room);
    }
    public IWall CreateNorthLockedSprite(Vector2 location, Room room)
    {
        return new NorthLockedSprite(location, room);
    }
    public IWall CreateNorthWallSprite(Vector2 location, Room room)
    {
        return new NorthWallSprite(location, room);
    }
    public IWall CreateWestBombableSprite(Vector2 location, Room room)
    {
        return new WestBombableSprite(location, room);
    }
    public IWall CreateWestBombedSprite(Vector2 location, Room room)
    {
        return new WestBombedSprite(location, room);
    }
    public IWall CreateWestClosedSprite(Vector2 location, Room room)
    {
        return new WestClosedSprite(location, room);
    }
    public IWall CreateWestDoorSprite(Vector2 location, Room room)
    {
        return new WestDoorSprite(location, room);
    }
    public IWall CreateWestLockedSprite(Vector2 location, Room room)
    {
        return new WestLockedSprite(location, room);
    }
    public IWall CreateWestWallSprite(Vector2 location, Room room)
    {
        return new WestWallSprite(location, room);
    }
    public IWall CreateSouthBombableSprite(Vector2 location, Room room)
    {
        return new SouthBombableSprite(location, room);
    }
    public IWall CreateSouthBombedSprite(Vector2 location, Room room)
    {
        return new SouthBombedSprite(location, room);
    }
    public IWall CreateSouthClosedSprite(Vector2 location, Room room)
    {
        return new SouthClosedSprite(location, room);
    }
    public IWall CreateSouthDoorSprite(Vector2 location, Room room)
    {
        return new SouthDoorSprite(location, room);
    }
    public IWall CreateSouthLockedSprite(Vector2 location, Room room)
    {
        return new SouthLockedSprite(location, room);
    }
    public IWall CreateSouthWallSprite(Vector2 location, Room room)
    {
        return new SouthWallSprite(location, room);
    }
}
