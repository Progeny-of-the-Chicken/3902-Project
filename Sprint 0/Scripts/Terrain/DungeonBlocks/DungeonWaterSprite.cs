using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;

public class DungeonWaterSprite : ITerrain
{
    private Rectangle spritesheetLocation = new Rectangle(1018, 28, 16, 16);
    Rectangle destination;

    public DungeonWaterSprite(Vector2 screenLocation)
    { 
        destination = new Rectangle((int) screenLocation.X,(int) screenLocation.Y, ObjectConstants.scale*spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
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