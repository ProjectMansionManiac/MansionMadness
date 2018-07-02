using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseBigFireballs : BossPhase
{
    public GameObject BigFireBallPrefab;

    [SerializeField] float TimeBetweenFireballs = 1f;
    [SerializeField] Transform shootingPivot;
    bool canShoot = false;
    public override void ActivatePhase()
    {
        Debug.Log("Big Fireball Phase Started");
        base.ActivatePhase();
        head.tag = "Enemy";
        torso.tag = "Enemy";
        restbody.tag = "Enemy";

        canShoot = true;

        StartCoroutine(HandleShooting());
        //animator.Play("InitPhase");
    }

    private void OnEnable()
    {
        ActivatePhase();
    }

    public override void DeactivatePhase()
    {
        base.DeactivatePhase();

        canShoot = false;
    }

    public override void Update()
    {
        base.Update();
    }

    IEnumerator HandleShooting()
    {
        while (canShoot)
        {
            yield return new WaitForSeconds(TimeBetweenFireballs);
            Shoot();

        }
    }

    private void OnDisable()
    {
        canShoot = false;
    }

    void Shoot()
    {
        Vector2 direction = (playerObject.transform.position - shootingPivot.position).normalized;
        GameObject fireball = (GameObject)Instantiate(BigFireBallPrefab, shootingPivot.position, Quaternion.identity);
        fireball.GetComponent<BigFireball>().Initialize(5f, direction);
    }
}
