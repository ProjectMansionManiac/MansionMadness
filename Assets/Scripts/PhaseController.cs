using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour {

    //public PhaseType[] phases;
    public int currentPhaseIndex = 0;
    private Animator animator;
    public static PhaseController instance = null;

    public Phase[] phases;

    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartNextPhase();
    }

    public enum PhaseType
    {
        Init,
        Mirror,
        Spear,
        Charge,
        BigFireball
    }

    public void StartNextPhase()
    {
        GetComponent<BossPhaseInit>().enabled = false;
        GetComponent<BossPhaseMirror>().enabled = false;
        GetComponent<BossPhaseSpear>().enabled = false;
        GetComponent<BossPhaseCharge>().enabled = false;
        GetComponent<BossPhaseBigFireballs>().enabled = false;

        animator.Play(phases[currentPhaseIndex].animationToPlay);
        if (phases[currentPhaseIndex].spriteToShowInThatPhase != null)
        GetComponent<SpriteRenderer>().sprite = phases[currentPhaseIndex].spriteToShowInThatPhase;
        if (phases.Length > currentPhaseIndex)
        foreach (PhaseType phaseType in phases[currentPhaseIndex].phaseTypes)
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
        currentPhaseIndex++;
    }

    [System.Serializable]
    public class Phase
    {
        public PhaseType[] phaseTypes;
        public float PhaseHealth;
        public string animationToPlay;
        public Sprite spriteToShowInThatPhase;
    }
}

