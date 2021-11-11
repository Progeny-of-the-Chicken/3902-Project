using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Scripts.Collider.Terrain;

public class StairSprite : ITerrain
{
    private Rectangle spritesheetLocation = SpriteRectangles.StairFrame;
    Rectangle destination;
    StairCollider collider;
    public IBlockCollider Collider { get => collider; }

    public StairSprite(Vector2 screenLocation)
    {
        destination = new Rectangle((int)screenLocation.X, (int)screenLocation.Y, ObjectConstants.scale * spritesheetLocation.Width, ObjectConstants.scale * spritesheetLocation.Height);
        this.collider = new StairCollider(this, destination);
    }

    public void Update()
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D texture = TerrainSpriteFactory.Instance.GetDungeonSpritesheet();
        spriteBatch.Draw(texture, destination, spritesheetLocation, Color.White);
    }

}