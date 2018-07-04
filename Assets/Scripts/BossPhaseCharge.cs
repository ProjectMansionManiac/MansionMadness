using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseCharge : BossPhase {

    [SerializeField] float TimeBetweenCharges;
    [SerializeField] float TimeWithoutHelmet;

    bool canCharge = false;
    public override void ActivatePhase()
    {
        Debug.Log("Charge Phase Started");
        base.ActivatePhase();

        canCharge = true;
        head.tag = "Untagged";
        restbody.tag = "Untagged";
        torso.tag = "Untagged";
        StartCoroutine(HandleCharge());
        //animator.Play("InitPhase");
    }

    private void OnEnable()
    {
        ActivatePhase();
    }

    public override void DeactivatePhase()
    {
        base.DeactivatePhase();

        canCharge = false;
    }

    public override void Update()
    {
        base.Update();
    }

    void OnDisable()
    {
        DeactivatePhase();
    }

    IEnumerator HandleCharge()
    {
        while (canCharge)
        {
            //Show Entry Animation
            yield return new WaitForSeconds(TimeBetweenCharges);
            //Show Helmet taking off animation
            head.tag = "Enemy";
            yield return new WaitForSeconds(TimeWithoutHelmet);
            //show Charging animation
            head.tag = "Untagged";
        }
    }
}
