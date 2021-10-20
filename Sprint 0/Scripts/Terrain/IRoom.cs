using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IRoom
{
	void Update(GameTime gt);
	void Draw(SpriteBatch spriteBatch);
	void LoadRoom();
	string RoomId();
}
