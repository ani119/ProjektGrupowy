using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Multiplication : MonoBehaviour
{
    public Text showEquation;
    public InputField answer;
    public Text error;
    private int multiplicand ;
    private int multiplier;
    private string equation;
    // Start is called before the first frame update
    void Start()
    {
        error.text = "";
        RandomEquation();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        { 
            CheckAnswer();
        }
    }
    public void RandomEquation()
    {
        multiplicand = Random.Range(1, 11);
        multiplier = Random.Range(1, 11);
        equation = multiplicand.ToString() + " * " + multiplier.ToString() + "=";
        showEquation.text = equation;
    }
    public void CheckAnswer()
    {
        if (answer.text == (multiplicand * multiplier).ToString())
        {
            error.text = "Bardzo dobrze! Następne równanie.";
            RandomEquation();
        }
        else
        {
            error.text = "Zła odpowiedź. Spróbuj jeszcze raz!";
        }
    }
}
