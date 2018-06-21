using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float maxHealth;
    public float health;

    public float damage;

	void Awake () {
        health = maxHealth;
	}

    public void ApplyDamage(float damage)
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

        Time.timeScale = 0f;

        Destroy(gameObject);
    }
}
