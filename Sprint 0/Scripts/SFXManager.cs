using Microsoft.Xna.Framework;
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
        bool musicStopped = false;
        double stopTimer = ObjectConstants.zero;

        private SFXManager()
        {
            SoundEffect.MasterVolume = 0;
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
        SoundEffect shotgunBang;
        SoundEffect fireCandle;
        SoundEffect fireMagicRod;
        SoundEffect gameOver;               //definitely needs to be loopable
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
        SoundEffect triforcePiece;

        SoundEffectInstance gameOverInstance;
        SoundEffectInstance lowHealthInstance;
        SoundEffectInstance musicInstance;
        SoundEffectInstance refillLoopInstance;
        SoundEffectInstance shoreInstance;
        SoundEffectInstance textScrollInstance;
        SoundEffectInstance textScrollSlowInstance;

        public void LoadAllSounds(ContentManager content)
        {
            bombExplosion = content.Load<SoundEffect>(ObjectConstants.bombExplosionStr);
            bombPlacement = content.Load<SoundEffect>(ObjectConstants.bombPlacementStr);
            bossHit = content.Load<SoundEffect>(ObjectConstants.bossHitStr);
            bossScream1 = content.Load<SoundEffect>(ObjectConstants.bossScream1Str);
            bossScream2 = content.Load<SoundEffect>(ObjectConstants.bossScream2Str);
            bossScream3 = content.Load<SoundEffect>(ObjectConstants.bossScream3Str);
            doorUnlocking = content.Load<SoundEffect>(ObjectConstants.doorUnlockingStr);
            enemyDeath = content.Load<SoundEffect>(ObjectConstants.enemyDeathStr);
            enemyHit = content.Load<SoundEffect>(ObjectConstants.enemyHitStr);
            fanfare = content.Load<SoundEffect>(ObjectConstants.fanfareStr);
            fireArrowBoomerang = content.Load<SoundEffect>(ObjectConstants.fireArrowBoomerangStr);
            shotgunBang = content.Load<SoundEffect>(ObjectConstants.shotgunBangStr);
            fireCandle = content.Load<SoundEffect>(ObjectConstants.fireCandleStr);
            fireMagicRod = content.Load<SoundEffect>(ObjectConstants.fireMagicRodStr);
            gameOver = content.Load<SoundEffect>(ObjectConstants.gameOverStr);
            keySpawn = content.Load<SoundEffect>(ObjectConstants.keySpawnStr);
            linkDeath = content.Load<SoundEffect>(ObjectConstants.linkDeathStr);
            linkHit = content.Load<SoundEffect>(ObjectConstants.linkHitStr);
            lowHealth = content.Load<SoundEffect>(ObjectConstants.lowHealthStr);
            music = content.Load<SoundEffect>(ObjectConstants.musicStr);
            pickUpHeart = content.Load<SoundEffect>(ObjectConstants.pickUpHeartStr);
            pickUpItem = content.Load<SoundEffect>(ObjectConstants.pickUpItemStr);
            pickupRupee = content.Load<SoundEffect>(ObjectConstants.pickupRupeeStr);
            recorder = content.Load<SoundEffect>(ObjectConstants.recorderStr);
            refillLoop = content.Load<SoundEffect>(ObjectConstants.refillLoopStr);
            secretFound = content.Load<SoundEffect>(ObjectConstants.secretFoundStr);
            shieldDeflect = content.Load<SoundEffect>(ObjectConstants.shieldDeflectStr);
            shore = content.Load<SoundEffect>(ObjectConstants.shoreStr);
            stairs = content.Load<SoundEffect>(ObjectConstants.stairsStr);
            swordCombined = content.Load<SoundEffect>(ObjectConstants.swordCombinedStr);
            swordShoot = content.Load<SoundEffect>(ObjectConstants.swordShootStr);
            swordSlash = content.Load<SoundEffect>(ObjectConstants.swordSlashStr);
            textScroll = content.Load<SoundEffect>(ObjectConstants.textScrollStr);
            textScrollSlow = content.Load<SoundEffect>(ObjectConstants.textScrollSlowStr);
            triforcePiece = content.Load<SoundEffect>(ObjectConstants.triforcePieceSoundStr);

            gameOverInstance = gameOver.CreateInstance();
            lowHealthInstance = lowHealth.CreateInstance();
            musicInstance = music.CreateInstance();
            refillLoopInstance = refillLoop.CreateInstance();
            shoreInstance = shore.CreateInstance();
            textScrollInstance = textScroll.CreateInstance();
            textScrollSlowInstance = textScrollSlow.CreateInstance();

            gameOverInstance.IsLooped = true;
            lowHealthInstance.IsLooped = true;
            musicInstance.IsLooped = true;
            refillLoopInstance.IsLooped = true;
            shoreInstance.IsLooped = true;
            textScrollInstance.IsLooped = true;
            textScrollSlowInstance.IsLooped = true;

            PlayMusic();
        }

        public void Update(GameTime gt)
        {
            if (musicStopped)
            {
                stopTimer -= gt.ElapsedGameTime.TotalSeconds;
                if (stopTimer <= 0)
                {
                    musicStopped = false;
                    PlayMusic();
                }
            }
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
            InterruptMusic(fanfare);
        }
        public void PlayFireArrowBoomerang()
        {
            fireArrowBoomerang.Play();
        }
        public void PlayShotgunBang()
        {
            shotgunBang.Play();
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
        public void PlayTriforcePiece()
        {
            InterruptMusic(triforcePiece);
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
        public void PlayGameOver()
        {
            gameOverInstance.Play();
        }
        public void StopGameOver()
        {
            gameOverInstance.Stop();
        }
        public void PauseMusic()
        {
            musicInstance.Pause();
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

        public void InterruptMusic(SoundEffect sound)
        {
            musicStopped = true;
            StopMusic();
            sound.Play();
            stopTimer = sound.Duration.TotalSeconds;
        }
    }
}
