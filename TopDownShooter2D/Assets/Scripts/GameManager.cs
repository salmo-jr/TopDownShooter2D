﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            if (instance != this) Destroy(this);
        }
    }

    public Vector3 GetPlayerPosition()
    {
        return player.transform.position;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
