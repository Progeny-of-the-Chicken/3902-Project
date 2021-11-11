using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Collider.Terrain;
using System;

public interface IWall
{
    public IWallCollider Collider { get; }
    public String NextRoom { get; }
    void Update();
    void Draw(SpriteBatch spriteBatch);
    void SwapDoor();

}
