using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts;
using Sprint_0.Scripts.Collider.Terrain;

public class NorthBombableSprite : IWall
{
    private Rectangle spritesheetLocation = SpriteRectangles.NorthBombableSpriteFrame;
    Rectangle destination;
    BombableWallCollider collider;
    public IWallCollider Collider { get => collider; }
    Room room;
    string nextRoom;
    public String NextRoom { get => nextRoom; }

    public NorthBombableSprite(Vector2 screenLocation, Room room, String nextRoom)
    {
        destination = new Rectangle((int)screenLocation.X, (int)screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
        collider = new BombableWallCollider(this, destination);
        this.room = room;
        this.nextRoom = nextRoom;
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
        CommandSwapDoor command = new CommandSwapDoor(room, this, ObjectConstants.NorthBombedSpriteStr);
        command.Execute();
    }

}