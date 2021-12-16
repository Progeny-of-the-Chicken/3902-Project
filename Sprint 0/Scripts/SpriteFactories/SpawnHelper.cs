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

        public Vector2 CenterLocationOnLinkForTriforce(Vector2 spawnerLocation, Vector2 spawnerDimensions, Vector2 spawneeDimensions)
        {
            Vector2 pos = GetCenterOfDimensions(spawnerDimensions);
            pos.Y -= spawnerDimensions.Y / ObjectConstants.oneInTwo + spawneeDimensions.Y / ObjectConstants.oneInTwo;
            return spawnerLocation + GetOffsetFromCenter(pos, spawneeDimensions);
        }

        public Vector2 CenterLocationOnLinkSword(Vector2 spawnerLocation, FacingDirection direction, Vector2 spawnerDimensions, Vector2 spawneeDimensions)
        {
            return spawnerLocation + GetSwordFromCenter(GetCenterOfDimensions(spawnerDimensions), spawneeDimensions, direction);
        }

        public Vector2 CenterLocationForShotgunBlast(Vector2 spawnerLocation, FacingDirection linksDirection)
        {
            return spawnerLocation + GetLinkFacingCenterForPellets(new Vector2(ObjectConstants.linkWidthHeight, ObjectConstants.linkWidthHeight), linksDirection);
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

        private Vector2 GetSwordFromCenter(Vector2 center, Vector2 spawneeDimensions, FacingDirection direction)
        {
            return (direction) switch
            {
                FacingDirection.Right => center + (new Vector2(ObjectConstants.linkSwordFromRightCenter + (spawneeDimensions.X / ObjectConstants.oneInTwo), 0)
                    * (ObjectConstants.RightUnitVector + ObjectConstants.UpUnitVector)),
                FacingDirection.Up => center + (new Vector2(0, ObjectConstants.linkSwordFromUpCenter + (spawneeDimensions.X / ObjectConstants.oneInTwo))
                    * (ObjectConstants.UpUnitVector + ObjectConstants.LeftUnitVector)),
                FacingDirection.Left => center + (new Vector2(ObjectConstants.linkSwordFromLeftCenter + (spawneeDimensions.X / ObjectConstants.oneInTwo), 0)
                    * (ObjectConstants.LeftUnitVector + ObjectConstants.DownUnitVector)),
                FacingDirection.Down => center + (new Vector2(0, ObjectConstants.linkSwordFromDownCenter + (spawneeDimensions.X / ObjectConstants.oneInTwo))
                    * (ObjectConstants.DownUnitVector + ObjectConstants.RightUnitVector)),
                // Should never happen
                _ => center
            };
        }

        private Vector2 GetLinkFacingCenterForPellets(Vector2 spawneeDimensions, FacingDirection direction)
        {
            return (direction) switch
            {
                FacingDirection.Right => (new Vector2(spawneeDimensions.X, spawneeDimensions.Y * (float)ObjectConstants.halfAdjustment)),
                FacingDirection.Up => (new Vector2(spawneeDimensions.X * (float)ObjectConstants.halfAdjustment, 0)),
                FacingDirection.Left => (new Vector2(0, spawneeDimensions.Y * (float)ObjectConstants.halfAdjustment)),
                FacingDirection.Down => (new Vector2(spawneeDimensions.X * (float)ObjectConstants.halfAdjustment, spawneeDimensions.Y)),
                // Should never happen
                _ => new Vector2(0, 0)
            };
        }
    }
}
