using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Modal modal;
    public string userName;
    public bool isModalPositive;
    public static string sceneName;

    void Update()
    {
      
    }

    public static void clearWater()
    {
        if(GameObject.Find("Canvas/Shoals/ShoalCopies"))
        {
        Transform shoalCopies = GameObject.Find("Canvas/Shoals/ShoalCopies").transform;
        foreach (Transform shoal in shoalCopies)
        {
            GameObject.Destroy(shoal.gameObject);
        }
        }
    }

}
