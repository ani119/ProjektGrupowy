using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class RatingModal : MonoBehaviour
{
    public Text text;
    public Button closeButton;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public InputField answer;
    public bool ratingModalIsShowed;
    private int total = 0;
    private int tries = 0;

    // Use this for initialization
    void Start()
    {
        HideModal();
        Button btn = closeButton.GetComponent<Button>();
        btn.onClick.AddListener(HideModal);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int CalculateAccuracy()
    {
        double acc = (double)total / tries;
        return (int)(acc * 100);
    }

    public void ShowRating(int tries, int total, TimeSpan time)
    {
        this.ShowRating(tries, total);
        text.text += Environment.NewLine + " Czas testu: " + time.Minutes + ":" + time.Seconds + "s"
                   + Environment.NewLine + " Poprawne odpowiedzi: " + total
                   + Environment.NewLine + " Błędne odpowiedzi: " + (tries - total);        
    }

    public void ShowRating(int tries, int total)
    {
        ratingModalIsShowed = true;
        this.tries = tries;
        this.total = total;
        int accuracy = CalculateAccuracy();
        star1.gameObject.SetActive(true);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
        if (accuracy >= 50)
        {
            star2.gameObject.SetActive(true);
            text.text = "Idzie Ci coraz lepiej!";
            if (accuracy >= 80)
            {
                star3.gameObject.SetActive(true);
                text.text = "Super! Oby tak dalej!";
            }
        }
        else
        {
            text.text = "Próbuj dalej!";
        }
    }


    public void HideModal()
    {
        this.gameObject.SetActive(false);
        ratingModalIsShowed = false;
        answer.text = "";
    }
}
