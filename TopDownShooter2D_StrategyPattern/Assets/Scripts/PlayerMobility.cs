using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour
{
    public float speed;

    private float moveForward;
    private Vector3 mouseposition;
    private Quaternion rot;
    private Rigidbody2D rb2;

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rot = Quaternion.LookRotation(transform.position - mouseposition, Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        moveForward = Input.GetAxis("Vertical");
        rb2.AddForce(gameObject.transform.up * moveForward * speed);
    }
}
