using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script : MonoBehaviour
{
    int x;
    int y;
    string rownanie;
    public Text napisRownanie;
    public InputField odpowiedz;
    public Text blad;
    // Start is called before the first frame update
    void Start()
    {
        blad.text = "";
        LosujRownanie();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            sprawdzOdpowiedz();
        }
    }
    public void LosujRownanie()
    {
        x = Random.Range(2, 11);
        y = Random.Range(2, 11);
        rownanie = x.ToString() + " * " + y.ToString() + "=";
        napisRownanie.text = rownanie;
    }
    public void sprawdzOdpowiedz()
    {
        if (odpowiedz.text == (x * y).ToString())
        {
            blad.text = "Bardzo dobrze następne równanie";
            LosujRownanie();

        }
        else
        {
            blad.text = "spróbuj jeszcze raz";
        }
    }
}
