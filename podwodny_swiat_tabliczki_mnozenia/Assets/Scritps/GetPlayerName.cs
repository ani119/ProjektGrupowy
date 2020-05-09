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
        Player.name = inputField.GetComponent<Text>().text;
        Debug.Log( "Witaj " + Player.name + " w podwodnym świecie tabliczki mnożenia!");
        SceneManager.LoadScene("Menu");
    }
}