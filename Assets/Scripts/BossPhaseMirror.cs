using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseMirror : BossPhase {
    [SerializeField] private GameObject[] mirrors;

	public override void ActivatePhase()
    {
        if (torso != null)
        torso.SetActive(true);

        foreach (GameObject mirror in mirrors)
        {
            mirror.SetActive(true);
        }
    }

    public override void DeactivatePhase()
    {
        foreach (GameObject mirror in mirrors)
        {
            mirror.SetActive(false);
        }

        base.DeactivatePhase();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivatePhase();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DeactivatePhase();
        }
    }
}
