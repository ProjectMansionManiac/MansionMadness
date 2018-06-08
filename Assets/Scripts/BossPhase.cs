using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase : MonoBehaviour {

    public GameObject head;
    public GameObject torso;
    public GameObject restbody;

    public GameObject playerObject;

    public Animator animator;

    public BossDamageComponent[] allDamageComponents;
    public int totalMaxHealth;
    public int totalHealth;


    private void Start()
    {
        playerObject = GameObject.Find("Player");
        allDamageComponents = GetComponentsInChildren<BossDamageComponent>();
        foreach (var damageComponent in allDamageComponents)
        {
            totalMaxHealth += (int)damageComponent.health;
        }
        totalHealth = totalMaxHealth;
    }

    public virtual void ActivatePhase()
    {

    }

    public virtual void DeactivatePhase()
    {
        head.tag = "Untagged";
        torso.tag = "Untagged";
        restbody.tag = "Untagged"; 
    }
}
