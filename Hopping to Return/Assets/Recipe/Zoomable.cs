using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomable : MonoBehaviour
{
    public float CameraX;
    public float CameraY;

    void OnMouseDown()
    {
        Debug.Log("Zoomable Clicked");
        StartCoroutine(MoveCamera(CameraX, CameraY));
    }

    IEnumerator MoveCamera(float x, float y)
    {
        Camera.main.transform.Translate(x, y, 0);
        yield return new WaitForSeconds(1f);
    }
}

