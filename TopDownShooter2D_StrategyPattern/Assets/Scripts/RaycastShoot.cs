using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : Weapon, IWeapon
{
    private Transform firePoint;
    private LineRenderer line;

    private void Start()
    {
        firePoint = GetComponentInChildren<Transform>().GetChild(0);
        line = GetComponentInChildren<LineRenderer>();
        damage = 40;
    }

    public void Shoot()
    {
        StartCoroutine(ShootRaycast());
    }


    IEnumerator ShootRaycast()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);

        if (hitInfo)
        {
            if (hitInfo.transform.gameObject.CompareTag("Enemy"))
            {
                hitInfo.transform.gameObject.GetComponent<EnemyMobility>().TakeDamage(damage);
                Instantiate(explosion, hitInfo.point, Quaternion.identity);

                line.SetPosition(0, firePoint.position);
                line.SetPosition(1, hitInfo.point);
            }
        }
        else
        {
            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, firePoint.position + firePoint.up * 100);
        }
        line.enabled = true;
        yield return new WaitForSeconds(0.02f);
        line.enabled = false;
    }
}