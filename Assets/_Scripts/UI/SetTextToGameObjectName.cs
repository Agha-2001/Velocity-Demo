using UnityEngine;
using TMPro;

public class SetTextToGameObjectName : MonoBehaviour
{
    private TextMeshProUGUI textMeshProText;

    void Start()
    {
        // Get the TextMeshProUGUI component attached to the same GameObject
        textMeshProText = GetComponent<TextMeshProUGUI>();

        // Set the text of the TextMeshPro text to be the name of the GameObject
        textMeshProText.text = gameObject.name;
    }
}
