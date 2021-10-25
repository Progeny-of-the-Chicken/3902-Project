using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;


namespace Sprint_0.Scripts.Enemy
{
    public class OldMan : IEnemy
    {
        private OldManSprite sprite;
        private Vector2 location;

        Rectangle frame = new Rectangle(1, 11, 16, 16);

        public int Damage { get => damage; }
        public IEnemyCollider Collider { get => collider; }
        IEnemyCollider collider;
        const int damage = 0;

        int health = 1;
        bool delete = false;

        public OldMan(Vector2 location, float scale)
        {
            this.location = location;
            sprite = (OldManSprite)EnemySpriteFactory.Instance.CreateOldManSprite(scale, frame);
            collider = new NPCCollider(this, new Rectangle(location.ToPoint(), (frame.Size.ToVector2() * scale).ToPoint()));
        }

        public void Update(GameTime gt)
        {
            sprite.Update(gt);
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }

        public void TakeDamage(int damage)
        {
            //May add way to have old man counter-attack if you hit him but for now this isn't planned to be called
            health -= damage;
            delete = (health <= 0);
        }
        public void KnockBack(Vector2 knockback)
        {
            location += knockback;
        }
        public bool CheckDelete()
        {
            return delete;
        }
    }
}
