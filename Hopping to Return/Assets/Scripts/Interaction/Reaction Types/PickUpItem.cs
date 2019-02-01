using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reactions/Pick up item")]
public class PickUpItem : Reaction
{
  public string itemTag;
  Pickup item;

  public override void Init()
  {
    item = GameObject.FindWithTag("flashlight").GetComponent<Pickup>();
  }

  public override void React()
  {
    item.Work();
  }

}
