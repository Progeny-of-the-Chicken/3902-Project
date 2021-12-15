using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Effect
{
    public class StaticEffect : IEffect
    {
        private ISprite sprite;
        private Vector2 location;
        private double durationSeconds;
        private bool delete = false;

        public StaticEffect(Vector2 location, EffectType type)
        {
            this.location = location;
            InitializeByType(type, FacingDirection.Up);
        }

        public StaticEffect(Vector2 location, EffectType type, FacingDirection direction)
        {
            this.location = location;
            InitializeByType(type, direction);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            durationSeconds -= gameTime.ElapsedGameTime.TotalSeconds;
            if (durationSeconds <= 0.0)
            {
                delete = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

        public bool CheckDelete()
        {
            return delete;
        }

        //----- Helper to get effect duration -----//

        private void InitializeByType(EffectType type, FacingDirection direction)
        {
            switch (type)
            {
                case EffectType.Pop:
                    sprite = EffectSpriteFactory.Instance.CreatePopSprite();
                    durationSeconds = ObjectConstants.popDurationSeconds;
                    break;
                case EffectType.Explosion:
                    sprite = EffectSpriteFactory.Instance.CreateExplosionSprite();
                    durationSeconds = ObjectConstants.explosionDurationSeconds;
                    break;
                case EffectType.PelletImpact:
                    durationSeconds = ObjectConstants.pelletImpactDurationSeconds;
                    sprite = EffectSpriteFactory.Instance.CreatePelletImpactSprite(direction);
                    break;
                default:
                    break;
            }
        }
    }
}
