using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Boss {

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        while (true) {
            yield return new WaitForSeconds(1f);
            for(int i = 0; i < shootPos.Length; i++)
            {
                Shoot(i);
            }
        }
    }

    void Shoot(int fromPos)
    {
        Vector2 direction = Vector2.left;
        GameObject enemyBullet = (GameObject)Instantiate(Resources.Load("EnemyBullet"), shootPos[fromPos].position, Quaternion.identity);
        enemyBullet.GetComponent<EnemyBullet>().Initialize(damage, direction);
    }
}
