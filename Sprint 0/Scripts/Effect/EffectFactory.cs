using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Effect
{
    public class EffectFactory
    {
        private IRoom room;

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

        public void LoadRoom(IRoom room)
        {
            this.room = room;
        }

    }
}
