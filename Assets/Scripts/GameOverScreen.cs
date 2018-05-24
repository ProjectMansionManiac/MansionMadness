using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

    public GameObject gameOverScreen;

    private void OnEnable()
    {
        gameOverScreen = GameObject.Find("GameOverScreen");
        gameOverScreen.SetActive(true);
    }
    private void OnDisable()
    {
        gameOverScreen.SetActive(false);
    }

    public void OnReturnToCheckpointPressed()
    {
        GameObject.Find("Player").GetComponentInChildren<PlayerDamageComponent>().Respawn();
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnRestartPressed()
    {
        gameObject.SetActive(false);
        GameManager.GetInstance().ReloadScene();
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Gate1"));
        Time.timeScale = 1f;
    }

    public void OnMainMenuPressed()
    {
        GameManager.GetInstance().BackToMenu();
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Gate1"));
        Time.timeScale = 1f;
    }
}
