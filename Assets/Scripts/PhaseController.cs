using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour {

    public PhaseType[] phases;
    int currentPhaseIndex = 0;

    public static PhaseController instance = null;

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
        switch (currentPhaseIndex)
        {
            case (int)PhaseType.Init:
                GetComponent<BossPhaseInit>().enabled = true;
                break;
            case (int)PhaseType.Mirror:
                GetComponent<BossPhaseMirror>().enabled = true;
                break;
            case (int)PhaseType.Spear:
                GetComponent<BossPhaseSpear>().enabled = true;
                break;
            case (int)PhaseType.MirrorSpear:

                break;
            case (int)PhaseType.Charge:

                break;
            case (int)PhaseType.Projectile:

                break;
            case (int)PhaseType.ChargeProjectile:

                break;
            case (int)PhaseType.All:

                break;
        }

        currentPhaseIndex++;
    }
}
