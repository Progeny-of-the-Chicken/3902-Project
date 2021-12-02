using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Sprint_0.Scripts.Terrain
{
    
    class DoorRandomizer
    {
        const int numConnections = 120;
        int numKeys = 0;
        string[, ,] doorStrings = new String[8, 8, 8];
        bool[,,] doorAvailability = new bool[8, 8, 4];
        

        public DoorRandomizer()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; i < 8; i++)
                {
                    for (int k = 0; i < 4; i++)
                    {
                        doorAvailability[i, j, k] = true;
                    }
                }
            }
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

            //Initialize our lists
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j != 7 || i != 4)
                    {
                        inDungeon.Add(new Vector2(i, j));
                    } else
                    {
                        notInDungeon.Add(new Vector2(i, j));
                    }
                }
            }

            var rand = new Random();

            for (int i = 0; i < numConnections; i++)
            {
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
                    i--;
                    continue;
                }

                //Pick next room
                randInt = rand.Next(inDungeon.Count);
            }


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
