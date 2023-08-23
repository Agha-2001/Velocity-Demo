using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ResetButton : MonoBehaviour
{
    [SerializeField] float sensValue = 10f;
    public void OnButtonClicked()
    {
        PlayerPrefs.SetFloat("SensitivityValue", sensValue);
    }
}
