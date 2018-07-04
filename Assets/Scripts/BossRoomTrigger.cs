using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomTrigger : MonoBehaviour
{

    public GameObject doorToSpawn;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PhaseController.instance.StartNextPhase();
            doorToSpawn.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
