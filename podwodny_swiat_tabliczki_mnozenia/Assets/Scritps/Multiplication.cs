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
    private int min=0,max=10;

    GameController GameController;
    Modal modal;

    void Awake()
    {
        SetRange();
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
        multiplicand = Random.Range(min, max+1);
        multiplier = Random.Range(min, max+1);
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

    private void SetRange()
    {
        if(GameController.sceneName=="Level1")
        {
            max = 3;
        }
        else if (GameController.sceneName=="Level2")
        {
            min = 4;
            max = 7;
        }
        else if (GameController.sceneName=="Level3")
        {
            min = 8;
            max = 10;
        }
    }
}
