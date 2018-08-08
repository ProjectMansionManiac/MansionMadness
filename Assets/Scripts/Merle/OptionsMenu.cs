using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    //public AudioMixer audioMixer;
    //public Dropdown resolutionDropdown;
    Resolution[] resulutions;


    /*void Start()
    {
       resulutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResulutionIndex = 0;

        for (int i = 0; i < resulutions.Length ; i++)
        {
            string option = resulutions[i].width + "x" + resulutions[i].height;
            options.Add(option);
            if (resulutions[i].width == Screen.currentResolution.width && resulutions[i].height == Screen.currentResolution.height)
            {

                currentResulutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResulutionIndex;
        resolutionDropdown.RefreshShownValue();

    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resulutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height , Screen.fullScreen);

    }
    
    public void SetVolume(float volume)
    {

        audioMixer.SetFloat("volume", volume);
    }
    public void GraficRes (int qualityIndex)
    {

        QualitySettings.SetQualityLevel(qualityIndex);
    }

    */
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

    }

    public void SetMusicVolume()
    {

    }
    public void SetSoundVolume()
    {

    }

    public Slider musicSlider, soundSlider;
    public Toggle musicToggle, soundToggle;

    void Update()
    {
        PlayerPrefs.SetFloat("musicvolume", musicSlider.value);
        PlayerPrefs.SetFloat("soundvolume", musicSlider.value);

        if (!musicToggle.isOn)
        {
            PlayerPrefs.SetFloat("musicvolume", 0f);
        }
        if (!soundToggle.isOn)
        {
            PlayerPrefs.SetFloat("soundvolume", 0f);
        }

        GameObject.Find("BackroundMusik").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume");
    }

}
