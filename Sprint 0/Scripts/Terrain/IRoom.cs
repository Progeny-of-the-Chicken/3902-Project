using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Projectiles;

public interface IRoom
{
	void Update(GameTime gt);
	void Draw(SpriteBatch spriteBatch);
	string RoomId();
	void AddProjectile(IProjectile item);
}
