using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Reactions/Destroy Object")]
public class DestroyObject : DelayedReaction
{
  public string tag;
  GameObject obj;

  public override void Init()
  {
    obj = GameObject.FindWithTag(tag);
  }

  public override void React()
  {
    Destroy(obj);
  }
}
