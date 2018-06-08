using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    private void Start()
    { 
            
        GameManager.GetInstance().currentState.currentCheckPoint = transform.position;
    }

    public void Die()
    {
        Text winText = GameObject.Find("WinText").GetComponent<Text>();
        winText.enabled = true;
        winText.text = "GAME OVER";

        Time.timeScale = 0f;


        Destroy(this.gameObject);
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5f);
    }
}
