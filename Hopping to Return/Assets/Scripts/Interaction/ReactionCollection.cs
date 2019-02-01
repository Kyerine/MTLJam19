using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reactions/Collection")]
public class ReactionCollection : ScriptableObject
{
  public Reaction[] reactions;
  public void React(MonoBehaviour mono)
  {
     for(int i = 0; i < reactions.Length; i++)
    {
      DelayedReaction delayed = reactions[i] as DelayedReaction;
      if (delayed)
      {
        delayed.React(mono);
      }
      else
        reactions[i].React();
    }
  }

  public void Init(MonoBehaviour mono)
  {
    for(int i = 0; i < reactions.Length; i++)
    {
      DelayedReaction delayed = reactions[i] as DelayedReaction;
      if (delayed)
        delayed.Init(mono);
      else
        reactions[i].Init();
    }
  }
}
