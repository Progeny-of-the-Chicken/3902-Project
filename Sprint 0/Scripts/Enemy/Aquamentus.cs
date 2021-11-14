using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Projectiles;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    public class Aquamentus : IEnemy
    {
        ISprite sprite;
        ISprite moveSprite;
        ISprite shootSprite;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        public int Damage { get => ObjectConstants.AquamentusDamage; }
        private int health = ObjectConstants.AquamentusStartingHealth;
        bool delete = false;

        List<IProjectile> projectiles;

        Vector2 location;
        Vector2 direction = ObjectConstants.LeftUnitVector;
        Vector2 startLocation;

        float timeSinceFire = ObjectConstants.counterInitialVal_float;

        public Aquamentus(Vector2 location)
        {
            this.location = location;
            startLocation = location;

            moveSprite = EnemySpriteFactory.Instance.CreateAquamentusMoveSprite(SpriteRectangles.aquamentusMoveFrames);
            shootSprite = EnemySpriteFactory.Instance.CreateAquamentusShootSprite(SpriteRectangles.aquamentusShootFrames);
            sprite = moveSprite;
            projectiles = new List<IProjectile>();

            Rectangle collision = new Rectangle(location.ToPoint(), (SpriteRectangles.aquamentusMoveFrames[ObjectConstants.firstFrame].Size.ToVector2() * ObjectConstants.scale).ToPoint());
            collider = new GenericEnemyCollider(this, collision);

            ObjectsFromObjectsFactory.Instance.CreateEffect(location, Effect.EffectType.Explosion);
            SFXManager.Instance.PlayBossScream1();
        }
        public void Update(GameTime t)
        {
            Move(t);
            sprite.Update(t);

            timeSinceFire += (float)t.ElapsedGameTime.TotalSeconds;
            if (timeSinceFire >= ObjectConstants.AquamentusReloadTime)
            {
                ShootProjectile();
            }
            if (timeSinceFire >= ObjectConstants.AquamentusShootSpriteTime)
            {
                sprite = moveSprite;
            }
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Update(t);
            }
        }

        public void Move(GameTime t)
        {
            if (location.X < startLocation.X - ObjectConstants.AquamentusMoveDistance || location.X > startLocation.X)
            {
                direction *= ObjectConstants.vectorFlip;
            }
            location += ObjectConstants.AquamentusMoveSpeed * direction * (float)t.ElapsedGameTime.TotalSeconds;
            collider.Update(location);
        }

        void ShootProjectile()
        {
            timeSinceFire = ObjectConstants.counterInitialVal_float;
            projectiles = ObjectsFromObjectsFactory.Instance.CreateThreeMagicProjectilesFromEnemy(location - ObjectConstants.LeftUnitVector * ObjectConstants.scaledStdWidthHeight, FacingDirection.Left);
            sprite = shootSprite;
            SFXManager.Instance.PlayBossScream1();
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= ObjectConstants.zero)
            {
                ObjectsFromObjectsFactory.Instance.CreateEffect(location, Effect.EffectType.Pop);
                delete = true;
                SFXManager.Instance.PlayBossScream1();
            }
            SFXManager.Instance.PlayBossHit();
        }
        public void SuddenKnockBack(Vector2 knockback)
        {
            location += knockback;
        }
        public void GradualKnockBack(Vector2 knockback)
        {
            //Aquamentus doesn't get knocked back when hit
        }
        public bool CheckDelete()
        {
            return delete;
        }
        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Draw(sb);
            }
        }
    }
}
