using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject explosion;
    [SerializeField] protected sbyte damage;

    public sbyte getDamage() { return damage; }
    
}
