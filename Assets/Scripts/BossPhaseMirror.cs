using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseMirror : BossPhase {
    [SerializeField] private GameObject[] mirrors;

	public override void ActivatePhase()
    {
        base.ActivatePhase();

        if (torso != null)
        torso.tag = "Enemy";

        foreach (GameObject mirror in mirrors)
        {
            mirror.SetActive(true);
        }
    }

    private void OnEnable()
    {
        ActivatePhase();
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

        if (playerObject.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
