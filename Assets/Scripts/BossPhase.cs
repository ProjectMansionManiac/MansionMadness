using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase : MonoBehaviour {

    public GameObject head;
    public GameObject torso;
    public GameObject rightArm;
    public GameObject leftArm;
    public GameObject rightLeg;
    public GameObject leftLeg;

	public virtual void ActivatePhase()
    {

    }

    public virtual void DeactivatePhase()
    {
        head.SetActive(false);
        torso.SetActive(false);
        rightArm.SetActive(false);
        leftArm.SetActive(false);
        rightLeg.SetActive(false);
        leftLeg.SetActive(false);

        this.enabled = false;
    }
}
