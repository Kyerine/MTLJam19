using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Item Selected Condition")]
public class ItemSelectedCondition : Condition
{
    public InventoryItem item;
    Player player;
    // Start is called before the first frame update
    public override void Init()
    {
     player = FindObjectOfType<Player>();
    }

    public override bool isSatisfied()
    {
      return true;
    }
}
