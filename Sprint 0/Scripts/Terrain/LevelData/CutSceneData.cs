using System.Collections.Generic;
using System.Collections;

namespace Sprint_0.Scripts.Terrain.LevelData
{
    public struct CutSceneData
    {
        private static string[] room25 = {
            "MANY YEARS AGO PRINCE DARKNESS GANNON STOLE ONE OF THE TRIFORCE WITH POWER",
            "PRINCESS ZELDA HAD ONE OF THE TRIFORCE WITH WISDOM",
            "SHE DIVIDED IT INTO ONE UNIT TO HIDE IT FROM GANNON BEFORE SHE WAS CAPTURED.",
            "GO FIND THE ONE UNITS LINK TO SAVE HER"
        };

        public static Dictionary<string, string[]> dialogueKeys = new Dictionary<string, string[]>()
        {
            { "Room25", room25 }
        };
    }
}
