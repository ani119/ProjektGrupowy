using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoalController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fishPrefab;
    public int fishAmount=1;
    public float fishGap=1;
    void generateShoal()
    {
        Quaternion q = new Quaternion();
        q.Set(0.0f, 1.0f, 0.0f, 0.0f);
        for (int i=0;i<fishAmount;i++)
        {
            GameObject textObject = (GameObject)Instantiate(fishPrefab, 
                new Vector3(0, i*fishGap, 0), q);
        }
    }
    void Start()
    {
        generateShoal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
