using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    static GameManager instance = null;
    public GameState currentState = null;

    public bool alive = false;

    private void Awake()
    {
        instance = this;
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Update()
    {
        if (alive == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameObject.Find("MenuCanvas").GetComponent<Canvas>().enabled = true;
                SceneManager.UnloadSceneAsync("Gate2");
                this.currentState = new GameState();
            }
        }
    }

    public void PlayPressed()
    {
        if (GameObject.Find("MenuCanvas").GetComponent<Canvas>().enabled == true)
        {
            SceneManager.LoadScene("Gate2"/*, LoadSceneMode.Additive*/);
            GameObject.Find("MenuCanvas").GetComponent<Canvas>().enabled = false;
            this.currentState = new GameState();
            Time.timeScale = 1f;
        }
    }

    public void ReloadScene()
    {
        Invoke("InvokedReload", .1f);
    }

    public void InvokedReload()
    {
        SceneManager.LoadScene("Gate2"/*, LoadSceneMode.Additive*/);
        this.currentState = new GameState();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
