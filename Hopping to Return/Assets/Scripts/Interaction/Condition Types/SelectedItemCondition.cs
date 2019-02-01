using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Selected Item Condition")]
public class SelectedItemCondition : Condition
{
  public Pickup requiredItem;
  Player player;
  public override void Init()
  {
    player = GameObject.FindWithTag("Player").GetComponent<Player>();
  }

  public override bool isSatisfied()
  {
    Debug.Log("Check if equipped " + requiredItem.tag);
    return player.GetTriggerItem() == requiredItem.tag;
  }
}
