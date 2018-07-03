using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseSpear : BossPhase {

    [SerializeField] float TimeBetweenSpikes;
    [SerializeField] float minSpikePosX, maxSpikePosX, spikePosY;

    GameObject dropObject;
    public override void ActivatePhase()
    {
        Debug.Log("Spear Phase Started");
        base.ActivatePhase();
        head.tag = "Enemy";
        torso.tag = "Untagged";
        restbody.tag = "Untagged";

        StartCoroutine(HandleSpikeDrop());
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

    public override void Update()
    {
        base.Update();
    }

    IEnumerator HandleSpikeDrop()
    {
        while (stillActive)
        {
            yield return new WaitForSeconds(TimeBetweenSpikes);
            float randX = Random.Range(minSpikePosX, maxSpikePosX);
            dropObject = Instantiate(Resources.Load("SpikeDrop"), new Vector3(randX, spikePosY, 0f), Quaternion.identity) as GameObject;        }
    }
}
