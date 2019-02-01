using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public GameObject bowl;
    private bool selected;
    private GameObject[] ingredients;
    public Transform ingredientPrefab;

    void Start()
    {
        selected = false;
        ingredients = GameObject.FindGameObjectsWithTag("Ingredient");
    }
    void Update()
    {

    }
    void OnMouseDown()
    {
        foreach (GameObject ingredient in ingredients)
        {
            ingredient.GetComponent<Ingredient>().setSelected(false);
            ingredient.GetComponent<SpriteRenderer>().color = Color.red;
        }
        bowl.GetComponent<Bowl>().bowlSelected = false;
        this.selected = true;
        this.GetComponent<SpriteRenderer>().color = Color.green;
        Debug.Log("Ingredient Clicked");
    }

    public bool getSelected() {
        return selected;
    }

    public void setSelected(bool selectedStatus) {
        this.selected = selectedStatus;
    }
}
