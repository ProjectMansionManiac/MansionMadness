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

    [SerializeField] private GameObject[] ObjectsToSpawn;

    [HideInInspector]
    public float HealthToChangePhase;

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
        foreach (GameObject obj in ObjectsToSpawn)
        {
            obj.SetActive(false);
        }
    }

    public virtual void Update()
    {
        totalHealth = 0;
        foreach (var damageComponent in allDamageComponents)
        {
            totalHealth += (int)damageComponent.health;
        }
        if ((float)totalHealth < PhaseController.instance.phases[PhaseController.instance.currentPhaseIndex - 1].HealthToChangePhase)
        {
            DeactivatePhase();
            PhaseController.instance.StartNextPhase();
        }
    }

    public virtual void DeactivatePhase()
    {
        foreach (GameObject obj in ObjectsToSpawn)
        {
            obj.SetActive(false);
        }

        head.tag = "Untagged";
        torso.tag = "Untagged";
        restbody.tag = "Untagged"; 
    }
}
