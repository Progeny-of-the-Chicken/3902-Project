using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Effect;

namespace Sprint_0.Scripts.Sets
{
    public class EffectSet
    {
        private HashSet<IEffect> effects;

        public HashSet<IEffect> GetEffectSet { get => effects; }

        public EffectSet()
        {
            effects = new HashSet<IEffect>();
        }

        public void Update(GameTime gameTime)
        {
            HashSet<IEffect> effectsToRemove = new HashSet<IEffect>();
            foreach (IEffect effect in effects)
            {
                effect.Update(gameTime);
                if (effect.CheckDelete())
                {
                    effectsToRemove.Add(effect);
                }
            }
            foreach (IEffect effect in effectsToRemove)
            {
                effects.Remove(effect);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IEffect effect in effects)
            {
                effect.Draw(spriteBatch);
            }
        }

        public void Add(IEffect effect)
        {
            effects.Add(effect);
        }
    }
}
