using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;
using System;

public class EastBombableSprite : IWall
{
    private Rectangle spritesheetLocation = new Rectangle(814, 77, 32, 32);
    Rectangle destination;
    BombableWallCollider collider;
    public IWallCollider Collider { get => collider; }
    Room room;
    string nextRoom;
    public String NextRoom { get => nextRoom; }

    public EastBombableSprite(Vector2 screenLocation, Room room)
    {
        destination = new Rectangle((int)screenLocation.X, (int)screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
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
        CommandSwapDoor command = new CommandSwapDoor(room, this, "EastBombedSprite");
        command.Execute();
    }
}