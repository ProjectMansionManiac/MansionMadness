using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip walkSound;
    [Range(0f, 1f)] public float walkVolume;
    public AudioClip shootSound;
    [Range(0f, 1f)] public float shootVolume;
    public AudioClip bossDamageSound;
    [Range(0f, 1f)] public float bossDamageVolume;
    public AudioClip reflectSound;
    [Range(0f, 1f)] public float reflectVolume;
    public AudioClip crouchSound;
    [Range(0f, 1f)] public float crouchVolume;
    public AudioClip playerDamageSound;
    [Range(0f, 1f)] public float playerDamageVolume;
    public AudioClip dieSound;
    [Range(0f, 1f)] public float dieVolume;
    public AudioClip fireballThrowSound;
    [Range(0f, 1f)] public float fireballThrowVolume;
    public AudioClip playerJumpSound;
    [Range(0f, 1f)] public float playerJumpVolume;
    public AudioClip fireballHitSound;
    [Range(0f, 1f)] public float fireballHitVolume;
    public AudioClip lancerainSpawnSound;
    [Range(0f, 1f)] public float lancerainSpawnVolume;
    public AudioClip lanceRainSound;
    [Range(0f, 1f)] public float lanceRainVolume;
    public AudioClip lanceRainCollideSound;
    [Range(0f, 1f)] public float lanceRainCollideVolume;
    public AudioClip mirrorSpawnSound;
    [Range(0f, 1f)] public float mirrorSpawnVolume;
    public AudioClip bossDieSound;
    [Range(0f, 1f)] public float bossDieVolume;
    public AudioClip envIntroSound;
    [Range(0f, 1f)] public float envIntroVolume;
    public AudioClip envDoorCloseSound;
    [Range(0f, 1f)] public float envDoorCloseVolume;
    public AudioClip envIntroBossSound;
    [Range(0f, 1f)] public float envIntroBossVolume;
    public AudioClip envMirrorBreakSound;
    [Range(0f, 1f)] public float envMirrorBreakVolume;
    public AudioClip dialog1Sound;
    [Range(0f, 1f)] public float dialog1Volume;
    public AudioClip dialog2Sound;
    [Range(0f, 1f)] public float dialog2Volume;
    public AudioClip buttonSound;
    [Range(0f, 1f)] public float buttonVolume;
    public AudioClip lowEnergySound;
    [Range(0f, 1f)] public float lowEnergyVolume;
    public AudioClip lowLifeSound;
    [Range(0f, 1f)] public float lowLifeVolume;


    [HideInInspector] public AudioSource walk;
    [HideInInspector] public AudioSource shoot;
    [HideInInspector] public AudioSource bossDamage;
    [HideInInspector] public AudioSource reflect ;
    [HideInInspector] public AudioSource crouch ;
    [HideInInspector] public AudioSource playerDamage;
    [HideInInspector] public AudioSource die ;
    [HideInInspector] public AudioSource fireballThrow;
    [HideInInspector] public AudioSource fireballFly;
    [HideInInspector] public AudioSource fireballHit;
    [HideInInspector] public AudioSource lancerainSpawn;
    [HideInInspector] public AudioSource lanceRain ;
    [HideInInspector] public AudioSource lanceRainCollide;
    [HideInInspector] public AudioSource mirrorSpawn;
    [HideInInspector] public AudioSource bossDie ;
    [HideInInspector] public AudioSource envIntro ;
    [HideInInspector] public AudioSource envDoorClose;
    [HideInInspector] public AudioSource envIntroBoss;
    [HideInInspector] public AudioSource envMirrorBreak;
    [HideInInspector] public AudioSource dialog1 ;
    [HideInInspector] public AudioSource dialog2 ;
    [HideInInspector] public AudioSource button ;
    [HideInInspector] public AudioSource lowEnergy ;
    [HideInInspector] public AudioSource lowLife ;

    public static SoundManager instance;

    void Start()
    {
        if (instance == null)
            instance = this;

        walk             .clip =  walkSound;
        shoot            .clip =  shootSound;
        bossDamage       .clip =  bossDamageSound;
        reflect          .clip =  reflectSound;
        crouch           .clip =  crouchSound;
        playerDamage     .clip =  playerDamageSound;
        die              .clip =  dieSound;
        fireballThrow    .clip =  fireballThrowSound;
        fireballFly      .clip =  playerJumpSound;
        fireballHit      .clip =  fireballHitSound;
        lancerainSpawn   .clip =  lancerainSpawnSound;
        lanceRain        .clip =  lanceRainSound;
        lanceRainCollide .clip =  lanceRainCollideSound;
        mirrorSpawn      .clip =  mirrorSpawnSound;
        bossDie          .clip =  bossDieSound;
        envIntro         .clip =  envIntroSound;
        envDoorClose     .clip =  envDoorCloseSound;
        envIntroBoss     .clip =  envIntroBossSound;
        envMirrorBreak   .clip =  envMirrorBreakSound;
        dialog1          .clip =  dialog1Sound;
        dialog2          .clip =  dialog2Sound;
        button           .clip =  buttonSound;
        lowEnergy        .clip =  lowEnergySound;
        lowLife          .clip = lowLifeSound;

        PlayEnvIntroSound();
    }

    public void PlayShootSound()
    {
        if (shoot.isPlaying)
            return;

        shoot.volume = shootVolume;
        shoot.Play();
    }
    public void PlayWalkSound()
    {
        if (walk.isPlaying)
            return;

        walk.volume = walkVolume;
        walk.Play();
    }
    public void PlayBossDamageSound()
    {
        if (bossDamage.isPlaying)
            return;

        bossDamage.volume = bossDamageVolume;
        bossDamage.Play();
    }
    public void PlayReflectSound()
    {
        if (reflect.isPlaying)
            return;

        reflect.volume = reflectVolume;
        reflect.Play();
    }
    public void PlayCrouchSound()
    {
        if (crouch.isPlaying)
            return;

        crouch.volume = crouchVolume;
        crouch.Play();
    }
    public void PlayPlayerDamageSound()
    {
        if (playerDamage.isPlaying)
            return;

        playerDamage.volume = playerDamageVolume;
        playerDamage.Play();
    }
    public void PlayDieSound()
    {
        if (die.isPlaying)
            return;

        die.volume = dieVolume;
        die.Play();
    }
    public void PlayFireballThrowSound()
    {
        if (fireballThrow.isPlaying)
            return;

        fireballThrow.volume = fireballThrowVolume;
        fireballThrow.Play();
    }
    public void PlayPlayerJumpSound()
    {
        if (fireballFly.isPlaying)
            return;

        fireballFly.volume = playerJumpVolume;
        fireballFly.Play();
    }
    public void PlayFireballHitSound()
    {
        if (fireballHit.isPlaying)
            return;

        fireballHit.volume = fireballHitVolume;
        fireballHit.Play();
    }
    public void PlayLancerainSpawnSound()
    {
        if (lancerainSpawn.isPlaying)
            return;

        lancerainSpawn.volume = lancerainSpawnVolume;
        lancerainSpawn.Play();
    }
    public void PlayLanceRainSound()
    {
        if (lanceRain.isPlaying)
            return;

        lanceRain.volume = lanceRainVolume;
        lanceRain.Play();
    }
    public void PlayLanceRainCollideSound()
    {
        if (lanceRainCollide.isPlaying)
            return;

        lanceRainCollide.volume = lanceRainCollideVolume;
        lanceRainCollide.Play();
    }
    public void PlayMirrorSpawnSound()
    {
        if (mirrorSpawn.isPlaying)
            return;

        mirrorSpawn.volume = mirrorSpawnVolume;
        mirrorSpawn.Play();
    }
    public void PlayBossDieSound()
    {
        if (bossDie.isPlaying)
            return;

        bossDie.volume = bossDieVolume;
        bossDie.Play();
    }
    public void PlayEnvIntroSound()
    {
        if (envIntro.isPlaying)
            return;

        envIntro.volume = envIntroVolume;
        envIntro.Play();
    }
    public void PlayEnvDoorCloseSound()
    {
        if (envDoorClose.isPlaying)
            return;

        envDoorClose.volume = envDoorCloseVolume;
        envDoorClose.Play();
    }
    public void PlayEnvIntroBossSound()
    {
        if (envIntroBoss.isPlaying)
            return;

        envIntroBoss.volume = envIntroBossVolume;
        envIntroBoss.Play();
    }
    public void PlayEnvMirrorBreakSound()
    {
        if (envMirrorBreak.isPlaying)
            return;

        envMirrorBreak.volume = envMirrorBreakVolume;
        envMirrorBreak.Play();
    }
    public void PlayDialog1Sound()
    {
        if (dialog1.isPlaying)
            return;

        dialog1.volume = dialog1Volume;
        dialog1.Play();
    }
    public void PlayDialog2Sound()
    {
        if (dialog2.isPlaying)
            return;

        dialog2.volume = dialog2Volume;
        dialog2.Play();
    }
    public void PlayButtonSound()
    {
        if (button.isPlaying)
            return;

        button.volume = buttonVolume;
        button.Play();
    }
    public void PlayLowEnergySound()
    {
        if (lowEnergy.isPlaying)
            return;

        lowEnergy.volume = lowEnergyVolume;
        lowEnergy.Play();
    }
    public void PlayLowLifeSound()
    {
        if (lowLife.isPlaying)
            return;

        lowLife.volume = lowLifeVolume;
        lowLife.Play();
    }

}
