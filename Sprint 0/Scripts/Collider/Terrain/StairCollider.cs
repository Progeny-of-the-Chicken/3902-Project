using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Collider.Terrain
{
    public class StairCollider : IBlockCollider
    {
        private ITerrain owner;
        private Rectangle hitbox;

        public StairCollider(ITerrain owner, Rectangle hitbox)
        {
            this.owner = owner;
            this.hitbox = hitbox;
        }

        public ITerrain Owner { get => owner; }

        public Rectangle Hitbox { get => hitbox; }

        public void OnEnemyCollision(IEnemy enemy)
        {
            //Keese can go over blocks
            if (!(enemy is Keese))
            {
                Vector2 adjustmentForEnemy = Overlap.DirectionToMoveObjectOff(this.hitbox, enemy.Collider.Hitbox);
                enemy.SuddenKnockBack(adjustmentForEnemy);
            }
        }

        public void OnLinkCollision(Link link)
        {
            link.StopMoving();
            RoomManager.Instance.SwitchToRoom("room00");

        }

        public void OnProjectileCollision(IProjectile projectile)
        {
            //TODO: I don't think there are but maybe there should be interactions with specific projectiles
        }

        public void Update(Vector2 location)
        {
            //Stairs do not move
        }
    }
}
