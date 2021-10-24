using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class EastBombableSprite : ITerrain
{
    private Rectangle spritesheetLocation = new Rectangle(814, 76, 32, 32);
    Rectangle destination;

    public EastBombableSprite(Vector2 screenLocation, int scale)
    { 
        destination = new Rectangle((int) screenLocation.X,(int) screenLocation.Y, spritesheetLocation.Width * scale, spritesheetLocation.Height * scale);
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