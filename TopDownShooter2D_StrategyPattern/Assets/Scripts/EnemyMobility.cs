using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMobility : MonoBehaviour
{
    [SerializeField] private sbyte health;
    [SerializeField] private float speed;

    private Rigidbody2D rb2;
    private Vector3 zEulerAngles;
    

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        zEulerAngles = Vector3.zero;
    }
    private void FixedUpdate()
    {
        zEulerAngles.z = Mathf.Atan2(
            (GameManager.instance.GetPlayerPosition().y - transform.position.y),
            (GameManager.instance.GetPlayerPosition().x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = zEulerAngles;
        rb2.AddForce(gameObject.transform.up * speed);
    }

    

    public void TakeDamage(sbyte damage)
    {
        health -= damage;
        if (health <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
