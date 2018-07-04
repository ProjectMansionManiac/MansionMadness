using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseSpear : BossPhase {

    [SerializeField] float TimeBetweenSpikes;
    [SerializeField] float minSpikePosX, maxSpikePosX, spikePosY;
    [SerializeField] GameObject spikeDrop;
    [SerializeField] GameObject spike;
    GameObject dropObject;
    public override void ActivatePhase()
    {
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

    void OnDisable()
    {
        StopAllCoroutines();
        DeactivatePhase();
    }

    IEnumerator HandleSpikeDrop()
    {
        while (stillActive)
        {
            yield return new WaitForSeconds(TimeBetweenSpikes);

            float spikeWidth = spike.GetComponent<SpriteRenderer>().bounds.size.x;
            float spikeAmount = (float)spikeDrop.GetComponent<DropComponent>().drops.Count;
            float spaceBetweenSpikes = spikeDrop.GetComponent<DropComponent>().spacingSize;

            float fullWidth = (spikeWidth * spikeAmount) + (spaceBetweenSpikes * (spikeAmount - 1));

            float randX = Random.Range(minSpikePosX + fullWidth / 2, maxSpikePosX - fullWidth / 2);
            dropObject = Instantiate(Resources.Load("SpikeDrop"), new Vector3(randX, spikePosY, 0f), Quaternion.identity) as GameObject;
        }

    }
}
