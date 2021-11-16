using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.SpriteFactories
{
    public class SpawnHelper
    {
        private static SpawnHelper instance = new SpawnHelper();

        public static SpawnHelper Instance
        {
            get
            {
                return instance;
            }
        }

        private SpawnHelper()
        {
        }

        public Vector2 CenterLocationOnSpawner(Vector2 spawnerLocation, Vector2 spawnerDimensions, Vector2 spawneeDimensions)
        {
            return spawnerLocation + GetOffsetFromCenter(GetCenterOfDimensions(spawnerDimensions), spawneeDimensions);
        }

        //----- Helper methods for finding centers -----//

        private Vector2 GetCenterOfDimensions(Vector2 dimensions)
        {
            return dimensions / ObjectConstants.oneInTwo;
        }

        private Vector2 GetOffsetFromCenter(Vector2 center, Vector2 dimensions)
        {
            return center - (dimensions / ObjectConstants.oneInTwo);
        }
    }
}
