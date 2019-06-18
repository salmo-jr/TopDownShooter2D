using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : Weapon, IWeapon
{
    private float speed;
    private Transform firePoint;

    private void Start()
    {
        firePoint = GetComponentInChildren<Transform>().GetChild(0);
        damage = 30;
        speed = 10;
    }
    
    public void Shoot()
    {
        GameObject bullet = Instantiate(Resources.Load("Bullet", typeof(GameObject))) as GameObject;
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
}
