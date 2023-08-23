using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HighScore : MonoBehaviour
{
    string highScore = "HighScore";
    int defaultValue = -1;

    TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    public void CheckHighScore()
    {
        if (PlayerPrefs.GetInt(highScore, defaultValue) == defaultValue)
        {
            PlayerPrefs.SetInt(highScore, ScoreManager.GetInstance().GetScore());
        }

        else if (PlayerPrefs.GetInt(highScore, defaultValue) != defaultValue)
        {
            if (PlayerPrefs.GetInt(highScore) >= ScoreManager.GetInstance().GetScore())
                return;

            PlayerPrefs.SetInt(highScore, ScoreManager.GetInstance().GetScore());
        }
    }

    private void Update()
    {
        CheckHighScore();
        textMeshPro.text = PlayerPrefs.GetInt(highScore).ToString();
    }
}
