using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    private int counter = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 newPos = new Vector3(Mathf.Clamp(102.5f,mousePosition.x,143.5f), transform.position.y, Mathf.Clamp(55.5f, mousePosition.z, 84.55f));
        transform.position = newPos;

    }

    public void foundItem()
    {
        counter++;
    }

}
