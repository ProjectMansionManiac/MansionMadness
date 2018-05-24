using UnityEngine;

public class CheckpointComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.GetInstance().currentState.currentCheckPoint = this.gameObject.transform.position;
        }
    }
}
