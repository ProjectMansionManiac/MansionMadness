using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float chargeTime;
    GameObject enemy;

    public void Initialize(float damage, Vector2 direction)
    {
        this.direction = Vector2.zero;
        enemy = GameObject.Find("Enemy");
        this.transform.parent = enemy.transform;

        StartCoroutine(CleanUpBullet());
        StartCoroutine(ChargeAttack(direction));
    }
    
    IEnumerator CleanUpBullet()
    {
        yield return new WaitForSeconds(5f + chargeTime);

        Destroy(this.gameObject);
    }

    IEnumerator ChargeAttack(Vector2 direction)
    {
        yield return new WaitForSeconds(chargeTime);

        this.transform.parent = null;
        this.direction = direction;
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    public float damage;
    public float speed;

    public Vector2 direction;

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            Destroy(this.gameObject);
        }
    }
}
