using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reactions/Enable Object")]
public class EnableObject : Reaction
{
    public string objectTag;
    GameObject obj;
    GameObject flight;
    public override void Init()
    {
      obj = GameObject.FindWithTag(objectTag);
    }

    public override void React()
    {
      //obj.SetActive(true);
    }
}
