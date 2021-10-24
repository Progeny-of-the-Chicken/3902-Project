using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class DownStatueSprite : ITerrain
{
    private Rectangle spritesheetLocation = new Rectangle(1018, 11, 16, 16);
    Rectangle destination;

    public DownStatueSprite(Vector2 screenLocation, int scale)
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