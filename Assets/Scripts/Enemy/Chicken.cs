using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Boss {

    public float[] shootIntervals;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        while (true) {
            for(int i = 0; i < shootPos.Length; i++)
            {
                yield return new WaitForSeconds(shootIntervals[i]);
                Shoot(i);
            }
        }
    }

    void Shoot(int fromPos)
    {
        Vector2 direction = Vector2.left;
        if (transform.rotation.eulerAngles.y > 90)
        {
            direction = Vector2.right;
        }
        GameObject enemyBullet = (GameObject)Instantiate(Resources.Load("Fireball"), shootPos[fromPos].position, Quaternion.identity);
        enemyBullet.GetComponent<EnemyBullet>().Initialize(damage, direction);
    }
}
