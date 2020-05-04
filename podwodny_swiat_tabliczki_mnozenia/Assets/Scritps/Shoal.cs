using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoal : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 newposition;
    public GameObject obj;
    int index = 0;
    Vector3 mousePos;
    
    public void BeginDrag()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 2.0f;
        newposition = Camera.main.ScreenToWorldPoint(mousePos);
        obj = Instantiate(prefab, newposition, Quaternion.identity);
        obj.name = this.name +"_"+ index.ToString();
        obj.transform.parent = GameObject.Find("Canvas/Shoals/ShoalCopies").transform;
        index++;
    }

    public void OnMouseDrag()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 2.0f;
        newposition = Camera.main.ScreenToWorldPoint(mousePos);
        obj.transform.position = newposition;
    }
}
