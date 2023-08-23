using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [System.Serializable]
    public enum ButtonType
    {
        Pause,
        Resume,
    }

    Button menuButton;
    [SerializeField] ButtonType type;

    [HideInInspector] public static bool isPaused;
    private void Start()
    {
        isPaused = false;

        menuButton = GetComponent<Button>();

        if (type == ButtonType.Pause)
        {
            menuButton.onClick.AddListener(PauseGame);
        }

        else if (type == ButtonType.Resume)
        {
            menuButton.onClick.AddListener(ResumeGame);
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
}
