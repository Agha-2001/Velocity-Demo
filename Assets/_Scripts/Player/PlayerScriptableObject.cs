using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Scriptable Objects/Player")]
public class PlayerScriptableObject : ScriptableObject
{
    public float playerHealth;
    public float playerSpeed;
    public GameObject playerPrefab;
}
