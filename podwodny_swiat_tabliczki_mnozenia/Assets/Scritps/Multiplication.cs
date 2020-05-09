using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Multiplication : MonoBehaviour
{
    public Text showEquation;
    public InputField answer;
    public Text error;
    public RatingModal ratingModal;

    private int multiplicand ;
    private int multiplier;
    private string equation;

    public int totalEquations = 0;
    public int totalAnswerTries = 0;

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

        if(totalEquations > 0 && totalEquations % 10 == 0)
        {
            ratingModal.ShowRating(totalAnswerTries, totalEquations);
        }

        totalEquations++;
    }
    public void CheckAnswer()
    {
        totalAnswerTries++;
        Debug.Log("Total aswers: " + totalAnswerTries + " / " + totalEquations);

        if (answer.text == (multiplicand * multiplier).ToString())
        {
            error.text = "Bardzo dobrze " + Player.name +" ! Następne równanie.";
            GameController.clearWater();
            RandomEquation();
        }
        else
        {
            error.text = "Zła odpowiedź. Spróbuj jeszcze raz!";
        }
    }
}
