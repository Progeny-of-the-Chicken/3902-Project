using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Terrain
{
    public class RoomManager : IRoomManager
    {
        private IRoom activeRoom;
        private ILink link;
        public RoomManager(ILink link)
        {
            this.link = link;
            activeRoom = new Room("Room02", this.link);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            activeRoom.Draw(spriteBatch);
        }

        public void SwitchToRoom(string roomID)
        {
            activeRoom.LoadRoom();
        }

        public void Update(GameTime gt)
        {
            activeRoom.Update(gt);
        }

        public IRoom CurrentRoom
        {
            get
            {
                return activeRoom;
            }
        }
    }
}