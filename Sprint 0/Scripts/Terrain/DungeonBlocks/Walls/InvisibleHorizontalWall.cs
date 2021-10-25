using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;

public class InvisibleHorizontalWall : IWall
{
    private Rectangle spritesheetLocation = new Rectangle(814, 143, 112, 32);
    Rectangle destination;

    public InvisibleHorizontalWall(Vector2 screenLocation)
    { 
        destination = new Rectangle((int) screenLocation.X,(int) screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
    }

    public void Update()
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
    }

}