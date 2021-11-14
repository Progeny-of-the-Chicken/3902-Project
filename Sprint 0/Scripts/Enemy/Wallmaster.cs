using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Scripts.Sprite;
using Sprint_0.Scripts.Collider.Enemy;
using Sprint_0.Scripts.Terrain;

namespace Sprint_0.Scripts.Enemy
{
    class Wallmaster : IEnemy
    {

        ISprite sprite;
        ISprite openSprite;
        ISprite closeSprite;
        IEnemyCollider collider;
        public IEnemyCollider Collider { get => collider; }

        static RNGCryptoServiceProvider randomDir = new RNGCryptoServiceProvider();
        byte[] random;
        public int Damage { get => _damage; }
        int _damage;
        int health = ObjectConstants.WallMasterHealth;
        const int knockbackDistance = 50; //TODO: this magic number appears more than once and needs to be standardized
        bool delete = false;
        bool grab = false;
        bool inKnockBack = false;

        float moveSpeed;
        float timeSinceMove = ObjectConstants.counterInitialVal_float;
        float timeSinceKnockback = ObjectConstants.counterInitialVal_float;

        Vector2 location;
        Vector2 direction;
        Vector2 knockbackDirection;

        Link grabbedLink;
        public Wallmaster(Vector2 location)
        {
            this.location = location;
            moveSpeed = ObjectConstants.WallMasterMoveSpeed;
            direction = ObjectConstants.LeftUnitVector;
            random = new byte[ObjectConstants.numberOfBytesForRandomDirection];
            openSprite = (WallmasterOpenSprite)EnemySpriteFactory.Instance.CreateWallmasterOpenSprite(SpriteRectangles.wallMasterOpenFrame);
            closeSprite = (WallmasterCloseSprite)EnemySpriteFactory.Instance.CreateWallmasterCloseSprite(SpriteRectangles.wallMasterCloseFrame);
            sprite = openSprite;
            collider = new GenericEnemyCollider(this, new Rectangle((int)location.X, (int)location.Y, (SpriteRectangles.wallMasterOpenFrame.Width * ObjectConstants.scale), (SpriteRectangles.wallMasterOpenFrame.Height * ObjectConstants.scale)));
        }

        public void Update(GameTime gt)
        {
            if (grab == false)
            {
                SearchMove(gt);
                sprite.Update(gt);
                collider.Update(location);
            }
            else
            {
                yeetLink();
                sprite.Update(gt);
            }
        }

        void SearchMove(GameTime gt)
        {
            timeSinceMove += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timeSinceMove >= ObjectConstants.WallMasterTimeToMoveAgain)
            {
                SetRandomDirection();
                timeSinceMove = ObjectConstants.counterInitialVal_float;
            }
            location += direction * moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
        }

        //TODO: more appropriate name, this one is funny tho
        void yeetLink()
        {
            if (location.X > ObjectConstants.xOnScreenBorder)
            {
                --location.X;
                grabbedLink.ResetPosition(location);
            }
            else
            {
                //TODO:reset link to his starting position
                RoomManager.Instance.SwitchToRoom(ObjectConstants.wallMasterToRoom);
                grabbedLink.UnSuspend();
            }
        }

        void SetRandomDirection()
        {
            //First byte is vertical/horizontal, second is +/-
            randomDir.GetBytes(random);
            if (random[ObjectConstants.firstInArray] % ObjectConstants.oneInTwo == ObjectConstants.zero_int)
                direction = Vector2.UnitX;
            else
                direction = Vector2.UnitY;
            if (random[ObjectConstants.secondInArray] % ObjectConstants.oneInTwo == ObjectConstants.zero_int)
                direction *= ObjectConstants.vectorFlip;
        }

        public void GrabLink(Link player)
        {
            //todo 
            //change to closed hand, move link
            sprite = closeSprite;
            grab = true;
            grabbedLink = player;
            //change to first dungeon room
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= ObjectConstants.zero)
            {
                ObjectsFromObjectsFactory.Instance.CreateEffect(location, Effect.EffectType.Pop);
                delete = true;
                SFXManager.Instance.PlayEnemyDeath();
            }
            SFXManager.Instance.PlayEnemyHit();
        }
        public void SuddenKnockBack(Vector2 knockback)
        {
            location += knockback * knockbackDistance;
        }
        public void GradualKnockBack(Vector2 knockback)
        {
            //TODO: add gradual knockback to wallmaster
        }
        public bool CheckDelete()
        {
            return delete;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, location);
        }

    }
}