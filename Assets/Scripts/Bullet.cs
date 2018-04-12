using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage;
    public int speed;
    public Vector2 direction;

    public void Initialize(int damage, Vector2 direction)
    {
        this.damage = damage;
        this.direction = direction;
        StartCoroutine(CleanUpBullet());
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    IEnumerator CleanUpBullet()
    {
        yield return new WaitForSeconds(5f);

        Destroy(this.gameObject);
    }
}
