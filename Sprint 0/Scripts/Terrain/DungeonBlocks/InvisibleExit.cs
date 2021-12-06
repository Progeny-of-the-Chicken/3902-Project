using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;

public class InvisibleExit : ITerrain
{
    private Rectangle spritesheetLocation = SpriteRectangles.StairFrame;
    Rectangle destination;
    InvisibleExitCollider collider;
    public IBlockCollider Collider { get => collider; }

    public InvisibleExit(Vector2 screenLocation)
    {
        destination = new Rectangle((int)screenLocation.X, (int)screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
        this.collider = new InvisibleExitCollider(this, destination);
    }

    public void Update()
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {

    }

}