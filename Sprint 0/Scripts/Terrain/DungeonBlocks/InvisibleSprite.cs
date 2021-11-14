using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;

public class InvisibleSprite : ITerrain
{
    Rectangle destination;
    GenericBlockCollider collider;
    public IBlockCollider Collider { get => collider; }

    public InvisibleSprite(Vector2 screenLocation)
    {
        destination = new Rectangle((int)screenLocation.X, (int)screenLocation.Y, ObjectConstants.scaledStdWidthHeight, ObjectConstants.scaledStdWidthHeight);
        this.collider = new GenericBlockCollider(this, destination);
    }

    public void Update()
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        //Just don't
    }

}