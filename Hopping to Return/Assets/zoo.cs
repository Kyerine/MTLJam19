using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoo : MonoBehaviour
{

    GameObject miner;

    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        miner = GameObject.FindGameObjectWithTag("MineGuy");
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 3)
        {
            miner.GetComponent<Animator>().SetBool("Happy", true);
            score = 0;
        }
    }
}
