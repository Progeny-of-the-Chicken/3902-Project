using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Controller;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.SpriteFactories;
using Sprint_0.Scripts.Terrain;
using Sprint_0.Scripts.Effect;
using Sprint_0.Scripts;
using Sprint_0.GameStateHandlers;

namespace Sprint_0
{
    public enum FacingDirection { Right, Left, Up, Down };
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        KeyboardController kc;
        public Link link;
        public GameStateMachine gameStateMachine;

        int scale = 3;

        //Just for Sprint 3
        int roomNum = 0;
        MouseController mc;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            link = new Link();
            kc = new KeyboardController(this);

            //Just for Sprint 3
            mc = new MouseController(this);
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
            EffectSpriteFactory.Instance.LoadAllTextures(this.Content);

            base.LoadContent();

            gameStateMachine = new GameStateMachine(link);
        }

        protected override void Update(GameTime gameTime)
        {
            kc.Update();
            if (!link.IsAlive)
                this.Quit();

            //Just for Sprint 3
            mc.Update();

            gameStateMachine.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            gameStateMachine.Draw(_spriteBatch, gameTime);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Quit()
        {
            Exit();
        }
    }

}
