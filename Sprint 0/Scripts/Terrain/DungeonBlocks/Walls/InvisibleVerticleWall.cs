using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;

public class InvisibleVerticleWall : IWall
{
    private Rectangle spritesheetLocation = new Rectangle(814, 143, 32, 72);
    Rectangle destination;
    GenericWallCollider collider;
    public IWallCollider Collider { get => collider; }
    Room room;

    public InvisibleVerticleWall(Vector2 screenLocation, Room room)
    { 
        destination = new Rectangle((int) screenLocation.X,(int) screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
        collider = new GenericWallCollider(this, this.destination);
        this.room = room;
    }

    public void Update()
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
    }

    public void SwapDoor()
    {

    }
}