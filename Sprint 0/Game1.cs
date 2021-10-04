using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Items;
using Sprint_0.Scripts.Controller;

namespace Sprint_0
{
    public enum FacingDirection {Right, Left, Up, Down};
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        private KeyboardController kc;
        public ItemEntities itemSet;

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
            
            //Just for sprint 2
            blockNum = 0;
            blockLocation = new Vector2(GetCenterScreen().X - 64, GetCenterScreen().Y + 32);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TerrainSpriteFactory.Instance.LoadAllTextures(this.Content);
            ItemSpriteFactory.Instance.LoadAllTextures(this.Content);
            // TODO: use this.Content to load your game content here

            //Just for sprint 2
            block = new TileSprite(blockLocation);
            itemSet = new ItemEntities(this);
            itemSet.sprint2Item = ItemFactory.Instance.CreateBlueRuby(this.GetCenterScreen());
        }

        protected override void Update(GameTime gameTime)
        {
            kc.Update();
            itemSet.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            itemSet.Draw(_spriteBatch);

			//Just for sprint 2
            block.Draw(_spriteBatch);
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
