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


    private System.DateTime StartTime;

    GameController GameController;
    //Modal modal;

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        this.StartTime = System.DateTime.Now;
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Awake()
    {
        SetRange();
        RandomEquation();
        GameController = FindObjectOfType<GameController>();
        //modal = FindObjectOfType<Modal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !modal.modalIsShowed && answer.text!="")
        {
            CheckAnswer();

            int equationsModulo = 10;

            if (SceneManager.GetActiveScene().name == "TestGame")
            {
                equationsModulo = 20;
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
            int result = Random.Range(min, max + 1);
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
        Debug.Log("Total answers: " + totalAnswerTries + " / " + totalEquations);
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
