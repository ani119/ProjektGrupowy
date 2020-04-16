using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {

	// Use this for initialization
	public void OnClick()
    {
        if(EventSystem.current.currentSelectedGameObject.name == "play_button")
        {
            Debug.Log("GRAJ");
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "exit_button")
        {
            Application.Quit();
        }
    }
}
