using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Modal : MonoBehaviour
{
    public bool modalIsShowed;
    public InputField answer;
    Multiplication multiplication;
    bool IsPositive = false;

    void Awake()
    {
        hideModal();
        setBackgroundColor();
        multiplication = FindObjectOfType<Multiplication>();
    }
    
    public void setMessage(string playerName, bool isPositive)
    {
        setBackgroundColor();
        setModalTextContent(playerName, isPositive);
        setModalTextColor(isPositive);
        IsPositive = isPositive;
    }

    public void showModal()
    {
        this.gameObject.SetActive(true);
        modalIsShowed = true;
    }

    public void hideModal()
    {
        answer.text = "";
        this.gameObject.SetActive(false);
        modalIsShowed = false;
        if (multiplication == null)
            multiplication = FindObjectOfType<Multiplication>();
        if (IsPositive)
            multiplication.RandomEquation();
    }

    private void setModalTextContent(string userName, bool isPositive)
    {
        if (isPositive)
        {
            GetComponentInChildren<Text>().text = "GRATULACJE " + userName?.ToUpper() + " !";
        }
        else GetComponentInChildren<Text>().text = userName?.ToUpper()+" SPRÓBUJ PONOWNIE"; 
    }

    private void setModalTextColor(bool isPositive)
    {
        if (isPositive) GetComponentInChildren<Text>().color = new Color(0.1f, 0.5f, 0.0f, 1.0f); 
        else GetComponentInChildren<Text>().color = Color.red;
    }

    private void setBackgroundColor()
    {
        GetComponentInChildren<Image>().color=new Color(0.5f, 0.5f, 0.5f, 0.3f);
        GetComponentInChildren<Image>().rectTransform.sizeDelta = new Vector2(360, 150);
    }
    public void startMessage(string message)
    {
        GetComponentInChildren<Image>().color = new Color(0.7f, 0.7f, 1f, 0.9f);
        GetComponentInChildren<Text>().text = message;
        GetComponentInChildren<Image>().rectTransform.sizeDelta = new Vector2(420, 150);
    }
}
