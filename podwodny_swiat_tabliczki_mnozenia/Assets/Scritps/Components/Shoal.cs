using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoal : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 newposition;
    public GameObject obj;
    int index = 0;
    Vector3 mousePos;
    private static bool ifExist;

    private void Start()
    {
        obj = gameObject;
        newposition = transform.position;
        ifExist = true;
    }

    public void BeginDrag()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 2.0f;
        newposition = Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void BeginDragAndCopyShoal()
    {
        BeginDrag();
        CopyShoal();
    }

    public void OnMouseDrag()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 2.0f;
        newposition = mousePos;
        if (ifExist && obj == this.gameObject) obj.transform.rotation = Quaternion.identity;
        if (ifExist) obj.transform.position = newposition;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RecycleBin")
        {
            DeleteShoal();
        }
    }

    private void CopyShoal()
    {
        newposition = Camera.main.ScreenToWorldPoint(mousePos);
        obj = Instantiate(prefab, newposition, Quaternion.identity);
        obj.name = this.name + "_" + index.ToString();
        obj.transform.SetParent(  GameObject.Find("Canvas/Shoals/ShoalCopies").transform,false);
        index++;
    }

    private void DeleteShoal()
    {
        GameObject.Destroy(this.gameObject);
        ifExist = false;
    }
}
