﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Modal modal;
    public string userName;
    public bool isModalPositive;
    void Start()
    {
        
    }
    public static void clearWater()
    {
        Transform shoalCopies = GameObject.Find("Canvas/Shoals/ShoalCopies").transform;
        foreach (Transform shoal in shoalCopies)
        {
            GameObject.Destroy(shoal.gameObject);
        }
    }
}
