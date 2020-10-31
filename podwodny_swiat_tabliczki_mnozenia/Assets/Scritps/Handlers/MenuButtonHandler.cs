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
        SceneManager.LoadScene("LevelsMenu");
        Debug.Log("Cyferki.");
    }

    public void Level1Click()
    {
        SceneManager.LoadScene("NumbersGame");
    }

    public void Level2Click()
    {
        SceneManager.LoadScene("NumbersGame");
    }
    public void Level3Click()
    {
        SceneManager.LoadScene("NumbersGame");
    }
}
