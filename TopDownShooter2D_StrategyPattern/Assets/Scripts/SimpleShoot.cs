using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : Weapon, IWeapon
{
    [SerializeField] private GameObject bullet;
    private Transform firePoint;

    private void Start()
    {
        firePoint = GetComponentInChildren<Transform>().GetChild(0);
        damage = 30;
    }
    
    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
