using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    public int speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speed * 1.0f, 0, 0);
    }
 
}
