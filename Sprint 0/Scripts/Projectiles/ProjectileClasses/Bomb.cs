using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Projectile;
using Sprint_0.Scripts.Effect;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class Bomb : IProjectile
    {
        private ISprite sprite;
        private IProjectileCollider collider;
        private Vector2 pos;
        private int displacement = ObjectConstants.bombDisplacement;
        private bool delete = false;
        private bool friendly = false;

        private double startTime = ObjectConstants.counterInitialVal_float;
        private double fuseDurationSeconds = ObjectConstants.bombFuseDurationSeconds;
        private double extraExplosionOffset = ObjectConstants.bombExtraExplosionOffset;
        private double extraExplosionNumber = ObjectConstants.bombExtraExplosionNumber;

        public bool Friendly { get => friendly; }

        public int Damage { get => 0; }

        public IProjectileCollider Collider { get => collider; }

        public Bomb(Vector2 spawnLoc, FacingDirection direction)
        {
            pos = spawnLoc;
            switch (direction)
            {
                case FacingDirection.Right:
                    pos.X += displacement;
                    break;
                case FacingDirection.Up:
                    pos.Y -= displacement;
                    break;
                case FacingDirection.Left:
                    pos.X -= displacement;
                    break;
                case FacingDirection.Down:
                    pos.Y += displacement;
                    break;
                default:
                    break;
            }
            sprite = ProjectileSpriteFactory.Instance.CreateBombSprite();

            collider = ProjectileColliderFactory.Instance.CreateBombCollider(this);
            friendly = true;
        }

        public void Update(GameTime gt)
        {
            // Animation control
            sprite.Update(gt);
            collider.Update(pos);

            startTime += gt.ElapsedGameTime.TotalSeconds;
            if (startTime > fuseDurationSeconds)
            {
                SpawnExplosions();
                ObjectsFromObjectsFactory.Instance.CreateBlastZoneFromBomb(pos);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, pos);
        }

        public bool CheckDelete()
        {
            return delete;
        }

        public void Despawn()
        {
            delete = true;
        }

        public void MoveOutOfWall(Vector2 adjustment)
        {
            pos += adjustment;
        }

        private void SpawnExplosions()
        {
            ObjectsFromObjectsFactory.Instance.CreateEffect(pos, EffectType.Explosion);
            for (double i = 0; i <= (2 * Math.PI); i += (2 * Math.PI / extraExplosionNumber))
            {
                Vector2 explosionSpawnOffset = new Vector2((float)(Math.Cos(i) * extraExplosionOffset), (float)(Math.Sin(i) * extraExplosionOffset));
                ObjectsFromObjectsFactory.Instance.CreateEffect(pos + explosionSpawnOffset, EffectType.Explosion);
            }
        }
    }
}
