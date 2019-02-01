using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGuy : MonoBehaviour
{
    public GameObject chatBubble;
    private bool talkedtoNPC;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        talkedtoNPC = false;
        anim.SetBool("happy", false);
    }

    // Update is called once per frame
    void Update()
    {   
    }

    void onMouseDown() {
        Debug.Log("NPC");
        if (talkedtoNPC == false) {
            Instantiate(chatBubble, chatBubble.transform.position, Quaternion.identity);
            talkedtoNPC = true;
        }
    }
}
