using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    public bool bowlSelected = false;
    public Transform[] spawnPoints;
    public int addedIngredients;
    public GameObject secretfood;
    public GameObject badfood;
    private GameObject[] ingredients;
    private int numSalt;
    private int numSugar;
    private int numFlour;

    // Start is called before the first frame update
    void Start()
    {
        numSalt = 0;
        numSugar = 0;
        numFlour = 0;
        addedIngredients = 0;
        if (ingredients == null)
            ingredients = GameObject.FindGameObjectsWithTag("Ingredient");
    }

    // Update is called once per frame
    void Update()
    {
        if (addedIngredients == 7 && bowlSelected == true)
        {
            if (numSalt == 3 && numFlour == 2 && numSugar == 2)
            {
                Debug.Log("SECRET RECIPE FOUND");
                Instantiate(secretfood, spawnPoints[7].transform.position, Quaternion.Euler(90, 0, 0));
                bowlSelected = false;
                StartCoroutine(RecipeFound());
            }

            else
            {
                Debug.Log("YOU CREATED RUBBISH");
                Instantiate(badfood, spawnPoints[7].transform.position, Quaternion.Euler(90, 0, 0));
                bowlSelected = false;
                StartCoroutine(BadRecipeFound());
            }
            resetBowl();
        }
    }

    void OnMouseDown()
    {
        bowlSelected = true;

        foreach (GameObject ingredient in ingredients)
        {
            if (ingredient.GetComponent<Ingredient>().getSelected() == true && addedIngredients < 7) {
                Debug.Log("addedIngredients: " + addedIngredients);
                Transform clone = Instantiate(ingredient.GetComponent<Ingredient>().ingredientPrefab, spawnPoints[addedIngredients].transform.position, Quaternion.identity);
                clone.rotation *= Quaternion.Euler(90, 0, 0);
                Debug.Log(ingredient.name + " added");
                addedIngredients++;
                if (ingredient.name == "Salt")
                {
                    numSalt++;
                }
                else if (ingredient.name == "Sugar")
                {
                    numSugar++;
                }
                else
                {
                    numFlour++;
                }
            }
        }
    }

    IEnumerator RecipeFound()
    {
        yield return new WaitForSeconds(1);
        Destroy(GameObject.FindGameObjectWithTag("SecretFood"));
        Destroy(GameObject.Find("Table").GetComponent("Zoomable"));
        GameObject.Find("ForestGuy").GetComponent<Animator>().SetBool("happy", true);
    }

    IEnumerator BadRecipeFound()
    {
        yield return new WaitForSeconds(1);
        Destroy(GameObject.FindGameObjectWithTag("SecretFood"));
    }

    void resetBowl() {

        numSalt = 0;
        numSugar = 0;
        numFlour = 0;
        addedIngredients = 0;
        Debug.Log("Bowl Reset : " + numSalt + " " + numSugar + " " + numFlour + " " + addedIngredients);

        Object[] allObjects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject obj in allObjects)
        {
            if (obj != null && obj.transform.name == "Salt(Clone)" || obj.transform.name == "Sugar(Clone)" || obj.transform.name == "Flour(Clone)")
            {
                Destroy(obj);
            }
        }
    }

    public int getNumSalt()
    {
        return this.numSalt;
    }

    public int getNumSugar()
    {
        return this.numSugar;
    }

    public int getNumFlour()
    {
        return this.numFlour;
    }

    public void resetNumSalt()
    {
        this.numSalt = 0;
    }

    public void resetNumSugar()
    {
        this.numSugar = 0;
    }
    public void resetNumFlour()
    {
        this.numFlour = 0;
    }
}
