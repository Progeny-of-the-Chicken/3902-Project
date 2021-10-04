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

        //Just for sprint 2
        ITerrain block;
        Vector2 blockLocation;
        int blockNum;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            kc = new KeyboardController(this);
            mc = new MouseController(this);
            
			enemyStart = GetCenterScreen();

            //Just for sprint 2
            blockNum = 0;
            blockLocation = new Vector2(GetCenterScreen().X - 64, GetCenterScreen().Y + 32);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TerrainSpriteFactory.Instance.LoadAllTextures(this.Content);
            // TODO: use this.Content to load your game content here
            EnemySpriteFactory.Instance.LoadAllTextures(this.Content);
            SetEnemy(enemyIndex);

			//Just for sprint 2
            block = new TileSprite(blockLocation);
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
            
            //Just for sprint 2
            block.Draw(_spriteBatch);
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

        //Just for sprint 2
        private void SetBlock()
        {
            switch(blockNum % 10)
            {
                case 0:
                    block = new TileSprite(blockLocation);
                    break;
                case 1:
                    block = new BlockSprite(blockLocation);
                    break;
                case 2:
                    block = new DownStatueSprite(blockLocation);
                    break;
                case 3:
                    block = new UpStatueSprite(blockLocation);
                    break;
                case 4:
                    block = new BlackTileSprite(blockLocation);
                    break;
                case 5:
                    block = new DungeonSandSprite(blockLocation);
                    break;
                case 6:
                    block = new DungeonWaterSprite(blockLocation);
                    break;
                case 7:
                    block = new StairSprite(blockLocation);
                    break;
                case 8:
                    block = new BWWallSprite(blockLocation);
                    break;
                case 9:
                    block = new BWLadderSprite(blockLocation);
                    break;
                default:
                    //uh oh
                    break;
            }
        }

        //Just for sprint 2
        public void NextBlock()
        {
            blockNum++;
            SetBlock();
        }

        //Just for sprint 2
        public void PrevBlock()
        {
            blockNum--;
            if (blockNum == -1)
            {
                blockNum = 9;
            }
            SetBlock();
        }


    }
}
