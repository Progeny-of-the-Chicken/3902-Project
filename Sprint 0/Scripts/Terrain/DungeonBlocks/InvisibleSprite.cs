using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;

public class InvisibleNonMovingSprite : ITerrain
{
    Rectangle destination;

    public InvisibleNonMovingSprite(Vector2 screenLocation)
    { 
        destination = new Rectangle((int) screenLocation.X,(int) screenLocation.Y, ObjectConstants.scale * ObjectConstants.squareTileWidthHeight, ObjectConstants.scale * ObjectConstants.squareTileWidthHeight);
    }

    public void Update()
    {
        //Doesn't need to update
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        //Not drawing anything lol
    }

}