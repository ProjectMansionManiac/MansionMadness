using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase : MonoBehaviour {

    [HideInInspector] public GameObject head;
    [HideInInspector] public GameObject torso;
    [HideInInspector] public GameObject restbody;

    [HideInInspector]
    public GameObject playerObject;

    [HideInInspector]
    public Chicken chicken;

    [HideInInspector]
    public float totalMaxHealth;

    [HideInInspector]
    public float totalHealth;

    [SerializeField] private GameObject[] ObjectsToSpawn;

    [HideInInspector] public bool stillActive = false;

    private void Start()
    {
        playerObject = GameObject.Find("Player");

        head = transform.Find("HitboxHead").gameObject;
        torso = transform.Find("HitboxTorso").gameObject;
        restbody = transform.Find("HitboxBody").gameObject;

    //allDamageComponents = GetComponentsInChildren<BossDamageComponent>();
    //foreach (var damageComponent in allDamageComponents)
    //{
    //    totalMaxHealth += (int)damageComponent.health;
    //}
    //totalHealth = totalMaxHealth;

    chicken = GetComponent<Chicken>();
}

    public virtual void ActivatePhase()
    {
        stillActive = true;
        Debug.Log("Boss Phase Changed...");
        foreach (GameObject obj in ObjectsToSpawn)
        {
            obj.SetActive(true);
        }

        chicken = GetComponent<Chicken>();
        totalMaxHealth = PhaseController.instance.phases[PhaseController.instance.currentPhaseIndex].PhaseHealth;
        totalHealth = PhaseController.instance.phases[PhaseController.instance.currentPhaseIndex].PhaseHealth;
        chicken.maxHealth = PhaseController.instance.phases[PhaseController.instance.currentPhaseIndex].PhaseHealth;
        chicken.health = PhaseController.instance.phases[PhaseController.instance.currentPhaseIndex].PhaseHealth;
    }

    public virtual void Update()
    {
        totalHealth = chicken.health;
       
        if ((float)totalHealth <= 0)
        {
            DeactivatePhase();
            PhaseController.instance.StartNextPhase();
        }
    }

    public virtual void DeactivatePhase()
    {
        stillActive = false;
        foreach (GameObject obj in ObjectsToSpawn)
        {
            obj.SetActive(false);
        }

        head.tag = "Untagged";
        torso.tag = "Untagged";
        restbody.tag = "Untagged"; 
    }
}
