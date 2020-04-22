using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{
    public void FishClick()
    {
        SceneManager.LoadScene("FishGame");
        Debug.Log("Rybki, rybeczki, rybunie...");
    }

    public void NumbersClick()
    {
        Debug.Log("Cyferki.");
    }
}
