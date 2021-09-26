using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        KeyboardController kc;
        MouseController mc;

        IEnemy enemy;
        Vector2 enemyStart;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            kc = new KeyboardController(this);
            mc = new MouseController(this);

            enemyStart = GetCenterScreen();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //this.LoadContent();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            /*
            sprite = new Sprite1(this.GetCenterScreen());
            sprite.LoadContent(this.Content);
            credits = new SpriteText(this.GetCenterScreen());
            credits.LoadContent(this.Content);
            */
            EnemySpriteFactory.Instance.LoadAllTextures(this.Content);
            enemy = EnemyFactory.Instance.CreateStalfos(enemyStart);
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            kc.Update(gameTime);
            mc.Update(gameTime);

            enemy.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            enemy.Draw(_spriteBatch);
            //sprite.Draw(this._spriteBatch, gameTime);
            //credits.Draw(this._spriteBatch, gameTime);
            _spriteBatch.End();
        }

        public void Quit()
        {
            Exit();
        }
        public Vector2 GetCenterScreen()
        {
            return new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        }

        /*
        public void SetSprite(ISprite s)
        {
            this.sprite = s;
            sprite.LoadContent(this.Content);
        }
        */
    }
}
