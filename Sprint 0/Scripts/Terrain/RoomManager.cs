using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Terrain
{
    public class RoomManager : IRoomManager
    {
        private IRoom activeRoom;
        private Dictionary<string, IRoom> dormentRooms;
        private ILink link;
        public RoomManager(ILink link)
        {
            this.link = link;
            activeRoom = new Room("Room42", this.link);
            dormentRooms = new Dictionary<string, IRoom>();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            activeRoom.Draw(spriteBatch);
        }

        public void SwitchToRoom(string roomID)
        {
            dormentRooms.Add(activeRoom.RoomId(), activeRoom);
            if(dormentRooms.ContainsKey(roomID))
            {
                dormentRooms.Remove(roomID, out activeRoom);
            }
            else
            {
                activeRoom = new Room(roomID, link);
            }
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