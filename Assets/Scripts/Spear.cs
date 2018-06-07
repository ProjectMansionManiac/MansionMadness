using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    private Countdown dropCountdown;
    private Countdown removeTimer;

    public bool dropping = false;
    public bool remove = false;

    [SerializeField]
    private float dropDelay = 1.0f;
    [SerializeField]
    private float dropSpeed = 0.5f;

    [SerializeField]
    private float removeDelay = 5.0f;

    [SerializeField]
    private float spearDamage = 50.0f;

    void Start ()
    {
        Action action = () => { this.dropping = true; };
        this.dropCountdown = new Countdown(action, dropDelay);

        action = () => { this.remove = true; };
        this.removeTimer = new Countdown(action, dropDelay + removeDelay);
    }
	
	void Update ()
    {
        dropCountdown.Update(Time.deltaTime);
        removeTimer.Update(Time.deltaTime);

        if (dropping)
        {
            this.transform.position += transform.up * dropSpeed;
        }

        if (remove)
        {
            this.remove = false;
            this.dropping = false;
            this.gameObject.SetActive(false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            var dmgComp = collider.gameObject.GetComponent<DamageComponent>();

            if (dmgComp == null)
                return;

            dmgComp.health -= this.spearDamage;
            this.gameObject.SetActive(false);
        }

        if (collider.tag == "Through")
        {
            this.gameObject.SetActive(false);
        }
    }
}
