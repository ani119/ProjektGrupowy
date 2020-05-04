using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetPlayerName : MonoBehaviour
{
    public GameObject inputField; 

    public void Button_Click()
    {
        Globals.playerName = inputField.GetComponent<Text>().text;
        Debug.Log( "Witaj " + Globals.playerName + " w podwodnym świecie tabliczki mnożenia!");
        SceneManager.LoadScene("Menu");
    }
}