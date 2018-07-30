using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public GameObject pauseMenuObject;

	void Update () {
		if (Input.GetKey(KeyCode.Joystick1Button7) || Input.GetKey(KeyCode.Escape)){
            ChangeActiveState();
        }
    }

    void ChangeActiveState()
    {
        pauseMenuObject.SetActive(!pauseMenuObject.activeSelf);
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
    
    public void OnContinueClicked()
    {
        ChangeActiveState();
    }

    public void OnRestartClicked()
    {
        GameManager.GetInstance().ReloadScene();
    }

    public void OnBackToMenuPressed()
    {
        GameManager.GetInstance().BackToMenu();
    }
}
