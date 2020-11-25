using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtonHandler : MonoBehaviour
{

    public void FishClick()
    {
        GameController.sceneName = "FishGame";
        SceneManager.LoadScene("FishGame");
        Debug.Log("Rybki, rybeczki, rybunie...");
    }

    public void NumbersClick()
    {
        SceneManager.LoadScene("LevelsMenu");
        Debug.Log("Cyferki.");
    }

    public void BlanksClick()
    {
        GameController.sceneName = "BlanksGame";
        SceneManager.LoadScene("BlanksGame");
        Debug.Log("Luki.");
    }
    public void SignsClick()
    {
        GameController.sceneName = "SignsGame";
        SceneManager.LoadScene("SignsGame");
        Debug.Log("Znaki");
    }
    public void TestClick()
    {
        GameController.sceneName = "TestGame";
        SceneManager.LoadScene("NumbersGame");
        Debug.Log("Test.");
    }

    public void Level1Click()
    {
        GameController.sceneName = "Level1";
        SceneManager.LoadScene("NumbersGame");
    }

    public void Level2Click()
    {
        GameController.sceneName = "Level2";
        SceneManager.LoadScene("NumbersGame");
    }
    public void Level3Click()
    {
        GameController.sceneName = "Level3";
        SceneManager.LoadScene("NumbersGame");
    }
}
