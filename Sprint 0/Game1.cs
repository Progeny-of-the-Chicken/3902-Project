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
            roomManager = RoomManager.Instance;
            roomManager.Init(link);
        }

        protected override void Update(GameTime gameTime)
        {
            kc.Update();
            roomManager.Update(gameTime);
            if (!link.IsAlive)
                this.Quit();

            //Just for Sprint 3
            mc.Update();
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

        //Just for sprint 3
        void ChangeRoom()
        {
            switch (roomNum)
            {
                case 0:
                    roomManager.SwitchToRoom("Room25");
                    break;
                case 1:
                    roomManager.SwitchToRoom("Room15");
                    break;
                case 2:
                    roomManager.SwitchToRoom("Room35");
                    break;
                case 3:
                    roomManager.SwitchToRoom("Room24");
                    break;
                case 4:
                    roomManager.SwitchToRoom("Room23");
                    break;
                case 5:
                    roomManager.SwitchToRoom("Room33");
                    break;
                case 6:
                    roomManager.SwitchToRoom("Room13");
                    break;
                case 7:
                    roomManager.SwitchToRoom("Room12");
                    break;
                case 8:
                    roomManager.SwitchToRoom("Room02");
                    break;
                case 9:
                    roomManager.SwitchToRoom("Room22");
                    break;
                case 10:
                    roomManager.SwitchToRoom("Room21");
                    break;
                case 11:
                    roomManager.SwitchToRoom("Room20");
                    break;
                case 12:
                    roomManager.SwitchToRoom("Room10");
                    break;
                case 13:
                    roomManager.SwitchToRoom("Room00");
                    break;
                case 14:
                    roomManager.SwitchToRoom("Room32");
                    break;
                case 15:
                    roomManager.SwitchToRoom("Room42");
                    break;
                case 16:
                    roomManager.SwitchToRoom("Room41");
                    break;
                case 17:
                    roomManager.SwitchToRoom("Room51");
                    break;
                default:
                    break;
            }
        }

        public void NextRoom()
        {
            roomNum++;
            if (roomNum > 17)
            {
                roomNum = 0;
            }
            ChangeRoom();
        }

        public void PrevRoom()
        {
            roomNum--;
            if (roomNum < 0)
            {
                roomNum = 17;
            }
            ChangeRoom();
        }

    }

}
