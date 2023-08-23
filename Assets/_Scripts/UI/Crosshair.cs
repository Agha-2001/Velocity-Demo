using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameEventListener))]
public class Crosshair : MonoBehaviour
{
    private RectTransform crosshair;
    [SerializeField] float MaxSize;
    [SerializeField] float MinSize;
    [SerializeField] float ChangeSpeed;
    [SerializeField] Color IntialColor;
    [SerializeField] Color TargetColor;
    private List<Image> lines;
    private float CurrentSize;
    public bool Target;
    public void IsTarget() => Target = true;
    public void NotTarget() => Target = false;
    // Start is called before the first frame update
    void Start()
    {
        crosshair = GetComponent<RectTransform>();
        lines = new List<Image>(GetComponentsInChildren<Image>());
        SetColor(IntialColor);
    }

    // Update is called once per frame
    void Update()
    {
        if(Target)
        {
            CurrentSize = Mathf.Lerp(CurrentSize, MaxSize, Time.deltaTime * ChangeSpeed);
            SetColor(TargetColor);
        }
        else if(!Target)
        {
            CurrentSize = Mathf.Lerp(CurrentSize, MinSize, Time.deltaTime * ChangeSpeed);
            SetColor(IntialColor);
        }

        crosshair.sizeDelta = new Vector2(CurrentSize,CurrentSize);
    }

    void SetColor(Color c)
    {
        foreach(Image image in lines)
        {
            Color newColor = new Color(c.r, c.g, c.b, image.color.a);
            image.color = newColor;
        }
    }
}
