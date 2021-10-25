using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;

public class InvisibleSprite : ITerrain
{
    private Rectangle spritesheetLocation = new Rectangle(1000, 100, 16, 16);
    Rectangle destination;
    GenericBlockCollider collider;
    public IBlockCollider Collider { get => collider; }

    public InvisibleSprite(Vector2 screenLocation)
    { 
        destination = new Rectangle((int) screenLocation.X,(int) screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
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