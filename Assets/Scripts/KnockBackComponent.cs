using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackComponent : MonoBehaviour
{
    public bool canKnockback = true;
    [SerializeField]
    float pushBackCoefficient = 1.0f;
    public void Execute(GameObject collision)
    {
        //if (!canKnockback)
        //    return;

        var obj = collision.gameObject;
        
        Debug.Log("Collision (" + this.gameObject.name + " with " + collision.name + ")");
        
        var player = obj.GetComponentInChildren<PlayerMovement>();
        float xDot = Vector3.Dot(obj.transform.position - this.transform.position, this.transform.position);
        
        if (player == null)
            return;
        
        player.velocity.x = ((xDot / Mathf.Abs(xDot)) * pushBackCoefficient);
        
        Debug.Log("Velocity: " + player.velocity.x);
        
        if (player.velocity.x > 0.1f && player.velocity.x < -0.1f)
           player.velocity.x = -1.0f;
        
        canKnockback = false;
        
        //StartCoroutine(ReactivateKnockback());
    }

    IEnumerator ReactivateKnockback()
    {
        yield return new WaitForSeconds(0.2f);
        canKnockback = true;
    }
}
