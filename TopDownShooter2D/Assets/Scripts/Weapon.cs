using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject explosion;
    
    [SerializeField] private sbyte damage;
    private LineRenderer line;

    //public GameObject bullet;

    private void Start()
    {
        line = GetComponentInChildren<LineRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            StartCoroutine(Shoot());
    }

    /*
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
    */

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);

        if (hitInfo)
        {
            if (hitInfo.transform.gameObject.CompareTag("Enemy")) {
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
