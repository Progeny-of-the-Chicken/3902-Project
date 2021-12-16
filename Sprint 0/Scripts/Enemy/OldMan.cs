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
        private ISprite sprite;
        private Vector2 location;

        public int Damage { get => damage; }
        public Vector2 Position { get => location; }
        public bool CanBeAffectedByPlayer { get => true; }
        public IEnemyCollider Collider { get => collider; }
        IEnemyCollider collider;
        const int damage = ObjectConstants.OldManDamage;
        bool delete = false;

        public OldMan(Vector2 location)
        {
            this.location = location;
            sprite = EnemySpriteFactory.Instance.CreateOldManSprite();
            collider = new NPCCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.oldManFrame.Size.ToVector2() * ObjectConstants.scale).ToPoint()));
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
            //health -= damage;
            //delete = (health <= 0);
        }
        public void SuddenKnockBack(Vector2 knockback)
        {
            //Old man stands his ground
        }
        public void GradualKnockBack(Vector2 knockback)
        {
            //The old man does not budge under the force of your sword
        }
        public void Freeze(float duration)
        {
            //Old man does not get frozen
        }
        public void ChangeDirection()
        {
            //Old man does not have direction
        }
        public bool CheckDelete()
        {
            return delete;
        }
    }
}
