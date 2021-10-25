using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;

public class NorthDoorSprite : IWall
{
    private Rectangle spritesheetLocation = new Rectangle(848, 11, 32, 32);
    Rectangle destination;
    OpenWallCollider collider;
    public IWallCollider Collider { get => Collider; }
    Room room;

    public NorthDoorSprite(Vector2 screenLocation, Room room)
    { 
        destination = new Rectangle((int) screenLocation.X,(int) screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
        Rectangle hitbox = destination;
        hitbox.Height -= 8 * ObjectConstants.scale;
        collider = new OpenWallCollider(this, hitbox);
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