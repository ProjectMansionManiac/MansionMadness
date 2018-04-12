using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public int maxHealth;
    public int health;

    public int damage;

	void Awake () {
        health = maxHealth;
	}

    public void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Text winText = GameObject.Find("WinText").GetComponent<Text>();
        winText.enabled = true;

        GameManager.GetInstance().alive = false;

        Destroy(this.gameObject);
    }
}
