using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;

public class MoveableBlockSprite : ITerrain
{
    private Rectangle spritesheetLocation = SpriteRectangles.MovableBlockFrame;
    Rectangle destination;
    IBlockCollider collider;
    public IBlockCollider Collider { get => collider; }

    public MoveableBlockSprite(Vector2 screenLocation)
    {
        destination = new Rectangle((int)screenLocation.X, (int)screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
        this.collider = new MoveableBlockCollider(this, destination);
    }

    public void Update()
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D texture = TerrainSpriteFactory.Instance.GetDungeonSpritesheet();
        spriteBatch.Draw(texture, destination, spritesheetLocation, Color.White);
    }

    public void MoveBlock(Vector2 direction)
    {
        if (direction.X == ObjectConstants.zero_float)
        {
            if (direction.Y > ObjectConstants.zero_float)
            {
                destination.Y -= ObjectConstants.scale * spritesheetLocation.Width;
            }
            else
            {
                destination.Y += ObjectConstants.scale * spritesheetLocation.Width;
            }
        }
        else
        {
            if (direction.X > ObjectConstants.zero_float)
            {
                destination.X -= ObjectConstants.scale * spritesheetLocation.Width;
            }
            else
            {
                destination.X += ObjectConstants.scale * spritesheetLocation.Width;
            }
        }
        collider = new GenericBlockCollider(this, destination);

    }
}