using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ResetButton : MonoBehaviour
{
    [SerializeField] float sensValue = 10f;
    [SerializeField] float volValue = 0.5f;
    public void OnButtonClicked()
    {
        PlayerPrefs.SetFloat("SensitivityValue", sensValue);
        PlayerPrefs.SetFloat("VolumeValue", volValue);
    }
}
