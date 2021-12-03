using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Terrain
{
    
    class DoorRandomizer
    {
        const int numConnections = 50;
        int numKeys = 0;
        string[, ,] doorStrings = new String[8, 8, 8];
        bool[,,] doorAvailability = new bool[8, 8, 4];
        private static DoorRandomizer instance = new DoorRandomizer();

        public static DoorRandomizer Instance
        {
            get
            {
                return instance;
            }
        }

        private DoorRandomizer()
        {
            randomizeDoors();
        }

        private void randomizeDoors()
        {
            //Bosses always lead to treasure rooms
            doorStrings[0, 7, 0] = "EastClosedSprite";
            doorStrings[0, 7, 1] = "Room17";
            doorAvailability[0, 7, 0] = false;
            doorStrings[0, 7, 4] = "WestDoorSprite";
            doorStrings[0, 7, 5] = "Room07";
            doorAvailability[1, 7, 2] = false;
            doorStrings[2, 7, 0] = "EastClosedSprite";
            doorStrings[2, 7, 1] = "Room37";
            doorAvailability[2, 7, 0] = false;
            doorStrings[3, 7, 4] = "WestDoorSprite";
            doorStrings[3, 7, 5] = "Room27";
            doorAvailability[3, 7, 2] = false;

            //To keep track of what rooms need to be added
            List<Vector2> inDungeon = new List<Vector2>();
            List<Vector2> notInDungeon = new List<Vector2>();
            inDungeon.Add(new Vector2(4, 7));

            //Initialize notInDungeon
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    notInDungeon.Add(new Vector2(i, j));

                }
            }

            //Remove special rooms
            notInDungeon.Remove(new Vector2(0, 0));
            notInDungeon.Remove(new Vector2(1, 7));
            notInDungeon.Remove(new Vector2(3, 7));
            notInDungeon.Remove(new Vector2(4, 7));

            //Initialize DoorAvailability
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        doorAvailability[i, j, k] = true;
                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        doorStrings[i, j, k] = "";
                    }
                }
            }

            var rand = new Random();

            for (int j = 0; j < numConnections; j++)
            {
                System.Diagnostics.Debug.WriteLine(j);
                //Find room to add door to
                int randInt = rand.Next(inDungeon.Count);
                Vector2 roomToAddToPos = inDungeon[randInt];

                //Make sure there is an available slot to place the door
                bool roomIsAvailable = false;
                for (int i = 0; i < 4; i++)
                {
                    roomIsAvailable |= doorAvailability[(int) roomToAddToPos.X, (int) roomToAddToPos.Y, i];
                }
                if (!roomIsAvailable)
                {
                    //All doors in this room have been taken, reduce counter and skip to next attempt
                    j--;
                    continue;
                }

                //Pick next room
                randInt = rand.Next(notInDungeon.Count);
                if (randInt < inDungeon.Count)
                {
                    //Connecting to room that already has a door

                } else
                {
                    //Connecting to new room
                    randInt -= inDungeon.Count;
                    Vector2 roomConnectingPos = notInDungeon[randInt];
                    notInDungeon.RemoveAt(randInt);

                    //Pick doors to add to
                    randInt = rand.Next(4);
                    while (!doorAvailability[(int)roomToAddToPos.X, (int)roomToAddToPos.Y, randInt])
                    {
                        randInt = (randInt + 1) % 4;
                    }
                    int randInt2 = (randInt + 2) % 4;
                    addConnectingDoors(roomToAddToPos, randInt, roomConnectingPos, randInt2);
                    inDungeon.Add(roomConnectingPos);
                }

            }

        }

        //This assumes adding this door to this room is valid
        public void addConnectingDoors(Vector2 roomLocation1, int doorLocation1, Vector2 roomLocation2, int doorLocation2)
        {
            doorAvailability[(int)roomLocation1.X, (int)roomLocation1.Y, doorLocation1] = false;
            doorAvailability[(int)roomLocation2.X, (int)roomLocation2.Y, doorLocation2] = false;
            switch (doorLocation1) {
                case 0:
                    doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, 0] = "EastDoorSprite";
                    doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, 1] = "Room" + roomLocation2.X + roomLocation2.Y;
                    break;
                case 1:
                    doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, 2] = "NorthDoorSprite";
                    doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, 3] = "Room" + roomLocation2.X + roomLocation2.Y;
                    break;
                case 2:
                    doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, 4] = "WestDoorSprite";
                    doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, 5] = "Room" + roomLocation2.X + roomLocation2.Y;
                    break;
                case 3:
                    doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, 6] = "SouthDoorSprite";
                    doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, 7] = "Room" + roomLocation2.X + roomLocation2.Y;
                    break;
            }
            switch (doorLocation2)
            {
                case 0:
                    doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, 0] = "EastDoorSprite";
                    doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, 1] = "Room" + roomLocation1.X + roomLocation1.Y;
                    break;
                case 1:
                    doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, 2] = "NorthDoorSprite";
                    doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, 3] = "Room" + roomLocation1.X + roomLocation1.Y;
                    break;
                case 2:
                    doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, 4] = "WestDoorSprite";
                    doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, 5] = "Room" + roomLocation1.X + roomLocation1.Y;
                    break;
                case 3:
                    doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, 6] = "SouthDoorSprite";
                    doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, 7] = "Room" + roomLocation1.X + roomLocation1.Y;
                    break;
            }
            System.Diagnostics.Debug.WriteLine(roomLocation1);
            System.Diagnostics.Debug.WriteLine(doorStrings[(int)roomLocation1.X, (int)roomLocation1.Y, 2 * doorLocation1]);
            System.Diagnostics.Debug.WriteLine(roomLocation2);
            System.Diagnostics.Debug.WriteLine(doorStrings[(int)roomLocation2.X, (int)roomLocation2.Y, 2 * doorLocation2]);
        }

        public string[] getDoorsForRoom(Vector2 roomLocation)
        {
            string[] returnArray = new string[8];
            for (int i = 0; i < 8; i++)
            {
                returnArray[i] = doorStrings[(int)roomLocation.X, (int)roomLocation.Y, i];
            }
            return returnArray;
        }
    }
}
