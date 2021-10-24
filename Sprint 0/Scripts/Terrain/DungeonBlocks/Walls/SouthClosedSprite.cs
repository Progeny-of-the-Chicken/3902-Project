using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SouthClosedSprite : ITerrain
{
    private Rectangle spritesheetLocation = new Rectangle(913, 109, 32, 32);
    Rectangle destination;

    public SouthClosedSprite(Vector2 screenLocation, int scale)
    {
        destination = new Rectangle((int)screenLocation.X, (int)screenLocation.Y, spritesheetLocation.Width * scale, spritesheetLocation.Height * scale);
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