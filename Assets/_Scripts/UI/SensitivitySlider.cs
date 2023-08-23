using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SensitivitySlider : MonoBehaviour
{
    Slider slider;

    string sensitivity = "SensitivityValue";

    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        slider = GetComponent<Slider>();
        LoadValues();
    }

    public void SensitivitySet(float sensitivity)
    {
        textMeshProUGUI.text = sensitivity.ToString("0.0");
        SaveSensitivity();
    }

    public void SaveSensitivity()
    {
        float sliderValue = slider.value;
        PlayerPrefs.SetFloat(sensitivity, sliderValue);
        LoadValues();
    }

    public void LoadValues()
    {
        float sensValue = PlayerPrefs.GetFloat(sensitivity);
        slider.value = sensValue;
    }
}
