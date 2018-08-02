using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private GameObject pauseMenuObject;

    public float fadeTimeBetweenSteps = .1f;
    public float fadeStepAmount = .1f;

    
    private void Start()
    {
        pauseMenuObject = GameObject.Find("PauseMenu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void OnContinuePressed()
    {
        pauseMenuObject.SetActive(false);
        StartCoroutine(FadeTimeScale());
    }

    IEnumerator FadeTimeScale()
    {
        while (Time.timeScale <= 1f)
        {
            Time.timeScale += fadeStepAmount;
            yield return new WaitForSeconds(fadeTimeBetweenSteps);
        }
    }

}
