using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;

public class EastDoorSprite : IWall
{
    private Rectangle spritesheetLocation = SpriteRectangles.EastDoorSpriteFrame;
    Rectangle destination;
    OpenWallCollider collider;
    public IWallCollider Collider { get => collider; }
    Room room;
    string nextRoom;
    public String NextRoom { get => nextRoom; }
    private string roomID;

    public EastDoorSprite(Vector2 screenLocation, Room room)
    {
        destination = new Rectangle((int)screenLocation.X, (int)screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
        Rectangle hitbox = destination;
        hitbox.X += 8 * ObjectConstants.scale;
        hitbox.Width -= 8 * ObjectConstants.scale;
        collider = new OpenWallCollider(this, hitbox);
        this.room = room;
        nextRoom = this.room.RoomId();
        int roomX = (int)nextRoom[4] - '0' + 1;
        nextRoom = nextRoom.Substring(0, nextRoom.Length - 2) + roomX + nextRoom.Substring(nextRoom.Length - 1);
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