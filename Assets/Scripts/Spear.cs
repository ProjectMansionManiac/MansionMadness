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

    void Start ()
    {
        Action action = () => { this.dropping = true; };
        this.dropCountdown = new Countdown(action, dropDelay);

        action = () => { this.remove = true; };
        this.removeTimer = new Countdown(action, dropDelay + removeDelay);
    }
	
	void Update ()
    {
        dropCountdown.Update(Time.deltaTime, true);
        removeTimer.Update(Time.deltaTime, false);

        if (dropping)
        {
            this.transform.position += transform.up * dropSpeed;
        }

        if (remove)
        {
            Destroy(this.gameObject);
        }
	}
}
