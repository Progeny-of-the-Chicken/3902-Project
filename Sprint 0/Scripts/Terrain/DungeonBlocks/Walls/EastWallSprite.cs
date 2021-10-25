using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;

public class EastWallSprite : IWall
{
    private Rectangle spritesheetLocation = new Rectangle(815, 77, 32, 32);
    Rectangle destination;
    GenericWallCollider collider;
    public IWallCollider Collider { get => collider; }
    Room room;

    public EastWallSprite(Vector2 screenLocation, Room room)
    { 
        destination = new Rectangle((int) screenLocation.X,(int) screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
        collider = new GenericWallCollider(this, this.destination);
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