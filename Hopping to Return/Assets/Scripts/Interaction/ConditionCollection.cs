using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Conditions/Collection")]
public class ConditionCollection : ScriptableObject
{
  public string description;
  public Condition[] conditions;
  public ReactionCollection reaction;

  public bool CheckAndReact(MonoBehaviour mono)
  {
    for (int i = 0; i < conditions.Length; i++)
    {
      if (!conditions[i].isSatisfied())
      {
        return false;
      }
    }
    // All conditions satisfied: Do reactions
    if (reaction)
      reaction.React(mono);
    return true;
  }

  internal void Init(MonoBehaviour mono)
  {
    for (int i = 0; i < conditions.Length; i++)
    {
      conditions[i].Init();
    }
    reaction.Init(mono);
  }
}
