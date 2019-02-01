using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, ObjectInterface
{
    public GameObject man;

    public void Work()
    {
        man.GetComponent<ItemManager>().pickUp(gameObject);
        this.gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    public void ApplyItem(GameObject i)
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        // man = GameObject.FindWithTag("GameController").GetComponent<ItemManager>();
    }


}
