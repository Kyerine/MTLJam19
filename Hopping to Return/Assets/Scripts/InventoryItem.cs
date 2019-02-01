using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryItem : MonoBehaviour, ObjectInterface
{
    public GameObject reference;

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void Work()
    {
        if (gameObject.tag == "EmptyInvItem")
        {

        }
        else if (gameObject.tag == "InvItem")
        {
              Debug.Log("Select the item");
              player.SetTriggerItem(reference);
        }
    }
    public void ApplyItem(GameObject item)
    {
        if (gameObject.tag == "EmptyInvItem")
        {
            reference = item;
            gameObject.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            gameObject.tag = "InvItem";
        }
        else if (gameObject.tag == "InvItem")
        {
            Debug.Log("THERES NO CRAFTING IN THIS WORLD");
        }
    }

}
