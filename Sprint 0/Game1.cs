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
    public static class Extensions
    {
        public static FacingDirection Opposite(this FacingDirection dir)
        {
            switch (dir)
            {
                case FacingDirection.Left:
                    return FacingDirection.Right;
                case FacingDirection.Right:
                    return FacingDirection.Left;
                case FacingDirection.Up:
                    return FacingDirection.Down;
                case FacingDirection.Down:
                    return FacingDirection.Up;
                default:
                    // Should never happen
                    return FacingDirection.Up;
            }
        }
    }
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

            roomManager = RoomManager.Instance;
            roomManager.Init(link);
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

            GameStateManager.Instance.Init(link);
        }

        protected override void Update(GameTime gameTime)
        {
            kc.Update();
            if (!link.IsAlive)
                this.Quit();

            //Just for Sprint 3
            mc.Update();

            GameStateManager.Instance.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            GameStateManager.Instance.Draw(_spriteBatch, gameTime);
            
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
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room25", FacingDirection.Right);
                    roomManager.SwitchToRoom("Room25");
                    break;
                case 1:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room15", FacingDirection.Right);
                    roomManager.SwitchToRoom("Room15");
                    break;
                case 2:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room35", FacingDirection.Right);
                    roomManager.SwitchToRoom("Room35");
                    break;
                case 3:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room24", FacingDirection.Right);
                    roomManager.SwitchToRoom("Room24");
                    break;
                case 4:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room23", FacingDirection.Right);
                    roomManager.SwitchToRoom("Room23");
                    break;
                case 5:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room33", FacingDirection.Right);
                    roomManager.SwitchToRoom("Room33");
                    break;
                case 6:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room13", FacingDirection.Up);
                    roomManager.SwitchToRoom("Room13");
                    break;
                case 7:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room12", FacingDirection.Down);
                    roomManager.SwitchToRoom("Room12");
                    break;
                case 8:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room02", FacingDirection.Left);
                    roomManager.SwitchToRoom("Room02");
                    break;
                case 9:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room22", FacingDirection.Right);
                    roomManager.SwitchToRoom("Room22");
                    break;
                case 10:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room21", FacingDirection.Up);
                    roomManager.SwitchToRoom("Room21");
                    break;
                case 11:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room20", FacingDirection.Down);
                    roomManager.SwitchToRoom("Room20");
                    break;
                case 12:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room10", FacingDirection.Left);
                    roomManager.SwitchToRoom("Room10");
                    break;
                case 13:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room00", FacingDirection.Right);
                    roomManager.SwitchToRoom("Room00");
                    break;
                case 14:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room32", FacingDirection.Up);
                    roomManager.SwitchToRoom("Room32");
                    break;
                case 15:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room42", FacingDirection.Down);
                    roomManager.SwitchToRoom("Room42");
                    break;
                case 16:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room25", FacingDirection.Left);
                    roomManager.SwitchToRoom("Room41");
                    break;
                case 17:
                    GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), "Room25", FacingDirection.Right);
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
