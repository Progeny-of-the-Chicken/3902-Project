using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Sprint_0.Scripts.Effect
{
    public class EffectFactory
    {
        private static EffectFactory instance = new EffectFactory();

        public static EffectFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EffectFactory()
        {
        }

        public IEffect CreateStaticEffect(Vector2 location, EffectType type)
        {
            return new StaticEffect(location, type);
        }

        public IEffect CreateShotgunPelletImpactEffect(Vector2 location, EffectType type, FacingDirection direction)
        {
            return new StaticEffect(location, type, direction);
        }

        public List<IEffect> CreateSwordBeamExplosion(Vector2 location)
        {
            List<IEffect> effects = new List<IEffect>
            {
                new SwordBeamExplosion(location, ObjectConstants.RightUnitVector + ObjectConstants.UpUnitVector),
                new SwordBeamExplosion(location, ObjectConstants.UpUnitVector + ObjectConstants.LeftUnitVector),
                new SwordBeamExplosion(location, ObjectConstants.LeftUnitVector + ObjectConstants.DownUnitVector),
                new SwordBeamExplosion(location, ObjectConstants.DownUnitVector + ObjectConstants.RightUnitVector)
            };
            return effects;
        }
    }
}
