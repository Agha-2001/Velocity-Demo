using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreText : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = ScoreManager.GetInstance().GetScore().ToString();
    }
}
