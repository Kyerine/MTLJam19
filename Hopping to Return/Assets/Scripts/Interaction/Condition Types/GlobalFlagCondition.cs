using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Global Flag Condition")]
public class GlobalFlagCondition : Condition
{
  public GlobalFlag flag;
  public string description;
  public bool expectedValue;


  public override void Init()
  {
  }

  public override bool isSatisfied()
  {
    Debug.Log("Checking if condition is satisfied");
    return flag.GetValue() == expectedValue;
  }
}
