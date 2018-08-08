using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseController : MonoBehaviour {

    public Image healthbar;
    public float health1, health2, health3, maxhealth1, maxhealth2, maxhealth3;
    //public PhaseType[] phases;
    public int currentPhaseIndex = 0;
    private Animator animator;
    public static PhaseController instance = null;
    public GameObject statusScreen;
    public Phase[] phases;
    [HideInInspector] public bool dead = false;
    AudioSource audioSource;
    float maxVolume;

    public GameObject bossLoose, trineWin;
    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = audioSource.volume * PlayerPrefs.GetFloat("musicvolume", 1f);
        maxVolume = audioSource.volume;
    }

    private void Start()
    {
        //StartNextPhase();
        //healthbar = GameObject.Find("Boss_Health").GetComponent<Image>();

        if (phases.Length < 4)
            return;

        health1 = phases[0].PhaseHealth + phases[1].PhaseHealth;
        health2 = phases[2].PhaseHealth + phases[3].PhaseHealth;
        health3 = phases[4].PhaseHealth + phases[5].PhaseHealth;
        maxhealth1 = health1;
        maxhealth2 = health2;
        maxhealth3 = health3;
    }

    public enum PhaseType
    {
        Init,
        Mirror,
        Spear,
        Charge,
        BigFireball
    }

    bool startFilling = false;

    public void StartNextPhase()
    {
        startFilling = true;
        GetComponent<BossPhaseInit>().enabled = false;
        GetComponent<BossPhaseMirror>().enabled = false;
        GetComponent<BossPhaseSpear>().enabled = false;
        GetComponent<BossPhaseCharge>().enabled = false;
        GetComponent<BossPhaseBigFireballs>().enabled = false;

        if (phases.Length <= currentPhaseIndex)
        {
            PlayWinMusic();

            statusScreen.SetActive(true);
            bossLoose.SetActive(true);
            trineWin.SetActive(true);
            if (GameObject.Find("StatusText") != null)
            {
                var statusText = GameObject.Find("StatusText").GetComponent<UnityEngine.UI.Text>();
                statusText.text = "YOU WIN!";
            }
            dead = true;
            Time.timeScale = 0f;
            return;
        }

        animator.Play(phases[currentPhaseIndex].animationToPlay);
        if (GameObject.Find("EnemySprite").GetComponent<Animator>() != null)
        {
            GameObject.Find("EnemySprite").GetComponent<Animator>().Play(phases[currentPhaseIndex].spriteAnimationToPlay);
        }
        if (phases[currentPhaseIndex].spriteToShowInThatPhase != null)
        {
            GetComponent<SpriteRenderer>().sprite = phases[currentPhaseIndex].spriteToShowInThatPhase;
        }
        if (phases.Length > currentPhaseIndex)
        {
            if (phases[currentPhaseIndex].music != null)
            {
                StartCoroutine(FadeMusic());
            }
            foreach (PhaseType phaseType in phases[currentPhaseIndex].phaseTypes)
            {
                switch (phaseType)
                {
                    case PhaseType.Init:
                        GetComponent<BossPhaseInit>().enabled = true;
                        break;
                    case PhaseType.Mirror:
                        GetComponent<BossPhaseMirror>().enabled = true;
                        break;
                    case PhaseType.Spear:
                        GetComponent<BossPhaseSpear>().enabled = true;
                        break;
                    case PhaseType.Charge:
                        GetComponent<BossPhaseCharge>().enabled = true;
                        break;
                    case PhaseType.BigFireball:
                        GetComponent<BossPhaseBigFireballs>().enabled = true;
                        break;
                }
            }
        }
        currentPhaseIndex++;

        //fixed

        if (currentPhaseIndex == 1)
            StartCoroutine(ChangeSprite());
    }

    IEnumerator FadeMusic()
    {
        while (audioSource.volume > 0f)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            audioSource.volume -= maxVolume / 10f;
        }

        audioSource.clip = phases[currentPhaseIndex - 1].music;
        audioSource.Play();

        while (audioSource.volume < maxVolume)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            audioSource.volume += maxVolume / 10f;
        }
    }

    public AudioClip LooseMusic;
    public AudioClip WinMusic;

    public void PlayLooseMusic()
    {
        StartCoroutine(FadeMusicLoose());


        Debug.Log("Loose music");
    }

    public void PlayWinMusic()
    {
        StartCoroutine(FadeMusicWin());
    }

    IEnumerator FadeMusicWin()
    {
        while (audioSource.volume > 0f)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            audioSource.volume -= maxVolume / 10f;
        }

        audioSource.clip = WinMusic;
        audioSource.Play();

        while (audioSource.volume < maxVolume)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            audioSource.volume += maxVolume / 10f;
        }
    }

     IEnumerator FadeMusicLoose()
    {
        while (audioSource.volume > 0f)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            audioSource.volume -= maxVolume / 10f;
        }

        audioSource.clip = LooseMusic;
        audioSource.Play();

        while (audioSource.volume < maxVolume)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            audioSource.volume += maxVolume / 10f;
        }
    }

    IEnumerator ChangeSprite()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (phases[currentPhaseIndex - 1].spriteToShowInThatPhase != null)
            {
                GetComponent<SpriteRenderer>().sprite = phases[currentPhaseIndex - 1].spriteToShowInThatPhase;
            }
        }
    }

    private void LateUpdate()
    {
        if (currentPhaseIndex != 0)
        if (phases[currentPhaseIndex - 1].spriteToShowInThatPhase != null)
        {
            GetComponent<SpriteRenderer>().sprite = phases[currentPhaseIndex - 1].spriteToShowInThatPhase;
        }
    }

    bool full = false;
    void UpdateHealthbar()
    {
        if (healthbar == null)
            return;

        if (startFilling && !full)
        {
            healthbar.fillAmount += Time.deltaTime;
            if (healthbar.fillAmount >= 1f)
            {
                full = true;
            }
            return;
        }

        if (!startFilling)
            return;

        healthbar.fillAmount = (health1 / maxhealth1 / 3f) + (health2 / maxhealth2 / 3f) + (health3 / maxhealth3 / 3f);
        Debug.Log((health1 / maxhealth1 / 3f) + (health2 / maxhealth2 / 3f) + (health3 / maxhealth3 / 3f));
    }

    private void Update()
    {
        UpdateHealthbar();
    }

    [System.Serializable]
    public class Phase
    {
        public PhaseType[] phaseTypes;
        public float PhaseHealth;
        public string animationToPlay;
        public string spriteAnimationToPlay;
        public Sprite spriteToShowInThatPhase;
        public AudioClip music;
    }
}

