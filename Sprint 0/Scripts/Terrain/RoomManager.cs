﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0.Scripts.Terrain
{
    public class RoomManager : IRoomManager
    {
        private IRoom activeRoom;
        private Dictionary<string, IRoom> dormentRooms;
        private ILink link;
        private bool isRandomized;

        private static RoomManager instance = new RoomManager();

        public static RoomManager Instance
        {
            get
            {
                return instance;
            }
        }

        private RoomManager()
        {
            dormentRooms = new Dictionary<string, IRoom>();
        }

        public void reset()
        {
            instance = new RoomManager();
            instance.Init(Link.Instance, isRandomized);
        }

        public void Init(ILink player, bool isRandomized)
        {
            this.link = player;
            this.isRandomized = isRandomized;
            if (isRandomized) activeRoom = new Room(ObjectConstants.dungeon2StartRoom, this.link, isRandomized);
            else activeRoom = new Room(ObjectConstants.dungeon1StartRoom, this.link, isRandomized);
            RoomTracker.Instance.Init(activeRoom.RoomId());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            activeRoom.Draw(spriteBatch);
        }

        public void SwitchToRoom(string roomID)
        {
            dormentRooms.Add(activeRoom.RoomId(), activeRoom);
            RoomTracker.Instance.RegisterRoom(activeRoom.RoomId(), roomID);
            if (dormentRooms.ContainsKey(roomID))
            {
                dormentRooms.Remove(roomID, out activeRoom);
            }
            else
            {
                activeRoom = new Room(roomID, link, isRandomized);
            }
        }

        public void Update(GameTime gt)
        {
            activeRoom.Update(gt);
        }

        public IRoom LoadRoom(string roomID)
        {
            if (dormentRooms.ContainsKey(roomID))
            {
                return dormentRooms[roomID];
            }
            else
            {
                //IRoom newRoom = new Room(roomID, link);
                //dormentRooms.Add(roomID, newRoom);
                return new Room(roomID, link, isRandomized);
            }
        }
        public IRoom LoadRoomToSwapDoor(string roomID)
        {
            if (dormentRooms.ContainsKey(roomID))
            {
                return dormentRooms[roomID];
            }
            else
            {
                IRoom newRoom = new Room(roomID, link, isRandomized);
                dormentRooms.Add(roomID, newRoom);
                return new Room(roomID, link, isRandomized);
            }
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