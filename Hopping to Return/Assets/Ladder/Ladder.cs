using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour, ObjectInterface
{
    private GameObject player;
    public GameObject topLoc;
    public GameObject botLoc;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Work()
    {
        if(transform.position.y > player.transform.position.y)
        {
            StartCoroutine(GoUp());
        }
        else
        {
            StartCoroutine(GoDown());
        }
    }

    public void ApplyItem(GameObject item)
    {
        Debug.Log("Ladders dont like items... thanks but no thanks " + item.name);
    }

    IEnumerator GoUp()
    {
        int i = 5;
        player.GetComponent<Movement>().setLoc(new Vector2(botLoc.transform.position.x,player.transform.position.y));
        while(Vector2.Distance(botLoc.transform.position, player.transform.position)> 0.1)
        {
            yield return new WaitForSeconds(0.5f);
            if (i == 0)
            {
                yield break;
            }
            else
                i--;
            
        }
       player.GetComponent<Movement>().setLoc(topLoc.transform.position);

    }

    IEnumerator GoDown()
    {
        int i = 5;
        player.GetComponent<Movement>().setLoc(new Vector2(topLoc.transform.position.x, player.transform.position.y));
        while (Vector2.Distance(topLoc.transform.position, player.transform.position) > 0.1)
        {
            yield return new WaitForSeconds(0.5f);
            if (i == 0)
            {
                yield break;
            }
            else
                i--;
        }
        player.GetComponent<Movement>().setLoc(botLoc.transform.position);

    }

}
