using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioM;
    [SerializeField] private AudioMixer audioS;
    [SerializeField] private Slider audioslider;
    [SerializeField] private Slider sfxslider;
    [SerializeField] private Slider BrightnessSlider;
    [SerializeField] private Toggle windowToggle;
    [SerializeField] private PostProcessProfile profile;

    private float currentVolume;
    private float currentSFX;
    private float rbgValue = 0.5f;

    public void Start()
    {
        currentVolume = PlayerPrefs.GetFloat("set volume", audioslider.value);
        currentSFX = PlayerPrefs.GetFloat("set sfx", audioslider.value);
        sfxslider.value = currentSFX;
        BrightnessSlider.value = profile.GetSetting<ColorGrading>().postExposure.value;
    }

    public void SetVol(float volume)
    {
        audioM.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("set volume", volume);
        PlayerPrefs.Save();
    }

    public void SetSFX(float sfx)
    {
        audioS.SetFloat("sfx", sfx);
        PlayerPrefs.SetFloat("set volume", sfx);
        PlayerPrefs.Save();
    }

    public void SetQuality(int qualIndex)
    {
        QualitySettings.SetQualityLevel(qualIndex);
    }

    public void SetFullScreen()
    {
        if (windowToggle.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Debug.Log("Fullscreen is OFF");
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            Debug.Log("Fullscreen is ON");
        }
    }

    public void SetBrightness()
    {
        profile.GetSetting<ColorGrading>().postExposure.value = BrightnessSlider.value;
    }    
}
