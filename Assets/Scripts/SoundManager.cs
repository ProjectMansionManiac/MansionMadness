using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip walkSound;
    public AudioClip shootSound;
    public AudioClip bossDamageSound;
    public AudioClip reflectSound;
    public AudioClip crouchSound;
    public AudioClip playerDamageSound;
    public AudioClip dieSound;
    public AudioClip fireballThrowSound;
    public AudioClip playerJumpSound;
    public AudioClip fireballHitSound;
    public AudioClip lancerainSpawnSound;
    public AudioClip lanceRainSound;
    public AudioClip lanceRainCollideSound;
    public AudioClip mirrorSpawnSound;
    public AudioClip bossDieSound;
    public AudioClip envIntroSound;
    public AudioClip envDoorCloseSound;
    public AudioClip envIntroBossSound;
    public AudioClip envMirrorBreakSound;
    public AudioClip dialog1Sound;
    public AudioClip dialog2Sound;
    public AudioClip buttonSound;
    public AudioClip lowEnergySound;
    public AudioClip lowLifeSound;


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

        shoot.Play();
    }
    public void PlayWalkSound()
    {
        if (walk.isPlaying)
            return;

        walk.Play();
    }
    public void PlayBossDamageSound()
    {
        if (bossDamage.isPlaying)
            return;

        bossDamage.Play();
    }
    public void PlayReflectSound()
    {
        if (reflect.isPlaying)
            return;

        reflect.Play();
    }
    public void PlayCrouchSound()
    {
        if (crouch.isPlaying)
            return;

        crouch.Play();
    }
    public void PlayPlayerDamageSound()
    {
        if (playerDamage.isPlaying)
            return;

        playerDamage.Play();
    }
    public void PlayDieSound()
    {
        if (die.isPlaying)
            return;

        die.Play();
    }
    public void PlayFireballThrowSound()
    {
        if (fireballThrow.isPlaying)
            return;

        fireballThrow.Play();
    }
    public void PlayPlayerJumpSound()
    {
        if (fireballFly.isPlaying)
            return;

        fireballFly.Play();
    }
    public void PlayFireballHitSound()
    {
        if (fireballHit.isPlaying)
            return;

        fireballHit.Play();
    }
    public void PlayLancerainSpawnSound()
    {
        if (lancerainSpawn.isPlaying)
            return;

        lancerainSpawn.Play();
    }
    public void PlayLanceRainSound()
    {
        if (lanceRain.isPlaying)
            return;

        lanceRain.Play();
    }
    public void PlayLanceRainCollideSound()
    {
        if (lanceRainCollide.isPlaying)
            return;

        lanceRainCollide.Play();
    }
    public void PlayMirrorSpawnSound()
    {
        if (mirrorSpawn.isPlaying)
            return;

        mirrorSpawn.Play();
    }
    public void PlayBossDieSound()
    {
        if (bossDie.isPlaying)
            return;

        bossDie.Play();
    }
    public void PlayEnvIntroSound()
    {
        if (envIntro.isPlaying)
            return;

        envIntro.Play();
    }
    public void PlayEnvDoorCloseSound()
    {
        if (envDoorClose.isPlaying)
            return;

        envDoorClose.Play();
    }
    public void PlayEnvIntroBossSound()
    {
        if (envIntroBoss.isPlaying)
            return;

        envIntroBoss.Play();
    }
    public void PlayEnvMirrorBreakSound()
    {
        if (envMirrorBreak.isPlaying)
            return;

        envMirrorBreak.Play();
    }
    public void PlayDialog1Sound()
    {
        if (dialog1.isPlaying)
            return;

        dialog1.Play();
    }
    public void PlayDialog2Sound()
    {
        if (dialog2.isPlaying)
            return;

        dialog2.Play();
    }
    public void PlayButtonSound()
    {
        if (button.isPlaying)
            return;

        button.Play();
    }
    public void PlayLowEnergySound()
    {
        if (lowEnergy.isPlaying)
            return;

        lowEnergy.Play();
    }
    public void PlayLowLifeSound()
    {
        if (lowLife.isPlaying)
            return;

        lowLife.Play();
    }

}
