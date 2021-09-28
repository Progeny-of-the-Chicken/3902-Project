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
        int enemyCount = 7;
        int enemyIndex = 0;

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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            EnemySpriteFactory.Instance.LoadAllTextures(this.Content);
            SetEnemy(enemyIndex);
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            kc.Update();
            mc.Update();

            enemy.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            enemy.Draw(_spriteBatch);
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

        void SetEnemy(int i)
        {
            switch (i)
            {
                case 0:
                    enemy = EnemyFactory.Instance.CreateStalfos(enemyStart);
                    break;
                case 1:
                    enemy = EnemyFactory.Instance.CreateOldMan(enemyStart);
                    break;
                case 2:
                    enemy = EnemyFactory.Instance.CreateGel(enemyStart);
                    break;
                case 3:
                    enemy = EnemyFactory.Instance.CreateZol(enemyStart);
                    break;
                case 4:
                    enemy = EnemyFactory.Instance.CreateKeese(enemyStart);
                    break;
                case 5:
                    enemy = EnemyFactory.Instance.CreateGoriya(enemyStart);
                    break;
                case 6:
                    enemy = EnemyFactory.Instance.CreateAquamentus(enemyStart);
                    break;
                default:
                    break;
            }
        }
        public void NextEnemy()
        {
            enemyIndex++;
            enemyIndex %= enemyCount;
            SetEnemy(enemyIndex);
        }
        public void PrevEnemy()
        {
            //Add enemy count to ensure enemyIndex is not negative
            enemyIndex += enemyCount - 1;
            enemyIndex %= enemyCount;
            SetEnemy(enemyIndex);
        }
    }
}
