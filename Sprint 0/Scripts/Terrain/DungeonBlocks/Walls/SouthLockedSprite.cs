using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;

public class SouthLockedSprite : IWall
{
    private Rectangle spritesheetLocation = SpriteRectangles.SouthLockedSpriteFrame;
    Rectangle destination;
    LockedDoorCollider collider;
    public IWallCollider Collider { get => collider; }
    Room room;
    string nextRoom;
    public String NextRoom { get => nextRoom; }

    public SouthLockedSprite(Vector2 screenLocation, Room room)
    {
        destination = new Rectangle((int)screenLocation.X, (int)screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
        collider = new LockedDoorCollider(this, destination);
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
        CommandSwapDoor command = new CommandSwapDoor(room, this, ObjectConstants.SouthDoorSpriteStr);
        command.Execute();
    }
}