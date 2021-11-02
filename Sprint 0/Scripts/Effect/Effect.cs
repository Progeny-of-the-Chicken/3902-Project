using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Effect
{
    public class Effect : IEffect
    {
        private ISprite sprite;
        private Vector2 location;
        private double durationSeconds;
        private bool delete = false;

        public Effect(Vector2 location, EffectType type)
        {
            sprite = EffectSpriteFactory.Instance.CreatePopEffectSprite();
            this.location = location;
            durationSeconds = GetDuration(type);
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

        private double GetDuration(EffectType type)
        {
            double duration;
            switch (type)
            {
                case EffectType.Pop:
                    duration = ObjectConstants.popDurationSeconds;
                    break;
                case EffectType.Explosion:
                    duration = ObjectConstants.explosionDurationSeconds;
                    break;
                case EffectType.EnemySpawn:
                    duration = ObjectConstants.enemySpawnDurationSeconds;
                    break;
                default:
                    duration = ObjectConstants.popDurationSeconds;
                    break;
            }
            return duration;
        }
    }
}
