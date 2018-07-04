using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseMirror : BossPhase {
	public override void ActivatePhase()
    {
        Debug.Log("Mirror Phase Started");
        base.ActivatePhase();

        if (torso != null)
        torso.tag = "Enemy";
        head.tag = "Untagged";
        restbody.tag = "Untagged";
        //animator.Play("MirrorPhase");
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
