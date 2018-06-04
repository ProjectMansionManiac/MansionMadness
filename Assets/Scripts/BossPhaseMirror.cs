using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseMirror : BossPhase {
    [SerializeField] private GameObject[] mirrors;

	public override void ActivatePhase()
    {

        torso.SetActive(true);

        foreach (GameObject mirror in mirrors)
        {
            mirror.SetActive(true);
        }
    }

    public override void DeactivatePhase()
    {
        base.DeactivatePhase();

        foreach (GameObject mirror in mirrors)
        {
            mirror.SetActive(false);
        }
    }

    private void Update()
    {

    }
}
