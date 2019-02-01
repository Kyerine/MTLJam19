using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public GameObject bowl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Object[] allObjects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject obj in allObjects)
        {
            if (obj.transform.name == "Salt(Clone)" || obj.transform.name == "Sugar(Clone)" || obj.transform.name == "Flour(Clone)")
            {
                bowl.GetComponent<Bowl>().resetNumSalt();
                bowl.GetComponent<Bowl>().resetNumSugar();
                bowl.GetComponent<Bowl>().resetNumFlour();
                bowl.GetComponent<Bowl>().addedIngredients = 0;
                if (obj != null)
                {
                    Destroy(obj);
                }
                Debug.Log(obj.transform.name + " object deleted");
            }
        }
    }
}
