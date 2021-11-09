using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;

public class SouthBombedSprite : IWall
{
    private Rectangle spritesheetLocation = SpriteRectangles.SouthBombedSpriteFrame;
    Rectangle destination;
    OpenWallCollider collider;
    public IWallCollider Collider { get => collider; }
    Room room;
    string nextRoom;
    public String NextRoom { get => nextRoom; }

    public SouthBombedSprite(Vector2 screenLocation, Room room)
    {
        destination = new Rectangle((int)screenLocation.X, (int)screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
        Rectangle hitbox = destination;
        hitbox.Y += ObjectConstants.wallHitBoxHalfSize * ObjectConstants.scale;
        hitbox.Height -= ObjectConstants.wallHitBoxHalfSize * ObjectConstants.scale;
        collider = new OpenWallCollider(this, hitbox);
        this.room = room;
        nextRoom = this.room.RoomId();
        int roomY = (int)nextRoom[5] - '0' + 1;
        nextRoom = nextRoom.Substring(0, 5) + roomY;
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