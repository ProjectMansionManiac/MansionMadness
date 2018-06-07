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

        Debug.Log("Collision!");

        if (obj.tag == "Player")
        {
            var player = obj.GetComponentInChildren<Player>();
            float xDot = Vector3.Dot(obj.transform.position - this.transform.position, Vector3.right);
            player.velocity.x += (xDot / xDot) * pushBackCoefficient;

            Debug.Log("xDot * pushBackCoefficient: " + (xDot / xDot * pushBackCoefficient));
        }
    }
}
