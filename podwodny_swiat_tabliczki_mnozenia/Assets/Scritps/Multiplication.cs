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
    public Modal modal;
    public int totalEquations = 0;
    public int totalAnswerTries = 0;
    private int multiplicand;
    private int multiplier;
    private string equation;
    private int min=0,max=10;
    private string sign;
    private string message;
    private System.DateTime StartTime;

    GameController GameController;
    private void Start()
    {
        if (GameController.sceneName == "FishGame")
        {
            message = "Wpisz wynik rownania. Jako pomoc wykorzystaj rybki na dole ekranu. Przesuwaj je i usuwaj do woli.";
        }
        else if (GameController.sceneName == "Level1" || GameController.sceneName == "Level2" || GameController.sceneName == "Level3" || GameController.sceneName == "TestGame")
        {
            message = " Wpisz poprawny wynik równania ";
        }
        else if (GameController.sceneName == "BlanksGame")
        {
            message = " Wpisz brakującą cyfrę, tak aby równanie było poprawne ";
        }
        else if (GameController.sceneName == "SignsGame")
        {
            message = " Wpisz odpowiedni znak < lub = lub >, tak aby równanie było poprawne ";
        }
        modal.startMessage(message);
        modal.showModal();

        GameController = FindObjectOfType<GameController>();

        this.StartTime = System.DateTime.Now;
        SetRange();
        RandomEquation();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !modal.modalIsShowed && answer.text != "")
        {
            CheckAnswer();

            int equationsModulo = 10;

            if (SceneManager.GetActiveScene().name == "TestGame")
            {
                equationsModulo = 2;
            }

            if (totalEquations > 0 && totalEquations % equationsModulo == 0 && !modal.modalIsShowed && GameController.isModalPositive == true)
            {


                if (SceneManager.GetActiveScene().name == "TestGame")
                {
                    System.TimeSpan time = System.DateTime.Now - this.StartTime;
                    ratingModal.ShowRating(totalAnswerTries, totalEquations, time);
                }
                else
                {
                    ratingModal.ShowRating(totalAnswerTries, totalEquations);
                }
                RandomEquation();
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
        if(GameController.sceneName == "BlanksGame")
        {
            int result = multiplicand * multiplier;
            equation = multiplicand.ToString() + " x       = " + result.ToString();
        }
        else if (GameController.sceneName == "SignsGame")
        {
            int result = Random.Range(min, 100 + 1);
            equation = multiplicand.ToString() + " x " + multiplier.ToString() + "         " + result.ToString();
            if (multiplicand * multiplier < result)
            {
                sign = "<";

            }
            else if (multiplicand * multiplier > result)
            {
                sign = ">";
            }
            else if (multiplicand * multiplier == result)
            {
                sign = "=";
            }
        }
        showEquation.text = equation;
        totalEquations++;
    }
    
    public void CheckAnswer()
    {
        totalAnswerTries++;
        Debug.Log("Total aswers: " + totalAnswerTries + " / " + totalEquations);
        if (GameController.sceneName == "BlanksGame")
        {
            if ((answer.text ==  multiplier.ToString()) || multiplicand == 0)
            {
                GameController.isModalPositive = true;
                if (SceneManager.GetActiveScene().name == "BlanksGame")
                {
                    GameController.clearWater();
                }
            }
            else
            {
                GameController.isModalPositive = false;
            }
        }
        else if (GameController.sceneName == "SignsGame")
        {
            if (answer.text == sign)
            {
                GameController.isModalPositive = true;
                if (SceneManager.GetActiveScene().name == "SignsGame")
                {
                    GameController.clearWater();
                }
            }
            else
            {
                GameController.isModalPositive = false;
            }

        }
        else if (answer.text == (multiplicand * multiplier).ToString())
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
