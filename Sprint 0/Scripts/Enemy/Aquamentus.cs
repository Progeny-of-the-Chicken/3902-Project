using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Items;
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
        public IEnemyCollider Collider{ get => collider; }

        Rectangle[] moveFrames = { new Rectangle(51, 11, 24, 31), new Rectangle(76, 11, 24, 31) };
        Rectangle[] shootFrames = { new Rectangle(1, 11, 24, 31), new Rectangle(26, 11, 24, 31) };

        public int Damage { get => ObjectConstants.AquamentusDamage; }
        private int health = ObjectConstants.AquamentusStartingHealth;
        bool delete = false;

        List<IProjectile> projectiles;
        
        Vector2 location;
        Vector2 direction = -Vector2.UnitX;
        Vector2 startLocation;

        float timeSinceFire = 0;

        public Aquamentus(Vector2 location)
        {
            this.location = location;
            startLocation = location;

            moveSprite = EnemySpriteFactory.Instance.CreateAquamentusMoveSprite(moveFrames);
            shootSprite = EnemySpriteFactory.Instance.CreateAquamentusShootSprite(shootFrames);
            sprite = moveSprite;
            projectiles = ProjectileFactory.Instance.CreateThreeMagicProjectiles(location, FacingDirection.Left);

            Rectangle collision = new Rectangle(location.ToPoint(), (moveFrames[0].Size.ToVector2() * ObjectConstants.scale).ToPoint());
            collider = new GenericEnemyCollider(this, collision);
        }
        public void Update(GameTime t)
        {
            Move(t);
            sprite.Update(t);

            timeSinceFire += (float)t.ElapsedGameTime.TotalSeconds;
            if (projectiles.ToArray()[0].CheckDelete())
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
                direction *= -1;
            }
            location += ObjectConstants.AquamentusMoveSpeed * direction * (float)t.ElapsedGameTime.TotalSeconds;
            collider.Update(location);
        }

        void ShootProjectile()
        {
            timeSinceFire = 0;
            projectiles = ObjectsFromObjectsFactory.Instance.CreateThreeMagicProjectilesFromEnemy(location, FacingDirection.Left);
            sprite = shootSprite;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            delete = (health <= 0);
            SFXManager.Instance.PlayBossHit();
        }
        public void KnockBack(Vector2 knockback)
        {
            location += knockback;
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
