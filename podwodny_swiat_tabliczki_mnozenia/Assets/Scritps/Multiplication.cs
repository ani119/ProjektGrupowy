using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Multiplication : MonoBehaviour
{
    public Text showEquation;
    public InputField answer;
    public RatingModal ratingModal;

    private int multiplicand;
    private int multiplier;
    private string equation;

    public int totalEquations = 0;
    public int totalAnswerTries = 0;


    GameController GameController;
    Modal modal;
    void Awake()
    {
        RandomEquation();
        GameController = FindObjectOfType<GameController>();
        modal = FindObjectOfType<Modal>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !modal.modalIsShowed)
        {
            CheckAnswer();
            if (totalEquations > 0 && totalAnswerTries % 10 == 0)
            {
                Debug.Log("test");
                ratingModal.ShowRating(totalAnswerTries, totalEquations);
            }
            else
            {
                modal.setMessage(Player.name, GameController.isModalPositive);
                modal.showModal();
            }


        }
    }
    public void RandomEquation()
    {
        multiplicand = Random.Range(0, 11);
        multiplier = Random.Range(0, 11);
        equation = multiplicand.ToString() + " * " + multiplier.ToString() + "=";
        showEquation.text = equation;
        totalEquations++;
    }
    public void CheckAnswer()
    {
        totalAnswerTries++;
        Debug.Log("Total aswers: " + totalAnswerTries + " / " + totalEquations);

        if (answer.text == (multiplicand * multiplier).ToString())
        {
            GameController.isModalPositive = true;
            GameController.clearWater();

        }
        else
        {
            GameController.isModalPositive = false;
        }
    }
}
