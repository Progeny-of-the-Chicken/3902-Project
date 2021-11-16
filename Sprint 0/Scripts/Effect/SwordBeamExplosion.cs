using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;

namespace Sprint_0.Scripts.Effect
{
    public class SwordBeamExplosion : IEffect
    {
        private ISprite sprite;
        private Vector2 location;
        private Vector2 direction;
        private double speed = ObjectConstants.swordBeamExplosionSpeed;
        private double durationSeconds = ObjectConstants.swordBeamExplosionDurationSeconds;
        private bool delete = false;

        public SwordBeamExplosion(Vector2 location, Vector2 direction)
        {
            this.location = location;
            this.direction = direction;
            sprite = EffectSpriteFactory.Instance.CreateSwordBeamExplosionSprite(GetSpriteEffectsForVector());
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            location += direction * (float)(gameTime.ElapsedGameTime.TotalSeconds * speed);
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

        //----- Helper method for handling sprite flips -----//

        private SpriteEffects GetSpriteEffectsForVector()
        {
            // Base sprite is Vector(-1, -1)
            SpriteEffects flipValue = SpriteEffects.None;
            if (direction.X > 0)
            {
                flipValue |= SpriteEffects.FlipHorizontally;
            }
            if (direction.Y > 0)
            {
                flipValue |= SpriteEffects.FlipVertically;
            }
            return flipValue;
        }
    }
}
