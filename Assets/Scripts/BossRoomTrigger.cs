using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomTrigger : MonoBehaviour
{

    public GameObject doorToSpawn;
    public float newLeftBound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (SoundManager.instance != null)
            {
                SoundManager.instance.PlayEnvDoorCloseSound();
                SoundManager.instance.PlayEnvIntroBossSound();
            }

            GameObject.Find("Main Camera").GetComponent<CameraFollow>().levelTopLeft.x = newLeftBound;
            PhaseController.instance.StartNextPhase();
            if (doorToSpawn!=null)
            doorToSpawn.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
