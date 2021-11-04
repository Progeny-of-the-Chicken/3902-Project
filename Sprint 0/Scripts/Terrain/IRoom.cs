using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Effect;

public interface IRoom
{
	void Update(GameTime gt);
	void Draw(SpriteBatch spriteBatch);
	string RoomId();
	void AddProjectile(IProjectile item);
	void AddEffect(IEffect effect);
}
