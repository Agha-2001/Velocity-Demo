using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GunShoot : MonoBehaviour
{
    [SerializeField] private Transform GunParent;
    [SerializeField] private GunObject Gun;
    [SerializeField] private GameEvent shoot;

    private void Start()
    {
        Gun.Spawn(GunParent, this);
    }

    private void Update()
    {
        Gun.TargetCheck();
    }

    public void OnClickShoot()
    {
        Gun.Shoot();
        shoot.Invoke();
        
    }
}
