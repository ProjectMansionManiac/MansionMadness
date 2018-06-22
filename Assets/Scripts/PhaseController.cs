using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour {

    //public PhaseType[] phases;
    public int currentPhaseIndex = 0;

    public static PhaseController instance = null;

    public Phase[] phases;

    private void Awake()
    {
        instance = this;
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
    }
}

