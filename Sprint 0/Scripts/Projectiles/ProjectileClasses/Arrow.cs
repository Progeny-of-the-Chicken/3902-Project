using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Projectile;
using Sprint_0.Scripts.Effect;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class Arrow : IProjectile
    {
        private ISprite sprite;
        private IProjectileCollider collider;
        private Vector2 directionVector;
        private Vector2 currentPos;
        private Vector2 startPos;
        private Vector2 popOffset;
        private bool delete = false;
        private bool friendly = false;

        private double speedPerSecond = ObjectConstants.arrowSpeedPerSecond;
        private int maxDistance = ObjectConstants.arrowMaxDistance;
        private double silverArrowSpeedCoef = ObjectConstants.silverArrowSpeedCoef;

        public bool Friendly { get => friendly; }

        public int Damage { get => ObjectConstants.arrowDamage; }

        public IProjectileCollider Collider { get => collider; }

        public Arrow(Vector2 spawnLoc, FacingDirection direction, bool silver)
        {
            startPos = currentPos = spawnLoc;
            if (silver)
            {
                maxDistance = (int) (maxDistance * silverArrowSpeedCoef);
            }
            SetSpriteVectors(direction, silver);

            collider = ProjectileColliderFactory.Instance.CreateArrowCollider(this, direction);
            friendly = true;
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
            collider.Update(currentPos);

            currentPos += directionVector * (float)(gt.ElapsedGameTime.TotalSeconds * speedPerSecond);
            // Delete based on distance
            if (Math.Abs(currentPos.X - startPos.X) > maxDistance || Math.Abs(currentPos.Y - startPos.Y) > maxDistance)
            {
                ObjectsFromObjectsFactory.Instance.CreatePopEffect(currentPos + popOffset, EffectType.Pop);
                delete = true;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, currentPos);
        }

        public bool CheckDelete()
        {
            return delete;
        }

        public void Despawn()
        {
            delete = true;
        }

        private void SetSpriteVectors(FacingDirection direction, bool silver)
        {
            switch (direction)
            {
                case FacingDirection.Right:
                    directionVector = new Vector2(1, 0);
                    popOffset = new Vector2(4, -8);
                    sprite = ProjectileSpriteFactory.Instance.CreateArrowSprite(FacingDirection.Right, silver);
                    break;
                case FacingDirection.Up:
                    directionVector = new Vector2(0, -1);
                    popOffset = new Vector2(-8, -20);
                    sprite = ProjectileSpriteFactory.Instance.CreateArrowSprite(FacingDirection.Up, silver);
                    break;
                case FacingDirection.Left:
                    directionVector = new Vector2(-1, 0);
                    popOffset = new Vector2(-20, -8);
                    sprite = ProjectileSpriteFactory.Instance.CreateArrowSprite(FacingDirection.Left, silver);
                    break;
                case FacingDirection.Down:
                    directionVector = new Vector2(0, 1);
                    popOffset = new Vector2(-8, 4);
                    sprite = ProjectileSpriteFactory.Instance.CreateArrowSprite(FacingDirection.Down, silver);
                    break;
                default:
                    break;
            }
        }
    }
}
