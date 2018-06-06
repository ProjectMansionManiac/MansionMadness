﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseInit : BossPhase {

    [Header("Health fraction from 0-1. The phase will change at this health fraction")]
    public float healthFraction;

    public override void ActivatePhase()
    {
        base.ActivatePhase();
        head.tag = "Enemy";
        torso.tag = "Enemy";
        rightArm.tag = "Enemy";
        leftArm.tag = "Enemy";
        rightLeg.tag = "Enemy";
        leftLeg.tag = "Enemy";

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

    private void Update()
    {
        totalHealth = 0;
        foreach (var damageComponent in allDamageComponents)
        {
            totalHealth += (int)damageComponent.health;
        }
        if (totalHealth / totalMaxHealth < healthFraction)
        {
            DeactivatePhase();
            PhaseController.instance.StartNextPhase();
            this.enabled = false;
        }
    }
}