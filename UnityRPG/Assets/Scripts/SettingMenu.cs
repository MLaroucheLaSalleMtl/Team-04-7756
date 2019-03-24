using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{

    [SerializeField] private AudioMixer audioM;
    [SerializeField] private AudioMixer audioS;
    [SerializeField] private Slider audioslider;
    [SerializeField] private Slider sfxslider;
    [SerializeField] private Slider BrightnessSlider;
    private Rect sliderpos;
    private float rbgValue = 0.5f;

    public void Start()
    {
        PlayerPrefs.GetFloat("set volume", 0);
        PlayerPrefs.GetFloat("set sfx", 0);
        PlayerPrefs.GetInt("set qual", 0);
        sliderpos = new Rect(BrightnessSlider.transform.position.x, BrightnessSlider.transform.position.y, 160f, 20f);
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
        PlayerPrefs.SetFloat("set sfx", sfx);
        PlayerPrefs.Save();
    }

    public void SetQuality(int qualIndex)
    {
        QualitySettings.SetQualityLevel(qualIndex);
        PlayerPrefs.SetInt("set qual", qualIndex);
        PlayerPrefs.Save();
    }

    //public void OnGUI()
    //{
    //    rbgValue = GUI.HorizontalSlider(sliderpos, rbgValue, 0f, 1.0f);
    //}

    ////public void SetBrightness()
    ////{
    ////    rbgValue = BrightnessSlider.value;
    ////}

    //public void Update()
    //{
    //    RenderSettings.ambientLight = new Color(rbgValue, rbgValue, rbgValue, 1);
    //}
}
