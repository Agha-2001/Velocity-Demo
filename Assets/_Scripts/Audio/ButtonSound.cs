using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] string soundName;
    Button menuButton;
    private void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        AudioManager.GetInstance().Play(soundName);
    }
}
