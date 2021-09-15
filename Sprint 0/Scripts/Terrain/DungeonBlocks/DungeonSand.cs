using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class DungeonSand : ITerrain
{
    private Rectangle spritesheetLocation = new Rectangle(1000, 27, 16, 16);
    Rectangle destination;

    public DungeonSand(Vector2 screenLocation)
    { 
        destination = new Rectangle((int) screenLocation.X,(int) screenLocation.Y, 2*spritesheetLocation.Width, 2*spritesheetLocation.Height);
    }

    public void Update()
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D texture = TerrainSpriteFactory.Instance.GetDungeonSpritesheet();
        spriteBatch.Draw(texture, destination, spritesheetLocation, Color.White);
    }

}