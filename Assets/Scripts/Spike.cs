using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

    [Header("How fast the spike moves down")]
    public float moveDownSpeed = 1f;
    [Header("The time, that the spike waits, before it falls down")]
    public float waitTimeAfterSpawn = 1f;
    [Header("The time, how long the spike shakes")]
    public float shakeTime = 1f;
    [Header("The Lifetime of the Spike, after hitting the ground")]
    public float lifetimeAfterHit = 1f;
    [Header("How fast the spike shakes")]
    public float shakeSpeed = 1.0f; //how fast it shakes
    [Header("How strong the spike shakes")]
    public float shakeAmount = 1.0f; //how much it shakes
    [Header("The damage, that a spike deals")]
    public float damage = 10f;

    bool hit = false;
    bool wait = true;
    bool isShaking = false;



    void Start () {
        StartCoroutine(WaitBeforFall());
	}

	// Update is called once per frame
	void Update () {

        if (isShaking && !PhaseController.instance.dead)
        {
            transform.position = new Vector3(transform.position.x + Mathf.Sin(Time.time * shakeSpeed) * shakeAmount, transform.position.y,transform.position.z);
        }

        if (hit)
            return;

        if (wait)
            return;
        transform.position += (Vector3)Vector2.down * Time.deltaTime * moveDownSpeed;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11 && collision.gameObject.tag != "Ceiling")
        {
            hit = true;
            StartCoroutine(DestroyAfterSeconds());
            return;
        }
        if (collision.gameObject.name == "Hitbox")
        {
            this.gameObject.tag = "Untagged";
        }
    }

    IEnumerator WaitBeforFall()
    {
        yield return new WaitForSeconds(lifetimeAfterHit);
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        isShaking = true;
        yield return new WaitForSeconds(shakeTime);
        isShaking = false;
        wait = false;
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(lifetimeAfterHit);
        Destroy(this.gameObject);
    }
}
