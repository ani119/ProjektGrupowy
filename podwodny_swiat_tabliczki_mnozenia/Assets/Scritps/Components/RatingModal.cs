using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RatingModal : MonoBehaviour
{
    public Text text;
    public Button closeButton;

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

    public void ShowRating(int tries, int total)
    {
        this.tries = tries;
        this.total = total;

        string s = CalculateAccuracy() + "%";
        text.text = s;

        this.gameObject.SetActive(true);
    }

    public void HideModal()
    {
        this.gameObject.SetActive(false);
    }
}
