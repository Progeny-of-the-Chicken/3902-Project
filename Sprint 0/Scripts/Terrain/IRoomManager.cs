using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;

public interface IRoomManager
{
    void Update(GameTime gt);
    void Draw(SpriteBatch spriteBatch);
    void SwitchToRoom(string roomID);
    IRoom CurrentRoom { get; }
    void Init(ILink player);
    IRoom LoadRoom(string roomID);
}

