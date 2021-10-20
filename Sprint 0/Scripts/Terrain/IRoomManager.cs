using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IRoomManager
{
    void Update(GameTime gt);
    void Draw(SpriteBatch spriteBatch);
    void SwitchToRoom(string roomID);
    IRoom CurrentRoom { get; }
}

