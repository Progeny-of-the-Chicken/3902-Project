using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;

public class NorthBombableSprite : IWall
{
    private Rectangle spritesheetLocation = new Rectangle(815, 11, 32, 32);
    Rectangle destination;
    BombableWallCollider collider;
    public IWallCollider Collider { get => collider; }
    Room room;

    public NorthBombableSprite(Vector2 screenLocation, Room room)
    { 
        destination = new Rectangle((int) screenLocation.X,(int) screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
        collider = new BombableWallCollider(this, destination);
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
        System.Diagnostics.Debug.WriteLine("Blowing up door");
        CommandSwapDoor command = new CommandSwapDoor(room, this, "NorthBombedSprite");
        command.Execute();
    }

}