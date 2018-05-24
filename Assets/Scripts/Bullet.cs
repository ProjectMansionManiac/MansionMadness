using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void Initialize(int damage, Vector2 direction)
    {
        this.damage = damage;
        this.direction = direction;

        StartCoroutine(CleanUpBullet());
    }
    
    IEnumerator CleanUpBullet()
    {
        yield return new WaitForSeconds(5f);

        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    public int damage;
    public int speed;

    public Vector2 direction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            Destroy(this.gameObject);
        }
    }
}
