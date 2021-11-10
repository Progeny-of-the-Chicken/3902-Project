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

        public static RoomManager instance = new RoomManager();

        public static RoomManager Instance
        {
            get
            {
                return instance;
            }
        }
        public RoomManager()
        { 
            dormentRooms = new Dictionary<string, IRoom>();
        }
        public void Init(ILink player)
        {
            this.link = player;
            activeRoom = new Room("Room20", this.link);
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