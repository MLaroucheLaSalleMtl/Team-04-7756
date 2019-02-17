using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour {

    [SerializeField] private AudioMixer audioM;
    [SerializeField] private AudioMixer audioS;

    public void SetVol(float volume)
    {
        audioM.SetFloat("volume", volume);
    }

    public void SetSFX(float sfx)
    {
        audioS.SetFloat("sfx", sfx);
    }

    public void SetQuality(int qualIndex)
    {
        QualitySettings.SetQualityLevel(qualIndex);
    }
}
