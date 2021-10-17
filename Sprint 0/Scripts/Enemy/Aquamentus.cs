using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Items;

namespace Sprint_0.Scripts.Enemy
{
    public class Aquamentus : IEnemy
    {
        ISprite sprite;
        ISprite moveSprite;
        ISprite shootSprite;
        IEnemyCollider collider;

        Rectangle[] moveFrames = { new Rectangle(51, 11, 24, 31), new Rectangle(76, 11, 24, 31) };
        Rectangle[] shootFrames = { new Rectangle(1, 11, 24, 31), new Rectangle(26, 11, 24, 31) };

        public int damage { get => _damage; }
        int _damage;
        int health = 1;
        const int knockbackDistance = 50;

        List<IItem> projectiles;
        
        Vector2 location;
        Vector2 direction = new Vector2(-1, 0);
        Vector2 startLocation;

        float speed;
        float moveDistance;

        float timeSinceFire = 0;
        float shootSpriteTime = 0.5f;

        public Aquamentus(Vector2 location, float scale)
        {
            this.location = location;
            startLocation = location;

            speed = 25 * scale;
            moveDistance = 20 * scale;

            moveSprite = EnemySpriteFactory.Instance.CreateAquamentusMoveSprite(scale, moveFrames);
            shootSprite = EnemySpriteFactory.Instance.CreateAquamentusShootSprite(scale, shootFrames);
            sprite = moveSprite;
            projectiles = ItemFactory.Instance.CreateThreeMagicProjectiles(location, FacingDirection.Left);

            Rectangle collision = new Rectangle(0, 0, (int)(moveFrames[0].Width * scale), (int)(moveFrames[0].Height * scale));
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
            if (timeSinceFire >= shootSpriteTime)
            {
                sprite = moveSprite;
            }
            foreach (IItem projectile in projectiles)
            {
                projectile.Update(t);
            }
        }

        public void Move(GameTime t)
        {
            if (location.X < startLocation.X - moveDistance || location.X > startLocation.X)
            {
                direction *= -1;
            }
            location += speed * direction * (float)t.ElapsedGameTime.TotalSeconds;
        }

        void ShootProjectile()
        {
            timeSinceFire = 0;
            projectiles = ItemFactory.Instance.CreateThreeMagicProjectiles(location, FacingDirection.Left);
            sprite = shootSprite;
        }

        public void TakeDamage(int damage, Vector2 knockback)
        {
            health -= damage;
            location += knockback * knockbackDistance;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
            foreach (IItem projectile in projectiles)
            {
                projectile.Draw(sb);
            }
        }
    }
}
