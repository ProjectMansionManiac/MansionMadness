using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

    public float downSpeed = 1f;
    public float lifetime;
    public float damage = 10f;

    bool hit = false;


	void Start () {
        StartCoroutine(DestroyAfterSeconds());
	}
	
	// Update is called once per frame
	void Update () {
        if (hit)
            return;

        transform.position += (Vector3)Vector2.down * Time.deltaTime * downSpeed;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            hit = true;
            return;
        }
        if (collision.gameObject.name == "Hitbox")
        {
            this.gameObject.tag = "Untagged";
        }
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }
}
