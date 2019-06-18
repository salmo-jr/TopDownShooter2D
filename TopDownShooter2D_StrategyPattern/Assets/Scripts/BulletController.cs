using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private sbyte damage;
    //[SerializeField] private GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyMobility>().TakeDamage(damage);
            Destroy(gameObject);
            GameObject explosion = Instantiate(Resources.Load("Explosion", typeof(GameObject))) as GameObject;
            explosion.transform.position = transform.position;
            explosion.transform.rotation = transform.rotation;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
