using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Controller;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.SpriteFactories;
using Sprint_0.Scripts;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0
{
    public enum FacingDirection { Right, Left, Up, Down };
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        KeyboardController kc;
        public Link link;
        public IRoomManager roomManager;

        int scale = 3;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            link = new Link();
            kc = new KeyboardController(this);

        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 256 * scale;
            _graphics.PreferredBackBufferHeight = 240 * scale;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            LinkSpriteFactory.Instance.LoadAllTextures(this.Content);
            TerrainSpriteFactory.Instance.LoadAllTextures(this.Content);
            ItemSpriteFactory.Instance.LoadAllTextures(this.Content);
            ProjectileSpriteFactory.Instance.LoadAllTextures(this.Content);
            EnemySpriteFactory.Instance.LoadAllTextures(this.Content);

            base.LoadContent();
            roomManager = RoomManager.Instance;
            roomManager.Init(link);
        }

        protected override void Update(GameTime gameTime)
        {
            kc.Update();
            roomManager.Update(gameTime);
            if (!link.IsAlive)
                this.Quit();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            roomManager.Draw(_spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Quit()
        {
            Exit();
        }

    }
}
