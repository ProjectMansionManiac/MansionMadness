using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseInit : BossPhase {
    public override void ActivatePhase()
    {
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

    public override void Update()
    {
        base.Update();
    }
}
