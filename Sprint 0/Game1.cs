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
using Sprint_0.Scripts.GameState.InventoryState;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.GameState.MainMenuState;

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
        public IController kc;

        MouseController mc;
        public int roomNum = ObjectConstants.counterInitialVal_int;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = ObjectConstants.contentLocation;
            IsMouseVisible = true;

            kc = new MainMenuStateController(this);

            //Just for Sprint 3
            mc = new MouseController(this);

        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = ObjectConstants.PreferredBackBufferWidth * ObjectConstants.scale;
            _graphics.PreferredBackBufferHeight = ObjectConstants.PreferredBackBufferHeight * ObjectConstants.scale;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            MainMenuSpriteFactory.Instance.LoadAllTextures(this.Content);
            LinkSpriteFactory.Instance.LoadAllTextures(this.Content);
            TerrainSpriteFactory.Instance.LoadAllTextures(this.Content);
            ItemSpriteFactory.Instance.LoadAllTextures(this.Content);
            ProjectileSpriteFactory.Instance.LoadAllTextures(this.Content);
            EnemySpriteFactory.Instance.LoadAllTextures(this.Content);
            EffectSpriteFactory.Instance.LoadAllTextures(this.Content);
            InventorySpriteFactory.Instance.LoadAllTextures(this.Content);
            FontSpriteFactory.Instance.LoadAllTextures(this.Content);
            SFXManager.Instance.LoadAllSounds(this.Content);
            GameStateSpriteFactory.Instance.LoadAllTextures(this.Content);

            base.LoadContent();
            GameStateManager.Instance.Init(Link.Instance, this);
        }

        protected override void Update(GameTime gameTime)
        {
            kc.Update();
            if (!Link.Instance.IsAlive)
                GameStateManager.Instance.GameOver();

            //Just for Sprint 3
            mc.Update();

            SFXManager.Instance.Update(gameTime);
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
			GameStateManager.Instance.SwapRooms(RoomManager.Instance.CurrentRoom.RoomId(), ObjectConstants.rooms[roomNum], FacingDirection.Up);
        }

        public void NextRoom()
        {
            roomNum++;
            if (roomNum + ObjectConstants.nextInArray > ObjectConstants.rooms.Length)
            {
                roomNum = ObjectConstants.counterInitialVal_int;
            }
            ChangeRoom();
        }

        public void PrevRoom()
        {
            roomNum--;
            if (roomNum < ObjectConstants.counterInitialVal_int)
            {
                roomNum = ObjectConstants.rooms.Length - 1;
            }
            ChangeRoom();
        }

    }

}
