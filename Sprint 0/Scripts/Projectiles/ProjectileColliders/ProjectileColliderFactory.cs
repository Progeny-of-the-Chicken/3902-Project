namespace Sprint_0.Scripts.Projectiles.ProjectileColliders
{
    public class ProjectileColliderFactory
    {
        private static ProjectileColliderFactory instance = new ProjectileColliderFactory();

        public static ProjectileColliderFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ProjectileColliderFactory()
        {
        }
    }
}
