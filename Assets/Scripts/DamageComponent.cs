using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    public struct DamageInfo
    {
        public GameObject sender;
        public float damage;
    }

    public virtual void OnDamageReceived(DamageInfo info)
    {

        // check if the objects health minus the
        // damage to be done, is above zero
        if (this.health - info.damage >= 0.0f)
        {
            // subtract the damage
            this.health -= info.damage;
        }
        else
        {
            // otherwise clamp it
            this.health = 0.0f;
        }
    }
    
    [SerializeField] protected bool isDead = false;
    public float health = 100.0f;
    public float maxHealth = 100.0f;
}