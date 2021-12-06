using System;
using Sprint_0.GameStateHandlers;

namespace Sprint_0.Scripts.Terrain.LevelData
{
    public class CutSceneConstructor
    {
        GameplayStateHandler gsh;
        string room;

        private static CutSceneConstructor instance = new CutSceneConstructor();
        public static CutSceneConstructor Instance
        {
            get
            {
                return instance;
            }
        }

        public CutSceneConstructor(){}

        public void Init(GameplayStateHandler gsh)
        {
            this.gsh = gsh;
        }

        public void LoadDialogueForRoom(string roomID)
        {
            System.Diagnostics.Debug.WriteLine("Room ID Cutscene: " + roomID);

            if (CutSceneData.dialogueKeys.ContainsKey(roomID))
            {
                string[] data = CutSceneData.dialogueKeys[roomID];
                gsh.AddDialogue(data);
            }
        }
    }
}
