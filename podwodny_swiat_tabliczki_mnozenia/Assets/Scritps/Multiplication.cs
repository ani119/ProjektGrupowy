using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Multiplication : MonoBehaviour
{
    public Text showEquation;
    public InputField answer;
    public RatingModal ratingModal;
    public int totalEquations = 0;
    public int totalAnswerTries = 0;
    private int multiplicand;
    private int multiplier;
    private string equation;

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
        if (Input.GetKeyDown(KeyCode.Return) && !modal.modalIsShowed && answer.text!="")
        {
            CheckAnswer();
            if (totalEquations > 0 && totalEquations % 10 == 0 && GameController.isModalPositive == true)
            {
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
        equation = multiplicand.ToString() + " x " + multiplier.ToString() + " = ";
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
            if(SceneManager.GetActiveScene().name=="FishGame")
            {
                GameController.clearWater();
            }
        }
        else
        {
            GameController.isModalPositive = false;
        }
    }
}
