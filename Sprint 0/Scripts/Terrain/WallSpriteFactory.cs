using System;
using System.Collections.Generic;
using System.Text;
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

    public IWall CreateWallFromString(String str, Vector2 location)
    {
        switch (str)
        {
            case "EastBombableSprite":
                return CreateEastBombableSprite(location);
            case "EastBombedSprite":
                return CreateEastClosedSprite(location);
            case "EastClosedSprite":
                return CreateEastClosedSprite(location);
            case "EastDoorSprite":
                return CreateEastDoorSprite(location);
            case "EastLockedSprite":
                return CreateEastLockedSprite(location);
            case "EastWallSprite":
                return CreateEastWallSprite(location);
            case "NorthBombableSprite":
                return CreateNorthBombableSprite(location);
            case "NorthBombedSprite":
                return CreateNorthClosedSprite(location);
            case "NorthClosedSprite":
                return CreateNorthClosedSprite(location);
            case "NorthDoorSprite":
                return CreateNorthDoorSprite(location);
            case "NorthLockedSprite":
                return CreateNorthLockedSprite(location);
            case "NorthWallSprite":
                return CreateNorthWallSprite(location);
            case "WestBombableSprite":
                return CreateWestBombableSprite(location);
            case "WestBombedSprite":
                return CreateWestClosedSprite(location);
            case "WestClosedSprite":
                return CreateWestClosedSprite(location);
            case "WestDoorSprite":
                return CreateWestDoorSprite(location);
            case "WestLockedSprite":
                return CreateWestLockedSprite(location);
            case "WestWallSprite":
                return CreateWestWallSprite(location);
            case "SouthBombableSprite":
                return CreateSouthBombableSprite(location);
            case "SouthBombedSprite":
                return CreateSouthClosedSprite(location);
            case "SouthClosedSprite":
                return CreateSouthClosedSprite(location);
            case "SouthDoorSprite":
                return CreateSouthDoorSprite(location);
            case "SouthLockedSprite":
                return CreateSouthLockedSprite(location);
            case "SouthWallSprite":
                return CreateSouthWallSprite(location);
            default:
                return new EastBombedSprite(location);
        }
    }

    public IWall CreateEastBombableSprite(Vector2 location)
    {
        return new EastBombableSprite(location);
    }

    public IWall CreateEastBombedSprite(Vector2 location)
    {
        return new EastBombedSprite(location);
    }

    public IWall CreateEastClosedSprite(Vector2 location)
    {
        return new EastClosedSprite(location);
    }
    public IWall CreateEastDoorSprite(Vector2 location)
    {
        return new EastDoorSprite(location);
    }
    public IWall CreateEastLockedSprite(Vector2 location)
    {
        return new EastLockedSprite(location);
    }
    public IWall CreateEastWallSprite(Vector2 location)
    {
        return new EastWallSprite(location);
    }
    public IWall CreateNorthBombableSprite(Vector2 location)
    {
        return new NorthBombableSprite(location);
    }
    public IWall CreateNorthBombedSprite(Vector2 location)
    {
        return new NorthBombedSprite(location);
    }
    public IWall CreateNorthClosedSprite(Vector2 location)
    {
        return new NorthClosedSprite(location);
    }
    public IWall CreateNorthDoorSprite(Vector2 location)
    {
        return new NorthDoorSprite(location);
    }
    public IWall CreateNorthLockedSprite(Vector2 location)
    {
        return new NorthLockedSprite(location);
    }
    public IWall CreateNorthWallSprite(Vector2 location)
    {
        return new NorthWallSprite(location);
    }
    public IWall CreateWestBombableSprite(Vector2 location)
    {
        return new WestBombableSprite(location);
    }
    public IWall CreateWestBombedSprite(Vector2 location)
    {
        return new WestBombedSprite(location);
    }
    public IWall CreateWestClosedSprite(Vector2 location)
    {
        return new WestClosedSprite(location);
    }
    public IWall CreateWestDoorSprite(Vector2 location)
    {
        return new WestDoorSprite(location);
    }
    public IWall CreateWestLockedSprite(Vector2 location)
    {
        return new WestLockedSprite(location);
    }
    public IWall CreateWestWallSprite(Vector2 location)
    {
        return new WestWallSprite(location);
    }
    public IWall CreateSouthBombableSprite(Vector2 location)
    {
        return new SouthBombableSprite(location);
    }
    public IWall CreateSouthBombedSprite(Vector2 location)
    {
        return new SouthBombedSprite(location);
    }
    public IWall CreateSouthClosedSprite(Vector2 location)
    {
        return new SouthClosedSprite(location);
    }
    public IWall CreateSouthDoorSprite(Vector2 location)
    {
        return new SouthDoorSprite(location);
    }
    public IWall CreateSouthLockedSprite(Vector2 location)
    {
        return new SouthLockedSprite(location);
    }
    public IWall CreateSouthWallSprite(Vector2 location)
    {
        return new SouthWallSprite(location);
    }
}
