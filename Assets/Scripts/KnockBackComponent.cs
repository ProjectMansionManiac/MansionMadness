using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackComponent : MonoBehaviour
{
    [SerializeField]
    float pushBackCoefficient = 1.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject;
        
        if (obj.tag == "Player")
        {
            var player = obj.GetComponentInChildren<PlayerMovement>();
            float xDot = Vector3.Dot(this.transform.position - obj.transform.position, this.transform.position);

            if (player == null)
                return;

            player.velocity.x += (xDot / Mathf.Abs(xDot)) * pushBackCoefficient;
            
            if (player.velocity.x == 0.0f)
                player.velocity.x = -1.0f;
        }
    }
}
