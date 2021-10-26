using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Collider.Terrain;

public interface ITerrain
{
    public IBlockCollider Collider { get; }
    void Update();
    void Draw(SpriteBatch spriteBatch);
}
