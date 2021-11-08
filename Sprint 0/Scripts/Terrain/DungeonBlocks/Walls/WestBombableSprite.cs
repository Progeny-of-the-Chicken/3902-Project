using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts;
using Sprint_0.Scripts.Collider.Terrain;

public class WestBombableSprite : IWall
{
    private Rectangle spritesheetLocation = new Rectangle(815, 44, 32, 32);
    Rectangle destination;
    BombableWallCollider collider;
    public IWallCollider Collider { get => collider; }
    Room room;

    public WestBombableSprite(Vector2 screenLocation, Room room)
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
        CommandSwapDoor command = new CommandSwapDoor(room, this, "WestBombedSprite");
        command.Execute();
        SFXManager.Instance.PlaySecretFound();
    }

}