using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Effect;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Enemy;

public interface IRoom
{
	void Update(GameTime gt);
	void Draw(SpriteBatch spriteBatch);
	Vector2 roomLocation { get; }
	string RoomId();
	void AddProjectile(IProjectile item);
	void AddEffect(IEffect effect);
	void AddEnemy(IEnemy enemy);
	void AddItem(IItem item);
	void FreezeEnemies();
	void PrepareForTransition(bool leaving);
	void TransitionEnded();
	void UpdateDrawPoint(Vector2 dp);
	Vector2 roomDrawPoint { get; }
	ItemEntities ItemSet { get; }
}
