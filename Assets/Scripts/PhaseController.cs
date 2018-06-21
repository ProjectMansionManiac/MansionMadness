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
        MirrorSpear,
        Charge,
        Projectile,
        ChargeProjectile,
        All
    }

    public void StartNextPhase()
    {
        GetComponent<BossPhaseInit>().enabled = false;
        GetComponent<BossPhaseMirror>().enabled = false;
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
            case PhaseType.MirrorSpear:
                
                break;
            case PhaseType.Charge:

                break;
            case PhaseType.Projectile:

                break;
            case PhaseType.ChargeProjectile:

                break;
            case PhaseType.All:

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

