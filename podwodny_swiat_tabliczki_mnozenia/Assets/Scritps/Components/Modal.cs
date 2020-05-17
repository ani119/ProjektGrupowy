using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modal : MonoBehaviour
{
    public bool modalIsShowed;
    public InputField answer;
    Multiplication multiplication;
    void Awake()
    {
        hideModal();
        setBackgroundColor();
    }

    public void setMessage(string playerName, bool isPositive)
    {
        setModalTextContent(playerName, isPositive);
        setModalTextColor(isPositive);
    }
    public void showModal()
    {
        this.gameObject.SetActive(true);

    }
    public void hideModal()
    {
        this.gameObject.SetActive(false);
    }

    private void setModalTextContent(string userName, bool isPositive)
    {
        if (isPositive)
        {
            GetComponentInChildren<Text>().text = "GRATULACJE " + userName.ToUpper() + " !";
        }
        else GetComponentInChildren<Text>().text = userName.ToUpper()+", SPRÓBUJ PONOWNIE"; 
    }

    private void setModalTextColor(bool isPositive)
    {
        if (isPositive) GetComponentInChildren<Text>().color = new Color(0.1f, 0.5f, 0.0f, 1.0f); 
        else GetComponentInChildren<Text>().color = Color.red;
    }

    private void setBackgroundColor()
    {
        GetComponentInChildren<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        hideModal();
        answer.text = "";
    }

}
