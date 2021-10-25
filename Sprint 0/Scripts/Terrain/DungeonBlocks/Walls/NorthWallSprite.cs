using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;

public class NorthWallSprite : IWall
{
    private Rectangle spritesheetLocation = new Rectangle(815, 11, 32, 32);
    Rectangle destination;
    GenericWallCollider collider;
    public IWallCollider Collider { get => collider; }
    Room room;

    public NorthWallSprite(Vector2 screenLocation, Room room)
    { 
        destination = new Rectangle((int) screenLocation.X,(int) screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
        collider = new GenericWallCollider(this, destination);
        this.room = room;
    }

    public void Update()
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D texture = TerrainSpriteFactory.Instance.GetDungeonSpritesheet();
        spriteBatch.Draw(texture, destination, spritesheetLocation, Color.White);
    }

    public void SwapDoor()
    {

    }
}