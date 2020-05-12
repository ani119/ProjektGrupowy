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
    bool IsWaitingForAnswert = true;
    public void HideModal()
    {
        modal.hideModal();
        IsWaitingForAnswert = true;
    }
    private void modalControl()
    {
        modal.setMessage(Player.name, isModalPositive);
        if (IsWaitingForAnswert)
            if (Input.GetKeyDown(KeyCode.Return))
            {
                modal.showModal();
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
