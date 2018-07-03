using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseInit : BossPhase {
    public override void ActivatePhase()
    {
        Debug.Log("Init Phase Started");
        base.ActivatePhase();
        head.tag = "Enemy";
        torso.tag = "Enemy";
        restbody.tag = "Enemy";

        //animator.Play("InitPhase");
    }

    private void OnEnable()
    {
        ActivatePhase();
    }

    public override void DeactivatePhase()
    {
        base.DeactivatePhase();
    }

    void OnDisable()
    {
        DeactivatePhase();
    }

    public override void Update()
    {
        base.Update();
    }
}
