using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Invoke("Die", Mathf.CeilToInt(anim.GetCurrentAnimatorStateInfo(0).length));
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
