using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    static GameManager instance;

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
                SceneManager.UnloadSceneAsync("levelDesign");
            }
        }
    }

    public void PlayPressed()
    {
        if (GameObject.Find("MenuCanvas").GetComponent<Canvas>().enabled == true)
        {
            SceneManager.LoadScene("levelDesign", LoadSceneMode.Additive);
            GameObject.Find("MenuCanvas").GetComponent<Canvas>().enabled = false;
        }
    }
}
