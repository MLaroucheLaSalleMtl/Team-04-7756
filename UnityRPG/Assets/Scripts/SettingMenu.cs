using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour {

    public string difficulties/* = "Easy"*/;
    [SerializeField] private AudioMixer audioM;
    [SerializeField] private AudioMixer audioS;
    [SerializeField] private Slider audioslider;
    [SerializeField] private Slider sfxslider;
    [SerializeField] private Dropdown diffDropdown;

    public void Start()
    {
        PlayerPrefs.GetFloat("set volume", 0);
        PlayerPrefs.GetFloat("set sfx", 0);
        PlayerPrefs.GetInt("set qual", 0);
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

    public void SetDifficulties(string diff)
    {
        if(diffDropdown.value == 1)
        {
            diff = "Easy";
        }
        if (diffDropdown.value == 2)
        {
            diff = "Medium";
        }
        if (diffDropdown.value == 3)
        {
            diff = "Hard";
        }
        this.difficulties = diff;
    }
}
