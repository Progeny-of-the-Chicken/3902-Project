﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Scripts.Collider;


namespace Sprint_0.Scripts.Enemy
{
    public interface IEnemy
    {
        public int Damage { get; }
        public IEnemyCollider Collider { get; }
        public void Update(GameTime t);

        void Draw(SpriteBatch sb);

        public void TakeDamage(int damage, Vector2 knockback);
    }
}
