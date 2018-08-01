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
    public AudioClip fireballFlySound;
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

    public AudioSource walk;
    public AudioSource shoot;
    public AudioSource bossDamage;

    public static SoundManager instance;

    void Start()
    {
        if (instance == null)
            instance = this;

        shoot.clip = shootSound;
        walk.clip = walkSound;
        bossDamage.clip = bossDamageSound;
    }

    public void playShootSound()
    {
        if (shoot.isPlaying)
            return;

        shoot.Play();
    }

    public void playWalkSound()
    {
        if (walk.isPlaying)
            return;

        walk.Play();
    }

    public void playBossDamageSound()
    {
        if (bossDamage.isPlaying)
            return;

        bossDamage.Play();
    }

}
