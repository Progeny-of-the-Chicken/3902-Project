using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Sprint_0.Scripts
{
    class SFXManager
    {
        private static SFXManager instance = new SFXManager();
        public static SFXManager Instance
        {
            get => instance;
        }

        private SFXManager()
        {
        }
        SoundEffect bombExplosion;
        SoundEffect bombPlacement;
        SoundEffect bossHit;
        SoundEffect bossScream1;
        SoundEffect bossScream2;
        SoundEffect bossScream3;
        SoundEffect doorUnlocking;
        SoundEffect enemyDeath;
        SoundEffect enemyHit;
        SoundEffect fanfare;
        SoundEffect fireArrowBoomerang;
        SoundEffect fireCandle;
        SoundEffect fireMagicRod;
        SoundEffect keySpawn;
        SoundEffect linkDeath;
        SoundEffect linkHit;
        SoundEffect lowHealth;              //probably needs to be loopable
        SoundEffect music;                  //definitely needs to be loopable
        SoundEffect pickUpHeart;
        SoundEffect pickUpItem;
        SoundEffect pickupRupee;
        SoundEffect recorder;
        SoundEffect refillLoop;             //probably needs to be loopable
        SoundEffect secretFound;
        SoundEffect shieldDeflect;
        SoundEffect shore;                  //probably needs to be loopable
        SoundEffect stairs;
        SoundEffect swordCombined;
        SoundEffect swordShoot;
        SoundEffect swordSlash;
        SoundEffect textScroll;             //probably needs to be loopable
        SoundEffect textScrollSlow;         //probably needs to be loopable

        SoundEffectInstance lowHealthInstance;
        SoundEffectInstance musicInstance;
        SoundEffectInstance refillLoopInstance;
        SoundEffectInstance shoreInstance;
        SoundEffectInstance textScrollInstance;
        SoundEffectInstance textScrollSlowInstance;

        public void LoadAllSounds(ContentManager content)
        {
            bombExplosion = content.Load<SoundEffect>("Sounds/LOZ_Bomb_Blow");
            bombPlacement = content.Load<SoundEffect>("Sounds/LOZ_Bomb_Drop");
            bossHit = content.Load<SoundEffect>("Sounds/LOZ_Boss_Hit");
            bossScream1 = content.Load<SoundEffect>("Sounds/LOZ_Boss_Scream1");
            bossScream2 = content.Load<SoundEffect>("Sounds/LOZ_Boss_Scream2");
            bossScream3 = content.Load<SoundEffect>("Sounds/LOZ_Boss_Scream3");
            doorUnlocking = content.Load<SoundEffect>("Sounds/LOZ_Door_Unlock");
            enemyDeath = content.Load<SoundEffect>("Sounds/LOZ_Enemy_Die");
            enemyHit = content.Load<SoundEffect>("Sounds/LOZ_Enemy_Hit");
            fanfare = content.Load<SoundEffect>("Sounds/LOZ_Fanfare");
            fireArrowBoomerang = content.Load<SoundEffect>("Sounds/LOZ_Arrow_Boomerang");
            fireCandle = content.Load<SoundEffect>("Sounds/LOZ_Candle");
            fireMagicRod = content.Load<SoundEffect>("Sounds/LOZ_MagicalRod");
            keySpawn = content.Load<SoundEffect>("Sounds/LOZ_Key_Appear");
            linkDeath = content.Load<SoundEffect>("Sounds/LOZ_Link_Die");
            linkHit = content.Load<SoundEffect>("Sounds/LOZ_Link_Hurt");
            lowHealth = content.Load<SoundEffect>("Sounds/LOZ_LowHealth");
            music = content.Load<SoundEffect>("Sounds/Dungeon Theme");
            pickUpHeart = content.Load<SoundEffect>("Sounds/LOZ_Get_Heart");
            pickUpItem = content.Load<SoundEffect>("Sounds/LOZ_Get_Item");
            pickupRupee = content.Load<SoundEffect>("Sounds/LOZ_Get_Rupee");
            recorder = content.Load<SoundEffect>("Sounds/LOZ_Recorder");
            refillLoop = content.Load<SoundEffect>("Sounds/LOZ_Refill_Loop");
            secretFound = content.Load<SoundEffect>("Sounds/LOZ_Secret");
            shieldDeflect = content.Load<SoundEffect>("Sounds/LOZ_Shield");
            shore = content.Load<SoundEffect>("Sounds/LOZ_Shore");
            stairs = content.Load<SoundEffect>("Sounds/LOZ_Stairs");
            swordCombined = content.Load<SoundEffect>("Sounds/LOZ_Sword_Combined");
            swordShoot = content.Load<SoundEffect>("Sounds/LOZ_Sword_Shoot");
            swordSlash = content.Load<SoundEffect>("Sounds/LOZ_Sword_Slash");
            textScroll = content.Load<SoundEffect>("Sounds/LOZ_Text");
            textScrollSlow = content.Load<SoundEffect>("Sounds/LOZ_Text_Slow");

            lowHealthInstance = lowHealth.CreateInstance();
            musicInstance = music.CreateInstance();
            refillLoopInstance = refillLoop.CreateInstance();
            shoreInstance = shore.CreateInstance();
            textScrollInstance = textScroll.CreateInstance();
            textScrollSlowInstance = textScrollSlow.CreateInstance();

            lowHealthInstance.IsLooped = true;
            musicInstance.IsLooped = true;
            refillLoopInstance.IsLooped = true;
            shoreInstance.IsLooped = true;
            textScrollInstance.IsLooped = true;
            textScrollSlowInstance.IsLooped = true;
        }

        public void PlayBombExplosion()
        {
            bombExplosion.Play();
        }
        public void PlayBombPlacement()
        {
            bombPlacement.Play();
        }
        public void PlayBossHit()
        {
            bossHit.Play();
        }
        public void PlayBossScream1()
        {
            bossScream1.Play();
        }
        public void PlayBossScream2()
        {
            bossScream2.Play();
        }
        public void PlayBossScream3()
        {
            bossScream3.Play();
        }
        public void PlayDoorUnlocking()
        {
            doorUnlocking.Play();
        }
        public void PlayEnemyDeath()
        {
            enemyDeath.Play();
        }
        public void PlayEnemyHit()
        {
            enemyHit.Play();
        }
        public void PlayFanfare()
        {
            fanfare.Play();
        }
        public void PlayFireArrowBoomerang()
        {
            fireArrowBoomerang.Play();
        }
        public void PlayFireCandle()
        {
            fireCandle.Play();
        }
        public void PlayFireMagicRod()
        {
            fireMagicRod.Play();
        }
        public void PlayKeySpawn()
        {
            keySpawn.Play();
        }
        public void PlayLinkDeath()
        {
            linkDeath.Play();
        }
        public void PlayLinkHit()
        {
            linkHit.Play();
        }
        public void PlayPickUpHeart()
        {
            pickUpHeart.Play();
        }
        public void PlayPickUpItem()
        {
            pickUpItem.Play();
        }
        public void PlayPickUpRupee()
        {
            pickupRupee.Play();
        }
        public void PlayRecorder()
        {
            recorder.Play();
        }
        public void PlaySecretFound()
        {
            secretFound.Play();
        }
        public void PlayShieldDeflect()
        {
            shieldDeflect.Play();
        }
        public void PlayStairs()
        {
            stairs.Play();
        }
        public void PlaySwordCombined()
        {
            swordCombined.Play();
        }
        public void PlaySwordShoot() 
        { 
            swordShoot.Play(); 
        }
        public void PlaySwordSlash()
        {
            swordSlash.Play();
        }

        //Looping sounds
        public void PlayLowHealth()
        {
            lowHealthInstance.Play();
        }
        public void StopLowHealth()
        {
            lowHealthInstance.Stop();
        }
        public void PlayMusic()
        {
            musicInstance.Play();
        }
        public void StopMusic()
        {
            musicInstance.Stop();
        }
        public void PlayRefillLoop()
        {
            refillLoopInstance.Play();
        }
        public void StopRefillLoop()
        {
            refillLoopInstance.Stop();
        }
        public void PlayTextScroll()
        {
            textScrollInstance.Play();
        }
        public void PlayShore()
        {
            shoreInstance.Play();
        }
        public void StopShore()
        {
            shoreInstance.Stop();
        }
        public void StopTextScroll()
        {
            textScrollInstance.Stop();
        }
        public void PlayTextScrollSlow()
        {
            textScrollSlowInstance.Play();
        }
        public void StopTextScrollSlow()
        {
            textScrollSlowInstance.Stop();
        }
    }
}
