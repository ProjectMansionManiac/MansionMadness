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

    public GameObject playerObject;

    private void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    public virtual void ActivatePhase()
    {

    }

    public virtual void DeactivatePhase()
    {
        head.tag = "";
        torso.tag = "";
        rightArm.tag = ""; 
        leftArm.tag = "";
        rightLeg.tag = "";
        leftLeg.tag = "";

        this.enabled = false;
    }
}
