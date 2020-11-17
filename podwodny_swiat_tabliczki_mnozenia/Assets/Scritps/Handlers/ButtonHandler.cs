using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {

	// Use this for initialization
	public void OnClick()
    {
        if(EventSystem.current.currentSelectedGameObject.name == "play_button")
        {
            Debug.Log("GRAJ");
            SceneManager.LoadScene("NameScene");
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "exit_button")
        {
            Application.Quit();
        }
        if (EventSystem.current.currentSelectedGameObject.name == "BackToMenu")
        {
            SceneManager.LoadScene("MainScene");
        }
        if (EventSystem.current.currentSelectedGameObject.name == "BackToRangeChoice")
        {
            SceneManager.LoadScene("LevelsMenu");
        }
    }
}


