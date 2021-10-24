using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;

class TerrainSpriteFactory
{
    private Texture2D overworldSpritesheet;
    private Texture2D dungeonSpritesheet;
    private Texture2D dungeon1RoomSpritesheet;

    private static TerrainSpriteFactory instance = new TerrainSpriteFactory();

    public static TerrainSpriteFactory Instance
    {
        get
        {
            return instance;
        }
    }

    private TerrainSpriteFactory()
    {
    }

    public void LoadAllTextures(ContentManager content)
    {
        overworldSpritesheet = content.Load<Texture2D>("OverworldTileset");
        dungeonSpritesheet = content.Load<Texture2D>("dungeonTileset");
        dungeon1RoomSpritesheet = content.Load<Texture2D>("Dungeon1Eagle");
    }

    public Texture2D GetOverworldSpritesheet()
    {
        return overworldSpritesheet;
    }

    public Texture2D GetDungeonSpritesheet()
    {
        return dungeonSpritesheet;
    }

    public Texture2D GetDungeon1RoomSpritesheet()
    {
        return dungeon1RoomSpritesheet;
    }
}
