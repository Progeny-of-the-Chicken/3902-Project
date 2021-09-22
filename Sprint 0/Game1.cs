using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint_0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        KeyboardController kc;
        MouseController mc;
        SpriteText credits;

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
            
            //Just for sprint 2
            blockNum = 0;
            blockLocation = new Vector2(GetCenterScreen().X - 64, GetCenterScreen().Y + 32);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.LoadContent();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TerrainSpriteFactory.Instance.LoadAllTextures(this.Content);
            // TODO: use this.Content to load your game content here
            sprite = new Sprite1(this.GetCenterScreen());
            sprite.LoadContent(this.Content);
            credits = new SpriteText(this.GetCenterScreen());
            credits.LoadContent(this.Content);

            //Just for sprint 2
            block = new Tile(blockLocation);
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            kc.Update();
            mc.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            credits.Draw(this._spriteBatch, gameTime);
            
            //Just for sprint 2
            block.Draw(_spriteBatch);
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

        public void SetSprite(ISprite s)
        {
            this.sprite = s;
            sprite.LoadContent(this.Content);
        }

        //Just for sprint 2
        private void SetBlock()
        {
            switch(blockNum % 10)
            {
                case 0:
                    block = new Tile(blockLocation);
                    break;
                case 1:
                    block = new Block(blockLocation);
                    break;
                case 2:
                    block = new DownStatue(blockLocation);
                    break;
                case 3:
                    block = new UpStatue(blockLocation);
                    break;
                case 4:
                    block = new BlackTile(blockLocation);
                    break;
                case 5:
                    block = new DungeonSand(blockLocation);
                    break;
                case 6:
                    block = new DungeonWater(blockLocation);
                    break;
                case 7:
                    block = new Stair(blockLocation);
                    break;
                case 8:
                    block = new BWWall(blockLocation);
                    break;
                case 9:
                    block = new BWLadder(blockLocation);
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
