using System.Collections;
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

    void Update()
    {
        modalControl();
        
    }

    private void modalControl()
    {
        modal.setMessage( isModalPositive);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            modal.showModal();

        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) //left mouse button
        {
            modal.hideModal();

        }
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
