using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoalDrag : MonoBehaviour
{


    public GameObject prefab;
    public Vector3 newposition;
    int index = 0;
    public GameObject obj;

    Vector3 mousePos;
    public void BeginDrag()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 2.0f;
        newposition = Camera.main.ScreenToWorldPoint(mousePos);
        obj = Instantiate(prefab, newposition, Quaternion.identity);
        obj.transform.SetParent(null);
        obj.name = this.name +"_"+ index.ToString();
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
