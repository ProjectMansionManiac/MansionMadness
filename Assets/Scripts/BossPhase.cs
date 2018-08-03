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

    public float waitTimeBeforeSpawningObjects;

    public Animator[] otherAnimators;

    [HideInInspector] public Animator spriteAnimator;

    private void Start()
    {
        playerObject = GameObject.Find("Player");

        spriteAnimator = GetComponentInChildren<Animator>();

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

        StartCoroutine(SpawnObjects());

        chicken = GetComponent<Chicken>();
        totalMaxHealth = PhaseController.instance.phases[PhaseController.instance.currentPhaseIndex].PhaseHealth;
        totalHealth = PhaseController.instance.phases[PhaseController.instance.currentPhaseIndex].PhaseHealth;
        chicken.maxHealth = PhaseController.instance.phases[PhaseController.instance.currentPhaseIndex].PhaseHealth;
        chicken.health = PhaseController.instance.phases[PhaseController.instance.currentPhaseIndex].PhaseHealth;
    }

    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(waitTimeBeforeSpawningObjects);
        foreach (GameObject obj in ObjectsToSpawn)
        {
            obj.SetActive(true);
        }

        if (otherAnimators.Length != 0)
        {
            foreach (Animator anim in otherAnimators)
            {
                anim.Play(0);
            }
        }
    }

    public virtual void Update()
    {
        if (playerObject.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        totalHealth = chicken.health;

        if ((float)totalHealth <= 0)
        {
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
