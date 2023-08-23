using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitcher : MonoBehaviour
{
    LevelManager levelManager;
    public void ChangeLevel(string name)
    {
        levelManager = LevelManager.GetInstance();
        levelManager.LoadScene(name);
    }
}
