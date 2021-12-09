using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Enemy;
using Sprint_0.Scripts.Collider.Projectile;
using Sprint_0.Scripts.SpriteFactories;

namespace Sprint_0.Scripts.Projectiles.ProjectileClasses
{
    public class MagicProjectile : IProjectile
    {
        private ISprite sprite;
        private IProjectileCollider collider;
        private Vector2 directionVector;
        private Vector2 currentPos;
        private bool delete = false;
        private bool friendly;

        private double speedPerSecond = ObjectConstants.magicProjectileSpeed;
        private double startTimeSeconds = ObjectConstants.counterInitialVal_double;
        private double projectileLifetimeSeconds = ObjectConstants.magicProjectileLifetime;

        public bool Friendly { get => friendly; }

        public int Damage { get => ObjectConstants.magicProjectileDamage; }

        public IProjectileCollider Collider { get => collider; }

        public MagicProjectile(Vector2 spawnLoc, Vector2 directionVector)
        {
            currentPos = SpawnHelper.Instance.CenterLocationOnSpawner(spawnLoc, SpriteRectangles.aquamentusMoveFrames[ObjectConstants.firstFrame].Size.ToVector2(), ObjectConstants.magicProjectileWidthHeight);
            this.directionVector = directionVector;
            sprite = EnemySpriteFactory.Instance.CreateMagicProjectileSprite();
            collider = ProjectileColliderFactory.Instance.CreateMagicProjectileCollider(this);
            friendly = false;
        }

        public void Update(GameTime gt)
        {
            currentPos += directionVector * (float)(gt.ElapsedGameTime.TotalSeconds * speedPerSecond);
            startTimeSeconds += gt.ElapsedGameTime.TotalSeconds;
            if (startTimeSeconds > projectileLifetimeSeconds)
            {
                delete = true;
            }
            sprite.Update(gt);
            collider.Update(currentPos);
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
    }
}
