using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Controller;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0
{
    public enum FacingDirection { Right, Left, Up, Down };
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        KeyboardController kc;
        public ItemEntities itemSet;
        public Link link;


        //Just for sprint 2
        ITerrain block;
        Vector2 blockLocation;
        int blockNum;

        IEnemy enemy;
        Vector2 enemyStart;
        int enemyCount = 7;
        int enemyIndex = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            link = new Link();

            kc = new KeyboardController(this);


            //Just for sprint 2
            blockNum = 0;
            blockLocation = new Vector2(GetCenterScreen().X - 64, GetCenterScreen().Y + 32);
            enemyStart.X = GetCenterScreen().X * 1.5f;
            enemyStart.Y = GetCenterScreen().Y * 0.5f;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            LinkSpriteFactory.Instance.LoadAllTextures(this.Content);
            TerrainSpriteFactory.Instance.LoadAllTextures(this.Content);
            ItemSpriteFactory.Instance.LoadAllTextures(this.Content);
            EnemySpriteFactory.Instance.LoadAllTextures(this.Content);

            //Just for sprint 2
            SetEnemy(enemyIndex);
            block = new TileSprite(blockLocation);
            itemSet = new ItemEntities(this);
            itemSet.sprint2Item = ItemFactory.Instance.CreateBlueRuby(this.GetCenterScreen());

			base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            kc.Update();

            //Just for Sprint 2
            itemSet.Update(gameTime);
            enemy.Update(gameTime);
            link.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            
			      link.Draw(_spriteBatch, gameTime);

            //Just for sprint 2
            block.Draw(_spriteBatch);
            enemy.Draw(_spriteBatch);
            itemSet.Draw(_spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
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
                    enemy = EnemyFactory.Instance.CreateStalfos(enemyStart, 2);
                    break;
                case 1:
                    enemy = EnemyFactory.Instance.CreateOldMan(enemyStart, 2);
                    break;
                case 2:
                    enemy = EnemyFactory.Instance.CreateGel(enemyStart, 2);
                    break;
                case 3:
                    enemy = EnemyFactory.Instance.CreateZol(enemyStart, 2);
                    break;
                case 4:
                    enemy = EnemyFactory.Instance.CreateKeese(enemyStart, 2);
                    break;
                case 5:
                    enemy = EnemyFactory.Instance.CreateGoriya(enemyStart, 2);
                    break;
                case 6:
                    enemy = EnemyFactory.Instance.CreateAquamentus(enemyStart, 2);
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
            switch (blockNum % 10)
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
