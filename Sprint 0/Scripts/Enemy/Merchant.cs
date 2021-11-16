﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;


namespace Sprint_0.Scripts.Enemy
{
    public class Merchant : IEnemy
    {
        private ISprite sprite;
        private Vector2 location;
        public Vector2 Position { get => location; }

        public int Damage { get => damage; }
        public IEnemyCollider Collider { get => collider; }
        IEnemyCollider collider;
        const int damage = ObjectConstants.OldManDamage;
        bool delete = false;

        public Merchant(Vector2 location)
        {
            this.location = location;
            sprite = EnemySpriteFactory.Instance.CreateMerchantSprite();
            collider = new NPCCollider(this, new Rectangle(location.ToPoint(), (SpriteRectangles.merchantFrame.Size.ToVector2() * ObjectConstants.scale).ToPoint()));
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
        public bool CheckDelete()
        {
            return delete;
        }
    }
}