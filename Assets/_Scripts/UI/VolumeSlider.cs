using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    Slider slider;

    string volume = "VolumeValue";

    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        LoadValues();
    }

    public void SetVolume(float volume = 1.0f)
    {
        textMeshProUGUI.text = volume.ToString("0.0");
        SaveVolume();
    }

    public void SaveVolume()
    {
        float sliderValue = slider.value;
        PlayerPrefs.SetFloat(volume, sliderValue);
        LoadValues();
    }

    public void LoadValues()
    {
        float volValue = PlayerPrefs.GetFloat(volume);
        slider.value = volValue;
        AudioListener.volume = volValue;
    }
}
