using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Modal modal;
    public string userName;
    public bool isModalPositive;
    bool isWaitingForAnswer = true;
    void Start()
    {
        
    }
    void Update()
    {
        ModalControl();
    }
   
    public void HideModal()
    {
        modal.hideModal();
        isWaitingForAnswer = true;
    }
    private void ModalControl()
    {
        modal.setMessage(Player.name, isModalPositive);
        if (Input.GetKeyDown(KeyCode.Return) && isWaitingForAnswer) 
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
