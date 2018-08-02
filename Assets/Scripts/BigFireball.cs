using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFireball : Bullet {

    [SerializeField] int ballSpawnAmount = 3;
    [SerializeField] bool canExplode = false;

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11 && collision.gameObject.tag != "Through")
        {
            if (canExplode)
            SpawnSmallBalls();

            SoundManager.instance.PlayFireballHitSound();

            Destroy(this.gameObject);
        }
    }

    void SpawnSmallBalls()
    {
        for (int i = 0; i < ballSpawnAmount; i++)
        {
            Shoot(i);
        }
    }

    void Shoot(int i)
    {
        Vector2 dir = -direction;
        GameObject fireball = (GameObject)Instantiate(Resources.Load("Fireball"), transform.position, Quaternion.identity);
        fireball.GetComponent<EnemyBullet>().Initialize(5f, dir);
    }

}
