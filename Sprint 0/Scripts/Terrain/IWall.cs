using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Collider.Terrain;

public interface IWall
{
    public IWallCollider Collider { get; }
    void Update();
    void Draw(SpriteBatch spriteBatch);
    void SwapDoor();

}
