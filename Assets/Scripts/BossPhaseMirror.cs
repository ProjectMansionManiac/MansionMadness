using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseMirror : BossPhase {
	public override void ActivatePhase()
    {
        base.ActivatePhase();

        if (torso != null)
        torso.tag = "Enemy";

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

    public override void Update()
    {
        base.Update();
        if (playerObject.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
